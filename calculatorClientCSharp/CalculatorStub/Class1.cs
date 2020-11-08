using System;

namespace CalculatorStub
{
    public class Calculator
    {
        double a;
        double b;
        string @operator;
        public Calculator(double A,double B,string @Operator)
        {
            a = A;
            b = B;
            @operator = @Operator;
        }
        public double Calculate()
        {
            switch (@operator)
            {
                case "+":
                    return (a + b);

                case "-":
                    return (a - b);

                case "/":
                    return (a / b);

                case "*":
                    return (a * b);

            }
            throw new Exception();
        }    
    }
}