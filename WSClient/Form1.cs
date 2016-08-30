﻿using System;
using System.Windows.Forms;
using WSClient.data;
using WSClient.enums;
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
            servController.garbageCollector(servicio, EstadosEnum.SIN_ASIGNAR);
            servController.getGoogleGeocoding(servicio);
        }

        private void llamadosTimer_Tick(object sender, EventArgs e)
        {
            callServices("llamados");
        }

        private void trasladosTimer_Tick(object sender, EventArgs e)
        {
            callServices("traslados");
        }
    }
}

