using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using WSClient.data;

namespace WSClient.models
{
    class Traslados : Servicio

    {

        public override List<DataRow> getServicio(string id)
        {
            sqlServicio = @"select * from traslados where tranro = " + id + " ";
            return getListServicio();
        }

        public override List<DataRow> getAllServicios()
        {
            sqlServicio = @"select * from traslados ";
            return getListServicio();
        }

        public override List<DataRow> getProcessedServicios()
        {
            sqlServicio = @"select * from traslados where nroserv <> 0 ";
            return getListServicio();
        }

        public override List<DataRow> getNonProcessedServicios()
        {
            sqlServicio = @"select * from traslados where nroserv = 0 ";
            return getListServicio();
        }


        public override void setServicio(Decimal id, int NroServicio, int NroAsistencia)
        {
            using (yourConnectionHandler)
            using (OleDbCommand command = yourConnectionHandler.CreateCommand())
            {
                //nroasis = "+NroAsistencia.ToString()+",nroserv = "+NroServicio.ToString()+"
                command.CommandText = "update traslados set nroasis = " + NroAsistencia.ToString() + ",nroserv = " + NroServicio.ToString() + " where tranro = " + id.ToString();
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
                command.CommandText = "update traslados set tralat = " + lat + ", tralng = " + lng + " where tranro = " + id.ToString();
                yourConnectionHandler.Open();
                command.ExecuteNonQuery();
                yourConnectionHandler.Close();
            }
        }

    }
}
