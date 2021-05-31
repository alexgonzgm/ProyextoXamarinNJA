using System;
using System.Collections.Generic;
using System.Text;

namespace ProyextoXamarinNJA.Models
{
    public class Coche
    {
        //[JsonProperty("idDoctor")]
        public int IdCoche { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public int Año { get; set; }
        public int Kilometros { get; set; }
        public String Motor { get; set; }
        public int IdUsuario { get; set; }
        public string Imagen { get; set; }
    }
}
