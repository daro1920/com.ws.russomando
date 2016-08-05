﻿using System;
using System.Collections.Generic;
using System.Data;
using WSClient.services.models;
using System.Web.Script.Serialization;
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

        public String altaServicio(Llamados llamados)
        {
            String result = "";
            
            //se crea el jason
            dynamic ws = new JObject();
            ws.WSSDTAltaServicio = alta.getWSSDTAltaServicio(null);
            ws.WSAutorizacion = autorizacion;

            // para usar cuando llamados tenga datos
            //foreach (DataRow llamado in llamados.rows)
            //{
            //    alta = new WSSDTAltaServicio(llamado);

            //}

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
                result = streamReader.ReadToEnd();
            }
            //***********************************************************************************

            return result;
        }

    }
}
