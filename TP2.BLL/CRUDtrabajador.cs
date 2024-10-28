
using BE.DAL;
using System;
using System.Collections.Generic;
using TP2.BE;
using TP2.BLL.interfaces;
using TP2.DAL;

namespace TP2.BLL
{
    public class CRUDtrabajador : Icrud<Trabajador>
    {

        private string _myconectionString;
        private MapperTrabajador MapperTrabajador;

        public CRUDtrabajador(string myconectionString)
        {
           
            _myconectionString = myconectionString;
            MapperTrabajador = new MapperTrabajador(myconectionString);
        }
        public void Delete(Trabajador entity)
        {
          MapperTrabajador.Delete(entity);
        }

        public Trabajador FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Trabajador> GetAll()
        {
            List<Trabajador> listado = MapperTrabajador.GetAll();
            return listado;
        }

        public void Insert(Trabajador entity)
        {
            MapperTrabajador.Insert(entity);
        }
        private void TrabajadorValidation(Trabajador entity)
        {

            if (DateTime.Compare(entity.FechaIngreso, DateTime.Now) > 0)
                throw new Exception("Fecha de ingreso invalida");
        }


        public void Update(Trabajador entity)
        {
            MapperTrabajador.Update(entity);
         
        }

        public void UpdateTrabajador(Trabajador trabajador)
        {
            MapperTrabajador.UpdateTrabajador(trabajador);
        }
    }
}
