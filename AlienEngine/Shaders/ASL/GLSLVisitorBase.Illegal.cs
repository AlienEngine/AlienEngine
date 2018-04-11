using System.Text;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;

namespace AlienEngine.Shaders.ASL
{
    internal abstract partial class GLSLVisitorBase
    {
        public StringBuilder VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, int data)
        {
            throw new ASLException("ASL does not understand anonymous methods.");
        }

        public StringBuilder VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression, int data)
        {
            throw new ASLException("Unsupported nonstandard language extension encountered.");
        }

        public StringBuilder VisitAsExpression(AsExpression asExpression, int data)
        {
            throw new ASLException("ASL does not have reflection-supported casts.");
        }

        public StringBuilder VisitCheckedExpression(CheckedExpression checkedExpression, int data)
        {
            throw new ASLException("ASL can only operate in unchecked context.");
        }

        public StringBuilder VisitLambdaExpression(LambdaExpression lambdaExpression, int data)
        {
            throw new ASLException("ASL does not understand lambda expressions.");
        }

        public StringBuilder VisitIsExpression(IsExpression isExpression, int data)
        {
            throw new ASLException("ASL does not have reflection.");
        }

        public StringBuilder VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression, int data)
        {
            throw new ASLException("ASL has no notion of NULL.");
        }

        public StringBuilder VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression, int data)
        {
            throw new ASLException("ASL does not understand anonymous types");
        }

        public StringBuilder VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, int data)
        {
            throw new ASLException("ASL does not have pointers.");
        }

        public StringBuilder VisitSizeOfExpression(SizeOfExpression sizeOfExpression, int data)
        {
            throw new ASLException("ASL has no sizeof operator.");
        }

        public StringBuilder VisitStackAllocExpression(StackAllocExpression stackAllocExpression, int data)
        {
            throw new ASLException("Cannot stack-allocate memory in GLSL.");
        }

        public StringBuilder VisitTypeOfExpression(TypeOfExpression typeOfExpression, int data)
        {
            throw new ASLException("ASL does not have reflection.");
        }

        public StringBuilder VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression, int data)
        {
            throw new ASLException("ASL primitives do not methods.");
        }

        public StringBuilder VisitQueryExpression(QueryExpression queryExpression, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQueryFromClause(QueryFromClause queryFromClause, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQueryLetClause(QueryLetClause queryLetClause, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQueryWhereClause(QueryWhereClause queryWhereClause, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQueryJoinClause(QueryJoinClause queryJoinClause, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQueryOrderClause(QueryOrderClause queryOrderClause, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQueryOrdering(QueryOrdering queryOrdering, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitQuerySelectClause(QuerySelectClause querySelectClause, int data)
        {
            throw new ASLException("HLSL does not understand LINQ.");
        }

        public StringBuilder VisitQueryGroupClause(QueryGroupClause queryGroupClause, int data)
        {
            throw new ASLException("ASL does not understand LINQ.");
        }

        public StringBuilder VisitAttribute(Attribute attribute, int data)
        {
            throw new ASLException("ASL does not have attributes.");
        }

        public StringBuilder VisitAttribute(System.Attribute attribute, int data)
        {
            throw new ASLException("ASL does not have attributes.");
        }

        public StringBuilder VisitAttributeSection(AttributeSection attributeSection, int data)
        {
            throw new ASLException("HLSL does not have attributes.");
        }

        public StringBuilder VisitCheckedStatement(CheckedStatement checkedStatement, int data)
        {
            throw new ASLException("ASL can only operate in unchecked context.");
        }

        public StringBuilder VisitFixedStatement(FixedStatement fixedStatement, int data)
        {
            throw new ASLException("ASL does not understand the fixed keyword.");
        }

        public StringBuilder VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, int data)
        {
            throw new ASLException("ASL cannot jump from one case to another.");
        }

        public StringBuilder VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement, int data)
        {
            throw new ASLException("ASL cannot jump from one case to another.");
        }

        public StringBuilder VisitGotoStatement(GotoStatement gotoStatement, int data)
        {
            throw new ASLException("ASL does not support goto.");
        }

        public StringBuilder VisitLabelStatement(LabelStatement labelStatement, int data)
        {
            throw new ASLException("ASL does not support labels.");
        }

        public StringBuilder VisitLockStatement(LockStatement lockStatement, int data)
        {
            throw new ASLException("ASL does not have locks.");
        }

        public StringBuilder VisitThrowStatement(ThrowStatement throwStatement, int data)
        {
            throw new ASLException("ASL does not have exceptions.");
        }

        public StringBuilder VisitThrowExpression(ThrowExpression throwStatement, int data)
        {
            throw new ASLException("ASL does not have exceptions.");
        }

        public StringBuilder VisitTryCatchStatement(TryCatchStatement tryCatchStatement, int data)
        {
            throw new ASLException("ASL does not have exceptions.");
        }

        public StringBuilder VisitCatchClause(CatchClause catchClause, int data)
        {
            throw new ASLException("ASL does not have exceptions.");
        }

        public StringBuilder VisitUnsafeStatement(UnsafeStatement unsafeStatement, int data)
        {
            throw new ASLException("ASL does not allow unsafe code.");
        }

        public StringBuilder VisitUsingStatement(UsingStatement usingStatement, int data)
        {
            throw new ASLException("ASL does not have the using keyword.");
        }

        public StringBuilder VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement, int data)
        {
            throw new ASLException("ASL does not have iterators.");
        }

        public StringBuilder VisitNamedExpression(NamedExpression namedExpression, int data)
        {
            throw new ASLException("ASL does not have iterators.");
        }

        public StringBuilder VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement, int data)
        {
            throw new ASLException("ASL does not have iterators.");
        }

        public StringBuilder VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, int data)
        {
            throw new ASLException("ASL does not support default constructors.");
        }

        public StringBuilder VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration, int data)
        {
            throw new ASLException("ASL does not understand the fixed keyword.");
        }

        public StringBuilder VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer, int data)
        {
            throw new ASLException("ASL does not understand the fixed keyword.");
        }

        public StringBuilder VisitPatternPlaceholder(AstNode placeholder, Pattern pattern, int data)
        {
            throw new ASLException("ASL does not support pattern placeholders.");
        }

        public StringBuilder VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression, int data)
        {
            throw new ASLException("ASL does not support named arguments.");
        }
    }
}
