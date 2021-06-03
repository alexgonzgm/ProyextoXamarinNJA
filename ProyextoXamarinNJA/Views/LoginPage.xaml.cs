using ProyextoXamarinNJA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyextoXamarinNJA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //this.iniciar.Clicked += Iniciar_Clicked;
        }

        //private async void Iniciar_Clicked(object sender, EventArgs e)
        //{
        //    //Page Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CochesView)));
        //    //await Navigation.PushModalAsync(new NavigationPage((Page)Activator.CreateInstance(typeof(CochesView))));
        //    //await Navigation.PushAsync(new CochesView());
        //}
    }
}