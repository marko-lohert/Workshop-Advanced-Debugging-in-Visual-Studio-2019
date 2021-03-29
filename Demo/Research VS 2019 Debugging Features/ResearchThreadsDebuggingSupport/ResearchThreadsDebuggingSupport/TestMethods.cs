using System;
using System.Threading;

namespace Threads
{
    public class TestMethods
    {
        private Random Rnd { get; init; } = new();
        private const int minRnd = 100;
        private const int maxRnd = 1000;

        public void MethodA()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"MethodA: i = {i}");
                Thread.Sleep(Rnd.Next(minRnd, maxRnd));
            }
        }

        public void MethodB()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"MethodB: i = {i}");
                Thread.Sleep(Rnd.Next(minRnd, maxRnd));
            }
        }

        public void MethodC()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"MethodC: i = {i}");
                Thread.Sleep(Rnd.Next(minRnd, maxRnd));
                
                MethodC1();
            }
        }

        public void MethodC1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"MethodC1: i = {i}");
                Thread.Sleep(Rnd.Next(minRnd, maxRnd));

                MethodC2();
            }
        }

        public void MethodC2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"MethodC2: i = {i}");
                Thread.Sleep(Rnd.Next(minRnd, maxRnd));
            }
        }
    }
}
