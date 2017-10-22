namespace AlienEngine.Core.Physics.Ik
{
    public class SingleBoneLinearMotor : SingleBoneConstraint
    {
        /// <summary>
        /// Gets or sets the target position to apply to the target bone.
        /// </summary>
        public Vector3f TargetPosition;

        /// <summary>
        /// Gets or sets the offset in the bone's local space to the point which will be pulled towards the target position.
        /// </summary>
        public Vector3f LocalOffset;


        public Vector3f Offset
        {
            get { return Vector3f.Transform(LocalOffset, TargetBone.Orientation); }
            set { LocalOffset = Vector3f.Transform(value, Quaternion.Conjugate(TargetBone.Orientation)); }
        }

        protected internal override void UpdateJacobiansAndVelocityBias()
        {
            linearJacobian = Matrix3f.Identity;
            Vector3f r;
            Vector3f.Transform(ref LocalOffset, ref TargetBone.Orientation, out r);
            Matrix3f.CreateCrossProduct(ref r, out angularJacobian);
            //Transposing a skew symmetric matrix is equivalent to negating it.
            Matrix3f.Transpose(ref angularJacobian, out angularJacobian);

            Vector3f worldPosition;
            Vector3f.Add(ref TargetBone.Position, ref r, out worldPosition);

            //Error is in world space.
            Vector3f linearError;
            Vector3f.Subtract(ref TargetPosition, ref worldPosition, out linearError);
            //This is equivalent to projecting the error onto the linear jacobian. The linear jacobian just happens to be the identity matrix!
            Vector3f.Multiply(ref linearError, errorCorrectionFactor, out velocityBias);
        }


    }
}
