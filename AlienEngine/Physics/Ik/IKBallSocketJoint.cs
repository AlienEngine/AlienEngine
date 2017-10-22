namespace AlienEngine.Core.Physics.Ik
{
    //Keeps the anchors from two connections near each other.
    public class IKBallSocketJoint : IKJoint
    {
        /// <summary>
        /// Gets or sets the offset in connection A's local space from the center of mass to the anchor point.
        /// </summary>
        public Vector3f LocalOffsetA;
        /// <summary>
        /// Gets or sets the offset in connection B's local space from the center of mass to the anchor point.
        /// </summary>
        public Vector3f LocalOffsetB;

        /// <summary>
        /// Gets or sets the offset in world space from the center of mass of connection A to the anchor point.
        /// </summary>
        public Vector3f OffsetA
        {
            get { return Vector3f.Transform(LocalOffsetA, ConnectionA.Orientation); }
            set { LocalOffsetA = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionA.Orientation)); }
        }

        /// <summary>
        /// Gets or sets the offset in world space from the center of mass of connection B to the anchor point.
        /// </summary>
        public Vector3f OffsetB
        {
            get { return Vector3f.Transform(LocalOffsetB, ConnectionB.Orientation); }
            set { LocalOffsetB = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionB.Orientation)); }
        }

        /// <summary>
        /// Builds a ball socket joint.
        /// </summary>
        /// <param name="connectionA">First connection in the pair.</param>
        /// <param name="connectionB">Second connection in the pair.</param>
        /// <param name="anchor">World space anchor location used to initialize the local anchors.</param>
        public IKBallSocketJoint(Bone connectionA, Bone connectionB, Vector3f anchor)
            : base(connectionA, connectionB)
        {
            OffsetA = anchor - ConnectionA.Position;
            OffsetB = anchor - ConnectionB.Position;
        }

        protected internal override void UpdateJacobiansAndVelocityBias()
        {
            linearJacobianA = Matrix3f.Identity;
            //The jacobian entries are is [ La, Aa, -Lb, -Ab ] because the relative velocity is computed using A-B. So, negate B's jacobians!
            linearJacobianB = new Matrix3f { M11 = -1, M22 = -1, M33 = -1 };
            Vector3f rA;
            Vector3f.Transform(ref LocalOffsetA, ref ConnectionA.Orientation, out rA);
            Matrix3f.CreateCrossProduct(ref rA, out angularJacobianA);
            //Transposing a skew-symmetric matrix is equivalent to negating it.
            Matrix3f.Transpose(ref angularJacobianA, out angularJacobianA);

            Vector3f worldPositionA;
            Vector3f.Add(ref ConnectionA.Position, ref rA, out worldPositionA);

            Vector3f rB;
            Vector3f.Transform(ref LocalOffsetB, ref ConnectionB.Orientation, out rB);
            Matrix3f.CreateCrossProduct(ref rB, out angularJacobianB);

            Vector3f worldPositionB;
            Vector3f.Add(ref ConnectionB.Position, ref rB, out worldPositionB);

            Vector3f linearError;
            Vector3f.Subtract(ref worldPositionB, ref worldPositionA, out linearError);
            Vector3f.Multiply(ref linearError, errorCorrectionFactor, out velocityBias);

        }
    }
}
