using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density
{
    class RoutePickerPage : ContentPage
    {
        public LocationClass source_Location { get; set; }
        public Picker Source_State_Picker { get; set; }
        public Picker Source_City_Picker { get; set; }
        public Picker Source_Airport_Picker { get; set; }
        public WeatherCamClass sourceWeatherCamClass { get; set; }
        public ImageSource sourceAirportImage { get; set; }
        


        public LocationClass destination_Location { get; set; }
        public Picker Destination_State_Picker { get; set; }
        public Picker Destination_City_Picker { get; set; }          
        public Picker Destination_Airport_Picker { get; set; }
        public WeatherCamClass destinationWeatherCamClass { get; set; }

        public ImageSource destinationAirportImage { get; set; }
        


        public AircraftClass aircraftClass { get; set; }
        public Picker Aircraft_Picker { get; set; }
        public Entry AircraftSpeedText { get; set; }


        IEnumerable<string> states { get; set; }
        Dictionary<string, List<string>> cities { get; set; }
        Dictionary<string, List<string>> airports { get; set; }


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
                Aircraft_Speed_Entry.HorizontalTextAlignment = TextAlignment.End;
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
                    routePage.RouteMapCreate(source_Location, destination_Location, aircraftClass);
                    await Navigation.PushModalAsync(routePage);

                };
                start.GestureRecognizers.Add(starttapGestureRecognizer);

                source_Location = new LocationClass();
                destination_Location = new LocationClass();
                aircraftClass = new AircraftClass();

                AircraftSpeedText = new Entry();
                AircraftSpeedText.BindingContext = AircraftSpeedText;

                var statesSource = locationHelper.GetStates();

                Source_State_Picker = new Picker();
                Source_State_Picker.Title = "Start State";
                Source_State_Picker.WidthRequest = 150;
                Source_State_Picker.SelectedIndexChanged += Source_State_Picker_SelectedIndexChanged;

                Source_City_Picker = new Picker();
                Source_City_Picker.Title = "Start City";
                Source_City_Picker.WidthRequest = 150;
                Source_City_Picker.SelectedIndexChanged += Source_City_Picker_SelectedIndexChanged;

                Source_Airport_Picker = new Picker();
                Source_Airport_Picker.Title = "Start Airport";
                Source_Airport_Picker.WidthRequest = 150;
                Source_Airport_Picker.SelectedIndexChanged += Source_Airport_Picker_SelectedIndexChanged;

                Destination_State_Picker = new Picker();
                Destination_State_Picker.Title = "Destination State";
                Destination_State_Picker.WidthRequest = 150;
                Destination_State_Picker.SelectedIndexChanged += Destination_State_Picker_SelectedIndexChanged;

                Destination_City_Picker = new Picker();
                Destination_City_Picker.Title = "Destination City";
                Destination_City_Picker.WidthRequest = 150;
                Destination_City_Picker.SelectedIndexChanged += Destination_City_Picker_SelectedIndexChanged;

                Aircraft_Picker = new Picker();
                Aircraft_Picker.Title = "Type";
                Aircraft_Picker.WidthRequest = 150;
                Aircraft_Picker.SelectedIndexChanged += AircraftPicker_SelectedIndexChanged;

                Destination_Airport_Picker = new Picker();
                Destination_Airport_Picker.Title = "Start Airport";
                Destination_Airport_Picker.WidthRequest = 150;
                Destination_Airport_Picker.SelectedIndexChanged += Destination_Airport_Picker_SelectedIndexChanged;


                states = locationHelper.GetStates();
                cities = new Dictionary<string, List<string>>();
                airports = new Dictionary<string, List<string>>();

                foreach (var stateName in states)
                {
                    if (!cities.ContainsKey(stateName))
                        cities.Add(stateName, locationHelper.GetCities(stateName).ToList());


                    foreach (var cityNames in cities.Values)
                    {
                        foreach (var cityName in cityNames)
                        {
                            if (!airports.ContainsKey(cityName))
                                airports.Add(cityName, locationHelper.GetAirports(stateName, cityName).ToList());
                        }
                    }
                }

                //populate the source picker with state information                
                foreach (var state in states)
                {  Source_State_Picker.Items.Add(state);
                   Destination_State_Picker.Items.Add(state);
                }

                void Source_State_Picker_SelectedIndexChanged(object sender, EventArgs e)
                {                    
                    var sourceCityList = cities.Single(x => x.Key == Source_State_Picker.SelectedItem.ToString()).Value.ToList();

                    foreach (var item in sourceCityList)
                    {   Source_City_Picker.Items.Add(item);  }
                }

                void Source_City_Picker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    Source_Airport_Picker.Items.Clear();
                    {
                        var sourceAirportList = airports.Single(x => x.Key == Source_City_Picker.SelectedItem.ToString()).Value.ToList();
                        foreach (var item in sourceAirportList)
                        { Source_Airport_Picker.Items.Add(item); }
                    }
                }

                void Source_Airport_Picker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    source_Location.icao = locationHelper.GetIcaoFromAirport(
                                        Source_State_Picker.SelectedItem.ToString(),
                                        Source_Airport_Picker.SelectedItem.ToString());
                    source_Location = locationHelper.GetLocationFromIcao(source_Location);

                    //Task.Run(() => {
                    //    WeatherCamHelper weatherCamHelper = new WeatherCamHelper();

                    //    //WARNING INDEXING INTO THE LIST WITH THE [0] BIT AT THE END
                    //   sourceWeatherCamClass = weatherCamHelper.GetAirport(source_Location.name)[0];
                    //});


                }


                void Destination_State_Picker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    var destinationCityList = cities.Single(x => x.Key == Destination_State_Picker.SelectedItem.ToString()).Value.ToList();

                    foreach (var item in destinationCityList)
                    { Destination_City_Picker.Items.Add(item); }
                }

                void Destination_City_Picker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    Destination_Airport_Picker.Items.Clear();
                    {
                        var destinationAirportList = airports.Single(x => x.Key == Destination_City_Picker.SelectedItem.ToString()).Value.ToList();
                        foreach (var item in destinationAirportList)
                        { Destination_Airport_Picker.Items.Add(item); }
                    }
                }

                void Destination_Airport_Picker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    destination_Location.icao = locationHelper.GetIcaoFromAirport(
                                        Destination_State_Picker.SelectedItem.ToString(),
                                        Destination_Airport_Picker.SelectedItem.ToString());
                    destination_Location = locationHelper.GetLocationFromIcao(destination_Location);
                }

                var aircrafts = aircraftHelper.GetAircrafts();

                foreach (var item in aircrafts)
                { Aircraft_Picker.Items.Add(item); }

                void AircraftPicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    aircraftClass = aircraftHelper.GetAircraftFromName(Aircraft_Picker.SelectedItem.ToString());
                    AircraftSpeedText.Text = aircraftHelper.GetSpeed(aircraftClass);
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

                Grid.SetRow(Source_State_Picker, 1);
                Grid.SetColumn(Source_State_Picker, 0);
                Grid.SetColumnSpan(Source_State_Picker, 2);


                Grid.SetRow(Source_City_Picker, 1);
                Grid.SetColumn(Source_City_Picker, 2);
                Grid.SetColumnSpan(Source_City_Picker, 2);

                Grid.SetRow(Source_Airport_Picker, 2);
                Grid.SetColumn(Source_Airport_Picker, 0);
                Grid.SetColumnSpan(Source_Airport_Picker, 2);
             

                Grid.SetRow(Destination_Label, 3);
                Grid.SetColumn(Destination_Label, 0);
                Grid.SetColumnSpan(Destination_Label, 3);

                Grid.SetRow(Destination_State_Picker, 4);
                Grid.SetColumn(Destination_State_Picker, 0);
                Grid.SetColumnSpan(Destination_State_Picker, 2);

                Grid.SetRow(Destination_City_Picker, 4);
                Grid.SetColumn(Destination_City_Picker, 2);
                Grid.SetColumnSpan(Destination_City_Picker, 2);

                Grid.SetRow(Destination_Airport_Picker, 5);
                Grid.SetColumn(Destination_Airport_Picker, 0);
                Grid.SetColumnSpan(Destination_Airport_Picker, 2);              

                Grid.SetRow(Aircraft_Picker, 6);
                Grid.SetColumn(Aircraft_Picker, 1);
                Grid.SetColumnSpan(Aircraft_Picker, 2);
                Grid.SetRow(Aircraft_Speed_Entry, 6);
                Grid.SetColumn(Aircraft_Speed_Entry, 0);
                Grid.SetRow(AircraftSpeedText, 6);
                Grid.SetColumn(AircraftSpeedText, 2);
                          


                Grid.SetRow(start, 8);
                Grid.SetColumn(start, 0);
                Grid.SetRow(exit, 8);
                Grid.SetColumn(exit, 2);

                grid.Children.Add(Source_Label);
                grid.Children.Add(Source_State_Picker);
                grid.Children.Add(Source_City_Picker);
                grid.Children.Add(Source_Airport_Picker);               

                grid.Children.Add(Destination_Label);
                grid.Children.Add(Destination_State_Picker);
                grid.Children.Add(Destination_City_Picker);
                grid.Children.Add(Destination_Airport_Picker);                
                

                grid.Children.Add(Aircraft_Picker);
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

