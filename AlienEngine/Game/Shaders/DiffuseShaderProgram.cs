using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Core.Graphics.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class DiffuseShaderProgram : ShaderProgram
    {
        private static UBO _cameraUBO;
        private static UBO _lightsUBO;

        static DiffuseShaderProgram()
        {
            _cameraUBO = null;
            _lightsUBO = null;
        }

        public DiffuseShaderProgram() : base(new DiffuseVertexShader(), new DiffuseFragmentShader())
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

    public class DualDiffuseShaderProgram : ShaderProgram
    {
        public DualDiffuseShaderProgram() : base(new DiffuseVertexShader(), new DualDiffuseBlendFragmentShader())
        { }
    }
}
