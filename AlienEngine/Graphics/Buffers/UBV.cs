using System;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Graphics.Buffers
{
    public struct UBV
    {
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
        public void CheckType(params ShaderUniformType[] uniformRequestTypes)
        {
            if (uniformRequestTypes == null)
                throw new ArgumentNullException(nameof(uniformRequestTypes));

            /* ! Check: required uniform type shall correspond */
            foreach (ShaderUniformType uniformReqtype in uniformRequestTypes)
                if (Type == uniformReqtype)
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
    }
}