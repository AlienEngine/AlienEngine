using AlienEngine.Core.Graphics;
using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class DiffuseSpecularEmissiveShaderProgram : ShaderProgram
    {
        private static UBO _cameraUBO;
        private static UBO _lightsUBO;

        static DiffuseSpecularEmissiveShaderProgram()
        {
            _cameraUBO = null;
            _lightsUBO = null;
        }

        public DiffuseSpecularEmissiveShaderProgram() : base(new DiffuseVertexShader(), new DiffuseSpecularEmissiveFragmentShader())
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
