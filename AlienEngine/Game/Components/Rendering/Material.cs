using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Shaders;
using AlienEngine.Imaging;
using System;

namespace AlienEngine
{
    public class Material : Component
    {
        private ShaderProgram _shader;

        public int TextureTilling = 1;
        public MaterialBlendMode BlendMode;
        public float BumpScaling;
        public Color4 ColorAmbient;
        public Color4 ColorDiffuse;
        public Color4 ColorEmissive;
        public Color4 ColorReflective;
        public Color4 ColorSpecular;
        public Color4 ColorTransparent;
        public bool HasBlendMode;
        public bool HasBumpScaling;
        public bool HasColorAmbient;
        public bool HasColorDiffuse;
        public bool HasColorEmissive;
        public bool HasColorReflective;
        public bool HasColorSpecular;
        public bool HasColorTransparent;
        public bool HasName;
        public bool HasOpacity;
        public bool HasReflectivity;
        public bool HasShadingMode;
        public bool HasShininess;
        public bool HasShininessStrength;
        public bool HasTextureAmbient;
        public bool HasTextureDiffuse;
        public bool HasTextureDisplacement;
        public bool HasTextureEmissive;
        public bool HasTextureHeight;
        public bool HasTextureLightMap;
        public bool HasTextureNormal;
        public bool HasTextureOpacity;
        public bool HasTextureReflection;
        public bool HasTextureSpecular;
        public bool HasTwoSided;
        public bool HasWireFrame;
        public bool IsTwoSided;
        public bool IsWireFrameEnabled;
        public string Name;
        public float Opacity;
        public int PropertyCount;
        public float Reflectivity;
        public MaterialShadingMode ShadingMode;
        public float Shininess;
        public float ShininessStrength;
        public Texture TextureAmbient;
        public Texture TextureDiffuse;
        public Texture TextureDisplacement;
        public Texture TextureEmissive;
        public Texture TextureHeight;
        public Texture TextureLightMap;
        public Texture TextureNormal;
        public Texture TextureOpacity;
        public Texture TextureReflection;
        public Texture TextureSpecular;

        public ShaderProgram ShaderProgram
        {
            get { return _shader; }
            set
            {
                _shader?.Dispose();
                _shader = value;
            }
        }

        // TODO: Implement shaders who handle all these parameters
        // TODO: Complete this implementation
        public void Use()
        {
            // Pre calculate all matrices
            Matrix4f wMatrix = gameElement.WorldTransform.GetTransformation();

            if (RendererManager.IsShadowMapDepthPass)
            {
                RendererManager.DepthShaderProgram.Bind();

                RendererManager.DepthShaderProgram.SetUniform("w_matrix", wMatrix);
            }
            else
            {
                // Use the current shader program
                ShaderProgram.Bind();

                Matrix3f nMatrix = wMatrix.ToMatrix3f().Inversed.Transposed;

                // Sets projection matrices uniforms values
                ShaderProgram.SetUniform("w_matrix", wMatrix);
                ShaderProgram.SetUniform("n_matrix", nMatrix);

                // Sets lights informations
                var ligths = SceneManager.CurrentScene.Lights;
                var maxNB = ligths.Length;
                ShaderProgram.SetUniform("lights_nb", maxNB);
                for (int i = 0; i < maxNB; i++)
                {
                    var light = ligths[i].GetComponent<Light>();
                    ShaderProgram.SetUniform($"lights[{i}].Type", (int)light.Type);
                    ShaderProgram.SetUniform($"lights[{i}].AmbientColor", light.AmbientColor);
                    ShaderProgram.SetUniform($"lights[{i}].DiffuseColor", light.DiffuseColor);
                    ShaderProgram.SetUniform($"lights[{i}].SpecularColor", light.SpecularColor);
                    ShaderProgram.SetUniform($"lights[{i}].Intensity", light.Intensity);
                    ShaderProgram.SetUniform($"lights[{i}].Direction", light.Direction);
                    ShaderProgram.SetUniform($"lights[{i}].Position", ligths[i].WorldTransform.Translation);
                    ShaderProgram.SetUniform($"lights[{i}].AttenuationFactors", light.AttenuationFactors);
                    ShaderProgram.SetUniform($"lights[{i}].FallOffExponent", light.FallOffExponent);
                    ShaderProgram.SetUniform($"lights[{i}].CutOff", new Vector2f(MathHelper.Cos(MathHelper.Deg2Rad(light.FallOffAngles.X)), MathHelper.Cos(MathHelper.Deg2Rad(light.FallOffAngles.Y))));
                }

                // Sets Camera informations
                // ShaderProgram.SetUniform("c_position", Game.Instance.CurrentScene.PrimaryCamera.WorldTransform.Translation);
                // ShaderProgram.SetUniform("c_rotation", Game.Instance.CurrentScene.PrimaryCamera.WorldTransform.Rotation);
                // ShaderProgram.SetUniform("c_depthDistances", new Vector2f(_camera.Near, _camera.Far));

                // Sets material data
                ShaderProgram.SetUniform("materialState.textureTilling", Math.Max(0, TextureTilling));

                // Sets material data disponibility informations
                ShaderProgram.SetUniform("materialState.hasColorAmbient", HasColorAmbient);
                ShaderProgram.SetUniform("materialState.hasColorDiffuse", HasColorDiffuse);
                ShaderProgram.SetUniform("materialState.hasColorSpecular", HasColorSpecular);
                ShaderProgram.SetUniform("materialState.hasColorEmissive", HasColorEmissive);
                ShaderProgram.SetUniform("materialState.hasShininess", HasShininess);
                ShaderProgram.SetUniform("materialState.hasShininessStrength", HasShininessStrength);

                ShaderProgram.SetUniform("materialState.hasTextureAmbient", HasTextureAmbient);
                ShaderProgram.SetUniform("materialState.hasTextureDiffuse", HasTextureDiffuse);
                ShaderProgram.SetUniform("materialState.hasTextureSpecular", HasTextureSpecular);
                ShaderProgram.SetUniform("materialState.hasTextureEmissive", HasTextureEmissive);
                ShaderProgram.SetUniform("materialState.hasTextureNormal", HasTextureNormal);
                ShaderProgram.SetUniform("materialState.hasTextureDisplacement", HasTextureDisplacement);

                ShaderProgram.SetUniform("materialState.hasReflectivity", HasReflectivity);
                ShaderProgram.SetUniform("materialState.hasOpacity", HasOpacity);

                // Sets material data if disponible
                if (HasOpacity)
                {
                    ShaderProgram.SetUniform("materialState.opacity", Opacity);
                }

                if (HasShininess)
                {
                    ShaderProgram.SetUniform("materialState.shininess", Shininess);
                }

                if (HasShininessStrength)
                {
                    ShaderProgram.SetUniform("materialState.shininessStrength", ShininessStrength);
                }

                if (HasReflectivity)
                {
                    ShaderProgram.SetUniform("materialState.reflectivity", Reflectivity);
                }

                if (HasColorAmbient)
                {
                    ShaderProgram.SetUniform("materialState.colorAmbient", ColorAmbient);
                }

                if (HasColorDiffuse)
                {
                    ShaderProgram.SetUniform("materialState.colorDiffuse", ColorDiffuse);
                }

                if (HasColorSpecular)
                {
                    ShaderProgram.SetUniform("materialState.colorSpecular", ColorSpecular);
                }

                if (HasColorEmissive)
                {
                    ShaderProgram.SetUniform("materialState.colorEmissive", ColorEmissive);
                }

                if (HasTextureAmbient)
                {
                    ShaderProgram.SetUniform("materialState.textureAmbient", GL.AMBIENT_TEXTURE_UNIT_INDEX);
                    TextureDiffuse.Bind(GL.AMBIENT_TEXTURE_UNIT_INDEX);
                }

                if (HasTextureDiffuse)
                {
                    ShaderProgram.SetUniform("materialState.textureDiffuse", GL.DIFFUSE_TEXTURE_UNIT_INDEX);
                    TextureDiffuse.Bind(GL.DIFFUSE_TEXTURE_UNIT_INDEX);
                }

                if (HasTextureSpecular)
                {
                    ShaderProgram.SetUniform("materialState.textureSpecular", GL.SPECULAR_TEXTURE_UNIT_INDEX);
                    TextureSpecular.Bind(GL.SPECULAR_TEXTURE_UNIT_INDEX);
                }

                if (HasTextureEmissive)
                {
                    ShaderProgram.SetUniform("materialState.textureEmissive", GL.EMISSIVE_TEXTURE_UNIT_INDEX);
                    TextureEmissive.Bind(GL.EMISSIVE_TEXTURE_UNIT_INDEX);
                }

                if (HasTextureNormal)
                {
                    ShaderProgram.SetUniform("materialState.textureNormal", GL.NORMAL_TEXTURE_UNIT_INDEX);
                    TextureNormal.Bind(GL.NORMAL_TEXTURE_UNIT_INDEX);
                }

                if (HasTextureDisplacement)
                {
                    ShaderProgram.SetUniform("materialState.textureDisplacement", GL.DISPLACEMENT_TEXTURE_UNIT_INDEX);
                    TextureDisplacement.Bind(GL.DISPLACEMENT_TEXTURE_UNIT_INDEX);
                }

                RendererManager.BindShadowMapTexture(ShaderProgram);
            }
        }

        public void Unuse()
        {
            if (RendererManager.IsShadowMapDepthPass)
            {
                RendererManager.DepthShaderProgram.Unbind();
            }
            else
            {
                ShaderProgram.Unbind();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            
            _shader?.Dispose();
            _shader = null;
        }
    }
}
