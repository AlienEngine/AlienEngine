using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Graphics;
using System;
using System.Runtime.InteropServices;

namespace AlienEngine
{
    public class Material : Component
    {
        private ShaderProgram _shader;

        [CLSCompliant(false)]
        public enum MaterialBlendMode : uint
        {
            Default = 0,
            Additive = 1
        }

        [CLSCompliant(false)]
        public enum MaterialShadingMode : uint
        {
            None = 0,
            Flat = 1,
            Gouraud = 2,
            Phong = 3,
            Blinn = 4,
            Toon = 5,
            OrenNayar = 6,
            Minnaert = 7,
            CookTorrance = 8,
            NoShading = 9,
            Fresnel = 10
        }

        [CLSCompliant(false)]
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
        [CLSCompliant(false)]
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
                if (_shader != null)
                    _shader.Dispose();

                _shader = value;
            }
        }

        // TODO: Implement shaders who handle all these parameters
        // TODO: Complete this implementation
        public void Use()
        {
            var _camera = Game.CurrentScene.PrimaryCamera.GetComponent<Camera>();

            // Use the current shader program
            ShaderProgram.Bind();

            // Pre calculate all matrices
            Matrix4f
                w_matrix = gameElement.WorldTransform.GetTransformation(),
                v_matrix = _camera.ViewMatrix,
                p_matrix = _camera.ProjectionMatrix,
                cm_matrix = _camera.CubemapMatrix,
                pcm_matrix = p_matrix * cm_matrix,
                wv_matrix = w_matrix * v_matrix,
                wvp_matrix = wv_matrix * p_matrix,
                i_w_matrix = w_matrix.Inversed,
                i_v_matrix = v_matrix.Inversed,
                i_p_matrix = p_matrix.Inversed,
                i_wv_matrix = wv_matrix.Inversed,
                i_wvp_matrix = wvp_matrix.Inversed;

            Matrix3f n_matrix = w_matrix.ToMatrix3f().Inversed.Transposed;

            // Sets projection matrices uniforms values
            ShaderProgram.SetUniform("wvp_matrix", wvp_matrix);
            ShaderProgram.SetUniform("wv_matrix", wv_matrix);
            ShaderProgram.SetUniform("w_matrix", w_matrix);
            ShaderProgram.SetUniform("v_matrix", v_matrix);
            ShaderProgram.SetUniform("p_matrix", p_matrix);
            ShaderProgram.SetUniform("n_matrix", n_matrix);
            ShaderProgram.SetUniform("cm_matrix", cm_matrix);
            ShaderProgram.SetUniform("pcm_matrix", pcm_matrix);
            ShaderProgram.SetUniform("i_wvp_matrix", i_wvp_matrix);
            ShaderProgram.SetUniform("i_wv_matrix", i_wv_matrix);
            ShaderProgram.SetUniform("i_w_matrix", i_w_matrix);
            ShaderProgram.SetUniform("i_v_matrix", i_v_matrix);
            ShaderProgram.SetUniform("i_p_matrix", i_p_matrix);

            // Sets light informations
            var ligths = Game.CurrentScene.Lights;
            var max_nb = ligths.Length;
            ShaderProgram.SetUniform("lights_nb", max_nb);
            for (int i = 0; i < max_nb; i++)
            {
                var light = ligths[i].GetComponent<Light>();
                ShaderProgram.SetUniform(string.Format("lights[{0}].Type", i), (int)light.Type);
                ShaderProgram.SetUniform(string.Format("lights[{0}].AmbientColor", i), light.AmbientColor);
                ShaderProgram.SetUniform(string.Format("lights[{0}].DiffuseColor", i), light.DiffuseColor);
                ShaderProgram.SetUniform(string.Format("lights[{0}].SpecularColor", i), light.SpecularColor);
                ShaderProgram.SetUniform(string.Format("lights[{0}].Intensity", i), light.Intensity);
                ShaderProgram.SetUniform(string.Format("lights[{0}].Direction", i), light.Direction);
                ShaderProgram.SetUniform(string.Format("lights[{0}].Position", i), ligths[i].WorldTransform.Translation);
                ShaderProgram.SetUniform(string.Format("lights[{0}].AttenuationFactors", i), light.AttenuationFactors);
                ShaderProgram.SetUniform(string.Format("lights[{0}].FallOffExponent", i), light.FallOffExponent);
                ShaderProgram.SetUniform(string.Format("lights[{0}].CutOff", i), new Vector2f(MathHelper.Cos(light.FallOffAngles.X), MathHelper.Cos(light.FallOffAngles.Y)));
            }

            // Sets Camera informations
            ShaderProgram.SetUniform("c_position", Game.CurrentScene.PrimaryCamera.WorldTransform.Translation);
            ShaderProgram.SetUniform("c_rotation", Game.CurrentScene.PrimaryCamera.WorldTransform.Rotation);
            ShaderProgram.SetUniform("c_depthDistances", new Vector2f(_camera.Near, _camera.Far));

            // Sets material data disponibility informations
            ShaderProgram.SetUniform("materialState.hasColorAmbient", HasColorAmbient);
            ShaderProgram.SetUniform("materialState.hasColorDiffuse", HasColorDiffuse);
            ShaderProgram.SetUniform("materialState.hasReflectivity", HasReflectivity);
            ShaderProgram.SetUniform("materialState.hasShininessStrength", HasShininessStrength);
            ShaderProgram.SetUniform("materialState.hasShininess", HasShininess);
            ShaderProgram.SetUniform("materialState.hasOpacity", HasOpacity);
            ShaderProgram.SetUniform("materialState.hasColorSpecular", HasColorSpecular);
            ShaderProgram.SetUniform("materialState.hasTextureDiffuse", HasTextureDiffuse);
            ShaderProgram.SetUniform("materialState.hasTextureNormal", HasTextureNormal);
            ShaderProgram.SetUniform("materialState.hasTextureSpecular", HasTextureSpecular);
            ShaderProgram.SetUniform("materialState.hasTextureDisplacement", HasTextureDisplacement);

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

            if (HasColorDiffuse)
            {
                ShaderProgram.SetUniform("materialState.colorDiffuse", ColorDiffuse);
            }

            if (HasColorAmbient)
            {
                ShaderProgram.SetUniform("materialState.colorAmbient", ColorAmbient);
            }

            if (HasColorSpecular)
            {
                ShaderProgram.SetUniform("materialState.colorSpecular", ColorSpecular);
            }

            if (HasTextureDiffuse)
            {
                ShaderProgram.SetUniform("materialState.textureDiffuse", GL.COLOR_TEXTURE_UNIT_INDEX);
                TextureDiffuse.Bind(GL.COLOR_TEXTURE_UNIT_INDEX);
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
        }
    }
}
