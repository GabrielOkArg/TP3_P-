using BE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.BE;
using TP2.DAL;

namespace TP2.BLL
{
    public class CrudUtils
    {
        private MapperCategoria mapperCategoria;
        private MapperRangos mapperRango;

        public CrudUtils(string connectionString)
        {
            mapperCategoria = new MapperCategoria(connectionString);
            mapperRango = new MapperRangos(connectionString);
        }


        public List<Rango> GetRangos()
        {
            return mapperRango.GetAll();
        }

        public List<Categoria> GetCategorias()
        {
            return mapperCategoria.GetAll();
        }

        public Categoria GetCategoriaBy(int id)
        {
            return mapperCategoria.FindById(id);
        }
        public Rango GetRangoBy(int id)
        {
            return mapperRango.FindById(id);
        }

    }
}
