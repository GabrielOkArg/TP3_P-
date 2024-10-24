using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.BE
{
    public class Trabajador : Persona
    {
        public int Id { get; set; }
        public Categoria Categoria { get; set; }
        public Rango Rango { get; set; }
        public string AreaTrabajo { get; set; }
        public int CantidadHoras { get; set; } = 0;
        public decimal ValorHora { get; set; } = 0.0m;
        public decimal Sueldo { get; set; } = 0.0m;
        public DateTime FechaIngreso { get; set; }

       
    }
}
