
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PreFlightAI.Shared;
using PreFlightAI.Server.Services;

namespace PreFlightAI.Server.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
       
        public Employee employee { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employee = await employeeDataService.GetEmployeeDetails(int.Parse(Id));
            
        }
    }
}
