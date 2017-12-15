using AlienEngine.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    internal class BumpedDiffuseFragmentShader : FragmentShader
    {
        [Out] vec4 FragColor;
        
        #region Structs
        // --------------------
        // Material state
        // --------------------
        struct MaterialState
        {
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
        //[In] vec2 color;
        //[In] vec2 tbn;
        [In] vec3 position;

        // [Out] vec4 fragment;

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
        // Near/Far planes distances
        [Uniform]
        vec2 c_depthDistances;
        #endregion

        mat3 CotangentFrame(vec3 N, vec3 p, vec2 uv)
        {
            // récupère les vecteurs du triangle composant le pixel
            vec3 dp1 = dFdx(p);
            vec3 dp2 = dFdy(p);
            vec2 duv1 = dFdx(uv);
            vec2 duv2 = dFdy(uv);

            // résout le système linéaire
            vec3 dp2perp = cross(dp2, N);
            vec3 dp1perp = cross(N, dp1);
            vec3 T = dp2perp * duv1.x + dp1perp * duv2.x;
            vec3 B = dp2perp * duv1.y + dp1perp * duv2.y;

            // construit une trame invariante à l'échelle 
            float invmax = inversesqrt(max(dot(T, T), dot(B, B)));
            return new mat3(T * invmax, B * invmax, N);
        }

        vec3 PerturbNormal(vec3 N, vec3 V, vec2 texcoord)
        {
            // N, la normale interpolée et
            // V, le vecteur vue (vertex dirigé vers l'œil)
            vec3 map = texture(materialState.textureNormal, texcoord).rgb;
            map = map * 255f / 127f - 128f / 127f;
            mat3 TBN = CotangentFrame(N, -V, texcoord);
            return normalize(TBN * map);
        }

        vec4 CalcLightInternal(LightState light, vec3 direction, vec3 normal)
        {
            vec4 mat = (materialState.hasColorAmbient ? materialState.colorAmbient : new vec4(1));
            vec4 AmbientColor = new vec4(light.AmbientColor.rgb * mat.rgb, light.AmbientColor.a * mat.a);
            vec4 DiffuseColor = new vec4(0, 0, 0, 0);
            vec4 SpecularColor = new vec4(0, 0, 0, 0);

            //if (materialState.hasColorDiffuse)
            //{
                float diffuseFactor = max(0.0f, dot(normal, -direction));

                if (diffuseFactor > 0)
                {
                    DiffuseColor = new vec4(light.DiffuseColor.rgb * materialState.colorDiffuse.rgb * diffuseFactor, light.DiffuseColor.a * materialState.colorDiffuse.a);

                    //if (materialState.hasColorSpecular)
                    //{
                        vec3 vertexToEye = normalize(c_position - position);
                        vec3 lv = -direction + vertexToEye;
                        vec3 halfway = lv / length(lv);
                        vec3 PN = PerturbNormal(normalize(normal), -vertexToEye, uv);
                        //vec3 lightReflect = normalize(reflect(direction, normal));
                        float specularFactor = max(0.0f, dot(PN, halfway));

                        if (specularFactor > 0)
                        {
                            specularFactor = pow(specularFactor, materialState.shininess);
                            SpecularColor = new vec4(light.SpecularColor.rgb * materialState.colorSpecular.rgb * materialState.shininessStrength * specularFactor, light.SpecularColor.a * materialState.colorSpecular.a);
                        }
                //}
                }
            //}

            vec4 color = (AmbientColor + DiffuseColor + SpecularColor);

            return  new vec4(color.rgb * light.Intensity, color.a);
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
                FragColor = texture(materialState.textureDiffuse, uv) * _totalLight;
            }
            else
            {
                FragColor = _totalLight;
            }

            //float Ip = 1 / length(ld);
            //vec3 H = normalize(ld + viewport_vector);

            //// Ambient Light Intensity
            //vec4 ambientColorIntensity = colorAmbient; // Ka * Ia

            //// Diffuse Light Intensity
            //vec4 diffuseColorIntensity = colorDiffuse * Ip * max(0, dot(normalize(normal), normalize(ld))); // Kd * Ip * (N.L)
            //diffuseColorIntensity = clamp(diffuseColorIntensity, 0.0f, 1.0f);

            //// Specular Light Intensity
            //vec4 specularColorIntensity = colorSpecular * Ip * pow(max(0, dot(normalize(normal), H)), shininess); // Ks * Ip * (R.V)^n
            //specularColorIntensity = clamp(specularColorIntensity, 0.0f, 1.0f);

            //// Edge detection
            ////Black color if dot product is smaller than 0.3
            ////else keep the same colors
            ////float edgeDetection = (dot(normalize(viewport_vector), normalize(normal)) > 0.3f) ? 1 : 0;

            ////vec4 color = new vec4(edgeDetection * (ambientColorIntensity.rgb + diffuseColorIntensity.rgb + specularColorIntensity.rgb + diffuseTextureIntensity.rgb), opacity * (ambientColorIntensity.a + diffuseColorIntensity.a + specularColorIntensity.a + diffuseTextureIntensity.a));

            ////float intensity = dot(normalize(ld), normalize(normal));

            ////if (intensity > 0.95f)
            ////    color = new vec4(color.rgb * 1.00f, color.a);
            ////else if (intensity < 0.95f && intensity > 0.5f)
            ////    color = new vec4(color.rgb * 0.95f, color.a);
            ////else if (intensity < 0.5f && intensity > 0.25f)
            ////    color = new vec4(color.rgb * 0.5f, color.a);
            ////else if (intensity < 0.25f && intensity > 0.0f)
            ////    color = new vec4(color.rgb * 0.25f, color.a);
            ////else
            ////    color = new vec4(color.rgb * 0.1f, color.a);

            //gl_FragColor = diffuseColorIntensity * new vec4(ambientColorIntensity.rgb + diffuseColorIntensity.rgb + specularColorIntensity.rgb, opacity * min(1.0f, ambientColorIntensity.a + diffuseColorIntensity.a + specularColorIntensity.a));
        }
    }
}
