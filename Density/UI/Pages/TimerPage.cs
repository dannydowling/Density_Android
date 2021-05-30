using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System;
using Xamarin.Forms;

namespace Density
{
    class TimerPage : ContentPage
    {
        public Label remainTime { get; set; }
        public void TimerCreate(WeatherClass weatherClass)
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
                    StartTimer(weatherClass);
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


        public event EventHandler<TimerEventArgs> TimerTicked;        
        public DateTime StartDateTime { get; private set; }
        internal int delay;
        internal bool timerActive;

        public event EventHandler TimerExpired;
        public event EventHandler timerWarning;        

        private bool minute20WarningShown;
        private bool minute10WarningShown;
        private bool minute0WarningShown;

        public void StartTimer(WeatherClass weatherClass)
        {
            delay = 0;
            delay += (Convert.ToInt32(weatherClass.AirTemperature - 60));
            delay += (Convert.ToInt32(weatherClass.AirPressure - 1018));

            StartDateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TimeSpan delta = (DateTime.Now - StartDateTime);
                TimerTicked?.Invoke(this, new TimerEventArgs { Delta = delta });
                TimerTicked += Countdown_TimerTicked;

                //active because as long as the timer returns true the timer keeps running.
                return timerActive;

            });
        }

        private void Countdown_TimerTicked(object sender, TimerEventArgs e)
        {
            remainTime.Text = string.Format(string.Format("{0:D2} : {1:D2} : {2:D2}", e.Delta.Hours, e.Delta.Minutes, e.Delta.Seconds));

            var delta_int = e.Delta.TotalSeconds;

            if (minute20WarningShown != true)
            {
                if (delta_int >= 0 + delay)
                {
                    App.Current.MainPage.DisplayAlert("20 Minute Warning.", "In 20 minutes the de-Icing effectiveness will be questionable", "OK");
                    timerActive = true;
                    timerWarning += TimerPage_timerWarning;
                    minute20WarningShown = true;
                }
            }

            if (minute10WarningShown != true)
            {
                if (delta_int >= 600 + delay)
                {
                    App.Current.MainPage.DisplayAlert("10 Minute Warning.", "In 10 minutes the de-Icing effectiveness will be questionable", "OK");
                    timerActive = true;
                    timerWarning += TimerPage_timerWarning;
                    minute10WarningShown = true;
                }
            }

            if (minute0WarningShown != true)
            {
                if (delta_int >= 1200 + delay)
                {
                    App.Current.MainPage.DisplayAlert("Time's up.", "The de-ice holdover timer has expired.", "OK");
                    timerActive = false;
                    timerWarning += TimerPage_timerWarning;
                    TimerExpired += TimerPage_TimerExpired;
                    minute0WarningShown = true;
                    
                }
            }
           
            timerActive = true;
        }

        private void TimerPage_timerWarning(object sender, EventArgs e)
        {
            
            throw new NotImplementedException();
        }

        private void TimerPage_TimerExpired(object sender, EventArgs e)
        {
            
            throw new NotImplementedException();
        }

        public class TimerEventArgs : EventArgs
        {
            public TimeSpan Delta { get; set; }
        }
    }
}

