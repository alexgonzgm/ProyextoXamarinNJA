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
    public class ForoViewModel: ViewModelBase
    {
        ServiceCoches serviceCoches;
        public ForoViewModel(ServiceCoches serviceCoches)
        {
            this.serviceCoches = serviceCoches;
            this.Foro = new Foro();
            this.Comentario = new Comentario();
            Task.Run(async () =>
            {
                await this.CargarComentarios();
            });
            MessagingCenter.Subscribe<CocheViewModel>(this, "RELOAD", async (sender) =>
            {
                await this.CargarComentarios();
            });
            MessagingCenter.Subscribe<ForoViewModel>(this, "RELOAD", async (sender) =>
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

        private Comentario _Comentario;
        public Comentario Comentario
        {
            get { return this._Comentario; }
            set
            {
                this._Comentario = value;
                OnPropertyChanged("Comentario");
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

        public Command show
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(new NewComentarioPopupPage());
                });
            }
        }

        public Command NuevoComentario
        {
            get
            {
                return new Command(async () => {
                    await this.serviceCoches.InsertarComentarioAsync(this.Comentario.IdComentario, 1, this.Comentario.Mensaje,
                        this.Comentario.Valoracion, this.Comentario.FechaMensaje, this.Comentario.IdForo);
                    MessagingCenter.Send(App.ServiceLocator.ForoViewModel, "RELOAD");
                    //await Application.Current.MainPage.Navigation.PopModalAsync();
                    await PopupNavigation.Instance.PopAsync();


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
