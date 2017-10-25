using AlienEngine.Core.Physics.Constraints.Collision;

namespace AlienEngine.Core.Physics.NarrowPhaseSystems.Pairs
{
    ///<summary>
    /// Pair handler that manages a pair of two boxes.
    ///</summary>
    public abstract class ConvexConstraintPairHandler : ConvexPairHandler
    {
        private ConvexContactManifoldConstraint contactConstraint;


        /// <summary>
        /// Gets the contact constraint used by the pair handler.
        /// </summary>
        public override ContactManifoldConstraint ContactConstraint
        {
            get { return contactConstraint; }
        }

        protected ConvexConstraintPairHandler()
        {
            contactConstraint = new ConvexContactManifoldConstraint(this);
        }

        protected internal override void GetContactInformation(int index, out ContactInformation info)
        {
            info.Contact = ContactManifold.contacts.Elements[index];
            //Find the contact's normal force.
            float totalNormalImpulse = 0;
            info.NormalImpulse = 0;
            for (int i = 0; i < contactConstraint.penetrationConstraints.Count; i++)
            {
                totalNormalImpulse += contactConstraint.penetrationConstraints.Elements[i].accumulatedImpulse;
                if (contactConstraint.penetrationConstraints.Elements[i].contact == info.Contact)
                {
                    info.NormalImpulse = contactConstraint.penetrationConstraints.Elements[i].accumulatedImpulse;
                }
            }
            //Compute friction force.  Since we are using central friction, this is 'faked.'
            float radius;
            Vector3f.Distance(ref contactConstraint.slidingFriction.manifoldCenter, ref info.Contact.Position, out radius);
            if (totalNormalImpulse > 0)
                info.FrictionImpulse = (info.NormalImpulse / totalNormalImpulse) * (contactConstraint.slidingFriction.accumulatedImpulse.Length + contactConstraint.twistFriction.accumulatedImpulse * radius);
            else
                info.FrictionImpulse = 0;
            //Compute relative velocity
            Vector3f velocity;
            //If the pair is handling some type of query and does not actually have supporting entities, then consider the velocity contribution to be zero.
            if (EntityA != null)
            {
                Vector3f.Subtract(ref info.Contact.Position, ref EntityA.position, out velocity);
                Vector3f.Cross(ref EntityA.angularVelocity, ref velocity, out velocity);
                Vector3f.Add(ref velocity, ref EntityA.linearVelocity, out info.RelativeVelocity);
            }
            else
                info.RelativeVelocity = new Vector3f();

            if (EntityB != null)
            {
                Vector3f.Subtract(ref info.Contact.Position, ref EntityB.position, out velocity);
                Vector3f.Cross(ref EntityB.angularVelocity, ref velocity, out velocity);
                Vector3f.Add(ref velocity, ref EntityB.linearVelocity, out velocity);
                Vector3f.Subtract(ref info.RelativeVelocity, ref velocity, out info.RelativeVelocity);
            }


            info.Pair = this;

        }

    }

}
