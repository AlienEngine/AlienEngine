namespace AlienEngine.Core.Physics.Ik
{
    public class SingleBoneRevoluteConstraint : SingleBoneConstraint
    {
        private Vector3f freeAxis;
        private Vector3f constrainedAxis1;
        private Vector3f constrainedAxis2;

        /// <summary>
        /// Gets or sets the direction to constrain the bone free axis to.
        /// </summary>
        public Vector3f FreeAxis
        {
            get { return freeAxis; }
            set
            {
                freeAxis = value;
                constrainedAxis1 = Vector3f.Cross(freeAxis, VectorHelper.Up);
                if (constrainedAxis1.LengthSquared < MathHelper.Epsilon)
                {
                    constrainedAxis1 = Vector3f.Cross(freeAxis, VectorHelper.Right);
                }
                constrainedAxis1.Normalize();
                constrainedAxis2 = Vector3f.Cross(freeAxis, constrainedAxis1);
            }
        }


        /// <summary>
        /// Axis of allowed rotation in the bone's local space.
        /// </summary>
        public Vector3f BoneLocalFreeAxis;

        protected internal override void UpdateJacobiansAndVelocityBias()
        {
 

            linearJacobian = new Matrix3f();

            Vector3f boneAxis;
            Vector3f.Transform(ref BoneLocalFreeAxis, ref TargetBone.Orientation, out boneAxis);


            angularJacobian = new Matrix3f
            {
                M11 = constrainedAxis1.X,
                M12 = constrainedAxis1.Y,
                M13 = constrainedAxis1.Z,
                M21 = constrainedAxis2.X,
                M22 = constrainedAxis2.Y,
                M23 = constrainedAxis2.Z
            };


            Vector3f error;
            Vector3f.Cross(ref boneAxis, ref freeAxis, out error);
            Vector2f constraintSpaceError;
            Vector3f.Dot(ref error, ref constrainedAxis1, out constraintSpaceError.X);
            Vector3f.Dot(ref error, ref constrainedAxis2, out constraintSpaceError.Y);
            velocityBias.X = errorCorrectionFactor * constraintSpaceError.X;
            velocityBias.Y = errorCorrectionFactor * constraintSpaceError.Y;


        }


    }
}
