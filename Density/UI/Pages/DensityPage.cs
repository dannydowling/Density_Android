using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System;
using System.Net.Http;
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
        private Entry icaoEntryLabel { get; set; }
        public string pickerIcao { get; set; }

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

                icaoEntryLabel = new Entry();
                icaoEntryLabel.BindingContext = icaoEntryLabel;
                if (!string.IsNullOrEmpty(locationClass.icao))
                { icaoEntryLabel.Text = locationClass.icao; }

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


                Label icaocodeentry = new Label();
                icaocodeentry.FontSize = 16;
                icaocodeentry.WidthRequest = 150;
                icaocodeentry.TextColor = Color.Black;
                icaocodeentry.VerticalTextAlignment = TextAlignment.Center;
                icaocodeentry.HorizontalTextAlignment = TextAlignment.Center;
                icaocodeentry.Text = "Enter Icao code:  ";

                StatePicker = new Picker();
                StatePicker.Title = "State";
                StatePicker.WidthRequest = 150;
                StatePicker.SelectedIndexChanged += StatePicker_SelectedIndexChanged;

                CityPicker = new Picker();
                CityPicker.Title = "City";
                CityPicker.WidthRequest = 150;
                CityPicker.SelectedIndexChanged += CityPicker_SelectedIndexChanged;


                var states = locationHelper.GetStates();

                foreach (var state in states)
                {
                    StatePicker.Items.Add(state);
                }
                void StatePicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    var cities = locationHelper.GetCities(StatePicker.SelectedItem.ToString());

                    if (CityPicker.Items.Count >= 2)
                    {
                        CityPicker.Items.Clear();
                    }

                    foreach (var city in cities)
                    {
                        CityPicker.Items.Add(city);
                    }
                }
                void CityPicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (pickerIcao == null)
                    {
                        pickerIcao = "";
                    }
                    pickerIcao = locationHelper.GetIcao(StatePicker.SelectedItem.ToString(), CityPicker.SelectedItem.ToString());
                    locationClass.icao = pickerIcao.Trim().ToUpperInvariant();
                    icaoEntryLabel.Text = locationClass.icao;

                    locationHelper.GetLocationFromIcao(locationClass);

                }

                Label EstimateMSG = new Label();
                EstimateMSG.FontSize = 16;
                EstimateMSG.HorizontalTextAlignment = TextAlignment.Center;
                EstimateMSG.Text = "Estimate for Jet-A fuel adjusted for weather";

                Label EstimateMSG2 = new Label();
                EstimateMSG2.FontSize = 14;
                EstimateMSG2.HorizontalTextAlignment = TextAlignment.Center;
                EstimateMSG2.Text = "Weight changes with Air Pressure and Temperature";

                Label Pre_Message = new Label();
                Pre_Message.FontSize = 14;
                Pre_Message.HorizontalTextAlignment = TextAlignment.Center;
                Pre_Message.VerticalTextAlignment = TextAlignment.Center;
                Pre_Message.Text = "The Fuel Density in pounds per gallon is:";

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
                    locationClass.icao = icaoEntryLabel.Text;
                    Navigation.PopModalAsync();
                };
                exit.GestureRecognizers.Add(exittapGestureRecognizer);

                var update = new SpringBoardButton();
                update.Icon = "Update.png";
                update.Label = "Update";
                var updatetapGestureRecognizer = new TapGestureRecognizer();
                updatetapGestureRecognizer.Tapped += (s, e) =>
                {
                    //gets a weather class
                    Task<WeatherClass> updateDensity = Task.Run(async () =>
                    await weatherHelper.GetWeatherAsync
                    (locationClass, weatherClass));

                    //antecedent is the return from the previous task.
                    updateDensity.ContinueWith(antecedent => 
                    densityHelper.ConvertToDensity
                    (antecedent.Result, locationHelper, weatherHelper, locationClass, densityClass));

                    try
                    {
                        updateDensity.Wait();

                        Density_Label.Text = densityClass.densityValue;
                        AirTemperature_Label.Text = weatherClass.AirTemperature.ToString();
                        AirPressure_Label.Text = weatherClass.AirPressure.ToString();

                    }
                    catch (Exception)
                    {
                        Density_Label.Text = "Not found or other error";
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
                Grid.SetRow(EstimateMSG2, 1);
                Grid.SetColumn(EstimateMSG2, 0);
                Grid.SetColumnSpan(EstimateMSG2, 2);

                Grid.SetRow(StatePicker, 2);
                Grid.SetColumn(StatePicker, 0);
                Grid.SetRow(CityPicker, 2);
                Grid.SetColumn(CityPicker, 1);

                Grid.SetRow(icaocodeentry, 3);
                Grid.SetColumn(icaocodeentry, 0);
                Grid.SetRow(icaoEntryLabel, 3);
                Grid.SetColumn(icaoEntryLabel, 1);

                Grid.SetRow(Pre_Message, 4);
                Grid.SetColumn(Pre_Message, 0);
                Grid.SetColumnSpan(Pre_Message, 2);
                Grid.SetRow(Density_Label, 5);
                Grid.SetColumn(Density_Label, 0);
                Grid.SetColumnSpan(Density_Label, 2);

                Grid.SetRow(Post_Message, 6);
                Grid.SetColumn(Post_Message, 0);
                Grid.SetColumnSpan(Post_Message, 2);
                Grid.SetRow(AirTemperature_Label, 7);
                Grid.SetColumn(AirTemperature_Label, 0);
                
                Grid.SetRow(AirPressure_Label, 7);
                Grid.SetColumn(AirPressure_Label, 1);
                

                Grid.SetRow(update, 8);
                Grid.SetColumn(update, 0);
                Grid.SetRow(exit, 8);
                Grid.SetColumn(exit, 1);

                grid.Children.Add(EstimateMSG);
                grid.Children.Add(EstimateMSG2);
                grid.Children.Add(icaocodeentry);
                grid.Children.Add(icaoEntryLabel);
                grid.Children.Add(StatePicker);
                grid.Children.Add(CityPicker);
                grid.Children.Add(Pre_Message);
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
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("The controls on the page failed to load.", "Check the controls and try again", "OK");
            }
            #endregion
        }
    }
}
