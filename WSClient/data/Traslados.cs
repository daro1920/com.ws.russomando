using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using WSClient.data;

namespace WSClient.models
{
    class Traslados : Servicio

    {

        public override List<DataRow> getServicio(string id)
        {
            sqlServicio = @"select * from g:\Pricipal\traslados where tranro = " + id + " ";
            return getListServicio();
        }

        public override List<DataRow> getAllServicios()
        {
            sqlServicio = @"select * from g:\Pricipal\traslados ";
            return getListServicio();
        }

        public override List<DataRow> getProcessedServicios()
        {
            sqlServicio = @"select * from g:\Pricipal\traslados where nroserv <> 0 ";
            return getListServicio();
        }

        public override List<DataRow> getNonProcessedServicios()
        {
            sqlServicio = @"select * from g:\Pricipal\traslados where nroserv = 0 ";
            return getListServicio();
        }


        public override void setServicio(Decimal id, int NroServicio, int NroAsistencia)
        {
            using (yourConnectionHandler)
            using (OleDbCommand command = yourConnectionHandler.CreateCommand())
            {
                //nroasis = "+NroAsistencia.ToString()+",nroserv = "+NroServicio.ToString()+"
                command.CommandText = @"update g:\Pricipal\traslados set nroasis = " + NroAsistencia.ToString() + ",nroserv = " + NroServicio.ToString() + " where tranro = " + id.ToString();
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

        public override void finalizarServicio(JArray serviciosFinalizados)
        {


            foreach (JObject servicio in serviciosFinalizados)
            {
                string id = servicio["IdExterno"].ToString();

                if (servicio["Prestacion"].ToString() != "Llamado") continue;

                List<DataRow> rowList = getServicio(id);

                updateTrasladosR(rowList);
            }

        }

        private void updateTrasladosR(List<DataRow> rowList)
        {

            using (yourConnectionHandler)
            using (OleDbCommand command = yourConnectionHandler.CreateCommand())
            {
                foreach (DataRow row in rowList)
                {
                    command.CommandText = "insert into trasladosr (TRANRO,TRAFCHING, ENORIGEN,TRAINS,TRAINSDSC,TRAMED,TRAFCH ,TRAORI, TRADES,TRADESF,TRAPAC,TRATEL,TRADOC,TRAEDAD ,TRASEX, TRADIA,"+
                    "TRATPO ,TRATPODSC,TRAOBS,TRAMOV,TRAMOVR,PRONTO ,TRABAS , TRABASR ,TRARES, TRAFCHRES ,TRAFCHRESR  ,TRANROFORM,TRAFCHSAL1 ,TRAFCHLLE1, "+
                    "TRAFCHSAL2 ,TRAFCHLLE2 , TRAFCHSAL3 ,TRAFCHLLE3 , TRALIBMOV ,FCHMOD , EMPCOD ,TRAAGENDA,EMPCODTEL ,NROASIS,NROSERV, LATORI,LNGORI,"+
                    "ZONAORI,DEP,LATDES,LNGDES,ZONADES,DEPDES,LATDESF,LNGDESF,ZONADESF,DEPDESF) " +
                    " VALUES " +
                    "(" + row["TRANRO"] + "," + row["TRAFCHING"] + "," + row["ENORIGEN"] + "," + row["TRAINS"] + "," + row["TRAINSDSC"] + "," + row["TRAMED"] + "," + row["TRAFCH"] + "," + row["TRAORI"] + "," +
                     row["TRADES"] + "," + row["TRADESF"] + "," + row["TRAPAC"] + "  ," + row["TRATEL"] + " ," + row["TRADOC"] + " ," +
                     row["TRAEDAD"] + " , " + row["TRASEX"] + ", " + row["TRADIA"] + "," + row["TRATPO"] + " ," + row["TRATPODSC"] + "," + row["TRAOBS"] + "," + row["TRAMOV"] + "," +
                     row["TRAMOVR"] + " ," + row["PRONTO"] + " ," + row["TRABAS"] + " ," + row["TRABASR"] + "  ," + row["TRARES"] + "   ," + row["TRAFCHRES"] + " ," +
                     row["TRAFCHRESR"] + "," + row["TRANROFORM"] + " ," + row["TRAFCHSAL1"] + " ," + row["TRAFCHLLE1"] + " , " + row["TRAFCHSAL2"] + " , " + row["TRAFCHLLE2"] + " ," + row["TRAFCHSAL3"] + "," +
                     row["TRAFCHLLE3"] + "," + row["TRALIBMOV"] + "," + row["FCHMOD"] + "," + row["EMPCOD"] + " , " + row["TRAAGENDA"] + "," + row["EMPCODTEL"] + " , " + row["EMPCODTEL"] + ", " +
                     row["NROASIS"] + "," + row["NROSERV"] + " , " + row["LATORI"] + "," + row["LNGORI"] + " ," + row["ZONAORI"] + "  , " + row["LLANROLIN"] + " , " +
                     row["DEP"] + ", " + row["LATDES"] + "," + row["LNGDES"] + " , " + row["ZONADES"] + ", " + row["DEPDES"] + ",  " + row["LATDESF"] + "," + row["LNGDESF"] + " ," +
                     row["ZONADESF"] + ", " + row["DEPDESF"]  + ")";
                    yourConnectionHandler.Open();
                    command.ExecuteNonQuery();
                    yourConnectionHandler.Close();

                }
            }

    }
}
