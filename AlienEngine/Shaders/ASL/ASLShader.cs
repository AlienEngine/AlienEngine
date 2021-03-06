using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using System.Collections.Generic;

namespace AlienEngine.Shaders.ASL
{
    public abstract partial class ASLShader
    {
        [BuiltIn]
        protected struct gl_DepthRangeParameters
        {
            [BuiltIn]
            public readonly float near;
            [BuiltIn]
            public readonly float far;
            [BuiltIn]
            public readonly float diff;
        }

        [Uniform]
        [BuiltIn]
        protected readonly gl_DepthRangeParameters gl_DepthRange;

        [Uniform]
        [BuiltIn]
        protected readonly int gl_NumSamples;

        [BuiltIn]
        protected const int gl_MaxClipDistances = 8;

        [BuiltIn]
        protected const int gl_MaxClipPlanes = 8;

        [BuiltIn]
        protected const int gl_MaxDrawBuffers = 8;

        [BuiltIn]
        protected const int gl_MaxTextureUnits = 2;

        [BuiltIn]
        protected const int gl_MaxTextureCoords = 2;

        [BuiltIn]
        protected const int gl_MaxGeometryTextureImageUnits = 16;

        [BuiltIn]
        protected const int gl_MaxTextureImageUnits = 16;

        [BuiltIn]
        protected const int gl_MaxVertexAttribs = 16;

        [BuiltIn]
        protected const int gl_MaxVertexTextureImageUnits = 16;

        [BuiltIn]
        protected const int gl_MaxCombinedTextureImageUnits = 48;

        [BuiltIn]
        protected const int gl_MaxGeometryVaryingComponents = 64;

        [BuiltIn]
        protected const int gl_MaxVaryingComponents = 64;

        [BuiltIn]
        protected const int gl_MaxVaryingFloats = 64;

        [BuiltIn]
        protected const int gl_MaxGeometryOutputVertices = 256;

        [BuiltIn]
        protected const int gl_MaxFragmentUniformComponents = 1024;

        [BuiltIn]
        protected const int gl_MaxGeometryTotalOutputComponents = 1024;

        [BuiltIn]
        protected const int gl_MaxGeometryUniformComponents = 1024;

        [BuiltIn]
        protected const int gl_MaxVertexUniformComponents = 1024;

        private const BindingFlags _flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.FlattenHierarchy;

        private TypeDefinition _shader;

        public ASLShader()
        {
            _shader = _loadReflection();
        }

        private static readonly Dictionary<string, string> _globalNames = new Dictionary<string, string>();

        public static readonly string DefaultShaderVersion = "330 core";

        public static readonly bool DefaultDebugBehavior = false;

        internal string Version
        {
            get
            {
                var attr = GetType().GetCustomAttributes(typeof(VersionAttribute), true).Select(a => a as VersionAttribute).ToList();
                return attr.Count > 0 ? attr.First().Version : DefaultShaderVersion;
            }
        }

        internal bool DebugMode
        {
            get
            {
                var attr = GetType().GetCustomAttributes(typeof(DebugAttribute), true).Select(a => a as DebugAttribute).ToList();
                return attr.Count > 0 ? attr.First().Debug : DefaultDebugBehavior;
            }
        }

        internal IEnumerable<string> GetExtensions()
        {
            var attr = GetType().GetCustomAttributes(typeof(ExtensionAttribute), true).Select(a => a as ExtensionAttribute).ToList();
            if (attr.Count > 0)
                foreach (var ext in attr)
                    yield return ext.ExtensionName;
            else
                yield break;
        }

        internal IEnumerable<ASLShaderVariable> GetUniforms()
        {
            foreach (var field in _shader.Fields)
            {
                if (field.HasCustomAttributes)
                {
                    var attrs = field.CustomAttributes.Where(a => a.AttributeType.IsUniform() && !a.AttributeType.IsBuiltIn());
                    var customAttributes = attrs as CustomAttribute[] ?? attrs.ToArray();
                    if (customAttributes.Any())
                    {
                        var attr = customAttributes.First();
                        var isArray = field.FieldType.IsArray;
                        var type = GLSL.ToGLSL(isArray ? field.FieldType.Name.Trim('[', ']') : field.FieldType.Name);
                        var arrayAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<ArraySizeAttribute>());
                        var attributes = arrayAttr as CustomAttribute[] ?? arrayAttr.ToArray();
                        var arraySize = (isArray && attributes.Any() && attributes.First().HasConstructorArguments) ? attributes.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                        var name = field.Name;
                        var commentAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<CommentAttribute>());
                        var userComments = commentAttr as CustomAttribute[] ?? commentAttr.ToArray();
                        var uComments = (userComments.Any() && userComments.First().HasConstructorArguments) ? userComments.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                        var dComments = DebugMode ? field.DeclaringType.FullName + "." + field.Name : string.Empty;
                        var layoutAttr = (this is VertexShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<VertexShader.LayoutAttribute>()) :
                            ((this is FragmentShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<FragmentShader.LayoutAttribute>()) :
                            ((this is GeometryShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<GeometryShader.LayoutAttribute>()) : null));
                        var layoutAttributes = layoutAttr as CustomAttribute[] ?? layoutAttr.ToArray();
                        var layout = (layoutAttributes.Any()) ? layoutAttributes.First() : null;
                        yield return new ASLShaderVariable(type, isArray, arraySize, name, uComments, dComments, attr.AttributeType, layout);
                    }
                }
            }
        }

        internal IEnumerable<ASLShaderVariable> GetInputs()
        {
            foreach (var field in _shader.Fields)
            {
                if (field.HasCustomAttributes)
                {
                    var attrs = field.CustomAttributes.Where(a => a.AttributeType.IsIn() && !a.AttributeType.IsBuiltIn());
                    if (attrs.Count() > 0)
                    {
                        var attr = attrs.First();
                        var type = GLSL.ToGLSL(field.FieldType.Name);
                        var isArray = field.FieldType.IsArray;
                        var arrayAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<ArraySizeAttribute>());
                        var arraySize = (isArray && arrayAttr.Count() > 0 && arrayAttr.First().HasConstructorArguments) ? arrayAttr.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                        var name = field.Name;
                        var commentAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<CommentAttribute>());
                        var u_comment = (commentAttr.Count() > 0 && commentAttr.First().HasConstructorArguments) ? commentAttr.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                        var d_comment = DebugMode ? field.DeclaringType.FullName + "." + field.Name : string.Empty;
                        var layoutAttr = (this is VertexShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<VertexShader.LayoutAttribute>()) :
                            ((this is FragmentShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<FragmentShader.LayoutAttribute>()) :
                            ((this is GeometryShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<GeometryShader.LayoutAttribute>()) : null));
                        var layout = (layoutAttr != null && layoutAttr.Count() > 0) ? layoutAttr.First() : null;
                        yield return new ASLShaderVariable(type, isArray, arraySize, name, u_comment, d_comment, attr.AttributeType, layout);
                    }
                }
            }
        }

        internal IEnumerable<ASLShaderVariable> GetOutputs()
        {
            foreach (var field in _shader.Fields)
            {
                if (field.HasCustomAttributes)
                {
                    var attrs = field.CustomAttributes.Where(a => a.AttributeType.IsOut() && !a.AttributeType.IsBuiltIn());
                    if (attrs.Count() > 0)
                    {
                        var attr = attrs.First();
                        var type = GLSL.ToGLSL(field.FieldType.Name);
                        var isArray = field.FieldType.IsArray;
                        var arrayAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<ArraySizeAttribute>());
                        var arraySize = (isArray && arrayAttr.Count() > 0 && arrayAttr.First().HasConstructorArguments) ? arrayAttr.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                        var name = field.Name;
                        var commentAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<CommentAttribute>());
                        var u_comment = (commentAttr.Count() > 0 && commentAttr.First().HasConstructorArguments) ? commentAttr.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                        var d_comment = DebugMode ? field.DeclaringType.FullName + "." + field.Name : string.Empty;
                        var layoutAttr = (this is FragmentShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<FragmentShader.LayoutAttribute>()) :
                            ((this is GeometryShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<GeometryShader.LayoutAttribute>()) : null);
                        var layout = (layoutAttr != null && layoutAttr.Count() > 0) ? layoutAttr.First() : null;
                        yield return new ASLShaderVariable(type, isArray, arraySize, name, u_comment, d_comment, attr.AttributeType, layout);
                    }
                }
            }
        }

        internal IEnumerable<ASLShaderStruct> GetStructures()
        {
            foreach (var structure in _shader.NestedTypes)
            {
                var isInterfaceBlock = structure.HasCustomAttributes && structure.HasAttribute<InterfaceBlockAttribute>();
                TypeReference interfaceBlockType = null;
                var interfaceBlockAttribute = isInterfaceBlock ? structure.CustomAttributes.First(a => a.AttributeType.Is<InterfaceBlockAttribute>()) : null;
                var interfaceBlockNamespace = isInterfaceBlock && interfaceBlockAttribute.ConstructorArguments.Count > 0 ? interfaceBlockAttribute.ConstructorArguments.First().Value.ToString() : string.Empty;

                if (isInterfaceBlock)
                {
                    var attrs = structure.CustomAttributes.Where(a => a.AttributeType.IsIn() || a.AttributeType.IsOut() || a.AttributeType.IsUniform());
                    var customAttributes = attrs as CustomAttribute[] ?? attrs.ToArray();
                    if (!customAttributes.Any())
                        throw new ASLException("ASL Error: An interface block have to have a qualifier which can be in, out or uniform.");
                    if (customAttributes.Count() > 1)
                        throw new ASLException("ASL Error: An interface block have to have only one qualifier, which can be in, out or uniform.");
                    interfaceBlockType = customAttributes.First().AttributeType;
                }

                List<ASLShaderVariable> fields = new List<ASLShaderVariable>();
                foreach (var field in structure.Fields)
                {
                    var type = GLSL.ToGLSL(field.FieldType.Name);
                    var isArray = field.FieldType.IsArray;
                    var arrayAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<ArraySizeAttribute>());
                    var arraySize = (isArray && arrayAttr.Any() && arrayAttr.First().HasConstructorArguments) ? arrayAttr.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                    var name = field.Name;
                    var commentAttr = field.CustomAttributes.Where(a => a.AttributeType.Is<CommentAttribute>());
                    var u_comment = (commentAttr.Any() && commentAttr.First().HasConstructorArguments) ? commentAttr.First().ConstructorArguments.First().Value.ToString() : string.Empty;
                    var d_comment = DebugMode ? field.DeclaringType.FullName + "." + field.Name : string.Empty;
                    TypeReference attrType = null;
                    if (isInterfaceBlock)
                    {
                        var attrs = field.CustomAttributes.Where(a => a.AttributeType.IsIn() || a.AttributeType.IsOut() || a.AttributeType.IsUniform());
                        if (attrs.Count() > 1)
                            throw new ASLException("ASL Error: An interface block member have to have only one qualifier, which can be in, out or uniform, according to the interface block qualifier.");
                        if (attrs.Any())
                        {
                            if ((interfaceBlockType.IsIn() && (attrs.First().AttributeType.IsOut() || attrs.First().AttributeType.IsUniform())) || (interfaceBlockType.IsUniform() && (attrs.First().AttributeType.IsOut() || attrs.First().AttributeType.IsIn())) || (interfaceBlockType.IsOut() && (attrs.First().AttributeType.IsIn() || attrs.First().AttributeType.IsUniform())))
                                throw new ASLException("ASL Error: An interface block member have to have (if he has one) a similar qualifier than the interface block.");
                            attrType = attrs.First().AttributeType;
                        }
                    }
                    var varLayoutAttr = (this is VertexShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<VertexShader.LayoutAttribute>()) :
                        ((this is FragmentShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<FragmentShader.LayoutAttribute>()) :
                        ((this is GeometryShader) ? field.CustomAttributes.Where(a => a.AttributeType.Is<GeometryShader.LayoutAttribute>()) : null));
                    var varLayout = (varLayoutAttr != null && varLayoutAttr.Any()) ? varLayoutAttr.First() : null;
                    fields.Add(new ASLShaderVariable(type, isArray, arraySize, name, u_comment, d_comment, attrType, varLayout));
                }

                var layoutAttr = (this is VertexShader) ? structure.CustomAttributes.Where(a => a.AttributeType.Is<VertexShader.LayoutAttribute>()) :
                    ((this is FragmentShader) ? structure.CustomAttributes.Where(a => a.AttributeType.Is<FragmentShader.LayoutAttribute>()) :
                    ((this is GeometryShader) ? structure.CustomAttributes.Where(a => a.AttributeType.Is<GeometryShader.LayoutAttribute>()) : null));
                var layout = (layoutAttr != null && layoutAttr.Any()) ? layoutAttr.First() : null;

                yield return new ASLShaderStruct(structure.Name, isInterfaceBlock, interfaceBlockType, interfaceBlockNamespace, fields, layout);
            }
        }

        internal IEnumerable<KeyValuePair<MethodDefinition, KeyValuePair<string, string>>> GetMethods()
        {
            var methods = new List<KeyValuePair<MethodDefinition, KeyValuePair<string, string>>>();
            bool _mainPassedBeforeCtor = false;
            string _ctor = string.Empty;
            bool _ctorPassed = false;
            string _mainBody = string.Empty;
            MethodDefinition _mainDefinition = null;

            foreach (var m in _shader.Methods)
            {
                var body = ASLShaderCompiler.CreateMethodString(_shader, m);

                // Copy constructor instructions
                if ((m.IsConstructor || m.Name == ".ctor") && string.IsNullOrEmpty(_ctor))
                {
                    var ctorInst = body.Value.Value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    var validInst = ctorInst.Where(i => !(new List<string> { "{", ".ctor();", "}"}).Contains(i.Trim()) && !i.Trim().StartsWith("void .ctor(")).ToArray();
                    _ctor = string.Join(Environment.NewLine, validInst);
                    _ctorPassed = true;
                    continue;
                }

                // Paste constructor instructions at the top of void main()
                if (m.Name == "main")
                {
                    if (!string.IsNullOrEmpty(_ctor))
                    {
                        var mainInst = body.Value.Value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        var ctorInst = _ctor.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                        for(int i = 0, j = 2; i < ctorInst.Length; i++, j++)
                        {
                            mainInst.Insert(j, ctorInst[i]);
                        }

                        body = new KeyValuePair<MethodDefinition, KeyValuePair<string, string>>
                        (
                            m,
                            new KeyValuePair<string, string>(m.Name, string.Join(Environment.NewLine, mainInst) + Environment.NewLine)
                        );
                    }
                    else if (!_ctorPassed)
                    {
                        _mainPassedBeforeCtor = true;
                        _mainDefinition = m;
                        _mainBody = body.Value.Value;
                        continue;
                    }
                }

                methods.Add(body);
            }

            if (_mainPassedBeforeCtor && _ctorPassed)
            {
                var mainInst = _mainBody.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var ctorInst = _ctor.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                for(int i = 0, j = 2; i < ctorInst.Length; i++, j++)
                {
                    mainInst.Insert(j, ctorInst[i]);
                }

                var mainBody = new KeyValuePair<MethodDefinition, KeyValuePair<string, string>>
                (
                    _mainDefinition,
                    new KeyValuePair<string, string>(_mainDefinition.Name, string.Join(Environment.NewLine, mainInst) + Environment.NewLine)
                );

                methods.Add(mainBody);
            }

            return methods;
        }

        /// <summary>
        /// Outputs an hard coded block of code in the compiled
        /// GLSL source.
        /// </summary>
        /// <param name="code">The block of code to output.</param>
        [CLSCompliant(false)]
        protected void __output(string code)
        {
            throw new NotImplementedException();
        }

        private TypeDefinition _loadReflection()
        {
            var t = GetType();
            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(Path.GetDirectoryName(t.Assembly.Location));
            resolver.AddSearchDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var asm = AssemblyDefinition.ReadAssembly(t.Assembly.Location, new ReaderParameters { AssemblyResolver = resolver });

            var mod = asm.Modules.Single(x => x.MetadataToken.ToInt32() == t.Module.MetadataToken);
            return mod.Types.Single(x => x.MetadataToken.ToInt32() == t.MetadataToken);
        }
    }
}
