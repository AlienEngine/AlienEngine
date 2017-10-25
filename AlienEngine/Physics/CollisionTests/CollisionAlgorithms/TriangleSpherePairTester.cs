﻿using System;
using AlienEngine.Core.Physics.CollisionShapes.ConvexShapes;
using AlienEngine.Core.Physics.Utilities;
using AlienEngine.Core.Utils.DataStructures;

namespace AlienEngine.Core.Physics.CollisionTests.CollisionAlgorithms
{
    ///<summary>
    /// Persistent tester that compares triangles against convex objects.
    ///</summary>
    public sealed class TriangleSpherePairTester : TrianglePairTester
    {
        internal SphereShape sphere;

        private VoronoiRegion lastRegion;


        //Relies on the triangle being located in the local space of the convex object.  The convex transform is used to transform the
        //contact points back from the convex's local space into world space.
        ///<summary>
        /// Generates a contact between the triangle and convex.
        ///</summary>
        ///<param name="contactList">Contact between the shapes, if any.</param>
        ///<returns>Whether or not the shapes are colliding.</returns>
        public override bool GenerateContactCandidates(TriangleShape triangle, out TinyStructList<ContactData> contactList)
        {
            contactList = new TinyStructList<ContactData>();


            Vector3f ab, ac;
            Vector3f.Subtract(ref triangle.vB, ref triangle.vA, out ab);
            Vector3f.Subtract(ref triangle.vC, ref triangle.vA, out ac);
            Vector3f triangleNormal;
            Vector3f.Cross(ref ab, ref ac, out triangleNormal);
            if (triangleNormal.LengthSquared < MathHelper.Epsilon * .01f)
            {
                //If the triangle is degenerate, use the offset between its center and the sphere.
                Vector3f.Add(ref triangle.vA, ref triangle.vB, out triangleNormal);
                Vector3f.Add(ref triangleNormal, ref triangle.vC, out triangleNormal);
                Vector3f.Multiply(ref triangleNormal, 1 / 3f, out triangleNormal);
                if (triangleNormal.LengthSquared < MathHelper.Epsilon * .01f)
                    triangleNormal = Toolbox.UpVector; //Alrighty then! Pick a random direction.
                    
            }

            
            float dot;
            Vector3f.Dot(ref triangleNormal, ref triangle.vA, out dot);
            switch (triangle.sidedness)
            {
                case TriangleSidedness.DoubleSided:
                    if (dot < 0)
                        Vector3f.Negate(ref triangleNormal, out triangleNormal); //Normal must face outward.
                    break;
                case TriangleSidedness.Clockwise:
                    if (dot > 0)
                        return false; //Wrong side, can't have a contact pointing in a reasonable direction.
                    break;
                case TriangleSidedness.Counterclockwise:
                    if (dot < 0)
                        return false; //Wrong side, can't have a contact pointing in a reasonable direction.
                    break;

            }


            Vector3f closestPoint;
            //Could optimize this process a bit.  The 'point' being compared is always zero.  Additionally, since the triangle normal is available,
            //there is a little extra possible optimization.
            lastRegion = Toolbox.GetClosestPointOnTriangleToPoint(ref triangle.vA, ref triangle.vB, ref triangle.vC, ref Toolbox.ZeroVector, out closestPoint);
            float lengthSquared = closestPoint.LengthSquared;
            float marginSum = triangle.collisionMargin + sphere.collisionMargin;

            if (lengthSquared <= marginSum * marginSum)
            {
                var contact = new ContactData();
                if (lengthSquared < MathHelper.Epsilon)
                {
                    //Super close to the triangle.  Normalizing would be dangerous.

                    Vector3f.Negate(ref triangleNormal, out contact.Normal);
                    contact.Normal.Normalize();
                    contact.PenetrationDepth = marginSum;
                    contactList.Add(ref contact);
                    return true;
                }

                lengthSquared = (float)Math.Sqrt(lengthSquared);
                Vector3f.Divide(ref closestPoint, lengthSquared, out contact.Normal);
                contact.PenetrationDepth = marginSum - lengthSquared;
                contact.Position = closestPoint;
                contactList.Add(ref contact);
                return true;

            }
            return false;




        }

        public override VoronoiRegion GetRegion(TriangleShape triangle, ref ContactData contact)
        {
            return lastRegion;
        }


        public override bool ShouldCorrectContactNormal
        {
            get
            {
                return false;
            }
        }

        ///<summary>
        /// Initializes the pair tester.
        ///</summary>
        ///<param name="convex">Convex shape to use.</param>
        public override void Initialize(ConvexShape convex)
        {
            this.sphere = (SphereShape)convex;
        }

        /// <summary>
        /// Cleans up the pair tester.
        /// </summary>
        public override void CleanUp()
        {
            sphere = null;
            Updated = false;
        }
    }

}
