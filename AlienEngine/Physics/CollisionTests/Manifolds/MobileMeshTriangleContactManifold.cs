﻿using AlienEngine.Core.Physics.CollisionTests.CollisionAlgorithms;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Physics.CollisionTests.Manifolds
{
    ///<summary>
    /// Manages persistent contacts between a convex and an instanced mesh.
    ///</summary>
    public class MobileMeshTriangleContactManifold : MobileMeshContactManifold
    {

        UnsafeResourcePool<TriangleTrianglePairTester> testerPool = new UnsafeResourcePool<TriangleTrianglePairTester>();
        protected override void GiveBackTester(TrianglePairTester tester)
        {
            testerPool.GiveBack((TriangleTrianglePairTester)tester);
        }

        protected override TrianglePairTester GetTester()
        {
            return testerPool.Take();
        }

    }
}
