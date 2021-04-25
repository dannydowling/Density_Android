using Xamarin.Forms;

namespace Density
{
    class AboutPage : ContentPage
    {
        public void AboutCreate()
        {

            Image banner = new Image();
            banner.HeightRequest = 100;
            banner.Source = "Banner.png";

            Label caution = new Label();
            caution.FontSize = 10;
            caution.HorizontalTextAlignment = TextAlignment.Center;
            caution.Text = "Use with caution.I'm not guaranteeing the results.";

            Label email = new Label();
            email.FontSize = 10;
            email.HorizontalTextAlignment = TextAlignment.Center;
            email.Text = "To communicate with the developer";

            Label email2 = new Label();
            email2.FontSize = 10;
            email2.HorizontalTextAlignment = TextAlignment.Center;
            email2.Text = "send an email to FuelDensityApp@gmail.com";

            ZoomContainer zoom = new ZoomContainer();
            Image aboutinfo = new Image();
            aboutinfo.Source = "aboutinfo.png";
            zoom.HeightRequest = 2000;
            zoom.Content = aboutinfo;

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
                Children = { banner, caution, email, email2, zoom, menu }
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

