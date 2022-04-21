using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SimpleNimbleExtended.API;
using SimpleNimbleExtended.API.Implementation;
using SimpleNimbleExtended;
using System.Resources;

namespace SimpleNimbleExtended
{
    public partial class App : Application {
        public App() {
            InitializeComponent();

            

            ISNapi simpleNimbleAPI = new SimpleNimbleAPI(SimpleNimbleExtended.Properties.AppResources.API_URL);

            Controler ctrl = Controler.GetInstance();
            ctrl.Load(simpleNimbleAPI);

            
            MainPage = new NavigationPage( new MainPage());
            
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
