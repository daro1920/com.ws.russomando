using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSClient.models;
using WSClient.services;

namespace WSClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ServicesController servController = new ServicesController();
        private Llamados llamados = new Llamados();


        private async void button1_Click(object sender, EventArgs e)
        {

            //List<DataRow> llamadosLista = llamados.getLlamados();
            servController.altaServicio(null);

            //    ServicePointManager.Expect100Continue = true;
            //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //    // se completan los datos de seguridad
            //    dynamic WSAutorizacion = new JObject();
            //    WSAutorizacion.Guid = "44d2475c-f444-4dd5-854c-f0b1e64a5c3f";
            //    WSAutorizacion.Usuario = "martin.sofpc@gmail.com";
            //    WSAutorizacion.Password = "ws2016";

            //    // se completan los datos a enviar
            //    dynamic WSSDTAltaServicio = new JObject();
            //    WSSDTAltaServicio.CancelarTarea = "NO";
            //    WSSDTAltaServicio.CancelarNota = "Motivo de la cancelación.";
            //    WSSDTAltaServicio.NroAsistencia = 12;
            //    WSSDTAltaServicio.NroServicio = 20;
            //    WSSDTAltaServicio.CuentaCodigoExterno = 1100;
            //    WSSDTAltaServicio.Procedencia = "Russomando";
            //    WSSDTAltaServicio.Producto = "Emergencia Medica";
            //    WSSDTAltaServicio.Cobertura = "";
            //    WSSDTAltaServicio.Prestacion = "";
            //    WSSDTAltaServicio.Motivo = "Fiebre";
            //    WSSDTAltaServicio.Origen_Causa = "A-Emergencia";
            //    WSSDTAltaServicio.Origen_SubCausa = "ASFIXIA";
            //    WSSDTAltaServicio.Celular = "099896123";
            //    WSSDTAltaServicio.Telefono = "27078965";
            //    WSSDTAltaServicio.IdExterno = "20";
            //    WSSDTAltaServicio.Contacto = "Juan Perez";
            //    WSSDTAltaServicio.Prioridad = "1";
            //    WSSDTAltaServicio.Particular = false;
            //    WSSDTAltaServicio.Vehiculo_Matricula = "SAE 8962";
            //    WSSDTAltaServicio.Vehiculo_Marca = "AUDI";
            //    WSSDTAltaServicio.Vehiculo_Modelo = "Modelo";
            //    WSSDTAltaServicio.Vehiculo_Anio = 2013;
            //    WSSDTAltaServicio.Detalle = "Detalle del servicio";
            //    WSSDTAltaServicio.Programado = "yyyy-mm-ddThh:mm:ss";
            //    WSSDTAltaServicio.Origen_LugarEspecial = "";
            //    WSSDTAltaServicio.Origen_Pais = "Uruguay";
            //    WSSDTAltaServicio.Origen_Departamento = "Montevideo";
            //    WSSDTAltaServicio.Origen_Ciudad = "Montevideo";
            //    WSSDTAltaServicio.Origen_Zona = "Sayago";
            //    WSSDTAltaServicio.Origen_Calle = "Bv. España";
            //    WSSDTAltaServicio.Origen_Esquina = "Luis Franzini";
            //    WSSDTAltaServicio.Origen_NumeroPta = "2565";
            //    WSSDTAltaServicio.Origen_Apto = "";
            //    WSSDTAltaServicio.Origen_MiraHacia = "";
            //    WSSDTAltaServicio.Origen_Latitud = "0E-14";
            //    WSSDTAltaServicio.Origen_Longitud = "0E-14";
            //    WSSDTAltaServicio.Destino_Causa = "";
            //    WSSDTAltaServicio.Destino_SubCausa = "";
            //    WSSDTAltaServicio.Destino_LugarEspecial = "";
            //    WSSDTAltaServicio.Destino_Pais = "";
            //    WSSDTAltaServicio.Destino_Departamento = "";
            //    WSSDTAltaServicio.Destino_Ciudad = "";
            //    WSSDTAltaServicio.Destino_Zona = "";
            //    WSSDTAltaServicio.Destino_Calle = "*";
            //    WSSDTAltaServicio.Destino_Esquina = "";
            //    WSSDTAltaServicio.Destino_NumeroPta = "";
            //    WSSDTAltaServicio.Destino_Apto = "";
            //    WSSDTAltaServicio.Destino_MiraHacia = "";
            //    WSSDTAltaServicio.Destino_Latitud = "";
            //    WSSDTAltaServicio.Destino_Longitud = "";
            //    WSSDTAltaServicio.ReservarPersonal = "";
            //    WSSDTAltaServicio.ReservarPrestador = "";
            //    WSSDTAltaServicio.ReservarMovil = "";
            //    WSSDTAltaServicio.ReservarUsuarioEmail = "";

            //    //se crea el jason
            //    dynamic ws = new JObject();
            //    ws.WSSDTAltaServicio = WSSDTAltaServicio;
            //    ws.WSAutorizacion = WSAutorizacion;


            //    var webAddr = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
            //    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            //    httpWebRequest.ContentType = "application/json";
            //    httpWebRequest.Method = "POST";

            //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //    {

            //        streamWriter.Write(ws.ToString());
            //        streamWriter.Flush();
            //    }
            //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //    {
            //        var result = streamReader.ReadToEnd();
            //    }



        }


    }
}
