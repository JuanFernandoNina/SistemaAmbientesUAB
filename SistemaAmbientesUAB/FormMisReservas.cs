using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormMisReservas : Form
    {
        private int _idUsuario;
        private bool _esAdmin;

        // Tabla completa cargada desde BD (sin paginar)
        private DataTable _tablaDatos = new DataTable();

        // Paginación
        private int _paginaActual = 1;
        private const int FILAS_POR_PAGINA = 10;
        private int _totalPaginas = 1;

        public FormMisReservas(int idUsuario, bool esAdmin)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _esAdmin = esAdmin;
        }

        // ── CARGA INICIAL ────────────────────────────────────────────────────────────
        private void FormMisReservas_Load(object sender, EventArgs e)
        {
            // Estilo cabecera grilla
            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 236, 247);
            dgvReservas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(28, 37, 58);
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgvReservas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);

            // Título dinámico según rol
            lblTitulo.Text = _esAdmin ? "Todas las reservas" : "Mis reservas";

            // Ocultar Eliminar si no es admin
            btnEliminar.Visible = _esAdmin;

            CargarReservas();
        }

        // ── CARGA DESDE BASE DE DATOS ────────────────────────────────────────────────
        private void CargarReservas()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    // Admin ve todas; los demás solo las propias
                    string whereUsuario = _esAdmin ? "" : "WHERE r.id_usuario = @idUsuario";

                    string query = $@"
                        SELECT
                            r.id_reserva        AS [ID],
                            u.nombre_completo   AS [Usuario],
                            a.codigo            AS [Ambiente],
                            a.tipo              AS [Tipo],
                            r.fecha_inicio      AS [Fecha Inicio],
                            r.fecha_fin         AS [Fecha Fin],
                            r.hora_inicio       AS [Hora Inicio],
                            r.hora_fin          AS [Hora Fin],
                            r.motivo            AS [Motivo],
                            r.cantidad_asistentes AS [Asistentes],
                            r.estado            AS [Estado],
                            r.fecha_creacion    AS [Creado]
                        FROM Reserva r
                        INNER JOIN Usuario  u ON u.id_usuario  = r.id_usuario
                        INNER JOIN Ambiente a ON a.id_ambiente = r.id_ambiente
                        {whereUsuario}
                        ORDER BY r.fecha_creacion DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (!_esAdmin)
                        cmd.Parameters.AddWithValue("@idUsuario", _idUsuario);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    _tablaDatos = new DataTable();
                    da.Fill(_tablaDatos);
                }

                AplicarFiltroYPaginar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── FILTRADO + PAGINACIÓN ────────────────────────────────────────────────────
        private void AplicarFiltroYPaginar()
        {
            string filtroEstado = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todas";
            string textoBuscar = txtBuscar.Text.Trim();
            bool busquedaActiva = textoBuscar != "" && textoBuscar != "Buscar reserva...";

            // Construir filtro para DataView
            string filtro = "";

            if (filtroEstado != "Todas")
                filtro = $"Estado = '{filtroEstado}'";

            if (busquedaActiva)
            {
                string b = textoBuscar.Replace("'", "''");
                string filtroTexto = $"(Convert([ID], 'System.String') LIKE '%{b}%'" +
                                     $" OR Usuario LIKE '%{b}%'" +
                                     $" OR Ambiente LIKE '%{b}%'" +
                                     $" OR Motivo LIKE '%{b}%'" +
                                     $" OR Estado LIKE '%{b}%')";
                filtro = filtro == "" ? filtroTexto : $"({filtro}) AND {filtroTexto}";
            }

            DataView dv = new DataView(_tablaDatos);
            if (filtro != "") dv.RowFilter = filtro;

            DataTable tablaFiltrada = dv.ToTable();
            int totalFilas = tablaFiltrada.Rows.Count;
            _totalPaginas = Math.Max(1, (int)Math.Ceiling(totalFilas / (double)FILAS_POR_PAGINA));
            if (_paginaActual > _totalPaginas) _paginaActual = _totalPaginas;

            // Recortar página
            int inicio = (_paginaActual - 1) * FILAS_POR_PAGINA;
            DataTable paginada = tablaFiltrada.Clone();
            for (int i = inicio; i < Math.Min(inicio + FILAS_POR_PAGINA, totalFilas); i++)
                paginada.ImportRow(tablaFiltrada.Rows[i]);

            dgvReservas.DataSource = paginada;
            AplicarEstiloFilas();

            // Ocultar columna ID (la usamos internamente)
            if (dgvReservas.Columns["ID"] != null)
                dgvReservas.Columns["ID"].Visible = false;

            // Etiqueta estado
            int desde = totalFilas == 0 ? 0 : inicio + 1;
            int hasta = Math.Min(inicio + FILAS_POR_PAGINA, totalFilas);
            lblEstado.Text = $"Mostrando {desde}–{hasta} de {totalFilas} reservas";

            ActualizarBotonesPaginacion(totalFilas);
        }

        // ── COLORES POR ESTADO EN FILAS ──────────────────────────────────────────────
        private void AplicarEstiloFilas()
        {
            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                if (row.IsNewRow) continue;
                string estado = row.Cells["Estado"].Value?.ToString() ?? "";
                switch (estado)
                {
                    case "activa":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(6, 95, 70);
                        break;
                    case "cancelada":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(146, 64, 14);
                        break;
                    case "finalizada":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
                        break;
                }
            }
        }

        // ── OBTENER ID RESERVA SELECCIONADA ─────────────────────────────────────────
        private int ObtenerIdReservaSeleccionada()
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reserva primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            return Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ID"].Value);
        }

        private string ObtenerEstadoSeleccionado()
        {
            if (dgvReservas.SelectedRows.Count == 0) return "";
            return dgvReservas.SelectedRows[0].Cells["Estado"].Value?.ToString() ?? "";
        }

        // ── BOTÓN CANCELAR ───────────────────────────────────────────────────────────
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            int idReserva = ObtenerIdReservaSeleccionada();
            if (idReserva == -1) return;

            if (ObtenerEstadoSeleccionado() != "activa")
            {
                MessageBox.Show("Solo se pueden cancelar reservas con estado 'activa'.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abrir formulario de detalle/cancelación
            var frm = new FormDetalleMisReservas(idReserva, esCancelacion: true);
            frm.ShowDialog();
            CargarReservas(); // Recargar tras volver
        }

        // ── BOTÓN ELIMINAR (solo admin) ──────────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idReserva = ObtenerIdReservaSeleccionada();
            if (idReserva == -1) return;

            var confirm = MessageBox.Show(
                $"¿Eliminar definitivamente la reserva #{idReserva}?\n\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            // Primero eliminar cancelaciones relacionadas (FK)
                            SqlCommand delCan = new SqlCommand(
                                "DELETE FROM Cancelacion WHERE id_reserva = @id", con, tx);
                            delCan.Parameters.AddWithValue("@id", idReserva);
                            delCan.ExecuteNonQuery();

                            // Luego eliminar la reserva
                            SqlCommand delRes = new SqlCommand(
                                "DELETE FROM Reserva WHERE id_reserva = @id", con, tx);
                            delRes.Parameters.AddWithValue("@id", idReserva);
                            delRes.ExecuteNonQuery();

                            tx.Commit();
                            MessageBox.Show("Reserva eliminada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la reserva:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── BOTÓN EDITAR ─────────────────────────────────────────────────────────────
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idReserva = ObtenerIdReservaSeleccionada();
            if (idReserva == -1) return;

            var frm = new FormDetalleMisReservas(idReserva, esCancelacion: false);
            frm.ShowDialog();
            CargarReservas();
        }

        // ── FILTROS Y BÚSQUEDA ───────────────────────────────────────────────────────
        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            _paginaActual = 1;
            AplicarFiltroYPaginar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar reserva...") return;
            _paginaActual = 1;
            AplicarFiltroYPaginar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _paginaActual = 1;
            CargarReservas();
        }

        // ── PAGINACIÓN ───────────────────────────────────────────────────────────────
        private void ActualizarBotonesPaginacion(int totalFilas)
        {
            btnAnterior.Enabled = _paginaActual > 1;
            btnSiguiente.Enabled = _paginaActual < _totalPaginas;

            // Botones de página numerada
            Button[] pagBtns = { btnPagina1, btnPagina2, btnPagina3 };
            int inicio = Math.Max(1, _paginaActual - 1);
            if (inicio + 2 > _totalPaginas) inicio = Math.Max(1, _totalPaginas - 2);

            for (int i = 0; i < pagBtns.Length; i++)
            {
                int numPag = inicio + i;
                pagBtns[i].Visible = numPag <= _totalPaginas;
                pagBtns[i].Text = numPag.ToString();
                pagBtns[i].Tag = numPag;
                bool activa = numPag == _paginaActual;
                pagBtns[i].BackColor = activa ? Color.FromArgb(39, 85, 166) : Color.White;
                pagBtns[i].ForeColor = activa ? Color.White : Color.FromArgb(28, 37, 58);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_paginaActual > 1) { _paginaActual--; AplicarFiltroYPaginar(); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (_paginaActual < _totalPaginas) { _paginaActual++; AplicarFiltroYPaginar(); }
        }

        private void btnPagina_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int pag)
            {
                _paginaActual = pag;
                AplicarFiltroYPaginar();
            }
        }

        // ── PAINT Y RESIZE ───────────────────────────────────────────────────────────
        private void panelBuscar_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, panelBuscar.Width - 1, panelBuscar.Height - 1);
            using (Pen pen = new Pen(Color.FromArgb(218, 224, 233), 1f))
                e.Graphics.DrawRectangle(pen, rect);
        }

        private void dgvReservas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                e.Handled = false;
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e) { }
        private void FormMisReservas_Resize(object sender, EventArgs e) { }

        // ── PLACEHOLDER BUSCADOR ─────────────────────────────────────────────────────
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar reserva...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.FromArgb(28, 37, 58);
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar reserva...";
                txtBuscar.ForeColor = Color.FromArgb(150, 161, 184);
            }
        }
    }
}