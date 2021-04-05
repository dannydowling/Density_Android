using PCL = Density;

namespace Density.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoadApplication(new PCL.App());
            Xamarin.FormsMaps.Init("INSERT_AUTHENTICATION_TOKEN_HERE");
        }
    }
}
