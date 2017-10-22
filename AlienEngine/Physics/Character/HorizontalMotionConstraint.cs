using System;
using AlienEngine.Core.Physics.BroadPhaseEntries.MobileCollidables;
using AlienEngine.Core.Physics.Constraints;
using AlienEngine.Core.Physics.Entities;
using AlienEngine.Core.Physics.Utilities;
using AlienEngine.Core.Utils.DataStructures;

namespace AlienEngine.Core.Physics.Character
{
    /// <summary>
    /// Manages the horizontal movement of a character.
    /// </summary>
    public class HorizontalMotionConstraint : SolverUpdateable
    {
        Entity characterBody;
        private SupportFinder supportFinder;


        SupportData supportData;

        Vector2f movementDirection;
        /// <summary>
        /// Gets or sets the goal movement direction.
        /// The movement direction is based on the view direction.
        /// Values of X are applied to the axis perpendicular to the HorizontalViewDirection and Down direction.
        /// Values of Y are applied to the HorizontalViewDirection.
        /// </summary>
        public Vector2f MovementDirection
        {
            get { return movementDirection; }
            set
            {
                if (movementDirection.X != value.X || movementDirection.Y != value.Y) //Floating point comparison is perfectly fine here. Any bitwise variation should go through.
                {
                    characterBody.ActivityInformation.Activate();

                    float lengthSquared = value.LengthSquared;
                    if (lengthSquared > MathHelper.Epsilon)
                    {
                        Vector2f.Divide(ref value, (float)Math.Sqrt(lengthSquared), out movementDirection);
                    }
                    else
                    {
                        movementDirection = new Vector2f();
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets the target speed of the character in its current state.
        /// </summary>
        public float TargetSpeed { get; set; }
        /// <summary>
        /// Gets or sets the maximum force the character can apply to move horizontally in its current state.
        /// </summary>
        public float MaximumForce { get; set; }
        /// <summary>
        /// Gets or sets the maximum force the character can apply to accelerate. 
        /// This will not let the character apply more force than the MaximumForce; the actual applied force is constrained by both this and the MaximumForce property.
        /// </summary>
        public float MaximumAccelerationForce { get; set; }
        float maxForceDt;
        float maxAccelerationForceDt;

        private float timeUntilPositionAnchor = .2f;

        /// <summary>
        /// <para>Gets or sets the time it takes for the character to achieve stable footing after trying to stop moving.
        /// When a character has stable footing, it will resist position drift relative to its support. For example,
        /// if the player was on a rotating platform, integrating the velocity repeatedly would otherwise make the character gradually shift
        /// relative to the support.</para>
        /// <para>This time should be longer than the time it takes the player to decelerate from normal movement while it has traction. Otherwise, the character 
        /// will seem to 'rubber band' back to a previous location after the character tries to stop.</para>
        /// </summary>
        public float TimeUntilPositionAnchor
        {
            get { return timeUntilPositionAnchor; }
            set { timeUntilPositionAnchor = value; }
        }

        /// <summary>
        /// Gets or sets the distance beyond which the character will reset its goal position.
        /// When a character is standing still (as defined by TimeUntilStableFooting), a shove smaller than this threshold will result in an attempt to return to the previous anchor.
        /// A shove which pushes the character more than this threshold will cause a new anchor to be created.
        /// </summary>
        public float PositionAnchorDistanceThreshold { get; set; }

        /// <summary>
        /// <para>Gets whether the character currently has stable footing. If true, the character will resist position drift relative to its support. For example,
        /// if the character was on a rotating platform while trying to stand still relative to the platform, integrating the velocity repeatedly would make the character gradually shift
        /// relative to the platform. The anchoring effect of stable footing keeps the character near the same relative location.</para>
        /// <para>Can only occur when the character has traction and is not trying to move while standing on an entity.</para>
        /// </summary>
        public bool HasPositionAnchor
        {
            get { return timeSinceTransition < 0; }
        }

        /// <summary>
        /// Forces a recomputation of the position anchor during the next update if a position anchor is currently active.
        /// The new position anchor will be dropped at the character's location as of the next update.
        /// </summary>
        public void ResetPositionAnchor()
        {
            if (HasPositionAnchor)
                timeSinceTransition = timeUntilPositionAnchor;
        }


        /// <summary>
        /// Gets or sets the current movement style used by the character.
        /// </summary>
        public MovementMode MovementMode { get; set; }


        internal Vector3f movementDirection3d;

        /// <summary>
        /// Gets the 3d movement direction, as updated in the previous call to UpdateMovementBasis.
        /// Note that this will not change when MovementDirection is set. It only changes on a call to UpdateMovementBasis.
        /// So, getting this value externally will get the previous frame's snapshot.
        /// </summary>
        public Vector3f MovementDirection3d
        {
            get { return movementDirection3d; }
        }

        Vector3f strafeDirection;
        /// <summary>
        /// Gets the strafe direction as updated in the previous call to UpdateMovementBasis.
        /// </summary>
        public Vector3f StrafeDirection
        {
            get
            {
                return strafeDirection;
            }
        }

        Vector3f horizontalForwardDirection;
        /// <summary>
        /// Gets the horizontal forward direction as updated in the previous call to UpdateMovementBasis.
        /// </summary>
        public Vector3f ForwardDirection
        {
            get
            {
                return horizontalForwardDirection;
            }
        }

        /// <summary>
        /// Updates the movement basis of the horizontal motion constraint.
        /// Should be updated automatically by the character on each time step; other code should not need to call this.
        /// </summary>
        /// <param name="forward">Forward facing direction of the character.</param>
        public void UpdateMovementBasis(ref Vector3f forward)
        {
            Vector3f down = characterBody.orientationMatrix.Down;
            horizontalForwardDirection = forward - down * Vector3f.Dot(down, forward);
            float forwardLengthSquared = horizontalForwardDirection.LengthSquared;

            if (forwardLengthSquared < MathHelper.Epsilon)
            {
                //Use an arbitrary direction to complete the basis.
                horizontalForwardDirection = characterBody.orientationMatrix.Forward;
                strafeDirection = characterBody.orientationMatrix.Right;
            }
            else
            {
                Vector3f.Divide(ref horizontalForwardDirection, (float)Math.Sqrt(forwardLengthSquared), out horizontalForwardDirection);
                Vector3f.Cross(ref down, ref horizontalForwardDirection, out strafeDirection);
                //Don't need to normalize the strafe direction; it's the cross product of two normalized perpendicular vectors.
            }


            Vector3f.Multiply(ref horizontalForwardDirection, movementDirection.Y, out movementDirection3d);
            Vector3f strafeComponent;
            Vector3f.Multiply(ref strafeDirection, movementDirection.X, out strafeComponent);
            Vector3f.Add(ref strafeComponent, ref movementDirection3d, out movementDirection3d);

        }

        /// <summary>
        /// Updates the constraint's view of the character's support data.
        /// </summary>
        public void UpdateSupportData()
        {
            //Check if the support has changed, and perform the necessary bookkeeping to keep the connections up to date.
            var oldSupport = supportData.SupportObject;
            supportData = supportFinder.SupportData;
            if (oldSupport != supportData.SupportObject)
            {
                OnInvolvedEntitiesChanged();
                var supportEntityCollidable = supportData.SupportObject as EntityCollidable;
                if (supportEntityCollidable != null)
                {
                    supportEntity = supportEntityCollidable.Entity;
                }
                else
                {
                    //We aren't on an entity, so clear out the support entity.
                    supportEntity = null;
                }
            }
        }

        float supportForceFactor = 1;
        /// <summary>
        /// Gets or sets the scaling factor of forces applied to the supporting object if it is a dynamic entity.
        /// Low values (below 1) reduce the amount of motion imparted to the support object; it acts 'heavier' as far as horizontal motion is concerned.
        /// High values (above 1) increase the force applied to support objects, making them appear lighter.
        /// Be careful when changing this- it can create impossible situations!
        /// </summary>
        public float SupportForceFactor
        {
            get
            {
                return supportForceFactor;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value must be nonnegative.");
                supportForceFactor = value;
            }
        }





        Matrix2f massMatrix;
        Entity supportEntity;
        Vector3f linearJacobianA1;
        Vector3f linearJacobianA2;
        Vector3f linearJacobianB1;
        Vector3f linearJacobianB2;
        Vector3f angularJacobianB1;
        Vector3f angularJacobianB2;

        Vector2f accumulatedImpulse;
        Vector2f targetVelocity;

        Vector2f positionCorrectionBias;

        Vector3f positionLocalOffset;
        bool wasTryingToMove;
        bool hadTraction;
        Entity previousSupportEntity;
        float timeSinceTransition;
        bool isTryingToMove;

        /// <summary>
        /// Constructs a new horizontal motion constraint.
        /// </summary>
        /// <param name="characterBody">Character body to be governed by this constraint.</param>
        /// <param name="supportFinder">Helper used to find supports for the character.</param>
        public HorizontalMotionConstraint(Entity characterBody, SupportFinder supportFinder)
        {
            this.characterBody = characterBody;
            this.supportFinder = supportFinder;
            CollectInvolvedEntities();
            MaximumAccelerationForce = float.MaxValue;
        }



        protected internal override void CollectInvolvedEntities(RawList<Entity> outputInvolvedEntities)
        {
            var entityCollidable = supportData.SupportObject as EntityCollidable;
            if (entityCollidable != null)
                outputInvolvedEntities.Add(entityCollidable.Entity);
            outputInvolvedEntities.Add(characterBody);

        }


        /// <summary>
        /// Computes per-frame information necessary for the constraint.
        /// </summary>
        /// <param name="dt">Time step duration.</param>
        public override void Update(float dt)
        {

            isTryingToMove = movementDirection3d.LengthSquared > 0;

            maxForceDt = MaximumForce * dt;
            maxAccelerationForceDt = MaximumAccelerationForce * dt;


            //Compute the jacobians.  This is basically a PointOnLineJoint with motorized degrees of freedom.
            Vector3f downDirection = characterBody.orientationMatrix.Down;

            if (MovementMode != MovementMode.Floating)
            {
                //Compute the linear jacobians first.
                if (isTryingToMove)
                {
                    Vector3f velocityDirection;
                    Vector3f offVelocityDirection;
                    //Project the movement direction onto the support plane defined by the support normal.
                    //This projection is NOT along the support normal to the plane; that would cause the character to veer off course when moving on slopes.
                    //Instead, project along the sweep direction to the plane.
                    //For a 6DOF character controller, the lineStart would be different; it must be perpendicular to the local up.
                    Vector3f lineStart = movementDirection3d;

                    Vector3f lineEnd;
                    Vector3f.Add(ref lineStart, ref downDirection, out lineEnd);
                    Plane plane = new Plane(supportData.Normal, 0);
                    float t;
                    //This method can return false when the line is parallel to the plane, but previous tests and the slope limit guarantee that it won't happen.
                    Toolbox.GetLinePlaneIntersection(ref lineStart, ref lineEnd, ref plane, out t, out velocityDirection);

                    //The origin->intersection line direction defines the horizontal velocity direction in 3d space.
                    velocityDirection.Normalize();


                    //The normal and velocity direction are perpendicular and normal, so the off velocity direction doesn't need to be normalized.
                    Vector3f.Cross(ref velocityDirection, ref supportData.Normal, out offVelocityDirection);

                    linearJacobianA1 = velocityDirection;
                    linearJacobianA2 = offVelocityDirection;
                    linearJacobianB1 = -velocityDirection;
                    linearJacobianB2 = -offVelocityDirection;

                }
                else
                {
                    //If the character isn't trying to move, then the velocity directions are not well defined.
                    //Instead, pick two arbitrary vectors on the support plane.
                    //First guess will be based on the previous jacobian.
                    //Project the old linear jacobian onto the support normal plane.
                    float dot;
                    Vector3f.Dot(ref linearJacobianA1, ref supportData.Normal, out dot);
                    Vector3f toRemove;
                    Vector3f.Multiply(ref supportData.Normal, dot, out toRemove);
                    Vector3f.Subtract(ref linearJacobianA1, ref toRemove, out linearJacobianA1);

                    //Vector3f.Cross(ref linearJacobianA2, ref supportData.Normal, out linearJacobianA1);
                    float length = linearJacobianA1.LengthSquared;
                    if (length < MathHelper.Epsilon)
                    {
                        //First guess failed.  Try the right vector.
                        Vector3f.Cross(ref Toolbox.RightVector, ref supportData.Normal, out linearJacobianA1);
                        length = linearJacobianA1.LengthSquared;
                        if (length < MathHelper.Epsilon)
                        {
                            //Okay that failed too! try the forward vector.
                            Vector3f.Cross(ref Toolbox.ForwardVector, ref supportData.Normal, out linearJacobianA1);
                            length = linearJacobianA1.LengthSquared;
                            //Unless something really weird is happening, we do not need to test any more axes.
                        }

                    }
                    Vector3f.Divide(ref linearJacobianA1, (float)Math.Sqrt(length), out linearJacobianA1);
                    //Pick another perpendicular vector.  Don't need to normalize it since the normal and A1 are already normalized and perpendicular.
                    Vector3f.Cross(ref linearJacobianA1, ref supportData.Normal, out linearJacobianA2);

                    //B's linear jacobians are just -A's.
                    linearJacobianB1 = -linearJacobianA1;
                    linearJacobianB2 = -linearJacobianA2;

                }

                if (supportEntity != null)
                {
                    //Compute the angular jacobians.
                    Vector3f supportToContact = supportData.Position - supportEntity.Position;
                    //Since we treat the character to have infinite inertia, we're only concerned with the support's angular jacobians.
                    //Note the order of the cross product- it is reversed to negate the result.
                    Vector3f.Cross(ref linearJacobianA1, ref supportToContact, out angularJacobianB1);
                    Vector3f.Cross(ref linearJacobianA2, ref supportToContact, out angularJacobianB2);

                }
                else
                {
                    //If we're not standing on an entity, there are no angular jacobians.
                    angularJacobianB1 = new Vector3f();
                    angularJacobianB2 = new Vector3f();
                }
            }
            else
            {
                //If the character is floating, then the jacobians are simply the 3d movement direction and the perpendicular direction on the character's horizontal plane.
                linearJacobianA1 = movementDirection3d;
                linearJacobianA2 = Vector3f.Cross(linearJacobianA1, characterBody.orientationMatrix.Down);


            }


            //Compute the target velocity (in constraint space) for this frame.  The hard work has already been done.
            targetVelocity.X = isTryingToMove ? TargetSpeed : 0;
            targetVelocity.Y = 0;

            //Compute the effective mass matrix.
            if (supportEntity != null && supportEntity.IsDynamic)
            {
                float m11, m22, m1221 = 0;
                float inverseMass;
                Vector3f intermediate;

                inverseMass = characterBody.InverseMass;
                m11 = inverseMass;
                m22 = inverseMass;


                //Scale the inertia and mass of the support.  This will make the solver view the object as 'heavier' with respect to horizontal motion.
                Matrix3f inertiaInverse = supportEntity.InertiaTensorInverse;
                Matrix3f.Multiply(ref inertiaInverse, supportForceFactor, out inertiaInverse);
                float extra;
                inverseMass = supportForceFactor * supportEntity.InverseMass;
                Vector3f.Transform(ref angularJacobianB1, ref inertiaInverse, out intermediate);
                Vector3f.Dot(ref intermediate, ref angularJacobianB1, out extra);
                m11 += inverseMass + extra;
                Vector3f.Dot(ref intermediate, ref angularJacobianB2, out extra);
                m1221 += extra;
                Vector3f.Transform(ref angularJacobianB2, ref inertiaInverse, out intermediate);
                Vector3f.Dot(ref intermediate, ref angularJacobianB2, out extra);
                m22 += inverseMass + extra;


                massMatrix.M11 = m11;
                massMatrix.M12 = m1221;
                massMatrix.M21 = m1221;
                massMatrix.M22 = m22;
                Matrix2f.Invert(ref massMatrix, out massMatrix);


            }
            else
            {
                //If we're not standing on a dynamic entity, then the mass matrix is defined entirely by the character.
                Matrix2f.CreateScale(characterBody.Mass, out massMatrix);
            }

            //If we're trying to stand still on an object that's moving, use a position correction term to keep the character
            //from drifting due to accelerations. 
            //First thing to do is to check to see if we're moving into a traction/trying to stand still state from a 
            //non-traction || trying to move state.  Either that, or we've switched supports and need to update the offset.
            if (supportEntity != null && ((wasTryingToMove && !isTryingToMove) || (!hadTraction && supportFinder.HasTraction) || supportEntity != previousSupportEntity))
            {
                //We're transitioning into a new 'use position correction' state.
                //Force a recomputation of the local offset.
                //The time since transition is used as a flag.
                timeSinceTransition = 0;
            }

            //The state is now up to date.  Compute an error and velocity bias, if needed.
            if (!isTryingToMove && MovementMode == MovementMode.Traction && supportEntity != null)
            {

                var distanceToBottomOfCharacter = supportFinder.BottomDistance;

                if (timeSinceTransition >= 0 && timeSinceTransition < timeUntilPositionAnchor)
                    timeSinceTransition += dt;
                if (timeSinceTransition >= timeUntilPositionAnchor)
                {
                    Vector3f.Multiply(ref downDirection, distanceToBottomOfCharacter, out positionLocalOffset);
                    positionLocalOffset = (positionLocalOffset + characterBody.Position) - supportEntity.Position;
                    positionLocalOffset = Vector3f.TransformTranspose(positionLocalOffset, supportEntity.OrientationMatrix);
                    timeSinceTransition = -1; //Negative 1 means that the offset has been computed.
                }
                if (timeSinceTransition < 0)
                {
                    Vector3f targetPosition;
                    Vector3f.Multiply(ref downDirection, distanceToBottomOfCharacter, out targetPosition);
                    targetPosition += characterBody.Position;
                    Vector3f worldSupportLocation = Vector3f.Transform(positionLocalOffset, supportEntity.OrientationMatrix) + supportEntity.Position;
                    Vector3f error;
                    Vector3f.Subtract(ref targetPosition, ref worldSupportLocation, out error);
                    //If the error is too large, then recompute the offset.  We don't want the character rubber banding around.
                    if (error.LengthSquared > PositionAnchorDistanceThreshold * PositionAnchorDistanceThreshold)
                    {
                        Vector3f.Multiply(ref downDirection, distanceToBottomOfCharacter, out positionLocalOffset);
                        positionLocalOffset = (positionLocalOffset + characterBody.Position) - supportEntity.Position;
                        positionLocalOffset = Vector3f.TransformTranspose(positionLocalOffset, supportEntity.OrientationMatrix);
                        positionCorrectionBias = new Vector2f();
                    }
                    else
                    {
                        //The error in world space is now available.  We can't use this error to directly create a velocity bias, though.
                        //It needs to be transformed into constraint space where the constraint operates.
                        //Use the jacobians!
                        Vector3f.Dot(ref error, ref linearJacobianA1, out positionCorrectionBias.X);
                        Vector3f.Dot(ref error, ref linearJacobianA2, out positionCorrectionBias.Y);
                        //Scale the error so that a portion of the error is resolved each frame.
                        Vector2f.Multiply(ref positionCorrectionBias, .2f / dt, out positionCorrectionBias);
                    }
                }
            }
            else
            {
                timeSinceTransition = 0;
                positionCorrectionBias = new Vector2f();
            }

            wasTryingToMove = isTryingToMove;
            hadTraction = supportFinder.HasTraction;
            previousSupportEntity = supportEntity;

        }


        /// <summary>
        /// Performs any per-frame initialization needed by the constraint that must be done with exclusive access
        /// to the connected objects.
        /// </summary>
        public override void ExclusiveUpdate()
        {
            //Warm start the constraint using the previous impulses and the new jacobians!
#if !WINDOWS
            Vector3f impulse = new Vector3f();
            Vector3f torque= new Vector3f();
#else
            Vector3f impulse;
            Vector3f torque;
#endif
            float x = accumulatedImpulse.X;
            float y = accumulatedImpulse.Y;
            impulse.X = linearJacobianA1.X * x + linearJacobianA2.X * y;
            impulse.Y = linearJacobianA1.Y * x + linearJacobianA2.Y * y;
            impulse.Z = linearJacobianA1.Z * x + linearJacobianA2.Z * y;

            characterBody.ApplyLinearImpulse(ref impulse);

            if (supportEntity != null && supportEntity.IsDynamic)
            {
                Vector3f.Multiply(ref impulse, -supportForceFactor, out impulse);

                x *= supportForceFactor;
                y *= supportForceFactor;
                torque.X = x * angularJacobianB1.X + y * angularJacobianB2.X;
                torque.Y = x * angularJacobianB1.Y + y * angularJacobianB2.Y;
                torque.Z = x * angularJacobianB1.Z + y * angularJacobianB2.Z;


                supportEntity.ApplyLinearImpulse(ref impulse);
                supportEntity.ApplyAngularImpulse(ref torque);
            }
        }

        /// <summary>
        /// Computes a solution to the constraint.
        /// </summary>
        /// <returns>Impulse magnitude computed by the iteration.</returns>
        public override float SolveIteration()
        {

            Vector2f relativeVelocity = RelativeVelocity;

            Vector2f.Add(ref relativeVelocity, ref positionCorrectionBias, out relativeVelocity);


            //Create the full velocity change, and convert it to an impulse in constraint space.
            Vector2f lambda;
            Vector2f.Subtract(ref targetVelocity, ref relativeVelocity, out lambda);
            Vector2f.Transform(ref lambda, ref massMatrix, out lambda);

            //Add and clamp the impulse.

            Vector2f previousAccumulatedImpulse = accumulatedImpulse;
            if (MovementMode == MovementMode.Floating)
            {
                //If it's floating, clamping rules are different.
                //The constraint is not permitted to slow down the character; only speed it up.
                //This offers a hole for an exploit; by jumping and curving just right,
                //the character can accelerate beyond its maximum speed.  A bit like an HL2 speed run.
                accumulatedImpulse.X = MathHelper.Clamp(accumulatedImpulse.X + lambda.X, 0, maxForceDt);
                accumulatedImpulse.Y = 0;
            }
            else
            {

                Vector2f.Add(ref lambda, ref accumulatedImpulse, out accumulatedImpulse);
                float length = accumulatedImpulse.LengthSquared;
                if (length > maxForceDt * maxForceDt)
                {
                    Vector2f.Multiply(ref accumulatedImpulse, maxForceDt / (float)Math.Sqrt(length), out accumulatedImpulse);
                }
                if (isTryingToMove && accumulatedImpulse.X > maxAccelerationForceDt)
                {
                    accumulatedImpulse.X = maxAccelerationForceDt;
                }
            }
            Vector2f.Subtract(ref accumulatedImpulse, ref previousAccumulatedImpulse, out lambda);


            //Use the jacobians to put the impulse into world space.

#if !WINDOWS
            Vector3f impulse = new Vector3f();
            Vector3f torque= new Vector3f();
#else
            Vector3f impulse;
            Vector3f torque;
#endif
            float x = lambda.X;
            float y = lambda.Y;
            impulse.X = linearJacobianA1.X * x + linearJacobianA2.X * y;
            impulse.Y = linearJacobianA1.Y * x + linearJacobianA2.Y * y;
            impulse.Z = linearJacobianA1.Z * x + linearJacobianA2.Z * y;

            characterBody.ApplyLinearImpulse(ref impulse);

            if (supportEntity != null && supportEntity.IsDynamic)
            {
                Vector3f.Multiply(ref impulse, -supportForceFactor, out impulse);

                x *= supportForceFactor;
                y *= supportForceFactor;
                torque.X = x * angularJacobianB1.X + y * angularJacobianB2.X;
                torque.Y = x * angularJacobianB1.Y + y * angularJacobianB2.Y;
                torque.Z = x * angularJacobianB1.Z + y * angularJacobianB2.Z;

                supportEntity.ApplyLinearImpulse(ref impulse);
                supportEntity.ApplyAngularImpulse(ref torque);
            }

            return (Math.Abs(lambda.X) + Math.Abs(lambda.Y));


        }


        /// <summary>
        /// Gets the current velocity between the character and its support in constraint space.
        /// The X component corresponds to velocity along the movement direction.
        /// The Y component corresponds to velocity perpendicular to the movement direction and support normal.
        /// </summary>
        public Vector2f RelativeVelocity
        {
            get
            {
                //The relative velocity's x component is in the movement direction.
                //y is the perpendicular direction.
#if !WINDOWS
                Vector2f relativeVelocity = new Vector2f();
#else
                Vector2f relativeVelocity;
#endif

                Vector3f.Dot(ref linearJacobianA1, ref characterBody.linearVelocity, out relativeVelocity.X);
                Vector3f.Dot(ref linearJacobianA2, ref characterBody.linearVelocity, out relativeVelocity.Y);

                float x, y;
                if (supportEntity != null)
                {
                    Vector3f.Dot(ref linearJacobianB1, ref supportEntity.linearVelocity, out x);
                    Vector3f.Dot(ref linearJacobianB2, ref supportEntity.linearVelocity, out y);
                    relativeVelocity.X += x;
                    relativeVelocity.Y += y;
                    Vector3f.Dot(ref angularJacobianB1, ref supportEntity.angularVelocity, out x);
                    Vector3f.Dot(ref angularJacobianB2, ref supportEntity.angularVelocity, out y);
                    relativeVelocity.X += x;
                    relativeVelocity.Y += y;

                }
                return relativeVelocity;
            }
        }

        /// <summary>
        /// Gets the current velocity between the character and its support.
        /// </summary>
        public Vector3f RelativeWorldVelocity
        {
            get
            {
                Vector3f bodyVelocity = characterBody.LinearVelocity;
                if (supportEntity != null)
                    return bodyVelocity - Toolbox.GetVelocityOfPoint(supportData.Position, supportEntity.Position, supportEntity.LinearVelocity, supportEntity.AngularVelocity);
                return bodyVelocity;
            }
        }

        /// <summary>
        /// Gets the velocity of the support at the support point.
        /// </summary>
        public Vector3f SupportVelocity
        {
            get
            {
                return supportEntity == null ? new Vector3f() : Toolbox.GetVelocityOfPoint(supportData.Position, supportEntity.Position, supportEntity.LinearVelocity, supportEntity.AngularVelocity);
            }
        }


        /// <summary>
        /// Gets the accumulated impulse in world space applied to the character.
        /// </summary>
        public Vector3f CharacterAccumulatedImpulse
        {
            get
            {

                Vector3f impulse;
                impulse.X = accumulatedImpulse.X * linearJacobianA1.X + accumulatedImpulse.Y * linearJacobianA2.X;
                impulse.Y = accumulatedImpulse.X * linearJacobianA1.Y + accumulatedImpulse.Y * linearJacobianA2.Y;
                impulse.Z = accumulatedImpulse.X * linearJacobianA1.Z + accumulatedImpulse.Y * linearJacobianA2.Z;
                return impulse;
            }
        }

        /// <summary>
        /// Gets the accumulated impulse in constraint space.
        /// The X component corresponds to impulse along the movement direction.
        /// The Y component corresponds to impulse perpendicular to the movement direction and support normal.
        /// </summary>
        public Vector2f AccumulatedImpulse
        {
            get
            {
                return accumulatedImpulse;
            }
        }

    }


}
