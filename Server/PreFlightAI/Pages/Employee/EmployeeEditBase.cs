using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PreFlightAI.Shared;
using PreFlightAI.Server.Services;
using Microsoft.AspNetCore.Components.Forms;


namespace PreFlightAI.Server.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }

        [Inject]
        public ILocationDataService locationDataService { get; set; }

        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        public Employee employee { get; set; }
        
        [Parameter]
        public string Id { get; set; }        

        public InputText LastNameInputText { get; set; }

        public InputText PasswordInputText { get; set; }


        //needed to bind to select to value
        protected string LocationId = string.Empty;
        protected string JobCategoryId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

       
        protected override async Task OnInitializedAsync()
        {
            Saved = false;       

            int.TryParse(Id, out var employeeId);

            if (employeeId == 0) //new employee is being created
            {
                //add some defaults
                employee = new Employee { Id = 0, city = "", email = "", firstName = "", lastName = "", password = "", street = "", zip = ""};
            }
            else
            {
                employee = await employeeDataService.GetEmployeeDetails(int.Parse(Id));
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (employee.Id == 0) //new
            {
                var addedEmployee = await employeeDataService.AddEmployee(employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await employeeDataService.UpdateEmployee(employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await employeeDataService.DeleteEmployee(employee.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
