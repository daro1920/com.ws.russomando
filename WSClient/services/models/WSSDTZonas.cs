using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.services.models
{
    class WSSDTZonas
    {
        public void getWSSDTZonas(ref dynamic ws)
        {
            ws.Pais = "uruguay";
            ws.Departamento = "montevideo";
            ws.Ciudad = "montevideo";
            ws.Zona = "";
        }
    }
}
