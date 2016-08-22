using System;
using System.Data;
using WSClient.services.models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using WSClient.models;
using WSClient.data;
using System.Collections.Generic;
using WSClient.lists;

namespace WSClient.services
{
    class ServicesController
    {
        private JObject autorizacion = WSAutorizacion.getAutorizacion();
        private WSSDTAltaServicio alta = new WSSDTAltaServicio();
        private WSSDTFiltroServicio listar = new WSSDTFiltroServicio();
        private WSSDTZonas zonas = new WSSDTZonas();

        public void altaServicio(Servicio servicio)
        {

            //se crea el json
            dynamic ws = new JObject();

            ws.WSAutorizacion = autorizacion;
            
            List<DataRow> rowList = servicio.getNonProcessedServicios();
            foreach (DataRow row in rowList)
            {

                ws.WSSDTAltaServicio = servicio is Llamados ? alta.getWSSDTAltaServicio(row) : alta.getWSSDTAltaServicioTraslado(row);

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
                        Int32 id = servicio is Llamados ? (Int32)row["llaid"] : (Int32)row["tranro"];
                        Int32 nroServicio = Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio);
                        Int32 nroAsistencia = Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia);

                        servicio.setServicio(id, nroServicio, nroAsistencia);
                    }
                }
                //***********************************************************************************


            }
        }

        public void listarServicio(Servicio servicio)
        {

            //se crea el jason
            dynamic ws = new JObject();

            ws.WSAutorizacion = autorizacion;

            List<DataRow> rowList = servicio.getProcessedServicios();
            foreach (DataRow row in rowList)
            {
                ws.WSSDTFiltroServicio = servicio is Llamados ? listar.getWSSDTFiltroServicio(row) : listar.getWSSDTFiltroServicio(row);

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
                    if (result.WSSDTDatosServicios.Notas == "Los datos han sido actualizados. - ")
                    {
                        //Int32 id = servicio is Llamados ? (Int32)row["llaid"] : (Int32)row["tranro"];
                        //Int32 nroServicio = Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio);
                        //Int32 nroAsistencia = Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia);

                        //servicio.setServicio(id, nroServicio, nroAsistencia);
                    }
                }
                //***********************************************************************************

            }
        }

        public List<Zona> getListaZonas()
        {

            //se crea el jason
            dynamic ws = new JObject();
            zonas.getWSSDTZonas(ref ws);
            ws.WSAutorizacion = autorizacion;

            List<Zona> listZones = new List<Zona>();

            // este pedazo de codigo se puede bajar un nivel o pasar a un metodo auxiliar
            var webAddr = "http://api.logicsat.com/logicsat/rest/WSGetZonas";
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
                listZones = result.WSSDTOutZonas.WSSDTZonas.ToObject<List<Zona>>();
            }
            //***********************************************************************************

            return listZones;
        }

    }
}
