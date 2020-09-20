using System;
namespace ConsoleApplication1
{
    public class Calculator
    {
        int a;
        int b;
        string @operator;
        public Calculator(int A,int B,string @Operator)
        {
            a = A;
            b = B;
            @operator = @Operator;
        }
        public int Calculate()
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
            throw new Exception("Invalid smth");
        }    
    }
}