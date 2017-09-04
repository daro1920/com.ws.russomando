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

            //Console.WriteLine("Se ejecuto el alta de servicios para "+ serviceType);
            // alta nuevos servicios
            servController.altaServicio(servicio);
        }

        private void cerrarServices(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);

            //Console.WriteLine("Se ejecuto el cerrar servicios para " + serviceType);
            //cierro servicio
            servController.cerrarServicio(servicio, EstadosEnum.FINALIZADO);
        }

        private void cancelarServices(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);

            //Console.WriteLine("Se ejecuto el cerrar servicios para " + serviceType);
            //cierro servicio
            servController.cancelarServicio(servicio, EstadosEnum.FINALIZADO);
        }

        private void gcLlamados(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);

            //Console.WriteLine("Se ejecuto el gc de servicios para " + serviceType);
            //garbage collector solo llamados
            servController.garbageCollector(servicio, EstadosEnum.SIN_ASIGNAR);
        }

        private void geocodLlamados(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);
            //Console.WriteLine("Se ejecuto el geocod de servicios para " + serviceType);
            //geocodifico solo llamamdos
            servController.getGoogleGeocoding(servicio);
        }

        private void listarService(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);
            //Console.WriteLine("Se ejecuto el listar de servicios para " + serviceType);
            //listado de servicios
            servController.listarServicio(servicio, EstadosEnum.ASIGNADO);
            servController.listarServicio(servicio, EstadosEnum.ACEPTADO);
            servController.listarServicio(servicio, EstadosEnum.EN_CAMINO);

        }

        private void altasLlamadosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Altas Llamados" + System.Environment.NewLine;
            Thread altaLlamado = new Thread(() => altarServices("llamados"));
            altaLlamado.Start();
            altaLlamado.Join();
            logArea.Text = DateTime.Now + " Fin Altas Llamados" + System.Environment.NewLine;
        }

        private void altasTrasadosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Incio Alta Traslados" + System.Environment.NewLine;
            Thread altaTraslados = new Thread(() => altarServices("traslados"));
            altaTraslados.Start();
            altaTraslados.Join();
            logArea.Text = DateTime.Now + " Fin Alta Traslados" + System.Environment.NewLine;
        }
        
        private void cerrarLlamadosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Cerrar Llamados" + System.Environment.NewLine;
            Thread cerrarLlamado = new Thread(() => cerrarServices("llamados"));
            cerrarLlamado.Start();
            cerrarLlamado.Join();
            logArea.Text = DateTime.Now + " Fin Cerrar Llamados" + System.Environment.NewLine;
        }

        private void cerrarTrasladosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Cerrar Traslados" + System.Environment.NewLine;
            Thread cerrarTraslado = new Thread(() => cerrarServices("traslados"));
            cerrarTraslado.Start();
            cerrarTraslado.Join();
            logArea.Text = DateTime.Now + " Fin Cerrar Traslados" + System.Environment.NewLine;
        }

        private void garbageCollectorLlamados_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Garbage Llamados" + System.Environment.NewLine;
            Thread garbageColl = new Thread(() => gcLlamados("llamados"));
            garbageColl.Start();
            garbageColl.Join();
            logArea.Text = DateTime.Now + " Fin Garbage Llamados" + System.Environment.NewLine;
        }
        private void geocodLlamadosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Geocodificacion Llamados" + System.Environment.NewLine;
            Thread geocod = new Thread(() => geocodLlamados("llamados"));
            geocod.Start();
            geocod.Join();
            logArea.Text = DateTime.Now + " Fin Geocodificacion Llamados" + System.Environment.NewLine;
        }
        

        private void listarLlamadosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Listar Llamados" + System.Environment.NewLine;
            Thread listLla = new Thread(() => listarService("llamados"));
            listLla.Start();
            listLla.Join();
            logArea.Text = DateTime.Now + " Fin Listar Llamados" + System.Environment.NewLine;
        }
        
        private void ListarTrasladosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Listar Traslados" + System.Environment.NewLine;
            Thread listTra = new Thread(() => listarService("traslados"));
            listTra.Start();
            listTra.Join();
            logArea.Text = DateTime.Now + " Fin Listar Traslados" + System.Environment.NewLine;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cancelarTrasladosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now + " Inicio Cancelar Traslados" + System.Environment.NewLine;
            Thread cancelarTra = new Thread(() => cancelarServices("traslados"));
            cancelarTra.Start();
            cancelarTra.Join();
            logArea.Text = DateTime.Now + " Fin Cancelar Traslados" + System.Environment.NewLine;
        }

        private void cancelarLlamadosTimer_Tick(object sender, EventArgs e)
        {
            logArea.Text = DateTime.Now+" Inicio Cancelar Llamados" + System.Environment.NewLine;
            Thread cancelarLla = new Thread(() => cancelarServices("llamados"));
            cancelarLla.Start();
            cancelarLla.Join();
            logArea.Text = DateTime.Now + " Fin Cancelar Llamados" + System.Environment.NewLine;
        }

    }
}

