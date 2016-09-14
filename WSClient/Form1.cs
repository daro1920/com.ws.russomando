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
            //if (servicio is Llamados) servController.getGoogleGeocoding(servicio);

            // alta nuevos servicios
            //servController.altaServicio(servicio);

            //servController.listarServicio(servicio);

            //devuleve lista de zonas
            //servController.getListaZonas();

            //servController.garbageCollector(servicio, EstadosEnum.SIN_ASIGNAR);

            servController.cerrarServicio(servicio, EstadosEnum.FINALIZADO);

        }

        private void llamadosTimer_Tick(object sender, EventArgs e)
        {
            callServices("llamados");
        }

        private void trasladosTimer_Tick(object sender, EventArgs e)
        {
            //callServices("traslados");
        }
    }
}

