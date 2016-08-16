using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace WSClient.models
{
    class Traslados
    {
        private List<DataRow> rows;

        public Traslados(){
            this.rows = getTraslados();
        }

        public List<DataRow> Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }
        
        public List<DataRow> getTraslados()
        {

            List<DataRow> trasladosList = new List<DataRow>();

            // creo datatable para los llamados
            DataTable traslados = new DataTable();

            OleDbConnection yourConnectionHandler = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=C:\dbf\");

            // Open the connection, and if open successfully, you can try to query it
            yourConnectionHandler.Open();

            if (yourConnectionHandler.State == ConnectionState.Open)
            {
                string sqlTraslados = "select * from traslados";  // dbf table name

                OleDbCommand queryTraslados = new OleDbCommand(sqlTraslados, yourConnectionHandler);
                OleDbDataAdapter DALlamados = new OleDbDataAdapter(queryTraslados);

                DALlamados.Fill(traslados);
                
                foreach (DataRow row in traslados.Rows)
                {
                    trasladosList.Add(row);

                }
                

                yourConnectionHandler.Close();
            }
            return trasladosList;
        }
        
        public void setTraslados(Int32 llaid)
        {
            

            using (OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=C:\Work\FreelanceProjects\RoussoMando\dbf"))
            using (OleDbCommand command = con.CreateCommand())
            {
                command.CommandText = "update traslados set EMPCOD = 155 where LLAID = " + llaid.ToString();
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

        }
        
    }
}
