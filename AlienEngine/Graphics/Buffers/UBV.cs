using System;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Graphics.Buffers
{
    public struct UBV
    {
        /// <summary>
        /// The index of the uniform variable.
        /// </summary>
        public uint UniformIndex;

        /// <summary>
        /// The type of the uniform variable.
        /// </summary>
        public ShaderUniformType Type;

        /// <summary>
        /// Check uniform variable coherence.
        /// </summary>
        /// <param name="uniformRequestTypes">
        /// A sequence of OpenGL constants that are the allowed types for the specified uniform.
        /// </param>
        public void CheckType(params int[] uniformRequestTypes)
        {
            if (uniformRequestTypes == null)
                throw new ArgumentNullException(nameof(uniformRequestTypes));

            /* ! Check: required uniform type shall correspond */
            foreach (int uniformReqtype in uniformRequestTypes)
                if ((int) Type == uniformReqtype)
                    return;

            // 3.3.0 NVIDIA 310.44 confuse float uniforms (maybe in structs?) as vec4
            if (Type == ShaderUniformType.FloatVec4)
                return;
            // Allow unknown uniform type
            if (Type == ShaderUniformType.None)
                return;

            throw new InvalidOperationException("uniform type mismatch");
        }

        /// <summary>
        /// The offset of the uniform variable from the beginning of the uniform buffer, in bytes.
        /// </summary>
        public int Offset;

        /// <summary>
        /// The stride between array elements, in case the uniform variable is an array variable, in bytes.
        /// </summary>
        public int ArrayStride;

        /// <summary>
        /// The stride between matrix elements, in case the uniform variable is an array of matrix variable, in bytes.
        /// </summary>
        public int MatrixStride;

        /// <summary>
        /// The flag indicating whether the the matrix components are stored in row-major order.
        /// </summary>
        public bool RowMajor;
    }
}