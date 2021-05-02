using Density.Business_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Density
{
    public class CustomMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }
        public CustomMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }

    public class RouteMapPage : ContentPage
    {

        CustomMap map;
        private Label duration { get; set; }

        public void RouteMapCreate(LocationClass sourceLocation, LocationClass destinationLocation, AircraftClass aircraftClass)
        {
            Label duration = new Label();
            duration.FontSize = 16;
            duration.WidthRequest = 150;
            duration.TextColor = Color.Black;
            duration.VerticalTextAlignment = TextAlignment.Center;
            duration.HorizontalTextAlignment = TextAlignment.Center;
            duration.Text = "  Time of flight:  ";


            #region Define the map and what's on it
            map = new CustomMap
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill
            };

            map.MapType = MapType.Hybrid;

            map.RouteCoordinates.Add(new Position(sourceLocation.lat, sourceLocation.lon));
            map.RouteCoordinates.Add(new Position(destinationLocation.lat, destinationLocation.lon));

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(sourceLocation.lat, sourceLocation.lon), Distance.FromMiles(4.0)));


            var maptype = new Button { Text = "Map Type" };
            var distance = new Button { Text = "Distance" };            
            var menu = new Button { Text = "Menu" };
            

            maptype.Clicked += MapClicked;
            distance.Clicked += DistanceClickedAsync;
            menu.Clicked += MenuClicked;

            async void MenuClicked(object sender, EventArgs e)
            {
                var b = sender as Button;
                {
                   await Navigation.PopModalAsync();
                }
            }

            async void DistanceClickedAsync(object sender, EventArgs e)
            {
                var b = sender as Button;
                b.Text = "Distance";
                DistanceCalculator distanceCalculator = new DistanceCalculator();
                var route = await distanceCalculator.GetInfoForRoute(3, sourceLocation, destinationLocation);                           
                b.Text = route.Distance.ToString();
                duration = new Label();
                duration.Text = distanceCalculator.getDurationOfRoute(b.Text, aircraftClass.speed);

            }


            void MapClicked(object sender, EventArgs e)
            {
                var b = sender as Button;
                switch (map.MapType)
                {
                    case MapType.Hybrid:
                        map.MapType = MapType.Street;
                        break;
                    case MapType.Satellite:
                        map.MapType = MapType.Hybrid;
                        break;
                    case MapType.Street:
                        map.MapType = MapType.Satellite;
                        break;
                }
            }
            #endregion

            #region Create the Page
            var segments = new StackLayout
            {
                Spacing = 1,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.End,
                Orientation = StackOrientation.Horizontal,
                Children = { maptype, distance, menu, duration }
            };

            var stack = new RelativeLayout();

            stack.Children.Add(map,
            xConstraint: Constraint.Constant(0),
                            yConstraint: Constraint.Constant(0),
                            widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                            heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));

            stack.Children.Add(segments,
             xConstraint: Constraint.Constant(0),
             yConstraint: Constraint.Constant(0),
            widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width * 0.7; }),
            heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height * 0.92; }));

            #endregion
            Content = stack;
            Content.IsVisible = true;

        }
    }
}