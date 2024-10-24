using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TP2.BE;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BE.DAL
{
    public class MapperTrabajador : Imapper<Trabajador>
    {

        
       private SqlDataAdapter dataAdapter;
        public MapperTrabajador(string myconectionString)
        {
            string error = "";
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * FROM Personas", myconectionString);
            }
            catch (SqlException ex)
            {
               error = ex.Message;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        

        }
        public void Delete(Trabajador entity)
        {
            try
            {
                DataTable dt = ConexionBD.GetDataTable("SELECT * FROM Personas WHERE Id = "+entity.Id, dataAdapter);
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0].Delete();
                    ConexionBD.UpdateDataBase(dt, "SELECT * FROM Personas", dataAdapter);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Trabajador FindById(int id)
        {
            DataTable dataTable = new DataTable();
            dataTable = ConexionBD.GetDataTable("select R.Id as RangoId, R.Nombre as RangoNombre, C.Id as CategoriaId, C.Nombre as CategoriaNombre, *  \r\nfrom Personas P\r\ninner join Rangos R on P.RangoId = R.Id \r\ninner join Categorias C on p.CategoriaId = C.Id \r\nWHERE P.Id = " + id, dataAdapter);

            if (dataTable.Rows.Count >0)
            {
                Trabajador trabajador = new Trabajador();
                trabajador.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);   
                trabajador.Nombre = dataTable.Rows[0]["Nombre"].ToString();
                trabajador.Apellido = dataTable.Rows[0]["Apellido"].ToString();
                trabajador.Domicilio = dataTable.Rows[0]["Domicilio"].ToString();
                trabajador.Localidad = dataTable.Rows[0]["Localidad"].ToString();
                trabajador.Provincia = dataTable.Rows[0]["Provincia"].ToString();
                trabajador.NroCelular = Convert.ToInt32(dataTable.Rows[0]["NroCelular"]);
                trabajador.Categoria = new Categoria();
                trabajador.Categoria.Id = Convert.ToInt32(dataTable.Rows[0]["CategoriaId"]);
                trabajador.Categoria.Nombre = dataTable.Rows[0]["CategoriaNombre"].ToString();
                trabajador.Rango = new Rango();
                trabajador.Rango.Nombre = dataTable.Rows[0]["RangoNombre"].ToString();
                trabajador.Rango.Id = Convert.ToInt32(dataTable.Rows[0]["RangoId"]);
                trabajador.AreaTrabajo = dataTable.Rows[0]["AreaTrabajo"].ToString();
                trabajador.CantidadHoras = Convert.ToInt32(dataTable.Rows[0]["CantidadHoras"]);
                trabajador.ValorHora = Convert.ToDecimal(dataTable.Rows[0]["ValorHora"]);
                trabajador.Sueldo = Convert.ToDecimal(dataTable.Rows[0]["Sueldo"]);
                return trabajador;
            }
            return null;
        }

        public List<Trabajador> GetAll()
        {
            List<Trabajador> listado = new List<Trabajador>();
            DataTable dt = new DataTable();
            dt = ConexionBD.GetDataTable("select R.Id as RangoId, R.Nombre as RangoNombre, C.Id as CategoriaId, C.Nombre as CategoriaNombre, *  from Personas P\r\ninner join Rangos R on P.RangoId = R.Id\r\ninner join Categorias C on p.CategoriaId = C.Id", dataAdapter);
            foreach (DataRow item in dt.Rows)
            {
                Trabajador trabajador = new Trabajador();
                trabajador.Id = Convert.ToInt32(item["Id"]);
                trabajador.Nombre = item["Nombre"].ToString();
                trabajador.Apellido = item["Apellido"].ToString();
                trabajador.Domicilio = item["Domicilio"].ToString();
                trabajador.Localidad = item["Localidad"].ToString();
                trabajador.Provincia = item["Provincia"].ToString();
                trabajador.NroCelular = Convert.ToInt32(item["NroCelular"]);
                trabajador.Categoria = new Categoria();
                trabajador.Categoria.Id = Convert.ToInt32(item["CategoriaId"]);
                trabajador.Categoria.Nombre = item["CategoriaNombre"].ToString();
                trabajador.Rango = new Rango();
                trabajador.Rango.Nombre = item["RangoNombre"].ToString();
                trabajador.Rango.Id = Convert.ToInt32(item["RangoId"]);
                trabajador.AreaTrabajo = item["AreaTrabajo"].ToString();
                trabajador.CantidadHoras = Convert.ToInt32(item["CantidadHoras"]);
                trabajador.ValorHora = Convert.ToDecimal(item["ValorHora"]);
                trabajador.Sueldo = Convert.ToDecimal(item["Sueldo"]);
                trabajador.FechaIngreso = Convert.ToDateTime(item["FechaIngreso"]);
                listado.Add(trabajador);
            };
            return listado;
        }

        public void Insert(Trabajador entity)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ConexionBD.GetDataTable("SELECT * FROM Personas", dataAdapter);
                DataRow dr = dt.NewRow();
                dr["Nombre"] = entity.Nombre;
                dr["Apellido"] = entity.Apellido;
                dr["CategoriaId"] = entity.Categoria.Id;
                dr["RangoId"] = entity.Rango.Id;
                dr["AreaTrabajo"] = entity.AreaTrabajo;
                dr["CantidadHoras"] = entity.CantidadHoras;
                dr["ValorHora"] = entity.ValorHora;
                dr["Sueldo"] = entity.Sueldo;
                dr["FechaIngreso"] = entity.FechaIngreso;
                dr["Localidad"] = entity.Localidad;
                dr["Provincia"] = entity.Provincia;
                dr["NroCelular"] = entity.NroCelular;
                dr["Domicilio"] = entity.Domicilio;
                dr["Id"] = 0;

                dt.Rows.Add(dr);
                ConexionBD.UpdateDataBase(dt,"SELECT * FROM Personas",dataAdapter);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(Trabajador entity)
        {
            try
            {
                Trabajador trabajador = FindById(entity.Id);
                if (trabajador != null)
                {
                    DataTable dt  = ConexionBD.GetDataTable("SELECT * FROM Personas", dataAdapter);
                    if (dt.Rows.Count > 0 )
                    {
                        DataRow dr = dt.Rows[0];
                        dr["ValorHora"] = entity.ValorHora;
                        dr["CantidadHoras"] = entity.CantidadHoras;

                    }
                    ConexionBD.UpdateDataBase(dt, "SELECT * FROM Personas", dataAdapter);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
