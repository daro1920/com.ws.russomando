using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSClient.data;

namespace WSClient.models
{
    class Llamados : Servicio
    {
        public override List<DataRow> getServicio(string id)
        {
            sqlServicio = @"select * from g:\tablaslibres\llamados where LLAID = "+id+" ";
            return getListServicio();
        }

        public override List<DataRow> getAllServicios()
        {
            sqlServicio = @"select * from g:\tablaslibres\llamados ";
            return getListServicio();
        }
        
        public override List<DataRow> getProcessedServicios()
        {
            sqlServicio = @"select * from g:\tablaslibres\llamados where nroserv <> 0 ";
            return getListServicio();
        }

        public override List<DataRow> getNonProcessedServicios()
        {
            sqlServicio = @"select * from g:\tablaslibres\llamados where nroserv = 0 ";
            return getListServicio();
        }

        public override void setServicio(Decimal id, int NroServicio, int NroAsistencia)
        {
            using (yourConnectionHandler)
            using (OleDbCommand command = yourConnectionHandler.CreateCommand())
            {
                command.CommandText = @"update g:\tablaslibres\llamados set nroserv = " + NroServicio.ToString() + ", nroasis = " + NroAsistencia.ToString() + " where LLAID = " + id.ToString();
                yourConnectionHandler.Open();
                command.ExecuteNonQuery();
                yourConnectionHandler.Close();
            }
        }

        public override void setServicioLatLng(string id, string lat, string lng)
        {
            using (yourConnectionHandler)
            using (OleDbCommand command = yourConnectionHandler.CreateCommand())
            {
                command.CommandText = @"update g:\tablaslibres\llamados set lat = " + lat + ", lng = " + lng + " where LLAID = " + id.ToString();
                yourConnectionHandler.Open();
                command.ExecuteNonQuery();
                yourConnectionHandler.Close();
            }
        }
    }
}

