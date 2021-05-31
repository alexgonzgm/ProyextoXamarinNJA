using System;
using System.Collections.Generic;
using System.Text;

namespace ProyextoXamarinNJA.Models
{
    public class MantenimientoAveria
    {
        public int IdMantenimientoAveria { get; set; }
        public int Tipo { get; set; }
        public String Zona { get; set; }
        public String Logo { get; set; }
        public DateTime FechaMantenimiento { get; set; }
        public int PrecioMantenimiento { get; set; }
        public String ObservacionesMantenimiento { get; set; }
        public int IdCoche { get; set; }
    }
}
