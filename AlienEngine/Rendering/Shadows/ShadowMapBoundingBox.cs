using System.Collections.Generic;

namespace AlienEngine.Core.Rendering.Shadows
{
    public struct ShadowMapBoundingBox
    {
        private BoundingBox _internalBoundingBox;

        private Matrix4f _lightViewMatrix;

        private Matrix4f _lightProjectionMatrix;

        /// <summary>
        /// Location with the lowest X, Y, and Z coordinates in the axis-aligned bounding box.
        /// </summary>
        public Vector3f Min => _internalBoundingBox.Min;

        /// <summary>
        /// Location with the highest X, Y, and Z coordinates in the axis-aligned bounding box.
        /// </summary>
        public Vector3f Max => _internalBoundingBox.Max;

        public Matrix4f LightSpaceMatrix => Matrix4f.CreateTranslation(-GetCenter()) * _lightViewMatrix * _lightProjectionMatrix;

        public ShadowMapBoundingBox(Camera camera, Light light, float n, float f)
        {
            _lightProjectionMatrix = Matrix4f.Identity;
            _lightViewMatrix = Matrix4f.Identity;

            float fov = camera.FieldOfView,
                near = camera.Near,
                far = camera.Far,
                ratio = camera.Viewport.Width / camera.Viewport.Height;

            switch (light.Type)
            {
                case LightType.Directional:
                    _lightViewMatrix = Matrix4f.LookAt(light.Direction, VectorHelper.Up);
                    break;

                case LightType.Point:
                    _lightViewMatrix = Matrix4f.LookAt(light.Direction, VectorHelper.Up);
                    break;
                
                case LightType.Spot:
                    _lightViewMatrix = Matrix4f.CreateTranslation(light.GetGameElement().WorldTransform.Translation) * Matrix4f.LookAt(light.Direction, VectorHelper.Up);
                    break;
            }

            Matrix4f lightCameraProjection = Matrix4f.CreatePerspectiveFieldOfView(MathHelper.Deg2Rad(fov), ratio,
                near + ((far - near) * n), ((far - near) * f) + near);

            Matrix4f invCameraViewProjection = (camera.ViewMatrix * lightCameraProjection).Inversed;

            Vector4f[] worldSpaceCorners = new Vector4f[8]
            {
                new Vector4f(-1.0f, -1.0f, 1.0f, 1.0f),
                new Vector4f(-1.0f, -1.0f, -1.0f, 1.0f),
                new Vector4f(-1.0f, 1.0f, 1.0f, 1.0f),
                new Vector4f(-1.0f, 1.0f, -1.0f, 1.0f),
                new Vector4f(1.0f, -1.0f, 1.0f, 1.0f),
                new Vector4f(1.0f, -1.0f, -1.0f, 1.0f),
                new Vector4f(1.0f, 1.0f, 1.0f, 1.0f),
                new Vector4f(1.0f, 1.0f, -1.0f, 1.0f)
            };

            Vector3f[] lightSpaceCorners = new Vector3f[8];

            for (int c = 0; c < 8; c++)
            {
                worldSpaceCorners[c] = worldSpaceCorners[c] * invCameraViewProjection;
                worldSpaceCorners[c] = worldSpaceCorners[c] / worldSpaceCorners[c].W;
                worldSpaceCorners[c] = Vector4f.Transform(worldSpaceCorners[c], _lightViewMatrix);
                lightSpaceCorners[c] = worldSpaceCorners[c].XYZ;
            }

            _internalBoundingBox = BoundingBox.CreateFromPoints(lightSpaceCorners);

            Vector3f extents = new Vector3f(Max.X - Min.X, Max.Y - Min.Y, Max.Z - Min.Z);
            Vector3f he = extents * 0.5f;

            switch (light.Type)
            {
                case LightType.Directional:
                    _lightProjectionMatrix = Matrix4f.CreateOrthographic(extents.X, extents.Y, -he.Z, he.Z);
                    break;

                case LightType.Point:
                    _lightProjectionMatrix = Matrix4f.CreateOrthographic(extents.X, extents.Y, -he.Z, he.Z);
                    break;

                case LightType.Spot:
                    _lightProjectionMatrix = Matrix4f.CreatePerspectiveFieldOfView(MathHelper.Deg2Rad(light.FallOffAngles.Y), extents.X / extents.Y, 0.1f, he.Z);
                    break;
            }
        }

        /// <summary>
        /// Gets an array of locations corresponding to the 8 corners of the bounding box.
        /// </summary>
        /// <returns>Corners of the bounding box.</returns>
        public Vector3f[] GetCorners()
        {
            return _internalBoundingBox.GetCorners();
        }

        public Vector3f GetCenter()
        {
            Vector4f center =
                Vector4f.Transform(
                    new Vector4f((Min.X + Max.X) * 0.5f, (Min.Y + Max.Y) * 0.5f, (Min.Z + Max.Z) * 0.5f, 1.0f),
                    _lightViewMatrix.Inversed);
            return center.XYZ / center.W;
        }
    }
}