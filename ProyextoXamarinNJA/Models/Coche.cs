using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyextoXamarinNJA.Models
{
    public class Coche
    {
        [JsonProperty("idCoche")]
        public int IdCoche { get; set; }
        [JsonProperty("marca")]
        public String Marca { get; set; }
        [JsonProperty("modelo")]
        public String Modelo { get; set; }
        [JsonProperty("año")]
        public int Año { get; set; }
        [JsonProperty("kilometros")]
        public int Kilometros { get; set; }
        [JsonProperty("motor")]
        public String Motor { get; set; }
        [JsonProperty("idUsuario")]
        public int IdUsuario { get; set; }
        //public string Imagen { get; set; }
    }
}
