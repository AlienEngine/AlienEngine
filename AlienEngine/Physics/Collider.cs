using AlienEngine.Core.Physics;
using BEPUphysics.CollisionShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
