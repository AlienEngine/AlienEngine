using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assimp;
using AlienEngine.Graphics;
using AlienEngine.Graphics.Shaders;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Game;

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

        public ShaderProgram Program
        {
            get { return _shader; }
            set
            {
                if (_shader != null)
                    _shader.Dispose();

                _shader = value;
            }
        }

        private Camera _camera
        {
            get { return Game.CurrentCamera.GetComponent<Camera>(); }
        }

        // TODO: Implement shaders who handle all these parameters
        // TODO: Complete this implementation
        public void Use()
        {
            // Use the current shader program
            Program.Bind();

            // Sets projection matrices uniforms values
            Program.SetUniform("wvp_matrix", gameElement.WorldTransform.GetProjectedTransformation());
            Program.SetUniform("w_matrix", gameElement.WorldTransform.GetTransformation());
            Program.SetUniform("v_matrix", _camera.ViewMatrix);
            Program.SetUniform("p_matrix", _camera.ProjectionMatrix);
            Program.SetUniform("cm_matrix", _camera.CubemapMatrix);
            Program.SetUniform("pcm_matrix", _camera.ProjectionMatrix * _camera.CubemapMatrix);

            // Sets Camera informations
            Program.SetUniform("c_position", Game.CurrentCamera.WorldTransform.Position);
            // TODO: Think about the rotation

            // Sets texture disponibility informations
            Program.SetUniform("useTextureDiffuse", HasTextureDiffuse);
            Program.SetUniform("useTextureNormal", HasTextureNormal);

            if (HasOpacity)
            {
                Program.SetUniform("opacity", Opacity);
            }

            if (HasShininess)
            {
                Program.SetUniform("shininess", Shininess);
            }

            if (HasShininessStrength)
            {
                Program.SetUniform("shininessStrength", ShininessStrength);
            }

            if (HasReflectivity)
            {
                Program.SetUniform("reflectivity", Reflectivity);
            }

            if (HasColorDiffuse)
            {
                Program.SetUniform("colorDiffuse", ColorDiffuse);
            }

            if (HasColorAmbient)
            {
                Program.SetUniform("colorAmbient", ColorAmbient);
            }

            if (HasColorSpecular)
            {
                Program.SetUniform("colorSpecular", ColorSpecular);
            }

            if (HasTextureDiffuse)
            {
                Program.SetUniform("textureDiffuse", GL.COLOR_TEXTURE_UNIT_INDEX);
                TextureDiffuse.Bind(GL.COLOR_TEXTURE_UNIT_INDEX);
            }

            if (HasTextureNormal)
            {
                Program.SetUniform("textureNormal", GL.NORMAL_TEXTURE_UNIT_INDEX);
                TextureNormal.Bind(GL.NORMAL_TEXTURE_UNIT_INDEX);
            }

            if (HasTextureDisplacement)
            {
                Program.SetUniform("textureDisplacement", GL.DISPLACEMENT_TEXTURE_UNIT_INDEX);
                TextureDisplacement.Bind(GL.DISPLACEMENT_TEXTURE_UNIT_INDEX);
            }
        }
    }
}
