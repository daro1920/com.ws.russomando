using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.services.models
{
    class WSSDTAltaServicio
    {
        public String CancelarTarea;
        public String CancelarNota;
        public int NroAsistencia;
        public int NroServicio;
        public int CuentaCodigoExterno;
        public String Procedencia;
        public String Producto;
        public String Cobertura;
        public String Prestacion;
        public String Motivo ;
        public String Origen_Causa ;
        public String Origen_SubCausa ;
        public String Celular ;
        public String Telefono ;
        public String IdExterno ;
        public String Contacto ;
        public String Prioridad ;
        public bool Particular ;
        public String Vehiculo_Matricula ;
        public String Vehiculo_Marca ;
        public String Vehiculo_Modelo ;
        public int Vehiculo_Anio;
        public String Detalle ;
        public String Programado ;
        public String Origen_LugarEspecial;
        public String Origen_Pais ;
        public String Origen_Departamento ;
        public String Origen_Ciudad ;
        public String Origen_Zona ;
        public String Origen_Calle ;
        public String Origen_Esquina ;
        public String Origen_NumeroPta ;
        public String Origen_Apto ;
        public String Origen_MiraHacia ;
        public String Origen_Latitud ;
        public String Origen_Longitud;
        public String Destino_Causa;
        public String Destino_SubCausa;
        public String Destino_LugarEspecial;
        public String Destino_Pais;
        public String Destino_Departamento;
        public String Destino_Ciudad;
        public String Destino_Zona;
        public String Destino_Calle;
        public String Destino_Esquina ;
        public String Destino_NumeroPta ;
        public String Destino_Apto ;
        public String Destino_MiraHacia ;
        public String Destino_Latitud ;
        public String Destino_Longitud ;
        public String ReservarPersonal ;
        public String ReservarPrestador ;
        public String ReservarMovil ;
        public String ReservarUsuarioEmail ;

        public JObject getWSSDTAltaServicio(DataRow llamdo)
        {
            // se completan los datos a enviar
            dynamic WSSDTAltaServicio = new JObject();
            WSSDTAltaServicio.CancelarTarea = "NO";
            WSSDTAltaServicio.CancelarNota = "Motivo de la cancelación.";
            WSSDTAltaServicio.NroAsistencia = 12;
            WSSDTAltaServicio.NroServicio = 20;
            WSSDTAltaServicio.CuentaCodigoExterno = 1100;
            WSSDTAltaServicio.Procedencia = "Russomando";
            WSSDTAltaServicio.Producto = "Emergencia Medica";
            WSSDTAltaServicio.Cobertura = "";
            WSSDTAltaServicio.Prestacion = "";
            WSSDTAltaServicio.Motivo = "Fiebre";
            WSSDTAltaServicio.Origen_Causa = "A-Emergencia";
            WSSDTAltaServicio.Origen_SubCausa = "ASFIXIA";
            WSSDTAltaServicio.Celular = "099896123";
            WSSDTAltaServicio.Telefono = "27078965";
            WSSDTAltaServicio.IdExterno = "20";
            WSSDTAltaServicio.Contacto = "Juan Perez";
            WSSDTAltaServicio.Prioridad = "1";
            WSSDTAltaServicio.Particular = false;
            WSSDTAltaServicio.Vehiculo_Matricula = "SAE 8962";
            WSSDTAltaServicio.Vehiculo_Marca = "AUDI";
            WSSDTAltaServicio.Vehiculo_Modelo = "Modelo";
            WSSDTAltaServicio.Vehiculo_Anio = 2013;
            WSSDTAltaServicio.Detalle = "Detalle del servicio";
            WSSDTAltaServicio.Programado = "yyyy-mm-ddThh:mm:ss";
            WSSDTAltaServicio.Origen_LugarEspecial = "";
            WSSDTAltaServicio.Origen_Pais = "Uruguay";
            WSSDTAltaServicio.Origen_Departamento = "Montevideo";
            WSSDTAltaServicio.Origen_Ciudad = "Montevideo";
            WSSDTAltaServicio.Origen_Zona = "Sayago";
            WSSDTAltaServicio.Origen_Calle = "Bv. España";
            WSSDTAltaServicio.Origen_Esquina = "Luis Franzini";
            WSSDTAltaServicio.Origen_NumeroPta = "2565";
            WSSDTAltaServicio.Origen_Apto = "";
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

    }
}
