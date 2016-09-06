using Newtonsoft.Json.Linq;
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
            WSSDTAltaServicio.Prestacion = "Llamado";
            WSSDTAltaServicio.Motivo = "Fiebre";
            WSSDTAltaServicio.Origen_Causa = "A-Emergencia";
            WSSDTAltaServicio.Origen_SubCausa = "Otra";
            WSSDTAltaServicio.Celular = "";

            string tel = llamdo["llatel"].ToString();
<<<<<<< HEAD


            WSSDTAltaServicio.Telefono = tel.Substring(0, 9);
=======
            

            WSSDTAltaServicio.Telefono = tel.Substring(0, 9); 
>>>>>>> origin/clienteWs
            WSSDTAltaServicio.IdExterno = llamdo["llaid"].ToString();
            WSSDTAltaServicio.Contacto = llamdo["llanom"];
            WSSDTAltaServicio.Prioridad = "1";
            WSSDTAltaServicio.Particular = false;
            WSSDTAltaServicio.Vehiculo_Matricula = "";
            WSSDTAltaServicio.Vehiculo_Marca = "";
            WSSDTAltaServicio.Vehiculo_Modelo = "";
            WSSDTAltaServicio.Vehiculo_Anio = "2013";
            WSSDTAltaServicio.Detalle = llamdo["dianom"];
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
            WSSDTAltaServicio.Origen_Latitud = "0E-14";
            WSSDTAltaServicio.Origen_Longitud = "0E-14";
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

        public JObject getWSSDTAltaServicioTraslado(DataRow traslado)
        {
            // se completan los datos a enviar
            dynamic WSSDTAltaServicio = new JObject();
            WSSDTAltaServicio.CancelarTarea = "NO";
            WSSDTAltaServicio.CancelarNota = "Motivo de la cancelación.";
            WSSDTAltaServicio.NroAsistencia = traslado["tranro"];
            WSSDTAltaServicio.NroServicio = traslado["tranro"];
            WSSDTAltaServicio.CuentaCodigoExterno = traslado["tranro"];
            WSSDTAltaServicio.Procedencia = "Russomando";
            WSSDTAltaServicio.Producto = "Emergencia Medica";
            WSSDTAltaServicio.Cobertura = "";
            ///ver categorizar segun traslado
            WSSDTAltaServicio.Prestacion = "";
            WSSDTAltaServicio.Motivo = "Traslado S";
            WSSDTAltaServicio.Origen_Causa = "";
            WSSDTAltaServicio.Origen_SubCausa = "";
            WSSDTAltaServicio.Celular = "";

            string tel = traslado["tratel"].ToString();


            WSSDTAltaServicio.Telefono = tel.Substring(0, 9);
            WSSDTAltaServicio.IdExterno = traslado["tranro"];
            WSSDTAltaServicio.Contacto = traslado["trapac"];
            WSSDTAltaServicio.Prioridad = "1";
            WSSDTAltaServicio.Particular = false;
            WSSDTAltaServicio.Vehiculo_Matricula = "";
            WSSDTAltaServicio.Vehiculo_Marca = "";
            WSSDTAltaServicio.Vehiculo_Modelo = "";
            WSSDTAltaServicio.Vehiculo_Anio = 2013;
            WSSDTAltaServicio.Detalle = traslado["tradia"];
            WSSDTAltaServicio.Programado = "";
            WSSDTAltaServicio.Origen_LugarEspecial = "";
            WSSDTAltaServicio.Origen_Pais = "Uruguay";
            WSSDTAltaServicio.Origen_Departamento = "Montevideo";
            WSSDTAltaServicio.Origen_Ciudad = "Montevideo";
            WSSDTAltaServicio.Origen_Zona = "";
            WSSDTAltaServicio.Origen_Calle = traslado["traori"];
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

    }
}
