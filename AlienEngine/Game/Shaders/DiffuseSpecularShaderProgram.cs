using AlienEngine.Core.Graphics;
using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class DiffuseSpecularShaderProgram : ShaderProgram
    {
        private static UBO _cameraUBO;
        private static UBO _lightsUBO;

        static DiffuseSpecularShaderProgram()
        {
            _cameraUBO = null;
            _lightsUBO = null;
        }

        public DiffuseSpecularShaderProgram() : base(new DiffuseVertexShader(), new DiffuseSpecularFragmentShader())
        {
            //if (_cameraUBO == null)
            //{
            //    if (UBO.Is("CameraInformations"))
            //        _cameraUBO = UBO.Get("CameraInformations");
            //    else
            //     _cameraUBO = new UBO("CameraInformations");
            //}

            //if (_lightsUBO == null)
            //{
            //    if (UBO.Is("LigthInformations"))
            //        _lightsUBO = UBO.Get("LigthInformations");
            //    else
            //        _lightsUBO = new UBO("LigthInformations");
            //}
        }
    }
}
