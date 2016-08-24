using System;
using System.Collections.Generic;
using System.Data;
using WSClient.services.models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using WSClient.models;

namespace WSClient.services
{
    class ServicesController
    {
        private JObject autorizacion = WSAutorizacion.getAutorizacion();
        private WSSDTAltaServicio alta = new WSSDTAltaServicio();
        private WSSDTFiltroServicio listar = new WSSDTFiltroServicio();
        

<<<<<<< HEAD
        public void altaServicio(Llamados llamados)
=======
        private string LIST_ZONES = "http://api.logicsat.com/logicsat/rest/WSGetZonas";
        private string LIST_SERVICE = "http://api.logicsat.com/logicsat/rest/WSGetServicios";
        private string CREATE_CLOSE_SERVICE = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
        
        public void altaServicio(Servicio servicio)
>>>>>>> origin/clienteWs
        {

            //se crea el jason
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;
<<<<<<< HEAD
=======

            dynamic result;
            List<DataRow> rowList = servicio.getNonProcessedServicios();
            foreach (DataRow row in rowList)
            {
>>>>>>> origin/clienteWs

            // para usar cuando llamados tenga datos
            foreach (DataRow llamado in llamados.getLlamados())
            {
                ws.WSSDTAltaServicio = alta.getWSSDTAltaServicio(llamado);

<<<<<<< HEAD
                // este pedazo de codigo se puede bajar un nivel o pasar a un metodo auxiliar
                var webAddr = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(ws.ToString());
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    dynamic result = JObject.Parse(streamReader.ReadToEnd());
                    // actualizados o nuevo OJO
                    if (result.WSSDTDatoNroServicio.Notas == "Los datos han sido actualizados. - ")
                    {
                        llamados.setLlamados((Int32)llamado["llaid"],Convert.ToInt32( result.WSSDTDatoNroServicio.NroServicio), Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia));
                    }
=======
                result = getWSResult(CREATE_CLOSE_SERVICE, ws);
                // actualizados o nuevo OJO
                if (result.WSSDTDatoNroServicio.Notas == "Los datos han sido actualizados. - ")
                {
                    Int32 id = servicio is Llamados ? (Int32)row["llaid"] : (Int32)row["tranro"];
                    Int32 nroServicio = Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio);
                    Int32 nroAsistencia = Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia);

                    servicio.setServicio(id, nroServicio, nroAsistencia);
>>>>>>> origin/clienteWs
                }


            }
        }

        public void altaServicio(Traslados traslados)
        {

            //se crea el jason
            dynamic ws = new JObject();
<<<<<<< HEAD


            ws.WSAutorizacion = autorizacion;

            // para usar cuando llamados tenga datos
            foreach (DataRow traslado in traslados.getTraslados())
            {
                ws.WSSDTAltaServicio = alta.getWSSDTAltaServicio(traslado);

                // este pedazo de codigo se puede bajar un nivel o pasar a un metodo auxiliar
                var webAddr = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(ws.ToString());
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    dynamic result = JObject.Parse(streamReader.ReadToEnd());
                    // actualizados o nuevo OJO
                    if (result.WSSDTDatoNroServicio.Notas == "Los datos han sido actualizados. - ")
                    {
                        traslados.setTraslados((Int32)traslado["llaid"]);
                    }
                }
                //***********************************************************************************
=======
            ws.WSAutorizacion = autorizacion;

            dynamic result;
            List<DataRow> rowList = servicio.getProcessedServicios();
            foreach (DataRow row in rowList)
            {
                ws.WSSDTFiltroServicio = servicio is Llamados ? listar.getWSSDTFiltroServicio(row,"","") : listar.getWSSDTFiltroServicio(row, "", "");

                result = getWSResult(LIST_SERVICE, ws);
>>>>>>> origin/clienteWs

            }
        }

        public void listarLlamados(Llamados llamados)
        {

            //se crea el jason
            dynamic ws = new JObject();

            ws.WSAutorizacion = autorizacion;

<<<<<<< HEAD
            // para usar cuando llamados tenga datos
            foreach (DataRow llamado in llamados.getLlamados())
            {
                ws.WSSDTFiltroServicio = listar.getWSSDTAltaServicio(llamado);

                // este pedazo de codigo se puede bajar un nivel o pasar a un metodo auxiliar
                var webAddr = "http://api.logicsat.com/logicsat/rest/WSGetServicios";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(ws.ToString());
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    dynamic result = JObject.Parse(streamReader.ReadToEnd());
                    // actualizados o nuevo OJO
                    if (result.WSSDTDatoNroServicio.Notas == "Los datos han sido actualizados. - ")
                    {
                        llamados.setLlamados((Int32)llamado["llaid"]);
                    }
                }
                //***********************************************************************************
=======
            dynamic result = getWSResult(LIST_ZONES,ws);
            List<Zona> listZones = result.WSSDTOutZonas.WSSDTZonas.ToObject<List<Zona>>();

            return listZones;
        }

        public void garbageCollLlamados(Servicio servicio)
        {

            //se crea el jason
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;
            
            string dateIni = DateTime.Now.AddDays(-5).ToString("dd'-'MM'-'yyyy HH:mm:ss");
            string dateFin = DateTime.Now.ToString("dd'-'MM'-'yyyy HH:mm:ss");
            
            ws.WSSDTFiltroServicio = listar.getWSSDTFiltroServicio(null, dateIni, dateFin);

            dynamic result = getWSResult(LIST_SERVICE, ws);

            JArray array = result.WSSDTDatosServicios.SDTDatosServicios;
            int lenght = array.Count;

            //se crea el jason
            dynamic wsClose = new JObject();
            wsClose.WSAutorizacion = autorizacion;
            foreach (JObject item in array)
            {

                string id = item["IdExterno"].ToString();

                // los ids con .0 son traslados
                if (id.Contains(".0")) continue;

                List<DataRow> rowList = servicio.getServicio(id);

                if (rowList.Count != 0) continue;

                wsClose.WSSDTAltaServicio = alta.getWSSDTCancelarServicio(id);
                result = getWSResult(CREATE_CLOSE_SERVICE, wsClose);
                Console.WriteLine(result.WSSDTDatoNroServicio.Notas);


            }
        }

        private dynamic getWSResult(string webAddr, dynamic ws)
        {
            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
>>>>>>> origin/clienteWs

            }


            ws.WSAutorizacion = autorizacion;

            // para usar cuando traslado tenga datos
            foreach (DataRow traslado in traslados.getTraslados())
            {
<<<<<<< HEAD
                ws.WSSDTAltaServicio = alta.getWSSDTAltaServicioTraslado(traslado);

                // este pedazo de codigo se puede bajar un nivel o pasar a un metodo auxiliar
                var webAddr = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(ws.ToString());
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    dynamic result = JObject.Parse(streamReader.ReadToEnd());
                    // actualizados o nuevo OJO
                    if (result.WSSDTDatoNroServicio.NroServicio != 0)
                    {
                        // Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio), Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia)
                        traslados.setTraslados((Decimal)traslado["tranro"], Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio), Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia));
                    }
                }
                //***********************************************************************************
=======
                dynamic result = JObject.Parse(streamReader.ReadToEnd());
                return result;
                
>>>>>>> origin/clienteWs
            }
        }
        public void listaServicio()
        {

            //se crea el jason
            dynamic ws = new JObject();

            ws.WSAutorizacion = autorizacion;

            //ws.WSSDTAltaServicio = alta.getWSSDTAltaServicioTraslado(traslado);

            // este pedazo de codigo se puede bajar un nivel o pasar a un metodo auxiliar
            var webAddr = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(ws.ToString());
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    dynamic result = JObject.Parse(streamReader.ReadToEnd());
                    // actualizados o nuevo OJO
                    if (result.WSSDTDatoNroServicio.NroServicio != 0)
                    {
                        // Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio), Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia)
                        //traslados.setTraslados((Decimal)traslado["tranro"], Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio), Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia));
                    }
                }
                //***********************************************************************************
            
        }
    }
}
