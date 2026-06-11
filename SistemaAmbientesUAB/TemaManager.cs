using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public enum TipoTema { Claro, Oscuro }

    public static class TemaManager
    {
        public static TipoTema TemaActual = TipoTema.Claro;

        // ═══════════════════════════════════════════════════════
        //  FONDOS
        // ═══════════════════════════════════════════════════════

        /// Fondo general de la app   Claro:#EFF4FB  Oscuro:#0D1117
        public static Color FondoPrincipal =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(239, 244, 251) : Color.FromArgb(13, 17, 23);

        /// Sidebar                   Claro:#0C1E3E  Oscuro:#0A0F1C
        public static Color FondoMenu =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(12, 30, 62) : Color.FromArgb(10, 15, 28);

        /// Área de contenido         igual a FondoPrincipal
        public static Color FondoContenido => FondoPrincipal;

        /// Fondo de tabla/grid       Claro:#FFFFFF  Oscuro:#161B27
        public static Color FondoGrid =>
            TemaActual == TipoTema.Claro ? Color.White : Color.FromArgb(22, 27, 39);

        /// Card principal            Claro:#FFFFFF  Oscuro:#161B27
        public static Color FondoTarjeta =>
            TemaActual == TipoTema.Claro ? Color.White : Color.FromArgb(22, 27, 39);

        /// Card secundaria           Claro:#F0F5FC  Oscuro:#1C2436
        public static Color FondoTarjeta2 =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(240, 245, 252) : Color.FromArgb(28, 36, 54);

        // ═══════════════════════════════════════════════════════
        //  TEXTOS
        // ═══════════════════════════════════════════════════════

        /// Texto primario            Claro:#0C1E3E  Oscuro:#E2EEFF
        public static Color TextoPrincipal =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(12, 30, 62) : Color.FromArgb(226, 238, 255);

        /// Texto secundario          Claro:#4A6080  Oscuro:#7E9CBF
        public static Color TextoSecundario =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(74, 96, 128) : Color.FromArgb(126, 156, 191);

        /// Texto atenuado            Claro:#8BA4C0  Oscuro:#3D5470
        public static Color TextoMuted =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(139, 164, 192) : Color.FromArgb(61, 84, 112);

        /// Iconos / texto nav        Claro:#7BA4D4  Oscuro:#3D5470
        public static Color NavIcono =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(123, 164, 212) : Color.FromArgb(61, 84, 112);

        // ═══════════════════════════════════════════════════════
        //  ACENTO / MARCA
        // ═══════════════════════════════════════════════════════

        /// Azul principal            Claro:#2563EB  Oscuro:#3B9EFF
        public static Color Acento =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(37, 99, 235) : Color.FromArgb(59, 158, 255);

        /// Azul hover/pressed        Claro:#1D4ED8  Oscuro:#1D4ED8
        public static Color AcentoOscuro => Color.FromArgb(29, 78, 216);

        /// Cian secundario           Claro:#22D3EE  Oscuro:#22D3A0
        public static Color Acento2 =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(34, 211, 238) : Color.FromArgb(34, 211, 160);

        // ═══════════════════════════════════════════════════════
        //  ESTADOS
        // ═══════════════════════════════════════════════════════

        /// Verde éxito / activo      Claro:#10B981  Oscuro:#22D3A0
        public static Color Exito =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(16, 185, 129) : Color.FromArgb(34, 211, 160);

        /// Ámbar advertencia         #F59E0B (ambos temas)
        public static Color Advertencia => Color.FromArgb(245, 158, 11);

        /// Rojo peligro / cancelado  Claro:#EF4444  Oscuro:#FF5A5A
        public static Color Peligro =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(239, 68, 68) : Color.FromArgb(255, 90, 90);

        // ── Fondos suaves para badges de estado ──────────────
        /// Fondo badge "activa"
        public static Color BadgeFondoActiva =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(220, 252, 231) : Color.FromArgb(6, 78, 59);

        /// Fondo badge "cancelada"
        public static Color BadgeFondoCancelada =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(254, 226, 226) : Color.FromArgb(127, 29, 29);

        /// Fondo badge "finalizada"
        public static Color BadgeFondoFinalizada =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(241, 245, 249) : Color.FromArgb(30, 41, 59);

        // ═══════════════════════════════════════════════════════
        //  BOTONES MENÚ / NAV
        // ═══════════════════════════════════════════════════════

        /// Fondo base botón nav       igual a FondoMenu
        public static Color BotonMenu => FondoMenu;

        /// Hover botón nav (semitransparente sobre el sidebar)
        public static Color BotonHover =>
            TemaActual == TipoTema.Claro
                ? Color.FromArgb(18, 40, 80)    // #122850
                : Color.FromArgb(16, 26, 48);   // #101A30

        /// Botón activo / seleccionado  Claro:#2563EB  Oscuro:#3B9EFF
        public static Color BotonActivo => Acento;

        // ═══════════════════════════════════════════════════════
        //  BORDES
        // ═══════════════════════════════════════════════════════

        /// Borde general             Claro:#C3D5EE  Oscuro:#1E2A3F
        public static Color Borde =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(195, 213, 238) : Color.FromArgb(30, 42, 63);

        // ═══════════════════════════════════════════════════════
        //  GRID — header
        // ═══════════════════════════════════════════════════════

        /// Header de tabla            Claro:#0C1E3E  Oscuro:#0A0F1C
        public static Color HeaderGrid =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(12, 30, 62) : Color.FromArgb(10, 15, 28);

        /// Fila alternada             Claro:#F0F5FC  Oscuro:#1C2436
        public static Color FilaAlternadaGrid =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(240, 245, 252) : Color.FromArgb(28, 36, 54);

        // ═══════════════════════════════════════════════════════
        //  MÉTODOS DE AYUDA
        // ═══════════════════════════════════════════════════════

        /// Alterna entre tema claro y oscuro
        public static void CambiarTema() =>
            TemaActual = TemaActual == TipoTema.Claro ? TipoTema.Oscuro : TipoTema.Claro;

        /// Aplica el tema completo a un DataGridView
        public static void AplicarGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = FondoGrid;
            dgv.DefaultCellStyle.BackColor = FondoGrid;
            dgv.DefaultCellStyle.ForeColor = TextoPrincipal;
            dgv.DefaultCellStyle.SelectionBackColor = Acento;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = FilaAlternadaGrid;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = HeaderGrid;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.GridColor = Borde;
            dgv.RowTemplate.Height = 34;
            dgv.ColumnHeadersHeight = 38;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
        }

        /// Aplica fondo del tema a un Form
        public static void AplicarForm(Form frm) => frm.BackColor = FondoContenido;

        /// Aplica estilo estándar a un botón de acción
        public static void AplicarBoton(Button btn, Color? fondo = null)
        {
            btn.BackColor = fondo ?? Acento;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        /// Aplica color de texto a un Label
        public static void AplicarLabel(Label lbl, bool secundario = false)
        {
            lbl.ForeColor = secundario ? TextoSecundario : TextoPrincipal;
            lbl.BackColor = Color.Transparent;
        }

        /// Aplica el tema a un TextBox (inputs de formularios)
        public static void AplicarInput(TextBox txt)
        {
            txt.BackColor = FondoGrid;
            txt.ForeColor = TextoPrincipal;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 9.5F);
        }

        /// Aplica el tema a un ComboBox
        public static void AplicarCombo(ComboBox cmb)
        {
            cmb.BackColor = FondoGrid;
            cmb.ForeColor = TextoPrincipal;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 9.5F);
        }

        /// Dibuja un panel con bordes redondeados y borde de color.
        /// Llama desde el evento Paint del Panel.
        public static void DibujarCard(System.Windows.Forms.PaintEventArgs e,
                                       Rectangle rect,
                                       Color fondoCard,
                                       Color bordeCard,
                                       int radio = 10,
                                       Color? bordeIzquierdo = null)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var gp = RoundedPath(rect, radio))
            using (var br = new SolidBrush(fondoCard))
                e.Graphics.FillPath(br, gp);

            using (var gp = RoundedPath(rect, radio))
            using (var pen = new Pen(bordeCard, 1f))
                e.Graphics.DrawPath(pen, gp);

            if (bordeIzquierdo.HasValue)
                using (var pen = new Pen(bordeIzquierdo.Value, 3f))
                    e.Graphics.DrawLine(pen, rect.X + 1, rect.Y + radio, rect.X + 1, rect.Bottom - radio);
        }

        /// Construye un GraphicsPath rectangular redondeado
        public static GraphicsPath RoundedPath(Rectangle r, int rad)
        {
            var gp = new GraphicsPath();
            gp.AddArc(r.X, r.Y, rad * 2, rad * 2, 180, 90);
            gp.AddArc(r.Right - rad * 2, r.Y, rad * 2, rad * 2, 270, 90);
            gp.AddArc(r.Right - rad * 2, r.Bottom - rad * 2, rad * 2, rad * 2, 0, 90);
            gp.AddArc(r.X, r.Bottom - rad * 2, rad * 2, rad * 2, 90, 90);
            gp.CloseFigure();
            return gp;
        }
    }
}