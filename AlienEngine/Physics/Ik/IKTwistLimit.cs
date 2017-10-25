using System;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.Ik
{
    /// <summary>
    /// Prevents two bones from twisting beyond a certain angle away from each other as measured by the twist between two measurement axes.
    /// </summary>
    public class IKTwistLimit : IKLimit
    {
        /// <summary>
        /// Gets or sets the axis attached to ConnectionA in its local space.
        /// Must be unit length and perpendicular to LocalMeasurementAxisA.
        /// </summary>
        public Vector3f LocalAxisA;
        /// <summary>
        /// Gets or sets the axis attached to ConnectionB in its local space.
        /// Must be unit length and perpendicular to LocalMeasurementAxisB.
        /// </summary>
        public Vector3f LocalAxisB;

        /// <summary>
        /// Gets or sets the measurement axis attached to connection A.
        /// Must be unit length and perpendicular to LocalAxisA.
        /// </summary>
        public Vector3f LocalMeasurementAxisA;
        /// <summary>
        /// Gets or sets the measurement axis attached to connection B.
        /// Must be unit length and perpendicular to LocalAxisB.
        /// </summary>
        public Vector3f LocalMeasurementAxisB;

        /// <summary>
        /// Gets or sets the axis attached to ConnectionA in world space.
        /// Must be unit length and perpendicular to MeasurementAxisA.
        /// </summary>
        public Vector3f AxisA
        {
            get { return Vector3f.Transform(LocalAxisA, ConnectionA.Orientation); }
            set { LocalAxisA = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionA.Orientation)); }
        }

        /// <summary>
        /// Gets or sets the axis attached to ConnectionB in world space.
        /// Must be unit length and perpendicular to MeasurementAxisB.
        /// </summary>
        public Vector3f AxisB
        {
            get { return Vector3f.Transform(LocalAxisB, ConnectionB.Orientation); }
            set { LocalAxisB = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionB.Orientation)); }
        }

        /// <summary>
        /// Gets or sets the measurement axis attached to ConnectionA in world space.
        /// This axis is compared against the other connection's measurement axis to determine the twist.
        /// Must be unit length and perpendicular to AxisA.
        /// </summary>
        public Vector3f MeasurementAxisA
        {
            get { return Vector3f.Transform(LocalMeasurementAxisA, ConnectionA.Orientation); }
            set { LocalMeasurementAxisA = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionA.Orientation)); }
        }

        /// <summary>
        /// Gets or sets the measurement axis attached to ConnectionB in world space.
        /// This axis is compared against the other connection's measurement axis to determine the twist.
        /// Must be unit length and perpendicular to AxisB.
        /// </summary>
        public Vector3f MeasurementAxisB
        {
            get { return Vector3f.Transform(LocalMeasurementAxisB, ConnectionB.Orientation); }
            set { LocalMeasurementAxisB = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionB.Orientation)); }
        }

        private float maximumAngle;
        /// <summary>
        /// Gets or sets the maximum angle between the two axes allowed by the constraint.
        /// </summary>
        public float MaximumAngle
        {
            get { return maximumAngle; }
            set { maximumAngle = Math.Max(0, value); }
        }

        /// <summary>
        /// Automatically computes the measurement axes for the current local axes.
        /// The current relative state of the entities will be considered 0 twist angle.
        /// </summary>
        public void ComputeMeasurementAxes()
        {
            Vector3f axisA, axisB;
            Vector3f.Transform(ref LocalAxisA, ref ConnectionA.Orientation, out axisA);
            Vector3f.Transform(ref LocalAxisB, ref ConnectionB.Orientation, out axisB);
            //Pick an axis perpendicular to axisA to use as the measurement axis.
            Vector3f worldMeasurementAxisA;
            Vector3f.Cross(ref Toolbox.UpVector, ref axisA, out worldMeasurementAxisA);
            float lengthSquared = worldMeasurementAxisA.LengthSquared;
            if (lengthSquared > MathHelper.Epsilon)
            {
                Vector3f.Divide(ref worldMeasurementAxisA, (float)Math.Sqrt(lengthSquared), out worldMeasurementAxisA);
            }
            else
            {
                //Oops! It was parallel to the up vector. Just try again with the right vector.
                Vector3f.Cross(ref Toolbox.RightVector, ref axisA, out worldMeasurementAxisA);
                worldMeasurementAxisA.Normalize();
            }
            //Attach the measurement axis to entity B.
            //'Push' A's axis onto B by taking into account the swing transform.
            Quaternion alignmentRotation;
            Quaternion.GetQuaternionBetweenNormalizedVectors(ref axisA, ref axisB, out alignmentRotation);
            Vector3f worldMeasurementAxisB;
            Vector3f.Transform(ref worldMeasurementAxisA, ref alignmentRotation, out worldMeasurementAxisB);
            //Plop them on!
            MeasurementAxisA = worldMeasurementAxisA;
            MeasurementAxisB = worldMeasurementAxisB;

        }


        /// <summary>
        /// Builds a new twist limit. Prevents two bones from rotating beyond a certain angle away from each other as measured by attaching an axis to each connected bone.
        /// </summary>
        /// <param name="connectionA">First connection of the limit.</param>
        /// <param name="connectionB">Second connection of the limit.</param>
        /// <param name="axisA">Axis attached to connectionA in world space.</param>
        /// <param name="axisB">Axis attached to connectionB in world space.</param>
        /// <param name="maximumAngle">Maximum angle allowed between connectionA's axis and connectionB's axis.</param>
        public IKTwistLimit(Bone connectionA, Bone connectionB, Vector3f axisA, Vector3f axisB, float maximumAngle)
            : base(connectionA, connectionB)
        {
            AxisA = axisA;
            AxisB = axisB;
            MaximumAngle = maximumAngle;

            ComputeMeasurementAxes();
        }

        protected internal override void UpdateJacobiansAndVelocityBias()
        {

            //This constraint doesn't consider linear motion.
            linearJacobianA = linearJacobianB = new Matrix3f();

            //Compute the world axes.
            Vector3f axisA, axisB;
            Vector3f.Transform(ref LocalAxisA, ref ConnectionA.Orientation, out axisA);
            Vector3f.Transform(ref LocalAxisB, ref ConnectionB.Orientation, out axisB);

            Vector3f twistMeasureAxisA, twistMeasureAxisB;
            Vector3f.Transform(ref LocalMeasurementAxisA, ref ConnectionA.Orientation, out twistMeasureAxisA);
            Vector3f.Transform(ref LocalMeasurementAxisB, ref ConnectionB.Orientation, out twistMeasureAxisB);

            //Compute the shortest rotation to bring axisB into alignment with axisA.
            Quaternion alignmentRotation;
            Quaternion.GetQuaternionBetweenNormalizedVectors(ref axisB, ref axisA, out alignmentRotation);

            //Transform the measurement axis on B by the alignment quaternion.
            Vector3f.Transform(ref twistMeasureAxisB, ref alignmentRotation, out twistMeasureAxisB);

            //We can now compare the angle between the twist axes.
            float angle;
            Vector3f.Dot(ref twistMeasureAxisA, ref twistMeasureAxisB, out angle);
            angle = (float)Math.Acos(MathHelper.Clamp(angle, -1, 1));

            //Compute the bias based upon the error.
            if (angle > maximumAngle)
                velocityBias = new Vector3f(errorCorrectionFactor * (angle - maximumAngle), 0, 0);
            else //If the constraint isn't violated, set up the velocity bias to allow a 'speculative' limit.
                velocityBias = new Vector3f(angle - maximumAngle, 0, 0);

            //We can't just use the axes directly as jacobians. Consider 'cranking' one object around the other.
            Vector3f jacobian;
            Vector3f.Add(ref axisA, ref axisB, out jacobian);
            float lengthSquared = jacobian.LengthSquared;
            if (lengthSquared > MathHelper.Epsilon)
            {
                Vector3f.Divide(ref jacobian, (float)Math.Sqrt(lengthSquared), out jacobian);
            }
            else
            {
                //The constraint is in an invalid configuration. Just ignore it.
                jacobian = new Vector3f();
            }

            //In addition to the absolute angle value, we need to know which side of the limit we're hitting.
            //The jacobian will be negated on one side. This is because limits can only 'push' in one direction;
            //if we didn't flip the direction of the jacobian, it would be trying to push the same direction on both ends of the limit.
            //One side would end up doing nothing!
            Vector3f cross;
            Vector3f.Cross(ref twistMeasureAxisA, ref twistMeasureAxisB, out cross);
            float limitSide;
            Vector3f.Dot(ref cross, ref axisA, out limitSide);
            //Negate the jacobian based on what side of the limit we're on.
            if (limitSide < 0)
                Vector3f.Negate(ref jacobian, out jacobian);

            angularJacobianA = new Matrix3f { M11 = jacobian.X, M12 = jacobian.Y, M13 = jacobian.Z };
            angularJacobianB = new Matrix3f { M11 = -jacobian.X, M12 = -jacobian.Y, M13 = -jacobian.Z };




        }
    }
}
