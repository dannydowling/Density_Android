using Density.Business_Layer.Logic;
using Xamarin.Forms;

namespace Density
{
    public class App : Application
    {
        public LayoutPage layoutPage { get; set; }
        public NavigationPage nav { get; set; }


        public App()
        {
            layoutPage = new LayoutPage();

            //layoutPage.LayoutCreate();

            nav = new NavigationPage(layoutPage);

            MainPage = nav;
           
        }
    }
}

