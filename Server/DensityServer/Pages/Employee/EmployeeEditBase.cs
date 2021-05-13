using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Shared;
using DensityServer.Server.Services;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace DensityServer.Server.Pages
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


            if (string.IsNullOrEmpty(employee.EmployeeId)) //new employee is being created
            {
                //add some defaults
                employee = new Employee ( Guid.NewGuid().ToString(), "", "", "", "", "", "", "");
            }
            else
            {
                employee = await employeeDataService.GetEmployeeDetails(employee.EmployeeId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (string.IsNullOrEmpty(employee.EmployeeId)) //new
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
            await employeeDataService.DeleteEmployee(employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Employees");
        }
    }
}
