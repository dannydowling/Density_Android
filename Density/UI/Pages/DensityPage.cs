using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System;
using Xamarin.Forms;

namespace Density
{
    class DensityPage : ContentPage
    {
        private Label densityLabel { get; set; }
        private Picker StatePicker { get; set; }
        private Picker CityPicker { get; set; }
        private Entry icaoEntryLabel { get; set; }
        public string pickerIcao { get; set; }

        public void DensityPageCreate(LocationHelper locationHelper, WeatherHelper weatherHelper, DensityHelper densityHelper, LocationClass locationClass, WeatherClass weatherClass, DensityClass densityClass)
        {
            if (locationClass == null)
            { 
                locationClass = new LocationClass();
                weatherClass = new WeatherClass();
                densityClass = new DensityClass();            
            }
           
            if (locationHelper == null)
            { locationHelper = new LocationHelper(); }
           
            if (weatherHelper == null)
            { weatherHelper = new WeatherHelper(); }
           
            if (densityHelper == null)
            { densityHelper = new DensityHelper(); }            
       

            try
            {
                icaoEntryLabel = new Entry();
                icaoEntryLabel.BindingContext = icaoEntryLabel;
                if (!string.IsNullOrEmpty(locationClass.icao))
                { icaoEntryLabel.Text = locationClass.icao; }

                densityLabel = new Label();
                densityLabel.FontSize = 25;
                densityLabel.TextColor = Color.Black;
                densityLabel.VerticalTextAlignment = TextAlignment.Center;
                densityLabel.HorizontalTextAlignment = TextAlignment.Center;
                densityLabel.Text = "";
                densityLabel.BindingContext = densityLabel;


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

                Label Densitypremessage = new Label();
                Densitypremessage.FontSize = 14;
                Densitypremessage.HorizontalTextAlignment = TextAlignment.Center;
                Densitypremessage.VerticalTextAlignment = TextAlignment.Center;
                Densitypremessage.Text = "The Fuel Density in pounds per gallon is:";


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
                updatetapGestureRecognizer.Tapped += async (s, e) =>
                {                    
                    await weatherHelper.GetWeatherAsync(locationClass, weatherClass);

                    await densityHelper.ConvertToDensity(weatherClass, locationHelper, weatherHelper, locationClass, densityClass);
              
                    densityLabel.Text = densityClass.densityValue;
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

                Grid.SetRow(Densitypremessage, 4);
                Grid.SetColumn(Densitypremessage, 0);
                Grid.SetColumnSpan(Densitypremessage, 2);
                Grid.SetRow(densityLabel, 5);
                Grid.SetColumn(densityLabel, 0);
                Grid.SetColumnSpan(densityLabel, 2);

                Grid.SetRow(update, 6);
                Grid.SetColumn(update, 0);
                Grid.SetRow(exit, 6);
                Grid.SetColumn(exit, 1);

                grid.Children.Add(EstimateMSG);
                grid.Children.Add(EstimateMSG2);
                grid.Children.Add(icaocodeentry);
                grid.Children.Add(icaoEntryLabel);
                grid.Children.Add(StatePicker);
                grid.Children.Add(CityPicker);
                grid.Children.Add(Densitypremessage);
                grid.Children.Add(densityLabel);
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
