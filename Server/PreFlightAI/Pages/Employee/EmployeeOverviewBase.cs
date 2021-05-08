using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PreFlightAI.Server.Services;
using PreFlightAI.Shared;

namespace PreFlightAI.Server.Pages
{
    public class EmployeeOverviewBase: ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Location> employeeLocations { get; set; }

        protected AddLocationDialogBase AddEmployeeDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employeeLocations = (await LocationDataService.GetAllLocations()).ToList();
            Employees = (await EmployeeDataService.GetAllEmployees(employeeLocations)).ToList();
        }

        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }
    }
}
