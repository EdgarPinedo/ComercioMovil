using Comercio_Movil.Services;
using Comercio_Movil.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comercio_Movil
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
