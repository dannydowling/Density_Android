using Density.Business_Layer.Logic;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace Density
{
    class TimerPage : ContentPage
    {
        public Label remainTime { get; set; }           

        public void TimerCreate()
        {
            try
            {
                Image banner = new Image();
                banner.HeightRequest = 100;
                banner.Source = "Banner.png";

                Label instruction = new Label();
                instruction.FontSize = 14;
                instruction.HorizontalTextAlignment = TextAlignment.Center;
                instruction.Text = "Start after applying Deicing fluid.";

                ZoomContainer zoom = new ZoomContainer();
                Image aircraftinfo = new Image();
                aircraftinfo.Source = "deIcing.png";
                zoom.Content = aircraftinfo;

                Label caution = new Label();
                caution.FontSize = 14;
                caution.HorizontalTextAlignment = TextAlignment.Center;
                caution.Text = "If the timer stops before departure, reapply fluid. Uses Weather.gov and Type 4 50/50 mix holdover guidelines from the FAA.";

                Label elapsed = new Label();
                elapsed.FontSize = 18;
                elapsed.HorizontalTextAlignment = TextAlignment.Center;
                elapsed.Text = "Time Elapsed:";

                remainTime = new Label();
                remainTime.FontSize = 18;
                remainTime.HorizontalTextAlignment = TextAlignment.Center;
                remainTime.BindingContext = "CountDownTimer";

                var exit = new SpringBoardButton();
                exit.Icon = "Exit.png";
                exit.Label = "Exit";
                var exittapGestureRecognizer = new TapGestureRecognizer();
                exittapGestureRecognizer.Tapped += (s, e) =>
                {
                    Navigation.PopModalAsync();
                };
                exit.GestureRecognizers.Add(exittapGestureRecognizer);

                var menu = new SpringBoardButton();
                menu.Icon = "Start.png";
                menu.Label = "Timer";
                var menutapGestureRecognizer = new TapGestureRecognizer();
                menutapGestureRecognizer.Tapped += (s, e) =>
                {
                    StartTimer();
                };
                menu.GestureRecognizers.Add(menutapGestureRecognizer); ;

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


                Grid.SetRow(instruction, 0);
                Grid.SetColumn(instruction, 0);
                Grid.SetRow(elapsed, 1);
                Grid.SetColumn(elapsed, 0);
                Grid.SetRow(remainTime, 1);
                Grid.SetColumn(remainTime, 1);
                Grid.SetRow(zoom, 2);
                Grid.SetColumn(zoom, 0);
                Grid.SetRowSpan(zoom, 2);
                Grid.SetColumnSpan(zoom, 2);
                Grid.SetRow(caution, 5);
                Grid.SetColumn(caution, 0);
                Grid.SetColumnSpan(caution, 2);
                Grid.SetRow(menu, 6);
                Grid.SetColumn(menu, 0);
                Grid.SetRow(exit, 6);
                Grid.SetColumn(exit, 1);

                grid.Children.Add(instruction);
                grid.Children.Add(elapsed);
                grid.Children.Add(remainTime);
                grid.Children.Add(zoom);
                grid.Children.Add(caution);
                grid.Children.Add(menu);
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
                App.Current.MainPage.DisplayAlert("The timer page failed to load.", "Check the code and try again", "OK");
            }
        }

        public async System.Threading.Tasks.Task StartTimer()
        {
            //I hate this, it's because I can't inherit or see the things in the APP class.
            Weather weather = new Weather();
            weather.Init();
            weather.AirTemperature *= 40000;
            double counter = 1600000 + weather.AirTemperature;
            //gives an hour at 50 degrees, 
            //gives 53 minutes at 40 degrees, 
            //46 minutes at 30 degrees, 30 
            //minutes at 0 degrees

            Timer countdown = new Timer();
            countdown.Update(counter);
            countdown.OnTimerFire += Countdown_TimerTicked;
        }

        private void Countdown_TimerTicked(object sender, TimerEventArgs e)
        {
            remainTime.Text = string.Format(string.Format("{0:D2} : {1:D2} : {2:D2}", e.TimeOffset.Hours, e.TimeOffset.Minutes, e.TimeOffset.Seconds));
        }
    }
}

