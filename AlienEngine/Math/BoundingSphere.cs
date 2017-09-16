namespace AlienEngine
{
    /// <summary>
    /// Manage bounding sphere volumes.
    /// </summary>
    public struct BoundingSphere
    {
        /// <summary>
        /// Radius of the sphere.
        /// </summary>
        public float Radius;
        /// <summary>
        /// Location of the center of the sphere.
        /// </summary>
        public Vector3f Center;

        /// <summary>
        /// Constructs a new <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="center">Location of the center of the sphere.</param>
        /// <param name="radius">Radius of the sphere.</param>
        public BoundingSphere(Vector3f center, float radius)
        {
            Center = center;
            Radius = radius;
        }
    }
}
