using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.services.models
{
    class WSAutorizacion
    {
        public String Guid;
        public String Usuario;
        public String Password;

        private static object lockingObject = new object();
        private volatile static JObject autorizacionObect;
        

        private static JObject getWSAutorizacion()
        {
            // se completan los datos de seguridad
            dynamic WSAutorizacion = new JObject();
            WSAutorizacion.Guid = "44d2475c-f444-4dd5-854c-f0b1e64a5c3f";
            WSAutorizacion.Usuario = "martin.sofpc@gmail.com";
            WSAutorizacion.Password = "ws2016";
            return WSAutorizacion;
        }

        public static JObject getAutorizacion()
        {
            
            if(autorizacionObect == null)
            {
                lock (lockingObject)
                {
                    if(autorizacionObect == null)
                    {
                        autorizacionObect = getWSAutorizacion();
                    }
                }
            }
            return autorizacionObect;
        }
        
    }
}
    