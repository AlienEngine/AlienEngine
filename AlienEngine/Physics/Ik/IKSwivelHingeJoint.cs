using System;

namespace AlienEngine.Core.Physics.Ik
{
    public class IKSwivelHingeJoint : IKJoint
    {
        /// <summary>
        /// Gets or sets the free hinge axis attached to connection A in its local space.
        /// </summary>
        public Vector3f LocalHingeAxis;
        /// <summary>
        /// Gets or sets the free twist axis attached to connection B in its local space.
        /// </summary>
        public Vector3f LocalTwistAxis;


        /// <summary>
        /// Gets or sets the free hinge axis attached to connection A in world space.
        /// </summary>
        public Vector3f WorldHingeAxis
        {
            get { return Vector3f.Transform(LocalHingeAxis, ConnectionA.Orientation); }
            set
            {
                LocalHingeAxis = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionA.Orientation));
            }
        }

        /// <summary>
        /// Gets or sets the free twist axis attached to connection B in world space.
        /// </summary>
        public Vector3f WorldTwistAxis
        {
            get { return Vector3f.Transform(LocalTwistAxis, ConnectionB.Orientation); }
            set
            {
                LocalTwistAxis = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionB.Orientation));
            }
        }

        /// <summary>
        /// Constructs a new constraint which allows relative angular motion around a hinge axis and a twist axis.
        /// </summary>
        /// <param name="connectionA">First connection of the pair.</param>
        /// <param name="connectionB">Second connection of the pair.</param>
        /// <param name="worldHingeAxis">Hinge axis attached to connectionA.
        /// The connected bone will be able to rotate around this axis relative to each other.</param>
        /// <param name="worldTwistAxis">Twist axis attached to connectionB.
        /// The connected bones will be able to rotate around this axis relative to each other.</param>
        public IKSwivelHingeJoint(Bone connectionA, Bone connectionB, Vector3f worldHingeAxis, Vector3f worldTwistAxis)
            : base(connectionA, connectionB)
        {
            WorldHingeAxis = worldHingeAxis;
            WorldTwistAxis = worldTwistAxis;
        }

        protected internal override void UpdateJacobiansAndVelocityBias()
        {
            linearJacobianA = linearJacobianB = new Matrix3f();


            //There are two free axes and one restricted axis.
            //The constraint attempts to keep the hinge axis attached to connection A and the twist axis attached to connection B perpendicular to each other.
            //The restricted axis is the cross product between the twist and hinge axes.

            Vector3f worldTwistAxis, worldHingeAxis;
            Vector3f.Transform(ref LocalHingeAxis, ref ConnectionA.Orientation, out worldHingeAxis);
            Vector3f.Transform(ref LocalTwistAxis, ref ConnectionB.Orientation, out worldTwistAxis);

            Vector3f restrictedAxis;
            Vector3f.Cross(ref worldHingeAxis, ref worldTwistAxis, out restrictedAxis);
            //Attempt to normalize the restricted axis.
            float lengthSquared = restrictedAxis.LengthSquared;
            if (lengthSquared > MathHelper.Epsilon)
            {
                Vector3f.Divide(ref restrictedAxis, (float)Math.Sqrt(lengthSquared), out restrictedAxis);
            }
            else
            {
                restrictedAxis = new Vector3f();
            }


            angularJacobianA = new Matrix3f
              {
                  M11 = restrictedAxis.X,
                  M12 = restrictedAxis.Y,
                  M13 = restrictedAxis.Z,
              };
            Matrix3f.Negate(ref angularJacobianA, out angularJacobianB);

            float error;
            Vector3f.Dot(ref worldHingeAxis, ref worldTwistAxis, out error);
            error = (float)Math.Acos(MathHelper.Clamp(error, -1, 1)) - MathHelper.PiOver2;

            velocityBias = new Vector3f(errorCorrectionFactor * error, 0, 0);


        }
    }
}
