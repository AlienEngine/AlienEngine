﻿using System;
using AlienEngine.Core.Physics.BroadPhaseEntries;
using AlienEngine.Core.Physics.BroadPhaseEntries.MobileCollidables;
using AlienEngine.Core.Physics.CollisionShapes.ConvexShapes;
using AlienEngine.Core.Physics.CollisionTests.CollisionAlgorithms;
using AlienEngine.Core.Physics.Settings;
using AlienEngine.Core.Resources;
using AlienEngine.Core.Utils.DataStructures;

namespace AlienEngine.Core.Physics.CollisionTests.Manifolds
{
    ///<summary>
    /// Manages persistent contacts between a triangle and convex.
    ///</summary>
    public class TriangleConvexContactManifold : ContactManifold
    {
        RawValueList<ContactSupplementData> supplementData = new RawValueList<ContactSupplementData>(4);
        TriangleConvexPairTester pairTester;
        TriangleShape localTriangleShape = new TriangleShape();

        ///<summary>
        /// Gets the pair tester used by the manifold.
        ///</summary>
        public TriangleConvexPairTester PairTester
        {
            get
            {
                return pairTester;
            }

        }

        protected ConvexCollidable convex;
        protected ConvexCollidable<TriangleShape> triangle;

        ///<summary>
        /// Gets the convex associated with the pair.
        ///</summary>
        public ConvexCollidable Convex
        {
            get
            {
                return convex;
            }
        }

        ///<summary>
        /// Gets the triangle associated with the pair.
        ///</summary>
        public ConvexCollidable<TriangleShape> Triangle
        {
            get
            {
                return triangle;
            }
        }

        ///<summary>
        /// Constructs a new manifold.
        ///</summary>
        public TriangleConvexContactManifold()
        {
            contacts = new RawList<Contact>(4);
            unusedContacts = new UnsafeResourcePool<Contact>(4);
            contactIndicesToRemove = new RawList<int>(4);
            pairTester = new TriangleConvexPairTester();
        }

        public override void Update(float dt)
        {
            //First, refresh all existing contacts.  This is an incremental manifold.
            ContactRefresher.ContactRefresh(contacts, supplementData, ref convex.worldTransform, ref triangle.worldTransform, contactIndicesToRemove);
            RemoveQueuedContacts();


            //Compute the local triangle vertices.
            //TODO: this could be quicker and cleaner.
            localTriangleShape.collisionMargin = triangle.Shape.collisionMargin;
            localTriangleShape.sidedness = triangle.Shape.sidedness;
            Matrix3f orientation;
            Matrix3f.FromQuaternion(ref triangle.worldTransform.Orientation, out orientation);
            Vector3f.Transform(ref triangle.Shape.vA, ref orientation, out localTriangleShape.vA);
            Vector3f.Transform(ref triangle.Shape.vB, ref orientation, out localTriangleShape.vB);
            Vector3f.Transform(ref triangle.Shape.vC, ref orientation, out localTriangleShape.vC);
            Vector3f.Add(ref localTriangleShape.vA, ref triangle.worldTransform.Position, out localTriangleShape.vA);
            Vector3f.Add(ref localTriangleShape.vB, ref triangle.worldTransform.Position, out localTriangleShape.vB);
            Vector3f.Add(ref localTriangleShape.vC, ref triangle.worldTransform.Position, out localTriangleShape.vC);

            Vector3f.Subtract(ref localTriangleShape.vA, ref convex.worldTransform.Position, out localTriangleShape.vA);
            Vector3f.Subtract(ref localTriangleShape.vB, ref convex.worldTransform.Position, out localTriangleShape.vB);
            Vector3f.Subtract(ref localTriangleShape.vC, ref convex.worldTransform.Position, out localTriangleShape.vC);
            Matrix3f.FromQuaternion(ref convex.worldTransform.Orientation, out orientation);
            Vector3f.TransformTranspose(ref localTriangleShape.vA, ref orientation, out localTriangleShape.vA);
            Vector3f.TransformTranspose(ref localTriangleShape.vB, ref orientation, out localTriangleShape.vB);
            Vector3f.TransformTranspose(ref localTriangleShape.vC, ref orientation, out localTriangleShape.vC);

            //Now, generate a contact between the two shapes.
            ContactData contact;
            TinyStructList<ContactData> contactList;
            if (pairTester.GenerateContactCandidates(localTriangleShape, out contactList))
            {
                for (int i = 0; i < contactList.Count; i++)
                {
                    contactList.Get(i, out contact);
                    //Put the contact into world space.
                    Vector3f.Transform(ref contact.Position, ref orientation, out contact.Position);
                    Vector3f.Add(ref contact.Position, ref convex.worldTransform.Position, out contact.Position);
                    Vector3f.Transform(ref contact.Normal, ref orientation, out contact.Normal);
                    //Check if the contact is unique before proceeding.
                    if (IsContactUnique(ref contact))
                    {
                        //Check if adding the new contact would overflow the manifold.
                        if (contacts.Count == 4)
                        {
                            //Adding that contact would overflow the manifold.  Reduce to the best subset.
                            bool addCandidate;
                            ContactReducer.ReduceContacts(contacts, ref contact, contactIndicesToRemove, out addCandidate);
                            RemoveQueuedContacts();
                            if (addCandidate)
                                Add(ref contact);
                        }
                        else
                        {
                            //Won't overflow the manifold, so just toss it in PROVIDED that it isn't too close to something else.
                            Add(ref contact);
                        }
                    }
                }
            }
            else
            {
                //Clear out the contacts, it's separated.
                for (int i = contacts.Count - 1; i >= 0; i--)
                    Remove(i);
            }

        }

        protected override void Add(ref ContactData contactCandidate)
        {
            ContactSupplementData supplement;
            supplement.BasePenetrationDepth = contactCandidate.PenetrationDepth;
            //The closest point method computes the local space versions before transforming to world... consider cutting out the middle man
            RigidTransform.TransformByInverse(ref contactCandidate.Position, ref convex.worldTransform, out supplement.LocalOffsetA);
            RigidTransform.TransformByInverse(ref contactCandidate.Position, ref triangle.worldTransform, out supplement.LocalOffsetB);
            supplementData.Add(ref supplement);
            base.Add(ref contactCandidate);
        }

        protected override void Remove(int contactIndex)
        {
            supplementData.RemoveAt(contactIndex);
            base.Remove(contactIndex);
        }


        private bool IsContactUnique(ref ContactData contactCandidate)
        {
            contactCandidate.Validate();
            float distanceSquared;
            for (int i = 0; i < contacts.Count; i++)
            {
                Vector3f.DistanceSquared(ref contacts.Elements[i].Position, ref contactCandidate.Position, out distanceSquared);
                if (distanceSquared < CollisionDetectionSettings.ContactMinimumSeparationDistanceSquared)
                {
                    //Update the existing 'redundant' contact with the new information.
                    //This works out because the new contact is the deepest contact according to the previous collision detection iteration.
                    contacts.Elements[i].Normal = contactCandidate.Normal;
                    contacts.Elements[i].Position = contactCandidate.Position;
                    contacts.Elements[i].PenetrationDepth = contactCandidate.PenetrationDepth;
                    supplementData.Elements[i].BasePenetrationDepth = contactCandidate.PenetrationDepth;
                    RigidTransform.TransformByInverse(ref contactCandidate.Position, ref convex.worldTransform, out supplementData.Elements[i].LocalOffsetA);
                    RigidTransform.TransformByInverse(ref contactCandidate.Position, ref triangle.worldTransform, out supplementData.Elements[i].LocalOffsetB);
                    return false;
                }
            }
            return true;
        }

        public override void Initialize(Collidable newCollidableA, Collidable newCollidableB)
        {
            convex = newCollidableA as ConvexCollidable;
            triangle = newCollidableB as ConvexCollidable<TriangleShape>;


            if (convex == null || triangle == null)
            {
                convex = newCollidableB as ConvexCollidable;
                triangle = newCollidableA as ConvexCollidable<TriangleShape>;
                if (convex == null || triangle == null)
                    throw new ArgumentException("Inappropriate types used to initialize contact manifold.");
            }

            pairTester.Initialize(convex.Shape);
        }

        public override void CleanUp()
        {
            supplementData.Clear();
            convex = null;
            triangle = null;
            pairTester.CleanUp();
            base.CleanUp();
        }


    }
}