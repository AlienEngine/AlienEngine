using AlienEngine.Shaders.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    internal class DualDiffuseBlendFragmentShader : FragmentShader
    {
        const int MAX_POINT_LIGHTS = 2;
        const int MAX_SPOT_LIGHTS = 2;

        [In] vec2 TexCoord0;
        [In] vec3 Normal0;
        [In] vec3 Position0;

        [Out] vec4 FragColor;

        struct BaseLight
        {
            public vec3 Color;
            public float AmbientIntensity;
            public float DiffuseIntensity;
        };

        struct DirectionalLight
        {
            public BaseLight Base;
            public vec3 Direction;
        };

        struct Attenuation
        {
            public float Constant;
            public float Linear;
            public float Exp;
        };

        struct PointLight
        {
            public BaseLight Base;
            public vec3 Position;
            public Attenuation Atten;
        };

        struct SpotLight
        {
            public PointLight Base;
            public vec3 Direction;
            public float Cutoff;
        };

        [Uniform] int gNumPointLights;
        [Uniform] int gNumSpotLights;
        [Uniform] DirectionalLight gDirectionalLight;
        [Uniform] [ArraySize(MAX_POINT_LIGHTS)] PointLight[] gPointLights;
        [Uniform] [ArraySize(MAX_SPOT_LIGHTS)] SpotLight[] gSpotLights;
        [Uniform] sampler2D gColorMap1;
        [Uniform] sampler2D gColorMap2;
        [Uniform] float blendFactor;
        [Uniform] vec3 gEyeWorldPos;
        [Uniform] float gMatSpecularIntensity;
        [Uniform] float gSpecularPower;

        vec4 CalcLightInternal(BaseLight Light, vec3 LightDirection, vec3 Normal)
        {
            vec4 AmbientColor = new vec4(Light.Color * Light.AmbientIntensity, 1.0f);
            float DiffuseFactor = dot(Normal, -LightDirection);

            vec4 DiffuseColor = new vec4(0, 0, 0, 0);
            vec4 SpecularColor = new vec4(0, 0, 0, 0);

            if (DiffuseFactor > 0)
            {
                DiffuseColor = new vec4(Light.Color * Light.DiffuseIntensity * DiffuseFactor, 1.0f);

                vec3 VertexToEye = normalize(gEyeWorldPos - Position0);
                vec3 LightReflect = normalize(reflect(LightDirection, Normal));
                float SpecularFactor = dot(VertexToEye, LightReflect);
                if (SpecularFactor > 0)
                {
                    SpecularFactor = pow(SpecularFactor, gSpecularPower);
                    SpecularColor = new vec4(Light.Color * gMatSpecularIntensity * SpecularFactor, 1.0f);
                }
            }

            return (AmbientColor + DiffuseColor + SpecularColor);
        }

        vec4 CalcDirectionalLight(vec3 Normal)
        {
            return CalcLightInternal(gDirectionalLight.Base, gDirectionalLight.Direction, Normal);
        }

        vec4 CalcPointLight(PointLight l, vec3 Normal)
        {
            vec3 LightDirection = Position0 - l.Position;
            float Distance = length(LightDirection);
            LightDirection = normalize(LightDirection);

            vec4 Color = CalcLightInternal(l.Base, LightDirection, Normal);
            float Attenuation = l.Atten.Constant +
                                 l.Atten.Linear * Distance +
                                 l.Atten.Exp * Distance * Distance;

            return Color / Attenuation;
        }

        vec4 CalcSpotLight(SpotLight l, vec3 Normal)
        {
            vec3 LightToPixel = normalize(Position0 - l.Base.Position);
            float SpotFactor = dot(LightToPixel, l.Direction);

            if (SpotFactor > l.Cutoff)
            {
                vec4 Color = CalcPointLight(l.Base, Normal);
                return Color * (1.0f - (1.0f - SpotFactor) * 1.0f / (1.0f - l.Cutoff));
            }
            else
            {
                return new vec4(0, 0, 0, 0);
            }
        }

        void main()
        {
            vec3 Normal = normalize(Normal0);
            vec4 TotalLight = CalcDirectionalLight(Normal);

            for (int i = 0; i < gNumPointLights; i++)
            {
                TotalLight += CalcPointLight(gPointLights[i], Normal);
            }

            for (int i = 0; i < gNumSpotLights; i++)
            {
                TotalLight += CalcSpotLight(gSpotLights[i], Normal);
            }

            vec4 color1 = texture(gColorMap1, TexCoord0.xy);
            vec4 color2 = texture(gColorMap2, TexCoord0.xy);

            FragColor = mix(color1, color2, blendFactor)  * TotalLight;
        }
    }
}
