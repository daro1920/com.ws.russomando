using Newtonsoft.Json.Linq;
using System;
using System.Data;

namespace WSClient.services.models
{
    class WSSDTAltaServicio
    {


        public JObject getWSSDTCancelarServicio(string id)
        {

            dynamic WSSDTAltaServicio = new JObject();
            WSSDTAltaServicio.CancelarTarea = "SI";
            WSSDTAltaServicio.CancelarNota = "Motivo de la cancelación.";
            WSSDTAltaServicio.IdExterno = id;
            WSSDTAltaServicio.Prioridad = "1";

            return WSSDTAltaServicio;
        }



        public JObject getWSSDTAltaServicio(DataRow llamdo)
        {
            // se completan los datos a enviar
            dynamic WSSDTAltaServicio = new JObject();
            WSSDTAltaServicio.CancelarTarea = "NO";
            WSSDTAltaServicio.CancelarNota = "Motivo de la cancelación.";
            WSSDTAltaServicio.NroAsistencia = llamdo["llaid"];
            WSSDTAltaServicio.NroServicio = llamdo["llaid"];
            WSSDTAltaServicio.CuentaCodigoExterno = llamdo["llaid"];
            WSSDTAltaServicio.Procedencia = "Russomando";
            WSSDTAltaServicio.Producto = "Emergencia Medica";
            WSSDTAltaServicio.Cobertura = "";
            
            //WSSDTAltaServicio.Motivo = "Fiebre";
            WSSDTAltaServicio.Celular = "";
            string tel = llamdo["llatel"].ToString();

            WSSDTAltaServicio.Telefono = tel.Substring(0, 9);

            WSSDTAltaServicio.IdExterno = llamdo["llaid"].ToString();
            WSSDTAltaServicio.Contacto = llamdo["llanom"];

            string claveini = (string)llamdo["llaclaini"];

            if (char.Equals(claveini.Trim(), "URGENCIA")) {
                WSSDTAltaServicio.Prioridad = "2";
                WSSDTAltaServicio.Prestacion = "Llamado";
                WSSDTAltaServicio.Origen_Causa = "B-Urgencia";
                WSSDTAltaServicio.Origen_SubCausa = "Otra";
            }

            if (char.Equals(claveini.Trim(), "EMERGENCIA"))
            {
                WSSDTAltaServicio.Prioridad = "1";
                WSSDTAltaServicio.Prestacion = "Llamado";
                WSSDTAltaServicio.Origen_Causa = "A-Emergencia";
                WSSDTAltaServicio.Origen_SubCausa = "Otra";
            }
            if (char.Equals(claveini.Trim(), "RADIO"))
            {
                WSSDTAltaServicio.Prioridad = "3";
                WSSDTAltaServicio.Prestacion = "Llamado";
                WSSDTAltaServicio.Origen_Causa = "C-Radio";
                WSSDTAltaServicio.Origen_SubCausa = "Otra";
            }
            
            WSSDTAltaServicio.Particular = false;
            WSSDTAltaServicio.Vehiculo_Matricula = "";
            WSSDTAltaServicio.Vehiculo_Marca = "";
            WSSDTAltaServicio.Vehiculo_Modelo = "";
            WSSDTAltaServicio.Vehiculo_Anio = llamdo["llaedad"];
            string detalle;
            detalle = (string)llamdo["dianom"];
            WSSDTAltaServicio.Detalle = detalle.Trim()+"-"+(string)llamdo["tipo"];
            WSSDTAltaServicio.Programado = "";
            WSSDTAltaServicio.Origen_LugarEspecial = "";
            WSSDTAltaServicio.Origen_Pais = "Uruguay";
            WSSDTAltaServicio.Origen_Departamento = "Montevideo";
            WSSDTAltaServicio.Origen_Ciudad = "Montevideo";
            WSSDTAltaServicio.Origen_Zona = "";
            WSSDTAltaServicio.Origen_Calle = llamdo["afidompar"];
            WSSDTAltaServicio.Origen_Esquina = llamdo["afiesq1par"];
            WSSDTAltaServicio.Origen_NumeroPta = llamdo["afinumpar"];
            WSSDTAltaServicio.Origen_Apto = llamdo["afiaptopar"];
            WSSDTAltaServicio.Origen_MiraHacia = "";
            WSSDTAltaServicio.Origen_Latitud = llamdo["lat"];
            WSSDTAltaServicio.Origen_Longitud = llamdo["lng"];
            WSSDTAltaServicio.Destino_Causa = "";
            WSSDTAltaServicio.Destino_SubCausa = "";
            WSSDTAltaServicio.Destino_LugarEspecial = "";
            WSSDTAltaServicio.Destino_Pais = "";
            WSSDTAltaServicio.Destino_Departamento = "";
            WSSDTAltaServicio.Destino_Ciudad = "";
            WSSDTAltaServicio.Destino_Zona = "";
            WSSDTAltaServicio.Destino_Calle = "*";
            WSSDTAltaServicio.Destino_Esquina = "";
            WSSDTAltaServicio.Destino_NumeroPta = "";
            WSSDTAltaServicio.Destino_Apto = "";
            WSSDTAltaServicio.Destino_MiraHacia = "";
            WSSDTAltaServicio.Destino_Latitud = "";
            WSSDTAltaServicio.Destino_Longitud = "";
            WSSDTAltaServicio.ReservarPersonal = "";
            WSSDTAltaServicio.ReservarPrestador = "";
            WSSDTAltaServicio.ReservarMovil = "";
            WSSDTAltaServicio.ReservarUsuarioEmail = "";

            return WSSDTAltaServicio;
        }

        public JObject getWSSDTAltaServicioTraslado(DataRow traslado, object origen, object destino,object nroAsistencia,double codVuelta)
        {
            // se completan los datos a enviar
            dynamic WSSDTAltaServicio = new JObject();
            WSSDTAltaServicio.CancelarTarea = "NO";
            WSSDTAltaServicio.CancelarNota = "Motivo de la cancelación.";
            WSSDTAltaServicio.NroAsistencia = nroAsistencia != null? nroAsistencia : "";
            WSSDTAltaServicio.NroServicio = traslado["tranro"];
            WSSDTAltaServicio.CuentaCodigoExterno = traslado["tranro"];
            WSSDTAltaServicio.Procedencia = "Russomando";
            WSSDTAltaServicio.Producto = "Emergencia Medica";
            WSSDTAltaServicio.Cobertura = "";
            ///ver categorizar segun traslado
            WSSDTAltaServicio.Prestacion = "";

            string motivo="";
            if (traslado["tratpo"].ToString().Trim() == "1") { 
                motivo = "Traslado S";
            }
            if (traslado["tratpo"].ToString().Trim() == "2")
            {
                motivo = "Traslado C/R";
            }
            if (traslado["tratpo"].ToString().Trim() == "3")
            {
                motivo = "Traslado TPK";
            }
            if (traslado["tratpo"].ToString().Trim() == "4")
            {
                motivo = "Traslado TES S";
            }
            if (traslado["tratpo"].ToString().Trim() == "5")
            {
                motivo = "Traslado TES C/R";
            }
            if (traslado["tratpo"].ToString().Trim() == "6")
            {
                motivo = "Traslado TES TPK";
            }
            if (traslado["tratpo"].ToString().Trim() == "7")
            {
                motivo = "Traslado Dialisis";
            }
            WSSDTAltaServicio.Motivo = motivo;
            WSSDTAltaServicio.Origen_Causa = "";
            WSSDTAltaServicio.Origen_SubCausa = "";
            WSSDTAltaServicio.Celular = "";

            string tel = traslado["tratel"].ToString();
            double idExt = double.Parse(traslado["tranro"].ToString()) + codVuelta;

            WSSDTAltaServicio.Telefono = tel.Substring(0, 9);
            WSSDTAltaServicio.IdExterno = idExt;
            WSSDTAltaServicio.Contacto = traslado["trapac"];
            WSSDTAltaServicio.Prioridad = "1";
            WSSDTAltaServicio.Particular = false;
            WSSDTAltaServicio.Vehiculo_Matricula = "";
            WSSDTAltaServicio.Vehiculo_Marca = "";
            WSSDTAltaServicio.Vehiculo_Modelo = "";
            WSSDTAltaServicio.Vehiculo_Anio = traslado["traedad"];

            string enorigen = traslado["enorigen"].ToString() == "True" ? "(O) " : "(D) ";
            string detalle = enorigen + traslado["tradia"].ToString().Trim()+ " ["+traslado["trainsdsc"].ToString().Trim()+"]";
            WSSDTAltaServicio.Detalle = detalle;

            DateTime date = DateTime.Parse(traslado["trafch"].ToString());

            string fecha = "";
            if (DateTime.Compare(date, DateTime.Now) > 0)
            {       
                fecha = date.ToString("yyyy-MM-ddTHH:mm:ss");
            }
            WSSDTAltaServicio.Programado = fecha;
            WSSDTAltaServicio.Origen_LugarEspecial = "";
            WSSDTAltaServicio.Origen_Pais = "Uruguay";
            WSSDTAltaServicio.Origen_Departamento = "Montevideo";
            WSSDTAltaServicio.Origen_Ciudad = "Montevideo";
            WSSDTAltaServicio.Origen_Zona = "";
            WSSDTAltaServicio.Origen_Calle = origen;
            WSSDTAltaServicio.Origen_Esquina = "";
            WSSDTAltaServicio.Origen_NumeroPta = "";
            WSSDTAltaServicio.Origen_Apto = "";
            WSSDTAltaServicio.Origen_MiraHacia = "";
            WSSDTAltaServicio.Origen_Latitud = "0E-14";
            WSSDTAltaServicio.Origen_Longitud = "0E-14";
            WSSDTAltaServicio.Destino_Causa = "";
            WSSDTAltaServicio.Destino_SubCausa = "";
            WSSDTAltaServicio.Destino_LugarEspecial = "";
            WSSDTAltaServicio.Destino_Pais = "Uruguay";
            WSSDTAltaServicio.Destino_Departamento = "Montevideo";
            WSSDTAltaServicio.Destino_Ciudad = "Montevideo";
            WSSDTAltaServicio.Destino_Zona = "";
            WSSDTAltaServicio.Destino_Calle = destino;
            WSSDTAltaServicio.Destino_Esquina = "";
            WSSDTAltaServicio.Destino_NumeroPta = "";
            WSSDTAltaServicio.Destino_Apto = "";
            WSSDTAltaServicio.Destino_MiraHacia = "";
            WSSDTAltaServicio.Destino_Latitud = "";
            WSSDTAltaServicio.Destino_Longitud = "";
            WSSDTAltaServicio.ReservarPersonal = "";
            WSSDTAltaServicio.ReservarPrestador = "";
            WSSDTAltaServicio.ReservarMovil = "";
            WSSDTAltaServicio.ReservarUsuarioEmail = "";

            return WSSDTAltaServicio;
        }

    }
}
