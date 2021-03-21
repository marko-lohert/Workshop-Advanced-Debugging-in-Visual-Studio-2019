﻿using PeopleSharp.Shared;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PeopleSharp.Client.Pages
{
    public partial class EmployeeDirectory
    {
        List<Employee>? ListAllEmployees { get; set; }
        Employee? SelectedEmployee { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ListAllEmployees = await Http.GetFromJsonAsync<List<Employee>>("api/Employees/GetAllEmployees");
        }
    }
}
