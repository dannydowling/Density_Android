using System;
using Xamarin.Forms;

namespace Density
{
    public class CountDownTimer : TimerEventArgs
    {
        public event EventHandler<TimerEventArgs> TimerTicked;
        public DateTime StartDateTime { get; private set; }

        public void StartUpdating(double total)
        {          
                StartDateTime = DateTime.Now;
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    TimeSpan delta = (DateTime.Now - StartDateTime);
                    TimerTicked?.Invoke(this, new TimerEventArgs { Delta = delta });
                    #region warnings
                    if (delta.TotalSeconds >= total + 1200)
                    {
                        App.Current.MainPage.DisplayAlert("20 Minute Warning.", "In 20 minutes the de-Icing effectiveness will be questionable", "OK");
                    }

                    if (delta.TotalSeconds >= total + 600)
                    {
                        App.Current.MainPage.DisplayAlert("10 Minute Warning.", "In 10 minutes the de-Icing effectiveness will be questionable", "OK");
                    }
                   
                    if (delta.TotalSeconds >= total)
                    {
                        App.Current.MainPage.DisplayAlert("Timer has completed.", "HoldOver Time Being Exceeded", "OK");
                        return false;
                    }                   
                    #endregion
                       return true;
                });
            }    
        }
    
  
    public class TimerEventArgs : EventArgs
    {  public TimeSpan Delta { get; set; }
    }
}














