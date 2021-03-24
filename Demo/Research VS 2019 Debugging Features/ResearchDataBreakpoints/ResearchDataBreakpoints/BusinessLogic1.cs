namespace ResearchDataBreakpoints
{
    class BusinessLogic1
    {
        public void Method1(Employee employee1, Employee employee2, Employee employee3)
        {
            employee1.FirstName = "Jake";
            Method2(employee1, employee2, employee3);
            Method3(employee1, employee2, employee3);
        }

        public void Method2(Employee employee1, Employee employee2, Employee employee3)
        {
            employee3.FirstName = "James";
        }

        public void Method3(Employee employee1, Employee employee2, Employee employee3)
        {
            employee1.FirstName = "Robert";
        }
    }
}
