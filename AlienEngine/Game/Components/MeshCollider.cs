using AlienEngine.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Core.Physics;
using BEPUphysics.CollisionShapes.ConvexShapes;
using BEPUutilities;
using BEPUphysics.CollisionShapes;

namespace AlienEngine
{
    public class MeshCollider : Collider
    {
        private Vector3f _centerOffset;

        public override ColliderShapes ShapeType => ColliderShapes.Mesh;

        public MeshAsset Mesh;

        public Vector3f CenterOffset => _centerOffset;

        public MeshCollider()
        {
        }

        public override void Start()
        {
            if (Mesh != null)
            {
                MeshAsset mergedMesh = Mesh.Merged;
                Vector3f[] positions = mergedMesh.VerticesPositions;
                Vector3[] collection = new Vector3[positions.Length];
                Transform t = gameElement.WorldTransform;

                for (int i = 0, l = positions.Length; i < l; i++)
                {
                    collection[i] = (Vector3)positions[i];
                }

                Vector3 center;
                _shape = new MobileMeshShape(collection, mergedMesh.Indices, new AffineTransform((Vector3)t.Scale, BEPUutilities.Quaternion.CreateFromYawPitchRoll(t.Rotation.Z, t.Rotation.Y, t.Rotation.X), (Vector3)t.Translation), MobileMeshSolidity.DoubleSided, out center);
                _centerOffset = (Vector3f)center;

            }
        }
    }
}
