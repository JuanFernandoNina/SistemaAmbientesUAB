using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormHome : Form
    {
        private int _idUsuario;
        private string _nombre;

        public FormHome(int idUsuario, string nombre)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _nombre = nombre;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            AplicarTema();
            lblFecha.Text = "📅 " + DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy",
                new System.Globalization.CultureInfo("es-ES"));
            CrearTarjetas();
            CargarUltimasReservas();
        }

        private void AplicarTema()
        {
            this.BackColor = TemaManager.FondoPrincipal;
            panelTarjetas.BackColor = TemaManager.FondoPrincipal;
            TemaManager.AplicarLabel(lblTitulo);
            TemaManager.AplicarLabel(lblFecha, true);
            TemaManager.AplicarLabel(lblActividad);
            TemaManager.AplicarGrid(dgvActividad);
        }

        private void CrearTarjetas()
        {
            panelTarjetas.Controls.Clear();

            int totalAmbientes = ObtenerConteo("SELECT COUNT(*) FROM Ambiente");
            int disponibles = ObtenerConteo("SELECT COUNT(*) FROM Ambiente WHERE estado='disponible'");
            int enManten = ObtenerConteo("SELECT COUNT(*) FROM Ambiente WHERE estado='mantenimiento'");
            int totalReservas = ObtenerConteo("SELECT COUNT(*) FROM Reserva WHERE estado='activa'");
            int reservasHoy = ObtenerConteo("SELECT COUNT(*) FROM Reserva WHERE estado='activa' AND fecha_inicio=CAST(GETDATE() AS DATE)");
            int totalUsuarios = ObtenerConteo("SELECT COUNT(*) FROM Usuario WHERE estado='activo'");
            int cancelaciones = ObtenerConteo("SELECT COUNT(*) FROM Cancelacion");
            int totalEventos = ObtenerConteo("SELECT COUNT(*) FROM Evento");

            var colores = TemaManager.ColoresTarjetas;

            var tarjetas = new[]
            {
                new { titulo = "Ambientes",       valor = totalAmbientes, icono = "🏫", color = colores[0] },
                new { titulo = "Disponibles",     valor = disponibles,    icono = "✅", color = colores[1] },
                new { titulo = "Mantenimiento",   valor = enManten,       icono = "🔧", color = colores[2] },
                new { titulo = "Reservas hoy",    valor = reservasHoy,    icono = "📅", color = colores[3] },
                new { titulo = "Reservas activas",valor = totalReservas,  icono = "📋", color = colores[4] },
                new { titulo = "Usuarios",        valor = totalUsuarios,  icono = "👥", color = colores[5] },
                new { titulo = "Cancelaciones",   valor = cancelaciones,  icono = "❌", color = colores[6] },
                new { titulo = "Eventos",         valor = totalEventos,   icono = "🎉", color = colores[7] },
            };

            int ancho = 195;
            int alto = 110;
            int gap = 12;
            int porFila = 4;

            for (int i = 0; i < tarjetas.Length; i++)
            {
                int fila = i / porFila;
                int col = i % porFila;

                Panel card = new Panel();
                card.Size = new Size(ancho, alto);
                card.Location = new Point(col * (ancho + gap), fila * (alto + gap));
                card.BackColor = tarjetas[i].color;

                // Esquinas simuladas con padding interno
                Label lblIcono = new Label();
                lblIcono.Text = tarjetas[i].icono;
                lblIcono.Font = new Font("Segoe UI", 20F);
                lblIcono.ForeColor = Color.FromArgb(255, 255, 255, 180);
                lblIcono.Location = new Point(12, 8);
                lblIcono.Size = new Size(45, 45);
                lblIcono.TextAlign = ContentAlignment.MiddleCenter;

                Label lblValor = new Label();
                lblValor.Text = tarjetas[i].valor.ToString();
                lblValor.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
                lblValor.ForeColor = Color.White;
                lblValor.Location = new Point(70, 5);
                lblValor.Size = new Size(115, 50);
                lblValor.TextAlign = ContentAlignment.MiddleRight;

                Label lblTit = new Label();
                lblTit.Text = tarjetas[i].titulo;
                lblTit.Font = new Font("Segoe UI", 9F);
                lblTit.ForeColor = Color.FromArgb(230, 230, 230);
                lblTit.Location = new Point(12, 68);
                lblTit.Size = new Size(170, 22);
                lblTit.TextAlign = ContentAlignment.MiddleLeft;

                // Línea decorativa inferior
                Label linea = new Label();
                linea.Size = new Size(ancho, 3);
                linea.Location = new Point(0, alto - 3);
                linea.BackColor = Color.FromArgb(50, 255, 255, 255);

                card.Controls.Add(lblIcono);
                card.Controls.Add(lblValor);
                card.Controls.Add(lblTit);
                card.Controls.Add(linea);
                panelTarjetas.Controls.Add(card);
            }

            panelTarjetas.Height = tarjetas.Length > porFila
                ? (alto + gap) * 2 + 5
                : alto + 10;

            lblActividad.Top = panelTarjetas.Bottom + 18;
            dgvActividad.Top = lblActividad.Bottom + 5;
            dgvActividad.Height = this.Height - dgvActividad.Top - 20;
        }

        private int ObtenerConteo(string query)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    return Convert.ToInt32(new SqlCommand(query, con).ExecuteScalar());
                }
            }
            catch { return 0; }
        }

        private void CargarUltimasReservas()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT TOP 10
                            u.nombre_completo                     AS Solicitante,
                            a.codigo                              AS Ambiente,
                            b.nombre                              AS Bloque,
                            CONVERT(VARCHAR,r.fecha_inicio,103)   AS Fecha,
                            CONVERT(VARCHAR(5),r.hora_inicio,108) AS [Hora ini],
                            CONVERT(VARCHAR(5),r.hora_fin,108)    AS [Hora fin],
                            r.motivo                              AS Motivo,
                            r.estado                              AS Estado,
                            CONVERT(VARCHAR,r.fecha_creacion,103) AS Registrado
                        FROM Reserva r
                        INNER JOIN Usuario u  ON r.id_usuario  = u.id_usuario
                        INNER JOIN Ambiente a ON r.id_ambiente = a.id_ambiente
                        INNER JOIN Bloque b   ON a.id_bloque   = b.id_bloque
                        ORDER BY r.fecha_creacion DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvActividad.DataSource = dt;

                    foreach (DataGridViewRow row in dgvActividad.Rows)
                    {
                        string estado = row.Cells["Estado"].Value?.ToString();
                        if (estado == "cancelada")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 80, 80);
                        else if (estado == "finalizada")
                            row.DefaultCellStyle.ForeColor = TemaManager.TextoSecundario;
                        else
                            row.DefaultCellStyle.ForeColor = TemaManager.Acento;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al cargar actividad: " + ex.Message);
            }
        }
    }
}