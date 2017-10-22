using System;
using AlienEngine.ASL;

namespace AlienEngine.Core.Graphics.Shaders.Samples
{
    [Version(330)]
    internal class DiffuseFragmentShader : FragmentShader
    {
        #region Structs
        // --------------------
        // Material state
        // --------------------
        struct MaterialState
        {
            public int textureTilling;
            public uint blendMode;
            public float bumpScaling;
            public vec4 colorAmbient;
            public vec4 colorDiffuse;
            public vec4 colorEmissive;
            public vec4 colorReflective;
            public vec4 colorSpecular;
            public vec4 colorTransparent;
            public bool hasBlendMode;
            public bool hasBumpScaling;
            public bool hasColorAmbient;
            public bool hasColorDiffuse;
            public bool hasColorEmissive;
            public bool hasColorReflective;
            public bool hasColorSpecular;
            public bool hasColorTransparent;
            public bool hasName;
            public bool hasOpacity;
            public bool hasReflectivity;
            public bool hasShadingMode;
            public bool hasShininess;
            public bool hasShininessStrength;
            public bool hasTextureAmbient;
            public bool hasTextureDiffuse;
            public bool hasTextureDisplacement;
            public bool hasTextureEmissive;
            public bool hasTextureHeight;
            public bool hasTextureLightMap;
            public bool hasTextureNormal;
            public bool hasTextureOpacity;
            public bool hasTextureReflection;
            public bool hasTextureSpecular;
            public bool hasTwoSided;
            public bool hasWireFrame;
            public bool isTwoSided;
            public bool isWireFrameEnabled;
            public float opacity;
            public int propertyCount;
            public float reflectivity;
            public uint shadingMode;
            public float shininess;
            public float shininessStrength;
        }

        // --------------------
        // Light State
        // --------------------
        struct LightState
        {
            // The type of the light.
            //  1 = Spot
            //  2 = Directional
            //  3 = Point
            public int Type;

            // Light colors (all lights).
            public vec4 AmbientColor;
            public vec4 DiffuseColor;
            public vec4 SpecularColor;

            // Ambient light intensity
            public float Intensity;

            // The light direction vector (directional and spot lights).
            public vec3 Direction;
            // The light position vector (point and spot lights).
            public vec3 Position;

            // The light attenuation factors (X: constant; Y: linear; Z: quadratic; point and spot lights).
            public vec3 AttenuationFactors;
            // The spot fall-off parameters (X: fall-off angle in degrees; Y: fall-off exponent, spot lights).
            public float FallOffExponent;
            // The spot light cut-off
            public vec2 CutOff;
        }
        // --------------------
        #endregion

        [In] vec3 normal;
        [In] vec2 uv;
        [In] vec3 position;

        #region Lights
        // Lights
        [Uniform]
        [ArraySize("MAX_NUMBER_OF_LIGHTS")]
        LightState[] lights;
        // Number of lights
        [Uniform]
        int lights_nb;
        #endregion

        #region Materials
        // Matrial state
        [Uniform]
        MaterialState materialState;
        #endregion

        [Uniform]
        sampler2D textureAmbient;
        [Uniform]
        sampler2D textureDiffuse;
        [Uniform]
        sampler2D textureDisplacement;
        [Uniform]
        sampler2D textureEmissive;
        [Uniform]
        sampler2D textureHeight;
        [Uniform]
        sampler2D textureLightMap;
        [Uniform]
        sampler2D textureNormal;
        [Uniform]
        sampler2D textureOpacity;
        [Uniform]
        sampler2D textureReflection;
        [Uniform]
        sampler2D textureSpecular;

        #region Camera informations
        //[Uniform]
        //[InterfaceBlock]
        //[Layout(UniformLayout.Shared)]
        //struct CameraInformations
        //{
        //    // Position
        //    public vec3 c_position;
        //    // Rotation
        //    public vec3 c_rotation;
        //    // Near/Far planes distances
        //    public vec2 c_depthDistances;
        //}
        // Position
        [Uniform]
        vec3 c_position;
        // Rotation
        [Uniform]
        vec3 c_rotation;
        // Near and Far planes distances
        [Uniform]
        vec2 c_depthDistances;
        #endregion

        vec4 CalcLightInternal(LightState light, vec3 direction, vec3 normal)
        {
            vec4 mat = (materialState.hasColorAmbient ? materialState.colorAmbient : new vec4(1));
            vec4 AmbientColor = new vec4(light.AmbientColor.rgb * mat.rgb, light.AmbientColor.a * mat.a);
            vec4 DiffuseColor = new vec4(0, 0, 0, 0);
            vec4 SpecularColor = new vec4(0, 0, 0, 0);

            if (materialState.hasColorDiffuse)
            {
                float diffuseFactor = max(0.0f, dot(normal, -direction));

                if (diffuseFactor > 0)
                {
                    DiffuseColor = new vec4(light.DiffuseColor.rgb * materialState.colorDiffuse.rgb * diffuseFactor, light.DiffuseColor.a * materialState.colorDiffuse.a);

                    if (materialState.hasColorSpecular)
                    {
                        vec3 vertexToEye = normalize(c_position - position);
                        vec3 lv = -direction + vertexToEye;
                        vec3 halfway = lv / length(lv);
                        //vec3 lightReflect = normalize(reflect(direction, normal));
                        float specularFactor = max(0.0f, dot(normal, halfway));

                        if (specularFactor > 0)
                        {
                            specularFactor = pow(specularFactor, materialState.shininess);
                            SpecularColor = new vec4(light.SpecularColor.rgb * materialState.colorSpecular.rgb * materialState.shininessStrength * specularFactor, light.SpecularColor.a * materialState.colorSpecular.a);
                        }
                    }
                }
            }

            vec4 color = (AmbientColor + DiffuseColor + SpecularColor);

            return new vec4(color.rgb * light.Intensity, color.a);
        }

        vec4 CalcDirectionalLight(LightState light, vec3 Normal)
        {
            return CalcLightInternal(light, light.Direction, Normal);
        }

        vec4 CalcPointLight(LightState light, vec3 Normal)
        {
            vec3 LightDirection = position - light.Position;
            float Distance = length(LightDirection);
            LightDirection = normalize(LightDirection);

            vec4 Color = CalcLightInternal(light, LightDirection, Normal);
            float Attenuation = light.AttenuationFactors.x +
                                light.AttenuationFactors.y * Distance +
                                light.AttenuationFactors.z * Distance * Distance;

            return Color / Attenuation;
        }

        vec4 CalcSpotLight(LightState light, vec3 Normal)
        {
            vec3 LightToPixel = normalize(position - light.Position);
            float SpotFactor = max(0.0f, dot(LightToPixel, normalize(light.Direction)));

            if (SpotFactor > light.CutOff.x)
            {
                float spotValue = smoothstep(light.CutOff.x, light.CutOff.y, SpotFactor);
                float spotAttenuation = pow(spotValue, light.FallOffExponent);
                vec4 Color = CalcPointLight(light, Normal);
                return Color * spotAttenuation;//(1.0f - (1.0f - SpotFactor) * 1.0f / (1.0f - light.CutOff.x));
            }
            else
            {
                return new vec4(0, 0, 0, 0);
            }
        }

        void main()
        {
            vec3 _normal = normalize(normal);
            vec2 _uv = uv * materialState.textureTilling;
            vec4 _totalLight = new vec4(0);

            for (int i = 0; i < lights_nb; i++)
            {
                // If it is a spot light
                if (lights[i].Type == 1)
                {
                    _totalLight += CalcSpotLight(lights[i], _normal);
                }

                // If it is a directional light
                if (lights[i].Type == 2)
                {
                    _totalLight += CalcDirectionalLight(lights[i], _normal);
                }

                // If it is a point light
                if (lights[i].Type == 3)
                {
                    _totalLight += CalcPointLight(lights[i], _normal);
                }
            }

            // Diffuse Texture Light Intensity
            if (materialState.hasTextureDiffuse)
            {
                gl_FragColor = clamp(_totalLight * texture(textureDiffuse, _uv), 0, 1);
            }
            else
            {
                gl_FragColor = _totalLight;
            }
        }
    }
}
