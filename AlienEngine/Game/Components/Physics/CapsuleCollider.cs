using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Core.Physics;

namespace AlienEngine
{
    public class CapsuleCollider : Collider
    {
        public override ColliderShapes ShapeType => ColliderShapes.Capsule;
    }
}
