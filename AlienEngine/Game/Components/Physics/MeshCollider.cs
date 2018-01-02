using AlienEngine.Core.Assets;
using AlienEngine.Core.Assets.Mesh;
using AlienEngine.Core.Physics;
using AlienEngine.Core.Physics.CollisionShapes;

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
                MeshData mergedMesh = Mesh.Merged;
                Vector3f[] positions = mergedMesh.VerticesPositions;
                Vector3f[] collection = new Vector3f[positions.Length];
                Transform t = gameElement.WorldTransform;

                for (int i = 0, l = positions.Length; i < l; i++)
                {
                    // TODO: Transform positions here !!
                    collection[i] = positions[i];
                }

                _shape = new MobileMeshShape(collection, mergedMesh.Indices.ToArray(), new AffineTransform(t.Scale, Quaternion.FromEulerAngles(t.Rotation.Z, t.Rotation.Y, t.Rotation.X), t.Translation), MobileMeshSolidity.DoubleSided, out _centerOffset);
            }
        }
    }
}
