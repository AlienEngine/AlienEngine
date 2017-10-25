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

using System;

namespace AlienEngine
{
    /// <summary>
    /// Vector's helper.
    /// </summary>
    public static class VectorHelper
    {
        /// <summary>
        /// Gets the up vector (0,1,0).
        /// </summary>
        public static Vector3f Up
        {
            get
            {
                return new Vector3f()
                {
                    X = 0,
                    Y = 1,
                    Z = 0
                };
            }
        }

        /// <summary>
        /// Gets the down vector (0,-1,0).
        /// </summary>
        public static Vector3f Down
        {
            get
            {
                return new Vector3f()
                {
                    X = 0,
                    Y = -1,
                    Z = 0
                };
            }
        }

        /// <summary>
        /// Gets the right vector (1,0,0).
        /// </summary>
        public static Vector3f Right
        {
            get
            {
                return new Vector3f()
                {
                    X = 1,
                    Y = 0,
                    Z = 0
                };
            }
        }

        /// <summary>
        /// Gets the left vector (-1,0,0).
        /// </summary>
        public static Vector3f Left
        {
            get
            {
                return new Vector3f()
                {
                    X = -1,
                    Y = 0,
                    Z = 0
                };
            }
        }

        /// <summary>
        /// Gets the forward vector (0,0,-1).
        /// </summary>
        public static Vector3f Forward
        {
            get
            {
                return new Vector3f()
                {
                    X = 0,
                    Y = 0,
                    Z = -1
                };
            }
        }

        /// <summary>
        /// Gets the back vector (0,0,1).
        /// </summary>
        public static Vector3f Backward
        {
            get
            {
                return new Vector3f()
                {
                    X = 0,
                    Y = 0,
                    Z = 1
                };
            }
        }

        /// <summary>
        /// Represents an invalid Vector3.
        /// </summary>
        public static readonly Vector3f NoVector = new Vector3f(-Single.MaxValue, -Single.MaxValue, -Single.MaxValue);

        /// <summary>
        /// Update maximum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this Vector3f item, ref Vector3f currentMax)
        {
            if (currentMax.X < item.X) { currentMax.X = item.X; }
            if (currentMax.Y < item.Y) { currentMax.Y = item.Y; }
            if (currentMax.Z < item.Z) { currentMax.Z = item.Z; }
        }

        /// <summary>
        /// Update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this Vector3i item, ref Vector3i currentMax)
        {
            if (currentMax.X < item.X) { currentMax.X = item.X; }
            if (currentMax.Y < item.Y) { currentMax.Y = item.Y; }
            if (currentMax.Z < item.Z) { currentMax.Z = item.Z; }
        }

        /// <summary>
        /// Update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this Vector3ui item, ref Vector3ui currentMax)
        {
            if (currentMax.X < item.X) { currentMax.X = item.X; }
            if (currentMax.Y < item.Y) { currentMax.Y = item.Y; }
            if (currentMax.Z < item.Z) { currentMax.Z = item.Z; }
        }

        /// <summary>
        /// Update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMin"></param>
        public static void UpdateMin(this Vector3f item, ref Vector3f currentMin)
        {
            if (item.X < currentMin.X) { currentMin.X = item.X; }
            if (item.Y < currentMin.Y) { currentMin.Y = item.Y; }
            if (item.Z < currentMin.Z) { currentMin.Z = item.Z; }
        }

        /// <summary>
        /// Update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMin"></param>
        public static void UpdateMin(this Vector3i item, ref Vector3i currentMin)
        {
            if (item.X < currentMin.X) { currentMin.X = item.X; }
            if (item.Y < currentMin.Y) { currentMin.Y = item.Y; }
            if (item.Z < currentMin.Z) { currentMin.Z = item.Z; }
        }

        /// <summary>
        /// Update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMin"></param>
        public static void UpdateMin(this Vector3ui item, ref Vector3ui currentMin)
        {
            if (item.X < currentMin.X) { currentMin.X = item.X; }
            if (item.Y < currentMin.Y) { currentMin.Y = item.Y; }
            if (item.Z < currentMin.Z) { currentMin.Z = item.Z; }
        }
    }
}