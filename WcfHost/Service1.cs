using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using WSClient.data;
using WSClient.services;
using WSClient.services.factories;
using WSClient.services.models;

namespace WcfHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private ServicioFactory factory = new ServicioFactory();
        private WSSDTFiltroServicio listar = new WSSDTFiltroServicio();
        private ServicesController servController = new ServicesController();

        public string sendListarLlamados(String xml)
        {

            Servicio servicio = null;

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(xml);

            dynamic campoMov = "";
            DataRow row = null;

            XElement childNode = xdoc.Descendants().First();

            JObject json = JObject.Parse(childNode.Value);

            JObject autho = (JObject)json["WSAutorizacion"];

            if(autho["Usuario"].ToString().Equals("admin") && autho["Password"].ToString().Equals("admin"))
            {
                JArray data = (JArray)json["WSData"];

                for(int i = 0; i< data.Count; i++)
                {

                    JObject servicesData = (JObject)data[i]["WSSDTDatosServicios"]["SDTDatosServicios"][0];
                    string id = servicesData["IdExterno"].ToString();

                    if (id.IndexOf(".") == -1)//es un llamado
                    {
                        servicio = factory.getServicio("llamados");
                        row = servicio.getProcessedServiciosById(id)[0];
                        servicio.toProcesServicio(row, (String)servicesData["Movil"], campoMov);

                    }
                    else // es un traslado
                    {
                        servicio = factory.getServicio("traslados");
                        row = servicio.getProcessedServiciosById(id)[0];

                        if (row["trades"].ToString().Trim() == "")
                        {
                            //solo ida
                            campoMov = "tramov";
                            servicio.toProcesServicio(row, (String)servicesData["Movil"], campoMov);
                        }
                        else
                        {
                            // ida y vuelta
                            if (row["Pronto"].ToString().Trim() != "12/30/1899 12:00:00 AM")
                            {
                                //vuelta (tiene el pronto)
                                // no le tengo que tocar el id
                                campoMov = "tramovr";
                                servicio.toProcesServicio(row, (String)servicesData["Movil"], campoMov);
                            }
                            else
                            {
                                // en el ida, le tengo que agregar el .1 para encontrarlo.
                                campoMov = "tramov";
                                double idExt = double.Parse(row["tranro"].ToString()) + 0.1;
                                servicio.toProcesServicio(row, (String)servicesData["Movil"], campoMov);
                            }
                        }
                    }
                }
                return string.Format("You entered: {0}", xml);
            }
            else
            {
                return string.Format("wrong pass and username");
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
