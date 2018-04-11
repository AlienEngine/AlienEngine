using ICSharpCode.Decompiler.CSharp.Syntax;

namespace AlienEngine.Shaders.ASL
{
    internal static class ASLShaderExtensions
    {
        public static T Detach<T>(this T node) where T : AstNode
        {
            node.Remove();
            return node;
        }
    }
}