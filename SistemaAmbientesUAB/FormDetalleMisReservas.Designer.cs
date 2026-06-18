namespace SistemaAmbientesUAB
{
    partial class FormDetalleMisReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAmbienteEstilo = new System.Windows.Forms.Label();
            this.lblInfoAmbiente = new System.Windows.Forms.Label();
            this.lblHorarioEstilo = new System.Windows.Forms.Label();
            this.lblInfoHorario = new System.Windows.Forms.Label();
            this.lblMotivoEstilo = new System.Windows.Forms.Label();
            this.txtMotivoEvento = new System.Windows.Forms.TextBox();
            this.lblAsistentesEstilo = new System.Windows.Forms.Label();
            this.numAsistentes = new System.Windows.Forms.NumericUpDown();
            this.lblMotivoCancelacion = new System.Windows.Forms.Label();
            this.txtMotivoCancelacion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAsistentes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(24, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(214, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de la Reserva";
            // 
            // lblAmbienteEstilo
            // 
            this.lblAmbienteEstilo.AutoSize = true;
            this.lblAmbienteEstilo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblAmbienteEstilo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAmbienteEstilo.Location = new System.Drawing.Point(26, 68);
            this.lblAmbienteEstilo.Name = "lblAmbienteEstilo";
            this.lblAmbienteEstilo.Size = new System.Drawing.Size(126, 15);
            this.lblAmbienteEstilo.TabIndex = 1;
            this.lblAmbienteEstilo.Text = "Ambiente Asignado:";
            // 
            // lblInfoAmbiente
            // 
            this.lblInfoAmbiente.AutoSize = true;
            this.lblInfoAmbiente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoAmbiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblInfoAmbiente.Location = new System.Drawing.Point(25, 87);
            this.lblInfoAmbiente.Name = "lblInfoAmbiente";
            this.lblInfoAmbiente.Size = new System.Drawing.Size(135, 19);
            this.lblInfoAmbiente.TabIndex = 2;
            this.lblInfoAmbiente.Text = "Cargando bloque...";
            // 
            // lblHorarioEstilo
            // 
            this.lblHorarioEstilo.AutoSize = true;
            this.lblHorarioEstilo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblHorarioEstilo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHorarioEstilo.Location = new System.Drawing.Point(26, 122);
            this.lblHorarioEstilo.Name = "lblHorarioEstilo";
            this.lblHorarioEstilo.Size = new System.Drawing.Size(84, 15);
            this.lblHorarioEstilo.TabIndex = 3;
            this.lblHorarioEstilo.Text = "Fecha y Hora:";
            // 
            // lblInfoHorario
            // 
            this.lblInfoHorario.AutoSize = true;
            this.lblInfoHorario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoHorario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblInfoHorario.Location = new System.Drawing.Point(25, 141);
            this.lblInfoHorario.Name = "lblInfoHorario";
            this.lblInfoHorario.Size = new System.Drawing.Size(130, 19);
            this.lblInfoHorario.TabIndex = 4;
            this.lblInfoHorario.Text = "Cargando fecha...";
            // 
            // lblMotivoEstilo
            // 
            this.lblMotivoEstilo.AutoSize = true;
            this.lblMotivoEstilo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblMotivoEstilo.Location = new System.Drawing.Point(26, 184);
            this.lblMotivoEstilo.Name = "lblMotivoEstilo";
            this.lblMotivoEstilo.Size = new System.Drawing.Size(111, 15);
            this.lblMotivoEstilo.TabIndex = 5;
            this.lblMotivoEstilo.Text = "Nombre del Evento";
            // 
            // txtMotivoEvento
            // 
            this.txtMotivoEvento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMotivoEvento.Location = new System.Drawing.Point(29, 204);
            this.txtMotivoEvento.Name = "txtMotivoEvento";
            this.txtMotivoEvento.Size = new System.Drawing.Size(414, 25);
            this.txtMotivoEvento.TabIndex = 6;
            // 
            // lblAsistentesEstilo
            // 
            this.lblAsistentesEstilo.AutoSize = true;
            this.lblAsistentesEstilo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsistentesEstilo.Location = new System.Drawing.Point(26, 245);
            this.lblAsistentesEstilo.Name = "lblAsistentesEstilo";
            this.lblAsistentesEstilo.Size = new System.Drawing.Size(117, 15);
            this.lblAsistentesEstilo.TabIndex = 7;
            this.lblAsistentesEstilo.Text = "Asistentes Esperados";
            // 
            // numAsistentes
            // 
            this.numAsistentes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numAsistentes.Location = new System.Drawing.Point(29, 265);
            this.numAsistentes.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numAsistentes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numAsistentes.Name = "numAsistentes";
            this.numAsistentes.Size = new System.Drawing.Size(120, 25);
            this.numAsistentes.TabIndex = 8;
            this.numAsistentes.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMotivoCancelacion
            // 
            this.lblMotivoCancelacion.AutoSize = true;
            this.lblMotivoCancelacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblMotivoCancelacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblMotivoCancelacion.Location = new System.Drawing.Point(26, 307);
            this.lblMotivoCancelacion.Name = "lblMotivoCancelacion";
            this.lblMotivoCancelacion.Size = new System.Drawing.Size(129, 15);
            this.lblMotivoCancelacion.TabIndex = 9;
            this.lblMotivoCancelacion.Text = "Motivo de Cancelación:";
            // 
            // txtMotivoCancelacion
            // 
            this.txtMotivoCancelacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMotivoCancelacion.Location = new System.Drawing.Point(29, 327);
            this.txtMotivoCancelacion.Multiline = true;
            this.txtMotivoCancelacion.Name = "txtMotivoCancelacion";
            this.txtMotivoCancelacion.Size = new System.Drawing.Size(414, 58);
            this.txtMotivoCancelacion.TabIndex = 10;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(155, 408);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 36);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(331, 408);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(112, 36);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormDetalleMisReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 468);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtMotivoCancelacion);
            this.Controls.Add(this.lblMotivoCancelacion);
            this.Controls.Add(this.numAsistentes);
            this.Controls.Add(this.lblAsistentesEstilo);
            this.Controls.Add(this.txtMotivoEvento);
            this.Controls.Add(this.lblMotivoEstilo);
            this.Controls.Add(this.lblInfoHorario);
            this.Controls.Add(this.lblHorarioEstilo);
            this.Controls.Add(this.lblInfoAmbiente);
            this.Controls.Add(this.lblAmbienteEstilo);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormDetalleMisReservas";
            this.Text = "Detalle";
            this.Load += new System.EventHandler(this.FormDetalleMisReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAsistentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAmbienteEstilo;
        private System.Windows.Forms.Label lblInfoAmbiente;
        private System.Windows.Forms.Label lblHorarioEstilo;
        private System.Windows.Forms.Label lblInfoHorario;
        private System.Windows.Forms.Label lblMotivoEstilo;
        private System.Windows.Forms.TextBox txtMotivoEvento;
        private System.Windows.Forms.Label lblAsistentesEstilo;
        private System.Windows.Forms.NumericUpDown numAsistentes;
        private System.Windows.Forms.Label lblMotivoCancelacion;
        private System.Windows.Forms.TextBox txtMotivoCancelacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
    }
}