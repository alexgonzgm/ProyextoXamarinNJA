using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using ProyextoXamarinNJA.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyextoXamarinNJA.ViewModels
{
    public class ForoViewModel: ViewModelBase
    {
        ServiceCoches serviceCoches;
        public ForoViewModel(ServiceCoches serviceCoches)
        {
            this.serviceCoches = serviceCoches;
            this.Foro = new Foro();
            Task.Run(async () =>
            {
                await this.CargarComentarios();
            });
            MessagingCenter.Subscribe<CocheViewModel>(this, "RELOAD", async (sender) =>
            {
                await this.CargarComentarios();
            });
        }

        public async Task CargarComentarios()
        {
            List<Comentario> lista = await this.serviceCoches.GetComentarioAsync(this.Foro.IdForo);
            this.Comentarios = new ObservableCollection<Comentario>(lista);
        }

        private Foro _Foro;
        public Foro Foro
        {
            get { return this._Foro; }
            set
            {
                this._Foro = value;
                OnPropertyChanged("Foro");
            }
        }

        private ObservableCollection<Comentario> _Comentarios;
        public ObservableCollection<Comentario> Comentarios
        {
            get { return this._Comentarios; }
            set
            {
                this._Comentarios = value;
                OnPropertyChanged("Comentarios");
            }
        }

        public Command EliminarCoche
        {
            get
            {
                return new Command(async () =>
                {
                    ////Coche coche = car as Coche;
                    //await this.serviceCoches.EliminarCocheAsync(this.Coche.IdCoche);
                    //MessagingCenter.Send(App.ServiceLocator.CochesViewModel, "RELOAD");
                    //await Application.Current.MainPage.Navigation.PopModalAsync();
                });

            }
        }

        public Command ModificarCoche
        {
            get
            {
                return new Command(async () => {
                    //await this.serviceCoches.ModificarCocheAsync(this.Coche.IdCoche,
                    //    this.Coche.Marca, this.Coche.Modelo, this.Coche.Año, this.Coche.Kilometros, this.Coche.Motor);
                    //MessagingCenter.Send(App.ServiceLocator.CochesViewModel, "RELOAD");
                    //await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command Insertarcoche
        {
            get
            {
                return new Command(async () => {
                    //await this.serviceCoches.InsertarCocheAsync
                    //(
                    //this.Coche.Marca
                    //, this.Coche.Modelo,
                    //this.Coche.Año, this.Coche.Kilometros, this.Coche.Motor, this.Coche.IdUsuario);
                    //MessagingCenter.Send
                    //(App.ServiceLocator.CochesViewModel, "RELOAD");
                    //await PopupNavigation.Instance.PopAsync();

                });
            }
        }
    }
}
