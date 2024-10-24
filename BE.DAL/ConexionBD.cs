using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BE.DAL
{
    public static class ConexionBD
    {

        //Creo la conexion
        public static void UpdateDataBase(DataTable DT, string selectCommand, SqlDataAdapter DA)
        {
			try
			{
				DT.PrimaryKey = new DataColumn[] { DT.Columns[0] };
				DA.SelectCommand.CommandText =selectCommand;
                SqlCommandBuilder cb = new SqlCommandBuilder(DA);
                DA.DeleteCommand = cb.GetDeleteCommand();
                DA.UpdateCommand = cb.GetUpdateCommand();
                DA.InsertCommand = cb.GetInsertCommand();
                DA.Update(DT);
            }
			catch (Exception)
			{

				throw;
			}
        }


        //Obtengo un DataTable

        public static DataTable GetDataTable(string selectCommand, SqlDataAdapter DA)
        {
            try
            {
                DataTable DT = new DataTable();
                DA.SelectCommand.CommandText = selectCommand;
                DA.Fill(DT);
                return DT;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Obtengo el esquema de la tabla
        public static DataTable GetSchemma(string TableSchamma, SqlDataAdapter DA)
        {
           DataTable DT = new DataTable();
            try
            {
                DA.SelectCommand.CommandText = "SELECT * FROM " + TableSchamma;
                DA.FillSchema(DT, SchemaType.Source);
                return DT;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
