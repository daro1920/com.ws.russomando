using System;
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

        private void callServices(String serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);

            //geocodifico solo llamamdos
            if (servicio is Llamados) servController.getGoogleGeocoding(servicio);

            servController.listarServicio(servicio);

            //devuleve lista de zonas
            //servController.getListaZonas();

            if (servicio is Llamados) servController.garbageCollector(servicio, EstadosEnum.SIN_ASIGNAR);

            servController.cerrarServicio(servicio, EstadosEnum.FINALIZADO);

        }

        private void altarServices(string serviceType)
        {
            Servicio servicio = factory.getServicio(serviceType);
            // alta nuevos servicios
            servController.altaServicio(servicio);
        }

        private void llamadosTimer_Tick(object sender, EventArgs e)
        {
            callServices("llamados");
        }

        private void trasladosTimer_Tick(object sender, EventArgs e)
        {
            callServices("traslados");
        }

        private void altasLlamadosTimer_Tick(object sender, EventArgs e)
        {
            altarServices("llamados");
        }

        private void altasTrasadosTimer_Tick(object sender, EventArgs e)
        {
            altarServices("traslados");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

