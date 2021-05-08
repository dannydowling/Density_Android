using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PreFlightAI.Server.Services;
using PreFlightAI.Shared;

namespace PreFlightAI.Server.Pages
{
    public class LocationOverviewBase: ComponentBase
    {
        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }

        [Inject]
        public ILocationDataService locationDataService { get; set; }

        public List<Employee> employees { get; set; }

        protected AddLocationDialogBase AddEmployeeDialog { get; set; }

        IEnumerable<Location> employeeLocations { get; set; }
          

        protected override async Task OnInitializedAsync()
        {
            employeeLocations = (await locationDataService.GetAllLocations()).ToList();
            employees = (await employeeDataService.GetAllEmployees(employeeLocations)).ToList();
        }
        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }
    }
}
