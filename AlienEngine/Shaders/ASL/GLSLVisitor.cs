using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Transforms;
using ICSharpCode.Decompiler.Semantics;
using ICSharpCode.Decompiler.TypeSystem;
using Mono.Cecil;

namespace AlienEngine.Shaders.ASL
{
    public abstract partial class ASLShader
    {
        internal sealed partial class GLSLVisitor : GLSLVisitorBase
        {
            private readonly HashSet<Tuple<string, string>> _functions = new HashSet<Tuple<string, string>>();

            public IEnumerable<Tuple<string, string>> Functions => _functions;

            public static void ValidateType(string t)
            {
                GLSL.ToGLSL(t); // throws if t is not valid
            }

            public static string ToGLSLParamType(IParameter p)
            {
                var t = GLSL.ToGLSL(p.Type.Name);
                if (p.IsRef)
                    return $"{(p.IsOut ? "out " : "inout ")}{t}";

                return t;
            }
            
            public static string ToGLSLParamType(ParameterDefinition p)
            {
                var t = GLSL.ToGLSL(p.ParameterType.Name);
                if (p.ParameterType.IsByReference)
                    return $"{(p.IsOut ? "out " : "inout ")}{t}";

                return t;
            }

            public string Result { get; private set; }

            public static string GetParameterString(IMethod m)
            {
                var sig = string.Empty;

                var parameters = m.Parameters;
                if (parameters.Count > 0)
                {
                    sig = parameters.Take(parameters.Count - 1).Aggregate(sig, (current, v) =>
                    {
                        var vArraySize = string.Empty;
                        if (v.Type.Kind == TypeKind.Array && v.HasCustomAttributes())
                        {
                            var attr = v.Attributes.First(a => a.AttributeType.Is<ArraySizeAttribute>());
                            vArraySize = attr.Constructor.Parameters.First().ConstantValue.ToString();
                        }

                        return $"{current}{ToGLSLParamType(v)}{(v.Type.IsArray() ? $"[{vArraySize}]" : string.Empty)} {v.Name}, ";
                    });

                    var l = parameters.Last();
                    var lArraySize = string.Empty;
                    if (l.Type.IsArray() && l.HasCustomAttributes())
                    {
                        var attr = l.Attributes.First(a => a.AttributeType.Is<ArraySizeAttribute>());
                        lArraySize = attr.Constructor.Parameters.First().ConstantValue.ToString();
                    }

                    sig += $"{ToGLSLParamType(l)}{(l.Type.IsArray() ? $"[{lArraySize}]" : string.Empty)} {l.Name}";
                }

                return sig;
            }

            public static string GetParameterString(MethodDefinition m)
            {
                var sig = string.Empty;

                var parameters = m.Parameters;
                if (parameters.Count > 0)
                {
                    sig = parameters.Take(parameters.Count - 1).Aggregate(sig, (current, v) =>
                    {
                        var vArraySize = string.Empty;
                        if (v.ParameterType.IsArray && v.HasCustomAttributes)
                        {
                            var attr = v.CustomAttributes.First(a => a.AttributeType.Is<ArraySizeAttribute>());
                            vArraySize = attr.ConstructorArguments.First().Value.ToString();
                        }

                        return $"{current}{ToGLSLParamType(v)}{(v.ParameterType.IsArray ? $"[{vArraySize}]" : string.Empty)} {v.Name}, ";
                    });

                    var l = parameters.Last();
                    var lArraySize = string.Empty;
                    if (l.ParameterType.IsArray && l.HasCustomAttributes)
                    {
                        var attr = l.CustomAttributes.First(a => a.AttributeType.Is<ArraySizeAttribute>());
                        lArraySize = attr.ConstructorArguments.First().Value.ToString();
                    }

                    sig += $"{ToGLSLParamType(l)}{(l.ParameterType.IsArray ? $"[{lArraySize}]" : string.Empty)} {l.Name}";
                }

                return sig;
            }

            internal static string GetSignature(IMethod m)
            {
                var arraySize = string.Empty;
                if (m.ReturnType.IsArray() && m.ReturnTypeAttributes.Count > 0)
                {
                    var attr = m.ReturnTypeAttributes.First(a => a.AttributeType.Is<ArraySizeAttribute>());
                    arraySize = attr.Constructor.Parameters.First().ConstantValue.ToString();
                }

                return $"{GLSL.ToGLSL(m.ReturnType.Name)}{(m.ReturnType.Kind == TypeKind.Array ? $"[{arraySize}]" : string.Empty)} {m.Name}({GetParameterString(m)})";
            }

            internal static string GetSignature(MethodDefinition m)
            {
                var arraySize = string.Empty;
                if (m.ReturnType.IsArray && m.MethodReturnType.HasCustomAttributes)
                {
                    var attr = m.MethodReturnType.CustomAttributes.First(a => a.AttributeType.Is<ArraySizeAttribute>());
                    arraySize = attr.ConstructorArguments.First().Value.ToString();
                }

                return $"{GLSL.ToGLSL(m.ReturnType.Name)}{(m.ReturnType.IsArray ? $"[{arraySize}]" : string.Empty)} {m.Name}({GetParameterString(m)})";
            }

            private void RegisterMethod(IMethod m)
            {
                AddDependency(m);
                _functions.Add(new Tuple<string, string>(GetSignature(m), $"{m.DeclaringType.FullName}.{m.Name}"));
            }

            public GLSLVisitor(BlockStatement block, TransformContext ctx)
            {
                var trans1 = new ReplaceMethodCallsWithOperators();
                var trans2 = new RenameLocals();
                ((IAstTransform) trans1).Run(block, ctx);
                trans2.Run(block);

                Result = block.AcceptVisitor(this, 0).ToString();
                Result += Environment.NewLine;
            }

            public override StringBuilder VisitBlockStatement(BlockStatement blockStatement, int data)
            {
                var result = new StringBuilder();

                result.Append(Environment.NewLine).Append("{");

                foreach (var stm in blockStatement.Statements)
                    result.Append(Environment.NewLine).Append(Indent(stm, stm.AcceptVisitor(this, data)));

                result.Append(Environment.NewLine).Append("}");

                return result;
            }

            public override StringBuilder VisitExpressionStatement(ExpressionStatement expressionStatement, int data)
            {
                return expressionStatement.Expression.AcceptVisitor(this, data).Append(";");
            }

            public override StringBuilder VisitAssignmentExpression(AssignmentExpression assignmentExpression, int data)
            {
                var result = assignmentExpression.Left.AcceptVisitor(this, data);

                switch (assignmentExpression.Operator)
                {
                    case AssignmentOperatorType.Assign:
                        result.Append(" = ");
                        break;
                    case AssignmentOperatorType.Add:
                        result.Append(" += ");
                        break;
                    case AssignmentOperatorType.BitwiseAnd:
                        result.Append(" &= ");
                        break;
                    case AssignmentOperatorType.BitwiseOr:
                        result.Append(" |= ");
                        break;
                    case AssignmentOperatorType.Divide:
                        result.Append(" /= ");
                        break;
                    case AssignmentOperatorType.ExclusiveOr:
                        result.Append(" ^= ");
                        break;
                    case AssignmentOperatorType.Modulus:
                        result.Append(" %= ");
                        break;
                    case AssignmentOperatorType.Multiply:
                        result.Append(" *= ");
                        break;
                    case AssignmentOperatorType.ShiftLeft:
                        result.Append(" <<= ");
                        break;
                    case AssignmentOperatorType.ShiftRight:
                        result.Append(" >>= ");
                        break;
                    case AssignmentOperatorType.Subtract:
                        result.Append(" -= ");
                        break;
                    default:
                        throw new NotImplementedException();
                }

                result.Append(assignmentExpression.Right.AcceptVisitor(this, data));

                return result;
            }

            public override StringBuilder VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, int data)
            {
                var result = new StringBuilder();

                if (!(memberReferenceExpression.Target is ThisReferenceExpression) && !(memberReferenceExpression.Target is BaseReferenceExpression))
                    result.Append(memberReferenceExpression.Target.AcceptVisitor(this, data)).Append(".");

                var mdef = memberReferenceExpression.Annotation<IMemberDefinition>();
                if (mdef != null)
                    return result.Append(mdef.Name);

                var fref = memberReferenceExpression.Annotation<FieldReference>();
                if (fref != null)
                    return result.Append(fref.Name);

                var rref = memberReferenceExpression.GetSymbol();
                if (rref != null)
                    return result.Append(rref.Name);
                
                var iref = memberReferenceExpression.MemberNameToken.AcceptVisitor(this, data);
                if (iref.Length > 0)
                    return result.Append(iref);

                throw new NotImplementedException();
            }

            public override StringBuilder VisitInvocationExpression(InvocationExpression invocationExpression, int data)
            {
                var result = new StringBuilder();

                if (!(invocationExpression.GetSymbol() is IMethod m))
                    throw new ASLException("An error occured when parsing ASL code.");

                if (m.DeclaringType.FullName == typeof(ASLShader).FullName)
                {
                    if (m.Name == "__output")
                    {
                        return result.Append(ArgsToString(invocationExpression.Arguments));
                    }
                    
                    return result.Append(m.Name).Append("(").Append(ArgsToString(invocationExpression.Arguments)).Append(")");
                }

                RegisterMethod(m);
                result.Append(m.Name);
                result.Append("(").Append(ArgsToString(invocationExpression.Arguments)).Append(")");

                return result;
            }

            public override StringBuilder VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, int data)
            {
                return objectCreateExpression.Type.AcceptVisitor(this, data).Append("(").Append(
                    ArgsToString(objectCreateExpression.Arguments)).Append(")");
            }

            public override StringBuilder VisitMemberType(MemberType memberType, int data)
            {
                return new StringBuilder(GLSL.ToGLSL(memberType.Annotation<TypeReference>().Name));
            }

            public override StringBuilder VisitSimpleType(SimpleType simpleType, int data)
            {
                // this cast might not work for all cases...
                ValidateType(simpleType.Annotation<TypeResolveResult>().Type.Name);
                return new StringBuilder(simpleType.ToString());
            }

            public override StringBuilder VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, int data)
            {
                var result = new StringBuilder();

                if (primitiveExpression.Value is float f)
                {
                    var s = f.ToString(CultureInfo.InvariantCulture.NumberFormat);
                    result.Append(s);
                    if (!s.Contains("."))
                        result.Append(".0");

                    result.Append("f");
                    return result;
                }

                if (primitiveExpression.Value is double d)
                {
                    var s = d.ToString(CultureInfo.InvariantCulture.NumberFormat);
                    result.Append(s);
                    if (!s.Contains("."))
                        result.Append(".0");

                    result.Append("lf");
                    return result;
                }

                if (primitiveExpression.Value is uint u)
                {
                    var s = u.ToString(CultureInfo.InvariantCulture.NumberFormat);
                    result.Append(s).Append("u");
                    return result;
                }

                if (primitiveExpression.Value is bool b)
                {
                    return result.Append(b ? "true" : "false");
                }

                return result.Append(primitiveExpression.Value);
            }

            public override StringBuilder VisitCastExpression(CastExpression castExpression, int data)
            {
                // TODO: validate the cast operation, this unfortunateley needs a way to evalulate
                // the cast expressions type, which we still cant do properly with IC#..

                // unlike c/c++ GLSL uses constructor syntax as float(intExpression) rather than
                // a cast like expression as (float)intExpression.
                var s = castExpression.Type.AcceptVisitor(this, data);
                return s.Append("(").Append(castExpression.Expression.AcceptVisitor(this, data)).Append(")");
            }

            public override StringBuilder VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, int data)
            {
                if (binaryOperatorExpression.Operator == BinaryOperatorType.Modulus)
                {
                    // TODO: check if lhs is a gen(D)Type and only apply the rule in that case
                    // replace with mod(lhs, rhs) statement
                    var r = new StringBuilder();
                    r.Append("mod(");
                    r.Append(binaryOperatorExpression.Left.AcceptVisitor(this, data));
                    r.Append(", ");
                    r.Append(binaryOperatorExpression.Right.AcceptVisitor(this, data));
                    r.Append(")");
                    return r;
                }

                var result = new StringBuilder("(");

                result.Append(binaryOperatorExpression.Left.AcceptVisitor(this, data));

                switch (binaryOperatorExpression.Operator)
                {
                    case BinaryOperatorType.Multiply:
                        result.Append(" * ");
                        break;
                    case BinaryOperatorType.Divide:
                        result.Append(" / ");
                        break;
                    case BinaryOperatorType.Add:
                        result.Append(" + ");
                        break;
                    case BinaryOperatorType.Subtract:
                        result.Append(" - ");
                        break;
                    case BinaryOperatorType.Modulus:
                        result.Append(" % ");
                        break;
                    case BinaryOperatorType.BitwiseOr:
                        result.Append(" | ");
                        break;
                    case BinaryOperatorType.BitwiseAnd:
                        result.Append(" & ");
                        break;
                    case BinaryOperatorType.ExclusiveOr:
                        result.Append(" ^ ");
                        break;
                    case BinaryOperatorType.ShiftLeft:
                        result.Append(" << ");
                        break;
                    case BinaryOperatorType.ShiftRight:
                        result.Append(" >> ");
                        break;
                    case BinaryOperatorType.LessThan:
                        result.Append(" < ");
                        break;
                    case BinaryOperatorType.GreaterThan:
                        result.Append(" > ");
                        break;
                    case BinaryOperatorType.LessThanOrEqual:
                        result.Append(" <= ");
                        break;
                    case BinaryOperatorType.GreaterThanOrEqual:
                        result.Append(" >= ");
                        break;
                    case BinaryOperatorType.Equality:
                        result.Append(" == ");
                        break;
                    case BinaryOperatorType.InEquality:
                        result.Append(" != ");
                        break;
                    case BinaryOperatorType.ConditionalOr:
                        result.Append(" || ");
                        break;
                    case BinaryOperatorType.ConditionalAnd:
                        result.Append(" && ");
                        break;
                    default:
                        throw new NotImplementedException();
                }

                result.Append(binaryOperatorExpression.Right.AcceptVisitor(this, data)).Append(")");

                return result;
            }

            public override StringBuilder VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, int data)
            {
                var result = new StringBuilder();

                var exp = unaryOperatorExpression.Expression.AcceptVisitor(this, data);

                switch (unaryOperatorExpression.Operator)
                {
                    case UnaryOperatorType.Decrement:
                        return result.Append("--").Append(exp);
                    case UnaryOperatorType.Increment:
                        return result.Append("++").Append(exp);
                    case UnaryOperatorType.Minus:
                        return result.Append("-").Append(exp);
                    case UnaryOperatorType.Plus:
                        return result.Append("+").Append(exp);
                    case UnaryOperatorType.BitNot:
                        return result.Append("~").Append(exp);
                    case UnaryOperatorType.Not:
                        return result.Append("!").Append(exp);
                    case UnaryOperatorType.PostDecrement:
                        return result.Append(exp).Append("--");
                    case UnaryOperatorType.PostIncrement:
                        return result.Append(exp).Append("++");
                }

                throw new NotImplementedException();
            }

            public override StringBuilder VisitReturnStatement(ReturnStatement returnStatement, int data)
            {
                var result = new StringBuilder();

                result.Append("return");

                var exp = returnStatement.Expression.AcceptVisitor(this, data);
                if (exp.Length > 0)
                    result.Append(" ").Append(exp);

                result.Append(";");

                return result;
            }

            public override StringBuilder VisitIdentifierExpression(IdentifierExpression identifierExpression, int data)
            {
                return new StringBuilder(identifierExpression.Identifier);
            }

            public override StringBuilder VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, int data)
            {
                var result = new StringBuilder();
                const string brackets = "[]";

                var t = variableDeclarationStatement.Type;
                var type = t.AcceptVisitor(this, data);
                foreach (var v in variableDeclarationStatement.Variables)
                {
                    var varName = v.AcceptVisitor(this, data);
                    if (variableDeclarationStatement.Type is ComposedType)
                    {
                        if (type.ToString().EndsWith(brackets))
                        {
                            type.Remove(type.Length - brackets.Length, brackets.Length);
                        }

                        if (!varName.ToString().EndsWith(brackets))
                        {
                            varName.Append(brackets[0]);
                            // TODO: Find a way to get the size of the array here...
                            varName.Append(((ArrayInitializerExpression) v.Initializer).Elements.Count);
                            varName.Append(brackets[1]);
                        }
                    }
                    else
                    {
                        var tref = variableDeclarationStatement.Type.Annotation<TypeReference>();
                        if (tref != null && tref.IsArray)
                        {
                            if (type.ToString().EndsWith(brackets))
                                type.Remove(type.Length - brackets.Length, brackets.Length);
                            if (!varName.ToString().EndsWith(brackets))
                            {
                                varName.Append(brackets[0]);
                                // TODO: Find a way to get the size of the array here...
                                varName.Append(((ArrayInitializerExpression) v.Initializer).Elements.Count);
                                varName.Append(brackets[1]);
                            }
                        }
                    }

                    result.Append(type).Append(" ").Append(varName).Append(";");
                }

                return result;
            }

            public override StringBuilder VisitVariableInitializer(VariableInitializer variableInitializer, int data)
            {
                var result = new StringBuilder(variableInitializer.Name);

                if (!variableInitializer.Initializer.IsNull)
                    result.Append(" = ").Append(variableInitializer.Initializer.AcceptVisitor(this, data));

                return result;
            }

            public override StringBuilder VisitPrimitiveType(PrimitiveType primitiveType, int data)
            {
                return new StringBuilder(primitiveType.Keyword);
            }

            public override StringBuilder VisitWhileStatement(WhileStatement whileStatement, int data)
            {
                var result = new StringBuilder("while (").Append(whileStatement.Condition.AcceptVisitor(this, data)).Append(")");

                var stmt = whileStatement.EmbeddedStatement;
                result.Append(Indent(stmt, stmt.AcceptVisitor(this, data)));

                return result;
            }

            public override StringBuilder VisitDoWhileStatement(DoWhileStatement doWhileStatement, int data)
            {
                var result = new StringBuilder("do");

                var stmt = doWhileStatement.EmbeddedStatement;
                result.Append(Indent(stmt, stmt.AcceptVisitor(this, data)));

                result.Append("while (").Append(doWhileStatement.Condition.AcceptVisitor(this, data)).Append(");");

                return result;
            }

            public override StringBuilder VisitIfElseStatement(IfElseStatement ifElseStatement, int data)
            {
                var result = new StringBuilder("if (").Append(ifElseStatement.Condition.AcceptVisitor(this, data)).Append(")");

                var trueSection = ifElseStatement.TrueStatement;
                result.Append(Indent(trueSection, trueSection.AcceptVisitor(this, data)));

                var elseSection = ifElseStatement.FalseStatement;
                if (!elseSection.IsNull)
                {
                    result.Append(Environment.NewLine + "else");
                    result.Append(Indent(elseSection, elseSection.AcceptVisitor(this, data)));
                }

                return result;
            }

            public override StringBuilder VisitSwitchStatement(SwitchStatement switchStatement, int data)
            {
                var result = new StringBuilder("switch (").Append(switchStatement.Expression.AcceptVisitor(this, data)).Append(")");

                result.Append(Environment.NewLine + "{");

                foreach (var section in switchStatement.SwitchSections)
                    result.Append(Environment.NewLine).Append(Indent(section, section.AcceptVisitor(this, data)));

                result.Append(Environment.NewLine + "}");

                return result;
            }

            public override StringBuilder VisitSwitchSection(SwitchSection switchSection, int data)
            {
                var result = new StringBuilder();

                foreach (var label in switchSection.CaseLabels)
                {
                    result.Append(Indent(label, label.AcceptVisitor(this, data)));
                    result.Append(Environment.NewLine);
                }

                result.Append(Environment.NewLine).Append("{");

                foreach (var stmt in switchSection.Statements)
                    result.Append(Environment.NewLine).Append(Indent(stmt, stmt.AcceptVisitor(this, data)));

                result.Append(Environment.NewLine).Append("}");

                return result;
            }

            public override StringBuilder VisitCaseLabel(CaseLabel caseLabel, int data)
            {
                return new StringBuilder("case ").Append(caseLabel.Expression.AcceptVisitor(this, data)).Append(":");
            }

            public override StringBuilder VisitBreakStatement(BreakStatement breakStatement, int data)
            {
                return new StringBuilder("break;");
            }

            public override StringBuilder VisitContinueStatement(ContinueStatement continueStatement, int data)
            {
                return new StringBuilder("continue;");
            }

            public override StringBuilder VisitForStatement(ForStatement forStatement, int data)
            {
                var result = new StringBuilder("for (");

                var initializers = forStatement.Initializers.ToList();
                var initializerCount = initializers.Count;
                for (var i = 0; i < initializerCount; i++)
                {
                    var initializer = initializers[i];
                    result.Append(initializer.AcceptVisitor(this, data).ToString().Trim(',', ';'));

                    if (i != initializerCount - 1)
                        result.Append(", ");
                }
                
                result.Append(";");

                var condition = forStatement.Condition;
                if (condition != null)
                {
                    result.Append(" ");
                    result.Append(condition.AcceptVisitor(this, data).ToString().Trim(',', ';'));
                }

                result.Append(";");

                var iterators = forStatement.Iterators.ToList();
                var iteratorCount = iterators.Count;

                if (iteratorCount != 0)
                    result.Append(" ");

                for (var i = 0; i < iteratorCount; i++)
                {
                    var iterator = iterators[i];
                    result.Append(iterator.AcceptVisitor(this, data).ToString().Trim(',', ';'));

                    if (i != iteratorCount - 1)
                        result.Append(", ");
                }

                result.Append(")");

                var stmt = forStatement.EmbeddedStatement;
                result.Append(Indent(stmt, stmt.AcceptVisitor(this, data)));

                return result;
            }

            public override StringBuilder VisitDirectionExpression(DirectionExpression directionExpression, int data)
            {
                // at invocation time we wont pass out or inout keywords so
                // this just passes through
                return directionExpression.Expression.AcceptVisitor(this, data);
            }

            public override StringBuilder VisitConditionalExpression(ConditionalExpression conditionalExpression, int data)
            {
                var result = conditionalExpression.Condition.AcceptVisitor(this, data);
                var trueCond = conditionalExpression.TrueExpression.AcceptVisitor(this, data);
                var falseCond = conditionalExpression.FalseExpression.AcceptVisitor(this, data);
                return result.Append(" ? ").Append(trueCond).Append(" : ").Append(falseCond);
            }

            public override StringBuilder VisitNewLine(NewLineNode newLineNode, int data)
            {
                return new StringBuilder().AppendLine();
            }

            public override StringBuilder VisitIndexerExpression(IndexerExpression indexerExpression, int data)
            {
                var result = new StringBuilder();

                result.Append(indexerExpression.Target.AcceptVisitor(this, data)).Append("[");
                foreach (var a in indexerExpression.Arguments)
                {
                    result.Append(a.AcceptVisitor(this, data)).Append(",");
                }

                result.Remove(result.Length - 1, 1).Append("]");

                return result;
            }

            public override StringBuilder VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, int data)
            {
                var result = new StringBuilder();
                var t = arrayCreateExpression.Arguments.Count > 0
                    ? arrayCreateExpression.Arguments.First().AcceptVisitor(this, data)
                    : new StringBuilder().Append(arrayCreateExpression.Initializer.Elements.Count);

                result.Append(arrayCreateExpression.Type.AcceptVisitor(this, data));
                result.Append("[");
                result.Append(t);
                result.Append("]");
                result.Append("(");

                if (arrayCreateExpression.Initializer != null && arrayCreateExpression.Initializer.Elements.Count > 0)
                {
                    foreach (var item in arrayCreateExpression.Initializer.Elements)
                    {
                        result.Append(item.AcceptVisitor(this, data));
                        result.Append(",");
                    }

                    result.Remove(result.Length - 1, 1);
                }

                result.Append(")");

                return result;
            }

            public override StringBuilder VisitComposedType(ComposedType composedType, int data)
            {
                var result = new StringBuilder();

                result.Append(composedType.BaseType.AcceptVisitor(this, data));

                foreach (var spec in composedType.ArraySpecifiers)
                {
                    result.Append(spec);
                }

                return result;
            }

            public override StringBuilder VisitIdentifier(Identifier identifier, int data)
            {
                var result = new StringBuilder();
                var ilVar = identifier.Parent.FirstChild.Annotation<ICSharpCode.Decompiler.IL.ILVariable>();

                if (ilVar == null || ilVar.Type.Kind != ICSharpCode.Decompiler.TypeSystem.TypeKind.Array) return result;

                switch (identifier.Name)
                {
                    case "Length":
                    case "LongLength":
                        result.Append("length()");
                        break;

                    default:
                        throw new ASLException($"ASL doesn\'t support member \"{identifier.Name}\" from arrays.");
                }

                return result;
            }

            public override StringBuilder VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, int data)
            {
                var result = new StringBuilder();
                result.Append("(");
                result.Append(parenthesizedExpression.Expression.AcceptVisitor(this, data));
                result.Append(")");
                return result;
            }
        }
    }
}