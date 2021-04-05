using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Density
{
    public class App : Application
    {
        public static FileNameRespository files { get; set; }
        public static GetLocation getLocation { get; set; }
        public static Location location { get; set; }
        public JArray JPositions { get; set; }

        private HttpClientHandler _handler;
        public HttpClientHandler handler
        {
            get
            {
                if (handler == null)
                    _handler = new HttpClientHandler();
                return _handler;
            }
            set { _handler = value; }
        }

        private HttpClient _client;
        public HttpClient httpClient
        {
            get
            {

                if (httpClient == null)
                {
                    httpClient = new HttpClient(handler);
                    _client.DefaultRequestHeaders.Add("Accept", "application/json");
                    _client.DefaultRequestHeaders.Add("User-Agent", "DensityApp");
                }
                httpClient = _client;
                return _client;
            }
            set { _client = value; }
        }

        public App()
        {
            // The root page of your application
            LayoutPage layoutPage = new LayoutPage();
            layoutPage.LayoutCreate();
            var nav = new NavigationPage(layoutPage);
            MainPage = nav;
        }

       
        protected  override void OnStart()
        {           
                files = new FileNameRespository();
                getLocation = new GetLocation();
                location = new Location();
                getLocation.Init();           
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        
    }
}

