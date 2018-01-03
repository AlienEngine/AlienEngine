using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Graphics.Buffers.Data
{
    public class CameraBufferData: UBOData
    {
        // Camera position
        private Vector3f _position;
        
        // Camera orientation
        private Vector3f _rotation;

        // Camera Near and Far planes distances
        private Vector2f _depthDistances;

        // The size of this UBO data
        public new static int Size => 2 * BlittableValueType<Vector3f>.Stride + BlittableValueType<Vector2f>.Stride;

        /// <summary>
        /// Gets or sets the position vector of this ubo.
        /// </summary>
        public Vector3f Position
        {
            get { return _position; }
            set
            {
                if (_position == value) return;
                _position = value;
                SetVariableValue("position", ref _position);
            }
        }

        /// <summary>
        /// Gets or sets the rotation vector of this ubo.
        /// </summary>
        public Vector3f Rotation
        {
            get { return _rotation; }
            set
            {
                if (_rotation == value) return;
                _rotation = value;
                SetVariableValue("rotation", ref _rotation);
            }
        }

        /// <summary>
        /// Gets or sets the projection matrix of this ubo.
        /// </summary>
        public Vector2f DepthDistances
        {
            get { return _depthDistances; }
            set
            {
                if (_depthDistances == value) return;
                _depthDistances = value;
                SetVariableValue("depthDistances", ref _depthDistances);
            }
        }

        public CameraBufferData()
        {
            AddVariable("position", new UBV()
            {
                Offset = 0,
                Type = ShaderUniformType.FloatVec3
            });

            AddVariable("rotation", new UBV()
            {
                Offset = 16,
                Type = ShaderUniformType.FloatVec3
            });

            AddVariable("depthDistances", new UBV()
            {
                Offset = 32,
                Type = ShaderUniformType.FloatVec2
            });
        }

    }
}
