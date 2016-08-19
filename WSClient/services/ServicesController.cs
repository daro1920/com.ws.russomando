﻿using System;
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
        

        public void altaServicio(Llamados llamados)
        {

            //se crea el jason
            dynamic ws = new JObject();

            ws.WSAutorizacion = autorizacion;

            // para usar cuando llamados tenga datos
            foreach (DataRow llamado in llamados.getLlamados())
            {
                ws.WSSDTAltaServicio = alta.getWSSDTAltaServicio(llamado);

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
                        llamados.setLlamados((Int32)llamado["llaid"]);
                    }
                }
                //***********************************************************************************


            }
        }

        public void altaServicio(Traslados traslados)
        {

            //se crea el jason
            dynamic ws = new JObject();

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

            }
        }

        public void listarLlamados(Llamados llamados)
        {

            //se crea el jason
            dynamic ws = new JObject();

            ws.WSAutorizacion = autorizacion;

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

            }



        }

    }
}
