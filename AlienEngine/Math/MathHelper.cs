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
using System.Collections.Generic;
using System.Text;

namespace AlienEngine
{
    /// <summary>
    /// Contains common mathematical functions and constants.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Large tolerance value. Defaults to 1e-5f.
        /// </summary>
        public static float BigEpsilon = 1E-5f;

        /// <summary>
        /// Tolerance value. Defaults to 1e-7f.
        /// </summary>
        public static float Epsilon = 1E-7f;

        /// <summary>
        /// Refers to the identity quaternion.
        /// </summary>
        public static Quaternion IdentityOrientation = Quaternion.Identity;

        /// <summary>
        /// Refers to the rigid identity transformation.
        /// </summary>
        public static RigidTransform RigidIdentity = RigidTransform.Identity;

        /// <summary>
        /// Defines the value of tau divided by two as a <see cref="System.Single"/>.
        /// </summary>
        public const float Pi = 3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481117450284102701938521105559644622948954930382f;

        /// <summary>
        /// Defines the value of Pi divided by two as a <see cref="System.Single"/>.
        /// </summary>
        public const float PiOver2 = Pi / 2;

        /// <summary>
        /// Defines the value of Pi divided by three as a <see cref="System.Single"/>.
        /// </summary>
        public const float PiOver3 = Pi / 3;

        /// <summary>
        /// Definesthe value of  Pi divided by four as a <see cref="System.Single"/>.
        /// </summary>
        public const float PiOver4 = Pi / 4;

        /// <summary>
        /// Defines the value of Pi divided by six as a <see cref="System.Single"/>.
        /// </summary>
        public const float PiOver6 = Pi / 6;

        /// <summary>
        /// Defines the value of tau as a <see cref="System.Single"/>.
        /// </summary>
        public const float Tau = 2 * Pi;

        /// <summary>
        /// Defines the value of tau as a <see cref="System.Single"/>.
        /// </summary>
        public const float TwoPi = 2 * Pi;

        /// <summary>
        /// Defines the value of tau divided by two as a <see cref="System.Single"/>.
        /// </summary>
        public const float TauOver2 = Pi;

        /// <summary>
        /// Defines the value of tau divided by four as a <see cref="System.Single"/>.
        /// </summary>
        public const float TauOver4 = Tau / 4f;

        /// <summary>
        /// Defines the value of tau divided by six as a <see cref="System.Single"/>.
        /// </summary>
        public const float TauOver6 = Tau / 6f;

        /// <summary>
        /// Defines the value of tau divided by eight as a <see cref="System.Single"/>.
        /// </summary>
        public const float TauOver8 = Tau / 8f;

        /// <summary>
        /// Defines the value of tau divided by twelve as a <see cref="System.Single"/>.
        /// </summary>
        public const float TauOver12 = Tau / 12f;

        /// <summary>
        /// Defines the value of Pi multiplied by 3 and divided by two as a <see cref="System.Single"/>.
        /// </summary>
        public const float ThreePiOver2 = 3 * Pi / 2;

        /// <summary>
        /// Defines the value of E as a <see cref="System.Single"/>.
        /// </summary>
        public const float E = 2.71828182845904523536f;

        /// <summary>
        /// Defines the base-10 logarithm of E.
        /// </summary>
        public const float Log10E = 0.434294482f;

        /// <summary>
        /// Defines the base-2 logarithm of E.
        /// </summary>
        public const float Log2E = 1.442695041f;

        /// <summary>
        /// Gets the arc cosinus of a value.
        /// </summary>
        /// <param name="x">The value</param>
        public static float Acos(float x)
        {
            return (float)Math.Acos(x);
        }

        /// <summary>
        /// Gets the hyperbolic arc cosinus of a value.
        /// </summary>
        /// <param name="x">The value</param>
        public static float Acosh(float x)
        {
            if (x < (1f))
                return 0f;
            return (float)Math.Log(x + Math.Sqrt(x * x - (1f)));
        }

        /// <summary>
        /// Gets the arc sinus of a value.
        /// </summary>
        /// <param name="x">The value.</param>
        public static float Asin(float x)
        {
            return (float)Math.Asin(x);
        }

        /// <summary>
        /// Gets the hyperbolic arc sinus of a value.
        /// </summary>
        /// <param name="x">The value</param>
        public static float Asinh(float x)
        {
            return (x < 0f ? -1f : (x > 0f ? 1f : 0f)) * (float)Math.Log(Math.Abs(x) + Math.Sqrt(1f + x * x));
        }

        /// <summary>
        /// Gets the arc tangent of two values.
        /// </summary>
        /// <param name="y">The first value.</param>
        /// <param name="x">The second value.</param>
        public static float Atan(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        /// <summary>
        /// Gets the arc tangent of a value.
        /// </summary>
        /// <param name="y_over_x">The value.</param>
        public static float Atan(float y_over_x)
        {
            return (float)Math.Atan(y_over_x);
        }

        /// <summary>
        /// Gets the hyperbolic arc tangent of a value
        /// </summary>
        /// <param name="x">The value.</param>
        public static float Atanh(float x)
        {
            if (Math.Abs(x) >= 1f)
                return 0f;
            return (0.5f) * (float)Math.Log((1f + x) / (1f - x));
        }

        /// <summary>
        /// Gets the cosinus value of an angle.
        /// </summary>
        /// <param name="angle">The angle.</param>
        public static float Cos(float angle)
        {
            return (float)Math.Cos(angle);
        }

        /// <summary>
        /// Gets the hyperbolic cosinus value of an angle.
        /// </summary>
        /// <param name="angle">The angle.</param>
        public static float Cosh(float angle)
        {
            return (float)Math.Cosh(angle);
        }

        /// <summary>
        /// Gets the sinus value of an angle.
        /// </summary>
        /// <param name="angle">The angle.</param>
        public static float Sin(float angle)
        {
            return (float)Math.Sin(angle);
        }

        /// <summary>
        /// Gets the hyperbolic sinus value of an angle.
        /// </summary>
        /// <param name="angle">The angle.</param>
        public static float Sinh(float angle)
        {
            return (float)Math.Sinh(angle);
        }

        /// <summary>
        /// Gets the tangent value of an angle.
        /// </summary>
        /// <param name="angle">The angle.</param>
        public static float Tan(float angle)
        {
            return (float)Math.Tan(angle);
        }

        /// <summary>
        /// Gets the hyperbolic tangent value of an angle.
        /// </summary>
        /// <param name="angle">The angle.</param>
        public static float Tanh(float angle)
        {
            return (float)Math.Tanh(angle);
        }

        /// <summary>
        /// Returns the next power of two that is larger than the specified number.
        /// </summary>
        /// <param name="n">The specified number.</param>
        /// <returns>The next power of two.</returns>
        public static long NextPowerOfTwo(long n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            return (long)Math.Pow(2, Math.Ceiling(Math.Log(n, 2)));
        }

        /// <summary>
        /// Returns the next power of two that is larger than the specified number.
        /// </summary>
        /// <param name="n">The specified number.</param>
        /// <returns>The next power of two.</returns>
        public static int NextPowerOfTwo(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            return (int)Math.Pow(2, Math.Ceiling(Math.Log(n, 2)));
        }

        /// <summary>
        /// Returns the next power of two that is larger than the specified number.
        /// </summary>
        /// <param name="n">The specified number.</param>
        /// <returns>The next power of two.</returns>
        public static float NextPowerOfTwo(float n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            return (float)Math.Pow(2, Math.Ceiling(Math.Log(n, 2)));
        }

        /// <summary>
        /// Returns the next power of two that is larger than the specified number.
        /// </summary>
        /// <param name="n">The specified number.</param>
        /// <returns>The next power of two.</returns>
        public static double NextPowerOfTwo(double n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            return Math.Pow(2, Math.Ceiling(Math.Log(n, 2)));
        }

        /// <summary>
        /// Returns the previous power of two that is smaller than the specified number.
        /// </summary>
        /// <param name="n">Value to round down</param>
        /// <returns>Rounded down to the nearest power of two</returns>
        public static long PreviousPowerOfTwo(long n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            n = n | (n >> 1);
            n = n | (n >> 2);
            n = n | (n >> 4);
            n = n | (n >> 8);
            n = n | (n >> 16);
            return n - (n >> 1);
        }

        /// <summary>
        /// Returns the previous power of two that is smaller than the specified number.
        /// </summary>
        /// <param name="n">Value to round down</param>
        /// <returns>Rounded down to the nearest power of two</returns>
        public static int PreviousPowerOfTwo(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            n = n | (n >> 1);
            n = n | (n >> 2);
            n = n | (n >> 4);
            n = n | (n >> 8);
            n = n | (n >> 16);
            return n - (n >> 1);
        }

        /// <summary>
        /// Returns the previous power of two that is smaller than the specified number.
        /// </summary>
        /// <param name="n">Value to round down</param>
        /// <returns>Rounded down to the nearest power of two</returns>
        public static float PreviousPowerOfTwo(float n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            return (float)Math.Pow(2, Math.Floor(Math.Log(n, 2)));
        }

        /// <summary>
        /// Returns the previous power of two that is smaller than the specified number.
        /// </summary>
        /// <param name="n">Value to round down</param>
        /// <returns>Rounded down to the nearest power of two</returns>
        public static double PreviousPowerOfTwo(double n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "Must be positive.");
            return Math.Pow(2, Math.Floor(Math.Log(n, 2)));
        }

        /// <summary>
        /// Calculates the factorial of a given natural number.
        /// </summary>
        /// <param name="n">The number.</param>
        /// <returns>n!</returns>
        public static long Factorial(int n)
        {
            long result = 1;

            for (; n > 1; n--)
                result *= n;

            return result;
        }

        /// <summary>
        /// Calculates the binomial coefficient <paramref name="n"/> above <paramref name="k"/>.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="k">The k.</param>
        /// <returns>n! / (k! * (n - k)!)</returns>
        public static long BinomialCoefficient(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        /// <summary>
        /// Calculates the square root of a number and returns the float value.
        /// </summary>
        /// <param name="x">The number</param>
        /// <returns>The square root float value of the number.</returns>
        public static float Sqrt(float x)
        {
            return (float)System.Math.Sqrt(x);
        }

        /// <summary>
        /// Calculates the square root of a number and returns the float value.
        /// </summary>
        /// <param name="x">The number</param>
        /// <returns>The square root float value of the number.</returns>
        public static float Sqrt(double x)
        {
            return (float)System.Math.Sqrt(x);
        }

        /// <summary>
        /// Returns an approximation of the inverse square root of left number.
        /// </summary>
        /// <param name="x">A number.</param>
        /// <returns>An approximation of the inverse square root of the specified number, with an upper error bound of 0.001</returns>
        /// <remarks>
        /// This is an improved implementation of the the method known as Carmack's inverse square root
        /// which is found in the Quake III source code. This implementation comes from
        /// http://www.codemaestro.com/reviews/review00000105.html. For the history of this method, see
        /// http://www.beyond3d.com/content/articles/8/
        /// </remarks>
        public static float InverseSqrtFast(float x)
        {
            unsafe
            {
                float xhalf = 0.5f * x;
                int i = *(int*)&x;              // Read bits as integer.
                i = 0x5f375a86 - (i >> 1);      // Make an initial guess for Newton-Raphson approximation
                x = *(float*)&i;                // Convert bits back to float
                x = x * (1.5f - xhalf * x * x); // Perform left single Newton-Raphson step.
                return x;
            }
        }

        /// <summary>
        /// Returns an approximation of the inverse square root of left number.
        /// </summary>
        /// <param name="x">A number.</param>
        /// <returns>An approximation of the inverse square root of the specified number, with an upper error bound of 0.001</returns>
        /// <remarks>
        /// This is an improved implementation of the the method known as Carmack's inverse square root
        /// which is found in the Quake III source code. This implementation comes from
        /// http://www.codemaestro.com/reviews/review00000105.html. For the history of this method, see
        /// http://www.beyond3d.com/content/articles/8/. The 64 bit implementation uses a different magic
        /// demon number found at https://en.wikipedia.org/wiki/Fast_inverse_square_root#History_and_investigation
        /// </remarks>
        public static double InverseSqrtFast(double x)
        {
            unsafe
            {
                double xhalf = 0.5 * x;
                long i = *(long*)&x;              // Read bits as long integer.
                i = 0x5fe6eb50c7b537a9 - (i >> 1);    // what the fuck?
                x = *(double*)&i;               // Convert bits back to double
                x = x * (1.5f - xhalf * x * x); // Perform left single Newton-Raphson step.
                return x;
            }
        }

        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        /// <param name="degrees">An angle in degrees</param>
        /// <returns>The angle expressed in radians</returns>
        public static float Deg2Rad(float degrees)
        {
            const float degToRad = Pi / 180.0f;
            return degrees * degToRad;
        }

        /// <summary>
        /// Convert radians to degrees
        /// </summary>
        /// <param name="radians">An angle in radians</param>
        /// <returns>The angle expressed in degrees</returns>
        public static float Rad2Deg(float radians)
        {
            const float radToDeg = 180.0f / Pi;
            return radians * radToDeg;
        }

        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        /// <param name="degrees">An angle in degrees</param>
        /// <returns>The angle expressed in radians</returns>
        public static double Deg2Rad(double degrees)
        {
            const double degToRad = Pi / 180.0;
            return degrees * degToRad;
        }

        /// <summary>
        /// Convert radians to degrees
        /// </summary>
        /// <param name="radians">An angle in radians</param>
        /// <returns>The angle expressed in degrees</returns>
        public static double Rad2Deg(double radians)
        {
            const double radToDeg = 180.0 / Pi;
            return radians * radToDeg;
        }

        /// <summary>
        /// Clamps a number between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>min, if n is lower than min; max, if n is higher than max; n otherwise.</returns>
        public static int Clamp(int n, int min, int max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        /// <summary>
        /// Clamps a number between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>min, if n is lower than min; max, if n is higher than max; n otherwise.</returns>
        public static float Clamp(float n, float min, float max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        /// <summary>
        /// Clamps a number between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>min, if n is lower than min; max, if n is higher than max; n otherwise.</returns>
        public static double Clamp(double n, double min, double max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        public static bool Between(int n, int min, int max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        public static bool Between(float n, float min, float max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        public static bool Between(double n, double min, double max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        public static bool Between(byte n, byte min, byte max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        [CLSCompliant(false)]
        public static bool Between(sbyte n, sbyte min, sbyte max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        [CLSCompliant(false)]
        public static bool Between(uint n, uint min, uint max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        public static bool Between(short n, short min, short max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        [CLSCompliant(false)]
        public static bool Between(ushort n, ushort min, ushort max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        public static bool Between(long n, long min, long max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        [CLSCompliant(false)]
        public static bool Between(ulong n, ulong min, ulong max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Checks if a number is between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>true, if n is between min and max.</returns>
        public static bool Between(decimal n, decimal min, decimal max)
        {
            if (min > max) Swap(ref min, ref max);
            return n >= min && n <= max;
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static byte Min(params byte[] array)
        {
            byte Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static sbyte Min(params sbyte[] array)
        {
            sbyte Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static int Min(params int[] array)
        {
            int Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static uint Min(params uint[] array)
        {
            uint Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static long Min(params long[] array)
        {
            long Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static ulong Min(params ulong[] array)
        {
            ulong Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static short Min(params short[] array)
        {
            short Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static ushort Min(params ushort[] array)
        {
            ushort Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static decimal Min(params decimal[] array)
        {
            decimal Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static float Min(params float[] array)
        {
            float Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the minimal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static double Min(params double[] array)
        {
            double Minimum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Minimum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] < Minimum)
                    {
                        Minimum = array[counter];
                    }
                }

                return Minimum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static byte Max(params byte[] array)
        {
            byte Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static sbyte Max(params sbyte[] array)
        {
            sbyte Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static int Max(params int[] array)
        {
            int Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static uint Max(params uint[] array)
        {
            uint Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static long Max(params long[] array)
        {
            long Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static ulong Max(params ulong[] array)
        {
            ulong Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static short Max(params short[] array)
        {
            short Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        [CLSCompliant(false)]
        public static ushort Max(params ushort[] array)
        {
            ushort Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static float Max(params float[] array)
        {
            float Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static double Max(params double[] array)
        {
            double Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Returns the maximal value of an array.
        /// </summary>
        /// <param name="array">The array of values</param>
        public static decimal Max(params decimal[] array)
        {
            decimal Maximum;

            if (array.Length == 0)
            {
                throw new ArgumentException("The given array is empty", "array");
            }
            else
            {
                Maximum = array[0];

                for (int counter = 1; counter < array.Length; counter++)
                {
                    if (array[counter] > Maximum)
                    {
                        Maximum = array[counter];
                    }
                }

                return Maximum;
            }
        }

        /// <summary>
        /// Swaps values of two <see cref="System.Byte"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        public static void Swap(ref byte val1, ref byte val2)
        {
            byte dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.SByte"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        [CLSCompliant(false)]
        public static void Swap(ref sbyte val1, ref sbyte val2)
        {
            sbyte dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.Int16"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        public static void Swap(ref short val1, ref short val2)
        {
            short dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.UInt16"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        [CLSCompliant(false)]
        public static void Swap(ref ushort val1, ref ushort val2)
        {
            ushort dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.Int32"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        public static void Swap(ref int val1, ref int val2)
        {
            int dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.UInt32"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        [CLSCompliant(false)]
        public static void Swap(ref uint val1, ref uint val2)
        {
            uint dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.Int64"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        public static void Swap(ref long val1, ref long val2)
        {
            long dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.UInt64"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        [CLSCompliant(false)]
        public static void Swap(ref ulong val1, ref ulong val2)
        {
            ulong dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.Single"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        public static void Swap(ref float val1, ref float val2)
        {
            float dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.Double"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        public static void Swap(ref double val1, ref double val2)
        {
            double dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Swaps values of two <see cref="System.Decimal"/> variables.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        public static void Swap(ref decimal val1, ref decimal val2)
        {
            decimal dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        /// <summary>
        /// Reduces the angle into a range from -Pi to Pi.
        /// </summary>
        /// <param name="angle">Angle to wrap.</param>
        /// <returns>Wrapped angle.</returns>
        public static float WrapAngle(float angle)
        {
            angle = (float)Math.IEEERemainder(angle, TwoPi);
            if (angle < -Pi)
            {
                angle += TwoPi;
                return angle;
            }
            if (angle >= Pi)
            {
                angle -= TwoPi;
            }
            return angle;
        }

        public static byte HighNibble(byte value)
        {
            return (byte)(value >> 4);
        }

        public static byte LowNibble(byte value)
        {
            return (byte)(value & 0x0F);
        }

        [CLSCompliant(false)]
        public static byte HighNibble(ushort value)
        {
            return (byte)(value >> 8);
        }

        [CLSCompliant(false)]
        public static byte LowNibble(ushort value)
        {
            return (byte)(value & 0xFF);
        }

        [CLSCompliant(false)]
        public static ushort HighNibble(uint value)
        {
            return (ushort)(value >> 16);
        }

        [CLSCompliant(false)]
        public static ushort LowNibble(uint value)
        {
            return (ushort)(value & 0xFFFF);
        }

        [CLSCompliant(false)]
        public static uint HighNibble(ulong value)
        {
            return (uint)(value >> 32);
        }

        [CLSCompliant(false)]
        public static uint LowNibble(ulong value)
        {
            return (uint)(value & 0xFFFFFFFF);
        }
    }
}