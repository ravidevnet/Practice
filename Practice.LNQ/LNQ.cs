using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LNQ
{
    public class LNQ
    {
        private delegate int IncDelegate(int x);

        public IncDelegate AnonymousMethod = delegate(int x) { return x + 1; };

        public IncDelegate LamdaExpression = x => x + 1;

        public Func<double, double, double> TraiangleArea = (b, h) => b * h / 2;

        /*
         * Opertors (*, /): BinaryExpression
         * Parameters(b,h): ParameterExpression
         * constants (2): ConstantExpression
         */
        public Expression<Func<double, double, double>> TriangleAreaExp = (b, h) => b * h / 2;

        private static int DoubleMetohod(int n)
        {
            return n * 2;
        }

        /* 
         * DoubleMethod : MethodCallExpression
         * x : ParameterExpression
         * + : BinaryExpression
         * 1: ConstantExpression
         */
        public Expression<Func<int, int>> MethodCallInExpression = (x) => DoubleMetohod(x) + 1;

        private static Func<int, int> DoubleFunc = (n) => n * 2;

        /*
         * DoubleFunc : InvocationExpression
         */
        public Expression<Func<int, int>> FuncCallInEpression = (x) => DoubleFunc(x) + 1;

        /*
         * Using C# syntax of a lamda expression to an expression tree, one cannot combine an existing expression tree with a new one.In lamda expression, an expression tree
         * has to be compiled before it can used.
         */
        private static Expression<Func<int, int>> DoubleExpression = (n) => n * 2;
        public Expression<Func<int, int>> ExpressionCallInExpression = (x) => DoubleExpression.Compile()(x) + 1;

    }
}
