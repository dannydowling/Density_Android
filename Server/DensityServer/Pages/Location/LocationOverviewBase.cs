using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DensityServer.Server.Services;
using DensityServer.Shared;

namespace DensityServer.Server.Pages
{
    public class LocationOverviewBase: ComponentBase
    {
        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }


        [Inject]
        public IGameDataService locationDataService { get; set; }

        public List<Location> locations { get; set; }

        protected AddLocationDialogBase AddLocationDialog { get; set; }
          
        protected void QuickAddLocation()
        {
            AddLocationDialog.Show();
        }

        public async void AllLocationsDialog_OnDialogClose()
        {
            locations = (await locationDataService.GetAllLocations()).ToList();
            StateHasChanged();
        }
    }
}
