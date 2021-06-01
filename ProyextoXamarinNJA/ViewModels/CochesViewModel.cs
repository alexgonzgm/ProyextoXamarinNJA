﻿using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using ProyextoXamarinNJA.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyextoXamarinNJA.ViewModels
{
    public class CochesViewModel : ViewModelBase
    {
        private ServiceCoches ServiceCoches;

        public CochesViewModel(ServiceCoches serviceCoches)
        {
            this.ServiceCoches = serviceCoches;
            Task.Run(async () =>
            {
                await this.CargarCochesAsync();
            });
            //this.CargarCoches();
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
            List<Coche> lista = await this.ServiceCoches.GetCochesAsync(1);
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
    }
}
