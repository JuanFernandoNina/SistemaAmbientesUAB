using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormReportes : Form
    {
        private string _tipoActual = "ambientes";

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarReporte("ambientes");
        }

        // ── TEMA MINIMALISTA ──────────────────────────────────
        private void AplicarTema()
        {
            this.BackColor        = Color.White;
            panelBotones.BackColor = Color.FromArgb(247, 249, 252);

            lblTitulo.ForeColor    = TemaManager.TextoPrincipal;
            lblTitulo.Font         = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSubtitulo.ForeColor = TemaManager.TextoSecundario;
            lblSubtitulo.Font      = new Font("Segoe UI", 9.5F);
            lblTotal.ForeColor     = TemaManager.TextoMuted;

            AplicarEstiloTabla(dgvReporte);

            // Botones de reporte como tabs/pills
            Button[] bots = { btnAmbientesMasUsados, btnReservasCanceladas,
                               btnDisponibilidad, btnUsoPorCarrera, btnTodasReservas };
            foreach (var b in bots)
                EstiloBotonTab(b, false);
        }

        private static void AplicarEstiloTabla(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor           = Color.White;
            dgv.GridColor                 = Color.FromArgb(230, 235, 243);
            dgv.BorderStyle               = BorderStyle.None;
            dgv.RowHeadersVisible         = false;
            dgv.AllowUserToAddRows        = false;
            dgv.AllowUserToDeleteRows     = false;
            dgv.ReadOnly                  = true;
            dgv.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect               = false;
            dgv.AutoSizeColumnsMode       = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height        = 36;
            dgv.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.BackColor           = Color.White;
            dgv.DefaultCellStyle.ForeColor           = TemaManager.TextoPrincipal;
            dgv.DefaultCellStyle.SelectionBackColor  = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor  = TemaManager.TextoPrincipal;
            dgv.DefaultCellStyle.Font                = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding             = new Padding(9, 0, 9, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor          = Color.FromArgb(247, 249, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TemaManager.TextoPrincipal;

            dgv.ColumnHeadersDefaultCellStyle.BackColor          = Color.FromArgb(239, 243, 248);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor          = Color.FromArgb(145, 155, 177);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 243, 248);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(145, 155, 177);
            dgv.ColumnHeadersDefaultCellStyle.Font               = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding            = new Padding(9, 0, 9, 0);
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private static void EstiloBotonTab(Button btn, bool activo)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor    = Cursors.Hand;
            btn.Font      = new Font("Segoe UI", 9F, activo ? FontStyle.Bold : FontStyle.Regular);

            if (activo)
            {
                btn.BackColor = TemaManager.Acento;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize  = 0;
            }
            else
            {
                btn.BackColor = Color.White;
                btn.ForeColor = TemaManager.TextoSecundario;
                btn.FlatAppearance.BorderColor = Color.FromArgb(225, 231, 240);
                btn.FlatAppearance.BorderSize  = 1;
            }
        }

        // ── CARGA DE REPORTES ─────────────────────────────────
        private void CargarReporte(string tipo)
        {
            _tipoActual = tipo;
            string query = "", subtitulo = "";

            switch (tipo)
            {
                case "ambientes":
                    subtitulo = "Ambientes más utilizados";
                    query = @"SELECT a.codigo AS Código, b.nombre AS Bloque, a.tipo AS Tipo,
                                     a.capacidad AS Capacidad, COUNT(r.id_reserva) AS [Total Reservas]
                              FROM Reserva r
                              INNER JOIN Ambiente a ON r.id_ambiente=a.id_ambiente
                              INNER JOIN Bloque b ON a.id_bloque=b.id_bloque
                              WHERE r.estado<>'cancelada'
                              GROUP BY a.codigo,b.nombre,a.tipo,a.capacidad
                              ORDER BY [Total Reservas] DESC";
                    break;

                case "cancelaciones":
                    subtitulo = "Historial de cancelaciones";
                    query = @"SELECT r.id_reserva AS [ID Reserva], u.nombre_completo AS Solicitante,
                                     a.codigo AS Ambiente, CONVERT(VARCHAR,r.fecha_inicio,103) AS Fecha,
                                     r.motivo AS Motivo, uc.nombre_completo AS [Cancelado por],
                                     CONVERT(VARCHAR,c.fecha_cancelacion,103) AS [Fecha Cancelación],
                                     c.motivo_cancelacion AS [Motivo Cancelación]
                              FROM Cancelacion c
                              INNER JOIN Reserva r  ON c.id_reserva=r.id_reserva
                              INNER JOIN Usuario u  ON r.id_usuario=u.id_usuario
                              INNER JOIN Ambiente a ON r.id_ambiente=a.id_ambiente
                              INNER JOIN Usuario uc ON c.id_usuario_cancela=uc.id_usuario
                              ORDER BY c.fecha_cancelacion DESC";
                    break;

                case "disponibilidad":
                    subtitulo = "Ambientes disponibles hoy";
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
                    subtitulo = "Uso de ambientes por carrera/área";
                    query = @"SELECT ISNULL(u.carrera_area,'Sin especificar') AS [Carrera/Área],
                                     u.tipo_usuario AS [Tipo Usuario],
                                     COUNT(r.id_reserva) AS [Total Reservas],
                                     COUNT(DISTINCT r.id_ambiente) AS [Ambientes distintos]
                              FROM Reserva r
                              INNER JOIN Usuario u ON r.id_usuario=u.id_usuario
                              WHERE r.estado<>'cancelada'
                              GROUP BY u.carrera_area, u.tipo_usuario
                              ORDER BY [Total Reservas] DESC";
                    break;

                case "todas":
                    subtitulo = "Todas las reservas del sistema";
                    query = @"SELECT r.id_reserva AS ID, u.nombre_completo AS Solicitante,
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
                              ORDER BY r.fecha_inicio DESC, r.hora_inicio";
                    break;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReporte.DataSource = dt;
                    lblSubtitulo.Text     = subtitulo;
                    lblTotal.Text         = $"Mostrando {dt.Rows.Count} registro(s)";

                    ActualizarBotonesTab(tipo);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar reporte: " + ex.Message); }
        }

        private void ActualizarBotonesTab(string tipoActivo)
        {
            EstiloBotonTab(btnAmbientesMasUsados,  tipoActivo == "ambientes");
            EstiloBotonTab(btnReservasCanceladas,  tipoActivo == "cancelaciones");
            EstiloBotonTab(btnDisponibilidad,      tipoActivo == "disponibilidad");
            EstiloBotonTab(btnUsoPorCarrera,       tipoActivo == "carrera");
            EstiloBotonTab(btnTodasReservas,       tipoActivo == "todas");
        }

        // ── PINTURA DE CELDAS ─────────────────────────────────
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
            gp.AddArc(r.X,         r.Y,          d, d, 180, 90);
            gp.AddArc(r.Right - d, r.Y,          d, d, 270, 90);
            gp.AddArc(r.Right - d, r.Bottom - d, d, d, 0,   90);
            gp.AddArc(r.X,         r.Bottom - d, d, d, 90,  90);
            gp.CloseFigure();
            return gp;
        }

        // ── EVENTOS BOTONES ───────────────────────────────────
        private void btnAmbientesMasUsados_Click(object sender, EventArgs e)  => CargarReporte("ambientes");
        private void btnReservasCanceladas_Click(object sender, EventArgs e)   => CargarReporte("cancelaciones");
        private void btnDisponibilidad_Click(object sender, EventArgs e)       => CargarReporte("disponibilidad");
        private void btnUsoPorCarrera_Click(object sender, EventArgs e)        => CargarReporte("carrera");
        private void btnTodasReservas_Click(object sender, EventArgs e)        => CargarReporte("todas");
    }
}
