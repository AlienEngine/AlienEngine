using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlienEngine.ASL
{
    public class ASLShaderCompiler
    {
        #region Constructors

        public ASLShaderCompiler(ASLShader shader)
        {
            _indent = 0;
            _sb = new StringBuilder();
            _shaderSource = shader;
            _emitedStructures = new List<ASLShaderStruct>();

            if (_shaderSource == null)
                return;

            // Compile the shader
            if (ASLShadersCache.ContainsKey(shader.GetType()))
            {
                _sb.Append(ASLShadersCache[shader.GetType()]);
            }
            else
            {
                _compile();
                ASLShadersCache.Add(shader.GetType(), Shader);
            }
        }

        #endregion

        #region Static Members

        internal static Dictionary<Type, string> ASLShadersCache;

        static ASLShaderCompiler()
        {
            ASLShadersCache = new Dictionary<Type, string>();
        }

        internal static KeyValuePair<MethodDefinition, KeyValuePair<string, string>> CreateMethodString(TypeDefinition s, MethodDefinition m)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            if (m == null)
                throw new ArgumentNullException("m");

            var ctx = new DecompilerContext(s.Module)
            {
                CurrentType = s,
                CurrentMethod = m,
                CancellationToken = CancellationToken.None
            };

            var d = AstMethodBodyBuilder.CreateMethodBody(m, ctx);

            var glsl = new ASLShader.GLSLVisitor(d, ctx);

            var sig = ASLShader.GLSLVisitor.GetSignature(m);
            var code = glsl.Result;
            var desc = new KeyValuePair<MethodDefinition, KeyValuePair<string, string>>(
                m,
                new KeyValuePair<string, string>(m.Name, sig + code)
            );

            return desc;
        }

        #endregion

        #region Public Members

        public string Shader
        {
            get { return _sb.ToString(); }
        }

        #endregion

        #region Private Members

        private int _indent;

        private StringBuilder _sb;

        private ASLShader _shaderSource;

        private List<ASLShaderStruct> _emitedStructures;

        void _compile()
        {
            _sb.Length = 0;

            if (_shaderSource.Version != string.Empty)
            {
                _sb.Append("#version ");
                _sb.AppendLine(_shaderSource.Version.ToString());
            }

            foreach (string ext in _shaderSource.GetExtensions())
            {
                _sb.Append("#extension ");
                _sb.AppendLine(ext);
            }

            _emitStructures();
            _emitUniforms();
            _emitInputs();
            _emitOutputs();
            _emitMethods();
        }

        void _emitIndentation()
        {
            const string space = "    ";
            for (int i = 0; i < _indent; i++)
            {
                _sb.Append(space);
            }
        }

        void _emitStructures()
        {
            foreach (var type in _shaderSource.GetStructures())
            {
                _sb.AppendLine();
                _emitStructure(type);
            }
            _sb.AppendLine();
        }

        void _emitStructure(ASLShaderStruct type)
        {
            if (!_emitedStructures.Contains(type))
            {
                if (type.InterfaceType == null)
                    _sb.Append("struct ");
                else if (type.InterfaceType.IsIn())
                    _sb.Append("in ");
                else if (type.InterfaceType.IsOut())
                    _sb.Append("out ");
                else if (type.InterfaceType.IsUniform())
                {
                    if (type.LayoutAttribute != null && type.LayoutAttribute.HasConstructorArguments)
                    {
                        var args = type.LayoutAttribute.ConstructorArguments.First();
                        if (args.Value is IEnumerable<CustomAttributeArgument>)
                        {
                            var parameters = new List<string>();
                            foreach (var arg in (IEnumerable<CustomAttributeArgument>)args.Value)
                            {
                                if (arg.Type.Is<RenderShader.UniformLayout>())
                                {
                                    switch ((RenderShader.UniformLayout)arg.Value)
                                    {
                                        case RenderShader.UniformLayout.Shared:
                                            parameters.Add("shared");
                                            break;
                                        case RenderShader.UniformLayout.Packed:
                                            parameters.Add("packed");
                                            break;
                                        case RenderShader.UniformLayout.STD140:
                                            parameters.Add("std140");
                                            break;
                                        case RenderShader.UniformLayout.RowMajor:
                                            parameters.Add("row_major");
                                            break;
                                        case RenderShader.UniformLayout.ColumnMajor:
                                            parameters.Add("column_major");
                                            break;
                                    }
                                }
                            }
                            _sb.Append(string.Format("layout({0}) ", string.Join(", ", parameters.ToArray())));
                        }
                    }
                    _sb.Append("uniform ");
                }
                else
                    throw new ASLException("ASL Error: An interface block have to have a qualifier which can be in, out or uniform.");

                _sb.AppendLine(type.Name);
                _sb.AppendLine("{");
                _indent++;

                foreach (var field in type.Fields)
                    _emitField(field, true);

                _indent--;
                _sb.AppendLine("};");
                _emitedStructures.Add(type);
            }
        }

        void _emitUniforms()
        {
            foreach (var uniform in _shaderSource.GetUniforms())
                _emitField(uniform);

            _sb.AppendLine();
        }

        void _emitInputs()
        {
            foreach (var input in _shaderSource.GetInputs())
                _emitField(input);

            _sb.AppendLine();
        }

        void _emitOutputs()
        {
            foreach (var output in _shaderSource.GetOutputs())
                _emitField(output);
            _sb.AppendLine();
        }

        void _emitComment(string comment)
        {
            _sb.Append("// ").Append(comment.TrimStart());
        }

        void _emitMethods()
        {
            var shader_type = _shaderSource.GetType();
            var methods = _shaderSource.GetMethods();
            foreach (var method in methods)
            {
                if (method.Key.DeclaringType.MetadataToken.ToInt32() != shader_type.MetadataToken)
                    continue;
                
                _sb.AppendLine();
                _sb.Append(method.Value.Value);
            }
        }

        void _emitField(ASLShaderVariable field, bool fromInterfaceBlock = false)
        {
            if (field.UserComment != string.Empty)
            {
                _emitIndentation();
                _emitComment(field.UserComment);
                _sb.AppendLine();
            }

            _emitIndentation();
            if (fromInterfaceBlock && field.LayoutAttribute != null && field.LayoutAttribute.HasConstructorArguments)
            {
                var args = field.LayoutAttribute.ConstructorArguments.First();
                if (args.Value is IEnumerable<CustomAttributeArgument>)
                {
                    var parameters = new List<string>();
                    foreach (var arg in (IEnumerable<CustomAttributeArgument>)args.Value)
                    {
                        if (arg.Type.Is<RenderShader.UniformLayout>())
                        {
                            switch ((RenderShader.UniformLayout)arg.Value)
                            {
                                case RenderShader.UniformLayout.Shared:
                                    parameters.Add("shared");
                                    break;
                                case RenderShader.UniformLayout.Packed:
                                    parameters.Add("packed");
                                    break;
                                case RenderShader.UniformLayout.STD140:
                                    parameters.Add("std140");
                                    break;
                                case RenderShader.UniformLayout.RowMajor:
                                    parameters.Add("row_major");
                                    break;
                                case RenderShader.UniformLayout.ColumnMajor:
                                    parameters.Add("column_major");
                                    break;
                            }
                        }
                    }
                    _sb.Append(string.Format("layout({0}) ", string.Join(", ", parameters.ToArray())));
                }
            }

            if (field.AttributeType == null)
            {
                _sb.Append(string.Empty);
            }
            else if (field.AttributeType.IsIn())
            {
                if (field.LayoutAttribute != null)
                {
                    if (_shaderSource is VertexShader)
                    {
                        var location = (int)field.LayoutAttribute.Properties.Where(p => p.Name == "Location").First().Argument.Value;
                        _sb.Append(string.Format("layout(location = {0}) ", location));
                    }
                    else if (_shaderSource is FragmentShader)
                    {
                        if (field.LayoutAttribute.HasConstructorArguments)
                        {
                            var inputs = field.LayoutAttribute.ConstructorArguments;
                            var parameters = new List<string>();
                            foreach (var input in inputs)
                            {
                                if (input.Type.Is<FragmentShader.InputLayout>())
                                {
                                    switch ((FragmentShader.InputLayout)input.Value)
                                    {
                                        case FragmentShader.InputLayout.OriginUpperLeft:
                                            parameters.Add("origin_upper_left");
                                            break;
                                        case FragmentShader.InputLayout.PixelCenterInteger:
                                            parameters.Add("pixel_center_integer");
                                            break;
                                    }
                                }
                            }
                            _sb.Append(string.Format("layout({0}) ", string.Join(", ", parameters.ToArray())));
                        }
                    }
                    else if (_shaderSource is GeometryShader)
                    {
                        if (field.LayoutAttribute.HasConstructorArguments)
                        {
                            var input = field.LayoutAttribute.ConstructorArguments.First();
                            if (input.Type.Is<GeometryShader.InputLayout>())
                            {
                                switch ((GeometryShader.InputLayout)input.Value)
                                {
                                    case GeometryShader.InputLayout.Points:
                                        _sb.Append("layout(points) in;");
                                        break;
                                    case GeometryShader.InputLayout.Lines:
                                        _sb.Append("layout(lines) in;");
                                        break;
                                    case GeometryShader.InputLayout.LinesAdjacency:
                                        _sb.Append("layout(lines_adjacency) in;");
                                        break;
                                    case GeometryShader.InputLayout.Triangles:
                                        _sb.Append("layout(triangles) in;");
                                        break;
                                    case GeometryShader.InputLayout.TrianglesAdjacency:
                                        _sb.Append("layout(triangles_adjacency) in;");
                                        break;
                                }
                                _sb.AppendLine();
                                return;
                            }
                        }
                    }
                }
                _sb.Append("in ");
            }
            else if (field.AttributeType.IsOut())
            {
                if (field.LayoutAttribute != null)
                {
                    if (_shaderSource is FragmentShader)
                    {
                        var layouts = new List<string>();
                        var locationProp = field.LayoutAttribute.Properties.Where(p => p.Name == "Location");
                        var indexProp = field.LayoutAttribute.Properties.Where(p => p.Name == "Index");
                        if (locationProp.Count() > 0)
                            layouts.Add("location = " + (int)locationProp.First().Argument.Value);
                        if (indexProp.Count() > 0)
                            layouts.Add("index = " + (int)indexProp.First().Argument.Value);
                        _sb.Append(string.Format("layout({0}) ", string.Join(", ", layouts.ToArray())));
                    }
                    else if (_shaderSource is GeometryShader)
                    {
                        if (field.LayoutAttribute.HasConstructorArguments)
                        {
                            var input = field.LayoutAttribute.ConstructorArguments.First();
                            if (input.Type.Is<GeometryShader.OutputLayout>())
                            {
                                switch ((GeometryShader.OutputLayout)input.Value)
                                {
                                    case GeometryShader.OutputLayout.Points:
                                        _sb.Append("layout(points) out;");
                                        break;
                                    case GeometryShader.OutputLayout.LineStrip:
                                        _sb.Append("layout(line_strip) out;");
                                        break;
                                    case GeometryShader.OutputLayout.TriangleStrip:
                                        _sb.Append("layout(triangle_strip) out;");
                                        break;
                                }
                                _sb.AppendLine();
                                return;
                            }
                        }
                    }
                }
                _sb.Append("out ");
            }
            else if (field.AttributeType.IsUniform())
            {
                if (field.LayoutAttribute != null && field.LayoutAttribute.HasConstructorArguments)
                {
                    var args = field.LayoutAttribute.ConstructorArguments.First();
                    if (args.Value is IEnumerable<CustomAttributeArgument>)
                    {
                        var parameters = new List<string>();
                        foreach (var arg in (IEnumerable<CustomAttributeArgument>)args.Value)
                        {
                            if (arg.Type.Is<RenderShader.UniformLayout>())
                            {
                                switch ((RenderShader.UniformLayout)arg.Value)
                                {
                                    case RenderShader.UniformLayout.Shared:
                                        parameters.Add("shared");
                                        break;
                                    case RenderShader.UniformLayout.Packed:
                                        parameters.Add("packed");
                                        break;
                                    case RenderShader.UniformLayout.STD140:
                                        parameters.Add("std140");
                                        break;
                                    case RenderShader.UniformLayout.RowMajor:
                                        parameters.Add("row_major");
                                        break;
                                    case RenderShader.UniformLayout.ColumnMajor:
                                        parameters.Add("column_major");
                                        break;
                                }
                            }
                        }
                        _sb.AppendLine(string.Format("layout({0}) uniform;", string.Join(", ", parameters.ToArray())));
                        return;
                    }
                }
                _sb.Append("uniform ");
            }
            else
            {
                throw new ASLException("ASL Error: An error occured when evaluating the qualifier of the variable \"" + field.Name + "\".");
            }

            _sb.Append(field.Type);
            _sb.Append(" ");
            _sb.Append(field.Name);

            if (field.IsArray)
            {
                _sb.Append("[");
                _sb.Append(field.ArraySize);
                _sb.Append("]");
            }

            _sb.Append("; ");

            if (field.DebugComment != string.Empty)
                _emitComment(field.DebugComment);

            _sb.AppendLine();
        }

        #endregion
    }
}
