using System;
using System.Text;
using ICSharpCode.Decompiler.CSharp.Syntax;

namespace AlienEngine.Shaders.ASL
{
    internal abstract partial class GLSLVisitorBase
    {
        public StringBuilder VisitWhitespace(WhitespaceNode whitespaceNode, int data)
        {
            throw new NotImplementedException();
        }

        public StringBuilder VisitText(TextNode textNode, int data)
        {
            throw new NotImplementedException();
        }

        public StringBuilder VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective, int data)
        {
            throw new NotImplementedException();
        }

        public StringBuilder VisitDocumentationReference(DocumentationReference documentationReference, int data)
        {
            throw new NotImplementedException();
        }

        public StringBuilder VisitNullNode(AstNode nullNode, int data)
        {
            throw new NotImplementedException();
        }

        public StringBuilder VisitErrorNode(AstNode errorNode, int data)
        {
            throw new NotImplementedException();
        }

        public StringBuilder VisitOutVarDeclarationExpression(OutVarDeclarationExpression expression, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitTypeDeclaration(TypeDeclaration typeDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitUsingDeclaration(UsingDeclaration usingDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitAccessor(Accessor accessor, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitConstructorInitializer(ConstructorInitializer constructorInitializer, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitEventDeclaration(EventDeclaration eventDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitFieldDeclaration(FieldDeclaration fieldDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitMethodDeclaration(MethodDeclaration methodDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitParameterDeclaration(ParameterDeclaration parameterDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitSyntaxTree(SyntaxTree syntaxTree, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitComment(Comment comment, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration, int data)
        {
            throw new NotSupportedException();
        }

        public StringBuilder VisitConstraint(Constraint constraint, int data)
        {
            throw new NotSupportedException();
        }
    }
}
