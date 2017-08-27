using AlienEngine.Core.Physics;
using BulletSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine
{
    public class Collider : Component
    {
        protected CollisionShape _shape;
        protected ColliderShapes _shapeType;

        internal CollisionShape Shape
        {
            get { return _shape; }
        }

        internal ColliderShapes ShapeType
        {
            get { return _shapeType; }
        }
    }
}
