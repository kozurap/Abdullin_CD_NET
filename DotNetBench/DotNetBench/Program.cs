using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DotNetBench
{
    public class BenchmarkMethods
    {
        public static int StaticMethod()
        {
            int x = 1;
            int y = 2;
            x += y;
            return x;
        }

        public int InstanceMethod()
        {
            int x = 1;
            int y = 2;
            x += y;
            return x;
        }

        public int GenericMethod<T>(T z) where T : class
        {
            int x = 1;
            int y = 2;
            if (z != null)
                x += y;
            return x;
        }

        public static Func<int> virtualMethod = StaticMethod;
        public static dynamic b = new BenchmarkMethods();
            
        [Benchmark]
        public int StaticCall() => StaticMethod();
        
        [Benchmark]
        public int InstanceCall() => InstanceMethod();
        
        [Benchmark]
        public int VirtualCall() => virtualMethod();

        [Benchmark]
        public int GenericCall() => GenericMethod<string>("a");

        [Benchmark]
        public int DynamicCall() => b.InstanceMethod();

    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkMethods>();
        }
    }
}