using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Shared;
using DensityServer.Server.Services;
using System;

namespace DensityServer.Server.Pages
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        protected bool showDialog { get; set; }

        [Parameter]
        public EventCallback<bool> closeEmployeeEventCallback { get; set; }

        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }
        public EmployeeModel employee { get; set; }

        public void ShowEmployeeDialog()
        {           
            ResetDialog();
            showDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            //string firstName, string lastName, string email, string street, string zip, string city, string password
            employee = new EmployeeModel ("", "","", "", "", "", "");
        }

        public void Close()
        {
            showDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {

            if (employeeDataService != null)
            {
                await employeeDataService.AddEmployee(employee);
                showDialog = false;

                await closeEmployeeEventCallback.InvokeAsync(true);
                StateHasChanged();
            }          
        }
    }
}
