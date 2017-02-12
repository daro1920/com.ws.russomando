using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSClient.data;
using WSClient.models;

namespace WSClient.services.factories
{
    public class ServicioFactory
    {

        public Servicio getServicio(String tipoServicio)
        {
            Servicio servicio = null;
            switch (tipoServicio.ToLower())
            {
                case "llamados":
                    servicio = new Llamados();
                    break;
                case "traslados" :
                    servicio = new Traslados();
                    break;
                default:
                    Console.WriteLine("El servicio no existe");
                    break;
            }

            return servicio;

        }
    }
}
