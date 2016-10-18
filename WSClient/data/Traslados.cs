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
            sqlServicio = @"select * from g:\Principal\traslados where tratpo = 11 and tranro = " + id + " ";
            return getListServicio();
        }

        public override List<DataRow> getServiciop(string id)
        {
            //proceso
            sqlServicio = @"select * from g:\Principal\traslados where tratpo = 11 and tranro = " + id + " ";
            return getListServicio();
        }

        public override List<DataRow> getAllServicios()
        {
            sqlServicio = @"select * from g:\Principal\traslados where tratpo = 11 ";
            return getListServicio();
        }

        public override List<DataRow> getProcessedServicios()
        {
            sqlServicio = @"select * from g:\Principal\traslados where  tratpo = 11 and nroserv <> 0 ";
            return getListServicio();
        }

        public override List<DataRow> getNonProcessedServicios()
        {
            sqlServicio = @"select * from g:\Principal\traslados where   tratpo = 11 and nroserv = 0 ";
            return getListServicio();
        }


        public override void setServicio(Decimal id, int NroServicio, int NroAsistencia)
        {

            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            {
                //nroasis = "+NroAsistencia.ToString()+",nroserv = "+NroServicio.ToString()+"

                command.CommandText = @"update g:\Principal\traslados set nroasis = " + NroAsistencia.ToString() + ",nroserv = " + NroServicio.ToString() + " where tranro = " + id.ToString();
                connectionHandler.Open();
                command.ExecuteNonQuery();
                connectionHandler.Close();
            }
        }

        public override void setServicioLatLng(string id, string lat, string lng)
        {

            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            {

                command.CommandText = @"update g:\principal\traslados set tralat = " + lat + ", tralng = " + lng + " where tranro = " + id.ToString();
                connectionHandler.Open();

                command.ExecuteNonQuery();
                connectionHandler.Close();
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

        public override void toProcesServicio(DataRow row, string movil)
        {
            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            {

                command.CommandText = @"update g:\principal\traslados set tramov="+movil+ " where tranro = " + row["TRANRO"];
                connectionHandler.Open();

                command.ExecuteNonQuery();
                connectionHandler.Close();
            }

        }

        private void updateTrasladosR(List<DataRow> rowList)
        {


            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            using (OleDbCommand command2 = connectionHandler.CreateCommand())
            {

                foreach (DataRow row in rowList)
                {
                    command.CommandText = @"insert into g:\principal\trasladosR (TRANRO,TRAFCHING, ENORIGEN,TRAINS,TRAINSDSC,TRAMED,TRAFCH ,TRAORI, TRADES,TRADESF,TRAPAC, " +
                    "TRATEL,TRADOC,TRAEDAD ,TRASEX, TRADIA,TRATPO ,TRATPODSC,TRAOBS,TRAMOV,TRAMOVR,PRONTO ,TRABAS , TRABASR ,TRARES, TRAFCHRES ,TRAFCHRESR  ," +
                    "TRANROFORM,TRAFCHSAL1 ,TRAFCHLLE1,TRAFCHSAL2 ,TRAFCHLLE2 , TRAFCHSAL3 ,TRAFCHLLE3 , TRALIBMOV ,FCHMOD , EMPCOD ,TRAAGENDA,EMPCODTEL ," +
                    "NROASIS,NROSERV, LATORI,LNGORI,ZONAORI,DEP,LATDES,LNGDES,ZONADES,DEPDES,LATDESF,LNGDESF,ZONADESF,DEPDESF) " +
                    " VALUES " +
                    "(" +
                     row["TRANRO"] + ",ctot('" + row["TRAFCHING"] + "'),iif('TRUE'='" + row["ENORIGEN"] + "',.t.,.f.)," + row["TRAINS"] + ",'" + row["TRAINSDSC"] + "','" + row["TRAMED"] + "'," +
                     "ctot('" + row["TRAFCH"] + "'),'" + row["TRAORI"] + "','" + row["TRADES"] + "','" + row["TRADESF"] + "','" + row["TRAPAC"] + "','" + row["TRATEL"] + "'," +
                     row["TRADOC"] + "," + row["TRAEDAD"] + ",'" + row["TRASEX"] + "','" + row["TRADIA"] + "'," + row["TRATPO"] + ",'" + row["TRATPODSC"] + "','" + row["TRAOBS"] + "'," +
                     row["TRAMOV"] + "," + row["TRAMOVR"] + ",ctot('" + row["PRONTO"] + "')," + row["TRABAS"] + "," + row["TRABASR"] + ",'" + row["TRARES"] +","+
                     "ctot('" + row["TRAFCHRES"] + "'),ctot('" + row["TRAFCHRESR"] + "')," + row["TRANROFORM"] + ",ctot('" + row["TRAFCHSAL1"] + "'),ctot('" + row["TRAFCHLLE1"] + "')," +
                     "ctot('" + row["TRAFCHSAL2"] + "'),ctot('" + row["TRAFCHLLE2"] + "'),ctot('" + row["TRAFCHSAL3"] + "'),ctot('" + row["TRAFCHLLE3"] + "'),ctot('" + row["TRALIBMOV"] +"'),"+
                     "ctot('" + row["FCHMOD"] + "')," + row["EMPCOD"] + "," + row["TRAAGENDA"] + "," + row["EMPCODTEL"] + "," + row["EMPCODTEL"] + "," + row["NROASIS"] + "," +
                     row["NROSERV"] + "," + row["LATORI"] + "," + row["LNGORI"] + ",'" + row["ZONAORI"] + "','" + row["DEP"] + "'," + row["LATDES"] + "," +
                     row["LNGDES"] + ",'" + row["ZONADES"] + "','" + row["DEPDES"] + "'," + row["LATDESF"] + "," + row["LNGDESF"] + ",'" + row["ZONADESF"] + "','" + row["DEPDESF"] + "')";

                    command2.CommandText = @"delete from g:\tablaslibres\traslados where TRANRO = " + row["TRANRO"];

                    connectionHandler.Open();
                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    connectionHandler.Close();

                }
            }
        }
    }
}
