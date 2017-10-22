using System;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.Ik
{
    public class IKRevoluteJoint : IKJoint
    {
        private Vector3f localFreeAxisA;
        /// <summary>
        /// Gets or sets the free axis in connection A's local space.
        /// Must be unit length.
        /// </summary>
        public Vector3f LocalFreeAxisA
        {
            get { return localFreeAxisA; }
            set
            {
                localFreeAxisA = value;
                ComputeConstrainedAxes();
            }
        }

        private Vector3f localFreeAxisB;
        /// <summary>
        /// Gets or sets the free axis in connection B's local space.
        /// Must be unit length.
        /// </summary>
        public Vector3f LocalFreeAxisB
        {
            get { return localFreeAxisB; }
            set
            {
                localFreeAxisB = value;
                ComputeConstrainedAxes();
            }
        }



        /// <summary>
        /// Gets or sets the free axis attached to connection A in world space.
        /// This does not change the other connection's free axis.
        /// </summary>
        public Vector3f WorldFreeAxisA
        {
            get { return Vector3f.Transform(localFreeAxisA, ConnectionA.Orientation); }
            set
            {
                LocalFreeAxisA = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionA.Orientation));
            }
        }

        /// <summary>
        /// Gets or sets the free axis attached to connection B in world space.
        /// This does not change the other connection's free axis.
        /// </summary>
        public Vector3f WorldFreeAxisB
        {
            get { return Vector3f.Transform(localFreeAxisB, ConnectionB.Orientation); }
            set
            {
                LocalFreeAxisB = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionB.Orientation));
            }
        }

        private Vector3f localConstrainedAxis1, localConstrainedAxis2;
        void ComputeConstrainedAxes()
        {
            Vector3f worldAxisA = WorldFreeAxisA;
            Vector3f error = Vector3f.Cross(worldAxisA, WorldFreeAxisB);
            float lengthSquared = error.LengthSquared;
            Vector3f worldConstrainedAxis1, worldConstrainedAxis2;
            //Find the first constrained axis.
            if (lengthSquared > MathHelper.Epsilon)
            {
                //The error direction can be used as the first axis!
                Vector3f.Divide(ref error, (float)Math.Sqrt(lengthSquared), out worldConstrainedAxis1);
            }
            else
            {
                //There's not enough error for it to be a good constrained axis.
                //We'll need to create the constrained axes arbitrarily.
                Vector3f.Cross(ref Toolbox.UpVector, ref worldAxisA, out worldConstrainedAxis1);
                lengthSquared = worldConstrainedAxis1.LengthSquared;
                if (lengthSquared > MathHelper.Epsilon)
                {
                    //The up vector worked!
                    Vector3f.Divide(ref worldConstrainedAxis1, (float)Math.Sqrt(lengthSquared), out worldConstrainedAxis1);
                }
                else
                {
                    //The up vector didn't work. Just try the right vector.
                    Vector3f.Cross(ref Toolbox.RightVector, ref worldAxisA, out worldConstrainedAxis1);
                    worldConstrainedAxis1.Normalize();
                }
            }
            //Don't have to normalize the second constraint axis; it's the cross product of two perpendicular normalized vectors.
            Vector3f.Cross(ref worldAxisA, ref worldConstrainedAxis1, out worldConstrainedAxis2);

            localConstrainedAxis1 = Vector3f.Transform(worldConstrainedAxis1, Quaternion.Conjugate(ConnectionA.Orientation));
            localConstrainedAxis2 = Vector3f.Transform(worldConstrainedAxis2, Quaternion.Conjugate(ConnectionA.Orientation));
        }

        /// <summary>
        /// Constructs a new orientation joint.
        /// Orientation joints can be used to simulate the angular portion of a hinge.
        /// Orientation joints allow rotation around only a single axis.
        /// </summary>
        /// <param name="connectionA">First entity connected in the orientation joint.</param>
        /// <param name="connectionB">Second entity connected in the orientation joint.</param>
        /// <param name="freeAxis">Axis allowed to rotate freely in world space.</param>
        public IKRevoluteJoint(Bone connectionA, Bone connectionB, Vector3f freeAxis)
            : base(connectionA, connectionB)
        {
            WorldFreeAxisA = freeAxis;
            WorldFreeAxisB = freeAxis;
        }

        protected internal override void UpdateJacobiansAndVelocityBias()
        {
            linearJacobianA = linearJacobianB = new Matrix3f();

            //We know the one free axis. We need the two restricted axes. This amounts to completing the orthonormal basis.
            //We can grab one of the restricted axes using a cross product of the two world axes. This is not guaranteed
            //to be nonzero, so the normalization requires protection.

            Vector3f worldAxisA, worldAxisB;
            Vector3f.Transform(ref localFreeAxisA, ref ConnectionA.Orientation, out worldAxisA);
            Vector3f.Transform(ref localFreeAxisB, ref ConnectionB.Orientation, out worldAxisB);

            Vector3f error;
            Vector3f.Cross(ref worldAxisA, ref worldAxisB, out error);

            Vector3f worldConstrainedAxis1, worldConstrainedAxis2;
            Vector3f.Transform(ref localConstrainedAxis1, ref ConnectionA.Orientation, out worldConstrainedAxis1);
            Vector3f.Transform(ref localConstrainedAxis2, ref ConnectionA.Orientation, out worldConstrainedAxis2);


            angularJacobianA = new Matrix3f
            {
                M11 = worldConstrainedAxis1.X,
                M12 = worldConstrainedAxis1.Y,
                M13 = worldConstrainedAxis1.Z,
                M21 = worldConstrainedAxis2.X,
                M22 = worldConstrainedAxis2.Y,
                M23 = worldConstrainedAxis2.Z
            };
            Matrix3f.Negate(ref angularJacobianA, out angularJacobianB);


            Vector2f constraintSpaceError;
            Vector3f.Dot(ref error, ref worldConstrainedAxis1, out constraintSpaceError.X);
            Vector3f.Dot(ref error, ref worldConstrainedAxis2, out constraintSpaceError.Y);
            velocityBias.X = errorCorrectionFactor * constraintSpaceError.X;
            velocityBias.Y = errorCorrectionFactor * constraintSpaceError.Y;


        }
    }
}
