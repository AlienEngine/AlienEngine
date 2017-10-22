﻿

namespace AlienEngine
{
    ///<summary>
    /// A transformation composed of a linear transformation and a translation.
    ///</summary>
    public struct AffineTransform
    {
        ///<summary>
        /// Translation in the affine transform.
        ///</summary>
        public Vector3f Translation;
        /// <summary>
        /// Linear transform in the affine transform.
        /// </summary>
        public Matrix3f LinearTransform;

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(ref Vector3f translation)
        {
            LinearTransform = Matrix3f.Identity;
            Translation = translation;
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(Vector3f translation)
            : this(ref translation)
        {
        }

        ///<summary>
        /// Constructs a new affine tranform.
        ///</summary>
        ///<param name="orientation">Orientation to use as the linear transform.</param>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(ref Quaternion orientation, ref Vector3f translation)
        {
            Matrix3f.FromQuaternion(ref orientation, out LinearTransform);
            Translation = translation;
        }

        ///<summary>
        /// Constructs a new affine tranform.
        ///</summary>
        ///<param name="orientation">Orientation to use as the linear transform.</param>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(Quaternion orientation, Vector3f translation)
            : this(ref orientation, ref translation)
        {
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="scaling">Scaling to apply in the linear transform.</param>
        ///<param name="orientation">Orientation to apply in the linear transform.</param>
        ///<param name="translation">Translation to apply.</param>
        public AffineTransform(ref Vector3f scaling, ref Quaternion orientation, ref Vector3f translation)
        {
            //Create an SRT transform.
            Matrix3f.CreateScale(ref scaling, out LinearTransform);
            Matrix3f rotation;
            Matrix3f.FromQuaternion(ref orientation, out rotation);
            Matrix3f.Multiply(ref LinearTransform, ref rotation, out LinearTransform);
            Translation = translation;
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="scaling">Scaling to apply in the linear transform.</param>
        ///<param name="orientation">Orientation to apply in the linear transform.</param>
        ///<param name="translation">Translation to apply.</param>
        public AffineTransform(Vector3f scaling, Quaternion orientation, Vector3f translation)
            : this(ref scaling, ref orientation, ref translation)
        {
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="linearTransform">The linear transform component.</param>
        ///<param name="translation">Translation component of the transform.</param>
        public AffineTransform(ref Matrix3f linearTransform, ref Vector3f translation)
        {
            LinearTransform = linearTransform;
            Translation = translation;

        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="linearTransform">The linear transform component.</param>
        ///<param name="translation">Translation component of the transform.</param>
        public AffineTransform(Matrix3f linearTransform, Vector3f translation)
            : this(ref linearTransform, ref translation)
        {
        }

        ///<summary>
        /// Gets or sets the 4x4 matrix representation of the affine transform.
        /// The linear transform is the upper left 3x3 part of the 4x4 matrix.
        /// The translation is included in the matrix's Translation property.
        ///</summary>
        public Matrix4f Matrix
        {
            get
            {
                Matrix4f toReturn;
                Matrix3f.ToMatrix4f(ref LinearTransform, out toReturn);
                toReturn.Translation = Translation;
                return toReturn;
            }
            set
            {
                Matrix3f.FromMatrix4f(ref value, out LinearTransform);
                Translation = value.Translation;
            }
        }


        ///<summary>
        /// Gets the identity affine transform.
        ///</summary>
        public static AffineTransform Identity
        {
            get
            {
                var t = new AffineTransform { LinearTransform = Matrix3f.Identity, Translation = new Vector3f() };
                return t;
            }
        }

        ///<summary>
        /// Transforms a vector by an affine transform.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to apply.</param>
        ///<param name="transformed">Transformed position.</param>
        public static void Transform(ref Vector3f position, ref AffineTransform transform, out Vector3f transformed)
        {
            Vector3f.Transform(ref position, ref transform.LinearTransform, out transformed);
            Vector3f.Add(ref transformed, ref transform.Translation, out transformed);
        }

        ///<summary>
        /// Transforms a vector by an affine transform's inverse.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to invert and apply.</param>
        ///<param name="transformed">Transformed position.</param>
        public static void TransformInverse(ref Vector3f position, ref AffineTransform transform, out Vector3f transformed)
        {
            Vector3f.Subtract(ref position, ref transform.Translation, out transformed);
            Matrix3f inverse;
            Matrix3f.Invert(ref transform.LinearTransform, out inverse);
            Vector3f.TransformTranspose(ref transformed, ref inverse, out transformed);
        }

        ///<summary>
        /// Inverts an affine transform.
        ///</summary>
        ///<param name="transform">Transform to invert.</param>
        /// <param name="inverse">Inverse of the transform.</param>
        public static void Invert(ref AffineTransform transform, out AffineTransform inverse)
        {
            Matrix3f.Invert(ref transform.LinearTransform, out inverse.LinearTransform);
            Vector3f.Transform(ref transform.Translation, ref inverse.LinearTransform, out inverse.Translation);
            Vector3f.Negate(ref inverse.Translation, out inverse.Translation);
        }

        /// <summary>
        /// Multiplies a transform by another transform.
        /// </summary>
        /// <param name="a">First transform.</param>
        /// <param name="b">Second transform.</param>
        /// <param name="transform">Combined transform.</param>
        public static void Multiply(ref AffineTransform a, ref AffineTransform b, out AffineTransform transform)
        {
            Matrix3f linearTransform;//Have to use temporary variable just in case a or b reference is transform.
            Matrix3f.Multiply(ref a.LinearTransform, ref b.LinearTransform, out linearTransform);
            Vector3f translation;
            Vector3f.Transform(ref a.Translation, ref b.LinearTransform, out translation);
            Vector3f.Add(ref translation, ref b.Translation, out transform.Translation);
            transform.LinearTransform = linearTransform;
        }

        ///<summary>
        /// Multiplies a rigid transform by an affine transform.
        ///</summary>
        ///<param name="a">Rigid transform.</param>
        ///<param name="b">Affine transform.</param>
        ///<param name="transform">Combined transform.</param>
        public static void Multiply(ref RigidTransform a, ref AffineTransform b, out AffineTransform transform)
        {
            Matrix3f linearTransform;//Have to use temporary variable just in case b reference is transform.
            Matrix3f.FromQuaternion(ref a.Orientation, out linearTransform);
            Matrix3f.Multiply(ref linearTransform, ref b.LinearTransform, out linearTransform);
            Vector3f translation;
            Vector3f.Transform(ref a.Position, ref b.LinearTransform, out translation);
            Vector3f.Add(ref translation, ref b.Translation, out transform.Translation);
            transform.LinearTransform = linearTransform;
        }


        ///<summary>
        /// Transforms a vector using an affine transform.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="affineTransform">Transform to apply.</param>
        ///<returns>Transformed position.</returns>
        public static Vector3f Transform(Vector3f position, AffineTransform affineTransform)
        {
            Vector3f toReturn;
            Transform(ref position, ref affineTransform, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Creates an affine transform from a rigid transform.
        /// </summary>
        /// <param name="rigid">Rigid transform to base the affine transform on.</param>
        /// <param name="affine">Affine transform created from the rigid transform.</param>
        public static void CreateFromRigidTransform(ref RigidTransform rigid, out AffineTransform affine)
        {
            affine.Translation = rigid.Position;
            Matrix3f.FromQuaternion(ref rigid.Orientation, out affine.LinearTransform);
        }

        /// <summary>
        /// Creates an affine transform from a rigid transform.
        /// </summary>
        /// <param name="rigid">Rigid transform to base the affine transform on.</param>
        /// <returns>Affine transform created from the rigid transform.</returns>
        public static AffineTransform CreateFromRigidTransform(RigidTransform rigid)
        {
            AffineTransform toReturn;
            toReturn.Translation = rigid.Position;
            Matrix3f.FromQuaternion(ref rigid.Orientation, out toReturn.LinearTransform);
            return toReturn;
        }

    }
}