using AlienEngine.Core.Physics.BroadPhaseEntries.MobileCollidables;
using AlienEngine.Core.Physics.CollisionShapes.ConvexShapes;
using AlienEngine.Core.Physics.EntityStateManagement;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.Entities.Prefabs
{
    /// <summary>
    /// Pill-shaped object that can collide and move.  After making an entity, add it to a Space so that the engine can manage it.
    /// </summary>
    public class Capsule : Entity<ConvexCollidable<CapsuleShape>>
    {
        /// <summary>
        /// Gets or sets the length of the capsule.
        /// </summary>
        public float Length
        {
            get
            {
                return CollisionInformation.Shape.Length;
            }
            set
            {
                CollisionInformation.Shape.Length = value;
            }
        }

        /// <summary>
        /// Gets or sets the radius of the capsule.
        /// </summary>
        public float Radius
        {
            get
            {
                return CollisionInformation.Shape.Radius;
            }
            set
            {
                CollisionInformation.Shape.Radius = value;
            }
        }

        private Capsule(float len, float rad)
            : base(new ConvexCollidable<CapsuleShape>(new CapsuleShape(len, rad)))
        {
        }

        private Capsule(float len, float rad, float mass)
            : base(new ConvexCollidable<CapsuleShape>(new CapsuleShape(len, rad)), mass)
        {
        }



        ///<summary>
        /// Computes an orientation and length from a line segment.
        ///</summary>
        ///<param name="start">Starting point of the line segment.</param>
        ///<param name="end">Endpoint of the line segment.</param>
        ///<param name="orientation">Orientation of a line that fits the line segment.</param>
        ///<param name="length">Length of the line segment.</param>
        public static void GetCapsuleInformation(ref Vector3f start, ref Vector3f end, out Quaternion orientation, out float length)
        {
            Vector3f segmentDirection;
            Vector3f.Subtract(ref end, ref start, out segmentDirection);
            length = segmentDirection.Length;
            if (length > 0)
            {
                Vector3f.Divide(ref segmentDirection, length, out segmentDirection);
                Quaternion.GetQuaternionBetweenNormalizedVectors(ref Toolbox.UpVector, ref segmentDirection, out orientation);
            }
            else
                orientation = Quaternion.Identity;
        }

        ///<summary>
        /// Constructs a new kinematic capsule.
        ///</summary>
        ///<param name="start">Line segment start point.</param>
        ///<param name="end">Line segment end point.</param>
        ///<param name="radius">Radius of the capsule to expand the line segment by.</param>
        public Capsule(Vector3f start, Vector3f end, float radius)
            : this((end - start).Length, radius)
        {
            float length;
            Quaternion orientation;
            GetCapsuleInformation(ref start, ref end, out orientation, out length);
            this.Orientation = orientation;
            Vector3f position;
            Vector3f.Add(ref start, ref end, out position);
            Vector3f.Multiply(ref position, .5f, out position);
            this.Position = position;
        }


        ///<summary>
        /// Constructs a new dynamic capsule.
        ///</summary>
        ///<param name="start">Line segment start point.</param>
        ///<param name="end">Line segment end point.</param>
        ///<param name="radius">Radius of the capsule to expand the line segment by.</param>
        /// <param name="mass">Mass of the entity.</param>
        public Capsule(Vector3f start, Vector3f end, float radius, float mass)
            : this((end - start).Length, radius, mass)
        {
            float length;
            Quaternion orientation;
            GetCapsuleInformation(ref start, ref end, out orientation, out length);
            this.Orientation = orientation;
            Vector3f position;
            Vector3f.Add(ref start, ref end, out position);
            Vector3f.Multiply(ref position, .5f, out position);
            this.Position = position;
        }

        /// <summary>
        /// Constructs a physically simulated capsule.
        /// </summary>
        /// <param name="position">Position of the capsule.</param>
        /// <param name="length">Length of the capsule.</param>
        /// <param name="radius">Radius of the capsule.</param>
        /// <param name="mass">Mass of the object.</param>
        public Capsule(Vector3f position, float length, float radius, float mass)
            : this(length, radius, mass)
        {
            Position = position;
        }

        /// <summary>
        /// Constructs a nondynamic capsule.
        /// </summary>
        /// <param name="position">Position of the capsule.</param>
        /// <param name="length">Length of the capsule.</param>
        /// <param name="radius">Radius of the capsule.</param>
        public Capsule(Vector3f position, float length, float radius)
            : this(length, radius)
        {
            Position = position;
        }

        /// <summary>
        /// Constructs a dynamic capsule.
        /// </summary>
        /// <param name="motionState">Motion state specifying the entity's initial state.</param>
        /// <param name="length">Length of the capsule.</param>
        /// <param name="radius">Radius of the capsule.</param>
        /// <param name="mass">Mass of the object.</param>
        public Capsule(MotionState motionState, float length, float radius, float mass)
            : this(length, radius, mass)
        {
            MotionState = motionState;
        }

        /// <summary>
        /// Constructs a nondynamic capsule.
        /// </summary>
        /// <param name="motionState">Motion state specifying the entity's initial state.</param>
        /// <param name="length">Length of the capsule.</param>
        /// <param name="radius">Radius of the capsule.</param>
        public Capsule(MotionState motionState, float length, float radius)
            : this(length, radius)
        {
            MotionState = motionState;
        }

    }
}