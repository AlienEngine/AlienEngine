using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Core.Physics;

namespace AlienEngine
{
    public class SphereCollider : Collider
    {
        public override ColliderShapes ShapeType => ColliderShapes.Sphere;
    }
}
