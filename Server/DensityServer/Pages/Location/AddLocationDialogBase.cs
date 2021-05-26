using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Shared;
using DensityServer.Server.Services;


namespace DensityServer.Server.Pages
{
    public class AddLocationDialogBase : ComponentBase
    {
        protected bool showDialog { get; set; }

        [Parameter]
        public EventCallback<bool> closeLocationEventCallback { get; set; }

        [Inject]
        protected ILocationDataService locationDataService { get; set; }
        protected Location location { get; set; }

        public void Show()
        {
            ResetDialog();
            showDialog = true;
            StateHasChanged();
        }


        private void ResetDialog()
        {
            location = new Location { state = "", city = "", icao = "", name = "", lat = "", lon = ""};
        }

        public void Close()
        {
            showDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {

            if (locationDataService != null)
            {
                await locationDataService.AddLocation(location);
                showDialog = false;

                await closeLocationEventCallback.InvokeAsync(true);
                StateHasChanged();
            }
          
        }
    }
}
