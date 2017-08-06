using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Graphics;
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
            SetGlobal("MAX_NUMBER_OF_LIGHTS", System.Math.Max(1, Game.CurrentScene.Lights.Length).ToString());

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

        public void SetTransform(Matrix4f transform)
        {
            SetUniform("transform", transform);
        }

        public void SetModelTransform(Matrix4f world)
        {
            SetUniform("world", world);
        }

        public void SetPointOfLightsNumber(int number)
        {
            SetUniform("gNumPointLights", number);
        }

        public void SetSpotOfLightsNumber(int number)
        {
            SetUniform("gNumSpotLights", number);
        }

        public void SetDirectionalLight(Vector3f color, float ambient, float diffuse, Vector3f direction)
        {
            SetUniform("gDirectionalLight.Base.Color", color);
            SetUniform("gDirectionalLight.Base.AmbientIntensity", ambient);
            SetUniform("gDirectionalLight.Base.DiffuseIntensity", diffuse);
            SetUniform("gDirectionalLight.Direction", direction);
        }

        public void SetColorMap(Texture map)
        {
            SetUniform("gColorMap", map.TextureID);
        }

        public void SetColorMap(uint map)
        {
            SetUniform("gColorMap", map);
        }

        public void SetCameraPosition(Vector3f position)
        {
            SetUniform("gEyeWorldPos", position);
        }

        public void SetMaterialSpecularIntensity(float intensity)
        {
            SetUniform("gMatSpecularIntensity", intensity);
        }

        public void SetSpecularPower(float power)
        {
            SetUniform("gSpecularPower", power);
        }
    }

    public class DualDiffuseShaderProgram : ShaderProgram
    {
        public DualDiffuseShaderProgram() : base(new DiffuseVertexShader(), new DualDiffuseBlendFragmentShader())
        { }

        public void SetTransform(Matrix4f transform)
        {
            SetUniform("transform", transform);
        }

        public void SetModelTransform(Matrix4f world)
        {
            SetUniform("world", world);
        }

        public void SetPointOfLightsNumber(int number)
        {
            SetUniform("gNumPointLights", number);
        }

        public void SetSpotOfLightsNumber(int number)
        {
            SetUniform("gNumSpotLights", number);
        }

        public void SetDirectionalLight(Vector3f color, float ambient, float diffuse, Vector3f direction)
        {
            SetUniform("gDirectionalLight.Base.Color", color);
            SetUniform("gDirectionalLight.Base.AmbientIntensity", ambient);
            SetUniform("gDirectionalLight.Base.DiffuseIntensity", diffuse);
            SetUniform("gDirectionalLight.Direction", direction);
        }

        public void SetColorMap1(Texture map)
        {
            SetUniform("gColorMap1", map.TextureID);
        }

        public void SetColorMap2(Texture map)
        {
            SetUniform("gColorMap2", map.TextureID);
        }

        public void SetCameraPosition(Vector3f position)
        {
            SetUniform("gEyeWorldPos", position);
        }

        public void SetMaterialSpecularIntensity(float intensity)
        {
            SetUniform("gMatSpecularIntensity", intensity);
        }

        public void SetSpecularPower(float power)
        {
            SetUniform("gSpecularPower", power);
        }
    }
}
