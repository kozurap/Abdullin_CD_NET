using System;
namespace ConsoleApplication1
{
    static public class Calculator
    {
        static public double Calculate(double A, double B, string Sign)
        {
            if(B==0 && Sign=="/")
                throw new Exception("Division by zero");
            switch (Sign)
            {
                case "+":
                    return (A + B);

                case "-":
                    return (A - B);

                case "/":
                    return (A / B);

                case "*":
                    return (A * B);

            }
            throw new Exception("Invalid smth");
        }    
    }
}