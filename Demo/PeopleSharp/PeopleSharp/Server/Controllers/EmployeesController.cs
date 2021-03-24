using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleSharp.Server.DataAccess;
using PeopleSharp.Shared;
using PeopleSharp.Shared.Utility;
using System.Collections.Generic;

namespace PeopleSharp.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            DaoEmployees daoEmployees = new();
            return daoEmployees.GetAllEmployees();
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public string GetEmployeeInfo(string firstName, string lastName)
        {
            PersonalNameUtility personalNameUtility = new();
            return personalNameUtility.FormatShortInfo(firstName, lastName);
        }

        [AllowAnonymous]
        [HttpPut("[action]")]
        public void UpdateEmployee()
        {
            DaoEmployees daoEmployees = new();
            daoEmployees.UpdateEmployee();
        }
    }
}
