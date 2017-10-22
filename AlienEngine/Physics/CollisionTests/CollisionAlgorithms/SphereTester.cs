using System;
using AlienEngine.Core.Physics.CollisionShapes.ConvexShapes;
using AlienEngine.Core.Physics.Settings;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.CollisionTests.CollisionAlgorithms
{
    ///<summary>
    /// Helper class to test spheres against each other.
    ///</summary>
    public static class SphereTester
    {
        /// <summary>
        /// Computes contact data for two spheres.
        /// </summary>
        /// <param name="a">First sphere.</param>
        /// <param name="b">Second sphere.</param>
        /// <param name="positionA">Position of the first sphere.</param>
        /// <param name="positionB">Position of the second sphere.</param>
        /// <param name="contact">Contact data between the spheres, if any.</param>
        /// <returns>Whether or not the spheres are touching.</returns>
        public static bool AreSpheresColliding(SphereShape a, SphereShape b, ref Vector3f positionA, ref Vector3f positionB, out ContactData contact)
        {
            contact = new ContactData();

            float radiusSum = a.collisionMargin + b.collisionMargin;
            Vector3f centerDifference;
            Vector3f.Subtract(ref positionB, ref positionA, out centerDifference);
            float centerDistance = centerDifference.LengthSquared;

            if (centerDistance < (radiusSum + CollisionDetectionSettings.maximumContactDistance) * (radiusSum + CollisionDetectionSettings.maximumContactDistance))
            {
                //In collision!

                if (radiusSum > MathHelper.Epsilon) //This would be weird, but it is still possible to cause a NaN.
                    Vector3f.Multiply(ref centerDifference, a.collisionMargin / (radiusSum), out  contact.Position);
                else contact.Position = new Vector3f();
                Vector3f.Add(ref contact.Position, ref positionA, out contact.Position);

                centerDistance = (float)Math.Sqrt(centerDistance);
                if (centerDistance > MathHelper.BigEpsilon)
                {
                    Vector3f.Divide(ref centerDifference, centerDistance, out contact.Normal);
                }
                else
                {
                    contact.Normal = Toolbox.UpVector;
                }
                contact.PenetrationDepth = radiusSum - centerDistance;

                return true;

            }
            return false;
        }
    }
}
