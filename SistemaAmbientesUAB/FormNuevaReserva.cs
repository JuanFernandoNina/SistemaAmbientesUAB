using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormNuevaReserva : Form
    {
        private int _idUsuario;      // usuario logueado (admin o no)
        private bool _esAdmin;

        // ── Constructor sin cambios para usuarios normales ────
        public FormNuevaReserva(int idUsuario)
            : this(idUsuario, false) { }

        // ── Constructor extendido para admin ──────────────────
        public FormNuevaReserva(int idUsuario, bool esAdmin)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _esAdmin = esAdmin;
        }

        private void FormNuevaReserva_Load(object sender, EventArgs e)
        {
            AplicarEstiloTabla(dgvAmbientes);
            CargarHorarios();
            dtpFecha.MinDate = DateTime.Today;
            dtpFechaFin.MinDate = DateTime.Today;

            // Panel "reservar en nombre de" — solo visible para admin
            pnlEnNombreDe.Visible = _esAdmin;
            if (_esAdmin)
                CargarUsuarios();
        }

        // ── Carga el combo de usuarios (solo admin) ───────────
        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string sql = @"
                        SELECT id_usuario,
                               nombre_completo + ' (' + tipo_usuario + ' — ' + codigo + ')' AS etiqueta
                        FROM   Usuario
                        WHERE  estado = 'activo'
                        ORDER  BY nombre_completo";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbUsuarioBeneficiario.DisplayMember = "etiqueta";
                    cmbUsuarioBeneficiario.ValueMember = "id_usuario";
                    cmbUsuarioBeneficiario.DataSource = dt;

                    // Preseleccionar al propio admin
                    foreach (DataRowView row in cmbUsuarioBeneficiario.Items)
                    {
                        if (Convert.ToInt32(row["id_usuario"]) == _idUsuario)
                        {
                            cmbUsuarioBeneficiario.SelectedItem = row;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        // ── ESTILO TABLA MINIMALISTA ──────────────────────────
        private static void AplicarEstiloTabla(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(230, 235, 243);
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 36;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TemaManager.TextoPrincipal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = TemaManager.TextoPrincipal;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding = new Padding(9, 0, 9, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TemaManager.TextoPrincipal;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(239, 243, 248);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(145, 155, 177);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 243, 248);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(145, 155, 177);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(9, 0, 9, 0);
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        // ── PINTURA: badge "disponible" en columna Estado ─────
        private void dgvAmbientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!dgvAmbientes.Columns.Contains("estado")) return;
            if (dgvAmbientes.Columns[e.ColumnIndex].Name != "estado") return;

            e.Handled = true;

            Color fondo = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(247, 249, 252);
            bool seleccionada = dgvAmbientes.Rows[e.RowIndex].Selected;
            if (seleccionada) fondo = Color.FromArgb(219, 234, 254);

            using (var br = new SolidBrush(fondo))
                e.Graphics.FillRectangle(br, e.CellBounds);
            using (var pen = new Pen(Color.FromArgb(230, 235, 243)))
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                         e.CellBounds.Right, e.CellBounds.Bottom - 1);

            string estado = Convert.ToString(e.Value);
            Color bgBadge = Color.FromArgb(220, 252, 231);
            Color fgBadge = Color.FromArgb(16, 185, 129);

            Size ts = TextRenderer.MeasureText(estado, new Font("Segoe UI Semibold", 8F, FontStyle.Bold));
            Rectangle badge = new Rectangle(
                e.CellBounds.Left + 9,
                e.CellBounds.Top + (e.CellBounds.Height - 22) / 2,
                ts.Width + 18, 22);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var gp = RoundedPath(badge, badge.Height))
            using (var b2 = new SolidBrush(bgBadge))
                e.Graphics.FillPath(b2, gp);

            TextRenderer.DrawText(e.Graphics, estado,
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                badge, fgBadge,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private GraphicsPath RoundedPath(Rectangle r, int radio)
        {
            int d = radio;
            var gp = new GraphicsPath();
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            gp.CloseFigure();
            return gp;
        }

        // ── HORARIOS ──────────────────────────────────────────
        private void CargarHorarios()
        {
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
            DayOfWeek dia = dtpFecha.Value.DayOfWeek;
            bool esFinDeSemana = dia == DayOfWeek.Saturday || dia == DayOfWeek.Sunday;

            cmbHoraInicio.Enabled = !esFinDeSemana;
            cmbHoraFin.Enabled = !esFinDeSemana;

            if (esFinDeSemana)
            {
                lblMensaje.Text = "⚠️ Fin de semana: ingresa el horario manualmente.";
                lblMensaje.ForeColor = Color.DarkOrange;
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

        // ── BUSCAR AMBIENTES ──────────────────────────────────
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
                    AplicarEstiloTabla(dgvAmbientes);

                    if (dt.Rows.Count == 0)
                    {
                        lblMensaje.Text = "⚠️ No hay ambientes disponibles para ese horario.";
                        lblMensaje.ForeColor = Color.DarkOrange;
                    }
                    else
                    {
                        lblMensaje.Text = $"✅ {dt.Rows.Count} ambiente(s) disponible(s). Selecciona uno y confirma.";
                        lblMensaje.ForeColor = Color.FromArgb(16, 185, 129);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar ambientes: " + ex.Message);
            }
        }

        // ── CONFIRMAR RESERVA ─────────────────────────────────
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

            // Determinar el usuario beneficiario
            int idBeneficiario;
            bool creadoPorAdmin;

            if (_esAdmin && cmbUsuarioBeneficiario.SelectedValue != null)
            {
                idBeneficiario = Convert.ToInt32(cmbUsuarioBeneficiario.SelectedValue);
                creadoPorAdmin = (idBeneficiario != _idUsuario);   // true solo si reserva para OTRO
            }
            else
            {
                idBeneficiario = _idUsuario;
                creadoPorAdmin = false;
            }

            int idAmbiente = Convert.ToInt32(dgvAmbientes.SelectedRows[0].Cells["id_ambiente"].Value);
            string ambiente = dgvAmbientes.SelectedRows[0].Cells["codigo"].Value.ToString();

            // Texto de confirmación diferenciado
            string lineaBeneficiario = creadoPorAdmin
                ? $"\nReservando para: {cmbUsuarioBeneficiario.Text}"
                : "";

            var confirm = MessageBox.Show(
                $"¿Confirmar reserva del ambiente {ambiente}?{lineaBeneficiario}\n\n" +
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
                             @esRecurrente, @frecuencia, 'activa', @creadoPorAdmin)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idUsuario", idBeneficiario);
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
                    cmd.Parameters.AddWithValue("@creadoPorAdmin", creadoPorAdmin ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }

                string msgExito = creadoPorAdmin
                    ? $"✅ Reserva registrada correctamente para {cmbUsuarioBeneficiario.Text}."
                    : "✅ Reserva registrada correctamente.";

                MessageBox.Show(msgExito, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la reserva: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}