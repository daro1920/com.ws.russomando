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

            // creo datatable para los traslados
            DataTable traslados = new DataTable();

            OleDbConnection yourConnectionHandler = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=g:\Principal\");

            // Open the connection, and if open successfully, you can try to query it
            yourConnectionHandler.Open();

            if (yourConnectionHandler.State == ConnectionState.Open)
            {
                // traslados sin syncronizar
                string sqlTraslados = "select * from traslados where nroserv = 0 ";  // dbf table name

                OleDbCommand queryTraslados = new OleDbCommand(sqlTraslados, yourConnectionHandler);
                OleDbDataAdapter DATraslados = new OleDbDataAdapter(queryTraslados);

                DATraslados.Fill(traslados);
                
                foreach (DataRow row in traslados.Rows)
                {
                    trasladosList.Add(row);

                }
                

                yourConnectionHandler.Close();
            }
            return trasladosList;
        }
        
        public void setTraslados(Decimal tranro, int NroServicio, int NroAsistencia)
        //
        {


            using (OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=g:\Principal\"))
            using (OleDbCommand command = con.CreateCommand())
            {
                //nroasis = "+NroAsistencia.ToString()+",nroserv = "+NroServicio.ToString()+"
                command.CommandText = "update traslados set nroasis = " + NroAsistencia.ToString() + ",nroserv = " + NroServicio.ToString() + " where tranro = " + tranro.ToString();
                con.Open(); 
                command.ExecuteNonQuery();
                con.Close();
            }

        }
        
    }
}
