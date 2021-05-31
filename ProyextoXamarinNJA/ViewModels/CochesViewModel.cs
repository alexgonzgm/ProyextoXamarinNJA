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
                new Coche{Año = 1551 , IdCoche = 1 , IdUsuario=1 , Kilometros=55555,Marca="Ford" , Modelo="laguna"},
                new Coche{Año = 1551 , IdCoche = 2 , IdUsuario=1 , Kilometros=44444,Marca="Peugeot" , Modelo="laguna"},
                new Coche{Año = 1551 , IdCoche = 3 , IdUsuario=1 , Kilometros=51945,Marca="Renaul" , Modelo="laguna"},
                new Coche{Año = 1551 , IdCoche = 4 , IdUsuario=1 , Kilometros=21649,Marca="Ferrari" , Modelo="laguna"}
            };
            this.Coches = new ObservableCollection<Coche>(lista);
        }
    }
}
