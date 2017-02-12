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
    public class Llamados : Servicio
    {
        public override List<DataRow> getServicio(string id)
        {
            sqlServicio = @"select * from g:\tablaslibres\llamados where LLAID = "+id+" ";
            return getListServicio();
        }

        public override List<DataRow> getServiciop(string id)
        {
            sqlServicio = @"select * from g:\tablaslibres\llamadosp where LLAID = " + id + " ";
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

        public override List<DataRow> getProcessedServiciosById(string id)
        {
            sqlServicio = @"select * from g:\tablaslibres\llamados where nroserv <> 0 AND  LLAID = " + id + " ";
            return getListServicio();
        }

        public override List<DataRow> getNonProcessedServicios()
        {
            sqlServicio = @"select * from g:\tablaslibres\llamados where nroserv = 0 ";
            return getListServicio();
        }

        public override void setServicio(Decimal id, int NroServicio, int NroAsistencia)
        {

            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            {
                command.CommandText = @"update g:\tablaslibres\llamados set nroserv = " + NroServicio.ToString() + ", nroasis = " + NroAsistencia.ToString() + " where LLAID = " + id.ToString();
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
                command.CommandText = @"update g:\tablaslibres\llamados set  nroserv = 0, lat = " + lat + ", lng = " + lng + " where LLAID = " + id.ToString();
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


                List<DataRow> rowList = getServiciop(id);

                updateLlamadosR(rowList, servicio);
            }

        }

        public override void toProcesServicio(DataRow row, string movil, string campoMov)
        {
            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            using (OleDbCommand command2 = connectionHandler.CreateCommand())
            {


                //servicio["Eventos"].[4]
                command.CommandText = @"insert into g:\tablaslibres\llamadosp (LLAID,AFIID, LLANOM, LLAFCH," +
                "LLAEDAD,LLADOM,DIACOD, DIANOM, LLATEL,LLACLAINI, MOVCODLLA ,EMPCODMED , LLANROHIS, LLAHORCOM " +
                ", LLAHORSAL, LLAHORLLE,LLAHORFIN," +
                "MOVCODAPO,EMPCODMEDA,LLAHORCOMA ,LLAHORSALA  ,LLAHORLLEA ,LLAHORFINA " +
                ", MOVCODTRA ,LLAHORSALT  ,LLAHORLLET ,LLAHORFINT,LLADESTRA, DIACODFIN," +
                " LLAOBS, LLACLAFIN, LLADEM, DIAPRE1, DIAPRE2, DIAPRE3, DIAPRE4, DIAPRE5, " +
                " LLACLATEL, EMPCODTEL, LLATPO, FCHMOD, EMPCOD, LLANROCONF, LLADESTLLA," +
                "LLADESTAPO, LLANROLIN, CONCOD, AFICTA, AFIDOMPAR, LOCCODPAR, AFINUMPAR, AFIBLOPAR, AFIAPTOPAR, AFISENPAR, AFISUBCPAR, AFISUBNPAR, AFIESQ1PAR, AFIESQ2PAR," +
                " PRIORIDAD, PRIOCONV  , EMPCODENF, EMPCODCHO, RECLAMOS, NROASIS, NROSERV, LAT, LNG, ZONA, DEP,TIPO,CONVENIO)" +
                " VALUES " +
                "(" + row["LLAID"] + "," + row["AFIID"] + ",'" + row["LLANOM"] + "',ctot('" + row["LLAFCH"] + "')," + row["LLAEDAD"] + ",'" + row["LLADOM"] + "'," + row["DIACOD"] + ",'" + row["DIANOM"] + "','" +
                row["LLATEL"] + "','" + row["LLACLAINI"] + "'," + movil + "," + row["EMPCODMED"] + "," + row["LLANROHIS"] + ",ctot('" + row["LLAHORCOM"] + "'),ctot('" + row["LLAHORSAL"] + "'),ctot('" + row["LLAHORLLE"] + "'),ctot('" + row["LLAHORFIN"] + "')," +
                "" + row["MOVCODAPO"] + "," + row["EMPCODMEDA"] + ",datetime(),ctot('" + row["LLAHORSALA"] + "'),ctot('" + row["LLAHORLLEA"] + "'),ctot('" + row["LLAHORFINA"] + "')" +
                "," + row["MOVCODTRA"] + ",ctot('" + row["LLAHORSALT"] + "'),ctot('" + row["LLAHORLLET"] + "'),ctot('" + row["LLAHORFINT"] + "'),'" + row["LLADESTRA"] + "'," + row["DIACODFIN"] + ", '" +
                row["LLAOBS"] + "', " + row["LLACLAFIN"] + " , " + row["LLADEM"] + ",iif('TRUE'='" + row["DIAPRE1"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE2"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE3"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE4"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE5"] + "',.t.,.f.) , '" +
                row["LLACLATEL"] + "'," + row["EMPCODTEL"] + " ,'" + row["LLATPO"] + "',ctot('" + row["FCHMOD"] + "'),1 ,'" + row["LLANROCONF"] + "','" + row["LLADESTLLA"] + "'," +
                "'" + row["LLADESTAPO"] + "', " + row["LLANROLIN"] + " , " + row["CONCOD"] + ", " + row["AFICTA"] + ",'" + row["AFIDOMPAR"] + "', " + row["LOCCODPAR"] + ",'" + row["AFINUMPAR"] + "','" + row["AFIBLOPAR"] + "','" + row["AFIAPTOPAR"] + "','" +
                row["AFISENPAR"] + "','" + row["AFISUBCPAR"] + "','" + row["AFISUBNPAR"] + "','" + row["AFIESQ1PAR"] + "','" + row["AFIESQ2PAR"] + "', " +
                row["PRIORIDAD"] + "," + row["PRIOCONV"] + "," + row["EMPCODENF"] + ", " + row["EMPCODCHO"] + ", " + row["RECLAMOS"] + "," + row["NROASIS"] + "  ," + row["NROSERV"] + " , " +
                row["LAT"] + "," + row["LNG"] + " ,'" + row["ZONA"] + "','" + row["DEP"] + "','" + row["TIPO"] + "','" + row["CONVENIO"] + "')";

                command2.CommandText = @"delete from g:\tablaslibres\llamados where llaid = " + row["LLAID"];

                connectionHandler.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                connectionHandler.Close();

            }
        }


        private void updateLlamadosR(List<DataRow> rowList,JObject servicio)
        {
            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            using (OleDbCommand command2 = connectionHandler.CreateCommand())
            {
                foreach (DataRow row in rowList)
                {

                    //evalueo paramentos 0
                    string clavefinal="";
                    string obs="";

                    string p0 = (string)servicio["Eventos"][4]["EventoParametros"][0]["Parametro"];
                    if (p0=="Clave") { 
                        clavefinal = (string)servicio["Eventos"][4]["EventoParametros"][0]["Valor"];
                    }
                    if (p0 == "Obs.")
                    {
                        obs = (string)servicio["Eventos"][4]["EventoParametros"][0]["Valor"];
                    }

                    string p1 = (string)servicio["Eventos"][4]["EventoParametros"][1]["Parametro"];
                    if (p1 == "Clave")
                    {
                        clavefinal = (string)servicio["Eventos"][4]["EventoParametros"][1]["Valor"];
                    }
                    if (p1 == "Obs.")
                    {
                        obs = (string)servicio["Eventos"][4]["EventoParametros"][1]["Valor"];
                    }

                    string p2 = (string)servicio["Eventos"][4]["EventoParametros"][2]["Parametro"];
                    if (p2 == "Clave")
                    {
                        clavefinal = (string)servicio["Eventos"][4]["EventoParametros"][2]["Valor"];
                    }
                    if (p2 == "Obs.")
                    {
                        obs = (string)servicio["Eventos"][4]["EventoParametros"][2]["Valor"];
                    }

                    command.CommandText = @"insert into g:\principal\llamadosR (LLAID,AFIID, LLANOM, LLAFCH," +
                    "LLAEDAD,LLADOM,DIACOD, DIANOM, LLATEL,LLACLAINI, MOVCODLLA ,EMPCODMED , LLANROHIS, LLAHORCOM " +
                    ", LLAHORSAL, LLAHORLLE,LLAHORFIN," +
                    "MOVCODAPO,EMPCODMEDA,LLAHORCOMA ,LLAHORSALA  ,LLAHORLLEA ,LLAHORFINA " +
                    ", MOVCODTRA ,LLAHORSALT  ,LLAHORLLET ,LLAHORFINT,LLADESTRA, DIACODFIN," +
                    " LLAOBS, LLACLAFIN, LLADEM, DIAPRE1, DIAPRE2, DIAPRE3, DIAPRE4, DIAPRE5, " +
                    " LLACLATEL, EMPCODTEL, LLATPO, FCHMOD, EMPCOD, LLANROCONF, LLADESTLLA," +
                    "LLADESTAPO, LLANROLIN, CONCOD, AFICTA, AFIDOMPAR, LOCCODPAR, AFINUMPAR, AFIBLOPAR, AFIAPTOPAR, AFISENPAR, AFISUBCPAR, AFISUBNPAR, AFIESQ1PAR, AFIESQ2PAR," +
                    " PRIORIDAD, PRIOCONV  , EMPCODENF, EMPCODCHO, RECLAMOS, NROASIS, NROSERV, LAT, LNG, ZONA, DEP)" +
                    " VALUES " +
                    "(" + row["LLAID"] + "," + row["AFIID"] + ",'" + row["LLANOM"] + "',ctot('" + row["LLAFCH"] + "')," + row["LLAEDAD"] + ",'" + row["LLADOM"] + "'," + row["DIACOD"] + ",'" + row["DIANOM"] + "','" +
                    row["LLATEL"] + "','" + row["LLACLAINI"] + "'," + row["MOVCODLLA"] + "," + row["EMPCODMED"] + "," + row["LLANROHIS"] + ",ctot('" + row["LLAHORCOM"] + "'),ctot('" + row["LLAHORSAL"] + "'),ctot('" + row["LLAHORLLE"] + "'),ctot('" + row["LLAHORFIN"] + "')," +
                    "" + row["MOVCODAPO"] + "," + row["EMPCODMEDA"] + ",ctot('" + row["LLAHORCOMA"] + "'),ctot('" + row["LLAHORSALA"] + "'),ctot('" + row["LLAHORLLEA"] + "'),ctot('" + row["LLAHORFINA"] + "')" +
                    "," + row["MOVCODTRA"] + ",ctot('" + row["LLAHORSALT"] + "'),ctot('" + row["LLAHORLLET"] + "'),ctot('" + row["LLAHORFINT"] + "'),'" + row["LLADESTRA"] + "',1000, '" +
                    obs.ToUpper() + "', " + clavefinal.Substring(0,1) + " , " + row["LLADEM"] + ",iif('TRUE'='" + row["DIAPRE1"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE2"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE3"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE4"] + "',.t.,.f.),iif('TRUE'='" + row["DIAPRE5"] + "',.t.,.f.) , '" +
                    row["LLACLATEL"] + "'," + row["EMPCODTEL"] + " ,'" + row["LLATPO"] + "',ctot('" + row["FCHMOD"] + "')," + row["EMPCOD"] + " ,'" + row["LLANROCONF"] + "','" + row["LLADESTLLA"] + "'," +
                    "'" + row["LLADESTAPO"] + "', " + row["LLANROLIN"] + " , " + row["CONCOD"] + ", " + row["AFICTA"] + ",'" + row["AFIDOMPAR"] + "', " + row["LOCCODPAR"] + ",'" + row["AFINUMPAR"] + "','" + row["AFIBLOPAR"] + "','" + row["AFIAPTOPAR"] + "','" +
                    row["AFISENPAR"] + "','" + row["AFISUBCPAR"] + "','" + row["AFISUBNPAR"] + "','" + row["AFIESQ1PAR"] + "','" + row["AFIESQ2PAR"] + "', " +
                    row["PRIORIDAD"] + "," + row["PRIOCONV"] + "," + row["EMPCODENF"] + ", " + row["EMPCODCHO"] + ", " + row["RECLAMOS"] + "," + row["NROASIS"] + "  ," + row["NROSERV"] + " , " +
                    row["LAT"] + "," + row["LNG"] + " ,'" + row["ZONA"] + "','" + row["DEP"] + "')";

                    command2.CommandText = @"delete from g:\tablaslibres\llamadosp where llaid = " + row["LLAID"];

                    connectionHandler.Open();
                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    connectionHandler.Close();

                }

            }
        }
    }
}

