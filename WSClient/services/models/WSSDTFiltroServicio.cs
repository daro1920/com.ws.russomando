using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.services.models
{
    public class WSSDTFiltroServicio
    {


         public JObject getWSSDTFiltroServicio(string id, string fechaIni, string fechaFin,string estado)
        {
            // se completan los datos a enviar
            dynamic WSSDTFiltroServicio = new JObject();
            WSSDTFiltroServicio.Id = "";
            WSSDTFiltroServicio.SuperiorId = "";

            WSSDTFiltroServicio.IdExterno = id;
            WSSDTFiltroServicio.NroServicio = "";
            WSSDTFiltroServicio.NroAsistencia = "";
            WSSDTFiltroServicio.Estado = estado;
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
