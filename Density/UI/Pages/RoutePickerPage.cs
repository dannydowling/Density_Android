using Density.Business_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Density
{
    class RoutePickerPage : ContentPage
    {
        public Picker StatePickerSource { get; set; }
        public Picker CityPickerSource { get; set; }
        public Picker StatePickerDestination { get; set; }
        public Picker CityPickerDestination { get; set; }       
        public Entry SourceAirportText { get; set; }
        public Entry DestinationAirportText { get; set; }

        public void RouteCreate(LocationHelper locationHelper, LocationClass locationClass)
        {
          try { 
            Image banner = new Image();
            banner.HeightRequest = 100;
            banner.Source = "Banner.png";

            Label Source = new Label();
            Source.FontSize = 20;
            Source.HorizontalTextAlignment = TextAlignment.Center;
            Source.VerticalTextAlignment = TextAlignment.Center;
            Source.TextColor = Color.Black;
            Source.Text = "Choose where to start the route.";

            Label Destination = new Label();
            Destination.FontSize = 20;
            Destination.HorizontalTextAlignment = TextAlignment.Center;
            Destination.VerticalTextAlignment = TextAlignment.End;
            Destination.TextColor = Color.Black;
            Destination.Text = "Then the destination.";

            Label Sourceicaocodeentry = new Label();
            Sourceicaocodeentry.FontSize = 16;
            Sourceicaocodeentry.WidthRequest = 150;
            Sourceicaocodeentry.TextColor = Color.Black;
            Sourceicaocodeentry.VerticalTextAlignment = TextAlignment.Center;
            Sourceicaocodeentry.HorizontalTextAlignment = TextAlignment.Center;
            Sourceicaocodeentry.Text = "Enter Start Icao code:  ";
            

            Label Destinationicaocodeentry = new Label();
            Destinationicaocodeentry.FontSize = 16;
            Destinationicaocodeentry.WidthRequest = 150;
            Destinationicaocodeentry.TextColor = Color.Black;
            Destinationicaocodeentry.VerticalTextAlignment = TextAlignment.Center;
            Destinationicaocodeentry.HorizontalTextAlignment = TextAlignment.Center;
            Destinationicaocodeentry.Text = "Enter Destination Icao code:  ";
           
            var exit = new SpringBoardButton();
            exit.Icon = "Exit.png";
            exit.Label = "Exit";
            var exittapGestureRecognizer = new TapGestureRecognizer();
            exittapGestureRecognizer.Tapped += (s, e) =>
            {
                SourceLocation.icao = SourceAirportText.Text;
                DestinationLocation.icao = DestinationAirportText.Text;
                Navigation.PopModalAsync();
            };
            exit.GestureRecognizers.Add(exittapGestureRecognizer);

            var start = new SpringBoardButton();
            start.Icon = "Start.png";
            start.Label = "Start Route";
            var starttapGestureRecognizer = new TapGestureRecognizer();
            starttapGestureRecognizer.Tapped += async (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(SourceLocation.icao))
                {
                    RouteMapPage routePage = new RouteMapPage();
                    routePage.RouteMapCreate();
                    await Navigation.PushModalAsync(routePage);
                }
            };
            start.GestureRecognizers.Add(starttapGestureRecognizer);

            
        ////////////////////////////////////////////////////////////////////////////////////

        /* Source */

        ////////////////////////////////////////////////////////////////////////////////////

        SourceAirportText = new Entry();
            SourceAirportText.BindingContext = SourceAirportText;
            if (!string.IsNullOrEmpty(SourceLocation.icao))
            { SourceAirportText.Text = SourceLocation.icao; }
           
            var statesSource = locationHelper.GetStates();

            StatePickerSource = new Picker();
            StatePickerSource.Title = "Start State";
            StatePickerSource.WidthRequest = 150;
            StatePickerSource.SelectedIndexChanged += StatePickerSource_SelectedIndexChanged;

            CityPickerSource = new Picker();
            CityPickerSource.Title = "Start City";
            CityPickerSource.WidthRequest = 150;
            CityPickerSource.SelectedIndexChanged += CityPickerSource_SelectedIndexChanged;


            foreach (var stateSource in statesSource)
            {
                StatePickerSource.Items.Add(stateSource);
            }
            void StatePickerSource_SelectedIndexChanged(object sender, EventArgs e)
            {
                StatePickerDestination.SelectedIndex = StatePickerSource.SelectedIndex;

                var citiesSource = locationHelper.GetCities(StatePickerSource.SelectedItem.ToString());
                                
                if (CityPickerSource.Items.Count >= 2)
                {
                    CityPickerSource.Items.Clear();
                }

                foreach (var citySource in citiesSource)
                {
                    CityPickerSource.Items.Add(citySource);
                }
            }

            void CityPickerSource_SelectedIndexChanged(object sender, EventArgs e)
            {
                var icaoPicker = locationHelper.GetIcao(
                                    StatePickerSource.SelectedItem.ToString(), 
                    
                                    CityPickerSource.SelectedItem.ToString());
                   
                    SourceAirportText.Text = icaoPicker;
                    locationClass.icao = icaoPicker.ToString().ToUpperInvariant();

                    var source = locationHelper.GetLocationFromIcao(locationClass);

                    SourceLocation.lat = source.lat;
                    SourceLocation.lon = source.lon;
                    SourceLocation.city = source.city;
                    SourceLocation.name = source.name;
                    SourceLocation.state = source.state;
                    SourceLocation.icao = source.icao;
            }

            ////////////////////////////////////////////////////////////////////////////////////
            
            /* Destination */

            ////////////////////////////////////////////////////////////////////////////////////
            
            DestinationAirportText = new Entry();
            DestinationAirportText.BindingContext = DestinationAirportText;
            if (!string.IsNullOrEmpty(DestinationLocation.icao))
            { DestinationAirportText.Text = DestinationLocation.icao; }

            StatePickerDestination = new Picker();
            StatePickerDestination.Title = "Destination State";
            StatePickerDestination.WidthRequest = 150;
            StatePickerDestination.SelectedIndexChanged += StatePickerDestination_SelectedIndexChanged;

            CityPickerDestination = new Picker();
            CityPickerDestination.Title = "Destination City";
            CityPickerDestination.WidthRequest = 150;
            CityPickerDestination.SelectedIndexChanged += CityPickerDestination_SelectedIndexChanged;


            var statesDestination = locationHelper.GetStates();

            foreach (var state in statesDestination)
            {
                StatePickerDestination.Items.Add(state);
            }
            void StatePickerDestination_SelectedIndexChanged(object sender, EventArgs e)
            {
                var citiesDestination = locationHelper.GetCities(StatePickerDestination.SelectedItem.ToString());

                if (CityPickerDestination.Items.Count >= 2)
                {
                    CityPickerDestination.Items.Clear();
                }

                foreach (var city in citiesDestination)
                {
                    CityPickerDestination.Items.Add(city);
                }
            }

            void CityPickerDestination_SelectedIndexChanged(object sender, EventArgs e)
            {
                    var icaoPicker = locationHelper.GetIcao(
                                    StatePickerSource.SelectedItem.ToString(),

                                    CityPickerSource.SelectedItem.ToString());

                    DestinationAirportText.Text = icaoPicker;
                    locationClass.icao = icaoPicker.ToString().ToUpperInvariant();

                    var destination = locationHelper.GetLocationFromIcao(locationClass);

                    DestinationLocation.lat = destination.lat;
                    DestinationLocation.lon = destination.lon;
                    DestinationLocation.city = destination.city;
                    DestinationLocation.name = destination.name;
                    DestinationLocation.state = destination.state;
                    DestinationLocation.icao = destination.icao;

            }

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


            Grid.SetRow(Source, 0);
            Grid.SetColumn(Sourceicaocodeentry, 0);
            Grid.SetColumnSpan(Source, 2);
            
            Grid.SetRow(StatePickerSource, 1);
            Grid.SetColumn(StatePickerSource, 0);
            Grid.SetRow(CityPickerSource, 1);
            Grid.SetColumn(CityPickerSource, 1);

            Grid.SetRow(Sourceicaocodeentry, 2);
            Grid.SetColumn(Sourceicaocodeentry, 0);
            Grid.SetRow(SourceAirportText, 2);
            Grid.SetColumn(SourceAirportText, 1);

            
            Grid.SetRow(Destination, 3);
            Grid.SetColumn(Destination, 0);
            Grid.SetColumnSpan(Destination, 2);

            Grid.SetRow(StatePickerDestination, 4);
            Grid.SetColumn(StatePickerDestination, 0);
            Grid.SetRow(CityPickerDestination, 4);
            Grid.SetColumn(CityPickerDestination, 1);

            Grid.SetRow(Destinationicaocodeentry, 5);
            Grid.SetColumn(Destinationicaocodeentry, 0);
            Grid.SetRow(DestinationAirportText, 5);
            Grid.SetColumn(DestinationAirportText, 1);


            Grid.SetRow(start, 7);
            Grid.SetColumn(start, 0);
            Grid.SetRow(exit, 7);
            Grid.SetColumn(exit, 1);

            grid.Children.Add(Source);
            grid.Children.Add(StatePickerSource);
            grid.Children.Add(CityPickerSource);
            grid.Children.Add(Sourceicaocodeentry);
            grid.Children.Add(SourceAirportText);

            grid.Children.Add(Destination);
            grid.Children.Add(StatePickerDestination);
            grid.Children.Add(CityPickerDestination);
            grid.Children.Add(Destinationicaocodeentry);
            grid.Children.Add(DestinationAirportText);

            grid.Children.Add(start);
            grid.Children.Add(exit);

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
                App.Current.MainPage.DisplayAlert("The picker page failed to load.", "Check the code and try again", "OK");
            }
        }

    }
}

