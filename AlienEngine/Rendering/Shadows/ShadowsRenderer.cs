using System.Collections.Generic;
using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Shaders;
using AlienEngine.Core.Shaders;

namespace AlienEngine.Core.Rendering.Shadows
{
    /// <summary>
    /// Renderer for shadow maps.
    /// </summary>
    internal class ShadowsRenderer : IRenderer
    {
        /// <summary>
        /// The list of shadow maps.
        /// </summary>
        private List<IShadowMap> _shadowMaps;
        
        /// <summary>
        /// The index of the current shadow map.
        /// </summary>
        private int _shadowPassId;
        
        /// <summary>
        /// Used to split the view frustum for cascaded shadow maps.
        /// </summary>
        private float[] _cascadedShadowMapSplits;
        
        /// <summary>
        /// The texture size of the shadow map.
        /// </summary>
        private int _shadowMapTextureSize;
        
        /// <summary>
        /// The shader program used to render depth.
        /// </summary>
        private ShadowMapDepthShaderProgram _depthShaderProgram;

        /// <summary>
        /// The shader program used to render depth.
        /// </summary>
        public ShadowMapDepthShaderProgram DepthShaderProgram => _depthShaderProgram;

        /// <summary>
        /// The current shadow map.
        /// </summary>
        public IShadowMap CurrentShadowMap => _shadowMaps[_shadowPassId];
        
        /// <summary>
        /// Used to split the view frustum for cascaded shadow maps.
        /// </summary>
        public float[] CascadedShadowMapSplits => _cascadedShadowMapSplits;

        /// <summary>
        /// The texture size of the shadow map.
        /// </summary>
        public int ShadowMapTextureSize => _shadowMapTextureSize;

        public void BindTexture(ref ShaderProgram program)
        {
            if (GameSettings.ShadowMapEnabled)
            {
                program.SetUniform("shadowMap", GL.SHADOW_TEXTURE_UNIT_INDEX);
                CurrentShadowMap.BindTexture();
            }
        }

        /// <summary>
        /// Initialize the renderer.
        /// </summary>
        public void Init()
        {
            _shadowMaps = new List<IShadowMap>();
            _depthShaderProgram = new ShadowMapDepthShaderProgram();

            switch (GameSettings.ShadowMapQuality)
            {
                default:
                case ShadowMapQuality.Low:
                    _cascadedShadowMapSplits = new float[] { 1.0f };
                    _shadowMapTextureSize = 512;
                    break;

                case ShadowMapQuality.Normal:
                    _cascadedShadowMapSplits = new float[] { 1.0f };
                    _shadowMapTextureSize = 1024;
                    break;

                case ShadowMapQuality.High:
                    _cascadedShadowMapSplits = new float[] { 0.5f, 1.0f };
                    _shadowMapTextureSize = 2048;
                    break;

                case ShadowMapQuality.VeryHigh:
                    _cascadedShadowMapSplits = new float[] { 0.2f, 0.5f, 1.0f };
                    _shadowMapTextureSize = 4096;
                    break;

                case ShadowMapQuality.Ultra:
                    _cascadedShadowMapSplits = new float[] { 0.05f, 0.2f, 0.5f, 1.0f };
                    _shadowMapTextureSize = 8192;
                    break;
            }

            var lights = Game.Game.Instance.CurrentScene.Lights;
            var splitsCount = _cascadedShadowMapSplits.Length;

            for (int i = 0, l = lights.Length; i < l; i++)
            {
                var light = lights[i].GetComponent<Light>();

                if (light.Type == LightType.Directional)
                    _shadowMaps.Add(new DirectionalShadowMap(_shadowMapTextureSize, splitsCount));
                else if (light.Type == LightType.Point)
                    _shadowMaps.Add(new OmnidirectionalShadowMap(_shadowMapTextureSize));
                else if (light.Type == LightType.Spot)
                    _shadowMaps.Add(new DirectionalShadowMap(_shadowMapTextureSize, splitsCount));
            }
        }

        /// <summary>
        /// Render shadow maps.
        /// </summary>
        public void Process()
        {
            if (GameSettings.ShadowMapEnabled)
            {
                _shadowPassId = 0;
                
                RendererManager.ShadowMapDepthPass();

                var lights = Game.Game.Instance.CurrentScene.Lights;
                
                _shadowMaps[0].Begin();
    
                var lightElement = lights[0];
                var lightComponent = lightElement.GetComponent<Light>();
                var cameraComponent = Game.Game.Instance.CurrentScene.PrimaryCamera.GetComponent<Camera>();
    
                Matrix4f[] lightSpaceMatrices = new Matrix4f[_cascadedShadowMapSplits.Length];
    
                for (int i = 0, l = _cascadedShadowMapSplits.Length; i < l; i++)
                {
                    float split = _cascadedShadowMapSplits[i];
    
                    ShadowMapBoundingBox shadowMapBoundingBox = new ShadowMapBoundingBox(cameraComponent, lightComponent, i > 0 ?  _cascadedShadowMapSplits[i - 1]: 0, split);
        
                    lightSpaceMatrices[i] = shadowMapBoundingBox.LightSpaceMatrix;
                }
    
                RendererManager.MatricesData.LightSpace = lightSpaceMatrices[0];
    
                RendererManager.FaceCulling(cullFaceMode: CullFaceMode.Front);
                
                // Render the scene.
                RendererManager.RenderScene();
    
                RendererManager.FaceCulling(cullFaceMode: CullFaceMode.Back);
    
                _shadowMaps[0].End();
    
                RendererManager.ShadowMapDepthPass(false);
            }
        }
    }
}