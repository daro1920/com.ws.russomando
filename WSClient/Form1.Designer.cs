namespace WSClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.altasLlamadosTimer = new System.Windows.Forms.Timer(this.components);
            this.altasTrasadosTimer = new System.Windows.Forms.Timer(this.components);
            this.cerrarLlamadosTimer = new System.Windows.Forms.Timer(this.components);
            this.cerrarTrasladosTimer = new System.Windows.Forms.Timer(this.components);
            this.garbageCollectorLlamadosTimer = new System.Windows.Forms.Timer(this.components);
            this.geocodLlamadosTimer = new System.Windows.Forms.Timer(this.components);
            this.listarLlamadosTimer = new System.Windows.Forms.Timer(this.components);
            this.ListarTrasladosTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(213, 120);
            this.dataGridView1.TabIndex = 2;
            // 
            // altasLlamadosTimer
            // 
            this.altasLlamadosTimer.Enabled = true;
            this.altasLlamadosTimer.Interval = 10000;
            this.altasLlamadosTimer.Tick += new System.EventHandler(this.altasLlamadosTimer_Tick);
            // 
            // altasTrasadosTimer
            // 
            this.altasTrasadosTimer.Enabled = true;
            this.altasTrasadosTimer.Interval = 15000;
            this.altasTrasadosTimer.Tick += new System.EventHandler(this.altasTrasadosTimer_Tick);
            // 
            // cerrarLlamadosTimer
            // 
            this.cerrarLlamadosTimer.Interval = 60000;
            this.cerrarLlamadosTimer.Tick += new System.EventHandler(this.cerrarLlamadosTimer_Tick);
            // 
            // cerrarTrasladosTimer
            // 
            this.cerrarTrasladosTimer.Interval = 60000;
            this.cerrarTrasladosTimer.Tick += new System.EventHandler(this.cerrarTrasladosTimer_Tick);
            // 
            // garbageCollectorLlamadosTimer
            // 
            this.garbageCollectorLlamadosTimer.Enabled = true;
            this.garbageCollectorLlamadosTimer.Interval = 60000;
            this.garbageCollectorLlamadosTimer.Tick += new System.EventHandler(this.garbageCollectorLlamados_Tick);
            // 
            // geocodLlamadosTimer
            // 
            this.geocodLlamadosTimer.Enabled = true;
            this.geocodLlamadosTimer.Interval = 60000;
            this.geocodLlamadosTimer.Tick += new System.EventHandler(this.geocodLlamadosTimer_Tick);
            // 
            // listarLlamadosTimer
            // 
            this.listarLlamadosTimer.Enabled = true;
            this.listarLlamadosTimer.Interval = 60000;
            this.listarLlamadosTimer.Tick += new System.EventHandler(this.listarLlamadosTimer_Tick);
            // 
            // ListarTrasladosTimer
            // 
            this.ListarTrasladosTimer.Enabled = true;
            this.ListarTrasladosTimer.Interval = 60000;
            this.ListarTrasladosTimer.Tick += new System.EventHandler(this.ListarTrasladosTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 202);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Timer altasLlamadosTimer;
        private System.Windows.Forms.Timer altasTrasadosTimer;
        private System.Windows.Forms.Timer cerrarLlamadosTimer;
        private System.Windows.Forms.Timer cerrarTrasladosTimer;
        private System.Windows.Forms.Timer garbageCollectorLlamadosTimer;
        private System.Windows.Forms.Timer geocodLlamadosTimer;
        private System.Windows.Forms.Timer listarLlamadosTimer;
        private System.Windows.Forms.Timer ListarTrasladosTimer;
    }
}

