namespace ResearchDataBreakpoints
{
    class BusinessLogic3
    {
        public void Method6(Employee employee1, Employee employee2, Employee employee3)
        {
            employee1.FirstName = "Jake";
            Method7(employee1, employee2, employee3);
            Method8(employee1, employee2, employee3);
        }

        public void Method7(Employee employee1, Employee employee2, Employee employee3)
        {
            employee3.LastName = "Martin";
        }

        public void Method8(Employee employee1, Employee employee2, Employee employee3)
        {
            employee1.LastName = "Michael";
        }
    }
}
