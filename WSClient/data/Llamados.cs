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

        public List<DataRow> getLlamados()
        {

            List<DataRow> llamadosList = new List<DataRow>();

            // creo datatable para los llamados
            DataTable llamados = new DataTable();

            OleDbConnection yourConnectionHandler = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=C:\dbf\");

            // Open the connection, and if open successfully, you can try to query it
            yourConnectionHandler.Open();

            if (yourConnectionHandler.State == ConnectionState.Open)
            {
                string sqlLlamados = "select * from llamados";  // dbf table name

                OleDbCommand queryLlamados = new OleDbCommand(sqlLlamados, yourConnectionHandler);
                OleDbDataAdapter DALlamados = new OleDbDataAdapter(queryLlamados);

                DALlamados.Fill(llamados);
                
                foreach (DataRow row in llamados.Rows)
                {
                    llamadosList.Add(row);

                }


                //dataGridView1.DataSource = YourResultSet;
                //dataGridView1.DataBindingComplete();

                yourConnectionHandler.Close();
            }
            return llamadosList;
        }

    }
}
