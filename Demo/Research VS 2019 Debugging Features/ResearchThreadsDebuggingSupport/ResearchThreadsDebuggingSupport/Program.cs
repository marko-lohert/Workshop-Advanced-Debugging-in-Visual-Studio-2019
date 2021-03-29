using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_3Threads_AllMethods();

            //Test_4Threads_1Method();
        }

        private static void Test_3Threads_AllMethods()
        {
            TestMethods testMethods = new();

            Thread threadA = new(testMethods.MethodA);
            threadA.Start();

            Thread threadB = new(testMethods.MethodB);
            threadB.Start();

            Thread threadC = new(testMethods.MethodC);
            threadC.Start();
        }

        private static void Test_4Threads_1Method()
        {
            TestMethods testMethods = new();

            Thread threadA1 = new(testMethods.MethodA);
            threadA1.Start();

            Thread threadA2 = new(testMethods.MethodA);
            threadA2.Start();

            Thread threadA3 = new(testMethods.MethodA);
            threadA3.Start();

            Thread threadA4 = new(testMethods.MethodA);
            threadA4.Start();
        }
    }
}
