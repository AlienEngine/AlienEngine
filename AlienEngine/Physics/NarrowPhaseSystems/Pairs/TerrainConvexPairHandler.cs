using AlienEngine.Core.Physics.CollisionTests.Manifolds;

namespace AlienEngine.Core.Physics.NarrowPhaseSystems.Pairs
{
    ///<summary>
    /// Handles a terrain-convex collision pair.
    ///</summary>
    public sealed class TerrainConvexPairHandler : TerrainPairHandler
    {
        private TerrainConvexContactManifold contactManifold = new TerrainConvexContactManifold();
        protected override TerrainContactManifold TerrainManifold
        {
            get { return contactManifold; }
        }

    }

}
