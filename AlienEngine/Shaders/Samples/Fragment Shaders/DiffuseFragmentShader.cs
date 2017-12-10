﻿using System;
using AlienEngine.ASL;

namespace AlienEngine.Core.Graphics.Shaders.Samples
{
    [Version("330 core")]
    internal class DiffuseFragmentShader : FragmentShader
    {
        [Out] vec4 FragColor;

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
            public sampler2D textureAmbient;
            public sampler2D textureDiffuse;
            public sampler2D textureDisplacement;
            public sampler2D textureEmissive;
            public sampler2D textureHeight;
            public sampler2D textureLightMap;
            public sampler2D textureNormal;
            public sampler2D textureOpacity;
            public sampler2D textureReflection;
            public sampler2D textureSpecular;
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
        [ArraySize(1)]
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

        vec4 CalcLightInternal(LightState light, vec3 direction, vec3 normal, vec2 uv)
        {
            vec3 DiffuseColor = new vec3(0);
            vec3 SpecularColor = new vec3(0);

            vec3 _mat = (materialState.hasColorAmbient ? materialState.colorAmbient.rgb : new vec3(0));
            vec3 dTex = (materialState.hasTextureDiffuse ? new vec3(texture(materialState.textureDiffuse, uv)) : new vec3(1));
            vec3 sTex = (materialState.hasTextureSpecular ? new vec3(texture(materialState.textureSpecular, uv)) : new vec3(1));

            vec3 AmbientColor = light.AmbientColor.rgb * _mat;

            if (materialState.hasTextureDiffuse)
            {
                AmbientColor = AmbientColor * dTex;
            }

            if (materialState.hasColorDiffuse)
            {
                float diffuseFactor = max(0.0f, dot(normal, -direction));

                if (diffuseFactor > 0)
                {
                    DiffuseColor = light.DiffuseColor.rgb * materialState.colorDiffuse.rgb * diffuseFactor;

                    if (materialState.hasTextureDiffuse)
                    {
                        DiffuseColor = DiffuseColor * dTex;
                    }

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
                            SpecularColor = light.SpecularColor.rgb * materialState.colorSpecular.rgb * materialState.shininessStrength * specularFactor;

                            if (materialState.hasTextureSpecular)
                            {
                                SpecularColor = SpecularColor * sTex;
                            }
                        }
                    }
                }
            }

            vec3 color = (AmbientColor + DiffuseColor + SpecularColor) * light.Intensity;

            return new vec4(color, 1);
        }

        vec4 CalcDirectionalLight(LightState light, vec3 normal, vec2 uv)
        {
            return CalcLightInternal(light, light.Direction, normal, uv);
        }

        vec4 CalcPointLight(LightState light, vec3 normal, vec2 uv)
        {
            vec3 LightDirection = position - light.Position;
            float Distance = length(LightDirection);
            LightDirection = normalize(LightDirection);

            vec4 Color = CalcLightInternal(light, LightDirection, normal, uv);
            float Attenuation = light.AttenuationFactors.x +
                                light.AttenuationFactors.y * Distance +
                                light.AttenuationFactors.z * Distance * Distance;

            return Color / Attenuation;
        }

        vec4 CalcSpotLight(LightState light, vec3 normal, vec2 uv)
        {
            vec3 LightToPixel = normalize(position - light.Position);
            float SpotFactor = max(0.0f, dot(LightToPixel, normalize(light.Direction)));

            if (SpotFactor > light.CutOff.x)
            {
                float spotValue = smoothstep(light.CutOff.x, light.CutOff.y, SpotFactor);
                float spotAttenuation = pow(spotValue, light.FallOffExponent);
                vec4 Color = CalcPointLight(light, normal, uv);
                return Color * spotAttenuation;//(1.0f - (1.0f - SpotFactor) * 1.0f / (1.0f - light.CutOff.x));
            }
            else
            {
                return new vec4(0, 0, 0, 1);
            }
        }

        void main()
        {
            if (materialState.hasTextureDiffuse)
            {
                vec4 textureDiffuse = texture(materialState.textureDiffuse, uv);
                if (textureDiffuse.a < 0.1f)
                {
                    __output("discard");
                }
            }

            vec3 _normal = normalize(normal);
            vec2 _uv = uv * materialState.textureTilling;
            vec4 _totalLight = new vec4(0, 0, 0, 1);

            for (int i = 0; i < lights_nb; i++)
            {
                // If it is a spot light
                if (lights[i].Type == 1)
                {
                    _totalLight += CalcSpotLight(lights[i], _normal, _uv);
                }

                // If it is a directional light
                if (lights[i].Type == 2)
                {
                    _totalLight += CalcDirectionalLight(lights[i], _normal, _uv);
                }

                // If it is a point light
                if (lights[i].Type == 3)
                {
                    _totalLight += CalcPointLight(lights[i], _normal, _uv);
                }
            }

            FragColor = _totalLight;
        }
    }
}
