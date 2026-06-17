using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormEventoDetalle : Form
    {
        private int _idEvento;
        private int _idReservaExistente = 0;   // 0 = el evento aún no tiene reserva asociada

        public FormEventoDetalle(int idEvento)
        {
            InitializeComponent();
            _idEvento = idEvento;

            // 🔥 SOLUCIÓN RESPONSIVA: Fuerza a los botones a estar siempre al frente en la capa visual
            btnGuardar.BringToFront();
            btnCancelar.BringToFront();
        }

        private void FormEventoDetalle_Load(object sender, EventArgs e)
        {
            // Configurar títulos dinámicos
            this.Text = _idEvento == 0 ? "Nuevo Evento" : "Editar Evento";
            lblTitulo.Text = _idEvento == 0 ? "➕ Nuevo Evento" : "✏️ Editar Evento";

            // CAMBIO DINÁMICO: Texto del botón según la acción
            btnGuardar.Text = _idEvento == 0 ? "🚀 Crear Evento" : "💾 Confirmar Edición";

            dtpFechaEvento.MinDate = DateTime.Today;
            CargarHorarios();
            CargarResponsables();
            AplicarEstiloTablaAmbientes();

            if (_idEvento > 0)
            {
                CargarDatosEvento();
                // Si el evento ya tiene reserva, no permitimos duplicarla aquí
                chkCrearReserva.Checked = _idReservaExistente == 0;
                chkCrearReserva.Enabled = _idReservaExistente == 0;
                if (_idReservaExistente > 0)
                {
                    grpReserva.Visible = false;
                    lblMensajeReserva.Text = "Este evento ya tiene una reserva asociada. " +
                        "Gestiónala desde 'Mis Reservas'.";
                }
            }

            ActualizarVisibilidadReserva();
        }

        // ── CONTROL DE DISEÑO DINÁMICO (RESPONSIVE) ───────────
        private void ActualizarVisibilidadReserva()
        {
            bool mostrarReserva = chkCrearReserva.Checked && _idReservaExistente == 0;
            grpReserva.Visible = mostrarReserva;

            int margenInferior = 20;
            int espacioEntreControles = 15;

            // 🔥 CÁLCULO MATEMÁTICO: Posiciona los botones de acuerdo al contenedor visible
            if (mostrarReserva)
            {
                btnGuardar.Top = grpReserva.Bottom + espacioEntreControles;
                btnCancelar.Top = grpReserva.Bottom + espacioEntreControles;
            }
            else
            {
                btnGuardar.Top = chkCrearReserva.Bottom + espacioEntreControles;
                btnCancelar.Top = chkCrearReserva.Bottom + espacioEntreControles;
            }

            // 🔥 AJUSTE DE VENTANA AUTOMÁTICO: Adapta el alto total del Form según la posición del botón
            this.Height = btnGuardar.Bottom + margenInferior + SystemInformation.CaptionHeight + 15;
        }

        private void chkCrearReserva_CheckedChanged(object sender, EventArgs e) =>
            ActualizarVisibilidadReserva();

        private void dtpFechaEvento_ValueChanged(object sender, EventArgs e)
        {
            dgvAmbientes.DataSource = null;
            lblMensajeReserva.Text = "";
        }

        // ── COMBOS AUXILIARES ──────────────────────────────────
        private void CargarHorarios()
        {
            string[] horarios = {
                "07:15","08:00","08:55","09:40","10:35",
                "11:20","12:05","13:30","14:15","15:10",
                "15:55","16:50","17:35","18:20","19:00"
            };
            cmbHoraInicio.Items.Clear();
            cmbHoraFin.Items.Clear();
            cmbHoraInicio.Items.AddRange(horarios);
            cmbHoraFin.Items.AddRange(horarios);
        }

        private void CargarResponsables()
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

                    cmbResponsable.DisplayMember = "etiqueta";
                    cmbResponsable.ValueMember = "id_usuario";
                    cmbResponsable.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar responsables: " + ex.Message);
            }
        }

        private void AplicarEstiloTablaAmbientes()
        {
            dgvAmbientes.EnableHeadersVisualStyles = false;
            dgvAmbientes.BackgroundColor = System.Drawing.Color.White;
            dgvAmbientes.BorderStyle = BorderStyle.None;
            dgvAmbientes.RowHeadersVisible = false;
            dgvAmbientes.AllowUserToAddRows = false;
            dgvAmbientes.AllowUserToDeleteRows = false;
            dgvAmbientes.ReadOnly = true;
            dgvAmbientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAmbientes.MultiSelect = false;
            dgvAmbientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAmbientes.RowTemplate.Height = 30;
            dgvAmbientes.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        }

        // ── CARGAR DATOS EXISTENTES (modo edición) ─────────────
        private void CargarDatosEvento()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Evento WHERE id_evento = @id", con);
                    cmd.Parameters.AddWithValue("@id", _idEvento);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtNombreEvento.Text = dr["nombre_evento"].ToString();
                        nudAsistentes.Value = Convert.ToInt32(dr["cantidad_asistentes"]);
                        dtpFechaEvento.Value = Convert.ToDateTime(dr["fecha_evento"]);
                        txtRequerimientos.Text = dr["requerimientos"]?.ToString() ?? "";

                        int idResponsable = Convert.ToInt32(dr["id_responsable"]);
                        foreach (DataRowView row in cmbResponsable.Items)
                        {
                            if (Convert.ToInt32(row["id_usuario"]) == idResponsable)
                            {
                                cmbResponsable.SelectedItem = row;
                                break;
                            }
                        }
                    }
                    dr.Close();

                    SqlCommand cmdReserva = new SqlCommand("SELECT id_reserva FROM Reserva WHERE id_evento = @id", con);
                    cmdReserva.Parameters.AddWithValue("@id", _idEvento);
                    object resultado = cmdReserva.ExecuteScalar();
                    _idReservaExistente = resultado != null ? Convert.ToInt32(resultado) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el evento: " + ex.Message);
            }
        }

        // ── BUSCAR AMBIENTES DISPONIBLES ──
        private void btnBuscarAmbiente_Click(object sender, EventArgs e)
        {
            if (cmbHoraInicio.SelectedItem == null || cmbHoraFin.SelectedItem == null)
            {
                MessageBox.Show("Selecciona hora de inicio y fin.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_SugerirAmbientes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha_inicio", dtpFechaEvento.Value.Date);
                    cmd.Parameters.AddWithValue("@fecha_fin", dtpFechaEvento.Value.Date);
                    cmd.Parameters.AddWithValue("@hora_inicio", cmbHoraInicio.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@hora_fin", cmbHoraFin.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@capacidad_requerida", (int)nudAsistentes.Value);
                    cmd.Parameters.AddWithValue("@necesita_proyector", 0);
                    cmd.Parameters.AddWithValue("@necesita_computadoras", 0);
                    cmd.Parameters.AddWithValue("@necesita_enchufes", 0);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAmbientes.DataSource = dt;

                    lblMensajeReserva.Text = dt.Rows.Count == 0
                        ? "⚠️ No hay ambientes disponibles para ese horario."
                        : $"✅ {dt.Rows.Count} ambiente(s) disponible(s). Selecciona uno.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar ambientes: " + ex.Message);
            }
        }

        // ── GUARDAR / ACCIÓN PRINCIPAL ──
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEvento.Text))
            {
                MessageBox.Show("Ingresa el nombre del evento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbResponsable.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un responsable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool reservarAhora = chkCrearReserva.Checked && _idReservaExistente == 0;
            int idAmbienteSeleccionado = 0;

            if (reservarAhora)
            {
                if (dgvAmbientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Busca y selecciona un ambiente para la reserva, o desmarca la opción de reservar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbHoraInicio.SelectedItem == null || cmbHoraFin.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona hora de inicio y fin para la reserva.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idAmbienteSeleccionado = Convert.ToInt32(dgvAmbientes.SelectedRows[0].Cells["id_ambiente"].Value);
            }

            int idResponsable = Convert.ToInt32(cmbResponsable.SelectedValue);
            SqlConnection con = null;
            SqlTransaction tx = null;

            try
            {
                con = Conexion.ObtenerConexion();
                con.Open();
                tx = con.BeginTransaction();

                int idEventoFinal;

                if (_idEvento == 0)
                {
                    SqlCommand cmdIns = new SqlCommand(@"
                        INSERT INTO Evento (id_responsable, nombre_evento, cantidad_asistentes, requerimientos, fecha_evento)
                        OUTPUT INSERTED.id_evento
                        VALUES (@responsable, @nombre, @asistentes, @requerimientos, @fecha)", con, tx);

                    cmdIns.Parameters.AddWithValue("@responsable", idResponsable);
                    cmdIns.Parameters.AddWithValue("@nombre", txtNombreEvento.Text.Trim());
                    cmdIns.Parameters.AddWithValue("@asistentes", (int)nudAsistentes.Value);
                    cmdIns.Parameters.AddWithValue("@requerimientos", string.IsNullOrWhiteSpace(txtRequerimientos.Text) ? (object)DBNull.Value : txtRequerimientos.Text.Trim());
                    cmdIns.Parameters.AddWithValue("@fecha", dtpFechaEvento.Value.Date);

                    idEventoFinal = Convert.ToInt32(cmdIns.ExecuteScalar());
                }
                else
                {
                    SqlCommand cmdUpd = new SqlCommand(@"
                        UPDATE Evento
                        SET id_responsable = @responsable, nombre_evento = @nombre,
                            cantidad_asistentes = @asistentes, requerimientos = @requerimientos,
                            fecha_evento = @fecha
                        WHERE id_evento = @id", con, tx);

                    cmdUpd.Parameters.AddWithValue("@responsable", idResponsable);
                    cmdUpd.Parameters.AddWithValue("@nombre", txtNombreEvento.Text.Trim());
                    cmdUpd.Parameters.AddWithValue("@asistentes", (int)nudAsistentes.Value);
                    cmdUpd.Parameters.AddWithValue("@requerimientos", string.IsNullOrWhiteSpace(txtRequerimientos.Text) ? (object)DBNull.Value : txtRequerimientos.Text.Trim());
                    cmdUpd.Parameters.AddWithValue("@fecha", dtpFechaEvento.Value.Date);
                    cmdUpd.Parameters.AddWithValue("@id", _idEvento);
                    cmdUpd.ExecuteNonQuery();

                    idEventoFinal = _idEvento;
                }

                if (reservarAhora)
                {
                    SqlCommand cmdReserva = new SqlCommand(@"
                        INSERT INTO Reserva
                            (id_usuario, id_ambiente, id_evento, fecha_inicio, fecha_fin,
                             hora_inicio, hora_fin, motivo, cantidad_asistentes,
                             es_recurrente, frecuencia, estado, creado_por_admin)
                        VALUES
                            (@idUsuario, @idAmbiente, @idEvento, @fecha, @fecha,
                             @horaInicio, @horaFin, 'evento', @asistentes,
                             0, NULL, 'activa', 1)", con, tx);

                    cmdReserva.Parameters.AddWithValue("@idUsuario", idResponsable);
                    cmdReserva.Parameters.AddWithValue("@idAmbiente", idAmbienteSeleccionado);
                    cmdReserva.Parameters.AddWithValue("@idEvento", idEventoFinal);
                    cmdReserva.Parameters.AddWithValue("@fecha", dtpFechaEvento.Value.Date);
                    cmdReserva.Parameters.AddWithValue("@horaInicio", cmbHoraInicio.SelectedItem.ToString());
                    cmdReserva.Parameters.AddWithValue("@horaFin", cmbHoraFin.SelectedItem.ToString());
                    cmdReserva.Parameters.AddWithValue("@asistentes", (int)nudAsistentes.Value);
                    cmdReserva.ExecuteNonQuery();
                }

                tx.Commit();

                string msg = reservarAhora ? "✅ Evento y reserva registrados correctamente." : "✅ Evento guardado correctamente.";
                MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                try { tx?.Rollback(); } catch { }
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            finally
            {
                con?.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}