

namespace AlienEngine.Core.Physics.CollisionTests
{
    ///<summary>
    /// Extra data associated with a contact point used to refresh contacts each frame.
    ///</summary>
    public struct ContactSupplementData
    {
        /// <summary>
        /// Offset from the center of the first object to the contact point in the object's local space.
        /// </summary>
        public Vector3f LocalOffsetA;

        /// <summary>
        /// Offset from the center of the second object to the contact point in the object's local space.
        /// </summary>
        public Vector3f LocalOffsetB;
        /// <summary>
        /// Original penetration depth computed at the associatd contact.
        /// </summary>
        public float BasePenetrationDepth;
    }
}
