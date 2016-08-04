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

        public WSSDTAltaServicio(DataRow llamdo)
        {
            this.CancelarTarea = "NO";
            this.CancelarTarea = "Motivo de la cancelación.";
            this.NroAsistencia = 12;
            this.NroServicio = 20;
            this.CuentaCodigoExterno = 1100;
            this.Procedencia = "Russomando";
            this.Producto = "Emergencia Medica";
            this.Cobertura = "";
            this.Prestacion = "";
            this.Motivo = "Fiebre";
            this.Origen_Causa = "A-Emergencia";
            this.Origen_SubCausa = "ASFIXIA";
            this.Celular = "099896123";
            this.Telefono = "27078965";
            this.IdExterno = "20";
            this.Contacto = "Juan Perez";
            this.Prioridad = "1";
            this.Particular = false;
            this.Vehiculo_Matricula = "SAE 8962";
            this.Vehiculo_Marca = "AUDI";
            this.Vehiculo_Modelo = "Modelo";
            this.Vehiculo_Anio = 2013;
            this.Detalle = "Detalle del servicio";
            this.Programado = "yyyy-mm-ddThh:mm:ss";
            this.Origen_LugarEspecial = "";
            this.Origen_Pais = "Uruguay";
            this.Origen_Departamento = "Montevideo";
            this.Origen_Ciudad = "Montevideo";
            this.Origen_Zona = "Sayago";
            this.Origen_Calle = "Bv. España";
            this.Origen_Esquina = "Luis Franzini";
            this.Origen_NumeroPta = "2565";
            this.Origen_Apto = "";
            this.Origen_MiraHacia = "";
            this.Origen_Latitud = "0E-14";
            this.Origen_Longitud = "0E-14";
            this.Destino_Causa = "";
            this.Destino_SubCausa = "";
            this.Destino_LugarEspecial = "";
            this.Destino_Pais = "";
            this.Destino_Departamento = "";
            this.Destino_Ciudad = "";
            this.Destino_Zona = "";
            this.Destino_Calle = "*";
            this.Destino_Esquina = "";
            this.Destino_NumeroPta = "";
            this.Destino_Apto = "";
            this.Destino_MiraHacia = "";
            this.Destino_Latitud = "";
            this.Destino_Longitud = "";
            this.ReservarPersonal = "";
            this.ReservarPrestador = "";
            this.ReservarMovil = "";
            this.ReservarUsuarioEmail = "";
        }
        
    }
}
