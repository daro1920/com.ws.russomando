using System;
using System.Threading;
using System.Windows.Forms;
using WSClient.data;
using WSClient.enums;
using WSClient.models;
using WSClient.services;
using WSClient.services.factories;

namespace WSClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ServicesController servController = new ServicesController();
        private ServicioFactory factory = new ServicioFactory();

        private void altarServices(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);

            Console.WriteLine("Se ejecuto el alta de servicios para "+ serviceType);
            // alta nuevos servicios
            servController.altaServicio(servicio);
        }

        private void cerrarServices(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);

            Console.WriteLine("Se ejecuto el cerrar servicios para " + serviceType);
            //cierro servicio
            servController.cerrarServicio(servicio, EstadosEnum.FINALIZADO);
        }

        private void gcLlamados(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);

            Console.WriteLine("Se ejecuto el gc de servicios para " + serviceType);
            //garbage collector solo llamados
            servController.garbageCollector(servicio, EstadosEnum.SIN_ASIGNAR);
        }

        private void geocodLlamados(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);
            Console.WriteLine("Se ejecuto el geocod de servicios para " + serviceType);
            //geocodifico solo llamamdos
            servController.getGoogleGeocoding(servicio);
        }

        private void listarService(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);
            Console.WriteLine("Se ejecuto el listar de servicios para " + serviceType);
            //listado de servicios
            servController.listarServicio(servicio);
        }

        private void altasLlamadosTimer_Tick(object sender, EventArgs e)
        {
            Thread altaLlamado = new Thread(() => altarServices("llamados"));
            altaLlamado.Start();
        }

        private void altasTrasadosTimer_Tick(object sender, EventArgs e)
        {
            Thread altaLlamado = new Thread(() => altarServices("traslados"));
            altaLlamado.Start();
        }
        
        private void cerrarLlamadosTimer_Tick(object sender, EventArgs e)
        {
            Thread cerrarLlamado = new Thread(() => cerrarServices("llamados"));
            cerrarLlamado.Start();
        }

        private void cerrarTrasladosTimer_Tick(object sender, EventArgs e)
        {
            Thread cerrarTraslado = new Thread(() => cerrarServices("traslados"));
            cerrarTraslado.Start();
        }

        private void garbageCollectorLlamados_Tick(object sender, EventArgs e)
        {
            Thread garbageColl = new Thread(() => gcLlamados("llamados"));
            garbageColl.Start();
        }
        private void geocodLlamadosTimer_Tick(object sender, EventArgs e)
        {
            Thread geocod = new Thread(() => geocodLlamados("llamados"));
            geocod.Start();
        }
        

        private void listarLlamadosTimer_Tick(object sender, EventArgs e)
        {
            Thread listLla = new Thread(() => listarService("llamados"));
            listLla.Start();
        }
        
        private void ListarTrasladosTimer_Tick(object sender, EventArgs e)
        {
            Thread listTra = new Thread(() => listarService("llamados"));
            listTra.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

