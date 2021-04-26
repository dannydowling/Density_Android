using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density.Business_Layer.Logic
{
    public class CountDownTimer : TimerEventArgs
    {
        private TimeSpan currentTimerTicks;
        private int delay;      
        public event EventHandler<TimerEventArgs> OnTimerFire;

        public CountDownTimer()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(delay);
                //check for any subscribers to the event
                if (OnTimerFire != null)
                {
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        TimerEventArgs args = new TimerEventArgs() { Delta = currentTimerTicks };
                        OnTimerFire += Timer_OnTimerFire;
                        return true;
                    });
                }
            });  
        }

        public CountDownTimer(DateTimeOffset delay)
        {
            //if we pass in a delay to start, set the currentTimerTicks to have to wait until that delay elapses
            this.delay = delay.Second;                    
        }


        private void Timer_OnTimerFire(object sender, TimerEventArgs args)
        {
            if (args.Delta.TotalSeconds >= 1200)
            {
                App.Current.MainPage.DisplayAlert("20 Minute Warning.", "In 20 minutes the de-Icing effectiveness will be questionable", "OK");
            }

            if (args.Delta.TotalSeconds >= 600)
            {
                App.Current.MainPage.DisplayAlert("10 Minute Warning.", "In 10 minutes the de-Icing effectiveness will be questionable", "OK");
            }
        }
    }
    

    public class TimerEventArgs : EventArgs
    {
       public TimeSpan Delta { get; set; }
    }      
    
}