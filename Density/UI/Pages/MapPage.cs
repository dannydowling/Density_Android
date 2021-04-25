using Android.Content;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Density
{
    class MapPage : ContentPage
    {        
        Map map;

        public void MapCreate()
        {            
            try
            {
                #region Get the Position
                App.location.Latitude = Convert.ToDouble(App.getLocation.latitude(App.location.Icao));
                App.location.Longitude = Convert.ToDouble(App.getLocation.longitude(App.location.Icao));
                #endregion

                #region Define the map and what's on it
                map = new Map
                {
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                };

                map.MapType = MapType.Street;
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position
                    (App.location.Latitude, App.location.Longitude), Distance.FromMiles(0.6)));

                var slider = new Slider(12, 18, 1);
                slider.ValueChanged += (sender, e) =>
                {
                    var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                    if (map.VisibleRegion != null)
                        map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
                };
                var maptype = new Button { Text = "Map Type" };
                var street = new Button { Text = "Street" };
                var menu = new Button { Text = "Menu" };

                maptype.Clicked += MapClicked;
                street.Clicked += StreetClicked;
                menu.Clicked += MenuClicked;

                void MenuClicked(object sender, EventArgs e)
                {
                    var b = sender as Button;
                    {
                        Navigation.PopModalAsync();
                    }
                }

                void StreetClicked(object sender, EventArgs e)
                {
                    var b = sender as Button;
                    {
                        Android.Net.Uri gmmIntentUri = Android.Net.Uri.Parse("google.streetview:cbll=" + App.location.Latitude + "," + App.location.Longitude);
                        Intent mapIntent = new Intent(Intent.ActionView, gmmIntentUri);
                        mapIntent.SetPackage("com.google.android.apps.maps");
                        Android.App.Application.Context.StartActivity(mapIntent);
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
                    Children = { maptype, street, menu }
                };

                var stack = new RelativeLayout();

                stack.Children.Add(map,
                xConstraint: Constraint.Constant(0),
                    yConstraint: Constraint.Constant(0),
                    widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                    heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));

                stack.Children.Add(slider,
                 xConstraint: Constraint.Constant(0),
                 yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height * 0.1; }));

                stack.Children.Add(segments,
                 xConstraint: Constraint.Constant(0),
                 yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width * 0.7; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height * 0.92; }));

                #endregion
                Content = stack;
                Content.IsVisible = true;
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("The map failed to load.", "Check the code and try again", "OK");
            }
        }
    }
}



