using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_NET_HW1
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
            throw new Exception();
        }
    }
}
