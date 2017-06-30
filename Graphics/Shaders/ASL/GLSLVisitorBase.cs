using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AlienEngine.ASL
{
    internal abstract partial class GLSLVisitorBase : IAstVisitor<int, StringBuilder>
    {
        public readonly HashSet<Type> Dependencies = new HashSet<Type>();

        private int _tempCounter;

        protected VariableDeclarationStatement ToTemp(Expression e)
        {
            return new VariableDeclarationStatement(null, "__tmp" + _tempCounter++, e.Clone());
        }

        protected StringBuilder ArgsToString(ICollection<Expression> args)
        {
            var result = new StringBuilder();
            if (args.Count <= 0)
                return result;

            foreach (var v in args.Take(args.Count - 1))
            {
                result.Append(v.AcceptVisitor(this, 0));
                result.Append(", ");
            }

            result.Append(args.Last().AcceptVisitor(this, 0));
            return result;
        }

        protected static StringBuilder Indent(AstNode node, StringBuilder b)
        {
            if (node is BlockStatement)
                return b;

            var res = new StringBuilder();

            res.Append("    ");
            res.Append(b.Replace(Environment.NewLine, Environment.NewLine + "    "));

            return res;
        }

        private static Type GetType(TypeDefinition td)
        {
            var qualifiedName = Assembly.CreateQualifiedName(td.Module.Assembly.FullName, td.FullName);
            return Type.GetType(qualifiedName, true);
        }

        protected void AddDependency(MethodDefinition m)
        {
            var dependency = m.DeclaringType.Resolve();
            Dependencies.Add(GetType(dependency));
        }
    }
}
