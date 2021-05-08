using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PreFlightAI.Shared;
using PreFlightAI.Server.Services;


namespace PreFlightAI.Server.Pages
{
    public class AddLocationDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject]
        public ILocationDataService locationDataService { get; set; }
        public Location location { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }


        private void ResetDialog()
        {
            location = new Location { state = "", city = "", icao = "", name = "", lat = 0, lon = 0};
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {

            if (locationDataService != null)
            {
                await locationDataService.AddLocation(location);
                ShowDialog = false;

                await CloseEventCallback.InvokeAsync(true);
                StateHasChanged();
            }
          
        }
    }
}
