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
        private volatile static WSAutorizacion autorizacionObect;
        

        private WSAutorizacion()
        {
            // se completan los datos de seguridad
            this.Guid = "44d2475c-f444-4dd5-854c-f0b1e64a5c3f";
            this.Usuario = "martin.sofpc@gmail.com";
            this.Password = "ws2016";

        }

        public static WSAutorizacion getAutorizacion()
        {
            
            if(autorizacionObect == null)
            {
                lock (lockingObject)
                {
                    if(autorizacionObect == null)
                    {
                        autorizacionObect = new WSAutorizacion();
                    }
                }
            }
            return autorizacionObect;
        }
        
    }
}
    