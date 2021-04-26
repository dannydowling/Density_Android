using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density.Business_Layer.Logic
{
    public class CountDownTimer : TimerEventArgs
    {
        private TimeSpan currentTimerTicks;     
        public event EventHandler<TimerEventArgs> OnTimerFire;

        public CountDownTimer(int delay)
        {
                       
            Task.Factory.StartNew(() =>
            {
                
                //check for any subscribers to the event
                if (OnTimerFire != null)
                {
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        TimerEventArgs args = new TimerEventArgs() { Delta = currentTimerTicks };
                        OnTimerFire += Timer_OnTimerFire;
                        Thread.Sleep(delay);
                        return true;
                    });
                }
            });  
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