using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Shared;
using DensityServer.Server.Services;

namespace DensityServer.Server.Pages
{
    public class LocationDetailBase : ComponentBase
    {
        [Inject]
        public ILocationDataService locationDataService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Location location { get; set; } = new Location();

        protected override async Task OnInitializedAsync()
        {
            location = await locationDataService.GetLocationById(Id);
        }
    }
}
