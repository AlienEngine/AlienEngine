﻿namespace AlienEngine
{
    /// <summary>
    /// Provides XNA-like plane functionality.
    /// </summary>
    public struct Plane
    {
        /// <summary>
        /// Normal of the plane.
        /// </summary>
        public Vector3f Normal;
        /// <summary>
        /// Negative distance to the plane from the origin along the normal.
        /// </summary>
        public float D;


        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="position">A point on the plane.</param>
        /// <param name="normal">The normal of the plane.</param>
        public Plane(ref Vector3f position, ref Vector3f normal)
        {
            float d;
            Vector3f.Dot(ref position, ref normal, out d);
            D = -d;
            Normal = normal;
        }


        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="position">A point on the plane.</param>
        /// <param name="normal">The normal of the plane.</param>
        public Plane(Vector3f position, Vector3f normal)
            : this(ref position, ref normal)
        {

        }


        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="normal">Normal of the plane.</param>
        /// <param name="d">Negative distance to the plane from the origin along the normal.</param>
        public Plane(Vector3f normal, float d)
            : this(ref normal, d)
        {
        }

        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="normal">Normal of the plane.</param>
        /// <param name="d">Negative distance to the plane from the origin along the normal.</param>
        public Plane(ref Vector3f normal, float d)
        {
            this.Normal = normal;
            this.D = d;
        }

        /// <summary>
        /// Gets the dot product of the position offset from the plane along the plane's normal.
        /// </summary>
        /// <param name="v">Position to compute the dot product of.</param>
        /// <param name="dot">Dot product.</param>
        public void DotCoordinate(ref Vector3f v, out float dot)
        {
            dot = Normal.X * v.X + Normal.Y * v.Y + Normal.Z * v.Z + D;
        }
    }
}
