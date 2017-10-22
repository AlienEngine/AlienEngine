using System;

namespace AlienEngine.Core.Physics.Constraints
{
    /// <summary>
    /// Defines a three dimensional orthonormal basis used by a constraint.
    /// </summary>
    public class JointBasis3D
    {
        internal Vector3f localPrimaryAxis = VectorHelper.Backward;
        internal Vector3f localXAxis = VectorHelper.Right;
        internal Vector3f localYAxis = VectorHelper.Up;
        internal Vector3f primaryAxis = VectorHelper.Backward;
        internal Matrix3f rotationMatrix = Matrix3f.Identity;
        internal Vector3f xAxis = VectorHelper.Right;
        internal Vector3f yAxis = VectorHelper.Up;

        /// <summary>
        /// Gets the primary axis of the transform in local space.
        /// </summary>
        public Vector3f LocalPrimaryAxis
        {
            get { return localPrimaryAxis; }
        }

        /// <summary>
        /// Gets or sets the local transform of the basis.
        /// </summary>
        public Matrix3f LocalTransform
        {
            get
            {
                var toReturn = new Matrix3f {Right = localXAxis, Up = localYAxis, Backward = localPrimaryAxis};
                return toReturn;
            }
            set { SetLocalAxes(value); }
        }

        /// <summary>
        /// Gets the X axis of the transform in local space.
        /// </summary>
        public Vector3f LocalXAxis
        {
            get { return localXAxis; }
        }

        /// <summary>
        /// Gets the Y axis of the transform in local space.
        /// </summary>
        public Vector3f LocalYAxis
        {
            get { return localYAxis; }
        }

        /// <summary>
        /// Gets the primary axis of the transform.
        /// </summary>
        public Vector3f PrimaryAxis
        {
            get { return primaryAxis; }
        }

        /// <summary>
        /// Gets or sets the rotation matrix used by the joint transform to convert local space axes to world space.
        /// </summary>
        public Matrix3f RotationMatrix
        {
            get { return rotationMatrix; }
            set
            {
                rotationMatrix = value;
                ComputeWorldSpaceAxes();
            }
        }

        /// <summary>
        /// Gets or sets the world transform of the basis.
        /// </summary>
        public Matrix3f WorldTransform
        {
            get
            {
                var toReturn = new Matrix3f {Right = xAxis, Up = yAxis, Backward = primaryAxis};
                return toReturn;
            }
            set { SetWorldAxes(value); }
        }

        /// <summary>
        /// Gets the X axis of the transform.
        /// </summary>
        public Vector3f XAxis
        {
            get { return xAxis; }
        }

        /// <summary>
        /// Gets the Y axis of the transform.
        /// </summary>
        public Vector3f YAxis
        {
            get { return yAxis; }
        }


        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        /// <param name="yAxis">Third axis in the transform.</param>
        /// <param name="rotationMatrix">Matrix to use to transform the local axes into world space.</param>
        public void SetLocalAxes(Vector3f primaryAxis, Vector3f xAxis, Vector3f yAxis, Matrix3f rotationMatrix)
        {
            this.rotationMatrix = rotationMatrix;
            SetLocalAxes(primaryAxis, xAxis, yAxis);
        }


        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        /// <param name="yAxis">Third axis in the transform.</param>
        public void SetLocalAxes(Vector3f primaryAxis, Vector3f xAxis, Vector3f yAxis)
        {
            if (Math.Abs(Vector3f.Dot(primaryAxis, xAxis)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(primaryAxis, yAxis)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(xAxis, yAxis)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform do not form an orthonormal basis.  Ensure that each axis is perpendicular to the other two.");

            localPrimaryAxis = Vector3f.Normalize(primaryAxis);
            localXAxis = Vector3f.Normalize(xAxis);
            localYAxis = Vector3f.Normalize(yAxis);
            ComputeWorldSpaceAxes();
        }

        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="matrix">Rotation matrix representing the three axes.
        /// The matrix's backward vector is used as the primary axis.  
        /// The matrix's right vector is used as the x axis.
        /// The matrix's up vector is used as the y axis.</param>
        public void SetLocalAxes(Matrix3f matrix)
        {
            if (Math.Abs(Vector3f.Dot(matrix.Backward, matrix.Right)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(matrix.Backward, matrix.Up)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(matrix.Right, matrix.Up)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform do not form an orthonormal basis.  Ensure that each axis is perpendicular to the other two.");

            localPrimaryAxis = Vector3f.Normalize(matrix.Backward);
            localXAxis = Vector3f.Normalize(matrix.Right);
            localYAxis = Vector3f.Normalize(matrix.Up);
            ComputeWorldSpaceAxes();
        }


        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        /// <param name="yAxis">Third axis in the transform.</param>
        /// <param name="rotationMatrix">Matrix to use to transform the local axes into world space.</param>
        public void SetWorldAxes(Vector3f primaryAxis, Vector3f xAxis, Vector3f yAxis, Matrix3f rotationMatrix)
        {
            this.rotationMatrix = rotationMatrix;
            SetWorldAxes(primaryAxis, xAxis, yAxis);
        }

        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        /// <param name="yAxis">Third axis in the transform.</param>
        public void SetWorldAxes(Vector3f primaryAxis, Vector3f xAxis, Vector3f yAxis)
        {
            if (Math.Abs(Vector3f.Dot(primaryAxis, xAxis)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(primaryAxis, yAxis)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(xAxis, yAxis)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform do not form an orthonormal basis.  Ensure that each axis is perpendicular to the other two.");

            this.primaryAxis = Vector3f.Normalize(primaryAxis);
            this.xAxis = Vector3f.Normalize(xAxis);
            this.yAxis = Vector3f.Normalize(yAxis);
            Vector3f.TransformTranspose(ref this.primaryAxis, ref rotationMatrix, out localPrimaryAxis);
            Vector3f.TransformTranspose(ref this.xAxis, ref rotationMatrix, out localXAxis);
            Vector3f.TransformTranspose(ref this.yAxis, ref rotationMatrix, out localYAxis);
        }

        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="matrix">Rotation matrix representing the three axes.
        /// The matrix's backward vector is used as the primary axis.  
        /// The matrix's right vector is used as the x axis.
        /// The matrix's up vector is used as the y axis.</param>
        public void SetWorldAxes(Matrix3f matrix)
        {
            if (Math.Abs(Vector3f.Dot(matrix.Backward, matrix.Right)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(matrix.Backward, matrix.Up)) > MathHelper.BigEpsilon ||
                Math.Abs(Vector3f.Dot(matrix.Right, matrix.Up)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform do not form an orthonormal basis.  Ensure that each axis is perpendicular to the other two.");

            primaryAxis = Vector3f.Normalize(matrix.Backward);
            xAxis = Vector3f.Normalize(matrix.Right);
            yAxis = Vector3f.Normalize(matrix.Up);
            Vector3f.TransformTranspose(ref this.primaryAxis, ref rotationMatrix, out localPrimaryAxis);
            Vector3f.TransformTranspose(ref this.xAxis, ref rotationMatrix, out localXAxis);
            Vector3f.TransformTranspose(ref this.yAxis, ref rotationMatrix, out localYAxis);
        }

        internal void ComputeWorldSpaceAxes()
        {
            Vector3f.Transform(ref localPrimaryAxis, ref rotationMatrix, out primaryAxis);
            Vector3f.Transform(ref localXAxis, ref rotationMatrix, out xAxis);
            Vector3f.Transform(ref localYAxis, ref rotationMatrix, out yAxis);
        }
    }

    /// <summary>
    /// Defines a two axes which are perpendicular to each other used by a constraint.
    /// </summary>
    public class JointBasis2D
    {
        internal Vector3f localPrimaryAxis = VectorHelper.Backward;
        internal Vector3f localXAxis = VectorHelper.Right;
        internal Vector3f primaryAxis = VectorHelper.Backward;
        internal Matrix3f rotationMatrix = Matrix3f.Identity;
        internal Vector3f xAxis = VectorHelper.Right;

        /// <summary>
        /// Gets the primary axis of the transform in local space.
        /// </summary>
        public Vector3f LocalPrimaryAxis
        {
            get { return localPrimaryAxis; }
        }

        /// <summary>
        /// Gets the X axis of the transform in local space.
        /// </summary>
        public Vector3f LocalXAxis
        {
            get { return localXAxis; }
        }

        /// <summary>
        /// Gets the primary axis of the transform.
        /// </summary>
        public Vector3f PrimaryAxis
        {
            get { return primaryAxis; }
        }

        /// <summary>
        /// Gets or sets the rotation matrix used by the joint transform to convert local space axes to world space.
        /// </summary>
        public Matrix3f RotationMatrix
        {
            get { return rotationMatrix; }
            set
            {
                rotationMatrix = value;
                ComputeWorldSpaceAxes();
            }
        }

        /// <summary>
        /// Gets the X axis of the transform.
        /// </summary>
        public Vector3f XAxis
        {
            get { return xAxis; }
        }


        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        /// <param name="rotationMatrix">Matrix to use to transform the local axes into world space.</param>
        public void SetLocalAxes(Vector3f primaryAxis, Vector3f xAxis, Matrix3f rotationMatrix)
        {
            this.rotationMatrix = rotationMatrix;
            SetLocalAxes(primaryAxis, xAxis);
        }

        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        public void SetLocalAxes(Vector3f primaryAxis, Vector3f xAxis)
        {
            if (Math.Abs(Vector3f.Dot(primaryAxis, xAxis)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform are not perpendicular.  Ensure that the specified axes form a valid constraint.");

            localPrimaryAxis = Vector3f.Normalize(primaryAxis);
            localXAxis = Vector3f.Normalize(xAxis);
            ComputeWorldSpaceAxes();
        }

        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="matrix">Rotation matrix representing the three axes.
        /// The matrix's backward vector is used as the primary axis.  
        /// The matrix's right vector is used as the x axis.</param>
        public void SetLocalAxes(Matrix3f matrix)
        {
            if (Math.Abs(Vector3f.Dot(matrix.Backward, matrix.Right)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform are not perpendicular.  Ensure that the specified axes form a valid constraint.");
            localPrimaryAxis = Vector3f.Normalize(matrix.Backward);
            localXAxis = Vector3f.Normalize(matrix.Right);
            ComputeWorldSpaceAxes();
        }


        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        /// <param name="rotationMatrix">Matrix to use to transform the local axes into world space.</param>
        public void SetWorldAxes(Vector3f primaryAxis, Vector3f xAxis, Matrix3f rotationMatrix)
        {
            this.rotationMatrix = rotationMatrix;
            SetWorldAxes(primaryAxis, xAxis);
        }

        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="primaryAxis">First axis in the transform.  Usually aligned along the main axis of a joint, like the twist axis of a TwistLimit.</param>
        /// <param name="xAxis">Second axis in the transform.</param>
        public void SetWorldAxes(Vector3f primaryAxis, Vector3f xAxis)
        {
            if (Math.Abs(Vector3f.Dot(primaryAxis, xAxis)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform are not perpendicular.  Ensure that the specified axes form a valid constraint.");
            this.primaryAxis = Vector3f.Normalize(primaryAxis);
            this.xAxis = Vector3f.Normalize(xAxis);
            Vector3f.TransformTranspose(ref this.primaryAxis, ref rotationMatrix, out localPrimaryAxis);
            Vector3f.TransformTranspose(ref this.xAxis, ref rotationMatrix, out localXAxis);
        }

        /// <summary>
        /// Sets up the axes of the transform and ensures that it is an orthonormal basis.
        /// </summary>
        /// <param name="matrix">Rotation matrix representing the three axes.
        /// The matrix's backward vector is used as the primary axis.  
        /// The matrix's right vector is used as the x axis.</param>
        public void SetWorldAxes(Matrix3f matrix)
        {
            if (Math.Abs(Vector3f.Dot(matrix.Backward, matrix.Right)) > MathHelper.BigEpsilon)
                throw new ArgumentException("The axes provided to the joint transform are not perpendicular.  Ensure that the specified axes form a valid constraint.");
            primaryAxis = Vector3f.Normalize(matrix.Backward);
            xAxis = Vector3f.Normalize(matrix.Right);
            Vector3f.TransformTranspose(ref this.primaryAxis, ref rotationMatrix, out localPrimaryAxis);
            Vector3f.TransformTranspose(ref this.xAxis, ref rotationMatrix, out localXAxis);
        }

        internal void ComputeWorldSpaceAxes()
        {
            Vector3f.Transform(ref localPrimaryAxis, ref rotationMatrix, out primaryAxis);
            Vector3f.Transform(ref localXAxis, ref rotationMatrix, out xAxis);
        }
    }
}