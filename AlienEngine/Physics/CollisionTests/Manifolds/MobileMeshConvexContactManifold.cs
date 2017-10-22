using AlienEngine.Core.Physics.CollisionTests.CollisionAlgorithms;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Physics.CollisionTests.Manifolds
{
    ///<summary>
    /// Manages persistent contacts between a convex and an instanced mesh.
    ///</summary>
    public class MobileMeshConvexContactManifold : MobileMeshContactManifold
    {

        UnsafeResourcePool<TriangleConvexPairTester> testerPool = new UnsafeResourcePool<TriangleConvexPairTester>();
        protected override void GiveBackTester(TrianglePairTester tester)
        {
            testerPool.GiveBack((TriangleConvexPairTester)tester);
        }

        protected override TrianglePairTester GetTester()
        {
            return testerPool.Take();
        }

    }
}
