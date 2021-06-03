using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using ProyextoXamarinNJA.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace ProyextoXamarinNJA.ViewModels
{
    public class CocheViewModel : ViewModelBase
    {
        ServiceCoche serviceCoches;
        public CocheViewModel(ServiceCoche serviceCoches)
        {
            this.serviceCoches = serviceCoches;
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

        public Command EliminraCoche
        {
            get
            {
                return new Command(async () => {
                    //await
                    //this.serviceCoches
                    //(this.Departamento.IdDepartamento);
                    //MessagingCenter.Send
                    //(App.ServiceLocator.DepartamentosViewModel, "RELOAD");
                    //await Application.Current.MainPage
                    //.Navigation.PopModalAsync();
                });
            }
        }

        public Command ModificarCoche
        {
            get
            {
                return new Command(async () => {
                    await this.serviceCoches.ModificarCocheAsync 
                    (
                        this.Coche.IdCoche,
                    this.Coche.Marca
                    , this.Coche.Modelo,
                    this.Coche.Año , this.Coche.Kilometros ,this.Coche.Motor );
                    MessagingCenter.Send
                    (App.ServiceLocator.CochesViewModel, "RELOAD");
                    await Application.Current.MainPage
                    .Navigation.PopModalAsync();
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
                    await Application.Current.MainPage
                    .DisplayAlert("Alert", "Departamento insertado"
                    , "OK");
                });
            }
        }
    }
}





