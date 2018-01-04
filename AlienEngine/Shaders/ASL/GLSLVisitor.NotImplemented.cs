using ICSharpCode.NRefactory.CSharp;
using System;
using System.Text;

namespace AlienEngine.ASL
{
    public abstract partial class ASLShader
    {
        internal sealed partial class GLSLVisitor
        {
            public override StringBuilder VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression, int data)
            {
                throw new NotImplementedException();
            }

            public override StringBuilder VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, int data)
            {
                return null;
            }

            public override StringBuilder VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, int data)
            {
                return null;
            }

            public override StringBuilder VisitUncheckedExpression(UncheckedExpression uncheckedExpression, int data)
            {
                return new StringBuilder();
            }

            public override StringBuilder VisitEmptyStatement(EmptyStatement emptyStatement, int data)
            {
                return new StringBuilder();
            }

            public override StringBuilder VisitForeachStatement(ForeachStatement foreachStatement, int data)
            {
                throw new NotImplementedException();
            }

            public override StringBuilder VisitUncheckedStatement(UncheckedStatement uncheckedStatement, int data)
            {
                return new StringBuilder();
            }

            public override StringBuilder VisitArraySpecifier(ArraySpecifier arraySpecifier, int data)
            {
                throw new NotImplementedException();
            }

            public override StringBuilder VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode, int data)
            {
                throw new NotImplementedException();
            }
        }
    }
}