using System;
using System.Collections.Generic;
using System.Text;

namespace ProyextoXamarinNJA.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public int IdUsuario { get; set; }
        public String Mensaje { get; set; }
        public int Valoracion { get; set; }
        public DateTime FechaMensaje { get; set; }
        public int IdForo { get; set; }
    }
}
