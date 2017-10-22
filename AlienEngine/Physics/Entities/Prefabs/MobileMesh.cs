using AlienEngine.Core.Physics.BroadPhaseEntries.MobileCollidables;
using AlienEngine.Core.Physics.CollisionShapes;

namespace AlienEngine.Core.Physics.Entities.Prefabs
{
    /// <summary>
    /// Acts as a grouping of multiple other objects.  Can be used to form physically simulated concave shapes.
    /// </summary>
    public class MobileMesh : Entity<MobileMeshCollidable>
    {

        /// <summary>
        /// Creates a new kinematic MobileMesh.
        /// </summary>
        /// <param name="vertices">Vertices in the mesh.</param>
        /// <param name="indices">Indices of the mesh.</param>
        /// <param name="localTransform">Affine transform to apply to the vertices.</param>
        /// <param name="solidity">Solidity/sidedness of the mesh.  "Solid" is only permitted if the mesh is closed.</param>
        public MobileMesh(Vector3f[] vertices, int[] indices, AffineTransform localTransform, MobileMeshSolidity solidity)
        {
            Vector3f center;
            var shape = new MobileMeshShape(vertices, indices, localTransform, solidity, out center);
            Initialize(new MobileMeshCollidable(shape));
            Position = center;
        }



        /// <summary>
        /// Creates a new dynamic MobileMesh.
        /// </summary>
        /// <param name="vertices">Vertices in the mesh.</param>
        /// <param name="indices">Indices of the mesh.</param>
        /// <param name="localTransform">Affine transform to apply to the vertices.</param>
        /// <param name="solidity">Solidity/sidedness of the mesh.  "Solid" is only permitted if the mesh is closed.</param>
        /// <param name="mass">Mass of the mesh.</param>
        public MobileMesh(Vector3f[] vertices, int[] indices, AffineTransform localTransform, MobileMeshSolidity solidity, float mass)
        {
            Vector3f center;
            var shape = new MobileMeshShape(vertices, indices, localTransform, solidity, out center);
            Initialize(new MobileMeshCollidable(shape), mass);
            Position = center;
        }




    }


}