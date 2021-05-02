using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System;
using Xamarin.Forms;

namespace Density
{
    class RoutePickerPage : ContentPage
    {
        public LocationClass sourceLocation { get; set; }
        public Picker StatePickerSource { get; set; }
        public Picker CityPickerSource { get; set; }
        public Entry SourceAirportText { get; set; }


        public LocationClass destinationLocation { get; set; }
        public Picker StatePickerDestination { get; set; }
        public Picker CityPickerDestination { get; set; }        
        public Entry DestinationAirportText { get; set; }


        public AircraftClass aircraftClass { get; set; }
        public Picker AircraftPicker { get; set; }
        public Entry AircraftSpeedText { get; set; }

       
        public void RouteCreate(LocationHelper locationHelper, AircraftHelper aircraftHelper)
        {
            try
            {
                Image Top_of_page_Banner = new Image();
                Top_of_page_Banner.HeightRequest = 100;
                Top_of_page_Banner.Source = "Banner.png";

                Label Source_Label = new Label();
                Source_Label.FontSize = 20;
                Source_Label.HorizontalTextAlignment = TextAlignment.Center;
                Source_Label.VerticalTextAlignment = TextAlignment.Center;
                Source_Label.TextColor = Color.Black;
                Source_Label.Text = "Choose where to start the route.";

                Label Destination_Label = new Label();
                Destination_Label.FontSize = 20;
                Destination_Label.HorizontalTextAlignment = TextAlignment.Center;
                Destination_Label.VerticalTextAlignment = TextAlignment.End;
                Destination_Label.TextColor = Color.Black;
                Destination_Label.Text = "Then the destination.";

                Label Source_Icao_Entry = new Label();
                Source_Icao_Entry.FontSize = 16;
                Source_Icao_Entry.WidthRequest = 150;
                Source_Icao_Entry.TextColor = Color.Black;
                Source_Icao_Entry.VerticalTextAlignment = TextAlignment.Center;
                Source_Icao_Entry.HorizontalTextAlignment = TextAlignment.Center;
                Source_Icao_Entry.Text = "  Enter Start Icao code:  ";


                Label Destination_Icao_Entry = new Label();
                Destination_Icao_Entry.FontSize = 16;
                Destination_Icao_Entry.WidthRequest = 150;
                Destination_Icao_Entry.TextColor = Color.Black;
                Destination_Icao_Entry.VerticalTextAlignment = TextAlignment.Center;
                Destination_Icao_Entry.HorizontalTextAlignment = TextAlignment.Center;
                Destination_Icao_Entry.Text = "  Enter Destination Icao code:  ";

                Label Aircraft_Speed_Entry = new Label();
                Aircraft_Speed_Entry.FontSize = 16;
                Aircraft_Speed_Entry.WidthRequest = 150;
                Aircraft_Speed_Entry.TextColor = Color.Black;
                Aircraft_Speed_Entry.VerticalTextAlignment = TextAlignment.Center;
                Aircraft_Speed_Entry.HorizontalTextAlignment = TextAlignment.Center;
                Aircraft_Speed_Entry.Text = "  Aircraft Type:   ";

                var exit = new SpringBoardButton();
                exit.Icon = "Exit.png";
                exit.Label = "Exit";
                var exittapGestureRecognizer = new TapGestureRecognizer();
                exittapGestureRecognizer.Tapped += (s, e) =>
                {
                    Navigation.PopModalAsync();
                };
                exit.GestureRecognizers.Add(exittapGestureRecognizer);

                var start = new SpringBoardButton();
                start.Icon = "Start.png";
                start.Label = "Start Route";
                var starttapGestureRecognizer = new TapGestureRecognizer();
                starttapGestureRecognizer.Tapped += async (s, e) =>
                {

                    RouteMapPage routePage = new RouteMapPage();
                    routePage.RouteMapCreate(sourceLocation, destinationLocation, aircraftClass);
                    await Navigation.PushModalAsync(routePage);

                };
                start.GestureRecognizers.Add(starttapGestureRecognizer);

                sourceLocation = new LocationClass();
                destinationLocation = new LocationClass();
                aircraftClass = new AircraftClass();

                SourceAirportText = new Entry();
                SourceAirportText.BindingContext = SourceAirportText;

                DestinationAirportText = new Entry();
                DestinationAirportText.BindingContext = DestinationAirportText;

                AircraftSpeedText = new Entry();
                AircraftSpeedText.BindingContext = AircraftSpeedText;

                var statesSource = locationHelper.GetStates();

                StatePickerSource = new Picker();
                StatePickerSource.Title = "Start State";
                StatePickerSource.WidthRequest = 150;
                StatePickerSource.SelectedIndexChanged += StatePickerSource_SelectedIndexChanged;

                CityPickerSource = new Picker();
                CityPickerSource.Title = "Start City";
                CityPickerSource.WidthRequest = 150;
                CityPickerSource.SelectedIndexChanged += CityPickerSource_SelectedIndexChanged;

                AircraftPicker = new Picker();
                AircraftPicker.Title = "Type";
                AircraftPicker.WidthRequest = 150;
                AircraftPicker.SelectedIndexChanged += AircraftPicker_SelectedIndexChanged;

                StatePickerDestination = new Picker();
                StatePickerDestination.Title = "Destination State";
                StatePickerDestination.WidthRequest = 150;
                StatePickerDestination.SelectedIndexChanged += StatePickerDestination_SelectedIndexChanged;

                CityPickerDestination = new Picker();
                CityPickerDestination.Title = "Destination City";
                CityPickerDestination.WidthRequest = 150;
                CityPickerDestination.SelectedIndexChanged += CityPickerDestination_SelectedIndexChanged;

                //populate the source picker with state information                
                foreach (var stateSource in statesSource)
                {  StatePickerSource.Items.Add(stateSource);  }
                //event for when the state picker source is pressed
                void StatePickerSource_SelectedIndexChanged(object sender, EventArgs e)
                {
                    StatePickerDestination.SelectedIndex = StatePickerSource.SelectedIndex;

                    var citiesSource = locationHelper.GetCities(StatePickerSource.SelectedItem.ToString());

                    if (CityPickerSource.Items.Count >= 2)
                    {   CityPickerSource.Items.Clear();  }

                    foreach (var citySource in citiesSource)
                    {   CityPickerSource.Items.Add(citySource);  }
                }

                //event for when the city picker source is pressed
                void CityPickerSource_SelectedIndexChanged(object sender, EventArgs e)
                {
                    var icaoPicker = locationHelper.GetIcao(
                                        StatePickerSource.SelectedItem.ToString(),
                                        CityPickerSource.SelectedItem.ToString());

                    SourceAirportText.Text = icaoPicker;
                    sourceLocation.icao = icaoPicker.ToString().ToUpperInvariant();

                    sourceLocation = locationHelper.GetLocationFromIcao(sourceLocation);
                }

                //populate the picker for the aircraft
                var aircrafts = aircraftHelper.GetAircrafts();

                foreach (var item in aircrafts)
                { AircraftPicker.Items.Add(item);  }

                void AircraftPicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    aircraftClass = aircraftHelper.GetAircraftFromName(AircraftPicker.SelectedItem.ToString());
                    AircraftSpeedText.Text = aircraftClass.aircraftSpeed.ToString();
                }

                var statesDestination = locationHelper.GetStates();

                foreach (var state in statesDestination)
                {
                    StatePickerDestination.Items.Add(state);
                }
                void StatePickerDestination_SelectedIndexChanged(object sender, EventArgs e)
                {
                    var citiesDestination = locationHelper.GetCities(StatePickerDestination.SelectedItem.ToString());

                    if (CityPickerDestination.Items.Count >= 2)
                    { CityPickerDestination.Items.Clear(); }

                    foreach (var city in citiesDestination)
                    { CityPickerDestination.Items.Add(city); }
                }

                void CityPickerDestination_SelectedIndexChanged(object sender, EventArgs e)
                {
                    var icaoPicker = locationHelper.GetIcao(
                                    StatePickerSource.SelectedItem.ToString(),
                                    CityPickerSource.SelectedItem.ToString());

                    DestinationAirportText.Text = icaoPicker;
                    destinationLocation.icao = icaoPicker.ToString().ToUpperInvariant();

                    destinationLocation = locationHelper.GetLocationFromIcao(destinationLocation);
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


                Grid.SetRow(Source_Label, 0);
                Grid.SetColumn(Source_Icao_Entry, 0);
                Grid.SetColumnSpan(Source_Label, 3);

                Grid.SetRow(StatePickerSource, 1);
                Grid.SetColumn(StatePickerSource, 0);
                Grid.SetColumnSpan(StatePickerSource, 2);


                Grid.SetRow(CityPickerSource, 1);
                Grid.SetColumn(CityPickerSource, 2);
                Grid.SetColumnSpan(CityPickerSource, 2);

                Grid.SetRow(Source_Icao_Entry, 2);
                Grid.SetColumn(Source_Icao_Entry, 0);
                Grid.SetColumnSpan(Source_Icao_Entry, 2);
                Grid.SetRow(SourceAirportText, 2);
                Grid.SetColumn(SourceAirportText, 2);

                Grid.SetRow(Destination_Label, 3);
                Grid.SetColumn(Destination_Label, 0);
                Grid.SetColumnSpan(Destination_Label, 3);

                Grid.SetRow(StatePickerDestination, 4);
                Grid.SetColumn(StatePickerDestination, 0);
                Grid.SetColumnSpan(StatePickerDestination, 2);

                Grid.SetRow(CityPickerDestination, 4);
                Grid.SetColumn(CityPickerDestination, 2);
                Grid.SetColumnSpan(CityPickerDestination, 2)
                ;

                Grid.SetRow(Destination_Icao_Entry, 5);
                Grid.SetColumn(Destination_Icao_Entry, 0);
                Grid.SetColumnSpan(Destination_Icao_Entry, 2);
                Grid.SetRow(DestinationAirportText, 5);
                Grid.SetColumn(DestinationAirportText, 2);

                Grid.SetRow(AircraftPicker, 6);
                Grid.SetColumn(AircraftPicker, 1);
                Grid.SetColumnSpan(AircraftPicker, 2);
                Grid.SetRow(Aircraft_Speed_Entry, 6);
                Grid.SetColumn(Aircraft_Speed_Entry, 0);
                Grid.SetRow(AircraftSpeedText, 6);
                Grid.SetColumn(AircraftSpeedText, 2);
                          


                Grid.SetRow(start, 8);
                Grid.SetColumn(start, 0);
                Grid.SetRow(exit, 8);
                Grid.SetColumn(exit, 2);

                grid.Children.Add(Source_Label);
                grid.Children.Add(StatePickerSource);
                grid.Children.Add(CityPickerSource);
                grid.Children.Add(Source_Icao_Entry);
                grid.Children.Add(SourceAirportText);

                grid.Children.Add(Destination_Label);
                grid.Children.Add(StatePickerDestination);
                grid.Children.Add(CityPickerDestination);
                grid.Children.Add(Destination_Icao_Entry);
                grid.Children.Add(DestinationAirportText);

                grid.Children.Add(AircraftPicker);
                grid.Children.Add(Aircraft_Speed_Entry);
                grid.Children.Add(AircraftSpeedText);

                grid.Children.Add(start);
                grid.Children.Add(exit);

                var segments = new StackLayout
                {
                    Spacing = 0,
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.White,
                    Children = { Top_of_page_Banner, grid }
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

