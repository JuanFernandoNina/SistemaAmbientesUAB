using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public enum TipoTema { Claro, Oscuro }

    public static class TemaManager
    {
        public static TipoTema TemaActual = TipoTema.Claro;

        // ── FONDOS ────────────────────────────────────────────
        public static Color FondoPrincipal =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(245, 247, 250) : Color.FromArgb(15, 23, 42);

        public static Color FondoMenu =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(30, 41, 30) : Color.FromArgb(10, 15, 30);

        public static Color FondoContenido =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(240, 242, 245) : Color.FromArgb(18, 28, 50);

        public static Color FondoGrid =>
            TemaActual == TipoTema.Claro ? Color.White : Color.FromArgb(20, 30, 55);

        public static Color FondoTarjeta =>
            TemaActual == TipoTema.Claro ? Color.White : Color.FromArgb(22, 35, 65);

        // ── TEXTOS ────────────────────────────────────────────
        public static Color TextoPrincipal =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(30, 30, 30) : Color.FromArgb(220, 230, 255);

        public static Color TextoSecundario =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(120, 120, 120) : Color.FromArgb(120, 140, 180);

        // ── GRID ──────────────────────────────────────────────
        public static Color HeaderGrid =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(30, 41, 30) : Color.FromArgb(20, 40, 90);

        public static Color FilaAlternadaGrid =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(235, 245, 235) : Color.FromArgb(25, 38, 65);

        // ── BOTONES ───────────────────────────────────────────
        public static Color BotonMenu =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(30, 41, 30) : Color.FromArgb(10, 15, 30);

        public static Color BotonHover =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(55, 80, 55) : Color.FromArgb(30, 50, 100);

        public static Color Acento =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(40, 160, 80) : Color.FromArgb(30, 215, 130);

        public static Color AcentoOscuro =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(30, 120, 60) : Color.FromArgb(20, 170, 100);

        // ── BORDES / SEPARADORES ──────────────────────────────
        public static Color Borde =>
            TemaActual == TipoTema.Claro ? Color.FromArgb(220, 225, 230) : Color.FromArgb(30, 45, 80);

        // ── COLORES TARJETAS DASHBOARD ────────────────────────
        public static Color[] ColoresTarjetas =>
            TemaActual == TipoTema.Claro
                ? new[] {
                    Color.FromArgb(40,  120,  80),
                    Color.FromArgb(40,  100, 180),
                    Color.FromArgb(160,  90,  30),
                    Color.FromArgb(100,  40, 160),
                    Color.FromArgb(30,  140, 140),
                    Color.FromArgb(160,  50,  50),
                    Color.FromArgb(40,   80, 160),
                    Color.FromArgb(120, 110,  30),
                  }
                : new[] {
                    Color.FromArgb(20,  180, 100),
                    Color.FromArgb(50,  120, 255),
                    Color.FromArgb(255, 140,  40),
                    Color.FromArgb(150,  60, 255),
                    Color.FromArgb(20,  200, 200),
                    Color.FromArgb(255,  60,  60),
                    Color.FromArgb(50,  100, 255),
                    Color.FromArgb(210, 180,  30),
                  };

        // ── MÉTODOS DE APLICACIÓN ─────────────────────────────
        public static void CambiarTema()
        {
            TemaActual = TemaActual == TipoTema.Claro ? TipoTema.Oscuro : TipoTema.Claro;
        }

        public static void AplicarGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = FondoGrid;
            dgv.DefaultCellStyle.BackColor = FondoGrid;
            dgv.DefaultCellStyle.ForeColor = TextoPrincipal;
            dgv.DefaultCellStyle.SelectionBackColor = Acento;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = FilaAlternadaGrid;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = HeaderGrid;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.GridColor = Borde;
        }

        public static void AplicarForm(Form frm)
        {
            frm.BackColor = FondoPrincipal;
        }

        public static void AplicarBoton(Button btn, Color? fondo = null)
        {
            btn.BackColor = fondo ?? Acento;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void AplicarLabel(Label lbl, bool secundario = false)
        {
            lbl.ForeColor = secundario ? TextoSecundario : TextoPrincipal;
            lbl.BackColor = Color.Transparent;
        }
    }
}