using AlienEngine.ASL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Graphics.Shaders
{
    internal class CubemapFragmentShader : FragmentShader
    {
        [In] vec3 position;

        [Uniform] samplerCube textureCubemap;

        void main()
        {
            gl_FragColor = texture(textureCubemap, position);
        }
    }
}
