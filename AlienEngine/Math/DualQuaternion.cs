#region License

// Copyright (C) 2017 AlienGames
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
// USA

#endregion

namespace AlienEngine
{
    /// <summary>
    /// Dual quaternion class represents a dual quaternion which an represent multiple transfromations
    /// in a single structure an alternative to a 4x4 matrix 
    /// </summary>
    public class DualQuaternion
    {
        #region Fields

        /// <summary>
        /// The real quaternion.
        /// </summary>
        public Quaternion Real;

        /// <summary>
        /// The dual quaternion.
        /// </summary>
        public Quaternion Dual;

        #endregion

        #region Constructors

        /// <summary>
        /// Construct a new <see cref="DualQuaternion"/>.
        /// </summary>
        public DualQuaternion()
        {
            Real = new Quaternion();
            Dual = new Quaternion(0, 0, 0, 0);
        }

        /// <summary>
        /// Construct a new <see cref="DualQuaternion"/>.
        /// </summary>
        /// <param name="rotation">The rotation <see cref="Quaternion"/></param>
        public DualQuaternion(Quaternion rotation)
        {
            Real = rotation;
            Dual = 0.5f * rotation * new Quaternion(0, 0, 0, 0);
        }

        /// <summary>
        /// Construct a new <see cref="DualQuaternion"/>.
        /// </summary>
        /// <param name="tranlation">The translation <see cref="Vector3f"/></param>
        public DualQuaternion(Vector3f tranlation)
        {
            Real = Quaternion.Identity;
            Dual = 0.5f * Quaternion.FromVector(tranlation);
        }

        /// <summary>
        /// Construct a new <see cref="DualQuaternion"/>.
        /// </summary>
        /// <param name="rotation">The rotation <see cref="Quaternion"/></param>
        /// <param name="translation">The translation <see cref="Vector3f"/></param>
        public DualQuaternion(Quaternion rotation, Vector3f translation)
        {
            Real = rotation;
            Dual = 0.5f * rotation * Quaternion.FromVector(translation);
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// not public since it could be confusing as to what 
        /// this could refer to <see cref="DualQuaternion"/> class.
        /// </summary>
        /// <param name='real'>Real.</param>
        /// <param name='dual'>Dual.</param>
        private DualQuaternion(Quaternion real, Quaternion dual)
        {
            Real = real;
            Dual = dual;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the rotation <see cref="Quaternion"/> of this instance.
        /// </summary>
        public Quaternion Rotation => Real;

        /// <summary>
        /// Gets the translation <see cref="Quaternion"/> of this instance.
        /// </summary>
        public Quaternion Translation => 2.0f * Dual * (Quaternion.Conjugate(Real));

        #endregion

        #region Methods

        /// <summary>
        /// Add a <see cref="DualQuaternion"/> to this instance.
        /// </summary>
        /// <param name="q">The <see cref="DualQuaternion"/> to add.</param>
        public void Add(DualQuaternion q)
        {
            Real += q.Real;
            Dual += q.Dual;
        }

        /// <summary>
        /// Multiply a <see cref="DualQuaternion"/> to this instance.
        /// </summary>
        /// <param name="q">The <see cref="DualQuaternion"/>.</param>
        public void Multiply(DualQuaternion q)
        {
            Real *= q.Real;
            Dual = Real * q.Dual + Dual * q.Real;
        }

        /// <summary>
        /// Conjugate this instance.
        /// </summary>
        public void Conjugate()
        {
            Real = Quaternion.Conjugate(Real);
            Dual = Quaternion.Conjugate(Dual);
        }

        #endregion

        #region Static Members

        /// <summary>
        /// Adds two <see cref="DualQuaternion"/>.
        /// </summary>
        /// <param name="left">The first <see cref="DualQuaternion"/>.</param>
        /// <param name="right">The second <see cref="DualQuaternion"/>.</param>
        public static DualQuaternion Add(DualQuaternion left, DualQuaternion right)
        {
            return new DualQuaternion(left.Real + right.Real, left.Dual + right.Dual);
        }

        /// <summary>
        /// Adds two <see cref="DualQuaternion"/>.
        /// </summary>
        /// <param name="left">The first <see cref="DualQuaternion"/>.</param>
        /// <param name="right">The second <see cref="DualQuaternion"/>.</param>
        public static DualQuaternion operator +(DualQuaternion left, DualQuaternion right)
        {
            return Add(left, right);
        }

        /// <summary>
        /// Multiply a <see cref="DualQuaternion"/> with another.
        /// </summary>
        /// <param name="left">The first <see cref="DualQuaternion"/>.</param>
        /// <param name="right">The second <see cref="DualQuaternion"/>.</param>
        /// <remarks>The multiplication of two <see cref="DualQuaternion"/> is not commutative.</remarks>
        public static DualQuaternion Multiply(DualQuaternion left, DualQuaternion right)
        {
            return new DualQuaternion(left.Real * right.Real, left.Real * right.Dual + left.Dual * right.Real);
        }

        /// <summary>
        /// Multiply three <see cref="DualQuaternion"/>.
        /// </summary>
        /// <param name="left">The first <see cref="DualQuaternion"/>.</param>
        /// <param name="right">The second <see cref="DualQuaternion"/>.</param>
        /// <remarks>The multiplication of two <see cref="DualQuaternion"/> is not commutative.</remarks>
        public static DualQuaternion Multiply(DualQuaternion left, DualQuaternion mid, DualQuaternion right)
        {
            return new DualQuaternion(left.Real * mid.Real * right.Real, left.Real * mid.Dual * right.Real + left.Dual * mid.Real * right.Real);
        }

        /// <summary>
        /// Multiply a <see cref="DualQuaternion"/> with another.
        /// </summary>
        /// <param name="left">The first <see cref="DualQuaternion"/>.</param>
        /// <param name="right">The second <see cref="DualQuaternion"/>.</param>
        /// <remarks>The multiplication of two <see cref="DualQuaternion"/> is not commutative.</remarks>
        public static DualQuaternion operator *(DualQuaternion left, DualQuaternion right)
        {
            return Multiply(left, right);
        }

        /// <summary>
        /// Conjugates a <see cref="DualQuaternion"/>.
        /// </summary>
        /// <param name="q">The <see cref="DualQuaternion"/> to conjugate.</param>
        public static DualQuaternion Conjugate(DualQuaternion q)
        {
            return new DualQuaternion(Quaternion.Conjugate(q.Real), Quaternion.Conjugate(q.Dual));
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets the <see cref="System.String"/> representation of this instance.
        /// </summary>
        public override string ToString()
        {
            return $"[DualQuaternion: dual={Dual}, real={Real}]";
        }

        #endregion
    }
}