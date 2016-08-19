using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.models
{
    class Llamados
    {
        private List<DataRow> rows;

        public Llamados()
        {
            this.rows = getLlamados();
        }



        public List<DataRow> getLlamados()
        {

            List<DataRow> llamadosList = new List<DataRow>();

            // creo datatable para los llamados
            DataTable llamados = new DataTable();

            OleDbConnection yourConnectionHandler = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=g:\");

            // Open the connection, and if open successfully, you can try to query it
            yourConnectionHandler.Open();

            if (yourConnectionHandler.State == ConnectionState.Open)
            {
                string sqlLlamados = @"select * from g:\tablaslibres\llamados where nroserv = 0 ";  // dbf table name

                OleDbCommand queryLlamados = new OleDbCommand(sqlLlamados, yourConnectionHandler);
                OleDbDataAdapter DALlamados = new OleDbDataAdapter(queryLlamados);

                DALlamados.Fill(llamados);

                foreach (DataRow row in llamados.Rows)
                {
                    llamadosList.Add(row);

                }
                

                yourConnectionHandler.Close();
            }
            return llamadosList;
        }
        
        public void setLlamados(Int32 llaid, Int32 NroServicio, Int32 NroAsistencia)
        {

            using (OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=g:\tablaslibres\"))
            using (OleDbCommand command = con.CreateCommand())
            {
                command.CommandText = "update llamados set nroserv = "+NroServicio.ToString()+", nroasis = "+NroAsistencia.ToString()+" where LLAID = "+ llaid.ToString();
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

        }
        
    }
}

