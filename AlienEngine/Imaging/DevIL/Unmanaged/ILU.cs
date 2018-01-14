/*
* Copyright (c) 2012 Nicholas Woodfield
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;
using System.Runtime.InteropServices;
using AlienEngine.Imaging;

namespace AlienEngine.Core.Imaging.DevIL.Unmanaged
{
    internal static class ILU
    {
        #if LINUX
        private const string Library = "libILU.so";
        #else
        private const String Library = "ILU.dll";
        #endif
        private static bool _init = false;

        public static bool IsInitialized
        {
            get { return _init; }
        }

        #region ILU Methods

        public static void Initialize()
        {
            if (!_init)
            {
                iluInit();
                _init = true;
            }
        }

        [DllImport(Library, EntryPoint = "iluAlienify", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Alienify();

        public static bool BlurAverage(int iterations)
        {
            return iluBlurAverage((uint) iterations);
        }

        public static bool BlurGaussian(int iterations)
        {
            return iluBlurGaussian((uint) iterations);
        }

        public static bool CompareImages(int otherImageID)
        {
            return iluCompareImages((uint) otherImageID);
        }

        public static bool Crop(int xOffset, int yOffset, int zOffset, int width, int height, int depth)
        {
            return iluCrop((uint) xOffset, (uint) yOffset, (uint) zOffset, (uint) width, (uint) height, (uint) depth);
        }

        [DllImport(Library, EntryPoint = "iluContrast", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Contrast(float contrast);

        [DllImport(Library, EntryPoint = "iluEdgeDetectE", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool EdgeDetectE();

        [DllImport(Library, EntryPoint = "iluEdgeDetectP", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool EdgeDetectP();

        [DllImport(Library, EntryPoint = "iluEdgeDetectS", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool EdgeDetectS();

        [DllImport(Library, EntryPoint = "iluEmboss", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Emboss();

        public static bool EnlargeCanvas(int width, int height, int depth)
        {
            return iluEnlargeCanvas((uint) width, (uint) height, (uint) depth);
        }

        public static bool EnlargeImage(int xDimension, int yDimension, int zDimension)
        {
            return iluEnlargeImage((uint) xDimension, (uint) yDimension, (uint) zDimension);
        }

        [DllImport(Library, EntryPoint = "iluEqualize", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Equalize();

        public static String GetErrorString(ErrorType error)
        {
            //DevIL re-uses its error strings
            return Marshal.PtrToStringAnsi(iluGetErrorString((uint) error));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix">3x3 Matrix (row major)</param>
        /// <param name="scale"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        [DllImport(Library, EntryPoint = "iluConvolution", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Convolution(int[] matrix, int scale, int bias);

        [DllImport(Library, EntryPoint = "iluFlipImage", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FlipImage();

        [DllImport(Library, EntryPoint = "iluBuildMipmaps", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool BuildMipMaps();

        public static int ColorsUsed()
        {
            return (int) iluColorsUsed();
        }

        public static bool Scale(int width, int height, int depth)
        {
            return iluScale((uint) width, (uint) height, (uint) depth);
        }

        [DllImport(Library, EntryPoint = "iluGammaCorrect", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GammaCorrect(float gamma);

        [DllImport(Library, EntryPoint = "iluInvertAlpha", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool InvertAlpha();

        [DllImport(Library, EntryPoint = "iluMirror", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Mirror();

        [DllImport(Library, EntryPoint = "iluNegative", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Negative();

        [DllImport(Library, EntryPoint = "iluNoisify", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluNoisify(float tolerance);

        public static bool Noisify(float tolerance)
        {
            return iluNoisify(MathHelper.Clamp(tolerance, 0f, 1f));
        }

        public static bool Pixelize(int pixelSize)
        {
            return iluPixelize((uint) pixelSize);
        }

        [DllImport(Library, EntryPoint = "iluReplaceColour", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool ReplaceColor(byte red, byte green, byte blue, float tolerance);

        [DllImport(Library, EntryPoint = "iluRotate", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Rotate(float angle);

        [DllImport(Library, EntryPoint = "iluRotate3D", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Rotate3D(float x, float y, float z, float angle);

        [DllImport(Library, EntryPoint = "iluSaturate1f", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Saturate(float saturation);

        [DllImport(Library, EntryPoint = "iluSaturate4f", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Saturate(float red, float green, float blue, float saturation);

        [DllImport(Library, EntryPoint = "iluScaleAlpha", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool ScaleAlpha(float scale);

        [DllImport(Library, EntryPoint = "iluScaleColours", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool ScaleColors(float red, float green, float blue);

        [DllImport(Library, EntryPoint = "iluSetLanguage", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluSetLanguage(uint language);

        public static bool SetLanguage(Language lang)
        {
            return iluSetLanguage((uint) lang);
        }

        public static bool Sharpen(float factor, int iterations)
        {
            return iluSharpen(factor, (uint) iterations);
        }

        [DllImport(Library, EntryPoint = "iluSwapColours", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool SwapColors();

        [DllImport(Library, EntryPoint = "iluWave", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool Wave(float angle);

        public static String GetVendorName()
        {
            return Marshal.PtrToStringAnsi(iluGetString(ILDefines.IL_VENDOR));
        }

        public static String GetVersionNumber()
        {
            return Marshal.PtrToStringAnsi(iluGetString(ILDefines.IL_VERSION_NUM));
        }

        public static void SetImagePlacement(Placement placement)
        {
            iluImageParameter(ILUDefines.ILU_PLACEMENT, (uint) placement);
        }

        public static Placement GetImagePlacement()
        {
            return (Placement) iluGetInteger(ILUDefines.ILU_PLACEMENT);
        }

        public static void SetSamplingFilter(SamplingFilter filter)
        {
            iluImageParameter(ILUDefines.ILU_FILTER, (uint) filter);
        }

        public static SamplingFilter GetSamplingFilter()
        {
            return (SamplingFilter) iluGetInteger(ILUDefines.ILU_FILTER);
        }

        public static void Region(PointF[] points)
        {
            if (points == null || points.Length < 3)
            {
                return;
            }
            iluRegionf(points, (uint) points.Length);
        }

        public static void Region(PointI[] points)
        {
            if (points == null || points.Length < 3)
            {
                return;
            }
            iluRegioni(points, (uint) points.Length);
        }

        #endregion

        #region ILU Native Methods

        [DllImport(Library, EntryPoint = "iluInit", CallingConvention = CallingConvention.StdCall)]
        private static extern void iluInit();

        [DllImport(Library, EntryPoint = "iluBlurAvg", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluBlurAverage(uint iterations);

        [DllImport(Library, EntryPoint = "iluBlurGaussian", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluBlurGaussian(uint iterations);

        [DllImport(Library, EntryPoint = "iluCompareImage", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluCompareImages(uint otherImage);

        [DllImport(Library, EntryPoint = "iluCrop", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluCrop(uint offsetX, uint offsetY, uint offsetZ, uint width, uint height,
            uint depth);

        [DllImport(Library, EntryPoint = "iluEnlargeCanvas", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluEnlargeCanvas(uint width, uint height, uint depth);

        [DllImport(Library, EntryPoint = "iluEnlargeImage", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluEnlargeImage(uint xDim, uint yDim, uint zDim);

        [DllImport(Library, EntryPoint = "iluErrorString", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr iluGetErrorString(uint error);

        [DllImport(Library, EntryPoint = "iluColoursUsed", CallingConvention = CallingConvention.StdCall)]
        private static extern uint iluColorsUsed();

        [DllImport(Library, EntryPoint = "iluScale", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluScale(uint width, uint height, uint depth);

        [DllImport(Library, EntryPoint = "iluPixelize", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluPixelize(uint pixelSize);

        [DllImport(Library, EntryPoint = "iluSharpen", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool iluSharpen(float factor, uint iterations);

        [DllImport(Library, EntryPoint = "iluGetString", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr iluGetString(uint name);

        [DllImport(Library, EntryPoint = "iluImageParameter", CallingConvention = CallingConvention.StdCall)]
        private static extern void iluImageParameter(uint pName, uint param);

        [DllImport(Library, EntryPoint = "iluGetInteger", CallingConvention = CallingConvention.StdCall)]
        private static extern int iluGetInteger(uint mode);

        [DllImport(Library, EntryPoint = "iluRegionfv", CallingConvention = CallingConvention.StdCall)]
        private static extern void iluRegionf(PointF[] points, uint num);

        [DllImport(Library, EntryPoint = "iluRegioniv", CallingConvention = CallingConvention.StdCall)]
        private static extern void iluRegioni(PointI[] points, uint num);

        #endregion
    }
}