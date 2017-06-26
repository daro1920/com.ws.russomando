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
using WSClient.enums;

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
            String serv = servicio is Llamados ? "llamados" : "traslados";
            Program.log.Debug("altaServicio : Procesando " + serv);

            //se crea el json
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;

            //try
            //{
                List<DataRow> rowList = servicio.getNonProcessedServicios();
                foreach (DataRow row in rowList)
                {

                    if (servicio is Llamados)
                    {
                        ws.WSSDTAltaServicio = alta.getWSSDTAltaServicio(row);
                        setServicio(servicio, ws, row);

                    }
                    else
                    {
                        if (row["trades"].ToString().Trim() == "")
                        {
                            // traslado solo de IDA 
                            ws.WSSDTAltaServicio = alta.getWSSDTAltaServicioTraslado(row, row["traori"], row["tradesf"], null,0.0);
                            setServicio(servicio, ws, row);
                        }
                        else
                        {
                            //traslado IDA
                            ws.WSSDTAltaServicio = alta.getWSSDTAltaServicioTraslado(row, row["traori"], row["trades"], null,0.1);
                            setServicio(servicio, ws, row);



                            //traslado Vuelta si tiene el Pronto
                            if (row["Pronto"].ToString().Trim()!= "12/30/1899 12:00:00 AM") { 
                               ws.WSSDTAltaServicio = alta.getWSSDTAltaServicioTraslado(row, row["trades"], row["tradesf"], row["tranro"],0.0);
                                setServicio(servicio, ws, row);

                        }
                    }

                    }

                }

            //}
            //catch (Exception e)
            //{
            //    Program.log.Error("Error en Alta de servicios " + serv+" " + e);
            //}
            
        }
        private void setServicio(Servicio servicio, dynamic ws, DataRow row)
        {
            String serv = servicio is Llamados ? "llamados" : "traslados";
            Program.log.Debug("setServicio : Procesando " + serv);
            dynamic result = EMPTY;
            //try
            //{
                result = getWSResult(CREATE_CLOSE_SERVICE, ws);
                // actualizados o nuevo OJO
                //if (result != EMPTY && result.WSSDTDatoNroServicio.NroServicio != 0)
                if ( result.WSSDTDatoNroServicio.NroServicio != 0)
                {
                    var id = servicio is Llamados ? (Int32)row["llaid"] : (Decimal)row["tranro"];
                    Int32 nroServicio = Convert.ToInt32(result.WSSDTDatoNroServicio.NroServicio);
                    Int32 nroAsistencia = Convert.ToInt32(result.WSSDTDatoNroServicio.NroAsistencia);

                    servicio.setServicio(id, nroServicio, nroAsistencia);
                }
            //}
            //catch (Exception e)
            //{
            //    Program.log.Error("Error Creando servicios " + serv+" " + e);
            //}
            
        }

        //public void listarServicio(Servicio servicio)
        //{
        //    String campoMov = "";
        //    String serv = servicio is Llamados ? "llamados" : "traslados";
        //    if (servicio is Llamados) Program.log.Debug("listarServicio Llamados: Procesando " + serv);
        //    if (servicio is Traslados) Program.log.Debug("listarServicio Traslados: Procesando " + serv);
        //    //se crea el jason
        //    dynamic ws = new JObject();
        //    ws.WSAutorizacion = autorizacion;

        //    dynamic result;
        //    try
        //    {
        //        List<DataRow> rowList = servicio.getProcessedServicios();
        //        foreach (DataRow row in rowList)
        //        {
        //            //TODO estudiar comportamiento Por cada registro de llamados.dbf 
        //            if (servicio is Llamados)
        //            {
        //                ws.WSSDTFiltroServicio = listar.getWSSDTFiltroServicio(row["llaid"].ToString(), EMPTY, EMPTY, EstadosEnum.EN_CAMINO);
        //            }
        //            else
        //            {
        //                if (row["trades"].ToString().Trim() == "")
        //                {
        //                    //solo ida
        //                    campoMov = "tramov";
        //                    ws.WSSDTFiltroServicio = listar.getWSSDTFiltroServicio(row["tranro"].ToString(), EMPTY, EMPTY, EstadosEnum.EN_CAMINO);
        //                }
        //                else
        //                {
        //                    // ida y vuelta
        //                    if (row["Pronto"].ToString().Trim() != "12/30/1899 12:00:00 AM") {
        //                        //vuelta (tiene el pronto)
        //                        // no le tengo que tocar el id
        //                        campoMov = "tramovr";
        //                        ws.WSSDTFiltroServicio = listar.getWSSDTFiltroServicio(row["tranro"].ToString()+".0", EMPTY, EMPTY, EstadosEnum.EN_CAMINO);
        //                    }
        //                    else
        //                    {
        //                        // en el ida, le tengo que agregar el .1 para encontrarlo.
        //                        campoMov = "tramov";
        //                        double idExt = double.Parse(row["tranro"].ToString()) + 0.1;
        //                        ws.WSSDTFiltroServicio = listar.getWSSDTFiltroServicio(idExt.ToString(), EMPTY, EMPTY, EstadosEnum.EN_CAMINO);
        //                    }
        //                }

        //            }


        //            if (servicio is Traslados)
        //            {
        //                if (row["tranro"].ToString().Trim() == "166088")
        //                {
        //                   Program.log.Error("ese");
        //                }
        //            }

        //            // los datos del ws 
        //            result = getWSResult(LIST_SERVICE, ws);

        //            //if (result == EMPTY || result.status != "OK") continue;
        //            if (result== null) continue;
        //            // modificar dbf
        //            // implementrar en Services Factory, llamados y traslados.
        //            if ((String)result.WSSDTDatosServicios.Error != "No se encontraron registros que cumplan con los filtros ingresados")
        //            {
        //                servicio.toProcesServicio(row, (String)result["WSSDTDatosServicios"]["SDTDatosServicios"][0]["Movil"],campoMov);
        //            }

        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        Program.log.Error("Error en Listar Servicios " + serv+" " + e);
        //    }
        //    if (servicio is Llamados) Program.log.Debug("listarServicio Llamados: Fin" + serv);
        //    if (servicio is Traslados) Program.log.Debug("listarServicio Traslados: Fin" + serv);

        //}


        public void listarServicio(Servicio servicio)
        {

            Boolean isLLamado = servicio is Llamados;

            //se crea el jason
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;

            JArray services = getServicios(servicio, EstadosEnum.EN_CAMINO);
            
            foreach (JObject service in services)
            {
                string id = service["IdExterno"].ToString();

                List<DataRow> rowList = servicio.getProcessedServicios(id);

                if (rowList.Count == 0) continue;
                
                String campoMov = isLLamado ? "" : (id.Contains(".0") ? "tramovr" : "tramov");

                servicio.toProcesServicio(rowList[0], (String)service["WSSDTDatosServicios"]["SDTDatosServicios"][0]["Movil"], campoMov);
            }


    }
        public List<Zona> getListaZonas()
        {

            //se crea el jason
            dynamic ws = new JObject();
            zonas.getWSSDTZonas(ref ws);
            ws.WSAutorizacion = autorizacion;

            List<Zona> listZones = new List<Zona>();
            try
            {

                dynamic result = getWSResult(LIST_ZONES, ws);
                if (result != null )
                {
                    Program.log.Info("getListaZonas ");
                    listZones = result.WSSDTOutZonas.WSSDTZonas.ToObject<List<Zona>>();
                    
                }else{Program.log.Info("getListaZonas vacio ");}
            }
            catch (Exception e)
            {
                Program.log.Error("Error en listado de zonas" + e);
            }

            return listZones;


        }

        public JArray getServicios(Servicio servicio, string estado)
        {
            //se crea el jason
            dynamic ws = new JObject();
            ws.WSAutorizacion = autorizacion;
            JArray servArray = new JArray();
            try
            {
                string dateIni = DateTime.Now.AddDays(-1).ToString("dd'-'MM'-'yyyy HH:mm:ss");
                string dateFin = DateTime.Now.ToString("dd'-'MM'-'yyyy HH:mm:ss");

                ws.WSSDTFiltroServicio = listar.getWSSDTFiltroServicio(null, dateIni, dateFin, estado);

                dynamic result = getWSResult(LIST_SERVICE, ws);

                if (result != null )
                {
                    Program.log.Info("getServicios ");
                    servArray =  result.WSSDTDatosServicios.SDTDatosServicios;

                }else{Program.log.Info("getServicios vacio ");}
            }
            catch (Exception e)
            {
                Program.log.Error("Error en Obtener Servicios " + e);
            }

            return servArray;

        }

        public void cerrarServicio(Servicio servicio, string estado)
        {
            String serv = servicio is Llamados ? "llamados" : "traslados";
            try
            {
                JArray array = getServicios(servicio, estado);
               
                servicio.finalizarServicio(array);
            }
            catch (Exception e)
            {
                Program.log.Error("Error al cerrar servicio " + serv +" "+ e);
            }

           
        }

        public void garbageCollector(Servicio servicio, string estado)
        {

            //se crea el jason
            dynamic wsClose = new JObject();
            wsClose.WSAutorizacion = autorizacion;

            JArray array = getServicios(servicio, estado);
           
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
            String serv = servicio is Llamados ? "llamados" : "traslados";
            try
            {
                foreach (JObject item in array)
                {

                    string id = item["IdExterno"].ToString();

                    // los ids con .0 son traslados
                    if (item["Prestacion"].ToString() != "Llamado") continue;

                    List<DataRow> rowList = servicio.getServicio(id);
                    List<DataRow> rowListp = servicio.getServiciop(id);

                    if (rowList.Count != 0 || rowListp.Count != 0) continue;

                    wsClose.WSSDTAltaServicio = alta.getWSSDTCancelarServicio(id);
                    result = getWSResult(CREATE_CLOSE_SERVICE, wsClose);

                    if (result == null ) continue;

                    Program.log.Info("Garbage Collector Llamados, notas: " + result.WSSDTDatoNroServicio.Notas);

                }
            }
            catch (Exception e)
            {
                Program.log.Error("Error en Garbage Collector Llamados " + serv+" "+e);
            }
            
        }

        public void garbageCollTraslados(Servicio servicio, JArray array, dynamic wsClose)
        {
            dynamic result = EMPTY;
            String serv = servicio is Llamados ? "llamados" : "traslados";
            try
            {
                foreach (JObject item in array)
                {

                    string id = item["IdExterno"].ToString();

                    if (item["Prestacion"].ToString() == "Llamado") continue;

                    List<DataRow> rowList = servicio.getServicio(id);

                    if (rowList.Count != 0) continue;

                    wsClose.WSSDTAltaServicio = alta.getWSSDTCancelarServicio(id);
                    result = getWSResult(CREATE_CLOSE_SERVICE, wsClose);

                    if (result == null ) continue;

                    Program.log.Info("Garbage Collector Traslados, notas: " + result.WSSDTDatoNroServicio.Notas);


                }
            }
            catch (Exception e)
            {
                Program.log.Error("Error en Garbage Collector Traslados "+serv+" " + e);
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

            dynamic result = EMPTY;

            try {

                List<DataRow> rowList = servicio.getProcessedServicios();
                foreach (DataRow row in rowList)
                {

                    string lng = row["lng"].ToString();
                    string lat = row["lat"].ToString();


                    // si tengo valores en los dos campos , no hago nada 
                    if (lng != "0.000000" && lat != "0.000000") continue;

                    num = row["afinumpar"].ToString();
                    zone = EMPTY;//TODO
                    city = "Montevideo"; //TODO
                    street = row["afiesq1par"].ToString();
                    street2 = row["afidompar"].ToString();

                    url = GEO_GOOGLE + "address=" + num + "+" + street + "+%26+" + street2 + ",+" + zone + ",+" + city + "&key=" + googleKey + "";
                    result = getWSResult(url, EMPTY);

                    if (result == null) continue;

                    Program.log.Info("Geocodificacion : address=" + num + "+" + street + "+%26+" + street2 + ",+" + zone + ",+" + city);

                    dynamic location = result.results[0].geometry.location;

                    lat = location.lat;
                    lng = location.lng;

                    string id = row["llaid"].ToString();

                    servicio.setServicioLatLng(id, lat, lng);
                    //cooList.Add(coor);

                }
            }
            catch (Exception e)
            {
                Program.log.Error("Error en Geocodificacion" + e);
            }
            

        }



        private dynamic getWSResult(string webAddr, dynamic ws) 
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            dynamic result = null;
            try
            {
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
                    result = JObject.Parse(streamReader.ReadToEnd());
                }
            } catch (WebException e) {
                Program.log.Error("Respuesta incorrecta del web service"+e);
            } catch (Exception e) {
                Program.log.Error("Error en Obtener Resultados del ws" + e);
            }

            return result;

        }
    }
}
