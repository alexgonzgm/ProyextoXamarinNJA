using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyextoXamarinNJA.ViewModels
{
    public class CochesViewModel : ViewModelBase
    {
        public CochesViewModel()
        {
            this.CargarCoches();
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

        public void CargarCoches()
        {
            List<Coche> lista = new List<Coche>
            {
                new Coche{Año = 1551 , IdCoche = 1 , IdUsuario=1 , Kilometros=55555,
                    Marca="Opel" , Modelo="Astra", Imagen = "Opel.png"},
                new Coche{Año = 1551 , IdCoche = 2 , IdUsuario=1 , Kilometros=44444,
                    Marca="Seat" , Modelo="Ibiza", Imagen = "Ford.png"},
                new Coche{Año = 1551 , IdCoche = 3 , IdUsuario=1 , Kilometros=51945,
                    Marca="Toyota" , Modelo="Corolla", Imagen = "Ferrari.png"}
            };
            this.Coches = new ObservableCollection<Coche>(lista);
        }
    }
}
