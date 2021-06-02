using ProyextoXamarinNJA.Base;
using ProyextoXamarinNJA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyextoXamarinNJA.ViewModels
{
    public class ForoViewmModel : ViewModelBase
    {
        public ForoViewmModel()
        {
            this.CargarForo();

        }

        private ObservableCollection<Foro> _Foro;
        public ObservableCollection<Foro> Foro
        {
            get { return this._Foro; }
            set { this._Foro = value; OnPropertyChanged("foros"); }
        }

        private List<Foro> CargarForo()
        {
            List<Foro> lista = new List<Foro>
            {
                new Foro{IdForo=1 , Asunto="Foro1" , Contenido = "text ever since the 1500s, when an unknown " +
                "printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets conta",
                Marca="Ford.png" , Modelo="Mondeo"},
                new Foro{IdForo=1 , Asunto="Foro1" , Contenido = "text ever since the 1500s, when an unknown " +
                "printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets conta",
                Marca="Ford.png" , Modelo="Mondeo"},
                new Foro{IdForo=1 , Asunto="Foro1" , Contenido = "text ever since the 1500s, when an unknown " +
                "printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets conta",
                Marca="Ford.png" , Modelo="Mondeo"},
                new Foro{IdForo=1 , Asunto="Foro1" , Contenido = "text ever since the 1500s, when an unknown " +
                "printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets conta",
                Marca="Ford.png" , Modelo="Mondeo"},
                new Foro{IdForo=1 , Asunto="Foro1" , Contenido = "text ever since the 1500s, when an unknown " +
                "printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets conta",
                Marca="Ford.png" , Modelo="Mondeo"},
                new Foro{IdForo=1 , Asunto="Foro1" , Contenido = "text ever since the 1500s, when an unknown " +
                "printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets conta",
                Marca="Ford.png" , Modelo="Mondeo"},
            };
            this._Foro = new ObservableCollection<Foro>(lista);
            return lista;
        }

    }
}
