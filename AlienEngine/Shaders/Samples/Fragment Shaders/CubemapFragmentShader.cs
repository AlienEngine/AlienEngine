using AlienEngine.ASL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Graphics.Shaders
{
    [Version("330 core")]
    internal class CubemapFragmentShader : FragmentShader
    {
        [Out] vec4 FragColor;

        [In] vec3 position;

        [Uniform] samplerCube textureCubemap;

        void main()
        {
            FragColor = texture(textureCubemap, position);
        }
    }
}
