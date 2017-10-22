using System;
using AlienEngine.Core.Physics.Entities;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.Constraints.TwoEntity.JointLimits
{
    /// <summary>
    /// Keeps the angle between the axes attached to two entities below some maximum value.
    /// </summary>
    public class SwingLimit : JointLimit, I1DImpulseConstraintWithError, I1DJacobianConstraint
    {
        private float accumulatedImpulse;
        private float biasVelocity;
        private Vector3f hingeAxis;
        private float minimumCosine = 1;
        private float error;

        private Vector3f localAxisA;

        private Vector3f localAxisB;
        private Vector3f worldAxisA;

        private Vector3f worldAxisB;
        private float velocityToImpulse;

        /// <summary>
        /// Constructs a new constraint which attempts to restrict the maximum relative angle of two entities to some value.
        /// To finish the initialization, specify the connections (ConnectionA and ConnectionB) 
        /// as well as the WorldAxisA, WorldAxisB (or their entity-local versions) and the MaximumAngle.
        /// This constructor sets the constraint's IsActive property to false by default.
        /// </summary>
        public SwingLimit()
        {
            IsActive = false;
        }

        /// <summary>
        /// Constructs a new constraint which attempts to restrict the maximum relative angle of two entities to some value.
        /// </summary>
        /// <param name="connectionA">First connection of the pair.</param>
        /// <param name="connectionB">Second connection of the pair.</param>
        /// <param name="axisA">Axis attached to the first connected entity.</param>
        /// <param name="axisB">Axis attached to the second connected entity.</param>
        /// <param name="maximumAngle">Maximum angle between the axes allowed.</param>
        public SwingLimit(Entity connectionA, Entity connectionB, Vector3f axisA, Vector3f axisB, float maximumAngle)
        {
            ConnectionA = connectionA;
            ConnectionB = connectionB;
            WorldAxisA = axisA;
            WorldAxisB = axisB;
            MaximumAngle = maximumAngle;
        }

        /// <summary>
        /// Gets or sets the axis attached to the first connected entity in its local space.
        /// </summary>
        public Vector3f LocalAxisA
        {
            get { return localAxisA; }
            set
            {
                localAxisA = Vector3f.Normalize(value);
                Vector3f.Transform(ref localAxisA, ref connectionA.orientationMatrix, out worldAxisA);
            }
        }

        /// <summary>
        /// Gets or sets the axis attached to the first connected entity in its local space.
        /// </summary>
        public Vector3f LocalAxisB
        {
            get { return localAxisB; }
            set
            {
                localAxisB = Vector3f.Normalize(value);
                Vector3f.Transform(ref localAxisB, ref connectionA.orientationMatrix, out worldAxisB);
            }
        }

        /// <summary>
        /// Maximum angle allowed between the two axes, from 0 to pi.
        /// </summary>
        public float MaximumAngle
        {
            get { return (float)Math.Acos(minimumCosine); }
            set { minimumCosine = (float)Math.Cos(MathHelper.Clamp(value, 0, MathHelper.Pi)); }
        }

        /// <summary>
        /// Gets or sets the axis attached to the first connected entity in world space.
        /// </summary>
        public Vector3f WorldAxisA
        {
            get { return worldAxisA; }
            set
            {
                worldAxisA = Vector3f.Normalize(value);
                Quaternion conjugate;
                Quaternion.Conjugate(ref connectionA.orientation, out conjugate);
                Vector3f.Transform(ref worldAxisA, ref conjugate, out localAxisA);
            }
        }

        /// <summary>
        /// Gets or sets the axis attached to the first connected entity in world space.
        /// </summary>
        public Vector3f WorldAxisB
        {
            get { return worldAxisB; }
            set
            {
                worldAxisB = Vector3f.Normalize(value);
                Quaternion conjugate;
                Quaternion.Conjugate(ref connectionB.orientation, out conjugate);
                Vector3f.Transform(ref worldAxisB, ref conjugate, out localAxisB);
            }
        }

        #region I1DImpulseConstraintWithError Members

        /// <summary>
        /// Gets the current relative velocity between the connected entities with respect to the constraint.
        /// </summary>
        public float RelativeVelocity
        {
            get
            {
                if (isLimitActive)
                {
                    Vector3f relativeVelocity;
                    Vector3f.Subtract(ref connectionA.angularVelocity, ref connectionB.angularVelocity, out relativeVelocity);
                    float lambda;
                    Vector3f.Dot(ref relativeVelocity, ref hingeAxis, out lambda);
                    return lambda;
                }
                return 0;
            }
        }

        /// <summary>
        /// Gets the total impulse applied by this constraint.
        /// </summary>
        public float TotalImpulse
        {
            get { return accumulatedImpulse; }
        }

        /// <summary>
        /// Gets the current constraint error.
        /// </summary>
        public float Error
        {
            get { return error; }
        }

        #endregion

        #region I1DJacobianConstraint Members

        /// <summary>
        /// Gets the linear jacobian entry for the first connected entity.
        /// </summary>
        /// <param name="jacobian">Linear jacobian entry for the first connected entity.</param>
        public void GetLinearJacobianA(out Vector3f jacobian)
        {
            jacobian = Toolbox.ZeroVector;
        }

        /// <summary>
        /// Gets the linear jacobian entry for the second connected entity.
        /// </summary>
        /// <param name="jacobian">Linear jacobian entry for the second connected entity.</param>
        public void GetLinearJacobianB(out Vector3f jacobian)
        {
            jacobian = Toolbox.ZeroVector;
        }

        /// <summary>
        /// Gets the angular jacobian entry for the first connected entity.
        /// </summary>
        /// <param name="jacobian">Angular jacobian entry for the first connected entity.</param>
        public void GetAngularJacobianA(out Vector3f jacobian)
        {
            jacobian = hingeAxis;
        }

        /// <summary>
        /// Gets the angular jacobian entry for the second connected entity.
        /// </summary>
        /// <param name="jacobian">Angular jacobian entry for the second connected entity.</param>
        public void GetAngularJacobianB(out Vector3f jacobian)
        {
            jacobian = -hingeAxis;
        }

        /// <summary>
        /// Gets the mass matrix of the constraint.
        /// </summary>
        /// <param name="outputMassMatrix">Constraint's mass matrix.</param>
        public void GetMassMatrix(out float outputMassMatrix)
        {
            outputMassMatrix = velocityToImpulse;
        }

        #endregion

        /// <summary>
        /// Applies the sequential impulse.
        /// </summary>
        public override float SolveIteration()
        {
            float lambda;
            Vector3f relativeVelocity;
            Vector3f.Subtract(ref connectionA.angularVelocity, ref connectionB.angularVelocity, out relativeVelocity);
            //Transform the velocity to with the jacobian
            Vector3f.Dot(ref relativeVelocity, ref hingeAxis, out lambda);
            //Add in the constraint space bias velocity
            lambda = -lambda + biasVelocity - softness * accumulatedImpulse;

            //Transform to an impulse
            lambda *= velocityToImpulse;

            //Clamp accumulated impulse (can't go negative)
            float previousAccumulatedImpulse = accumulatedImpulse;
            accumulatedImpulse = MathHelper.Max(accumulatedImpulse + lambda, 0);
            lambda = accumulatedImpulse - previousAccumulatedImpulse;

            //Apply the impulse
            Vector3f impulse;
            Vector3f.Multiply(ref hingeAxis, lambda, out impulse);
            if (connectionA.isDynamic)
            {
                connectionA.ApplyAngularImpulse(ref impulse);
            }
            if (connectionB.isDynamic)
            {
                Vector3f.Negate(ref impulse, out impulse);
                connectionB.ApplyAngularImpulse(ref impulse);
            }

            return (Math.Abs(lambda));
        }

        /// <summary>
        /// Initializes the constraint for this frame.
        /// </summary>
        /// <param name="dt">Time since the last frame.</param>
        public override void Update(float dt)
        {
            Vector3f.Transform(ref localAxisA, ref connectionA.orientationMatrix, out worldAxisA);
            Vector3f.Transform(ref localAxisB, ref connectionB.orientationMatrix, out worldAxisB);

            float dot;
            Vector3f.Dot(ref worldAxisA, ref worldAxisB, out dot);

            //Keep in mind, the dot is the cosine of the angle.
            //1: 0 radians
            //0: pi/2 radians
            //-1: pi radians
            if (dot > minimumCosine)
            {
                isActiveInSolver = false;
                error = 0;
                accumulatedImpulse = 0;
                isLimitActive = false;
                return;
            }
            isLimitActive = true;

            //Hinge axis is actually the jacobian entry for angular A (negative angular B).
            Vector3f.Cross(ref worldAxisA, ref worldAxisB, out hingeAxis);
            float lengthSquared = hingeAxis.LengthSquared;
            if (lengthSquared < MathHelper.Epsilon)
            {
                //They're parallel; for the sake of continuity, pick some axis which is perpendicular to both that ISN'T the zero vector.
                Vector3f.Cross(ref worldAxisA, ref Toolbox.UpVector, out hingeAxis);
                lengthSquared = hingeAxis.LengthSquared;
                if (lengthSquared < MathHelper.Epsilon)
                {
                    //That's improbable; b's world axis was apparently parallel with the up vector!
                    //So just use the right vector (it can't be parallel with both the up and right vectors).
                    Vector3f.Cross(ref worldAxisA, ref Toolbox.RightVector, out hingeAxis);
                }
            }


            float errorReduction;
            springSettings.ComputeErrorReductionAndSoftness(dt, 1 / dt, out errorReduction, out softness);

            //Further away from 0 degrees is further negative; if the dot is below the minimum cosine, it means the angle is above the maximum angle.
            error = Math.Max(0, minimumCosine - dot - margin);
            biasVelocity = MathHelper.Clamp(errorReduction * error, -maxCorrectiveVelocity, maxCorrectiveVelocity);

            if (bounciness > 0)
            {
                //Compute the speed around the axis.
                float relativeSpeed;
                Vector3f relativeVelocity;
                Vector3f.Subtract(ref connectionA.angularVelocity, ref connectionB.angularVelocity, out relativeVelocity);
                Vector3f.Dot(ref relativeVelocity, ref hingeAxis, out relativeSpeed);

                biasVelocity = MathHelper.Max(biasVelocity, ComputeBounceVelocity(-relativeSpeed));
            }

            //Connection A's contribution to the mass matrix
            float entryA;
            Vector3f transformedAxis;
            if (connectionA.isDynamic)
            {
                Vector3f.Transform(ref hingeAxis, ref connectionA.inertiaTensorInverse, out transformedAxis);
                Vector3f.Dot(ref transformedAxis, ref hingeAxis, out entryA);
            }
            else
                entryA = 0;

            //Connection B's contribution to the mass matrix
            float entryB;
            if (connectionB.isDynamic)
            {
                Vector3f.Transform(ref hingeAxis, ref connectionB.inertiaTensorInverse, out transformedAxis);
                Vector3f.Dot(ref transformedAxis, ref hingeAxis, out entryB);
            }
            else
                entryB = 0;

            //Compute the inverse mass matrix
            velocityToImpulse = 1 / (softness + entryA + entryB);


        }

        public override void ExclusiveUpdate()
        {
            //Apply accumulated impulse
            Vector3f impulse;
            Vector3f.Multiply(ref hingeAxis, accumulatedImpulse, out impulse);
            if (connectionA.isDynamic)
            {
                connectionA.ApplyAngularImpulse(ref impulse);
            }
            if (connectionB.isDynamic)
            {
                Vector3f.Negate(ref impulse, out impulse);
                connectionB.ApplyAngularImpulse(ref impulse);
            }
        }
    }
}