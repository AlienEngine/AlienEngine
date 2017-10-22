using System;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.Ik
{
    /// <summary>
    /// Connects two bones together.
    /// </summary>
    public abstract class IKLimit : IKJoint
    {
        protected IKLimit(Bone connectionA, Bone connectionB)
            : base(connectionA, connectionB)
        {
        }

        protected internal override void SolveVelocityIteration()
        {
            //Compute the 'relative' linear and angular velocities. For single bone constraints, it's based entirely on the one bone's velocities!
            //They have to be pulled into constraint space first to compute the necessary impulse, though.
            Vector3f linearContributionA;
            Vector3f.TransformTranspose(ref ConnectionA.linearVelocity, ref linearJacobianA, out linearContributionA);
            Vector3f angularContributionA;
            Vector3f.TransformTranspose(ref ConnectionA.angularVelocity, ref angularJacobianA, out angularContributionA);
            Vector3f linearContributionB;
            Vector3f.TransformTranspose(ref ConnectionB.linearVelocity, ref linearJacobianB, out linearContributionB);
            Vector3f angularContributionB;
            Vector3f.TransformTranspose(ref ConnectionB.angularVelocity, ref angularJacobianB, out angularContributionB);

            //The constraint velocity error will be the velocity we try to remove.
            Vector3f constraintVelocityError;
            Vector3f.Add(ref linearContributionA, ref angularContributionA, out constraintVelocityError);
            Vector3f.Add(ref constraintVelocityError, ref linearContributionB, out constraintVelocityError);
            Vector3f.Add(ref constraintVelocityError, ref angularContributionB, out constraintVelocityError);
            //However, we need to take into account two extra sources of velocities which modify our target velocity away from zero.
            //First, the velocity bias from position correction:
            Vector3f.Subtract(ref constraintVelocityError, ref velocityBias, out constraintVelocityError);
            //And second, the bias from softness:
            Vector3f softnessBias;
            Vector3f.Multiply(ref accumulatedImpulse, -softness, out softnessBias);
            Vector3f.Subtract(ref constraintVelocityError, ref softnessBias, out constraintVelocityError);

            //By now, the constraint velocity error contains all the velocity we want to get rid of.
            //Convert it into an impulse using the effective mass matrix.
            Vector3f constraintSpaceImpulse;
            Vector3f.Transform(ref constraintVelocityError, ref effectiveMass, out constraintSpaceImpulse);

            Vector3f.Negate(ref constraintSpaceImpulse, out constraintSpaceImpulse);

            //Add the constraint space impulse to the accumulated impulse so that warm starting and softness work properly.
            Vector3f preadd = accumulatedImpulse;
            Vector3f.Add(ref constraintSpaceImpulse, ref accumulatedImpulse, out accumulatedImpulse);
            //Limits can only apply positive impulses.
            Vector3f.ComponentMax(ref Toolbox.ZeroVector, ref accumulatedImpulse, out accumulatedImpulse);
            //But wait! The accumulated impulse may exceed this constraint's capacity! Check to make sure!
            float impulseSquared = accumulatedImpulse.LengthSquared;
            if (impulseSquared > maximumImpulseSquared)
            {
                //Oops! Clamp that down.
                Vector3f.Multiply(ref accumulatedImpulse, maximumImpulse / (float)Math.Sqrt(impulseSquared), out accumulatedImpulse);
            }
            //Update the impulse based upon the clamped accumulated impulse and the original, pre-add accumulated impulse.
            Vector3f.Subtract(ref accumulatedImpulse, ref preadd, out constraintSpaceImpulse);

            //The constraint space impulse now represents the impulse we want to apply to the bone... but in constraint space.
            //Bring it out to world space using the transposed jacobian.
            if (!ConnectionA.Pinned)//Treat pinned elements as if they have infinite inertia.
            {
                Vector3f linearImpulseA;
                Vector3f.Transform(ref constraintSpaceImpulse, ref linearJacobianA, out linearImpulseA);
                Vector3f angularImpulseA;
                Vector3f.Transform(ref constraintSpaceImpulse, ref angularJacobianA, out angularImpulseA);

                //Apply them!
                ConnectionA.ApplyLinearImpulse(ref linearImpulseA);
                ConnectionA.ApplyAngularImpulse(ref angularImpulseA);
            }
            if (!ConnectionB.Pinned)//Treat pinned elements as if they have infinite inertia.
            {
                Vector3f linearImpulseB;
                Vector3f.Transform(ref constraintSpaceImpulse, ref linearJacobianB, out linearImpulseB);
                Vector3f angularImpulseB;
                Vector3f.Transform(ref constraintSpaceImpulse, ref angularJacobianB, out angularImpulseB);

                //Apply them!
                ConnectionB.ApplyLinearImpulse(ref linearImpulseB);
                ConnectionB.ApplyAngularImpulse(ref angularImpulseB);
            }

        }

    }
}
