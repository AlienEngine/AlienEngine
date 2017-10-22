using AlienEngine.Core.Physics;
using AlienEngine.Core.Physics.CollisionShapes;
using System;

namespace AlienEngine
{
    public abstract class Collider : Component
    {
        [CLSCompliant(false)]
        protected EntityShape _shape;

        internal EntityShape Shape
        {
            get { return _shape; }
        }

        public abstract ColliderShapes ShapeType
        {
            get;
        }
    }
}
