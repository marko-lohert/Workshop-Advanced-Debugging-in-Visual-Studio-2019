using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PeopleSharp.Shared.Tests
{
    [TestClass]
    public class VacationDaysCalculator_Tests
    {
        [TestMethod]
        public void Calculate_4_YearsWithCompany()
        {
            // Arange
            Employee employee = new()
            {
                FirstName = "John",
                LastName = "Smith",
                DateOfEmployment = DateTime.Now.AddYears(-4),
                VacationDays = 20
            };
            int expectedVacationDays = 21;
            VacationDaysCalculator calculator= new();

            // Act
            int actualVacationDays = calculator.Calculate(employee);

            // Assert
            Assert.AreEqual(expectedVacationDays, actualVacationDays);    
        }
    }
}
