﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSClient.data
{
    abstract class Servicio
    {
        public String sqlServicio { get; set; }

        protected DataTable servicios = new DataTable();
        protected List<DataRow> serviciosList = new List<DataRow>();
        protected OleDbConnection yourConnectionHandler = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=C:\Work\FreelanceProjects\RoussoMando\dbf");

        abstract public List<DataRow> getAllServicios();
        abstract public List<DataRow> getProcessedServicios();
        abstract public List<DataRow> getNonProcessedServicios();
        abstract public void setServicio(Decimal id, Int32 NroServicio, Int32 NroAsistencia);

        protected List<DataRow> getListServicio()
        {

            // Open the connection, and if open successfully, you can try to query it
            yourConnectionHandler.Open();

            if (yourConnectionHandler.State == ConnectionState.Open)
            {

                OleDbCommand queryServicio = new OleDbCommand(sqlServicio, yourConnectionHandler);
                OleDbDataAdapter DAServicio = new OleDbDataAdapter(queryServicio);

                DAServicio.Fill(servicios);

                foreach (DataRow row in servicios.Rows)
                {
                    serviciosList.Add(row);

                }

                yourConnectionHandler.Close();
            }
            return serviciosList;
        }


    }
}