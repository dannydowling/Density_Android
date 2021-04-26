using Xamarin.Forms;

namespace Density
{
    class FlightRadarPage : ContentPage
    {
        public void FlightRadarCreate()
        {
            var browser = new WebView
            { 
                Source = string.Format("https://www.flightradar24.com/{0},{1}/8", App.location.lon, App.location.lat),
                WidthRequest = 400, 
                HeightRequest = 800 
        };

            var menu = new SpringBoardButton();
            menu.Icon = "Exit.png";
            menu.Label = "Exit";
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Navigation.PopModalAsync();
            };
            menu.GestureRecognizers.Add(tapGestureRecognizer);

            var segments = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                Children = { browser, menu }
            };

            Content = new ScrollView
            {
                BackgroundColor = Color.White,
                Orientation = ScrollOrientation.Both,
                Content = segments
            };
        }
    }
}

