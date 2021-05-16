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

        [Parameter]
        public EventCallback<bool> closeEmployeeEventCallback { get; set; }

        public EmployeeModel employee { get; set; }
        
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


            if (string.IsNullOrEmpty(employee.LastName)) //new employee is being created
            {
                //add some defaults
                employee = new EmployeeModel ( "", "", "", "", "", "", "");
            }
            else
            {
                employee = await employeeDataService.GetEmployeeDetails(employee.FirstName + " " + employee.LastName);
            }
        }

        protected async Task HandleValidSubmit()
        {
            try
            {
                await employeeDataService.UpdateEmployee(employee);
                StateHasChanged();
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
            catch (Exception)
            {
                EmployeeModel tempEmployee = await employeeDataService.GetEmployeeDetails(employee.FirstName + "" + employee.LastName );
                await employeeDataService.DeleteEmployee(employee.FirstName + " " + employee.LastName);
                await employeeDataService.AddEmployee(tempEmployee);
                StateHasChanged();
                StatusClass = "alert-success";
                Message = "New employee added successfully.";
                Saved = true;
            }

           await closeEmployeeEventCallback.InvokeAsync(true);
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await employeeDataService.DeleteEmployee(employee.FirstName + " " + employee.LastName);

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
