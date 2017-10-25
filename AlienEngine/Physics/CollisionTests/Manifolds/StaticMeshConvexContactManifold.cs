using AlienEngine.Core.Physics.CollisionTests.CollisionAlgorithms;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Physics.CollisionTests.Manifolds
{
    ///<summary>
    /// Manages persistent contacts between a static mesh and a convex.
    ///</summary>
    public class StaticMeshConvexContactManifold : StaticMeshContactManifold
    {


        static LockingResourcePool<TriangleConvexPairTester> testerPool = new LockingResourcePool<TriangleConvexPairTester>();
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
