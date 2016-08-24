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


         public JObject getWSSDTFiltroServicio(DataRow llamado, string fechaIni, string fechaFin)
        {
            // se completan los datos a enviar
            dynamic WSSDTFiltroServicio = new JObject();
            WSSDTFiltroServicio.Id = "";
            WSSDTFiltroServicio.SuperiorId = "";
            WSSDTFiltroServicio.IdExterno = llamado == null ? "" :llamado["llaid"];
            WSSDTFiltroServicio.NroServicio = "";
            WSSDTFiltroServicio.NroAsistencia = "";
            WSSDTFiltroServicio.Estado = "";
            WSSDTFiltroServicio.FechaLlamadaInicial = fechaIni;
            WSSDTFiltroServicio.FechaLlamadaFinal = fechaFin;
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
