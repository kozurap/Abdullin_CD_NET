using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace calculatorClientCSharp
{
    public class ExpressionCalcVisitor:ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.Type.Name == "MethodConstantExpression")
                return node;
            Expression left = node.Left;
            Expression right = node.Right;
            double x = 0;
            double y = 0;
            double.TryParse(left.ToString(), out x);
            double.TryParse(right.ToString(), out y);
            Expression c1 = Expression.Constant(x);
            Expression c2 = Expression.Constant(y);
            if (left is BinaryExpression && !(right is BinaryExpression))
            {
                c1 = this.VisitBinary((BinaryExpression)left);
            }
            else if (!(left is BinaryExpression) && right is BinaryExpression)
            {
                c2 = this.VisitBinary((BinaryExpression)right);
            }
            else if (left is BinaryExpression && right is BinaryExpression)
            {
                c1 = this.VisitBinary((BinaryExpression)left);
                c2 = this.VisitBinary((BinaryExpression)right);
            }

            Expression Answ;
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    Answ = Expression.Constant(ExpressionSender.GetRespAsync(node.Left.ToString(),
                        node.Right.ToString(),
                        "+"));
                    break;
                case ExpressionType.Subtract:
                    Answ = Expression.Constant(ExpressionSender.GetRespAsync(node.Left.ToString(),
                        node.Right.ToString(),
                        "-"));
                    break;
                case ExpressionType.Multiply:
                    Answ = Expression.Constant(ExpressionSender.GetRespAsync(node.Left.ToString(),
                        node.Right.ToString(),
                        "*"));
                    break;
                case ExpressionType.Divide:
                    Answ = Expression.Constant(ExpressionSender.GetRespAsync(node.Left.ToString(),
                        node.Right.ToString(),
                        "/"));
                    break;
                default: throw new ArgumentException();
            }

            return Answ;
        }

        public static async Task<string> Calculate(Expression exp)
        {
            var a = new ExpressionCalcVisitor();
            var x = a.VisitBinary((BinaryExpression)exp);
            return x.ToString();
        }
    }
}