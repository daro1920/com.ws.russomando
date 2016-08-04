using System;
using System.Collections.Generic;
using System.Data;
using WSClient.services.models;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace WSClient.services
{
    class ServicesController
    {
        private JavaScriptSerializer seralizer = new JavaScriptSerializer();

        public void altaServicio(List<DataRow> llamados)
        {
            
            WSAutorizacion autorizacion = WSAutorizacion.getAutorizacion();
            WSSDTAltaServicio alta = new WSSDTAltaServicio(null);

            String jsonAut= new JavaScriptSerializer().Serialize(autorizacion);
            String jsonAlta = new JavaScriptSerializer().Serialize(alta);

            //se crea el jason
            dynamic ws = new JObject();
            ws.WSSDTAltaServicio = jsonAlta;
            ws.WSAutorizacion = jsonAut;
            //foreach (DataRow llamado in llamados)
            //{
            //    alta = new WSSDTAltaServicio(llamado);

            //}

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
                var result = streamReader.ReadToEnd();
            }


        }

    }
}
