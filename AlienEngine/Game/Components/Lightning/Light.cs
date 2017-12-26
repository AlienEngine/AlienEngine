using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine
{
    /// <summary>
    /// Light Component.
    /// </summary>
    public class Light : Component
    {
        /// <summary>
        /// The type of this light.
        /// </summary>
        public LightType Type;

        /// <summary>
        /// The ambient light color.
        /// </summary>
        public Color4 AmbientColor;

        /// <summary>
        /// The diffuse color.
        /// </summary>
        public Color4 DiffuseColor;

        /// <summary>
        /// The specular color.
        /// </summary>
        public Color4 SpecularColor;

        /// <summary>
        /// The ambient intensity of this light.
        /// </summary>
        public float Intensity;

        /// <summary>
        /// The light direction.
        /// </summary>
        /// <remarks>
        /// This is used by <see cref="LightType.Directional"/> and <see cref="LightType.Spot"/> lights only.
        /// </remarks>
        public Vector3f Direction
        {
            get
            {
                var r = gameElement.WorldTransform.Rotation;
                return Matrix4f.CreateRotation(MathHelper.Deg2Rad(r.X), MathHelper.Deg2Rad(r.Y), MathHelper.Deg2Rad(r.Z)).ToMatrix3f().Forward;
            }
        }

        /// <summary>
        /// Attenuation factors of the current light.
        /// Set the <see cref="Vector3f.X"/> component to set the constant attenuation.
        /// Set the <see cref="Vector3f.Y"/> component to set the linear attenuation.
        /// Set the <see cref="Vector3f.Z"/> component to set the quadratic attenuation.
        /// </summary>
        /// <remarks>
        /// This is used by <see cref="LightType.Point"/> and <see cref="LightType.Spot"/> lights only.
        /// </remarks>
        public Vector3f AttenuationFactors;

        /// <summary>
        /// Light fall-off exponent.
        /// </summary>
        /// <remarks>
        /// This is used by <see cref="LightType.Spot"/> lights only.
        /// </remarks>
        public float FallOffExponent;

        /// <summary>
        /// Light fall-off angles.
        /// Set the <see cref="Vector2f.X"/> component to set the inner angle (in degrees).
        /// Set the <see cref="Vector2f.Y"/> component to set the outer angle (in degrees).
        /// </summary>
        /// <remarks>
        /// This is used by <see cref="LightType.Spot"/> lights only.
        /// </remarks>
        public Vector2f FallOffAngles;
    }
}
