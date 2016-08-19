﻿using Newtonsoft.Json.Linq;
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
<<<<<<< HEAD
        public String CancelarTarea;
        public String CancelarNota;
        public int NroAsistencia;
        public int NroServicio;
        public int CuentaCodigoExterno;
        public String Procedencia;
        public String Producto;
        public String Cobertura;
        public String Prestacion;
        public String Motivo;
        public String Origen_Causa;
        public String Origen_SubCausa;
        public String Celular;
        public String Telefono;
        public String IdExterno;
        public String Contacto;
        public String Prioridad;
        public bool Particular;
        public String Vehiculo_Matricula;
        public String Vehiculo_Marca;
        public String Vehiculo_Modelo;
        public int Vehiculo_Anio;
        public String Detalle;
        public String Programado;
        public String Origen_LugarEspecial;
        public String Origen_Pais;
        public String Origen_Departamento;
        public String Origen_Ciudad;
        public String Origen_Zona;
        public String Origen_Calle;
        public String Origen_Esquina;
        public String Origen_NumeroPta;
        public String Origen_Apto;
        public String Origen_MiraHacia;
        public String Origen_Latitud;
        public String Origen_Longitud;
        public String Destino_Causa;
        public String Destino_SubCausa;
        public String Destino_LugarEspecial;
        public String Destino_Pais;
        public String Destino_Departamento;
        public String Destino_Ciudad;
        public String Destino_Zona;
        public String Destino_Calle;
        public String Destino_Esquina;
        public String Destino_NumeroPta;
        public String Destino_Apto;
        public String Destino_MiraHacia;
        public String Destino_Latitud;
        public String Destino_Longitud;
        public String ReservarPersonal;
        public String ReservarPrestador;
        public String ReservarMovil;
        public String ReservarUsuarioEmail;
=======
>>>>>>> 89b56f2c8bacea7e02978fbc82de470cbbe7c7c1

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
            WSSDTAltaServicio.Telefono = llamdo["llatel"];
            WSSDTAltaServicio.IdExterno = llamdo["llaid"];
            WSSDTAltaServicio.Contacto = llamdo["llanom"];
            WSSDTAltaServicio.Prioridad = "1";
            WSSDTAltaServicio.Particular = false;
            WSSDTAltaServicio.Vehiculo_Matricula = "";
            WSSDTAltaServicio.Vehiculo_Marca = "";
            WSSDTAltaServicio.Vehiculo_Modelo = "";
            WSSDTAltaServicio.Vehiculo_Anio = 2013;
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
            WSSDTAltaServicio.Telefono = traslado["tratel"];
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
