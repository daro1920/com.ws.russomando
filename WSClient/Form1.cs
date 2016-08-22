using System;
using System.Windows.Forms;
using WSClient.data;
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
            servController.altaServicio(servicio);
            servController.listarServicio(servicio);
            servController.getListaZonas();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            callServices("llamados");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            callServices("traslados");
        }
    }
}

