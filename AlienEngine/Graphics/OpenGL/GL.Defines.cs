﻿#region Copyright and License
// Copyright (c) 2013-2014 The Khronos Group Inc.
// Copyright (c) of C# port 2014 by Shinta <shintadono@gooemail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and/or associated documentation files (the
// "Materials"), to deal in the Materials without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Materials, and to
// permit persons to whom the Materials are furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Materials.
//
// THE MATERIALS ARE PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// MATERIALS OR THE USE OR OTHER DEALINGS IN THE MATERIALS.
#endregion

using System;

namespace AlienEngine.Core.Graphics.OpenGL
{
    public static partial class GL
    {
        #if LINUX
        internal const string DLLName = "libGL.so";
        #else
        internal const string DLLName = "opengl32.dll";
        #endif

        const string platformErrorString = "Value to big for 32bit platform.";

        static string PlatformErrorString { get { return platformErrorString; } }

        const string platformWrongTypeErrorString = "Platform is 64bit and value need 64bit to store, but argument is only 32bit.";

        static string PlatformWrongTypeErrorString { get { return platformWrongTypeErrorString; } }

        const string platformArrayErrorString = "A value in the array to big for 32bit platform.";

        static string PlatformArrayErrorString { get { return platformErrorString; } }

        public const string MAX_NUMBER_OF_LIGHTS = "MAX_NUMBER_OF_LIGHTS";

        /// <summary>
        /// Returned by <see cref="GL.GetProgramResourceIndex"/> on error.
        /// And outputted by <see cref="GL.GetUniformSubroutineuiv"/> , if location is unused.
        /// </summary>
        [CLSCompliant(false)]
        public const uint INVALID_INDEX = 0xFFFFFFFFu;

        /// <summary>
        /// Special timeout value for <see cref="GL.WaitSync"/>. (must be used)
        /// </summary>
        [CLSCompliant(false)]
        public const ulong TIMEOUT_IGNORED = 0xFFFFFFFFFFFFFFFFul;

        /// <summary>
        /// Value for <see cref="GL.VertexAttribFormat"/> and <see cref="O:GL.VertexAttribPointer"/>size argument.
        /// </summary>
        public const int BGRA = 0x80E1;

        /// <summary>
        /// For convenience: Use in places, where int is used instead of bool (GLboolean).
        /// </summary>
        public const int FALSE = 0;

        /// <summary>
        /// For convenience: Use in places, where int is used instead of bool (GLboolean).
        /// </summary>
        public const int TRUE = 1;

        /// <summary>
        /// For convenience: Can be used, in places where int is used instead of a specific enum, to avoid typecasts where unnecessary.
        /// </summary>
        public const int NONE = 0;

        /// <summary>
        /// Layout location of vertex positions in shaders.
        /// </summary>
        public const int VERTEX_POSITION_LOCATION = 0;

        /// <summary>
        /// Layout location of vertex colors in shaders.
        /// </summary>
        public const int VERTEX_COLOR_LOCATION = 1;

        /// <summary>
        /// Layout location of vertex texture coordinates in shaders.
        /// </summary>
        public const int VERTEX_TEXTURE_COORD_LOCATION = 2;

        /// <summary>
        /// Layout position of vertex normal coordinates in shaders.
        /// </summary>
        public const int VERTEX_NORMAL_LOCATION = 3;

        /// <summary>
        /// Layout position of vertex tangents in shaders.
        /// </summary>
        public const int VERTEX_TANGENT_LOCATION = 4;

        /// <summary>
        /// Layout position of vertex bitangents in shaders.
        /// </summary>
        public const int VERTEX_BITANGENT_LOCATION = 5;

        public const int DIFFUSE_TEXTURE_UNIT_INDEX = 0;

        public const int AMBIENT_TEXTURE_UNIT_INDEX = 1;

        public const int SPECULAR_TEXTURE_UNIT_INDEX = 2;

        public const int EMISSIVE_TEXTURE_UNIT_INDEX = 3;

        public const int NORMAL_TEXTURE_UNIT_INDEX = 4;

        public const int SHADOW_TEXTURE_UNIT_INDEX = 5;

        public const int RANDOM_TEXTURE_UNIT_INDEX = 6;

        public const int DISPLACEMENT_TEXTURE_UNIT_INDEX = 7;

        public const int MOTION_TEXTURE_UNIT_INDEX = 8;

        public const int CASCACDE_SHADOW_TEXTURE_UNIT0_INDEX = SHADOW_TEXTURE_UNIT_INDEX;

        public const int CASCACDE_SHADOW_TEXTURE_UNIT1_INDEX = 9;

        public const int CASCACDE_SHADOW_TEXTURE_UNIT2_INDEX = 10;

    }
}
