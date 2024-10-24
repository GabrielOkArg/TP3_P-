using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.BE;
using System.Data;
using System.Data.SqlClient;

namespace BE.DAL
{
    public class MapperRangos : Imapper<Rango>
    {

        private SqlDataAdapter dataAdapter;
        public MapperRangos(string myconectionString)
        {
            string error = "";
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * FROM Rangos", myconectionString);
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
        public void Delete(Rango entity)
        {
            throw new NotImplementedException();
        }

        public Rango FindById(int id)
        {
            DataTable dt = new DataTable();
            dt= ConexionBD.GetDataTable("SELECT * FROM Rangos WHERE Id = " + id, dataAdapter);
            if (dt.Rows.Count > 0)
            {
                Rango rango = new Rango();
                rango.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                rango.Nombre = dt.Rows[0]["Nombre"].ToString();
                return rango;
            }
            return null;
        }

        public List<Rango> GetAll()
        {
            List<Rango> listado = new List<Rango>();
            DataTable dt = new DataTable();
            dt = ConexionBD.GetDataTable("SELECT * FROM Rangos", dataAdapter);
            foreach (DataRow item in dt.Rows)
            {
                Rango rango = new Rango();
                rango.Id = Convert.ToInt32(item["Id"]);
                rango.Nombre = item["Nombre"].ToString();
                listado.Add(rango);
            }
            return listado;
        }

        public void Insert(Rango entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Rango entity)
        {
            throw new NotImplementedException();
        }
    }
}
