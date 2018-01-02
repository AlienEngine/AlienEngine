using AlienEngine.Core.Physics;
using AlienEngine.Core.Physics.CollisionShapes.ConvexShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine
{
    public class PlaneCollider : Collider
    {
        public Sizef Size;

        public PlaneCollider()
        { }

        public override ColliderShapes ShapeType
        {
            get { return ColliderShapes.Plane; }
        }

        public override void Start()
        {
            _shape = new BoxShape(Size.Width, 0.1f, Size.Height);
        }
    }
}
