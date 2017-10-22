﻿using System;
using AlienEngine.Core.Physics.Utilities;

namespace AlienEngine.Core.Physics.Ik
{
    /// <summary>
    /// Keeps the anchor points on two bones at the same distance.
    /// </summary>
    public class IKPointOnLineJoint : IKJoint
    {
        /// <summary>
        /// Gets or sets the offset in connection A's local space from the center of mass to the anchor point of the line.
        /// </summary>
        public Vector3f LocalLineAnchor;

        private Vector3f localLineDirection;
        /// <summary>
        /// Gets or sets the direction of the line in connection A's local space.
        /// Must be unit length.
        /// </summary>
        public Vector3f LocalLineDirection
        {
            get { return localLineDirection; }
            set
            {
                localLineDirection = value;
                ComputeRestrictedAxes();
            }
        }


        /// <summary>
        /// Gets or sets the offset in connection B's local space from the center of mass to the anchor point which will be kept on the line.
        /// </summary>
        public Vector3f LocalAnchorB;

        /// <summary>
        /// Gets or sets the world space location of the line anchor attached to connection A.
        /// </summary>
        public Vector3f LineAnchor
        {
            get { return ConnectionA.Position + Vector3f.Transform(LocalLineAnchor, ConnectionA.Orientation); }
            set { LocalLineAnchor = Vector3f.Transform(value - ConnectionA.Position, Quaternion.Conjugate(ConnectionA.Orientation)); }
        }

        /// <summary>
        /// Gets or sets the world space direction of the line attached to connection A.
        /// Must be unit length.
        /// </summary>
        public Vector3f LineDirection
        {
            get { return Vector3f.Transform(localLineDirection, ConnectionA.Orientation); }
            set { LocalLineDirection = Vector3f.Transform(value, Quaternion.Conjugate(ConnectionA.Orientation)); }
        }

        /// <summary>
        /// Gets or sets the offset in world space from the center of mass of connection B to the anchor point.
        /// </summary>
        public Vector3f AnchorB
        {
            get { return ConnectionB.Position + Vector3f.Transform(LocalAnchorB, ConnectionB.Orientation); }
            set { LocalAnchorB = Vector3f.Transform(value - ConnectionB.Position, Quaternion.Conjugate(ConnectionB.Orientation)); }
        }

        private Vector3f localRestrictedAxis1, localRestrictedAxis2;
        void ComputeRestrictedAxes()
        {
            Vector3f cross;
            Vector3f.Cross(ref localLineDirection, ref Toolbox.UpVector, out cross);
            float lengthSquared = cross.LengthSquared;
            if (lengthSquared > MathHelper.Epsilon)
            {
                Vector3f.Divide(ref cross, (float)Math.Sqrt(lengthSquared), out localRestrictedAxis1);
            }
            else
            {
                //Oops! The direction is aligned with the up vector.
                Vector3f.Cross(ref localLineDirection, ref Toolbox.RightVector, out cross);
                Vector3f.Normalize(ref cross, out localRestrictedAxis1);
            }
            //Don't need to normalize this; cross product of two unit length perpendicular vectors.
            Vector3f.Cross(ref localRestrictedAxis1, ref localLineDirection, out localRestrictedAxis2);
        }

        /// <summary>
        /// Constructs a new point on line joint.
        /// </summary>
        /// <param name="connectionA">First bone connected by the joint.</param>
        /// <param name="connectionB">Second bone connected by the joint.</param>
        /// <param name="lineAnchor">Anchor point of the line attached to the first bone in world space.</param>
        /// <param name="lineDirection">Direction of the line attached to the first bone in world space. Must be unit length.</param>
        /// <param name="anchorB">Anchor point on the second bone in world space which tries to stay on connection A's line.</param>
        public IKPointOnLineJoint(Bone connectionA, Bone connectionB, Vector3f lineAnchor, Vector3f lineDirection, Vector3f anchorB)
            : base(connectionA, connectionB)
        {
            LineAnchor = lineAnchor;
            LineDirection = lineDirection;
            AnchorB = anchorB;

        }

        protected internal override void UpdateJacobiansAndVelocityBias()
        {

            //Transform local stuff into world space
            Vector3f worldRestrictedAxis1, worldRestrictedAxis2;
            Vector3f.Transform(ref localRestrictedAxis1, ref ConnectionA.Orientation, out worldRestrictedAxis1);
            Vector3f.Transform(ref localRestrictedAxis2, ref ConnectionA.Orientation, out worldRestrictedAxis2);

            Vector3f worldLineAnchor;
            Vector3f.Transform(ref LocalLineAnchor, ref ConnectionA.Orientation, out worldLineAnchor);
            Vector3f.Add(ref worldLineAnchor, ref ConnectionA.Position, out worldLineAnchor);
            Vector3f lineDirection;
            Vector3f.Transform(ref localLineDirection, ref ConnectionA.Orientation, out lineDirection);

            Vector3f rB;
            Vector3f.Transform(ref LocalAnchorB, ref ConnectionB.Orientation, out rB);
            Vector3f worldPoint;
            Vector3f.Add(ref rB, ref ConnectionB.Position, out worldPoint);

            //Find the point on the line closest to the world point.
            Vector3f offset;
            Vector3f.Subtract(ref worldPoint, ref worldLineAnchor, out offset);
            float distanceAlongAxis;
            Vector3f.Dot(ref offset, ref lineDirection, out distanceAlongAxis);

            Vector3f worldNearPoint;
            Vector3f.Multiply(ref lineDirection, distanceAlongAxis, out offset);
            Vector3f.Add(ref worldLineAnchor, ref offset, out worldNearPoint);
            Vector3f rA;
            Vector3f.Subtract(ref worldNearPoint, ref ConnectionA.Position, out rA);

            //Error
            Vector3f error3D;
            Vector3f.Subtract(ref worldPoint, ref worldNearPoint, out error3D);

            Vector2f error;
            Vector3f.Dot(ref error3D, ref worldRestrictedAxis1, out error.X);
            Vector3f.Dot(ref error3D, ref worldRestrictedAxis2, out error.Y);

            velocityBias.X = errorCorrectionFactor * error.X;
            velocityBias.Y = errorCorrectionFactor * error.Y;


            //Set up the jacobians
            Vector3f angularA1, angularA2, angularB1, angularB2;
            Vector3f.Cross(ref rA, ref worldRestrictedAxis1, out angularA1);
            Vector3f.Cross(ref rA, ref worldRestrictedAxis2, out angularA2);
            Vector3f.Cross(ref worldRestrictedAxis1, ref rB, out angularB1);
            Vector3f.Cross(ref worldRestrictedAxis2, ref rB, out angularB2);

            //Put all the 1x3 jacobians into a 3x3 matrix representation.
            linearJacobianA = new Matrix3f
            {
                M11 = worldRestrictedAxis1.X,
                M12 = worldRestrictedAxis1.Y,
                M13 = worldRestrictedAxis1.Z,
                M21 = worldRestrictedAxis2.X,
                M22 = worldRestrictedAxis2.Y,
                M23 = worldRestrictedAxis2.Z
            };
            Matrix3f.Negate(ref linearJacobianA, out linearJacobianB);

            angularJacobianA = new Matrix3f
            {
                M11 = angularA1.X,
                M12 = angularA1.Y,
                M13 = angularA1.Z,
                M21 = angularA2.X,
                M22 = angularA2.Y,
                M23 = angularA2.Z
            };
            angularJacobianB = new Matrix3f
            {
                M11 = angularB1.X,
                M12 = angularB1.Y,
                M13 = angularB1.Z,
                M21 = angularB2.X,
                M22 = angularB2.Y,
                M23 = angularB2.Z
            };
        }
    }
}