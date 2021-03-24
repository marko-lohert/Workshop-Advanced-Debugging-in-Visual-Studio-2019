using System;

namespace ResearchDataBreakpoints
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee();
            Employee employee2 = new Employee();
            Employee employee3 = new Employee();
            // ...

            employee1.FirstName = "John";
            employee1.LastName = "Smith";
            employee2.FirstName = "Jane";
            employee2.LastName = "Smith";
            employee3.FirstName = "John";
            employee3.LastName = "Doe";

            BusinessLogic1 logic1 = new BusinessLogic1();
            BusinessLogic2 logic2 = new BusinessLogic2();
            BusinessLogic3 logic3 = new BusinessLogic3();

            logic1.Method1(employee1, employee2, employee3);
            logic1.Method2(employee1, employee2, employee3);
            logic1.Method3(employee1, employee2, employee3);
            logic2.Method4(employee1, employee2, employee3);
            logic2.Method5(employee1, employee2, employee3);
            logic3.Method6(employee1, employee2, employee3);
            logic3.Method7(employee1, employee2, employee3);
            logic3.Method8(employee1, employee2, employee3);

            Console.WriteLine($"Employee2:\n\tFirst Name: {employee2.FirstName}\n\tLast Name:  {employee2.LastName}");


        }
    }
}
