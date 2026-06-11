using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormHome : Form
    {
        private int _idUsuario;
        private string _nombre;

        // definición de las 4 tarjetas del diseño
        private struct CardDef
        {
            public string Titulo;
            public string Query;
            public Color BgLight;   // fondo claro
            public Color BgDark;
            public Color AccLight;  // número + borde izquierdo
            public Color AccDark;
        }

        private readonly CardDef[] _cards = new[]
        {
            new CardDef {
                Titulo   = "Ambientes",
                Query    = "SELECT COUNT(*) FROM Ambiente",
                BgLight  = Color.FromArgb(239, 246, 255),  // #EFF6FF
                BgDark   = Color.FromArgb(22, 27, 39),
                AccLight = Color.FromArgb(37, 99, 235),    // azul
                AccDark  = Color.FromArgb(59, 158, 255)
            },
            new CardDef {
                Titulo   = "Disponibles",
                Query    = "SELECT COUNT(*) FROM Ambiente WHERE estado='disponible'",
                BgLight  = Color.FromArgb(236, 253, 245),  // #ECFDF5
                BgDark   = Color.FromArgb(22, 27, 39),
                AccLight = Color.FromArgb(6, 95, 70),      // verde
                AccDark  = Color.FromArgb(34, 211, 160)
            },
            new CardDef {
                Titulo   = "Mantenimiento",
                Query    = "SELECT COUNT(*) FROM Ambiente WHERE estado='mantenimiento'",
                BgLight  = Color.FromArgb(255, 251, 235),  // #FFFBEB
                BgDark   = Color.FromArgb(22, 27, 39),
                AccLight = Color.FromArgb(146, 64, 14),    // ámbar
                AccDark  = Color.FromArgb(245, 158, 11)
            },
            new CardDef {
                Titulo   = "Reservas hoy",
                Query    = "SELECT COUNT(*) FROM Reserva WHERE estado='activa' AND fecha_inicio=CAST(GETDATE() AS DATE)",
                BgLight  = Color.FromArgb(239, 246, 255),
                BgDark   = Color.FromArgb(22, 27, 39),
                AccLight = Color.FromArgb(37, 99, 235),
                AccDark  = Color.FromArgb(59, 158, 255)
            },
        };

        public FormHome(int idUsuario, string nombre)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _nombre = nombre;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            AplicarTema();
            lblFecha.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy",
                new System.Globalization.CultureInfo("es-ES"));
            CrearTarjetas();
            CargarUltimasReservas();
        }

        private void FormHome_Resize(object sender, EventArgs e)
        {
            // Redibujar tarjetas cuando cambia el tamaño del form
            if (panelTarjetas != null && panelTarjetas.Width > 0)
                CrearTarjetas();
        }

        // ── TEMA ──────────────────────────────────────────────
        private void AplicarTema()
        {
            this.BackColor = TemaManager.FondoContenido;
            panelTarjetas.BackColor = Color.Transparent;

            lblTitulo.ForeColor = TemaManager.TextoPrincipal;
            lblTitulo.Font = new Font("Segoe UI", 17F, FontStyle.Bold);

            lblFecha.ForeColor = TemaManager.TextoSecundario;
            lblFecha.Font = new Font("Segoe UI", 9F);

            lblActividad.ForeColor = TemaManager.TextoPrincipal;
            lblActividad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            TemaManager.AplicarGrid(dgvActividad);
        }

        // ── TARJETAS MINIMALISTAS (estilo propuesta HTML) ─────
        private void CrearTarjetas()
        {
            panelTarjetas.Controls.Clear();

            int total = _cards.Length;
            int gap = 14;
            int avail = panelTarjetas.Width;
            int w = (avail - gap * (total - 1)) / total;
            int h = panelTarjetas.Height > 0 ? panelTarjetas.Height : 115;

            bool oscuro = TemaManager.TemaActual == TipoTema.Oscuro;

            for (int i = 0; i < total; i++)
            {
                var def = _cards[i];
                int valor = ObtenerConteo(def.Query);
                Color bg = oscuro ? def.BgDark : def.BgLight;
                Color acc = oscuro ? def.AccDark : def.AccLight;

                // Panel con borde redondeado y borde izquierdo de color
                var card = new Panel
                {
                    Size = new Size(w, h),
                    Location = new Point(i * (w + gap), 0),
                    BackColor = Color.Transparent
                };

                Color borderCol = TemaManager.Borde;
                card.Paint += (s, pe) =>
                {
                    var rc = ((Panel)s).ClientRectangle;
                    int rad = 10;
                    pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Fondo redondeado
                    using (var gp = RoundedRect(rc, rad))
                    using (var br = new SolidBrush(bg))
                        pe.Graphics.FillPath(br, gp);

                    // Borde sutil
                    using (var gp = RoundedRect(rc, rad))
                    using (var pen = new Pen(borderCol, 1f))
                        pe.Graphics.DrawPath(pen, gp);

                    // Borde izquierdo acento (3px)
                    using (var pen = new Pen(acc, 3f))
                        pe.Graphics.DrawLine(pen, rc.X + 1, rc.Y + rad, rc.X + 1, rc.Bottom - rad);
                };

                // Número grande
                var lblVal = new Label
                {
                    Text = valor.ToString(),
                    Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                    ForeColor = acc,
                    Location = new Point(20, 18),
                    Size = new Size(w - 24, 44),
                    BackColor = Color.Transparent,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                // Título debajo
                var lblTit = new Label
                {
                    Text = def.Titulo,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = TemaManager.TextoSecundario,
                    Location = new Point(20, 64),
                    Size = new Size(w - 24, 20),
                    BackColor = Color.Transparent,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                card.Controls.Add(lblVal);
                card.Controls.Add(lblTit);
                panelTarjetas.Controls.Add(card);
            }
        }

        private GraphicsPath RoundedRect(Rectangle r, int rad)
        {
            var gp = new GraphicsPath();
            gp.AddArc(r.X, r.Y, rad * 2, rad * 2, 180, 90);
            gp.AddArc(r.Right - rad * 2, r.Y, rad * 2, rad * 2, 270, 90);
            gp.AddArc(r.Right - rad * 2, r.Bottom - rad * 2, rad * 2, rad * 2, 0, 90);
            gp.AddArc(r.X, r.Bottom - rad * 2, rad * 2, rad * 2, 90, 90);
            gp.CloseFigure();
            return gp;
        }

        private int ObtenerConteo(string query)
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    return Convert.ToInt32(new SqlCommand(query, con).ExecuteScalar());
                }
            }
            catch { return 0; }
        }

        // ── GRID ÚLTIMAS RESERVAS ─────────────────────────────
        private void CargarUltimasReservas()
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string q = @"
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
                        INNER JOIN Usuario  u ON r.id_usuario  = u.id_usuario
                        INNER JOIN Ambiente a ON r.id_ambiente = a.id_ambiente
                        INNER JOIN Bloque   b ON a.id_bloque   = b.id_bloque
                        ORDER BY r.fecha_creacion DESC";

                    var da = new SqlDataAdapter(q, con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvActividad.DataSource = dt;

                    // Colores de estado por fila
                    foreach (DataGridViewRow row in dgvActividad.Rows)
                    {
                        string st = row.Cells["Estado"].Value?.ToString();
                        if (st == "cancelada")
                            row.DefaultCellStyle.ForeColor = TemaManager.Peligro;
                        else if (st == "finalizada")
                            row.DefaultCellStyle.ForeColor = TemaManager.TextoMuted;
                        else
                            row.DefaultCellStyle.ForeColor = TemaManager.Acento;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar actividad: " + ex.Message);
            }
        }
    }
}