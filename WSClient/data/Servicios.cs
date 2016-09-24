using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.data
{
    abstract class Servicio
    {
        public String sqlServicio { get; set; }
        

        abstract public List<DataRow> getServicio(string id);
        abstract public List<DataRow> getServiciop(string id);
        abstract public List<DataRow> getAllServicios();
        abstract public List<DataRow> getProcessedServicios();
        abstract public List<DataRow> getNonProcessedServicios();
        abstract public void finalizarServicio(JArray serviciosFinalizados);
        abstract public void toProcesServicio(DataRow row, string movil);
        abstract public void setServicioLatLng(string id, string lat, string lng);
        abstract public void setServicio(Decimal id, Int32 NroServicio, Int32 NroAsistencia);

        
        protected OleDbConnection getConnectionHandler()
        {
            return new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=g:\");
        }


        protected List<DataRow> getListServicio()
        {


            DataTable servicios = new DataTable();
            List<DataRow> serviciosList = new List<DataRow>();


            // Open the connection, and if open successfully, you can try to query it
            OleDbConnection connectionHandler = getConnectionHandler();
            connectionHandler.Open();
            
            if (connectionHandler.State == ConnectionState.Open)
            {

                OleDbCommand queryServicio = new OleDbCommand(sqlServicio, connectionHandler);
                OleDbDataAdapter DAServicio = new OleDbDataAdapter(queryServicio);

                DAServicio.Fill(servicios);
                int size  =servicios.Rows.Count;
                foreach (DataRow row in servicios.Rows)
                {
                    serviciosList.Add(row);
                }

                connectionHandler.Close();
            }
            return serviciosList;
        }


    }
}
