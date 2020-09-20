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
                int a = int.Parse(input[0]);
                string mark = input[1];
                int b = int.Parse(input[2]);
                var calc = new Calculator(a, b, mark);
                int res = calc.Calculate();
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