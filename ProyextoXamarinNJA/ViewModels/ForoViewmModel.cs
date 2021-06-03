using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using ProyextoXamarinNJA.Services;
using ProyextoXamarinNJA.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyextoXamarinNJA.ViewModels
{
    public class ForoViewmModel : ViewModelBase
    {
         ServiceCoches serviceCoche;

        public ForoViewmModel(ServiceCoches serviceCoche)
        {
            this.serviceCoche = serviceCoche;
            Task.Run(async () =>
            {
                await this.CargarForosAsync();

            });
        }

        private ObservableCollection<Foro> _Foros;
        public ObservableCollection<Foro> Foros
        {
            get { return this._Foros; }
            set { this._Foros = value; OnPropertyChanged("Foros"); }
        }

        private async Task CargarForosAsync()
        {
            this.Foros = new ObservableCollection<Foro>(await this.serviceCoche.GetForoAsync());
        }

        public Command DetallesForo
        {
            get
            {
                return new Command(async(f) =>
                {
                    Foro foro = f as Foro;
                    ForoViewModel viewmodel = App.ServiceLocator.ForoViewModel;
                    viewmodel.Foro = foro;
                    DetailsForoView view = new DetailsForoView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
