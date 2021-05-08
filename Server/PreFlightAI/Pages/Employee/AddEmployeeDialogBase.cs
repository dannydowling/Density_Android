
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Shared;
using DensityServer.Server.Services;


namespace DensityServer.Server.Pages
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject]
        public IEmployeeDataService? employeeDataService { get; set; }
        public Employee employee { get; set; }

        

        public void Show()
        {
           
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            employee = new Employee { Id = 0, firstName = "", city = "" };
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {

            if (employeeDataService != null)
            {
                await employeeDataService.AddEmployee(employee);
                ShowDialog = false;

                await CloseEventCallback.InvokeAsync(true);
                StateHasChanged();
            }
          
        }
    }
}
