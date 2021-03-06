using Rg.Plugins.Popup.Services;
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
    public partial class CochesView : ContentPage
    {
        public CochesView()
        {
            InitializeComponent();
        }
        private void ShowNewCochePopup(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new NewCochePopupPage());
        }
    }
}