using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using ProyextoXamarinNJA.Services;
using ProyextoXamarinNJA.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyextoXamarinNJA.ViewModels
{
    public class UsuarioViewModel: ViewModelBase
    {
        ServiceCoches ServiceCoches;

        public UsuarioViewModel(ServiceCoches serviceCoches)
        {
            this.ServiceCoches = serviceCoches;
        }

        private Usuario _Usuario;
        public  Usuario Usuario
        {
            get { return this._Usuario; }
            set
            {
                this._Usuario = value;
                OnPropertyChanged("Usuario");
            }
        }


        public Command ComprobarUsuario
        {
            get
            {
                return new Command(async () =>
                {
                    CochesView view = new CochesView();
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);

                    //Usuario usuario = usu as Usuario;
                    //await this.ServiceCoches.UserLogInAsync();
                });
            }
        }
    }
}
