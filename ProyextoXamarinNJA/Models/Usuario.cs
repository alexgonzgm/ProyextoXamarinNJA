using System;
using System.Collections.Generic;
using System.Text;

namespace ProyextoXamarinNJA.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public byte[] Pass { get; set; }
        public String Salt { get; set; }
    }
}
