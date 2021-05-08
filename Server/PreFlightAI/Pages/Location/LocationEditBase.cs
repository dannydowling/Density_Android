using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Shared;
using DensityServer.Server.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace DensityServer.Server.Pages
{
    public class LocationEditBase : ComponentBase
    {
        [Inject]
        public ILocationDataService locationDataService { get; set; }

        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        public Location location { get; set; }
        
        [Parameter]
        public string Id { get; set; }        

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        public List<Location> Locations { get; set; } = new List<Location>();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Locations = (await locationDataService.GetAllLocations()).ToList();            

            if (Id == "") //new location
            {
                //add some defaults
                location = new Location { city = "", icao = "", name = "", state = "", lat = 0, lon = 0};
            }
            else
            {
                location = await locationDataService.GetLocationById(location.icao);
            }

        }

        protected async Task HandleValidSubmit()
        {

            if (string.IsNullOrEmpty(location.icao)) //new
            {
                var addedLocation = await locationDataService.AddLocation(location);
                if (addedLocation != null)
                {
                    StatusClass = "alert-success";
                    Message = "New location added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new location. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await locationDataService.UpdateLocation(location);
                StatusClass = "alert-success";
                Message = "Location updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteLocation()
        {
            await locationDataService.DeleteLocation(location.icao);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/locationoverview");
        }
    }
}
