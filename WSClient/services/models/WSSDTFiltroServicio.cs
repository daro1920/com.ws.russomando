using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.services.models
{
    class WSSDTFiltroServicio
    {


         public JObject getWSSDTAltaServicio(DataRow llamdo)
        {
            // se completan los datos a enviar
            dynamic WSSDTFiltroServicio = new JObject();
            WSSDTFiltroServicio.Id = "";
            WSSDTFiltroServicio.SuperiorId = "0";
            WSSDTFiltroServicio.IdExterno ="";
            WSSDTFiltroServicio.NroServicio = "";
            WSSDTFiltroServicio.NroAsistencia ="";
            WSSDTFiltroServicio.Estado = "";
            WSSDTFiltroServicio.FechaLlamadaInicial = "01-04-2016 08:00:00";
            WSSDTFiltroServicio.FechaLlamadaFinal = "08-18-2016 08:00:00";
            WSSDTFiltroServicio.Prestador = "";
            WSSDTFiltroServicio.Movil = "";
            WSSDTFiltroServicio.Operador = "";
            WSSDTFiltroServicio.Telefonista = "";
            WSSDTFiltroServicio.Prestacion = "";
            WSSDTFiltroServicio.Causa ="";
            WSSDTFiltroServicio.SubCausa = "";
            WSSDTFiltroServicio.Motivo = "";
            WSSDTFiltroServicio.Pais = "";
            WSSDTFiltroServicio.Departamento = "";
            WSSDTFiltroServicio.Ciudad = "";
            WSSDTFiltroServicio.Zona = "";

            return WSSDTFiltroServicio;
        }
    }
}
