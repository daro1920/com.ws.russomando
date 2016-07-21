using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }
        }

        // EJEMPLO DE CONECCION A DBF
        //public DataTable GetYourData()
        //{
        //    DataTable YourResultSet = new DataTable();

        //    OleDbConnection yourConnectionHandler = new OleDbConnection(
        //        @"Provider=VFPOLEDB.1;Data Source=C:\Users\PC1\Documents\Visual FoxPro Projects\");

        //    // if including the full dbc (database container) reference, just tack that on
        //    //      OleDbConnection yourConnectionHandler = new OleDbConnection(
        //    //          "Provider=VFPOLEDB.1;Data Source=C:\\SomePath\\NameOfYour.dbc;" );


        //    // Open the connection, and if open successfully, you can try to query it
        //    yourConnectionHandler.Open();

        //    if (yourConnectionHandler.State == ConnectionState.Open)
        //    {
        //        string mySQL = "select * from CLIENTS";  // dbf table name

        //        OleDbCommand MyQuery = new OleDbCommand(mySQL, yourConnectionHandler);
        //        OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);

        //        DA.Fill(YourResultSet);

        //        yourConnectionHandler.Close();
        //    }

        //    return YourResultSet;
        //}

        private async void button1_Click(object sender, EventArgs e)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // se completan los datos de seguridad
            dynamic WSAutorizacion = new JObject();
            WSAutorizacion.Guid = "44d2475c-f444-4dd5-854c-f0b1e64a5c3f";
            WSAutorizacion.Usuario = "martin.sofpc@gmail.com";
            WSAutorizacion.Password = "ws2016";

            // se completan los datos a enviar
            dynamic WSSDTAltaServicio = new JObject();
            WSSDTAltaServicio.CancelarTarea = "SI/NO";
            WSSDTAltaServicio.CancelarNota = "Motivo de la cancelación.";
            WSSDTAltaServicio.NroAsistencia = 0;
            WSSDTAltaServicio.NroServicio = 0;
            WSSDTAltaServicio.CuentaCodigoExterno = 11233;
            WSSDTAltaServicio.Procedencia = "Nombre Procedencia Cuenta";
            WSSDTAltaServicio.Producto = "Nombre Tipo Cliente Cuenta";
            WSSDTAltaServicio.Cobertura = "Nombre de la cobertura";
            WSSDTAltaServicio.Prestacion = "";
            WSSDTAltaServicio.Motivo = "";
            WSSDTAltaServicio.Origen_Causa = "";
            WSSDTAltaServicio.Origen_SubCausa = "";
            WSSDTAltaServicio.Celular = "099896123";
            WSSDTAltaServicio.Telefono = "27078965";
            WSSDTAltaServicio.IdExterno = "Externo";
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
            WSSDTAltaServicio.Destino_Latitud = "0E-14";
            WSSDTAltaServicio.Destino_Longitud = "0E-14";
            WSSDTAltaServicio.ReservarPersonal = "";
            WSSDTAltaServicio.ReservarPrestador = "";
            WSSDTAltaServicio.ReservarMovil = "";
            WSSDTAltaServicio.ReservarUsuarioEmail = "";
            
            //se crea el jason
            dynamic ws = new JObject();
            ws.WSSDTAltaServicio = WSSDTAltaServicio;
            ws.WSAutorizacion = WSAutorizacion;


            var webAddr = "http://api.logicsat.com/logicsat/rest/WSAltaServicio";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(ws.ToString());
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        
    }
}
