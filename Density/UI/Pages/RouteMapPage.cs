
using System;
using System.Collections.Generic;
using System.Text;
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

        public void RouteMapCreate()
        {
            #region Define the map and what's on it
            map = new CustomMap
            {                
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill
            };

            map.MapType = MapType.Hybrid;

            map.RouteCoordinates.Add(new Position(SourceLocation.lat, SourceLocation.lon));
            map.RouteCoordinates.Add(new Position(DestinationLocation.lat, DestinationLocation.lon));


            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(SourceLocation.lat, SourceLocation.lon), Distance.FromMiles(4.0)));


            var maptype = new Button { Text = "Map Type" };
            var waypoint = new Button { Text = "Waypoint" };
            var menu = new Button { Text = "Menu" };

            maptype.Clicked += MapClicked;
            waypoint.Clicked += WaypointClicked;
            menu.Clicked += MenuClicked;

            void MenuClicked(object sender, EventArgs e)
            {
                var b = sender as Button;
                {
                    Navigation.PopModalAsync();
                }
            }

            void WaypointClicked(object sender, EventArgs e)
            {
                var b = sender as Button;
                {

                }
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
                Children = { maptype, waypoint, menu }
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