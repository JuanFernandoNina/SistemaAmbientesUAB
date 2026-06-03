using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarReporte("ambientes");
        }

        private void AplicarTema()
        {
            this.BackColor = TemaManager.FondoPrincipal;
            panelBotones.BackColor = TemaManager.FondoPrincipal;
            TemaManager.AplicarLabel(lblTitulo);
            TemaManager.AplicarLabel(lblSubtitulo);
            TemaManager.AplicarLabel(lblTotal, true);
            TemaManager.AplicarGrid(dgvReporte);

            // Estilo base de los botones de reporte
            Button[] bots = { btnAmbientesMasUsados, btnReservasCanceladas,
                               btnDisponibilidad, btnUsoPorCarrera, btnTodasReservas };
            foreach (var b in bots)
            {
                b.BackColor = TemaManager.AcentoOscuro;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
            }
        }

        private void CargarReporte(string tipo)
        {
            string query = "", subtitulo = "";

            switch (tipo)
            {
                case "ambientes":
                    subtitulo = "🏆 Ambientes más utilizados";
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
                    subtitulo = "❌ Historial de cancelaciones";
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
                    subtitulo = "📋 Todas las reservas del sistema";
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
                    lblSubtitulo.Text = subtitulo;
                    lblTotal.Text = $"Total: {dt.Rows.Count} registro(s)";

                    if (dt.Columns.Contains("Estado"))
                    {
                        foreach (DataGridViewRow row in dgvReporte.Rows)
                        {
                            string estado = row.Cells["Estado"].Value?.ToString();
                            if (estado == "cancelada")
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 80, 80);
                            else if (estado == "finalizada")
                                row.DefaultCellStyle.ForeColor = TemaManager.TextoSecundario;
                            else if (estado == "activa")
                                row.DefaultCellStyle.ForeColor = TemaManager.Acento;
                        }
                    }

                    ResetearBotones();
                    Color activo = Color.FromArgb(40, 80, 200);
                    switch (tipo)
                    {
                        case "ambientes": btnAmbientesMasUsados.BackColor = activo; break;
                        case "cancelaciones": btnReservasCanceladas.BackColor = activo; break;
                        case "disponibilidad": btnDisponibilidad.BackColor = activo; break;
                        case "carrera": btnUsoPorCarrera.BackColor = activo; break;
                        case "todas": btnTodasReservas.BackColor = activo; break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar reporte: " + ex.Message); }
        }

        private void ResetearBotones()
        {
            Button[] bots = { btnAmbientesMasUsados, btnReservasCanceladas,
                               btnDisponibilidad, btnUsoPorCarrera, btnTodasReservas };
            foreach (var b in bots)
                b.BackColor = TemaManager.AcentoOscuro;
        }

        private void btnAmbientesMasUsados_Click(object sender, EventArgs e) => CargarReporte("ambientes");
        private void btnReservasCanceladas_Click(object sender, EventArgs e) => CargarReporte("cancelaciones");
        private void btnDisponibilidad_Click(object sender, EventArgs e) => CargarReporte("disponibilidad");
        private void btnUsoPorCarrera_Click(object sender, EventArgs e) => CargarReporte("carrera");
        private void btnTodasReservas_Click(object sender, EventArgs e) => CargarReporte("todas");
    }
}