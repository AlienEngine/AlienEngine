using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Graphics.Buffers.Data
{
    public class MatricesBufferData : UBOData
    {
        // Projection matrix
        private Matrix4f _pMatrix;

        // Inversed Projection matrix
        private Matrix4f _iPMatrix;

        // Camera (view) matrix
        private Matrix4f _vMatrix;

        // Inversed Camera (view) matrix
        private Matrix4f _iVMatrix;
        
        // Cubemap matrix
        private Matrix4f _cmMatrix;

        // Ligth projection matrix
        private Matrix4f _lMatrix;

        // The size of the UBO data.
        public new static int Size => 6 * BlittableValueType<Matrix4f>.Stride;

        /// <summary>
        /// Gets or sets the projection matrix of this ubo.
        /// </summary>
        public Matrix4f Projection
        {
            get { return _pMatrix; }
            set
            {
                if (_pMatrix == value) return;
                _pMatrix = value;
                SetVariableValue("p", ref _pMatrix);
            }
        }

        /// <summary>
        /// Gets or sets the inversed projection matrix of this ubo.
        /// </summary>
        public Matrix4f InversedProjection
        {
            get { return _iPMatrix; }
            set
            {
                if (_iPMatrix == value) return;
                _iPMatrix = value;
                SetVariableValue("i_p", ref _iPMatrix);
            }
        }

        /// <summary>
        /// Gets or sets the view matrix of this ubo.
        /// </summary>
        public Matrix4f View
        {
            get { return _vMatrix; }
            set
            {
                if (_vMatrix == value) return;
                _vMatrix = value;
                SetVariableValue("v", ref _vMatrix);
            }
        }

        /// <summary>
        /// Gets or sets the inversed view matrix of this ubo.
        /// </summary>
        public Matrix4f InversedView
        {
            get { return _iVMatrix; }
            set
            {
                if (_iVMatrix == value) return;
                _iVMatrix = value;
                SetVariableValue("i_v", ref _iVMatrix);
            }
        }
        
        /// <summary>
        /// Gets or sets the cubemap matrix of this ubo.
        /// </summary>
        public Matrix4f Cubemap
        {
            get { return _cmMatrix; }
            set
            {
                if (_cmMatrix == value) return;
                _cmMatrix = value;
                SetVariableValue("cm", ref _cmMatrix);
            }
        }

        /// <summary>
        /// Gets or sets the light space matrix of this ubo.
        /// </summary>
        public Matrix4f LightSpace
        {
            get { return _lMatrix; }
            set
            {
                if (_lMatrix == value) return;
                _lMatrix = value;
                SetVariableValue("lm", ref _lMatrix);
            }
        }

        public MatricesBufferData()
        {
            AddVariable("p", new UBV()
            {
                Offset = 0,
                Type = ShaderUniformType.FloatMat4
            });
            
            AddVariable("i_p", new UBV()
            {
                Offset = 64,
                Type = ShaderUniformType.FloatMat4
            });

            AddVariable("v", new UBV()
            {
                Offset = 128,
                Type = ShaderUniformType.FloatMat4
            });

            AddVariable("i_v", new UBV()
            {
                Offset = 192,
                Type = ShaderUniformType.FloatMat4
            });

            AddVariable("cm", new UBV()
            {
                Offset = 256,
                Type = ShaderUniformType.FloatMat4
            });

            AddVariable("lm", new UBV()
            {
                Offset = 320,
                Type = ShaderUniformType.FloatMat4
            });
        }
    }
}