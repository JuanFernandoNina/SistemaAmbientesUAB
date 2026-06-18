using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormReportes : Form
    {
        private string _tipoActual = "ambientes";

        // ── Filtro de rango de fechas (null = sin filtro, se muestra todo) ──
        private DateTime? _fechaDesde = null;
        private DateTime? _fechaHasta = null;

        // ── Datos del reporte actualmente cargado (para exportar) ──────────
        private DataTable _dtReporteActual;

        // ── Control de paginación al imprimir/exportar a PDF ────────────────
        private int _printRowIndex = 0;

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarReporte("ambientes");
        }

        // ── TEMA MINIMALISTA MANTENIDO ────────────────────────
        private void AplicarTema()
        {
            this.BackColor = Color.White;
            panelBotones.BackColor = Color.FromArgb(247, 249, 252);

            lblTitulo.ForeColor = TemaManager.TextoPrincipal;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSubtitulo.ForeColor = TemaManager.TextoPrincipal;
            lblSubtitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.ForeColor = TemaManager.TextoMuted;

            AplicarEstiloTabla(dgvReporte);

            // Botones de reporte como tabs/pills
            Button[] bots = { btnAmbientesMasUsados, btnReservasCanceladas,
                               this.btnDisponibilidad, btnUsoPorCarrera, btnTodasReservas };
            foreach (var b in bots)
                EstiloBotonTab(b, false);

            // Panel de filtro de fecha
            panelFiltroFecha.BackColor = Color.White;
            lblFiltroFecha.ForeColor = TemaManager.TextoSecundario;
            lblFiltroFechaGuion.ForeColor = TemaManager.TextoSecundario;

            btnAplicarFiltroFecha.BackColor = TemaManager.Acento;
            btnAplicarFiltroFecha.ForeColor = Color.White;
            btnAplicarFiltroFecha.FlatStyle = FlatStyle.Flat;
            btnAplicarFiltroFecha.FlatAppearance.BorderSize = 0;
            btnAplicarFiltroFecha.Cursor = Cursors.Hand;

            btnQuitarFiltroFecha.BackColor = Color.White;
            btnQuitarFiltroFecha.ForeColor = TemaManager.TextoSecundario;
            btnQuitarFiltroFecha.FlatStyle = FlatStyle.Flat;
            btnQuitarFiltroFecha.FlatAppearance.BorderColor = TemaManager.Borde;
            btnQuitarFiltroFecha.FlatAppearance.BorderSize = 1;
            btnQuitarFiltroFecha.Cursor = Cursors.Hand;

            btnExportarExcel.BackColor = Color.FromArgb(33, 128, 83);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.Cursor = Cursors.Hand;

            btnExportarPdf.BackColor = Color.FromArgb(178, 34, 34);
            btnExportarPdf.ForeColor = Color.White;
            btnExportarPdf.FlatStyle = FlatStyle.Flat;
            btnExportarPdf.FlatAppearance.BorderSize = 0;
            btnExportarPdf.Cursor = Cursors.Hand;
        }

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

        private static void EstiloBotonTab(Button btn, bool activo)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 9F, activo ? FontStyle.Bold : FontStyle.Regular);

            if (activo)
            {
                btn.BackColor = TemaManager.Acento;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                btn.BackColor = Color.White;
                btn.ForeColor = TemaManager.TextoSecundario;
                btn.FlatAppearance.BorderColor = Color.FromArgb(225, 231, 240);
                btn.FlatAppearance.BorderSize = 1;
            }
        }

        // ── CARGA DE REPORTES ─────────────────────────────────
        private void CargarReporte(string tipo)
        {
            _tipoActual = tipo;
            string query = "", subtitulo = "";

            bool aplicaFiltroFecha = tipo != "disponibilidad";
            bool filtroActivo = aplicaFiltroFecha && _fechaDesde.HasValue && _fechaHasta.HasValue;

            switch (tipo)
            {
                case "ambientes":
                    subtitulo = "🏆 Ambientes más utilizados";
                    query = $@"SELECT a.codigo AS Código, b.nombre AS Bloque, a.tipo AS Tipo,
                                      a.capacidad AS Capacidad, COUNT(r.id_reserva) AS [Total Reservas]
                               FROM Reserva r
                               INNER JOIN Ambiente a ON r.id_ambiente=a.id_ambiente
                               INNER JOIN Bloque b ON a.id_bloque=b.id_bloque
                               WHERE r.estado<>'cancelada'
                                 {(filtroActivo ? "AND r.fecha_inicio BETWEEN @desde AND @hasta" : "")}
                               GROUP BY a.codigo,b.nombre,a.tipo,a.capacidad
                               ORDER BY [Total Reservas] DESC";
                    break;

                case "cancelaciones":
                    subtitulo = "❌ Historial de cancelaciones";
                    query = $@"SELECT r.id_reserva AS [ID Reserva], u.nombre_completo AS Solicitante,
                                      a.codigo AS Ambiente, CONVERT(VARCHAR,r.fecha_inicio,103) AS Fecha,
                                      r.motivo AS Motivo, uc.nombre_completo AS [Cancelado por],
                                      CONVERT(VARCHAR,c.fecha_cancelacion,103) AS [Fecha Cancelación],
                                      c.motivo_cancelacion AS [Motivo Cancelación]
                               FROM Cancelacion c
                               INNER JOIN Reserva r  ON c.id_reserva=r.id_reserva
                               INNER JOIN Usuario u  ON r.id_usuario=u.id_usuario
                               INNER JOIN Ambiente a ON r.id_ambiente=a.id_ambiente
                               INNER JOIN Usuario uc ON c.id_usuario_cancela=uc.id_usuario
                               WHERE 1=1
                                 {(filtroActivo ? "AND CAST(c.fecha_cancelacion AS DATE) BETWEEN @desde AND @hasta" : "")}
                               ORDER BY c.fecha_cancelacion DESC";
                    break;

                case "disponibilidad":
                    subtitulo = "📅 Ambientes disponibles hoy";
                    query = @"SELECT a.codigo AS Código, b.nombre AS Bloque, a.tipo AS Tipo,
                                      a.capacidad AS Capacidad,
                                      CASE WHEN a.tiene_proyector=1 THEN '✅' ELSE '❌' END AS Proyector,
                                      CASE WHEN a.tiene_computadoras=1 THEN '✅' ELSE '❌' END AS Computadoras,
                                      a.estado AS Estado
                               FROM Ambiente a
                               INNER JOIN Bloque b ON a.id_bloque=b.id_bloque
                               WHERE a.estado='disponible'
                                 AND a.id_ambiente NOT IN (
                                     SELECT id_ambiente FROM Reserva
                                     WHERE estado='activa'
                                       AND fecha_inicio<=CAST(GETDATE() AS DATE)
                                       AND fecha_fin>=CAST(GETDATE() AS DATE))
                               ORDER BY b.nombre, a.codigo";
                    break;

                case "carrera":
                    subtitulo = "🎓 Uso de ambientes por carrera/área";
                    query = $@"SELECT ISNULL(u.carrera_area,'Sin especificar') AS [Carrera/Área],
                                      u.tipo_usuario AS [Tipo Usuario],
                                      COUNT(r.id_reserva) AS [Total Reservas],
                                      COUNT(DISTINCT r.id_ambiente) AS [Ambientes distintos]
                               FROM Reserva r
                               INNER JOIN Usuario u ON r.id_usuario=u.id_usuario
                               WHERE r.estado<>'cancelada'
                                 {(filtroActivo ? "AND r.fecha_inicio BETWEEN @desde AND @hasta" : "")}
                               GROUP BY u.carrera_area, u.tipo_usuario
                               ORDER BY [Total Reservas] DESC";
                    break;

                case "todas":
                    subtitulo = "📋 Todas las reservas del sistema";
                    query = $@"SELECT r.id_reserva AS ID, u.nombre_completo AS Solicitante,
                                      a.codigo AS Ambiente, b.nombre AS Bloque,
                                      CONVERT(VARCHAR,r.fecha_inicio,103) AS [Fecha Inicio],
                                      CONVERT(VARCHAR(5),r.hora_inicio,108) AS [Hora Ini],
                                      CONVERT(VARCHAR(5),r.hora_fin,108) AS [Hora Fin],
                                      r.motivo AS Motivo, r.cantidad_asistentes AS Asistentes,
                                      CASE WHEN r.es_recurrente=1 THEN '✅' ELSE '❌' END AS Recurrente,
                                      r.estado AS Estado
                               FROM Reserva r
                               INNER JOIN Usuario u  ON r.id_usuario=u.id_usuario
                               INNER JOIN Ambiente a ON r.id_ambiente=a.id_ambiente
                               INNER JOIN Bloque b   ON a.id_bloque=b.id_bloque
                               WHERE 1=1
                                 {(filtroActivo ? "AND r.fecha_inicio BETWEEN @desde AND @hasta" : "")}
                               ORDER BY r.fecha_inicio DESC, r.hora_inicio";
                    break;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    if (filtroActivo)
                    {
                        cmd.Parameters.AddWithValue("@desde", _fechaDesde.Value.Date);
                        cmd.Parameters.AddWithValue("@hasta", _fechaHasta.Value.Date);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReporte.DataSource = dt;
                    _dtReporteActual = dt;
                    lblSubtitulo.Text = subtitulo;
                    lblTotal.Text = filtroActivo
                        ? $"Mostrando {dt.Rows.Count} registro(s) — del {_fechaDesde:dd/MM/yyyy} al {_fechaHasta:dd/MM/yyyy}"
                        : $"Mostrando {dt.Rows.Count} registro(s)";

                    ActualizarBotonesTab(tipo);
                    ActualizarEstadoFiltroFecha(tipo);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar reporte: " + ex.Message); }
        }

        private void ActualizarEstadoFiltroFecha(string tipo)
        {
            bool aplica = tipo != "disponibilidad";

            dtpDesde.Enabled = aplica;
            dtpHasta.Enabled = aplica;
            btnAplicarFiltroFecha.Enabled = aplica;
            btnQuitarFiltroFecha.Enabled = aplica && (_fechaDesde.HasValue || _fechaHasta.HasValue);

            lblFiltroFecha.Text = aplica
                ? "Rango de fechas:"
                : "Filtro no aplicable (Muestra estado actual)";
        }

        private void ActualizarBotonesTab(string tipoActivo)
        {
            EstiloBotonTab(btnAmbientesMasUsados, tipoActivo == "ambientes");
            EstiloBotonTab(btnReservasCanceladas, tipoActivo == "cancelaciones");
            EstiloBotonTab(btnDisponibilidad, tipoActivo == "disponibilidad");
            EstiloBotonTab(btnUsoPorCarrera, tipoActivo == "carrera");
            EstiloBotonTab(btnTodasReservas, tipoActivo == "todas");
        }

        // ── PINTURA DE CELDAS (BADGES RE-ESTILIZADOS) ─────────
        private void dgvReporte_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvReporte.Columns[e.ColumnIndex].Name;
            if (col == "Estado") PintarBadgeEstado(e);
        }

        private void PintarBadgeEstado(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string estado = Convert.ToString(e.Value);
            Color fondo, texto;

            if (estado == "activa" || estado == "disponible")
            {
                fondo = Color.FromArgb(220, 252, 231); texto = Color.FromArgb(16, 185, 129);
            }
            else if (estado == "cancelada" || estado == "inhabilitado")
            {
                fondo = Color.FromArgb(254, 226, 226); texto = Color.FromArgb(239, 68, 68);
            }
            else
            {
                fondo = Color.FromArgb(254, 243, 199); texto = Color.FromArgb(245, 158, 11);
            }

            Size ts = TextRenderer.MeasureText(estado, new Font("Segoe UI Semibold", 8F, FontStyle.Bold));
            Rectangle badge = new Rectangle(
                e.CellBounds.Left + 9,
                e.CellBounds.Top + (e.CellBounds.Height - 22) / 2,
                ts.Width + 18, 22);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var gp = RoundedPath(badge, badge.Height))
            using (var br = new SolidBrush(fondo))
                e.Graphics.FillPath(br, gp);

            TextRenderer.DrawText(e.Graphics, estado,
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                badge, texto,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void PintarFondoCelda(DataGridViewCellPaintingEventArgs e)
        {
            Color fondo = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(247, 249, 252);
            using (var br = new SolidBrush(fondo))
                e.Graphics.FillRectangle(br, e.CellBounds);
            using (var pen = new Pen(Color.FromArgb(230, 235, 243)))
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                         e.CellBounds.Right, e.CellBounds.Bottom - 1);
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

        // ── EVENTOS DE BOTONES MÓDULOS ───────────────────────
        private void btnAmbientesMasUsados_Click(object sender, EventArgs e) => CargarReporte("ambientes");
        private void btnReservasCanceladas_Click(object sender, EventArgs e) => CargarReporte("cancelaciones");
        private void btnDisponibilidad_Click(object sender, EventArgs e) => CargarReporte("disponibilidad");
        private void btnUsoPorCarrera_Click(object sender, EventArgs e) => CargarReporte("carrera");
        private void btnTodasReservas_Click(object sender, EventArgs e) => CargarReporte("todas");

        // ── FILTRO FECHAS LÓGICA ─────────────────────────────
        private void btnAplicarFiltroFecha_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _fechaDesde = dtpDesde.Value.Date;
            _fechaHasta = dtpHasta.Value.Date;
            CargarReporte(_tipoActual);
        }

        private void btnQuitarFiltroFecha_Click(object sender, EventArgs e)
        {
            _fechaDesde = null;
            _fechaHasta = null;
            CargarReporte(_tipoActual);
        }

        // ── EXPORTACIÓN CSV (EXCEL) ──────────────────────────
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (_dtReporteActual == null || _dtReporteActual.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo CSV (*.csv)|*.csv";
                sfd.FileName = NombreArchivoSugerido() + ".csv";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    ExportarCsv(_dtReporteActual, sfd.FileName);
                    MessageBox.Show(
                        "Reporte exportado correctamente.\n\n" +
                        "Se abre con doble clic (Excel lo reconoce automáticamente), " +
                        "o desde Excel: Datos > Desde texto/CSV si prefieres elegir la codificación manualmente.",
                        "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }

        private void ExportarCsv(DataTable dt, string ruta)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(";", dt.Columns.Cast<DataColumn>().Select(c => EscaparCsv(c.ColumnName))));

            foreach (DataRow fila in dt.Rows)
            {
                var valores = fila.ItemArray.Select(v => EscaparCsv(Convert.ToString(v)));
                sb.AppendLine(string.Join(";", valores));
            }

            File.WriteAllText(ruta, sb.ToString(), new UTF8Encoding(true));
        }

        private string EscaparCsv(string valor)
        {
            if (valor == null) return "";
            bool necesitaComillas = valor.Contains(";") || valor.Contains("\"") || valor.Contains("\n") || valor.Contains("\r");
            if (necesitaComillas)
                valor = "\"" + valor.Replace("\"", "\"\"") + "\"";
            return valor;
        }

        private string NombreArchivoSugerido()
        {
            return $"Reporte_{_tipoActual}_{DateTime.Now:yyyyMMdd_HHmm}";
        }

        // ── IMPRESIÓN DIRECTA DIGITAL A PDF ──────────────────
        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (_dtReporteActual == null || _dtReporteActual.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _printRowIndex = 0;

            using (PrintDocument pd = new PrintDocument())
            {
                pd.DocumentName = NombreArchivoSugerido();
                pd.PrintPage += PrintDocument_PrintPage;

                try { pd.DefaultPageSettings.Landscape = true; } catch { }
                try { pd.DefaultPageSettings.Margins = new Margins(40, 40, 50, 40); } catch { }

                foreach (string impresora in PrinterSettings.InstalledPrinters)
                {
                    if (impresora.IndexOf("PDF", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        pd.PrinterSettings.PrinterName = impresora;
                        break;
                    }
                }

                using (PrintDialog dlg = new PrintDialog())
                {
                    dlg.Document = pd;
                    dlg.AllowSelection = false;
                    dlg.AllowSomePages = false;
                    dlg.UseEXDialog = true;

                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    try
                    {
                        _printRowIndex = 0;
                        pd.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar el PDF: " + ex.Message);
                    }
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle area = e.MarginBounds;
            float y = area.Top;

            Font fuenteTitulo = new Font("Segoe UI", 13F, FontStyle.Bold);
            Font fuenteSubtitulo = new Font("Segoe UI", 9F, FontStyle.Italic);
            Font fuenteEncabezado = new Font("Segoe UI", 9F, FontStyle.Bold);
            Font fuenteCelda = new Font("Segoe UI", 8.5F);

            if (_printRowIndex == 0)
            {
                g.DrawString("Reportes y Estadísticas — " + lblSubtitulo.Text, fuenteTitulo, Brushes.Black, area.Left, y);
                y += 26;
                g.DrawString(lblTotal.Text, fuenteSubtitulo, Brushes.DimGray, area.Left, y);
                y += 22;
            }

            int colCount = _dtReporteActual.Columns.Count;
            float anchoCol = area.Width / (float)colCount;

            float x = area.Left;
            for (int c = 0; c < colCount; c++)
            {
                g.DrawString(_dtReporteActual.Columns[c].ColumnName, fuenteEncabezado, Brushes.Black,
                    new RectangleF(x, y, anchoCol - 2, 20));
                x += anchoCol;
            }
            y += 20;
            g.DrawLine(Pens.Black, area.Left, y, area.Right, y);
            y += 4;

            while (_printRowIndex < _dtReporteActual.Rows.Count)
            {
                if (y + 18 > area.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                x = area.Left;
                DataRow fila = _dtReporteActual.Rows[_printRowIndex];
                for (int c = 0; c < colCount; c++)
                {
                    string valor = Convert.ToString(fila[c]);
                    g.DrawString(valor, fuenteCelda, Brushes.Black,
                        new RectangleF(x, y, anchoCol - 2, 32));
                    x += anchoCol;
                }
                y += 18;
                _printRowIndex++;
            }

            e.HasMorePages = false;
        }
    }
}