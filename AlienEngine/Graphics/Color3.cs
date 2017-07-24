using System;
using System.Drawing;

namespace AlienEngine
{
    /// <summary>
    /// Represents a color with 3 floating-point components (R, G, B).
    /// </summary>
    [Serializable]
    public struct Color3 : IEquatable<Color3>
    {
        #region Fields

        /// <summary>
        /// The red component of this Color3 structure.
        /// </summary>
        public float R;

        /// <summary>
        /// The green component of this Color3 structure.
        /// </summary>
        public float G;

        /// <summary>
        /// The blue component of this Color3 structure.
        /// </summary>
        public float B;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new Color3 structure from the specified components.
        /// </summary>
        /// <param name="r">The red component of the new Color3 structure.</param>
        /// <param name="g">The green component of the new Color3 structure.</param>
        /// <param name="b">The blue component of the new Color3 structure.</param>
        public Color3(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Constructs a new Color3 structure from the specified components.
        /// </summary>
        /// <param name="r">The red component of the new Color3 structure.</param>
        /// <param name="g">The green component of the new Color3 structure.</param>
        /// <param name="b">The blue component of the new Color3 structure.</param>
        public Color3(byte r, byte g, byte b)
        {
            R = r / (float)Byte.MaxValue;
            G = g / (float)Byte.MaxValue;
            B = b / (float)Byte.MaxValue;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Converts this color to an integer representation with 8 bits per channel.
        /// </summary>
        /// <returns>A <see cref="System.Int32"/> that represents this instance.</returns>
        /// <remarks>This method is intended only for compatibility with System.Drawing. It compresses the color into 8 bits per channel, which means color information is lost.</remarks>
        public int ToArgb()
        {
            uint value =
                (uint)(Byte.MaxValue) << 24 |
                (uint)(R * Byte.MaxValue) << 16 |
                (uint)(G * Byte.MaxValue) << 8 |
                (uint)(B * Byte.MaxValue);

            return unchecked((int)value);
        }

        /// <summary>
        /// Compares the specified Color3 structures for equality.
        /// </summary>
        /// <param name="left">The left-hand side of the comparison.</param>
        /// <param name="right">The right-hand side of the comparison.</param>
        /// <returns>True if left is equal to right; false otherwise.</returns>
        public static bool operator ==(Color3 left, Color3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares the specified Color3 structures for inequality.
        /// </summary>
        /// <param name="left">The left-hand side of the comparison.</param>
        /// <param name="right">The right-hand side of the comparison.</param>
        /// <returns>True if left is not equal to right; false otherwise.</returns>
        public static bool operator !=(Color3 left, Color3 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts the specified System.Drawing.Color to a Color3 structure.
        /// </summary>
        /// <param name="color">The System.Drawing.Color to convert.</param>
        /// <returns>A new Color3 structure containing the converted components.</returns>
        public static implicit operator Color3(Color color)
        {
            return new Color3(color.R, color.G, color.B);
        }

        /// <summary>
        /// Converts the specified Color3 to a System.Drawing.Color structure.
        /// </summary>
        /// <param name="color">The Color3 to convert.</param>
        /// <returns>A new System.Drawing.Color structure containing the converted components.</returns>
        public static explicit operator Color(Color3 color)
        {
            return Color.FromArgb(
                (int)(Byte.MaxValue),
                (int)(color.R * Byte.MaxValue),
                (int)(color.G * Byte.MaxValue),
                (int)(color.B * Byte.MaxValue));
        }

        /// <summary>
        /// Compares whether this Color3 structure is equal to the specified object.
        /// </summary>
        /// <param name="obj">An object to compare to.</param>
        /// <returns>True obj is a Color3 structure with the same components as this Color3; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Color3))
                return false;

            return Equals((Color3)obj);
        }

        /// <summary>
        /// Calculates the hash code for this Color3 structure.
        /// </summary>
        /// <returns>A System.Int32 containing the hashcode of this Color3 structure.</returns>
        public override int GetHashCode()
        {
            return ToArgb();
        }

        /// <summary>
        /// Creates a System.String that describes this Color3 structure.
        /// </summary>
        /// <returns>A System.String that describes this Color3 structure.</returns>
        public override string ToString()
        {
            return String.Format("{{(R, G, B) = ({0}, {1}, {2})}}", R.ToString(), G.ToString(), B.ToString());
        }

        #region System colors

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (240, 248, 255, 255).
        /// </summary>
        public static Color3 AliceBlue { get { return new Color3(240, 248, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (250, 235, 215, 255).
        /// </summary>
        public static Color3 AntiqueWhite { get { return new Color3(250, 235, 215); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 255, 255, 255).
        /// </summary>
        public static Color3 Aqua { get { return new Color3(0, 255, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (127, 255, 212, 255).
        /// </summary>
        public static Color3 Aquamarine { get { return new Color3(127, 255, 212); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (240, 255, 255, 255).
        /// </summary>
        public static Color3 Azure { get { return new Color3(240, 255, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (245, 245, 220, 255).
        /// </summary>
        public static Color3 Beige { get { return new Color3(245, 245, 220); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 228, 196, 255).
        /// </summary>
        public static Color3 Bisque { get { return new Color3(255, 228, 196); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 0, 0, 255).
        /// </summary>
        public static Color3 Black { get { return new Color3(0, 0, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 235, 205, 255).
        /// </summary>
        public static Color3 BlanchedAlmond { get { return new Color3(255, 235, 205); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 0, 255, 255).
        /// </summary>
        public static Color3 Blue { get { return new Color3(0, 0, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (138, 43, 226, 255).
        /// </summary>
        public static Color3 BlueViolet { get { return new Color3(138, 43, 226); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (165, 42, 42, 255).
        /// </summary>
        public static Color3 Brown { get { return new Color3(165, 42, 42); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (222, 184, 135, 255).
        /// </summary>
        public static Color3 BurlyWood { get { return new Color3(222, 184, 135); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (95, 158, 160, 255).
        /// </summary>
        public static Color3 CadetBlue { get { return new Color3(95, 158, 160); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (127, 255, 0, 255).
        /// </summary>
        public static Color3 Chartreuse { get { return new Color3(127, 255, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (210, 105, 30, 255).
        /// </summary>
        public static Color3 Chocolate { get { return new Color3(210, 105, 30); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 127, 80, 255).
        /// </summary>
        public static Color3 Coral { get { return new Color3(255, 127, 80); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (100, 149, 237, 255).
        /// </summary>
        public static Color3 CornflowerBlue { get { return new Color3(100, 149, 237); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 248, 220, 255).
        /// </summary>
        public static Color3 Cornsilk { get { return new Color3(255, 248, 220); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (220, 20, 60, 255).
        /// </summary>
        public static Color3 Crimson { get { return new Color3(220, 20, 60); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 255, 255, 255).
        /// </summary>
        public static Color3 Cyan { get { return new Color3(0, 255, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 0, 139, 255).
        /// </summary>
        public static Color3 DarkBlue { get { return new Color3(0, 0, 139); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 139, 139, 255).
        /// </summary>
        public static Color3 DarkCyan { get { return new Color3(0, 139, 139); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (184, 134, 11, 255).
        /// </summary>
        public static Color3 DarkGoldenrod { get { return new Color3(184, 134, 11); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (169, 169, 169, 255).
        /// </summary>
        public static Color3 DarkGray { get { return new Color3(169, 169, 169); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 100, 0, 255).
        /// </summary>
        public static Color3 DarkGreen { get { return new Color3(0, 100, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (189, 183, 107, 255).
        /// </summary>
        public static Color3 DarkKhaki { get { return new Color3(189, 183, 107); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (139, 0, 139, 255).
        /// </summary>
        public static Color3 DarkMagenta { get { return new Color3(139, 0, 139); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (85, 107, 47, 255).
        /// </summary>
        public static Color3 DarkOliveGreen { get { return new Color3(85, 107, 47); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 140, 0, 255).
        /// </summary>
        public static Color3 DarkOrange { get { return new Color3(255, 140, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (153, 50, 204, 255).
        /// </summary>
        public static Color3 DarkOrchid { get { return new Color3(153, 50, 204); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (139, 0, 0, 255).
        /// </summary>
        public static Color3 DarkRed { get { return new Color3(139, 0, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (233, 150, 122, 255).
        /// </summary>
        public static Color3 DarkSalmon { get { return new Color3(233, 150, 122); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (143, 188, 139, 255).
        /// </summary>
        public static Color3 DarkSeaGreen { get { return new Color3(143, 188, 139); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (72, 61, 139, 255).
        /// </summary>
        public static Color3 DarkSlateBlue { get { return new Color3(72, 61, 139); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (47, 79, 79, 255).
        /// </summary>
        public static Color3 DarkSlateGray { get { return new Color3(47, 79, 79); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 206, 209, 255).
        /// </summary>
        public static Color3 DarkTurquoise { get { return new Color3(0, 206, 209); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (148, 0, 211, 255).
        /// </summary>
        public static Color3 DarkViolet { get { return new Color3(148, 0, 211); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 20, 147, 255).
        /// </summary>
        public static Color3 DeepPink { get { return new Color3(255, 20, 147); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 191, 255, 255).
        /// </summary>
        public static Color3 DeepSkyBlue { get { return new Color3(0, 191, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (105, 105, 105, 255).
        /// </summary>
        public static Color3 DimGray { get { return new Color3(105, 105, 105); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (30, 144, 255, 255).
        /// </summary>
        public static Color3 DodgerBlue { get { return new Color3(30, 144, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (178, 34, 34, 255).
        /// </summary>
        public static Color3 Firebrick { get { return new Color3(178, 34, 34); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 250, 240, 255).
        /// </summary>
        public static Color3 FloralWhite { get { return new Color3(255, 250, 240); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (34, 139, 34, 255).
        /// </summary>
        public static Color3 ForestGreen { get { return new Color3(34, 139, 34); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 0, 255, 255).
        /// </summary>
        public static Color3 Fuchsia { get { return new Color3(255, 0, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (220, 220, 220, 255).
        /// </summary>
        public static Color3 Gainsboro { get { return new Color3(220, 220, 220); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (248, 248, 255, 255).
        /// </summary>
        public static Color3 GhostWhite { get { return new Color3(248, 248, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 215, 0, 255).
        /// </summary>
        public static Color3 Gold { get { return new Color3(255, 215, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (218, 165, 32, 255).
        /// </summary>
        public static Color3 Goldenrod { get { return new Color3(218, 165, 32); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (128, 128, 128, 255).
        /// </summary>
        public static Color3 Gray { get { return new Color3(128, 128, 128); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 128, 0, 255).
        /// </summary>
        public static Color3 Green { get { return new Color3(0, 128, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (173, 255, 47, 255).
        /// </summary>
        public static Color3 GreenYellow { get { return new Color3(173, 255, 47); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (240, 255, 240, 255).
        /// </summary>
        public static Color3 Honeydew { get { return new Color3(240, 255, 240); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 105, 180, 255).
        /// </summary>
        public static Color3 HotPink { get { return new Color3(255, 105, 180); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (205, 92, 92, 255).
        /// </summary>
        public static Color3 IndianRed { get { return new Color3(205, 92, 92); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (75, 0, 130, 255).
        /// </summary>
        public static Color3 Indigo { get { return new Color3(75, 0, 130); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 255, 240, 255).
        /// </summary>
        public static Color3 Ivory { get { return new Color3(255, 255, 240); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (240, 230, 140, 255).
        /// </summary>
        public static Color3 Khaki { get { return new Color3(240, 230, 140); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (230, 230, 250, 255).
        /// </summary>
        public static Color3 Lavender { get { return new Color3(230, 230, 250); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 240, 245, 255).
        /// </summary>
        public static Color3 LavenderBlush { get { return new Color3(255, 240, 245); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (124, 252, 0, 255).
        /// </summary>
        public static Color3 LawnGreen { get { return new Color3(124, 252, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 250, 205, 255).
        /// </summary>
        public static Color3 LemonChiffon { get { return new Color3(255, 250, 205); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (173, 216, 230, 255).
        /// </summary>
        public static Color3 LightBlue { get { return new Color3(173, 216, 230); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (240, 128, 128, 255).
        /// </summary>
        public static Color3 LightCoral { get { return new Color3(240, 128, 128); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (224, 255, 255, 255).
        /// </summary>
        public static Color3 LightCyan { get { return new Color3(224, 255, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (250, 250, 210, 255).
        /// </summary>
        public static Color3 LightGoldenrodYellow { get { return new Color3(250, 250, 210); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (144, 238, 144, 255).
        /// </summary>
        public static Color3 LightGreen { get { return new Color3(144, 238, 144); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (211, 211, 211, 255).
        /// </summary>
        public static Color3 LightGray { get { return new Color3(211, 211, 211); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 182, 193, 255).
        /// </summary>
        public static Color3 LightPink { get { return new Color3(255, 182, 193); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 160, 122, 255).
        /// </summary>
        public static Color3 LightSalmon { get { return new Color3(255, 160, 122); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (32, 178, 170, 255).
        /// </summary>
        public static Color3 LightSeaGreen { get { return new Color3(32, 178, 170); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (135, 206, 250, 255).
        /// </summary>
        public static Color3 LightSkyBlue { get { return new Color3(135, 206, 250); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (119, 136, 153, 255).
        /// </summary>
        public static Color3 LightSlateGray { get { return new Color3(119, 136, 153); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (176, 196, 222, 255).
        /// </summary>
        public static Color3 LightSteelBlue { get { return new Color3(176, 196, 222); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 255, 224, 255).
        /// </summary>
        public static Color3 LightYellow { get { return new Color3(255, 255, 224); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 255, 0, 255).
        /// </summary>
        public static Color3 Lime { get { return new Color3(0, 255, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (50, 205, 50, 255).
        /// </summary>
        public static Color3 LimeGreen { get { return new Color3(50, 205, 50); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (250, 240, 230, 255).
        /// </summary>
        public static Color3 Linen { get { return new Color3(250, 240, 230); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 0, 255, 255).
        /// </summary>
        public static Color3 Magenta { get { return new Color3(255, 0, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (128, 0, 0, 255).
        /// </summary>
        public static Color3 Maroon { get { return new Color3(128, 0, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (102, 205, 170, 255).
        /// </summary>
        public static Color3 MediumAquamarine { get { return new Color3(102, 205, 170); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 0, 205, 255).
        /// </summary>
        public static Color3 MediumBlue { get { return new Color3(0, 0, 205); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (186, 85, 211, 255).
        /// </summary>
        public static Color3 MediumOrchid { get { return new Color3(186, 85, 211); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (147, 112, 219, 255).
        /// </summary>
        public static Color3 MediumPurple { get { return new Color3(147, 112, 219); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (60, 179, 113, 255).
        /// </summary>
        public static Color3 MediumSeaGreen { get { return new Color3(60, 179, 113); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (123, 104, 238, 255).
        /// </summary>
        public static Color3 MediumSlateBlue { get { return new Color3(123, 104, 238); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 250, 154, 255).
        /// </summary>
        public static Color3 MediumSpringGreen { get { return new Color3(0, 250, 154); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (72, 209, 204, 255).
        /// </summary>
        public static Color3 MediumTurquoise { get { return new Color3(72, 209, 204); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (199, 21, 133, 255).
        /// </summary>
        public static Color3 MediumVioletRed { get { return new Color3(199, 21, 133); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (25, 25, 112, 255).
        /// </summary>
        public static Color3 MidnightBlue { get { return new Color3(25, 25, 112); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (245, 255, 250, 255).
        /// </summary>
        public static Color3 MintCream { get { return new Color3(245, 255, 250); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 228, 225, 255).
        /// </summary>
        public static Color3 MistyRose { get { return new Color3(255, 228, 225); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 228, 181, 255).
        /// </summary>
        public static Color3 Moccasin { get { return new Color3(255, 228, 181); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 222, 173, 255).
        /// </summary>
        public static Color3 NavajoWhite { get { return new Color3(255, 222, 173); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 0, 128, 255).
        /// </summary>
        public static Color3 Navy { get { return new Color3(0, 0, 128); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (253, 245, 230, 255).
        /// </summary>
        public static Color3 OldLace { get { return new Color3(253, 245, 230); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (128, 128, 0, 255).
        /// </summary>
        public static Color3 Olive { get { return new Color3(128, 128, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (107, 142, 35, 255).
        /// </summary>
        public static Color3 OliveDrab { get { return new Color3(107, 142, 35); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 165, 0, 255).
        /// </summary>
        public static Color3 Orange { get { return new Color3(255, 165, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 69, 0, 255).
        /// </summary>
        public static Color3 OrangeRed { get { return new Color3(255, 69, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (218, 112, 214, 255).
        /// </summary>
        public static Color3 Orchid { get { return new Color3(218, 112, 214); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (238, 232, 170, 255).
        /// </summary>
        public static Color3 PaleGoldenrod { get { return new Color3(238, 232, 170); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (152, 251, 152, 255).
        /// </summary>
        public static Color3 PaleGreen { get { return new Color3(152, 251, 152); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (175, 238, 238, 255).
        /// </summary>
        public static Color3 PaleTurquoise { get { return new Color3(175, 238, 238); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (219, 112, 147, 255).
        /// </summary>
        public static Color3 PaleVioletRed { get { return new Color3(219, 112, 147); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 239, 213, 255).
        /// </summary>
        public static Color3 PapayaWhip { get { return new Color3(255, 239, 213); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 218, 185, 255).
        /// </summary>
        public static Color3 PeachPuff { get { return new Color3(255, 218, 185); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (205, 133, 63, 255).
        /// </summary>
        public static Color3 Peru { get { return new Color3(205, 133, 63); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 192, 203, 255).
        /// </summary>
        public static Color3 Pink { get { return new Color3(255, 192, 203); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (221, 160, 221, 255).
        /// </summary>
        public static Color3 Plum { get { return new Color3(221, 160, 221); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (176, 224, 230, 255).
        /// </summary>
        public static Color3 PowderBlue { get { return new Color3(176, 224, 230); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (128, 0, 128, 255).
        /// </summary>
        public static Color3 Purple { get { return new Color3(128, 0, 128); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 0, 0, 255).
        /// </summary>
        public static Color3 Red { get { return new Color3(255, 0, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (188, 143, 143, 255).
        /// </summary>
        public static Color3 RosyBrown { get { return new Color3(188, 143, 143); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (65, 105, 225, 255).
        /// </summary>
        public static Color3 RoyalBlue { get { return new Color3(65, 105, 225); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (139, 69, 19, 255).
        /// </summary>
        public static Color3 SaddleBrown { get { return new Color3(139, 69, 19); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (250, 128, 114, 255).
        /// </summary>
        public static Color3 Salmon { get { return new Color3(250, 128, 114); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (244, 164, 96, 255).
        /// </summary>
        public static Color3 SandyBrown { get { return new Color3(244, 164, 96); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (46, 139, 87, 255).
        /// </summary>
        public static Color3 SeaGreen { get { return new Color3(46, 139, 87); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 245, 238, 255).
        /// </summary>
        public static Color3 SeaShell { get { return new Color3(255, 245, 238); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (160, 82, 45, 255).
        /// </summary>
        public static Color3 Sienna { get { return new Color3(160, 82, 45); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (192, 192, 192, 255).
        /// </summary>
        public static Color3 Silver { get { return new Color3(192, 192, 192); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (135, 206, 235, 255).
        /// </summary>
        public static Color3 SkyBlue { get { return new Color3(135, 206, 235); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (106, 90, 205, 255).
        /// </summary>
        public static Color3 SlateBlue { get { return new Color3(106, 90, 205); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (112, 128, 144, 255).
        /// </summary>
        public static Color3 SlateGray { get { return new Color3(112, 128, 144); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 250, 250, 255).
        /// </summary>
        public static Color3 Snow { get { return new Color3(255, 250, 250); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 255, 127, 255).
        /// </summary>
        public static Color3 SpringGreen { get { return new Color3(0, 255, 127); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (70, 130, 180, 255).
        /// </summary>
        public static Color3 SteelBlue { get { return new Color3(70, 130, 180); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (210, 180, 140, 255).
        /// </summary>
        public static Color3 Tan { get { return new Color3(210, 180, 140); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (0, 128, 128, 255).
        /// </summary>
        public static Color3 Teal { get { return new Color3(0, 128, 128); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (216, 191, 216, 255).
        /// </summary>
        public static Color3 Thistle { get { return new Color3(216, 191, 216); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 99, 71, 255).
        /// </summary>
        public static Color3 Tomato { get { return new Color3(255, 99, 71); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (64, 224, 208, 255).
        /// </summary>
        public static Color3 Turquoise { get { return new Color3(64, 224, 208); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (238, 130, 238, 255).
        /// </summary>
        public static Color3 Violet { get { return new Color3(238, 130, 238); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (245, 222, 179, 255).
        /// </summary>
        public static Color3 Wheat { get { return new Color3(245, 222, 179); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 255, 255, 255).
        /// </summary>
        public static Color3 White { get { return new Color3(255, 255, 255); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (245, 245, 245, 255).
        /// </summary>
        public static Color3 WhiteSmoke { get { return new Color3(245, 245, 245); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (255, 255, 0, 255).
        /// </summary>
        public static Color3 Yellow { get { return new Color3(255, 255, 0); } }

        /// <summary>
        /// Gets the system color with (R, G, B, A) = (154, 205, 50, 255).
        /// </summary>
        public static Color3 YellowGreen { get { return new Color3(154, 205, 50); } }

        #endregion

        #endregion

        #region Color conversions

        #region sRGB

        /// <summary>
        /// Converts sRGB color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="srgb">
        /// Color value to convert in sRGB.
        /// </param>
        public static Color3 FromSrgb(Color3 srgb)
        {
            float r, g, b;

            if (srgb.R <= 0.04045f)
            {
                r = srgb.R / 12.92f;
            }
            else
            {
                r = (float)System.Math.Pow((srgb.R + 0.055f) / (1.0f + 0.055f), 2.4f);
            }

            if (srgb.G <= 0.04045f)
            {
                g = srgb.G / 12.92f;
            }
            else
            {
                g = (float)System.Math.Pow((srgb.G + 0.055f) / (1.0f + 0.055f), 2.4f);
            }

            if (srgb.B <= 0.04045f)
            {
                b = srgb.B / 12.92f;
            }
            else
            {
                b = (float)System.Math.Pow((srgb.B + 0.055f) / (1.0f + 0.055f), 2.4f);
            }

            return new Color3(r, g, b);
        }

        /// <summary>
        /// Converts RGB color values to sRGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        public static Color3 ToSrgb(Color3 rgb)
        {
            float r, g, b;

            if (rgb.R <= 0.0031308)
            {
                r = 12.92f * rgb.R;
            }
            else
            {
                r = (1.0f + 0.055f) * (float)System.Math.Pow(rgb.R, 1.0f / 2.4f) - 0.055f;
            }

            if (rgb.G <= 0.0031308)
            {
                g = 12.92f * rgb.G;
            }
            else
            {
                g = (1.0f + 0.055f) * (float)System.Math.Pow(rgb.G, 1.0f / 2.4f) - 0.055f;
            }

            if (rgb.B <= 0.0031308)
            {
                b = 12.92f * rgb.B;
            }
            else
            {
                b = (1.0f + 0.055f) * (float)System.Math.Pow(rgb.B, 1.0f / 2.4f) - 0.055f;
            }

            return new Color3(r, g, b);
        }

        #endregion

        #region HSL

        /// <summary>
        /// Converts HSL color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="hsl">
        /// Color value to convert in hue, saturation, lightness (HSL).
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Lightness (L), and the W element is Alpha (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        public static Color3 FromHsl(Vector3f hsl)
        {
            var hue = hsl.X * 360.0f;
            var saturation = hsl.Y;
            var lightness = hsl.Z;

            var C = (1.0f - System.Math.Abs(2.0f * lightness - 1.0f)) * saturation;

            var h = hue / 60.0f;
            var X = C * (1.0f - System.Math.Abs(h % 2.0f - 1.0f));

            float r, g, b;
            if (0.0f <= h && h < 1.0f)
            {
                r = C;
                g = X;
                b = 0.0f;
            }
            else if (1.0f <= h && h < 2.0f)
            {
                r = X;
                g = C;
                b = 0.0f;
            }
            else if (2.0f <= h && h < 3.0f)
            {
                r = 0.0f;
                g = C;
                b = X;
            }
            else if (3.0f <= h && h < 4.0f)
            {
                r = 0.0f;
                g = X;
                b = C;
            }
            else if (4.0f <= h && h < 5.0f)
            {
                r = X;
                g = 0.0f;
                b = C;
            }
            else if (5.0f <= h && h < 6.0f)
            {
                r = C;
                g = 0.0f;
                b = X;
            }
            else
            {
                r = 0.0f;
                g = 0.0f;
                b = 0.0f;
            }

            var m = lightness - (C / 2.0f);
            return new Color3(r + m, g + m, b + m);
        }

        /// <summary>
        /// Converts RGB color values to HSL color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Lightness (L), and the W element is Alpha (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        public static Vector3f ToHsl(Color3 rgb)
        {
            var M = System.Math.Max(rgb.R, System.Math.Max(rgb.G, rgb.B));
            var m = System.Math.Min(rgb.R, System.Math.Min(rgb.G, rgb.B));
            var C = M - m;

            float h = 0.0f;
            if (M == rgb.R)
            {
                h = ((rgb.G - rgb.B) / C);
            }
            else if (M == rgb.G)
            {
                h = ((rgb.B - rgb.R) / C) + 2.0f;
            }
            else if (M == rgb.B)
            {
                h = ((rgb.R - rgb.G) / C) + 4.0f;
            }

            var hue = h / 6.0f;
            if (hue < 0.0f)
            {
                hue += 1.0f;
            }

            var lightness = (M + m) / 2.0f;

            var saturation = 0.0f;
            if (0.0f != lightness && lightness != 1.0f)
            {
                saturation = C / (1.0f - System.Math.Abs(2.0f * lightness - 1.0f));
            }

            return new Vector3f(hue, saturation, lightness);
        }

        #endregion

        #region HSV

        /// <summary>
        /// Converts HSV color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="hsv">
        /// Color value to convert in hue, saturation, value (HSV).
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W element is Alpha (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        public static Color3 FromHsv(Vector3f hsv)
        {
            var hue = hsv.X * 360.0f;
            var saturation = hsv.Y;
            var value = hsv.Z;

            var C = value * saturation;

            var h = hue / 60.0f;
            var X = C * (1.0f - System.Math.Abs(h % 2.0f - 1.0f));

            float r, g, b;
            if (0.0f <= h && h < 1.0f)
            {
                r = C;
                g = X;
                b = 0.0f;
            }
            else if (1.0f <= h && h < 2.0f)
            {
                r = X;
                g = C;
                b = 0.0f;
            }
            else if (2.0f <= h && h < 3.0f)
            {
                r = 0.0f;
                g = C;
                b = X;
            }
            else if (3.0f <= h && h < 4.0f)
            {
                r = 0.0f;
                g = X;
                b = C;
            }
            else if (4.0f <= h && h < 5.0f)
            {
                r = X;
                g = 0.0f;
                b = C;
            }
            else if (5.0f <= h && h < 6.0f)
            {
                r = C;
                g = 0.0f;
                b = X;
            }
            else
            {
                r = 0.0f;
                g = 0.0f;
                b = 0.0f;
            }

            var m = value - C;
            return new Color3(r + m, g + m, b + m);
        }

        /// <summary>
        /// Converts RGB color values to HSV color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W element is Alpha (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        public static Vector3f ToHsv(Color3 rgb)
        {
            var M = System.Math.Max(rgb.R, System.Math.Max(rgb.G, rgb.B));
            var m = System.Math.Min(rgb.R, System.Math.Min(rgb.G, rgb.B));
            var C = M - m;

            float h = 0.0f;
            if (M == rgb.R)
            {
                h = ((rgb.G - rgb.B) / C) % 6.0f;
            }
            else if (M == rgb.G)
            {
                h = ((rgb.B - rgb.R) / C) + 2.0f;
            }
            else if (M == rgb.B)
            {
                h = ((rgb.R - rgb.G) / C) + 4.0f;
            }

            var hue = (h * 60.0f) / 360.0f;

            var saturation = 0.0f;
            if (0.0f != M)
            {
                saturation = C / M;
            }

            return new Vector3f(hue, saturation, M);
        }

        #endregion

        #region XYZ

        /// <summary>
        /// Converts XYZ color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="xyz">
        /// Color value to convert with the trisimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        /// <remarks>Uses the CIE XYZ colorspace.</remarks>
        public static Color3 FromXyz(Vector3f xyz)
        {
            var r = 0.41847f * xyz.X + -0.15866f * xyz.Y + -0.082835f * xyz.Z;
            var g = -0.091169f * xyz.X + 0.25243f * xyz.Y + 0.015708f * xyz.Z;
            var b = 0.00092090f * xyz.X + -0.0025498f * xyz.Y + 0.17860f * xyz.Z;
            return new Color3(r, g, b);
        }

        /// <summary>
        /// Converts RGB color values to XYZ color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value with the trisimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        /// <remarks>Uses the CIE XYZ colorspace.</remarks>
        public static Vector3f ToXyz(Color3 rgb)
        {
            var x = (0.49f * rgb.R + 0.31f * rgb.G + 0.20f * rgb.B) / 0.17697f;
            var y = (0.17697f * rgb.R + 0.81240f * rgb.G + 0.01063f * rgb.B) / 0.17697f;
            var z = (0.00f * rgb.R + 0.01f * rgb.G + 0.99f * rgb.B) / 0.17697f;
            return new Vector3f(x, y, z);
        }

        #endregion        

        #region YUV

        /// <summary>
        /// Converts YCbCr color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="ycbcr">
        /// Color value to convert in Luma-Chrominance (YCbCr) aka YUV.
        /// The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (U, -0.5 to 0.5), the Z element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element contains the Alpha (which is copied to the output's Alpha value).
        /// </param>
        /// <remarks>Converts using ITU-R BT.601/CCIR 601 W(r) = 0.299 W(b) = 0.114 U(max) = 0.436 V(max) = 0.615.</remarks>
        public static Color3 FromYcbcr(Vector3f ycbcr)
        {
            var r = 1.0f * ycbcr.X + 0.0f * ycbcr.Y + 1.402f * ycbcr.Z;
            var g = 1.0f * ycbcr.X + -0.344136f * ycbcr.Y + -0.714136f * ycbcr.Z;
            var b = 1.0f * ycbcr.X + 1.772f * ycbcr.Y + 0.0f * ycbcr.Z;
            return new Color3(r, g, b);
        }

        /// <summary>
        /// Converts RGB color values to YUV color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value in Luma-Chrominance (YCbCr) aka YUV.
        /// The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (U, -0.5 to 0.5), the Z element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element contains the Alpha (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        /// <remarks>Converts using ITU-R BT.601/CCIR 601 W(r) = 0.299 W(b) = 0.114 U(max) = 0.436 V(max) = 0.615.</remarks>
        public static Vector3f ToYcbcr(Color3 rgb)
        {
            var y = 0.299f * rgb.R + 0.587f * rgb.G + 0.114f * rgb.B;
            var u = -0.168736f * rgb.R + -0.331264f * rgb.G + 0.5f * rgb.B;
            var v = 0.5f * rgb.R + -0.418688f * rgb.G + -0.081312f * rgb.B;
            return new Vector3f(y, u, v);
        }

        #endregion

        #region HCY

        /// <summary>
        /// Converts HCY color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="hcy">
        /// Color value to convert in hue, chroma, luminance (HCY).
        /// The X element is Hue (H), the Y element is Chroma (C), the Z element is luminance (Y), and the W element is Alpha (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        public static Color3 FromHcy(Vector3f hcy)
        {
            var hue = hcy.X * 360.0f;
            var C = hcy.Y;
            var luminance = hcy.Z;

            var h = hue / 60.0f;
            var X = C * (1.0f - System.Math.Abs(h % 2.0f - 1.0f));

            float r, g, b;
            if (0.0f <= h && h < 1.0f)
            {
                r = C;
                g = X;
                b = 0.0f;
            }
            else if (1.0f <= h && h < 2.0f)
            {
                r = X;
                g = C;
                b = 0.0f;
            }
            else if (2.0f <= h && h < 3.0f)
            {
                r = 0.0f;
                g = C;
                b = X;
            }
            else if (3.0f <= h && h < 4.0f)
            {
                r = 0.0f;
                g = X;
                b = C;
            }
            else if (4.0f <= h && h < 5.0f)
            {
                r = X;
                g = 0.0f;
                b = C;
            }
            else if (5.0f <= h && h < 6.0f)
            {
                r = C;
                g = 0.0f;
                b = X;
            }
            else
            {
                r = 0.0f;
                g = 0.0f;
                b = 0.0f;
            }

            var m = luminance - (0.30f * r + 0.59f * g + 0.11f * b);
            return new Color3(r + m, g + m, b + m);
        }

        /// <summary>
        /// Converts RGB color values to HCY color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// The X element is Hue (H), the Y element is Chroma (C), the Z element is luminance (Y), and the W element is Alpha (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        public static Vector3f ToHcy(Color3 rgb)
        {
            var M = System.Math.Max(rgb.R, System.Math.Max(rgb.G, rgb.B));
            var m = System.Math.Min(rgb.R, System.Math.Min(rgb.G, rgb.B));
            var C = M - m;

            float h = 0.0f;
            if (M == rgb.R)
            {
                h = ((rgb.G - rgb.B) / C) % 6.0f;
            }
            else if (M == rgb.G)
            {
                h = ((rgb.B - rgb.R) / C) + 2.0f;
            }
            else if (M == rgb.B)
            {
                h = ((rgb.R - rgb.G) / C) + 4.0f;
            }

            var hue = (h * 60.0f) / 360.0f;

            var luminance = 0.30f * rgb.R + 0.59f * rgb.G + 0.11f * rgb.B;

            return new Vector3f(hue, C, luminance);
        }

        #endregion

        #endregion

        #region IEquatable<Color3> Members

        /// <summary>
        /// Compares whether this Color3 structure is equal to the specified Color3.
        /// </summary>
        /// <param name="other">The Color3 structure to compare to.</param>
        /// <returns>True if both Color3 structures contain the same components; false otherwise.</returns>
        public bool Equals(Color3 other)
        {
            return
                this.R == other.R &&
                this.G == other.G &&
                this.B == other.B;
        }

        #endregion
    }
}
