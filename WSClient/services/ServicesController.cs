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

        private string googleKey = "AIzaSyBcbMVMtS7J6AYXHp-0mz0agcVDhcyuZZg";

        private string EMPTY = "";

        private string LIST_ZONES = "http://api.logicsat.com/logicsat/rest/WSGetZonas";
        private string LIST_SERVICE = "http://api.logicsat.com/logicsat/rest/WSGetServicios";
        private string CREATE_CLOSE_SERVICE = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
        private string GEO_GOOGLE = "https://maps.googleapis.com/maps/api/geocode/json?";

        public void altaServicio(Servicio servicio)
        {

            //se crea el json
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;

            dynamic result;
            List<DataRow> rowList = servicio.getNonProcessedServicios();
            foreach (DataRow row in rowList)
            {

                ws.WSSDTAltaServicio = servicio is Llamados ? alta.getWSSDTAltaServicio(row) : alta.getWSSDTAltaServicioTraslado(row);

                result = getWSResult(CREATE_CLOSE_SERVICE, ws);
                // actualizados o nuevo OJO
                if (result.WSSDTDatoNroServicio.NroServicio != 0)
                {
                    var id = servicio is Llamados ? (Int32)row["llaid"] : (Decimal)row["tranro"];
                    Int32 nroServicio = Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio);
                    Int32 nroAsistencia = Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia);

                    servicio.setServicio(id, nroServicio, nroAsistencia);
                }

            }
        }

        public void listarServicio(Servicio servicio)
        {
            //se crea el jason
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;

            dynamic result;
            List<DataRow> rowList = servicio.getProcessedServicios();
            foreach (DataRow row in rowList)
            {
                //TODO estudiar comportamiento 
                ws.WSSDTFiltroServicio = servicio is Llamados ? listar.getWSSDTFiltroServicio(row, EMPTY, EMPTY, EMPTY) : listar.getWSSDTFiltroServicio(row, EMPTY, EMPTY, EMPTY);

                result = getWSResult(LIST_SERVICE, ws);

                // modificar dbf
                // implementrar en Services Factory, llamados y traslados.
                //servicio.setServicioLatLng(idrw,kdatoo....)
            }
        }

        public List<Zona> getListaZonas()
        {

            //se crea el jason
            dynamic ws = new JObject();
            zonas.getWSSDTZonas(ref ws);
            ws.WSAutorizacion = autorizacion;

            dynamic result = getWSResult(LIST_ZONES, ws);
            List<Zona> listZones = result.WSSDTOutZonas.WSSDTZonas.ToObject<List<Zona>>();

            return listZones;
        }

        public JArray getServicios(Servicio servicio, string estado)
        {
            //se crea el jason
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;

            string dateIni = DateTime.Now.AddDays(-29).ToString("dd'-'MM'-'yyyy HH:mm:ss");
            string dateFin = DateTime.Now.ToString("dd'-'MM'-'yyyy HH:mm:ss");

            ws.WSSDTFiltroServicio = listar.getWSSDTFiltroServicio(null, dateIni, dateFin, estado);

            dynamic result = getWSResult(LIST_SERVICE, ws);

            return result.WSSDTDatosServicios.SDTDatosServicios;


        }

        public void cerrarServicio(Servicio servicio, string estado)
        {

            JArray array = getServicios(servicio, estado);

            //se crea el jason
            dynamic wsClose = new JObject();
            wsClose.WSAutorizacion = autorizacion;

            servicio.finalizarServicio(array);
        }

        public void garbageCollector(Servicio servicio, string estado)
        {

            JArray array = getServicios(servicio, estado);

            //se crea el jason
            dynamic wsClose = new JObject();
            wsClose.WSAutorizacion = autorizacion;

            if (servicio is Llamados)
            {
                garbageCollLlamados(servicio, array, wsClose);
            }
            else
            {
                garbageCollTraslados(servicio, array, wsClose);
            }
        }
        public void garbageCollLlamados(Servicio servicio, JArray array, dynamic wsClose)
        {

            dynamic result = EMPTY;
            foreach (JObject item in array)
            {

                string id = item["IdExterno"].ToString();

                // los ids con .0 son traslados
                if (item["Prestacion"].ToString() != "Llamado") continue;

                List<DataRow> rowList = servicio.getServicio(id);

                if (rowList.Count != 0) continue;

                wsClose.WSSDTAltaServicio = alta.getWSSDTCancelarServicio(id);
                result = getWSResult(CREATE_CLOSE_SERVICE, wsClose);
                Console.WriteLine(result.WSSDTDatoNroServicio.Notas);


            }
        }

        public void garbageCollTraslados(Servicio servicio, JArray array, dynamic wsClose)
        {
            dynamic result = EMPTY;
            foreach (JObject item in array)
            {

                string id = item["IdExterno"].ToString();

                if (item["Prestacion"].ToString() == "Llamado") continue;

                List<DataRow> rowList = servicio.getServicio(id);

                if (rowList.Count != 0) continue;

                wsClose.WSSDTAltaServicio = alta.getWSSDTCancelarServicio(id);
                result = getWSResult(CREATE_CLOSE_SERVICE, wsClose);
                Console.WriteLine(result.WSSDTDatoNroServicio.Notas);


            }
        }

        // este metodo se llamara siempre de llamados ?
        public void getGoogleGeocoding(Servicio servicio)
        {

            List<Coordenadas> cooList = new List<Coordenadas>();

            string num = EMPTY;
            string street = EMPTY;
            string street2 = EMPTY;
            string zone = EMPTY;
            string city = EMPTY;


            string url = GEO_GOOGLE;

            dynamic result;
            List<DataRow> rowList = servicio.getProcessedServicios();
            foreach (DataRow row in rowList)
            {

                string lng =  row["lng"].ToString();
                string lat =  row["lat"].ToString();


                // si tengo valores en los dos campos , no hago nada 
                if (lng != "0.000000" && lat != "0.000000") continue;

                num = row["afinumpar"].ToString();
                zone = EMPTY;//TODO
                city = "Montevideo"; //TODO
                street = row["afiesq1par"].ToString();
                street2 = row["afidompar"].ToString();

                url = GEO_GOOGLE + "address=" + num + "+" + street + "+%26+" + street2 + ",+" + zone + ",+" + city + "&key=" + googleKey + "";
                result = getWSResult(url, EMPTY);

                if (result.status != "OK") continue;


                dynamic location = result.results[0].geometry.location;

                lat = location.lat;
                lng = location.lng;

                string id =  row["llaid"].ToString();

                servicio.setServicioLatLng(id, lat, lng);
                //cooList.Add(coor);

            }

        }



        private dynamic getWSResult(string webAddr, dynamic ws)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string wsString = ws.ToString();

                if (wsString != "")
                {
                    wsString.Substring(1, wsString.Length - 1);
                }
                

                streamWriter.Write(wsString);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                dynamic result = JObject.Parse(streamReader.ReadToEnd());
                return result;

            }
        }
    }
}
