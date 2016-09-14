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
                command.CommandText = @"update g:\tablaslibres\llamados set lat = " + lat + ", lng = " + lng + " where LLAID = " + id.ToString();
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

                updateLlamadosR(rowList);
            }
            
        }

        private void updateLlamadosR(List<DataRow> rowList)
        {
            OleDbConnection connectionHandler = getConnectionHandler();

            using (connectionHandler)
            using (OleDbCommand command = connectionHandler.CreateCommand())
            {
                foreach (DataRow row in rowList)
                {
                    command.CommandText = "insert into llamadosR (LLAID,AFIID,  LLANOM, LLAFCH,LLAEDAD,LLADOM,DIACOD, DIANOM, LLATEL,LLACLAINI, MOVCODLLA ,EMPCODMED , LLANROHIS," +
                    "LLAHORCOM , LLAHORSAL, LLAHORLLE,LLAHORFIN ,MOVCODAPO,EMPCODMEDA,LLAHORCOMA ,LLAHORSALA  ,LLAHORLLEA ,LLAHORFINA , MOVCODTRA ,LLAHORSALT  ,LLAHORLLET ,LLAHORFINT," +
                    "LLADESTRA , DIACODFIN, LLAOBS, LLACLAFIN, LLADEM ,DIAPRE1,DIAPRE2,DIAPRE3,DIAPRE4, DIAPRE5, LLACLATEL, EMPCODTEL, LLATPO, FCHMOD, EMPCOD, LLANROCONF, LLADESTLLA," +
                    "LLADESTAPO, LLANROLIN, CONCOD, AFICTA, AFIDOMPAR, LOCCODPAR, AFINUMPAR, AFIBLOPAR, AFIAPTOPAR, AFISENPAR, AFISUBCPAR, AFISUBNPAR, AFIESQ1PAR, AFIESQ2PAR, PRIORIDAD," +
                    "PRIOCONV  , EMPCODENF, EMPCODCHO, RECLAMOS, TIPO, CONVENIO, NROASIS, NROSERV, LAT, LNG, ZONA, DEP) "+
                    " VALUES "+
                    "("+ row["LLAID"]+ "," + row["AFIID"] + ",'" + row["LLANOM"] + "','" + row["LLAFCH"] + "',"+row["LLAEDAD"]+ ",'" + row["LLADOM"] + "','" + row["DIACOD"] + ",'" + row["DIANOM"] + "','"+
                     row["LLATEL"] + "','"+ row["LLACLAINI"] + "'," + row["MOVCODLLA"] + "  ," + row["EMPCODMED"] + " ," + row["LLANROHIS"] + " ," +
                     row["LLAHORCOM"] + " , "+row["LLAHORSAL"] + ", " + row["LLAHORLLE"] + "," + row["LLAHORFIN"] + " ," + row["MOVCODAPO"] + "," + row["EMPCODMEDA"] + "," + row["LLAHORCOMA"] + ","+
                     row["LLAHORSALA"] + " ," + row["LLAHORLLEA"] + " ," + row["LLAHORFINA"] + " ," + row["MOVCODTRA"] + "  ," + row["LLAHORSALT"] + "   ," + row["LLAHORLLET"] + " ,"+
                     row["LLAHORFINT"] + ",'" + row["LLADESTRA"] + "'," + row["DIACODFIN"] + " ,'" + row["LLAOBS"] + "', " + row["LLACLAFIN"] + " , " + row["LLADEM"] + " ," + row["DIAPRE1"] + ","+
                     row["DIAPRE2"] + "," + row["DIAPRE3"] + "," + row["DIAPRE4"] + "," + row["DIAPRE5"] + " , " + row["LLACLATEL"] + "," + row["EMPCODTEL"] + " ,'" + row["LLATPO"] + "', "+
                     row["FCHMOD"] + "," + row["EMPCOD"] + " ,'" + row["LLANROCONF"] + "','" + row["LLADESTLLA"] + "','" + row["LLADESTAPO"] + "', " + row["LLANROLIN"] + " , "+
                     row["CONCOD"] + ", " + row["AFICTA"] + ",'" + row["AFIDOMPAR"] + "', " + row["LOCCODPAR"] + ",'" + row["AFINUMPAR"] + "','" + row["AFIBLOPAR"] + "','" + row["AFIAPTOPAR"] + "','"+
                     row["AFISENPAR"] + "','" + row["AFISUBCPAR"] + "','" + row["AFISUBNPAR"] + "','" + row["AFIESQ1PAR"] + "','" + row["AFIESQ2PAR"] + "', " + row["PRIORIDAD"] + "," + row["PRIOCONV"] + ","+
                     row["EMPCODENF"] + ", " + row["EMPCODCHO"] + ", " + row["RECLAMOS"] + ",'" + row["TIPO"] + "','" + row["CONVENIO"] + "'," + row["NROASIS"] + "  ," + row["NROSERV"] + " , "+
                     row["LAT"] + "," + row["LNG"] + " ,'" + row["ZONA"] + "','" + row["DEP"] + "')";
                    connectionHandler.Open();
                    command.ExecuteNonQuery();
                    connectionHandler.Close();

                }
                
            }
        }
    }
}

