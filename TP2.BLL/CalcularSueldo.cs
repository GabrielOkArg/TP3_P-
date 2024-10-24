using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.BE;

namespace TP2.BLL
{
    public static class CalcularSueldo
    {
        public static decimal Calcular(Trabajador trabajador)
        {


            return trabajador.CantidadHoras * trabajador.ValorHora;
        }
    }
}
