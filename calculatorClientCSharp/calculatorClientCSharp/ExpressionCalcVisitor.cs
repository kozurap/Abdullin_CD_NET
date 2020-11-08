using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace calculatorClientCSharp
{
    public  class ExpressionCalcVisitor:ExpressionVisitor
    {
        private IExpressionSender _sender;

        public ExpressionCalcVisitor(IExpressionSender sender)
        {
            _sender = sender;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Console.WriteLine("Calculating:"+node.ToString());
            Expression left = node.Left;
            Expression right = node.Right;
            Task<Expression> c1;
            Task<Expression> c2;
            c1 = Calculate(left);
            c2 = Calculate(right);
            var t = Task.WhenAll(c1, c2);
            t.Wait();
            string op;
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    op = "+";
                    break;
                case ExpressionType.Subtract:
                    op = "-";
                    break;
                case ExpressionType.Multiply:
                    op = "*";
                    break;
                case ExpressionType.Divide:
                    op = "/";
                    break;
                default: throw new ArgumentException();
            }

            var taskAnsw = _sender.GetRespAsync(c1.Result.ToString(), c2.Result.ToString(), op);
            taskAnsw.Wait();
            var answer = Expression.Constant(taskAnsw.Result);
            Console.WriteLine("Result = " + answer.ToString());
            return answer;
        }
        public async Task<Expression> Calculate(Expression exp)
        {
            var x = await Task.Run(() => Visit(exp));
            return x;
        }

        public override Expression Visit(Expression node)
        {
            if (node is BinaryExpression)
                return VisitBinary((BinaryExpression)node);
            return VisitConstant((ConstantExpression) node);
        }
        
        protected override Expression VisitConstant(ConstantExpression node)
        {
            return Expression.Constant(double.Parse(node.ToString()));
        }
    }
}