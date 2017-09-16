using AlienEngine.Core.Physics;
using BEPUphysics.CollisionShapes;
using BEPUphysics.CollisionShapes.ConvexShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine
{
    public class BoxCollider : Collider
    {
        public Vector3f HalfExtends;
        public float Margin;

        public BoxCollider()
        {
            HalfExtends = Vector3f.Zero;
            Margin = 0;
        }

        public override ColliderShapes ShapeType
        {
            get { return ColliderShapes.Box; }
        }

        public override void Start()
        {
            ConvexShapeDescription desc = new ConvexShapeDescription
            {
                CollisionMargin = Margin
            };

            _shape = new BoxShape(HalfExtends.X, HalfExtends.Y, HalfExtends.Z, desc);
        }
    }
}
