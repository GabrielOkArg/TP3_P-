using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.BE;
using System.Data;
using System.Data.SqlClient;

namespace BE.DAL
{
    public class MapperCategoria : Imapper<Categoria>
    {

        private SqlDataAdapter dataAdapter;
        public MapperCategoria(string myconectionString)
        {
            string error = "";
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * FROM Categorias", myconectionString);
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
        public void Delete(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public Categoria FindById(int id)
        {
            DataTable dataTable = new DataTable();
            dataTable = ConexionBD.GetDataTable("SELECT * FROM Categorias WHERE Id = " + id, dataAdapter);
            if (dataTable.Rows.Count > 0)
            {
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                categoria.Nombre = dataTable.Rows[0]["Nombre"].ToString();
                return categoria;
            }
            return null;
        }

        public List<Categoria> GetAll()
        {
            List<Categoria> listado = new List<Categoria>();
            DataTable dt = new DataTable();
            dt = ConexionBD.GetDataTable("SELECT * FROM Categorias", dataAdapter);
            foreach (DataRow item in dt.Rows)
            {
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(item["Id"]);
                categoria.Nombre = item["Nombre"].ToString();
                listado.Add(categoria);
            }
            return listado;
        }

        public void Insert(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
