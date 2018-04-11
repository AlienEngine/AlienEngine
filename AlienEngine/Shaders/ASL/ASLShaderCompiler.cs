using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.TypeSystem;
using Mono.Cecil;

namespace AlienEngine.Shaders.ASL
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
                throw new ArgumentNullException(nameof(s));

            if (m == null)
                throw new ArgumentNullException(nameof(m));

            var settings = new DecompilerSettings()
            {
                DecompileMemberBodies = true,
                UsingStatement = false,
                UsingDeclarations = false,
                MakeAssignmentExpressions = true,
                ExpressionTrees = true
            };
            settings.CSharpFormattingOptions.SpaceBeforeMethodCallParentheses = false;
            var typeSys = new DecompilerTypeSystem(m.Module);

            var decompiler = new CSharpDecompiler(typeSys, settings)
            {
                CancellationToken = CancellationToken.None
            };
            
            var tree = decompiler.Decompile(m);

            BlockStatement methodBody = BlockStatement.Null;
            
            foreach (AstNode node in tree.Members)
            {
                if (node is MethodDeclaration methodDeclaration)
                {
                    methodBody = methodDeclaration.Body;
                    break;
                }

                if (node is ConstructorDeclaration constructorDeclaration)
                {
                    methodBody = constructorDeclaration.Body;
                }
            }
            
            if (methodBody == BlockStatement.Null)
                throw new Exception("Unable to find a method declaration in the syntax tree.");
            
            var glsl = new ASLShader.GLSLVisitor(methodBody, null);

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

        public string Shader => _sb.ToString();

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
                _sb.AppendLine(_shaderSource.Version);
            }

            foreach (string ext in _shaderSource.GetExtensions())
            {
                _sb.Append("#extension ");
                _sb.AppendLine(ext);
            }

            if (_shaderSource is GeometryShader)
            {
                _sb.AppendLine();
                var input = _shaderSource.GetType().GetCustomAttributes(typeof(GeometryShader.LayoutInAttribute), true).Select(a => a as GeometryShader.LayoutInAttribute).ToList();
                if (input.Count > 0)
                {
                    switch (input.First().InputID)
                    {
                        case GeometryShader.InputLayout.Points:
                            _sb.AppendLine("layout(points) in;");
                            break;
                        case GeometryShader.InputLayout.Lines:
                            _sb.AppendLine("layout(lines) in;");
                            break;
                        case GeometryShader.InputLayout.LinesAdjacency:
                            _sb.AppendLine("layout(lines_adjacency) in;");
                            break;
                        case GeometryShader.InputLayout.Triangles:
                            _sb.AppendLine("layout(triangles) in;");
                            break;
                        case GeometryShader.InputLayout.TrianglesAdjacency:
                            _sb.AppendLine("layout(triangles_adjacency) in;");
                            break;
                    }
                }

                var output = _shaderSource.GetType().GetCustomAttributes(typeof(GeometryShader.LayoutOutAttribute), true).Select(a => a as GeometryShader.LayoutOutAttribute).ToList();
                if (output.Count > 0)
                {
                    switch (output.First().OutputID)
                    {
                        case GeometryShader.OutputLayout.Points:
                            _sb.AppendLine("layout(points) out;");
                            break;
                        case GeometryShader.OutputLayout.LineStrip:
                            _sb.AppendLine("layout(line_strip) out;");
                            break;
                        case GeometryShader.OutputLayout.TriangleStrip:
                            _sb.AppendLine("layout(triangle_strip) out;");
                            break;
                    }
                }
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
                            foreach (var arg in (IEnumerable<CustomAttributeArgument>) args.Value)
                            {
                                if (arg.Type.Is<RenderShader.UniformLayout>())
                                {
                                    switch ((RenderShader.UniformLayout) arg.Value)
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

                            _sb.Append($"layout({string.Join(", ", parameters.ToArray())}) ");
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
                _sb.AppendLine($"}} {type.InterfaceBlockNamespace};");
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
                    foreach (var arg in (IEnumerable<CustomAttributeArgument>) args.Value)
                    {
                        if (arg.Type.Is<RenderShader.UniformLayout>())
                        {
                            switch ((RenderShader.UniformLayout) arg.Value)
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

                    _sb.Append($"layout({string.Join(", ", parameters.ToArray())}) ");
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
                        var location = (int) field.LayoutAttribute.Properties.First(p => p.Name == "Location").Argument.Value;
                        _sb.Append($"layout(location = {location}) ");
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
                                    switch ((FragmentShader.InputLayout) input.Value)
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

                            _sb.Append($"layout({string.Join(", ", parameters.ToArray())}) ");
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
                        if (locationProp.Any())
                            layouts.Add("location = " + (int) locationProp.First().Argument.Value);
                        if (indexProp.Any())
                            layouts.Add("index = " + (int) indexProp.First().Argument.Value);
                        _sb.Append($"layout({string.Join(", ", layouts.ToArray())}) ");
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
                        foreach (var arg in (IEnumerable<CustomAttributeArgument>) args.Value)
                        {
                            if (arg.Type.Is<RenderShader.UniformLayout>())
                            {
                                switch ((RenderShader.UniformLayout) arg.Value)
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

                        _sb.AppendLine($"layout({string.Join(", ", parameters.ToArray())}) uniform;");
                        return;
                    }
                }

                _sb.Append("uniform ");
            }
            else
            {
                throw new ASLException($"ASL Error: An error occured when evaluating the qualifier of the variable \"{field.Name}\".");
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