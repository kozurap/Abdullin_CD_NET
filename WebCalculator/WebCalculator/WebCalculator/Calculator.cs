using System;

namespace WebCalculator
{
    static public class Calculator
    {
        static public double Calculate(double a, double b, string sign)
        {
            if(b==0 && sign=="/")
                throw new Exception("Division by zero");
            switch (sign)
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