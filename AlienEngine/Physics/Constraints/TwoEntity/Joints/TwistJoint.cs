using System;
using AlienEngine.Core.Physics.Entities;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.Constraints.TwoEntity.Joints
{
    /// <summary>
    /// Prevents the connected entities from twisting relative to each other.
    /// Acts like the angular part of a universal joint.
    /// </summary>
    public class TwistJoint : Joint, I1DImpulseConstraintWithError, I1DJacobianConstraint
    {
        private Vector3f aLocalAxisY, aLocalAxisZ;
        private float accumulatedImpulse;
        private Vector3f bLocalAxisY;
        private float biasVelocity;
        private Vector3f jacobianA, jacobianB;
        private float error;
        private Vector3f localAxisA;
        private Vector3f localAxisB;
        private Vector3f worldAxisA;
        private Vector3f worldAxisB;
        private float velocityToImpulse;

        /// <summary>
        /// Constructs a new constraint which prevents the connected entities from twisting relative to each other.
        /// To finish the initialization, specify the connections (ConnectionA and ConnectionB) 
        /// as well as the WorldAxisA and WorldAxisB (or their entity-local versions).
        /// This constructor sets the constraint's IsActive property to false by default.
        /// </summary>
        public TwistJoint()
        {
            IsActive = false;
        }

        /// <summary>
        /// Constructs a new constraint which prevents the connected entities from twisting relative to each other.
        /// </summary>
        /// <param name="connectionA">First connection of the pair.</param>
        /// <param name="connectionB">Second connection of the pair.</param>
        /// <param name="axisA">Twist axis attached to the first connected entity.</param>
        /// <param name="axisB">Twist axis attached to the second connected entity.</param>
        public TwistJoint(Entity connectionA, Entity connectionB, Vector3f axisA, Vector3f axisB)
        {
            ConnectionA = connectionA;
            ConnectionB = connectionB;
            WorldAxisA = axisA;
            WorldAxisB = axisB;
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
                Initialize();
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
                Initialize();
            }
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
                Initialize();
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
                Initialize();
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
                float velocityA, velocityB;
                Vector3f.Dot(ref connectionA.angularVelocity, ref jacobianA, out velocityA);
                Vector3f.Dot(ref connectionB.angularVelocity, ref jacobianB, out velocityB);
                return velocityA + velocityB;
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
            jacobian = jacobianA;
        }

        /// <summary>
        /// Gets the angular jacobian entry for the second connected entity.
        /// </summary>
        /// <param name="jacobian">Angular jacobian entry for the second connected entity.</param>
        public void GetAngularJacobianB(out Vector3f jacobian)
        {
            jacobian = jacobianB;
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
        /// Solves for velocity.
        /// </summary>
        public override float SolveIteration()
        {
            float velocityA, velocityB;
            //Find the velocity contribution from each connection
            Vector3f.Dot(ref connectionA.angularVelocity, ref jacobianA, out velocityA);
            Vector3f.Dot(ref connectionB.angularVelocity, ref jacobianB, out velocityB);
            //Add in the constraint space bias velocity
            float lambda = -(velocityA + velocityB) + biasVelocity - softness * accumulatedImpulse;

            //Transform to an impulse
            lambda *= velocityToImpulse;

            //Accumulate the impulse
            accumulatedImpulse += lambda;

            //Apply the impulse
            Vector3f impulse;
            if (connectionA.isDynamic)
            {
                Vector3f.Multiply(ref jacobianA, lambda, out impulse);
                connectionA.ApplyAngularImpulse(ref impulse);
            }
            if (connectionB.isDynamic)
            {
                Vector3f.Multiply(ref jacobianB, lambda, out impulse);
                connectionB.ApplyAngularImpulse(ref impulse);
            }

            return (Math.Abs(lambda));
        }

        /// <summary>
        /// Do any necessary computations to prepare the constraint for this frame.
        /// </summary>
        /// <param name="dt">Simulation step length.</param>
        public override void Update(float dt)
        {
            Vector3f aAxisY, aAxisZ;
            Vector3f bAxisY;
            Vector3f.Transform(ref localAxisA, ref connectionA.orientationMatrix, out worldAxisA);
            Vector3f.Transform(ref aLocalAxisY, ref connectionA.orientationMatrix, out aAxisY);
            Vector3f.Transform(ref aLocalAxisZ, ref connectionA.orientationMatrix, out aAxisZ);
            Vector3f.Transform(ref localAxisB, ref connectionB.orientationMatrix, out worldAxisB);
            Vector3f.Transform(ref bLocalAxisY, ref connectionB.orientationMatrix, out bAxisY);

            Quaternion rotation;
            Quaternion.GetQuaternionBetweenNormalizedVectors(ref worldAxisB, ref worldAxisA, out rotation);

            //Transform b's 'Y' axis so that it is perpendicular with a's 'X' axis for measurement.
            Vector3f twistMeasureAxis;
            Vector3f.Transform(ref bAxisY, ref rotation, out twistMeasureAxis);

            //By dotting the measurement vector with a 2d plane's axes, we can get a local X and Y value.
            float y, x;
            Vector3f.Dot(ref twistMeasureAxis, ref aAxisZ, out y);
            Vector3f.Dot(ref twistMeasureAxis, ref aAxisY, out x);
            error = (float) Math.Atan2(y, x);

            //Debug.WriteLine("Angle: " + angle);

            //The nice thing about this approach is that the jacobian entry doesn't flip.
            //Instead, the error can be negative due to the use of Atan2.
            //This is important for limits which have a unique high and low value.

            //Compute the jacobian.
            Vector3f.Add(ref worldAxisA, ref worldAxisB, out jacobianB);
            if (jacobianB.LengthSquared < MathHelper.Epsilon)
            {
                //A nasty singularity can show up if the axes are aligned perfectly.
                //In a 'real' situation, this is impossible, so just ignore it.
                isActiveInSolver = false;
                return;
            }

            jacobianB.Normalize();
            jacobianA.X = -jacobianB.X;
            jacobianA.Y = -jacobianB.Y;
            jacobianA.Z = -jacobianB.Z;

            //****** VELOCITY BIAS ******//
            //Compute the correction velocity.
            float errorReduction;
            springSettings.ComputeErrorReductionAndSoftness(dt, 1 / dt, out errorReduction, out softness);
            biasVelocity = MathHelper.Clamp(-error * errorReduction, -maxCorrectiveVelocity, maxCorrectiveVelocity);

            //****** EFFECTIVE MASS MATRIX ******//
            //Connection A's contribution to the mass matrix
            float entryA;
            Vector3f transformedAxis;
            if (connectionA.isDynamic)
            {
                Vector3f.Transform(ref jacobianA, ref connectionA.inertiaTensorInverse, out transformedAxis);
                Vector3f.Dot(ref transformedAxis, ref jacobianA, out entryA);
            }
            else
                entryA = 0;

            //Connection B's contribution to the mass matrix
            float entryB;
            if (connectionB.isDynamic)
            {
                Vector3f.Transform(ref jacobianB, ref connectionB.inertiaTensorInverse, out transformedAxis);
                Vector3f.Dot(ref transformedAxis, ref jacobianB, out entryB);
            }
            else
                entryB = 0;

            //Compute the inverse mass matrix
            velocityToImpulse = 1 / (softness + entryA + entryB);

            
        }

        /// <summary>
        /// Performs any pre-solve iteration work that needs exclusive
        /// access to the members of the solver updateable.
        /// Usually, this is used for applying warmstarting impulses.
        /// </summary>
        public override void ExclusiveUpdate()
        {
            //****** WARM STARTING ******//
            //Apply accumulated impulse
            Vector3f impulse;
            if (connectionA.isDynamic)
            {
                Vector3f.Multiply(ref jacobianA, accumulatedImpulse, out impulse);
                connectionA.ApplyAngularImpulse(ref impulse);
            }
            if (connectionB.isDynamic)
            {
                Vector3f.Multiply(ref jacobianB, accumulatedImpulse, out impulse);
                connectionB.ApplyAngularImpulse(ref impulse);
            }
        }

        /// <summary>
        /// Computes the internal bases and target relative state based on the current axes and entity states.
        /// Called automatically when setting any of the axis properties.
        /// </summary>
        public void Initialize()
        {
            //Compute a vector which is perpendicular to the axis.  It'll be added in local space to both connections.
            Vector3f yAxis;
            Vector3f.Cross(ref worldAxisA, ref Toolbox.UpVector, out yAxis);
            float length = yAxis.LengthSquared;
            if (length < MathHelper.Epsilon)
            {
                Vector3f.Cross(ref worldAxisA, ref Toolbox.RightVector, out yAxis);
            }
            yAxis.Normalize();

            //Put the axis into the local space of A.
            Quaternion conjugate;
            Quaternion.Conjugate(ref connectionA.orientation, out conjugate);
            Vector3f.Transform(ref yAxis, ref conjugate, out aLocalAxisY);

            //Complete A's basis.
            Vector3f.Cross(ref localAxisA, ref aLocalAxisY, out aLocalAxisZ);

            //Rotate the axis to B since it could be arbitrarily rotated.
            Quaternion rotation;
            Quaternion.GetQuaternionBetweenNormalizedVectors(ref worldAxisA, ref worldAxisB, out rotation);
            Vector3f.Transform(ref yAxis, ref rotation, out yAxis);

            //Put it into local space.
            Quaternion.Conjugate(ref connectionB.orientation, out conjugate);
            Vector3f.Transform(ref yAxis, ref conjugate, out bLocalAxisY);
        }
    }
}