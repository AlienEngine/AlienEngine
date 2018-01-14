using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AlienEngine.Core.Graphics.Buffers;
using AlienEngine.Core.Graphics.Buffers.Data;
using AlienEngine.Core.Rendering;

namespace AlienEngine.Core.Shaders
{
    public class ShaderProgram : IDisposable
    {
        #region Private Members

        private string _vertexSource;
        private string _fragmentSource;
        private string _geometrySource;
        private string _tessControlSource;
        private string _tessEvaluationSource;
        private uint _program = 0;
        private Dictionary<string, int> _uniformLocationsCache;
        private Dictionary<string, object> _valuesMap;
        private static ShaderProgram _current;
        private bool _compiled;
        private Dictionary<string, string> _globals = new Dictionary<string, string>();
        private uint _vertexShaderHandle;
        private uint _tessEShaderHandle;
        private uint _tessCShaderHandle;
        private uint _fragmentShaderHandle;
        private uint _geometryShaderHandle;

        private int _getUniformLocation(string name)
        {
            if (_program == 0)
                return -1;
            if (_uniformLocationsCache.ContainsKey(name))
                return _uniformLocationsCache[name];

            int location = GL.GetUniformLocation(_program, name);
            _uniformLocationsCache.Add(name, location);
            return location;
        }

        private bool _checkCache(string key, object value)
        {
            if (!_valuesMap.ContainsKey(key))
            {
                _valuesMap.Add(key, value);
                return true;
            }
            else
            {
                if (_valuesMap[key] == value)
                    return false;
                else
                    return true;
            }
        }

        private uint _compileSingleShader(ShaderType type, string source)
        {
            uint shader = GL.CreateShader(type);

            // Normalize line ending
            source = string.Join ("\n", source.Split (new char[] { '\r', '\n' }));

            StringBuilder globalsString = new StringBuilder ();
            foreach (var g in _globals)
                globalsString.AppendLine("#define " + g.Key + " " + g.Value);

            string fullsrc = Regex.Replace (source, @"\#version (.+)\n", "#version $1\n" + globalsString);

            GL.ShaderSource(shader, fullsrc);

            GL.CompileShader(shader);

            var ostr = GL.GetShaderInfoLog(shader).Trim();
            if (ostr.Length > 0)
                Console.WriteLine(ostr);
            int status_code;
            GL.GetShaderi(shader, ShaderParameter.CompileStatus, out status_code);
            if (status_code != 1)
                throw new ApplicationException("Compilation error");
            return shader;
        }

        private void _compile()
        {
            // Setting default globals
            SetGlobal(GL.MAX_NUMBER_OF_LIGHTS, Math.Max(1, Game.Game.Instance.CurrentScene.Lights.Length).ToString());

            _program = GL.CreateProgram();

            Console.WriteLine("Compiling vertex shader");
            _vertexShaderHandle = _compileSingleShader(ShaderType.VertexShader, _vertexSource);
            GL.AttachShader(_program, _vertexShaderHandle);

            if (!string.IsNullOrEmpty(_fragmentSource))
            {
                Console.WriteLine("Compiling fragment shader");
                _fragmentShaderHandle = _compileSingleShader(ShaderType.FragmentShader, _fragmentSource);
                GL.AttachShader(_program, _fragmentShaderHandle);
            }

            if (!string.IsNullOrEmpty(_tessControlSource) && !string.IsNullOrEmpty(_tessEvaluationSource))
            {
                Console.WriteLine("Compiling tesselation control shader");
                _tessCShaderHandle = _compileSingleShader(ShaderType.TessControlShader, _tessControlSource);
                GL.AttachShader(_program, _tessCShaderHandle);

                Console.WriteLine("Compiling tesselation evaluation shader");
                _tessEShaderHandle = _compileSingleShader(ShaderType.TessEvaluationShader, _tessEvaluationSource);
                GL.AttachShader(_program, _tessEShaderHandle);
                GL.PatchParameteri(PatchParameterInt.PatchVertices, 3);

                UseTesselation = true;
            }

            if (!string.IsNullOrEmpty(_geometrySource))
            {
                Console.WriteLine("Compiling geometry shader");
                _geometryShaderHandle = _compileSingleShader(ShaderType.GeometryShader, _geometrySource);
                GL.AttachShader(_program, _geometryShaderHandle);
            }

            GL.LinkProgram(_program);
            var ostr = GL.GetProgramInfoLog(_program).Trim();
            if (ostr.Length > 0)
                Console.WriteLine(ostr);

            int status_code;
            GL.GetProgrami(_program, GetProgramParameterName.LinkStatus, out status_code);
            if (status_code != 1)
                throw new ApplicationException("Linking error");

            GL.UseProgram(_program);

            ostr = GL.GetProgramInfoLog(_program).Trim();
            if (ostr.Length > 0)
                Console.WriteLine(ostr);

            _compiled = true;

            OnCompile?.Invoke();
        }

        private void _create(string vertexShader, string fragmentShader = null, string geometryShader = null, string tesscontrolShader = null, string tessevalShader = null)
        {
            _vertexSource = vertexShader;
            _fragmentSource = fragmentShader;
            _geometrySource = geometryShader;
            _tessControlSource = tesscontrolShader;
            _tessEvaluationSource = tessevalShader;
            _compiled = false;
            _uniformLocationsCache = new Dictionary<string, int>();
            _valuesMap = new Dictionary<string, object>();

            OnCompile += _onCompile;
            
            ResourcesManager.AddDisposableResource(this);
        }

        private void _onCompile()
        {
            RendererManager.MatricesUBO.Bind(this);
        }

        #endregion

        #region Constructors

        public ShaderProgram(string vertexShader, string fragmentShader = null, string geometryShader = null, string tesscontrolShader = null, string tessevalShader = null)
        {
            _create(vertexShader, fragmentShader, geometryShader, tesscontrolShader, tessevalShader);
        }

        public ShaderProgram(VertexShader vertexShader, FragmentShader fragmentShader = null, GeometryShader geometryShader = null, TessellationControlShader tesscontrolShader = null, TessellationEvaluationShader tessevalShader = null)
        {
            _create(new ASLShaderCompiler(vertexShader).Shader, new ASLShaderCompiler(fragmentShader).Shader, new ASLShaderCompiler(geometryShader).Shader, new ASLShaderCompiler(tesscontrolShader).Shader, new ASLShaderCompiler(tessevalShader).Shader);
        }

        #endregion

        #region Static Members

        public static ShaderProgram Compile(string vertexShader, string fragmentShader = null, string geometryShader = null, string tesscontrolShader = null, string tessevalShader = null)
        {
            return new ShaderProgram(vertexShader, fragmentShader, geometryShader, tesscontrolShader, tessevalShader);
        }

        public static ShaderProgram Compile(VertexShader vertexShader, FragmentShader fragmentShader = null, GeometryShader geometryShader = null, TessellationControlShader tesscontrolShader = null, TessellationEvaluationShader tessevalShader = null)
        {
            return new ShaderProgram(vertexShader, fragmentShader, geometryShader, tesscontrolShader, tessevalShader);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Event triggered when this <see cref="ShaderProgram"/> has been compiled.
        /// </summary>
        public event Action OnCompile;

        public enum SwitchResult
        {
            Switched,
            AlreadyInUse,
            Locked
        }

        /// <summary>
        /// Specifies the OpenGL shader program ID.
        /// </summary>
        [CLSCompliant(false)]
        public uint ID { get { return _program; } }

        /// <summary>
        /// Specifies the current shader program used.
        /// </summary>
        public static ShaderProgram CurrentProgram { get { return _current; } }

        public bool Compiled { get { return _compiled; } }

        public Dictionary<string, string> Globals { get { return _globals; } }

        public bool UseTesselation { get; private set; }

        public SwitchResult Bind()
        {
            if (!_compiled)
                _compile();
            if (_current == this)
                return SwitchResult.AlreadyInUse;
            GL.UseProgram(_program);
            _current = this;
            return SwitchResult.Switched;
        }

        public SwitchResult Unbind()
        {
            if (!_compiled)
                _compile();
            if (_current == null)
                return SwitchResult.AlreadyInUse;
            GL.UseProgram(0);
            _current = null;
            return SwitchResult.Switched;
        }

        public void RemoveGlobal(string key)
        {
            if (_globals.ContainsKey(key))
                _globals.Remove(key);
        }

        public void SetGlobal(string key, string value)
        {
            if (_globals.ContainsKey(key))
                _globals[key] = value;
            else
                _globals.Add(key, value);
        }

        public void SetUniform(string name, Matrix4f data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.UniformMatrix4(location, data);
        }

        public void SetUniform(string name, Matrix3f data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.UniformMatrix3(location, data);
        }

        public void SetUniform(string name, bool data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform1i(location, data ? 1 : 0);
        }

        public void SetUniform(string name, float data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform1f(location, data);
        }

        public void SetUniform(string name, double data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform1d(location, data);
        }

        [CLSCompliant(false)]
        public void SetUniform(string name, uint data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform1ui(location, data);
        }

        public void SetUniform(string name, int data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform1i(location, data);
        }

        public void SetUniform(string name, Vector2f data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform2(location, data);
        }

        public void SetUniform(string name, Color3 data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform3(location, data);
        }

        public void SetUniform(string name, Vector3f data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform3(location, data);
        }

        public void SetUniform(string name, Color4 data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform4(location, data);
        }

        public void SetUniform(string name, Vector4f data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform4(location, data);
        }

        public void SetUniform(string name, Quaternion data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform4(location, data);
        }

        public void SetUniform(string name, long data)
        {
            int location = _getUniformLocation(name);
            // silly c# :)
            var bytes = BitConverter.GetBytes(data);
            var ui64_1 = BitConverter.ToUInt32(bytes, 0);
            var ui64_2 = BitConverter.ToUInt32(bytes, 4);
            if (location >= 0 && _checkCache(name, data) && data > 0)
                GL.Uniform2ui(location, ui64_1, ui64_2);
        }

        public void SetUniformArray(string name, Matrix4f[] data)
        {
            int location = _getUniformLocation(name);
            List<float> floats = new List<float>();
            foreach (var v in data)
                foreach (var i in v.ToArray())
                    floats.Add(i);

            if (location >= 0 && _checkCache(name, data))
                GL.UniformMatrix4fv(location, data.Length, false, floats.ToArray());
        }

        public void SetUniformArray(string name, Vector3f[] data)
        {
            int location = _getUniformLocation(name);
            List<float> floats = new List<float>();
            foreach (var v in data)
                foreach (var i in v.ToArray())
                    floats.Add(i);

            if (location >= 0 && _checkCache(name, data))
                GL.Uniform3fv(location, data.Length, floats.ToArray());
        }

        public bool SetUniformArray(string name, long[] data)
        {
            int location = _getUniformLocation(name);
            List<uint> floats = new List<uint>();

            foreach (var v in data)
            {
                if (v == 0)
                    return false;
                var bytes = BitConverter.GetBytes(v);
                var ui64_1 = BitConverter.ToUInt32(bytes, 0);
                var ui64_2 = BitConverter.ToUInt32(bytes, 4);
                floats.Add(ui64_1);
                floats.Add(ui64_2);
            }

            if (location >= 0 && _checkCache(name, data))
            {
                GL.Uniform2uiv(location, data.Length, floats.ToArray());
                return true;
            }

            return false;
        }

        public void SetUniformArray(string name, Vector2f[] data)
        {
            int location = _getUniformLocation(name);
            List<float> floats = new List<float>();
            foreach (var v in data)
                foreach (var i in v.ToArray())
                    floats.Add(i);

            if (location >= 0 && _checkCache(name, data))
                GL.Uniform2fv(location, data.Length, floats.ToArray());
        }

        public void SetUniformArray(string name, Vector4f[] data)
        {
            int location = _getUniformLocation(name);
            List<float> floats = new List<float>();

            foreach (var v in data)
                foreach (var i in v.ToArray())
                    floats.Add(i);

            if (location >= 0 && _checkCache(name, data))
                GL.Uniform4fv(location, data.Length, floats.ToArray());
        }

        public void SetUniformArray(string name, float[] data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform1fv(location, data.Length, data);
        }

        public void SetUniformArray(string name, int[] data)
        {
            int location = _getUniformLocation(name);
            if (location >= 0 && _checkCache(name, data))
                GL.Uniform1iv(location, data.Length, data);
        }

        #endregion

        #region IDisposable

        ~ShaderProgram()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (ID != 0)
            {
                // Make sure this program isn't being used
                if (CurrentProgram != null && CurrentProgram.ID == ID) Unbind();

                GL.DetachShader(ID, _vertexShaderHandle);
                GL.DetachShader(ID, _fragmentShaderHandle);
                GL.DetachShader(ID, _geometryShaderHandle);
                if (UseTesselation)
                {
                    GL.DetachShader(ID, _tessCShaderHandle);
                    GL.DetachShader(ID, _tessEShaderHandle);
                }
                GL.DeleteProgram(ID);

                _program = 0;
            }
        }

        #endregion
    }
}
