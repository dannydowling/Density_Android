using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density
{
    class DensityPage : ContentPage
    {
        private Label Density_Label { get; set; }
        private Label AirTemperature_Label { get; set; }
        private Label AirPressure_Label { get; set; }

       
             
        private Picker StatePicker { get; set; }
        private Picker CityPicker { get; set; }
        private Picker AirportPicker { get; set; }
        private Entry gallonsEntryLabel { get; set; }

        IEnumerable<string> states { get; set; }
        Dictionary<string, List<string>> cities { get; set; }
        Dictionary<string, List<string>> airports { get; set; }

        public Image hydrometer_fluid_background { get; set; }
        private static double hydrometer_Y_scale { get; set; }
        private Image hydrometer_glass_foreground { get; set; }


        public static void HydrometerScaled(object sender, HydrometerMovedEventArgs e)
        {
            hydrometer_Y_scale = e.ScaleFactor;            
        }
            
        public void DensityPageCreate(
            LocationHelper locationHelper,
            WeatherHelper weatherHelper,
            DensityHelper densityHelper,

            LocationClass locationClass,
            WeatherClass weatherClass,
            DensityClass densityClass)
        {
            if (locationHelper == null || weatherHelper == null || densityHelper == null)
            {
                Task.Factory.StartNew<object>(() => locationHelper = new LocationHelper())
                  .ContinueWith<object>(antecedent => weatherHelper = new WeatherHelper())
                  .ContinueWith<object>(antecedent => densityHelper = new DensityHelper());
            }
         
            try
            {
                hydrometer_fluid_background.ScaleY = hydrometer_Y_scale; 
                hydrometer_fluid_background.WidthRequest = 150;
                hydrometer_fluid_background.Source = "Hydrometer_Fluid.png";

                hydrometer_glass_foreground = new Image();
                hydrometer_glass_foreground.HeightRequest = 150;
                hydrometer_glass_foreground.WidthRequest = 150;
                hydrometer_glass_foreground.Source = "Hydrometer_Glass.png";

                gallonsEntryLabel = new Entry();
                gallonsEntryLabel.BindingContext = gallonsEntryLabel;
                gallonsEntryLabel.Text = "";

                Density_Label = new Label();
                Density_Label.FontSize = 25;
                Density_Label.TextColor = Color.Black;
                Density_Label.VerticalTextAlignment = TextAlignment.Center;
                Density_Label.HorizontalTextAlignment = TextAlignment.Center;
                Density_Label.Text = "";
                Density_Label.BindingContext = Density_Label;

                AirTemperature_Label = new Label();
                AirTemperature_Label.FontSize = 25;
                AirTemperature_Label.TextColor = Color.Black;
                AirTemperature_Label.VerticalTextAlignment = TextAlignment.Center;
                AirTemperature_Label.HorizontalTextAlignment = TextAlignment.Center;
                AirTemperature_Label.Text = "";
                AirTemperature_Label.BindingContext = AirTemperature_Label;

                AirPressure_Label = new Label();
                AirPressure_Label.FontSize = 25;
                AirPressure_Label.TextColor = Color.Black;
                AirPressure_Label.VerticalTextAlignment = TextAlignment.Center;
                AirPressure_Label.HorizontalTextAlignment = TextAlignment.Center;
                AirPressure_Label.Text = "";
                AirPressure_Label.BindingContext = AirPressure_Label;


                Image banner = new Image();
                banner.HeightRequest = 100;
                banner.Source = "Banner.png";


                Label Icao_Code_Label = new Label();
                Icao_Code_Label.FontSize = 16;
                Icao_Code_Label.WidthRequest = 150;
                Icao_Code_Label.TextColor = Color.Black;
                Icao_Code_Label.VerticalTextAlignment = TextAlignment.Center;
                Icao_Code_Label.HorizontalTextAlignment = TextAlignment.Center;
                Icao_Code_Label.Text = "Airport:  ";

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

                StatePicker = new Picker();
                StatePicker.Title = "State";
                StatePicker.WidthRequest = 150;
                StatePicker.SelectedIndexChanged += StatePicker_SelectedIndexChanged;
                StatePicker.ItemsSource = states.ToList();

                void StatePicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    CityPicker.Items.Clear();
                    AirportPicker.Items.Clear();
                    { var cityList = cities.Single(x => x.Key == StatePicker.SelectedItem.ToString()).Value.ToList();

                        foreach (var item in cityList)
                        { CityPicker.Items.Add(item); }
                    }
                }

                CityPicker = new Picker();
                CityPicker.Title = "City";
                CityPicker.WidthRequest = 150;
                CityPicker.SelectedIndexChanged += CityPicker_SelectedIndexChanged;
                void CityPicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    AirportPicker.Items.Clear();
                    {
                        var airportList = airports.Single(x => x.Key == CityPicker.SelectedItem.ToString()).Value.ToList();
                        foreach (var item in airportList)
                        {  AirportPicker.Items.Add(item);  }  
                    }
                }

                AirportPicker = new Picker();
                AirportPicker.Title = "Airport";
                AirportPicker.WidthRequest = 150;
                AirportPicker.SelectedIndexChanged += AirportPicker_SelectedIndexChanged;
                void AirportPicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (locationClass == null)
                    { locationClass = new LocationClass(); }
                    locationClass.icao = locationHelper.GetIcaoFromAirport(StatePicker.SelectedItem.ToString(), AirportPicker.SelectedItem.ToString());
                    locationClass = locationHelper.GetLocationFromIcao(locationClass);               
                }

                Label EstimateMSG = new Label();
                EstimateMSG.FontSize = 16;
                EstimateMSG.HorizontalTextAlignment = TextAlignment.Center;
                EstimateMSG.Text = "Estimate for Jet-A fuel adjusted for weather";

                Label Pre_Message = new Label();
                Pre_Message.FontSize = 14;
                Pre_Message.HorizontalTextAlignment = TextAlignment.Center;
                Pre_Message.VerticalTextAlignment = TextAlignment.Center;
                Pre_Message.Text = "Jet Fuel Weight:";

                Label Cost_Calculator = new Label();
                Cost_Calculator.FontSize = 14;
                Cost_Calculator.HorizontalTextAlignment = TextAlignment.Center;
                Cost_Calculator.VerticalTextAlignment = TextAlignment.Center;
                Cost_Calculator.Text = "Number of gallons:";

                Label Post_Message = new Label();
                Post_Message.FontSize = 14;
                Post_Message.HorizontalTextAlignment = TextAlignment.Center;
                Post_Message.VerticalTextAlignment = TextAlignment.Center;
                Post_Message.Text = "Based on air temperature and pressure of:";

                var exit = new SpringBoardButton();
                exit.Icon = "Exit.png";
                exit.Label = "Exit";
                var exittapGestureRecognizer = new TapGestureRecognizer();
                exittapGestureRecognizer.Tapped += (s, e) =>
                {
                    Navigation.PopModalAsync();
                };
                exit.GestureRecognizers.Add(exittapGestureRecognizer);

                var update = new SpringBoardButton();
                update.Icon = "Update.png";
                update.Label = "Update";
                var updatetapGestureRecognizer = new TapGestureRecognizer();
                updatetapGestureRecognizer.Tapped += async (s, e) =>
                {
                    //updates the weather class and then the density class.
                    weatherClass = await weatherHelper.GetWeatherAsync(locationClass, weatherClass);
                    densityClass = densityHelper.ConvertToDensity(weatherClass, densityClass);

                    try
                    {
                        Density_Label.Text = densityClass.densityValue;

                        double AirTemp_Temp = weatherClass.AirTemperature;
                        AirTemp_Temp *= 9;                //conversion to Fahrenheit
                        AirTemp_Temp /= 5;
                        AirTemp_Temp += 32;
                        AirTemperature_Label.Text = AirTemp_Temp.ToString();
                        AirPressure_Label.Text = weatherClass.AirPressure.ToString();

                        if (gallonsEntryLabel.Text != "")
                        {
                            double denseValue = Convert.ToDouble(densityClass.densityValue);
                            double gallonAmount = Convert.ToDouble(gallonsEntryLabel.Text);
                            gallonsEntryLabel.Text = gallonAmount.ToString() + " is " + (denseValue * gallonAmount).ToString() + "lbs";
                        }
                    }
                    catch (Exception error)
                    {
                        Density_Label.Text = error.Message + error.Source;
                    }

                };
                update.GestureRecognizers.Add(updatetapGestureRecognizer);

                #region Setup Grid and create the page
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


                Grid.SetRow(EstimateMSG, 0);
                Grid.SetColumn(EstimateMSG, 0);
                Grid.SetColumnSpan(EstimateMSG, 2);

                Grid.SetRow(StatePicker, 1);
                Grid.SetColumn(StatePicker, 0);
                Grid.SetRow(CityPicker, 1);
                Grid.SetColumn(CityPicker, 1);

                Grid.SetRow(Icao_Code_Label, 2);
                Grid.SetColumn(Icao_Code_Label, 0);
                Grid.SetRow(AirportPicker, 2);
                Grid.SetColumn(AirportPicker, 1);


                Grid.SetRow(Pre_Message, 3);
                Grid.SetColumn(Pre_Message, 0);
                Grid.SetRow(Cost_Calculator, 3);
                Grid.SetColumn(Cost_Calculator, 1);

                Grid.SetRow(gallonsEntryLabel, 4);
                Grid.SetColumn(gallonsEntryLabel, 1);
                Grid.SetRow(Density_Label, 4);
                Grid.SetColumn(Density_Label, 0);

                Grid.SetRow(Post_Message, 5);
                Grid.SetColumn(Post_Message, 0);
                Grid.SetColumnSpan(Post_Message, 2);
                Grid.SetRow(AirTemperature_Label, 6);
                Grid.SetColumn(AirTemperature_Label, 0);
                Grid.SetRow(AirPressure_Label, 6);
                Grid.SetColumn(AirPressure_Label, 1);


                Grid.SetRow(update, 8);
                Grid.SetColumn(update, 0);
                Grid.SetRow(exit, 8);
                Grid.SetColumn(exit, 1);

                grid.Children.Add(EstimateMSG);
                grid.Children.Add(Icao_Code_Label);
                grid.Children.Add(gallonsEntryLabel);
                grid.Children.Add(AirportPicker);
                grid.Children.Add(StatePicker);
                grid.Children.Add(CityPicker);
                grid.Children.Add(Pre_Message);
                grid.Children.Add(Cost_Calculator);
                grid.Children.Add(Density_Label);
                grid.Children.Add(AirTemperature_Label);
                grid.Children.Add(AirPressure_Label);
                grid.Children.Add(Post_Message);
                grid.Children.Add(update);
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
            catch (Exception error)
            {
                App.Current.MainPage.DisplayAlert(error.Message, error.Source + error.StackTrace, "OK");
            }
            #endregion
        }
    }
}
