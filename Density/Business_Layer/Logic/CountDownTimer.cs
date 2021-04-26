using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density.Business_Layer.Logic
{
    public class CountDownTimer : TimerEventArgs
    {
        private int delay;
        private bool active;
        public event EventHandler<TimerEventArgs> OnTimerTicked;

        public void StartTimer(int delay)
        {
                       
            Task.Factory.StartNew(() =>
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    TimeSpan delta;
                    OnTimerTicked?.Invoke(this, new TimerEventArgs { Delta = delta, Delay = delay});                   
                    return active;
                });
            });  
        }
                

        private void Timer_OnTimerFire(object sender, TimerEventArgs args)
        {
            timeText = string.Format("{0:D2} : {1:D2} : {2:D2}", args.Delta.Hours, args.Delta.Minutes, args.Delta.Seconds);

            if (args.Delta.TotalSeconds >= 0 + delay)
            {
                App.Current.MainPage.DisplayAlert("20 Minute Warning.", "In 20 minutes the de-Icing effectiveness will be questionable", "OK");
                active = true;
            }

            if (args.Delta.TotalSeconds >= 600 + delay)
            {
                App.Current.MainPage.DisplayAlert("10 Minute Warning.", "In 10 minutes the de-Icing effectiveness will be questionable", "OK");
                active = true;
            }

            if (args.Delta.TotalSeconds >= 1200 + delay)
            {
                App.Current.MainPage.DisplayAlert("Time's up.", "The de-ice holdover timer has expired.", "OK");
                active = false;
            }
        }
    }
    

    public class TimerEventArgs : EventArgs
    {

        public string timeText { get; set; }
       public TimeSpan Delta { get; set; }
        public int Delay { get; set; }
    }      
    
}