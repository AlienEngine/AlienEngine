using AlienEngine.ASL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Graphics.Shaders
{
    [Version(330)]
    internal class RenderTextureFragmentShader : FragmentShader
    {
        [In] vec2 uv;

        [Uniform] sampler2D texture;
        [Uniform] int postEffectMode;
        [Uniform] int width;
        [Uniform] int height;

        vec4 ApplyPostEffect(vec4 color, [ArraySize(9)] float[] kernel)
        {
            __output(@"
                float offset_w = 1.0f / width;
                float offset_h = 1.0f / height;

                vec2 offsets[9] = vec2[]
                (
                    vec2( offset_w,  offset_h),          // top-left
                    vec2( 0.0f,      offset_h),          // top-center
                    vec2(-offset_w,  offset_h),          // top-right
                    vec2( offset_w,  0.0f),              // center-left
                    vec2( 0.0f,    0.0f),                // center-center
                    vec2(-offset_w,  0.0f),              // center-right
                    vec2( offset_w, -offset_h),          // bottom-left
                    vec2( 0.0f,     -offset_h),          // bottom-center
                    vec2( offset_w, -offset_h)           // bottom-right
                );

                vec3 col = vec3(0.0f);

                for (int i = 0; i < 9; i++)
                    col += vec3(texture(texture, uv.st + offsets[i])) * kernel[i];

                color = vec4(col, color.a)");

            return color;
        }

        void main()
        {
            vec4 color = texture(texture, uv);

            switch (postEffectMode)
            {
                // Inverse colors
                case 1:
                    color = new vec4(1.0f - color.rgb, color.a);
                    break;

                // Sharpen
                case 2:
                    color = ApplyPostEffect(color, new float[9]
                    {
                        -1, -1, -1,
                        -1,  9, -1,
                        -1, -1, -1
                    });
                    break;

                // Blur
                case 3:
                    color = ApplyPostEffect(color, new float[9]
                    {
                        1.0f / 16, 2.0f / 16, 1.0f / 16,
                        2.0f / 16, 4.0f / 16, 2.0f / 16,
                        1.0f / 16, 2.0f / 16, 1.0f / 16
                    });
                    break;

                // Edge detection
                case 4:
                    color = ApplyPostEffect(color, new float[9]
                    {
                        1,  1,  1,
                        1, -8,  1,
                        1,  1,  1
                    });
                    break;
            }

            gl_FragColor = new vec4(color.rgb, 1.0f);
        }
    }
}
