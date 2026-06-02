using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormNuevaReserva : Form
    {
        private int _idUsuario;

        public FormNuevaReserva(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void FormNuevaReserva_Load(object sender, EventArgs e)
        {
            CargarHorarios();
            dtpFecha.MinDate = DateTime.Today;
            dtpFechaFin.MinDate = DateTime.Today;
        }

        private void CargarHorarios()
        {
            // Horarios predefinidos lunes-viernes
            string[] horarios = {
                "07:15","08:00","08:55","09:40","10:35",
                "11:20","12:05","13:30","14:15","15:10",
                "15:55","16:50","17:35","18:20","19:00",
                "19:45","20:30"
            };

            cmbHoraInicio.Items.AddRange(horarios);
            cmbHoraFin.Items.AddRange(horarios);
            cmbHoraInicio.SelectedIndex = 0;
            cmbHoraFin.SelectedIndex = 1;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Si es fin de semana, permitir hora libre
            DayOfWeek dia = dtpFecha.Value.DayOfWeek;
            bool esFinDeSemana = dia == DayOfWeek.Saturday || dia == DayOfWeek.Sunday;

            cmbHoraInicio.Enabled = !esFinDeSemana;
            cmbHoraFin.Enabled = !esFinDeSemana;

            if (esFinDeSemana)
            {
                lblMensaje.Text = "⚠️ Fin de semana: ingresa el horario manualmente.";
                lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                cmbHoraInicio.Enabled = true;
                cmbHoraFin.Enabled = true;
            }
            else
            {
                lblMensaje.Text = "";
            }
        }

        private void chkRecurrente_CheckedChanged(object sender, EventArgs e)
        {
            lblFrecuencia.Visible = chkRecurrente.Checked;
            cmbFrecuencia.Visible = chkRecurrente.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbHoraInicio.SelectedItem == null || cmbHoraFin.SelectedItem == null)
            {
                MessageBox.Show("Selecciona hora de inicio y fin.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_SugerirAmbientes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha_inicio", dtpFecha.Value.Date);
                    cmd.Parameters.AddWithValue("@fecha_fin", dtpFechaFin.Value.Date);
                    cmd.Parameters.AddWithValue("@hora_inicio", cmbHoraInicio.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@hora_fin", cmbHoraFin.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@capacidad_requerida", (int)nudAsistentes.Value);
                    cmd.Parameters.AddWithValue("@necesita_proyector", chkProyector.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@necesita_computadoras", chkComputadoras.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@necesita_enchufes", chkEnchufes.Checked ? 1 : 0);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAmbientes.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        lblMensaje.Text = "⚠️ No hay ambientes disponibles para ese horario.";
                        lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                    }
                    else
                    {
                        lblMensaje.Text = $"✅ {dt.Rows.Count} ambiente(s) disponible(s). Selecciona uno.";
                        lblMensaje.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar ambientes: " + ex.Message);
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dgvAmbientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Primero busca y selecciona un ambiente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingresa el motivo de la reserva.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAmbiente = Convert.ToInt32(dgvAmbientes.SelectedRows[0].Cells["id_ambiente"].Value);
            string ambiente = dgvAmbientes.SelectedRows[0].Cells["codigo"].Value.ToString();

            var confirm = MessageBox.Show(
                $"¿Confirmar reserva del ambiente {ambiente}?\n\n" +
                $"Fecha: {dtpFecha.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}\n" +
                $"Horario: {cmbHoraInicio.SelectedItem} - {cmbHoraFin.SelectedItem}\n" +
                $"Motivo: {txtMotivo.Text}",
                "Confirmar Reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        INSERT INTO Reserva
                            (id_usuario, id_ambiente, fecha_inicio, fecha_fin,
                             hora_inicio, hora_fin, motivo, cantidad_asistentes,
                             es_recurrente, frecuencia, estado, creado_por_admin)
                        VALUES
                            (@idUsuario, @idAmbiente, @fechaInicio, @fechaFin,
                             @horaInicio, @horaFin, @motivo, @asistentes,
                             @esRecurrente, @frecuencia, 'activa', 0)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idUsuario", _idUsuario);
                    cmd.Parameters.AddWithValue("@idAmbiente", idAmbiente);
                    cmd.Parameters.AddWithValue("@fechaInicio", dtpFecha.Value.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", dtpFechaFin.Value.Date);
                    cmd.Parameters.AddWithValue("@horaInicio", cmbHoraInicio.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@horaFin", cmbHoraFin.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());
                    cmd.Parameters.AddWithValue("@asistentes", (int)nudAsistentes.Value);
                    cmd.Parameters.AddWithValue("@esRecurrente", chkRecurrente.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@frecuencia", chkRecurrente.Checked
                        ? (object)cmbFrecuencia.SelectedItem.ToString()
                        : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Reserva registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la reserva: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}