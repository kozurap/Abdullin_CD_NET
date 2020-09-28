using System;
namespace ConsoleApplication1
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length != 3)
                throw new Exception("Invalid input");
            try
            {
                double a = double.Parse(input[0]);
                string mark = input[1];
                double b = double.Parse(input[2]);
                var res = Calculator.Calculate(a,b,mark);
                Console.WriteLine(res);
            }
            catch
            {
                throw new Exception("invalid input");
            }

            Console.ReadKey();
        }
    }
}