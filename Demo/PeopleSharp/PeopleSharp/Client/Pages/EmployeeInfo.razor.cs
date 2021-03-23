using PeopleSharp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PeopleSharp.Client.Pages
{
    public partial class EmployeeInfo
    {
        [CascadingParameter]
        Employee? SelectedEmployee { get; set; }
        bool IsSelectedEmployeeChanged { get; set; }
        string EmployeeShortInfo { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (SelectedEmployee is not null)
                EmployeeShortInfo = await Http.GetStringAsync($"api/Employees/GetEmployeeInfo?firstName={SelectedEmployee.FirstName}&lastName={SelectedEmployee.LastName}");
            else
                EmployeeShortInfo = string.Empty;
        }

        void RecalculateVacationDays()
        {
            if (SelectedEmployee == null)
                return;

            VacationDaysCalculator calculator = new();
            int newVacationDays = calculator.Calculate(SelectedEmployee);

            if (newVacationDays != SelectedEmployee.VacationDays)
            {
                IsSelectedEmployeeChanged = true;

                int oldVacationDays = SelectedEmployee.VacationDays;
                Employee newEmployee = SelectedEmployee with { VacationDays = newVacationDays };
                Employee newEmployeeOldVacationDays = newEmployee with { VacationDays = oldVacationDays };
                SelectedEmployee = newEmployee;
            }
        }

        protected override void OnParametersSet()
        {
            IsSelectedEmployeeChanged = false;
        }

        async Task UpdateEmployeeAsync()
        {
            if (SelectedEmployee == null || !IsSelectedEmployeeChanged)
                return;

            await Http.PutAsJsonAsync<Employee>("api/Employees/UpdateEmployee", SelectedEmployee);
        }
    }
}
