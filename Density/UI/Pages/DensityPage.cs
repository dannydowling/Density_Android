using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density
{
    class DensityPage : ContentPage
    {
        public string x { get; set; }
        
        private Label return_density { get; set; }
        private Picker StatePicker { get; set; }
        private Picker CityPicker { get; set; }
        private Entry AirportText { get; set; }
        public string pickerIcao { get; set; }

        #region ArrangeControlForWeatherMethodAsync()
        /*Format the entry box and make the values reset appropriately*/
        private async Task<string> ArrangeControlForWeatherMethodAsync()
        {
                     
                if (!string.IsNullOrEmpty(App.location.Icao))
                {
                    AirportText.Text = App.location.Icao;                    
                }                
                           
                x = App.weather.ConvertToDensity(App.weather.AirPressure, App.weather.AirTemperature, null);
                return return_density.Text = x.ToString();
                        
        }
        #endregion

        public void DensityPageCreate()
        {
            try
            {
                AirportText = new Entry();
                AirportText.BindingContext = AirportText;
                if (!string.IsNullOrEmpty(App.location.Icao))
                { AirportText.Text = App.location.Icao; }

                return_density = new Label();
                return_density.FontSize = 25;
                return_density.TextColor = Color.Black;
                return_density.VerticalTextAlignment = TextAlignment.Center;
                return_density.HorizontalTextAlignment = TextAlignment.Center;
                return_density.Text = "";
                return_density.BindingContext = return_density;


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

                var states = App.getLocation.GetStates();

                foreach (var state in states)
                {
                    StatePicker.Items.Add(state);
                }
                void StatePicker_SelectedIndexChanged(object sender, EventArgs e)
                {
                    var cities = App.getLocation.GetCities(StatePicker.SelectedItem.ToString());

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
                    pickerIcao = App.getLocation.GetIcao(StatePicker.SelectedItem.ToString(), CityPicker.SelectedItem.ToString());
                    App.location.Icao = pickerIcao.Trim().ToUpperInvariant();
                    AirportText.Text = App.location.Icao;

                    App.getLocation.GetLocationFromIcao(App.location.Icao);

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
                    App.location.Icao = AirportText.Text;
                    Navigation.PopModalAsync();
                };
                exit.GestureRecognizers.Add(exittapGestureRecognizer);

                var update = new SpringBoardButton();
                update.Icon = "Update.png";
                update.Label = "Update";
                var updatetapGestureRecognizer = new TapGestureRecognizer();
                updatetapGestureRecognizer.Tapped += async (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(App.location.Icao))
                    {
                    //an anonymous function cannot return a value so it has to 
                    //be in a separate method.
                    x = await ArrangeControlForWeatherMethodAsync();
                        return_density.Text = x;
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
                Grid.SetRow(AirportText, 3);
                Grid.SetColumn(AirportText, 1);

                Grid.SetRow(Densitypremessage, 4);
                Grid.SetColumn(Densitypremessage, 0);
                Grid.SetColumnSpan(Densitypremessage, 2);
                Grid.SetRow(return_density, 5);
                Grid.SetColumn(return_density, 0);
                Grid.SetColumnSpan(return_density, 2);

                Grid.SetRow(update, 6);
                Grid.SetColumn(update, 0);
                Grid.SetRow(exit, 6);
                Grid.SetColumn(exit, 1);

                grid.Children.Add(EstimateMSG);
                grid.Children.Add(EstimateMSG2);
                grid.Children.Add(icaocodeentry);
                grid.Children.Add(AirportText);
                grid.Children.Add(StatePicker);
                grid.Children.Add(CityPicker);
                grid.Children.Add(Densitypremessage);
                grid.Children.Add(return_density);
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
