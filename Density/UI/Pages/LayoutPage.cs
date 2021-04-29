using Android.Content;
using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System;
using Xamarin.Forms;

namespace Density
{

    public interface ILaunchBrowserPage
    { void StartBrowser(double lat, double lon); }

    public class LayoutPage : ContentPage
    {
        protected static LocationClass locationClass = new LocationClass();
        protected static WeatherClass weatherClass = new WeatherClass();
        protected static DensityClass densityClass = new DensityClass();

        LocationHelper locationHelper = new LocationHelper(locationClass);
        WeatherHelper weatherHelper = new WeatherHelper();
        DensityHelper densityHelper = new DensityHelper();

        public void LayoutCreate()
        {
            try
            {
                Image banner = new Image();
                banner.HeightRequest = 100;
                banner.Source = "Banner.png";

                var FuelWeight = new SpringBoardButton();
                FuelWeight.Icon = "API.png";
                FuelWeight.Label = "Set Location";
                var FuelWeighttapGestureRecognizer = new TapGestureRecognizer();
                FuelWeight.GestureRecognizers.Add(FuelWeighttapGestureRecognizer);
                FuelWeighttapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        DensityPage densityPage = new DensityPage();
                        densityPage.DensityPageCreate(locationHelper, weatherHelper, densityHelper, locationClass, weatherClass, densityClass);
                        await Navigation.PushModalAsync(densityPage);
                    };



                var Map = new SpringBoardButton();
                Map.Icon = "Map.png";
                Map.Label = "Map of Airport";
                var MaptapGestureRecognizer = new TapGestureRecognizer();
                Map.GestureRecognizers.Add(MaptapGestureRecognizer);
                MaptapGestureRecognizer.Tapped += async (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(locationClass.icao))
                    {
                        MapPage mapPage = new MapPage();
                        mapPage.MapCreate(locationClass);
                        await Navigation.PushModalAsync(mapPage);
                    }
                    if (string.IsNullOrWhiteSpace(locationClass.icao))
                    {
                        DensityPage densityPage = new DensityPage();
                        densityPage.DensityPageCreate(locationHelper, weatherHelper, densityHelper, locationClass, weatherClass, densityClass);
                        await Navigation.PushModalAsync(densityPage);
                    }
                };


                var Timer = new SpringBoardButton();
                Timer.Icon = "Timer.png";
                Timer.Label = "Holdover Timer";
                var TimertapGestureRecognizer = new TapGestureRecognizer();
                Timer.GestureRecognizers.Add(TimertapGestureRecognizer);
                TimertapGestureRecognizer.Tapped += async (s, e) =>
                {
                    TimerPage timerPage = new TimerPage();
                    timerPage.TimerCreate(weatherClass);
                    await Navigation.PushModalAsync(timerPage);
                };

                var About = new SpringBoardButton();
                About.Icon = "About.png";
                About.Label = "About";
                var AbouttapGestureRecognizer = new TapGestureRecognizer();
                About.GestureRecognizers.Add(AbouttapGestureRecognizer);
                AbouttapGestureRecognizer.Tapped += async (s, e) =>
                {
                    AboutPage aboutPage = new AboutPage();
                    aboutPage.AboutCreate();
                    await Navigation.PushModalAsync(aboutPage);
                };

                var Route = new SpringBoardButton();
                Route.Icon = "FuelDensity.png";
                Route.Label = "Create Route";
                var RoutetapGestureRecognizer = new TapGestureRecognizer();
                Route.GestureRecognizers.Add(RoutetapGestureRecognizer);
                RoutetapGestureRecognizer.Tapped += async (s, e) =>
                {
                    RoutePickerPage routePage = new RoutePickerPage();
                    routePage.RouteCreate(locationHelper, locationClass);
                    await Navigation.PushModalAsync(routePage);
                };


        var FlightRadar = new SpringBoardButton();
                FlightRadar.Icon = "Tracking.png";
                FlightRadar.Label = "Flight Tracking";
                var FlightRadartapGestureRecognizer = new TapGestureRecognizer();
                FlightRadar.GestureRecognizers.Add(FlightRadartapGestureRecognizer);
                FlightRadartapGestureRecognizer.Tapped += async (s, e) =>
                {
                    DependencyService.Register<ILaunchBrowserPage>();
                    DependencyService.Get<ILaunchBrowserPage>().StartBrowser(locationClass.lat, locationClass.lon);
                };

                var Exit = new SpringBoardButton();
                Exit.Icon = "MenuExit.png";
                Exit.Label = "Exit";
                var ExittapGestureRecognizer = new TapGestureRecognizer();
                Exit.GestureRecognizers.Add(ExittapGestureRecognizer);
                ExittapGestureRecognizer.Tapped += (s, e) =>
                {
                    Environment.Exit(0);
                };

                Grid grid = new Grid();

                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                RowDefinition rowDef3 = new RowDefinition();

                grid.RowDefinitions.Add(rowDef1);
                grid.RowDefinitions.Add(rowDef2);
                grid.RowDefinitions.Add(rowDef3);


                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();

                grid.ColumnDefinitions.Add(colDef1);
                grid.ColumnDefinitions.Add(colDef2);



                Grid.SetRow(Route, 0);
                Grid.SetColumn(Route, 1);
                Grid.SetRow(FuelWeight, 0);
                Grid.SetColumn(FuelWeight, 0);
                Grid.SetRow(Map, 1);
                Grid.SetColumn(Map, 0);
                Grid.SetRow(Timer, 1);
                Grid.SetColumn(Timer, 1);
                Grid.SetRow(FlightRadar, 2);
                Grid.SetColumn(FlightRadar, 0);
               // Grid.SetRow(About, 2);
               //Grid.SetColumn(About, 0);
                Grid.SetRow(Exit, 2);
                Grid.SetColumn(Exit, 1);

                grid.Children.Add(Route);
                grid.Children.Add(FuelWeight);
                grid.Children.Add(Map);
                grid.Children.Add(Timer);
                grid.Children.Add(FlightRadar);
               // grid.Children.Add(About);
                grid.Children.Add(Exit);

                var segments = new StackLayout
                {
                    Spacing = 0,
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.White,
                    Children = { banner, grid }
                };

                var view = new RelativeLayout();
                {
                    view.Children.Add(segments,
                    xConstraint: Constraint.Constant(0),
                    yConstraint: Constraint.Constant(0),
                    widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                    heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
                };
                Content = view;
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("The layout on the page failed to load.", "Check the layout page and try again", "OK");
            }
        }
    }
}
