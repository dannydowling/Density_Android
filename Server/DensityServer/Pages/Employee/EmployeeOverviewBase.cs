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
        public ILocationDataService locationDataService { get; set; }

        public List<Employee> employees { get; set; }
        protected IEnumerable<string> employeeLocations { get; set; }
        private IEnumerable<Location> allLocations { get; set; }


        protected AddEmployeeDialogBase AddEmployeeDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (employeeLocations != null)
            {
                //get all the locations
                allLocations = (await locationDataService.GetAllLocations());

                //reduce the location list down to match the employees list of icao codes.
              allLocations = allLocations.Where(x => x.icao.AsEnumerable() == employeeLocations);
            }

        }
        
        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.ShowEmployeeDialog();
        }

        public void AllEmployeesDialog_OnDialogClose()
        {           
            StateHasChanged();
        }
    }
}
