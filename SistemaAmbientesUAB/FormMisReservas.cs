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
        private int _paginaActual = 1;
        private int _totalPaginas = 1;
        private DataTable _reservas = new DataTable();

        public FormMisReservas(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void FormMisReservas_Load(object sender, EventArgs e)
        {
            AplicarTema();
            AjustarLayoutResponsive();
            CargarReservas("Todas");
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

            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = TemaManager.Acento;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderColor = TemaManager.Borde;
            btnActualizar.FlatAppearance.BorderSize = 1;

            AplicarEstiloTabla();
        }

        private void AplicarEstiloTabla()
        {
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.GridColor = Color.FromArgb(230, 235, 243);
            dgvReservas.DefaultCellStyle.BackColor = Color.White;
            dgvReservas.DefaultCellStyle.ForeColor = TemaManager.TextoPrincipal;
            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvReservas.DefaultCellStyle.SelectionForeColor = TemaManager.TextoPrincipal;
            dgvReservas.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvReservas.DefaultCellStyle.Padding = new Padding(9, 0, 9, 0);
            dgvReservas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252);
            dgvReservas.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 252);
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

            panelAcciones.Left = margen;
            panelAcciones.Width = Math.Max(320, ClientSize.Width - margen * 2);
            panelAcciones.Height = altoAcciones;
            panelAcciones.Top = Math.Max(topTabla + 96, ClientSize.Height - altoAcciones - 12);

            panelTabla.Left = margen;
            panelTabla.Top = topTabla;
            panelTabla.Width = panelAcciones.Width;
            panelTabla.Height = Math.Max(96, panelAcciones.Top - panelTabla.Top - 10);

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
                    string whereEstado = filtro == "Todas" ? "" : "AND r.estado = @estado";
                    string buscar = ObtenerTextoBusqueda();
                    string whereBuscar = string.IsNullOrWhiteSpace(buscar)
                        ? ""
                        : @"AND (a.codigo LIKE @buscar
                              OR b.nombre LIKE @buscar
                              OR a.tipo LIKE @buscar
                              OR r.motivo LIKE @buscar
                              OR r.estado LIKE @buscar)";

                    string query = $@"
                        SELECT
                            r.id_reserva          AS ID,
                            a.codigo              AS Ambiente,
                            b.nombre              AS Bloque,
                            a.tipo                AS Tipo,
                            r.fecha_inicio        AS Fecha,
                            r.hora_inicio         AS [Hora Inicio],
                            r.hora_fin            AS [Hora Fin],
                            r.motivo              AS Motivo,
                            r.cantidad_asistentes AS Asistentes,
                            r.estado              AS Estado
                        FROM Reserva r
                        INNER JOIN Ambiente a ON r.id_ambiente = a.id_ambiente
                        INNER JOIN Bloque b   ON a.id_bloque   = b.id_bloque
                        WHERE r.id_usuario = @idUsuario {whereEstado} {whereBuscar}
                        ORDER BY r.fecha_inicio DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
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
            AgregarColumnasAccion();
            AjustarColumnas();
            AplicarEstiloTabla();
            ActualizarPaginacion(inicio, fin);
        }

        private void AgregarColumnasAccion()
        {
            if (dgvReservas.Columns.Contains("Editar")) return;

            // Columnas de solo-icono: el texto se pinta manualmente en CellPainting
            DataGridViewTextBoxColumn editar = new DataGridViewTextBoxColumn();
            editar.Name = "Editar";
            editar.HeaderText = "";
            editar.ReadOnly = true;
            editar.SortMode = DataGridViewColumnSortMode.NotSortable;
            editar.Width = 44;
            editar.MinimumWidth = 44;

            DataGridViewTextBoxColumn eliminar = new DataGridViewTextBoxColumn();
            eliminar.Name = "Eliminar";
            eliminar.HeaderText = "";
            eliminar.ReadOnly = true;
            eliminar.SortMode = DataGridViewColumnSortMode.NotSortable;
            eliminar.Width = 44;
            eliminar.MinimumWidth = 44;

            dgvReservas.Columns.Add(editar);
            dgvReservas.Columns.Add(eliminar);
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

        // ── PINTURA REDONDEADA: BOTONES DE PAGINACIÓN ────────────
        private void btnPaginacion_Paint(object sender, PaintEventArgs e)
        {
            Button boton = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(panelAcciones.BackColor == Color.Transparent ? Color.White : panelAcciones.BackColor);

            bool esActual = boton.Tag != null && Convert.ToInt32(boton.Tag) == _paginaActual && (boton.Name.StartsWith("btnPagina"));

            Rectangle rect = new Rectangle(0, 0, boton.Width - 1, boton.Height - 1);
            int radio = rect.Height; // circular

            Color fondo = esActual ? TemaManager.Acento : Color.White;
            Color borde = esActual ? TemaManager.Acento : Color.FromArgb(225, 231, 240);
            Color texto = esActual
                ? Color.White
                : (boton.Enabled ? TemaManager.TextoPrincipal : Color.FromArgb(195, 203, 219));

            using (GraphicsPath path = RoundedPath(rect, radio))
            {
                using (SolidBrush br = new SolidBrush(fondo))
                    e.Graphics.FillPath(br, path);

                using (Pen pen = new Pen(borde, 1f))
                    e.Graphics.DrawPath(pen, path);
            }

            TextRenderer.DrawText(
                e.Graphics,
                boton.Text,
                boton.Font,
                rect,
                texto,
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

        // ── PINTURA: BUSCADOR REDONDEADO ──────────────────────────
        private void panelBuscar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panelBuscar.Width - 1, panelBuscar.Height - 1);

            using (GraphicsPath path = RoundedPath(rect, rect.Height))
            using (Pen pen = new Pen(Color.FromArgb(225, 231, 240), 1f))
                e.Graphics.DrawPath(pen, path);
        }

        private string ObtenerTextoBusqueda()
        {
            string texto = txtBuscar.Text.Trim();
            return texto == BuscarPlaceholder ? "" : texto;
        }

        private void AjustarColumnas()
        {
            if (dgvReservas.Columns.Count == 0) return;

            dgvReservas.Columns["ID"].Visible = false;
            dgvReservas.Columns["Ambiente"].MinimumWidth = 88;
            dgvReservas.Columns["Bloque"].MinimumWidth = 72;
            dgvReservas.Columns["Tipo"].MinimumWidth = 100;
            dgvReservas.Columns["Fecha"].MinimumWidth = 95;
            dgvReservas.Columns["Hora Inicio"].MinimumWidth = 90;
            dgvReservas.Columns["Hora Fin"].MinimumWidth = 84;
            dgvReservas.Columns["Motivo"].MinimumWidth = 135;
            dgvReservas.Columns["Asistentes"].MinimumWidth = 80;
            dgvReservas.Columns["Estado"].MinimumWidth = 110;
            dgvReservas.Columns["Editar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvReservas.Columns["Eliminar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvReservas.Columns["Motivo"].FillWeight = 150;
            dgvReservas.Columns["Ambiente"].FillWeight = 82;
            dgvReservas.Columns["Bloque"].FillWeight = 70;
            dgvReservas.Columns["Estado"].FillWeight = 90;
        }

        private void dgvReservas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvReservas.Columns[e.ColumnIndex].Name;
            if (columnName == "Estado")
            {
                PintarBadgeEstado(e);
                return;
            }

            if (columnName == "Editar" || columnName == "Eliminar")
            {
                PintarIconoAccion(e, columnName);
            }
        }

        private void PintarBadgeEstado(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string estado = Convert.ToString(e.Value);
            Color fondo;
            Color texto;

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
                textSize.Width + 18,
                22);

            using (GraphicsPath path = RoundedPath(badge, badge.Height))
            using (SolidBrush brush = new SolidBrush(fondo))
                e.Graphics.FillPath(brush, path);

            TextRenderer.DrawText(
                e.Graphics,
                estado,
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                badge,
                texto,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // ── ICONOS DE ACCIÓN (Editar ✏ / Eliminar 🗑) ────────────
        private void PintarIconoAccion(DataGridViewCellPaintingEventArgs e, string columnName)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string estado = Convert.ToString(dgvReservas.Rows[e.RowIndex].Cells["Estado"].Value);
            bool activa = estado == "activa";

            string icono = columnName == "Editar" ? "✏" : "🗑";
            Color color = !activa
                ? Color.FromArgb(205, 212, 226)
                : (columnName == "Editar" ? TemaManager.Acento : TemaManager.Peligro);

            TextRenderer.DrawText(
                e.Graphics,
                icono,
                new Font("Segoe UI Emoji", 11F),
                e.CellBounds,
                color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void PintarFondoCelda(DataGridViewCellPaintingEventArgs e)
        {
            Color fondo = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(247, 249, 252);
            using (SolidBrush brush = new SolidBrush(fondo))
                e.Graphics.FillRectangle(brush, e.CellBounds);

            using (Pen pen = new Pen(Color.FromArgb(230, 235, 243)))
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
        }

        // Cursor de mano sobre los iconos de acción
        private void dgvReservas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string columnName = dgvReservas.Columns[e.ColumnIndex].Name;
            dgvReservas.Cursor = (columnName == "Editar" || columnName == "Eliminar")
                ? Cursors.Hand
                : Cursors.Default;
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvReservas.Columns[e.ColumnIndex].Name;
            if (columnName != "Editar" && columnName != "Eliminar") return;

            int idReserva = Convert.ToInt32(dgvReservas.Rows[e.RowIndex].Cells["ID"].Value);
            string estado = Convert.ToString(dgvReservas.Rows[e.RowIndex].Cells["Estado"].Value);

            if (columnName == "Editar")
                EditarReserva(idReserva, estado, e.RowIndex);
            else
                EliminarReserva(idReserva, estado);
        }

        private void EditarReserva(int idReserva, string estado, int rowIndex)
        {
            if (estado != "activa")
            {
                MessageBox.Show("Solo puedes editar reservas activas.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string motivoActual = Convert.ToString(dgvReservas.Rows[rowIndex].Cells["Motivo"].Value);
            string asistentesActual = Convert.ToString(dgvReservas.Rows[rowIndex].Cells["Asistentes"].Value);
            string motivo = Microsoft.VisualBasic.Interaction.InputBox(
                "Nuevo motivo:", "Editar reserva", motivoActual);
            if (string.IsNullOrWhiteSpace(motivo)) return;

            string asistentesTexto = Microsoft.VisualBasic.Interaction.InputBox(
                "Cantidad de asistentes:", "Editar reserva", asistentesActual);
            if (!int.TryParse(asistentesTexto, out int asistentes) || asistentes < 1)
            {
                MessageBox.Show("Ingresa una cantidad valida de asistentes.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE Reserva
                          SET motivo=@motivo, cantidad_asistentes=@asistentes
                          WHERE id_reserva=@id AND id_usuario=@idUsuario AND estado='activa'", con);
                    cmd.Parameters.AddWithValue("@motivo", motivo.Trim());
                    cmd.Parameters.AddWithValue("@asistentes", asistentes);
                    cmd.Parameters.AddWithValue("@id", idReserva);
                    cmd.Parameters.AddWithValue("@idUsuario", _idUsuario);
                    cmd.ExecuteNonQuery();
                }

                CargarReservas(cmbFiltroEstado.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void EliminarReserva(int idReserva, string estado)
        {
            if (estado != "activa")
            {
                MessageBox.Show("Solo puedes eliminar reservas activas.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "La reserva activa se marcara como cancelada. Deseas continuar?",
                "Eliminar reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string motivo = Microsoft.VisualBasic.Interaction.InputBox(
                "Motivo de eliminacion:", "Eliminar reserva", "");
            if (string.IsNullOrWhiteSpace(motivo)) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_CancelarReserva", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_reserva", idReserva);
                    cmd.Parameters.AddWithValue("@id_usuario_cancela", _idUsuario);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.ExecuteNonQuery();
                }

                CargarReservas(cmbFiltroEstado.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
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
        {
            _paginaActual--;
            AplicarPagina();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _paginaActual++;
            AplicarPagina();
        }

        private void btnPagina_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton?.Tag == null) return;

            _paginaActual = Convert.ToInt32(boton.Tag);
            AplicarPagina();
        }

        private void FormMisReservas_Resize(object sender, EventArgs e)
        {
            AjustarLayoutResponsive();
        }
    }
}