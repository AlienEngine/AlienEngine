﻿using AlienEngine.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Core.Physics;
using AlienEngine.Core.Physics.CollisionShapes.ConvexShapes;
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
                MeshAsset mergedMesh = Mesh.Merged;
                Vector3f[] positions = mergedMesh.VerticesPositions;
                Vector3f[] collection = new Vector3f[positions.Length];
                Transform t = gameElement.WorldTransform;

                for (int i = 0, l = positions.Length; i < l; i++)
                {
                    // TODO: Transform positions here !!
                    collection[i] = positions[i];
                }

                Vector3f center;
                _shape = new MobileMeshShape(collection, mergedMesh.Indices, new AffineTransform(t.Scale, Quaternion.FromEulerAngles(t.Rotation.Z, t.Rotation.Y, t.Rotation.X), t.Translation), MobileMeshSolidity.DoubleSided, out center);
                _centerOffset = (Vector3f)center;

            }
        }
    }
}
