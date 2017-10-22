using AlienEngine.Core.Physics.Entities;

namespace AlienEngine.Core.Physics.Constraints.TwoEntity.Joints
{
    /// <summary>
    /// Constrains a point on one body to be on a plane defined by another body.
    /// </summary>
    public class PointOnPlaneJoint : Joint, I1DImpulseConstraintWithError, I1DJacobianConstraint
    {
        private float accumulatedImpulse;
        private float biasVelocity;
        private float error;

        private Vector3f localPlaneAnchor;
        private Vector3f localPlaneNormal;
        private Vector3f localPointAnchor;

        private Vector3f worldPlaneAnchor;
        private Vector3f worldPlaneNormal;
        private Vector3f worldPointAnchor;
        private float negativeEffectiveMass;
        private Vector3f rA;
        private Vector3f rAcrossN;
        private Vector3f rB;
        private Vector3f rBcrossN;

        /// <summary>
        /// Constructs a new point on plane constraint.
        /// To finish the initialization, specify the connections (ConnectionA and ConnectionB) 
        /// as well as the PlaneAnchor, PlaneNormal, and PointAnchor (or their entity-local versions).
        /// This constructor sets the constraint's IsActive property to false by default.
        /// </summary>
        public PointOnPlaneJoint()
        {
            IsActive = false;
        }

        /// <summary>
        /// Constructs a new point on plane constraint.
        /// </summary>
        /// <param name="connectionA">Entity to which the constraint's plane is attached.</param>
        /// <param name="connectionB">Entity to which the constraint's point is attached.</param>
        /// <param name="planeAnchor">A point on the plane.</param>
        /// <param name="normal">Direction, attached to the first connected entity, defining the plane's normal</param>
        /// <param name="pointAnchor">The point to constrain to the plane, attached to the second connected object.</param>
        public PointOnPlaneJoint(Entity connectionA, Entity connectionB, Vector3f planeAnchor, Vector3f normal, Vector3f pointAnchor)
        {
            ConnectionA = connectionA;
            ConnectionB = connectionB;

            PointAnchor = pointAnchor;
            PlaneAnchor = planeAnchor;
            PlaneNormal = normal;
        }

        /// <summary>
        /// Gets or sets the plane's anchor in entity A's local space.
        /// </summary>
        public Vector3f LocalPlaneAnchor
        {
            get { return localPlaneAnchor; }
            set
            {
                localPlaneAnchor = value;
                Vector3f.Transform(ref localPlaneAnchor, ref connectionA.orientationMatrix, out worldPlaneAnchor);
                Vector3f.Add(ref connectionA.position, ref worldPlaneAnchor, out worldPlaneAnchor);
            }
        }

        /// <summary>
        /// Gets or sets the plane's normal in entity A's local space.
        /// </summary>
        public Vector3f LocalPlaneNormal
        {
            get { return localPlaneNormal; }
            set
            {
                localPlaneNormal = Vector3f.Normalize(value);
                Vector3f.Transform(ref localPlaneNormal, ref connectionA.orientationMatrix, out worldPlaneNormal);
            }
        }

        /// <summary>
        /// Gets or sets the point anchor in entity B's local space.
        /// </summary>
        public Vector3f LocalPointAnchor
        {
            get { return localPointAnchor; }
            set
            {
                localPointAnchor = value;
                Vector3f.Transform(ref localPointAnchor, ref connectionB.orientationMatrix, out worldPointAnchor);
                Vector3f.Add(ref worldPointAnchor, ref connectionB.position, out worldPointAnchor);
            }
        }

        /// <summary>
        /// Gets the offset from A to the connection point between the entities.
        /// </summary>
        public Vector3f OffsetA
        {
            get { return rA; }
        }

        /// <summary>
        /// Gets the offset from B to the connection point between the entities.
        /// </summary>
        public Vector3f OffsetB
        {
            get { return rB; }
        }

        /// <summary>
        /// Gets or sets the plane anchor in world space.
        /// </summary>
        public Vector3f PlaneAnchor
        {
            get { return worldPlaneAnchor; }
            set
            {
                worldPlaneAnchor = value;
                localPlaneAnchor = value - connectionA.position;
                Vector3f.TransformTranspose(ref localPlaneAnchor, ref connectionA.orientationMatrix, out localPlaneAnchor);

            }
        }

        /// <summary>
        /// Gets or sets the plane's normal in world space.
        /// </summary>
        public Vector3f PlaneNormal
        {
            get { return worldPlaneNormal; }
            set
            {
                worldPlaneNormal = Vector3f.Normalize(value);
                Vector3f.TransformTranspose(ref worldPlaneNormal, ref connectionA.orientationMatrix, out localPlaneNormal);
            }
        }

        /// <summary>
        /// Gets or sets the point anchor in world space.
        /// </summary>
        public Vector3f PointAnchor
        {
            get { return worldPointAnchor; }
            set
            {
                worldPointAnchor = value;
                localPointAnchor = value - connectionB.position;
                Vector3f.TransformTranspose(ref localPointAnchor, ref connectionB.orientationMatrix, out localPointAnchor);

            }
        }

        #region I1DImpulseConstraintWithError Members

        /// <summary>
        /// Gets the current relative velocity between the connected entities with respect to the constraint.
        /// </summary>
        public float RelativeVelocity
        {
            get
            {
                Vector3f dv;
                Vector3f aVel, bVel;
                Vector3f.Cross(ref connectionA.angularVelocity, ref rA, out aVel);
                Vector3f.Add(ref aVel, ref connectionA.linearVelocity, out aVel);
                Vector3f.Cross(ref connectionB.angularVelocity, ref rB, out bVel);
                Vector3f.Add(ref bVel, ref connectionB.linearVelocity, out bVel);
                Vector3f.Subtract(ref aVel, ref bVel, out dv);
                float velocityDifference;
                Vector3f.Dot(ref dv, ref worldPlaneNormal, out velocityDifference);
                return velocityDifference;
            }
        }


        /// <summary>
        /// Gets the total impulse applied by this constraint.
        /// </summary>
        public float TotalImpulse
        {
            get { return accumulatedImpulse; }
        }

        /// <summary>
        /// Gets the current constraint error.
        /// </summary>
        public float Error
        {
            get { return error; }
        }

        #endregion

        #region I1DJacobianConstraint Members

        /// <summary>
        /// Gets the linear jacobian entry for the first connected entity.
        /// </summary>
        /// <param name="jacobian">Linear jacobian entry for the first connected entity.</param>
        public void GetLinearJacobianA(out Vector3f jacobian)
        {
            jacobian = worldPlaneNormal;
        }

        /// <summary>
        /// Gets the linear jacobian entry for the second connected entity.
        /// </summary>
        /// <param name="jacobian">Linear jacobian entry for the second connected entity.</param>
        public void GetLinearJacobianB(out Vector3f jacobian)
        {
            jacobian = -worldPlaneNormal;
        }

        /// <summary>
        /// Gets the angular jacobian entry for the first connected entity.
        /// </summary>
        /// <param name="jacobian">Angular jacobian entry for the first connected entity.</param>
        public void GetAngularJacobianA(out Vector3f jacobian)
        {
            jacobian = rAcrossN;
        }

        /// <summary>
        /// Gets the angular jacobian entry for the second connected entity.
        /// </summary>
        /// <param name="jacobian">Angular jacobian entry for the second connected entity.</param>
        public void GetAngularJacobianB(out Vector3f jacobian)
        {
            jacobian = -rBcrossN;
        }

        /// <summary>
        /// Gets the mass matrix of the constraint.
        /// </summary>
        /// <param name="outputMassMatrix">Constraint's mass matrix.</param>
        public void GetMassMatrix(out float outputMassMatrix)
        {
            outputMassMatrix = -negativeEffectiveMass;
        }

        #endregion

        /// <summary>
        /// Computes one iteration of the constraint to meet the solver updateable's goal.
        /// </summary>
        /// <returns>The rough applied impulse magnitude.</returns>
        public override float SolveIteration()
        {
            //TODO: This could technically be faster.
            //Form the jacobian explicitly.
            //Cross cross add add subtract dot
            //vs
            //dot dot dot dot and then scalar adds
            Vector3f dv;
            Vector3f aVel, bVel;
            Vector3f.Cross(ref connectionA.angularVelocity, ref rA, out aVel);
            Vector3f.Add(ref aVel, ref connectionA.linearVelocity, out aVel);
            Vector3f.Cross(ref connectionB.angularVelocity, ref rB, out bVel);
            Vector3f.Add(ref bVel, ref connectionB.linearVelocity, out bVel);
            Vector3f.Subtract(ref aVel, ref bVel, out dv);
            float velocityDifference;
            Vector3f.Dot(ref dv, ref worldPlaneNormal, out velocityDifference);
            //if(velocityDifference > 0)
            //    Debug.WriteLine("Velocity difference: " + velocityDifference);
            //Debug.WriteLine("softness velocity: " + softness * accumulatedImpulse);
            float lambda = negativeEffectiveMass * (velocityDifference + biasVelocity + softness * accumulatedImpulse);
            accumulatedImpulse += lambda;

            Vector3f impulse;
            Vector3f torque;
            Vector3f.Multiply(ref worldPlaneNormal, lambda, out impulse);
            if (connectionA.isDynamic)
            {
                Vector3f.Multiply(ref rAcrossN, lambda, out torque);
                connectionA.ApplyLinearImpulse(ref impulse);
                connectionA.ApplyAngularImpulse(ref torque);
            }
            if (connectionB.isDynamic)
            {
                Vector3f.Negate(ref impulse, out impulse);
                Vector3f.Multiply(ref rBcrossN, lambda, out torque);
                connectionB.ApplyLinearImpulse(ref impulse);
                connectionB.ApplyAngularImpulse(ref torque);
            }

            return lambda;
        }

        ///<summary>
        /// Performs the frame's configuration step.
        ///</summary>
        ///<param name="dt">Timestep duration.</param>
        public override void Update(float dt)
        {
            Vector3f.Transform(ref localPlaneNormal, ref connectionA.orientationMatrix, out worldPlaneNormal);
            Vector3f.Transform(ref localPlaneAnchor, ref connectionA.orientationMatrix, out worldPlaneAnchor);
            Vector3f.Add(ref worldPlaneAnchor, ref connectionA.position, out worldPlaneAnchor);

            Vector3f.Transform(ref localPointAnchor, ref connectionB.orientationMatrix, out rB);
            Vector3f.Add(ref rB, ref connectionB.position, out worldPointAnchor);

            //Find rA and rB.
            //So find the closest point on the plane to worldPointAnchor.
            float pointDistance, planeDistance;
            Vector3f.Dot(ref worldPointAnchor, ref worldPlaneNormal, out pointDistance);
            Vector3f.Dot(ref worldPlaneAnchor, ref worldPlaneNormal, out planeDistance);
            float distanceChange = planeDistance - pointDistance;
            Vector3f closestPointOnPlane;
            Vector3f.Multiply(ref worldPlaneNormal, distanceChange, out closestPointOnPlane);
            Vector3f.Add(ref closestPointOnPlane, ref worldPointAnchor, out closestPointOnPlane);

            Vector3f.Subtract(ref closestPointOnPlane, ref connectionA.position, out rA);

            Vector3f.Cross(ref rA, ref worldPlaneNormal, out rAcrossN);
            Vector3f.Cross(ref rB, ref worldPlaneNormal, out rBcrossN);
            Vector3f.Negate(ref rBcrossN, out rBcrossN);

            Vector3f offset;
            Vector3f.Subtract(ref worldPointAnchor, ref closestPointOnPlane, out offset);
            Vector3f.Dot(ref offset, ref worldPlaneNormal, out error);
            float errorReduction;
            springSettings.ComputeErrorReductionAndSoftness(dt, 1 / dt, out errorReduction, out softness);
            biasVelocity = MathHelper.Clamp(-errorReduction * error, -maxCorrectiveVelocity, maxCorrectiveVelocity);

            if (connectionA.IsDynamic && connectionB.IsDynamic)
            {
                Vector3f IrACrossN, IrBCrossN;
                Vector3f.Transform(ref rAcrossN, ref connectionA.inertiaTensorInverse, out IrACrossN);
                Vector3f.Transform(ref rBcrossN, ref connectionB.inertiaTensorInverse, out IrBCrossN);
                float angularA, angularB;
                Vector3f.Dot(ref rAcrossN, ref IrACrossN, out angularA);
                Vector3f.Dot(ref rBcrossN, ref IrBCrossN, out angularB);
                negativeEffectiveMass = connectionA.inverseMass + connectionB.inverseMass + angularA + angularB;
                negativeEffectiveMass = -1 / (negativeEffectiveMass + softness);
            }
            else if (connectionA.IsDynamic && !connectionB.IsDynamic)
            {
                Vector3f IrACrossN;
                Vector3f.Transform(ref rAcrossN, ref connectionA.inertiaTensorInverse, out IrACrossN);
                float angularA;
                Vector3f.Dot(ref rAcrossN, ref IrACrossN, out angularA);
                negativeEffectiveMass = connectionA.inverseMass + angularA;
                negativeEffectiveMass = -1 / (negativeEffectiveMass + softness);
            }
            else if (!connectionA.IsDynamic && connectionB.IsDynamic)
            {
                Vector3f IrBCrossN;
                Vector3f.Transform(ref rBcrossN, ref connectionB.inertiaTensorInverse, out IrBCrossN);
                float angularB;
                Vector3f.Dot(ref rBcrossN, ref IrBCrossN, out angularB);
                negativeEffectiveMass = connectionB.inverseMass + angularB;
                negativeEffectiveMass = -1 / (negativeEffectiveMass + softness);
            }
            else
                negativeEffectiveMass = 0;


        }

        /// <summary>
        /// Performs any pre-solve iteration work that needs exclusive
        /// access to the members of the solver updateable.
        /// Usually, this is used for applying warmstarting impulses.
        /// </summary>
        public override void ExclusiveUpdate()
        {
            //Warm Starting
            Vector3f impulse;
            Vector3f torque;
            Vector3f.Multiply(ref worldPlaneNormal, accumulatedImpulse, out impulse);
            if (connectionA.isDynamic)
            {
                Vector3f.Multiply(ref rAcrossN, accumulatedImpulse, out torque);
                connectionA.ApplyLinearImpulse(ref impulse);
                connectionA.ApplyAngularImpulse(ref torque);
            }
            if (connectionB.isDynamic)
            {
                Vector3f.Negate(ref impulse, out impulse);
                Vector3f.Multiply(ref rBcrossN, accumulatedImpulse, out torque);
                connectionB.ApplyLinearImpulse(ref impulse);
                connectionB.ApplyAngularImpulse(ref torque);
            }
        }
    }
}