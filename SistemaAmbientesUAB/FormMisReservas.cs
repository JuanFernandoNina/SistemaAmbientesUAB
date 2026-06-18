using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormMisReservas : Form
    {
        private const string BuscarPlaceholder = "Buscar reserva...";
        private const int FilasPorPagina = 6;

        private int _idUsuario;
        private bool _esAdmin;
        private int _paginaActual = 1;
        private int _totalPaginas = 1;
        private DataTable _reservas = new DataTable();

        public FormMisReservas(int idUsuario)
            : this(idUsuario, false) { }

        public FormMisReservas(int idUsuario, bool esAdmin)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _esAdmin = esAdmin;

            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
        }

        private void FormMisReservas_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = _esAdmin ? "Todas las reservas" : "Mis reservas";

            AplicarTema();
            AjustarLayoutResponsive();
            CargarReservas("Todas");
            EvaluarEstadoBotonesAccion();
        }

        private void AplicarTema()
        {
            this.BackColor = Color.White;
            panelTabla.BackColor = Color.White;

            lblTitulo.ForeColor = TemaManager.TextoPrincipal;
            lblFiltro.ForeColor = TemaManager.TextoSecundario;
            lblEstado.ForeColor = TemaManager.TextoMuted;

            panelBuscar.BackColor = Color.White;
            txtBuscar.BackColor = Color.White;
            txtBuscar.ForeColor = TemaManager.TextoMuted;

            cmbFiltroEstado.BackColor = Color.White;
            cmbFiltroEstado.ForeColor = TemaManager.TextoPrincipal;
            cmbFiltroEstado.FlatStyle = FlatStyle.Flat;

            EstilarBotonBorde(btnActualizar, TemaManager.Acento);
            EstilarBotonBorde(btnEditar, TemaManager.Acento);
            EstilarBotonBorde(btnCancelarReserva, TemaManager.Peligro);
            EstilarBotonBorde(btnEliminar, Color.FromArgb(100, 116, 139)); // Gris pizarra elegante

            AplicarEstiloTabla();
        }

        private void EstilarBotonBorde(Button btn, Color colorTema)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = colorTema;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(220, 225, 235);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 248, 253);
            btn.Cursor = Cursors.Hand;
        }

        private void AplicarEstiloTabla()
        {
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.GridColor = Color.FromArgb(230, 235, 243);

            dgvReservas.DefaultCellStyle.BackColor = Color.White;
            dgvReservas.DefaultCellStyle.ForeColor = TemaManager.TextoPrincipal;
            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 244, 253);
            dgvReservas.DefaultCellStyle.SelectionForeColor = TemaManager.TextoPrincipal;
            dgvReservas.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvReservas.DefaultCellStyle.Padding = new Padding(9, 0, 9, 0);

            dgvReservas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252);
            dgvReservas.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 244, 253);
            dgvReservas.AlternatingRowsDefaultCellStyle.SelectionForeColor = TemaManager.TextoPrincipal;

            dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(239, 243, 248);
            dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(145, 155, 177);
            dgvReservas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 243, 248);
            dgvReservas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(145, 155, 177);
            dgvReservas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            dgvReservas.ColumnHeadersDefaultCellStyle.Padding = new Padding(9, 0, 9, 0);
        }

        private void AjustarLayoutResponsive()
        {
            int margen = 13;
            int altoAcciones = 48;
            int topTabla = 114;

            // Panel inferior de paginación y botones de operación
            panelAcciones.Left = margen;
            panelAcciones.Width = Math.Max(320, ClientSize.Width - margen * 2);
            panelAcciones.Height = altoAcciones;
            panelAcciones.Top = Math.Max(topTabla + 96, ClientSize.Height - altoAcciones - 12);

            panelTabla.Left = margen;
            panelTabla.Top = topTabla;
            panelTabla.Width = panelAcciones.Width;
            panelTabla.Height = Math.Max(96, panelAcciones.Top - panelTabla.Top - 10);

            // Acomodar botones numéricos de paginación a la derecha del panel inferior
            int x = panelAcciones.Width - 194;
            btnAnterior.Left = x;
            btnPagina1.Left = x + 40;
            btnPagina2.Left = x + 80;
            btnPagina3.Left = x + 120;
            btnSiguiente.Left = x + 160;
        }

        private void CargarReservas(string filtro)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string whereUsuario = _esAdmin ? "" : "AND r.id_usuario = @idUsuario";
                    string whereEstado = filtro == "Todas" ? "" : "AND r.estado = @estado";

                    string buscar = ObtenerTextoBusqueda();
                    string whereBuscar = string.IsNullOrWhiteSpace(buscar) ? "" : @"
                        AND (a.codigo              LIKE @buscar
                          OR b.nombre              LIKE @buscar
                          OR a.tipo                LIKE @buscar
                          OR r.motivo              LIKE @buscar
                          OR r.estado              LIKE @buscar
                          OR u.nombre_completo     LIKE @buscar)";

                    string colUsuario = _esAdmin ? "u.nombre_completo AS Usuario," : "";

                    string query = $@"
                        SELECT
                            r.id_reserva          AS ID,
                            {colUsuario}
                            a.codigo              AS Ambiente,
                            b.nombre              AS Bloque,
                            a.tipo                AS Tipo,
                            r.fecha_inicio        AS Fecha,
                            r.hora_inicio         AS [Hora Inicio],
                            r.hora_fin            AS [Hora Fin],
                            r.motivo              AS Motivo,
                            r.cantidad_asistentes AS Asistentes,
                            r.estado              AS Estado
                        FROM  Reserva r
                        INNER JOIN Ambiente a ON r.id_ambiente = a.id_ambiente
                        INNER JOIN Bloque   b ON a.id_bloque   = b.id_bloque
                        INNER JOIN Usuario  u ON r.id_usuario  = u.id_usuario
                        WHERE 1=1
                          {whereUsuario}
                          {whereEstado}
                          {whereBuscar}
                        ORDER BY r.fecha_inicio DESC";

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (!_esAdmin)
                        cmd.Parameters.AddWithValue("@idUsuario", _idUsuario);
                    if (filtro != "Todas")
                        cmd.Parameters.AddWithValue("@estado", filtro);
                    if (!string.IsNullOrWhiteSpace(buscar))
                        cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    _reservas = new DataTable();
                    da.Fill(_reservas);
                    _paginaActual = 1;
                    AplicarPagina();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }
        }

        private void AplicarPagina()
        {
            DataTable pagina = _reservas.Clone();
            _totalPaginas = Math.Max(1, (int)Math.Ceiling(_reservas.Rows.Count / (double)FilasPorPagina));
            _paginaActual = Math.Max(1, Math.Min(_paginaActual, _totalPaginas));

            int inicio = (_paginaActual - 1) * FilasPorPagina;
            int fin = Math.Min(inicio + FilasPorPagina, _reservas.Rows.Count);
            for (int i = inicio; i < fin; i++)
                pagina.ImportRow(_reservas.Rows[i]);

            dgvReservas.Columns.Clear();
            dgvReservas.DataSource = pagina;
            AjustarColumnas();
            AplicarEstiloTabla();
            ActualizarPaginacion(inicio, fin);
            EvaluarEstadoBotonesAccion();
        }

        private void ActualizarPaginacion(int inicio, int fin)
        {
            lblEstado.Text = _reservas.Rows.Count == 0
                ? "Showing 0 reservas"
                : $"Showing {inicio + 1} to {fin} of {_reservas.Rows.Count} reservas";

            int primera = Math.Max(1, Math.Min(_paginaActual - 1, Math.Max(1, _totalPaginas - 2)));
            ConfigurarBotonNumero(btnPagina1, primera);
            ConfigurarBotonNumero(btnPagina2, primera + 1);
            ConfigurarBotonNumero(btnPagina3, primera + 2);

            btnAnterior.Enabled = _paginaActual > 1;
            btnSiguiente.Enabled = _paginaActual < _totalPaginas;

            btnAnterior.Invalidate();
            btnSiguiente.Invalidate();
            btnPagina1.Invalidate();
            btnPagina2.Invalidate();
            btnPagina3.Invalidate();
        }

        private void ConfigurarBotonNumero(Button boton, int pagina)
        {
            boton.Text = pagina.ToString();
            boton.Tag = pagina;
            boton.Visible = pagina <= _totalPaginas;
            boton.Invalidate();
        }

        private void AjustarColumnas()
        {
            if (dgvReservas.Columns.Count == 0) return;

            dgvReservas.Columns["ID"].Visible = false;

            if (dgvReservas.Columns.Contains("Usuario"))
                dgvReservas.Columns["Usuario"].MinimumWidth = 140;

            dgvReservas.Columns["Ambiente"].MinimumWidth = 88;
            dgvReservas.Columns["Bloque"].MinimumWidth = 72;
            dgvReservas.Columns["Tipo"].MinimumWidth = 100;
            dgvReservas.Columns["Fecha"].MinimumWidth = 95;
            dgvReservas.Columns["Hora Inicio"].MinimumWidth = 90;
            dgvReservas.Columns["Hora Fin"].MinimumWidth = 84;
            dgvReservas.Columns["Motivo"].MinimumWidth = 135;
            dgvReservas.Columns["Asistentes"].MinimumWidth = 80;
            dgvReservas.Columns["Estado"].MinimumWidth = 110;

            dgvReservas.Columns["Motivo"].FillWeight = 150;
            dgvReservas.Columns["Ambiente"].FillWeight = 82;
            dgvReservas.Columns["Bloque"].FillWeight = 70;
            dgvReservas.Columns["Estado"].FillWeight = 90;
        }

        private void dgvReservas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string col = dgvReservas.Columns[e.ColumnIndex].Name;
            if (col == "Estado") { PintarBadgeEstado(e); return; }
        }

        private void PintarBadgeEstado(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string estado = Convert.ToString(e.Value);
            Color fondo, texto;

            if (estado == "activa")
            {
                fondo = Color.FromArgb(220, 252, 231);
                texto = Color.FromArgb(16, 185, 129);
            }
            else if (estado == "cancelada")
            {
                fondo = Color.FromArgb(254, 226, 226);
                texto = Color.FromArgb(239, 68, 68);
            }
            else
            {
                fondo = Color.FromArgb(254, 243, 199);
                texto = Color.FromArgb(245, 158, 11);
            }

            Size textSize = TextRenderer.MeasureText(estado, new Font("Segoe UI Semibold", 8F, FontStyle.Bold));
            Rectangle badge = new Rectangle(
                e.CellBounds.Left + 10,
                e.CellBounds.Top + (e.CellBounds.Height - 22) / 2,
                textSize.Width + 18, 22);

            using (GraphicsPath path = RoundedPath(badge, badge.Height))
            using (SolidBrush brush = new SolidBrush(fondo))
                e.Graphics.FillPath(brush, path);

            TextRenderer.DrawText(e.Graphics, estado,
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                badge, texto,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void PintarFondoCelda(DataGridViewCellPaintingEventArgs e)
        {
            Color fondo = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(247, 249, 252);
            using (SolidBrush brush = new SolidBrush(fondo))
                e.Graphics.FillRectangle(brush, e.CellBounds);
            using (Pen pen = new Pen(Color.FromArgb(230, 235, 243)))
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                         e.CellBounds.Right, e.CellBounds.Bottom - 1);
        }

        private void EvaluarEstadoBotonesAccion()
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnCancelarReserva.Enabled = false;
                btnEliminar.Enabled = false;
                return;
            }

            // Validamos el estado ignorando espacios vacíos y asegurando minúsculas
            string estado = Convert.ToString(dgvReservas.SelectedRows[0].Cells["Estado"].Value).Trim().ToLower();

            // Si el estado es "activa", habilitamos editar y cancelar
            bool esActiva = (estado == "activa");

            btnEditar.Enabled = esActiva;
            btnCancelarReserva.Enabled = esActiva;
            btnEliminar.Enabled = true;
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            EvaluarEstadoBotonesAccion();
        }

        // ── BOTONES DE ACCIONES FÍSICOS (CORREGIDOS CON DETECCIÓN DE ERRORES) ────────────────────────
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReservas.SelectedRows.Count == 0) return;

                int rowIndex = dgvReservas.SelectedRows[0].Index;
                int idReserva = Convert.ToInt32(dgvReservas.Rows[rowIndex].Cells["ID"].Value);
                string estado = Convert.ToString(dgvReservas.Rows[rowIndex].Cells["Estado"].Value).Trim().ToLower();

                if (estado != "activa")
                {
                    MessageBox.Show("Solo puedes editar reservas que se encuentren en estado 'activa'.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FormDetalleMisReservas frmDetalle = new FormDetalleMisReservas(idReserva, false);
                if (frmDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarReservas(cmbFiltroEstado.SelectedItem?.ToString() ?? "Todas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar abrir la ventana de edición:\n" + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReservas.SelectedRows.Count == 0) return;

                int rowIndex = dgvReservas.SelectedRows[0].Index;
                int idReserva = Convert.ToInt32(dgvReservas.Rows[rowIndex].Cells["ID"].Value);
                string estado = Convert.ToString(dgvReservas.Rows[rowIndex].Cells["Estado"].Value).Trim().ToLower();

                if (estado != "activa")
                {
                    MessageBox.Show("Esta reserva ya no se encuentra activa para ser cancelada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FormDetalleMisReservas frmCancelar = new FormDetalleMisReservas(idReserva, true);
                if (frmCancelar.ShowDialog() == DialogResult.OK)
                {
                    CargarReservas(cmbFiltroEstado.SelectedItem?.ToString() ?? "Todas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar abrir la ventana de cancelación:\n" + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0) return;

            int rowIndex = dgvReservas.SelectedRows[0].Index;
            int idReserva = Convert.ToInt32(dgvReservas.Rows[rowIndex].Cells["ID"].Value);

            if (MessageBox.Show("¿Está completamente seguro de ELIMINAR permanentemente esta reserva?\nSi la reserva fue cancelada, se borrará también su historial de cancelación.",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    using (SqlTransaction transaccion = con.BeginTransaction())
                    {
                        try
                        {
                            // 1. Eliminamos primero de la tabla hija 'Cancelacion' para evitar el error de Foreign Key
                            string queryHijo = "DELETE FROM Cancelacion WHERE id_reserva = @id";
                            using (SqlCommand cmdHijo = new SqlCommand(queryHijo, con, transaccion))
                            {
                                cmdHijo.Parameters.AddWithValue("@id", idReserva);
                                cmdHijo.ExecuteNonQuery();
                            }

                            // 2. Ahora sí, borramos la reserva principal de forma segura
                            string queryPadre = "DELETE FROM Reserva WHERE id_reserva = @id";
                            using (SqlCommand cmdPadre = new SqlCommand(queryPadre, con, transaccion))
                            {
                                cmdPadre.Parameters.AddWithValue("@id", idReserva);
                                cmdPadre.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            MessageBox.Show("La reserva y sus registros asociados fueron eliminados con éxito.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exTrans)
                        {
                            transaccion.Rollback();
                            throw new Exception("No se pudo completar la transacción de borrado: " + exTrans.Message);
                        }
                    }
                }
                CargarReservas(cmbFiltroEstado.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al eliminar la reserva: " + ex.Message,
                    "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ── PINTURA Y RENDERIZADO CUSTOM ──────────────────────
        private void btnPaginacion_Paint(object sender, PaintEventArgs e)
        {
            Button boton = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            bool esActual = boton.Tag != null
                && Convert.ToInt32(boton.Tag) == _paginaActual
                && boton.Name.StartsWith("btnPagina");

            Rectangle rect = new Rectangle(0, 0, boton.Width - 1, boton.Height - 1);
            Color fondo = esActual ? TemaManager.Acento : Color.White;
            Color borde = esActual ? TemaManager.Acento : Color.FromArgb(225, 231, 240);
            Color textoColor = esActual
                ? Color.White
                : (boton.Enabled ? TemaManager.TextoPrincipal : Color.FromArgb(195, 203, 219));

            using (GraphicsPath path = RoundedPath(rect, rect.Height))
            {
                using (SolidBrush br = new SolidBrush(fondo))
                    e.Graphics.FillPath(br, path);
                using (Pen pen = new Pen(borde, 1f))
                    e.Graphics.DrawPath(pen, path);
            }

            TextRenderer.DrawText(e.Graphics, boton.Text, boton.Font, rect, textoColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void panelBuscar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panelBuscar.Width - 1, panelBuscar.Height - 1);
            using (GraphicsPath path = RoundedPath(rect, rect.Height))
            using (Pen pen = new Pen(Color.FromArgb(225, 231, 240), 1f))
                e.Graphics.DrawPath(pen, path);
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

        private string ObtenerTextoBusqueda()
        {
            string texto = txtBuscar.Text.Trim();
            return texto == BuscarPlaceholder ? "" : texto;
        }

        private void btnActualizar_Click(object sender, EventArgs e) =>
            CargarReservas(cmbFiltroEstado.SelectedItem.ToString());

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) =>
            CargarReservas(cmbFiltroEstado.SelectedItem.ToString());

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == BuscarPlaceholder) return;
            CargarReservas(cmbFiltroEstado.SelectedItem.ToString());
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text != BuscarPlaceholder) return;
            txtBuscar.Text = "";
            txtBuscar.ForeColor = TemaManager.TextoPrincipal;
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            txtBuscar.Text = BuscarPlaceholder;
            txtBuscar.ForeColor = TemaManager.TextoMuted;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        { _paginaActual--; AplicarPagina(); }

        private void btnSiguiente_Click(object sender, EventArgs e)
        { _paginaActual++; AplicarPagina(); }

        private void btnPagina_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton?.Tag == null) return;
            _paginaActual = Convert.ToInt32(boton.Tag);
            AplicarPagina();
        }

        private void FormMisReservas_Resize(object sender, EventArgs e) =>
            AjustarLayoutResponsive();
    }
}