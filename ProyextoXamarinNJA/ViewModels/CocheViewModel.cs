using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using ProyextoXamarinNJA.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ProyextoXamarinNJA.ViewModels
{
    public class CocheViewModel : ViewModelBase
    {
        ServiceCoches serviceCoches;
        public CocheViewModel(ServiceCoches serviceCoches)
        {
            this.serviceCoches = serviceCoches;
            this.Coche = new Coche();
            Task.Run(async () =>
            {
                await this.CargarAverias();
            });
            MessagingCenter.Subscribe<CocheViewModel>(this, "RELOAD", async (sender) =>
            {
                await this.CargarAverias();
            });
        }

        public async Task CargarAverias()
        {
            List<MantenimientoAveria> lista = await this.serviceCoches.GetMantenimientoAveriaAsync(this.Coche.IdCoche);
            this.MantenimientoAverias = new ObservableCollection<MantenimientoAveria>(lista);
        }

        private Coche _Coche;
        public Coche Coche
        {
            get { return this._Coche; }
            set
            {
                this._Coche = value; OnPropertyChanged("detalles");
            }
        }

        private ObservableCollection<MantenimientoAveria> _MantenimientoAverias;
        public ObservableCollection<MantenimientoAveria> MantenimientoAverias
        {
            get { return this._MantenimientoAverias; }
            set
            {
                this._MantenimientoAverias = value;
                OnPropertyChanged("MantenimientoAverias");
            }
        }

        public Command EliminarCoche
        {
            get
            {
                return new Command(async () =>
                {
                    //Coche coche = car as Coche;
                    await this.serviceCoches.EliminarCocheAsync(this.Coche.IdCoche);
                    MessagingCenter.Send(App.ServiceLocator.CochesViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });

            }
        }

        public Command ModificarCoche
        {
            get
            {
                return new Command(async () => {
                    await this.serviceCoches.ModificarCocheAsync(this.Coche.IdCoche,
                        this.Coche.Marca, this.Coche.Modelo,this.Coche.Año , this.Coche.Kilometros ,this.Coche.Motor );
                    MessagingCenter.Send(App.ServiceLocator.CochesViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command Insertarcoche
        {
            get
            {
                return new Command(async () => {
                    await this.serviceCoches.InsertarCocheAsync
                    (
                    this.Coche.Marca
                    , this.Coche.Modelo,
                    this.Coche.Año, this.Coche.Kilometros, this.Coche.Motor , this.Coche.IdUsuario);
                    MessagingCenter.Send
                    (App.ServiceLocator.CochesViewModel, "RELOAD");
                    await PopupNavigation.Instance.PopAsync();
                    
                });
            }
        }
    }
}





