using ProyextoXamarinNJA.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyextoXamarinNJA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CochesView();
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
