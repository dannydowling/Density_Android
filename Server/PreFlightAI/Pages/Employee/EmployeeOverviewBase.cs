using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Server.Services;
using DensityServer.Shared;

namespace DensityServer.Server.Pages
{
    public class EmployeeOverviewBase: ComponentBase
    {
        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        public List<Employee> employees { get; set; }
        public List<Location> employeeLocations { get; set; }

        protected AddLocationDialogBase AddEmployeeDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employeeLocations = (await LocationDataService.GetAllLocations()).ToList();
            employees = (await employeeDataService.GetAllEmployees(employeeLocations)).ToList();
        }

        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }

        public async void AllEmployeesDialog_OnDialogClose()
        {
            employees = (await employeeDataService.GetAllEmployees(employeeLocations)).ToList();
            StateHasChanged();
        }
    }
}
