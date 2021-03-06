
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Shared;
using DensityServer.Server.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace DensityServer.Server.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
       
        public EmployeeModel employee { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employee = await employeeDataService.GetEmployeeDetails(employee.FirstName + " " + employee.LastName);
            
        }
    }
}
