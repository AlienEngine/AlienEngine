namespace AlienEngine.Core.Physics.Ik
{
    public class SingleBoneAngularPlaneConstraint : SingleBoneConstraint
    {
        /// <summary>
        /// Gets or sets normal of the plane which the bone's axis will be constrained to..
        /// </summary>
        public Vector3f PlaneNormal;



        /// <summary>
        /// Axis to constrain to the plane in the bone's local space.
        /// </summary>
        public Vector3f BoneLocalAxis;

        protected internal override void UpdateJacobiansAndVelocityBias()
        {
 

            linearJacobian = new Matrix3f();

            Vector3f boneAxis;
            Vector3f.Transform(ref BoneLocalAxis, ref TargetBone.Orientation, out boneAxis);

            Vector3f jacobian;
            Vector3f.Cross(ref boneAxis, ref PlaneNormal, out jacobian);

            angularJacobian = new Matrix3f
            {
                M11 = jacobian.X,
                M12 = jacobian.Y,
                M13 = jacobian.Z,
            };


            Vector3f.Dot(ref boneAxis, ref PlaneNormal, out velocityBias.X);
            velocityBias.X = -errorCorrectionFactor * velocityBias.X;


        }


    }
}
