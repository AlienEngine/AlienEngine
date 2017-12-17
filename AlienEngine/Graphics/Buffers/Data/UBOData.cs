using System.Collections.Generic;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Graphics.Buffers.Data
{
    /// <summary>
    /// Manages data used by uniform buffer objects.
    /// </summary>
    public abstract class UBOData
    {
        // The collection of variables.
        private readonly Dictionary<string, UBV> _variablesCollection;

        // The collection of uniform buffer objects who use this data.
        private readonly List<UBO> _registeredUbos;

        /// <summary>
        /// The size of data in bytes.
        /// </summary>
        public static int Size => 0;
        
        /// <summary>
        /// Initialize
        /// </summary>
        protected UBOData()
        {
            _registeredUbos = new List<UBO>();
            _variablesCollection = new Dictionary<string, UBV>();
        }

        /// <summary>
        /// Adds a variable descriptor to this uniform buffer object data.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="variable">The variable description.</param>
        protected void AddVariable(string name, UBV variable)
        {
            if (!_variablesCollection.ContainsKey(name))
                _variablesCollection.Add(name, variable);
        }
        
        /// <summary>
        /// Register a new uniform buffer object to use this data.
        /// </summary>
        /// <param name="ubo">The UBO to register.</param>
        public void RegisterUBO(UBO ubo)
        {
            if (!_registeredUbos.Contains(ubo))
                _registeredUbos.Add(ubo);
        }

        /// <summary>
        /// Sets a variable's value.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value.</param>
        protected void SetVariableValue(string name, ref Matrix4f value)
        {
            UBV variable;
            if (!_variablesCollection.TryGetValue(name, out variable)) return;
            
            variable.CheckType(ShaderUniformType.FloatMat4);

            foreach (var ubo in _registeredUbos)
                ubo.SetBufferSubData(variable.Offset, ref value);
        }
    }
}