using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using ProyextoXamarinNJA.Services;
using ProyextoXamarinNJA.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyextoXamarinNJA.ViewModels
{
    public class CochesViewModel : ViewModelBase
    {
        private ServiceCoche ServiceCoches;

        public CochesViewModel(ServiceCoche serviceCoches)
        {
            this.ServiceCoches = serviceCoches;
            Task.Run(async () =>
            {
                await this.CargarCochesAsync();
            });
            //this.CargarCoches();

            MessagingCenter.Subscribe<CochesViewModel>
                (this, "RELOAD", async (sender) =>
                {
                    await this.CargarCochesAsync();
                });
        }

        private ObservableCollection<Coche> _Coches;
        public ObservableCollection<Coche> Coches
        {
            get { return this._Coches; }
            set
            {
                this._Coches = value;
                OnPropertyChanged("Coches");
            }
        }

        private async Task CargarCochesAsync()
        {
            List<Coche> lista = await this.ServiceCoches.GetCocheAsync(1);
            this.Coches = new ObservableCollection<Coche>(lista);
        }

        //public void CargarCoches()
        //{
        //    List<Coche> lista = new List<Coche>
        //    {
        //        new Coche{Año = 1551 , IdCoche = 1 , IdUsuario=1 , Kilometros=55555,
        //            Marca="Opel" , Modelo="Astra", Imagen = "Opel.png"},
        //        new Coche{Año = 1551 , IdCoche = 2 , IdUsuario=1 , Kilometros=44444,
        //            Marca="Seat" , Modelo="Ibiza", Imagen = "Ford.png"},
        //        new Coche{Año = 1551 , IdCoche = 3 , IdUsuario=1 , Kilometros=51945,
        //            Marca="Toyota" , Modelo="Corolla", Imagen = "Ferrari.png"}
        //    };
        //    this.Coches = new ObservableCollection<Coche>(lista);
        //}

        public Command EditarCoche
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Has pulsado en editar", "OK");
                });
            }
        }
        public Command EliminarCoche
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Has pulsado en eliminar", "OK");
                });
            }
        }

        public Command show
        {
            get
            {
                return new Command(async () =>
                {
                  await  PopupNavigation.Instance.PushAsync(new NewCochePopupPage());
                });
            }
        }
    }
}

