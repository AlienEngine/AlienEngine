using System;
using System.Collections.Generic;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Transforms;

namespace AlienEngine.Shaders.ASL
{
    internal sealed class RenameLocals
    {
        private int _ctr;

        private readonly Dictionary<string, string> _locals = new Dictionary<string, string>();

        public void Run(AstNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (node is VariableInitializer initializer)
            {
                if (!_locals.ContainsValue(initializer.Name))
                {
                    var newName = $"_loc{_ctr++}";
                    _locals[initializer.Name] = newName;
                    initializer.ReplaceWith(new VariableInitializer(newName, initializer.Initializer.Detach()));
                }
            }
            else
            {
                if (node is IdentifierExpression identifier)
                {
                    string newName;
                    if (_locals.TryGetValue(identifier.Identifier, out newName))
                        identifier.ReplaceWith(new IdentifierExpression(newName));
                }
            }

            foreach (var c in node.Descendants)
                Run(c);
        }
    }
}