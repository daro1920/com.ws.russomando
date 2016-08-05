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

            Llamados llamados = new Llamados();
            Console.WriteLine(servController.altaServicio(llamados));
        }


    }
}
