using System;
using Xamarin.Forms;

namespace Density.Business_Layer.Logic
{
    public class CountDownTimer : TimerEventArgs
    {
        private double currentTimerTicks;
        private double delay;      
        public event OnTimerFireHandler OnTimerFire;        

        public CountDownTimer()
        {       
            // 1 second increments, the callback is to the update method
            Device.StartTimer(TimeSpan.FromSeconds(1), () => Update(currentTimerTicks));
        }

        public CountDownTimer(double delay)
        {
            //if we pass in a delay to start, set the currentTimerTicks to have to wait until that delay elapses
            this.delay = delay;
            currentTimerTicks -= delay;         
        }     

        public bool Update(double offset)
        {                        
            currentTimerTicks += offset;
           
           
            //check for any subscribers to the event
                if (OnTimerFire != null)
                {
                    TimerEventArgs args = new TimerEventArgs() { TimeTicks = currentTimerTicks };  
                    OnTimerFire += Timer_OnTimerFire;                    
                    return true;
                }
            
            return false;
        }

        private void Timer_OnTimerFire(object sender, TimerEventArgs args)
        {
            if (args.TimeOffset.TotalSeconds >= 1200)
            {
                App.Current.MainPage.DisplayAlert("20 Minute Warning.", "In 20 minutes the de-Icing effectiveness will be questionable", "OK");
            }

            if (args.TimeOffset.TotalSeconds >= 600)
            {
                App.Current.MainPage.DisplayAlert("10 Minute Warning.", "In 10 minutes the de-Icing effectiveness will be questionable", "OK");
            }
        }
    }
    

    public class TimerEventArgs : EventArgs
    {
        public TimeSpan TimeOffset;
        public double TimeTicks { get => TimeOffset.TotalSeconds; set => Convert.ToDateTime(value); }
    }

    public delegate void OnTimerFireHandler(object sender, TimerEventArgs args);
    
}