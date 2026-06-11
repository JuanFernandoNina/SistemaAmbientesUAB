using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    // ============================================================
    // UI HELPER — aplica el sistema de diseño UAB a controles WinForms
    // Usar en el Load() de cada formulario y al cambiar de tema
    // ============================================================

    public static class UIHelper
    {
        // ── Fuentes del sistema ──────────────────────────────────
        public static readonly Font FuenteTitulo = new Font("Segoe UI", 15f, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FuenteNormal = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FuenteSmall = new Font("Segoe UI", 8f, FontStyle.Regular);
        public static readonly Font FuenteBold = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font FuenteNav = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FuenteStatNum = new Font("Segoe UI", 18f, FontStyle.Bold);

        // ============================================================
        // APLICAR TEMA A UN FORMULARIO COMPLETO
        // Llama a esto en el Load de cada Form:
        //   UIHelper.AplicarTemaFormulario(this);
        // ============================================================
        public static void AplicarTemaFormulario(Form form)
        {
            form.BackColor = ColorTheme.FondoApp;
            form.ForeColor = ColorTheme.TextoPrimario;
            AplicarTemaRecursivo(form.Controls);
        }

        private static void AplicarTemaRecursivo(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl.Tag is string tag)
                {
                    switch (tag)
                    {
                        case "card": EstilizarCard(ctrl); break;
                        case "sidebar": EstilizarSidebar(ctrl); break;
                        case "topbar": EstilizarTopbar(ctrl); break;
                        case "stat-card": EstilizarStatCard(ctrl); break;
                        case "btn-primary": EstilizarBotonPrimario((Button)ctrl); break;
                        case "btn-secondary": EstilizarBotonSecundario((Button)ctrl); break;
                        case "btn-danger": EstilizarBotonPeligro((Button)ctrl); break;
                        case "input": EstilizarInput(ctrl); break;
                        case "label-title": EstilizarLabelTitulo((Label)ctrl); break;
                        case "label-sub": EstilizarLabelSub((Label)ctrl); break;
                        case "grid": EstilizarDataGridView((DataGridView)ctrl); break;
                        case "nav-active": EstilizarNavActivo((Button)ctrl); break;
                        case "nav-normal": EstilizarNavNormal((Button)ctrl); break;
                    }
                }

                // Aplicar fondo/texto base a controles sin tag especial
                if (ctrl.Tag == null || !(ctrl.Tag is string))
                {
                    if (ctrl is Label lbl && !(ctrl.Tag is string))
                    {
                        lbl.ForeColor = ColorTheme.TextoPrimario;
                        lbl.BackColor = Color.Transparent;
                    }
                    else if (ctrl is Panel || ctrl is GroupBox)
                    {
                        ctrl.BackColor = ColorTheme.FondoApp;
                        ctrl.ForeColor = ColorTheme.TextoPrimario;
                    }
                }

                if (ctrl.HasChildren)
                    AplicarTemaRecursivo(ctrl.Controls);
            }
        }

        // ============================================================
        // CONTENEDORES
        // ============================================================

        public static void EstilizarCard(Control ctrl)
        {
            ctrl.BackColor = ColorTheme.FondoCard;
            ctrl.ForeColor = ColorTheme.TextoPrimario;
        }

        public static void EstilizarSidebar(Control ctrl)
        {
            ctrl.BackColor = ColorTheme.FondoSidebar;
            ctrl.ForeColor = ColorTheme.TextoNavNormal;
        }

        public static void EstilizarTopbar(Control ctrl)
        {
            ctrl.BackColor = ColorTheme.FondoTopbar;
            ctrl.ForeColor = ColorTheme.TextoPrimario;
        }

        public static void EstilizarStatCard(Control ctrl)
        {
            ctrl.BackColor = ColorTheme.FondoStatCard;
            ctrl.ForeColor = ColorTheme.TextoPrimario;
        }

        // ============================================================
        // BOTONES
        // Uso: button1.Tag = "btn-primary"; UIHelper.EstilizarBotonPrimario(button1);
        // ============================================================

        public static void EstilizarBotonPrimario(Button btn)
        {
            btn.BackColor = ColorTheme.Primario;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ColorTheme.PrimarioHover;
            btn.FlatAppearance.MouseDownBackColor = ColorTheme.PrimarioHover;
            btn.Font = FuenteBold;
            btn.Cursor = Cursors.Hand;
            btn.Height = 36;
        }

        public static void EstilizarBotonSecundario(Button btn)
        {
            btn.BackColor = ColorTheme.FondoApp;
            btn.ForeColor = ColorTheme.Primario;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = ColorTheme.Primario;
            btn.FlatAppearance.MouseOverBackColor = ColorTheme.PrimarioSuave;
            btn.Font = FuenteBold;
            btn.Cursor = Cursors.Hand;
            btn.Height = 36;
        }

        public static void EstilizarBotonPeligro(Button btn)
        {
            btn.BackColor = ColorTheme.ErrorSuave;
            btn.ForeColor = ColorTheme.ErrorTexto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = ColorTheme.Error;
            btn.Font = FuenteBold;
            btn.Cursor = Cursors.Hand;
            btn.Height = 36;
        }

        // ============================================================
        // INPUTS (TextBox, ComboBox, DateTimePicker)
        // ============================================================

        public static void EstilizarInput(Control ctrl)
        {
            ctrl.BackColor = ColorTheme.FondoInput;
            ctrl.ForeColor = ColorTheme.TextoPrimario;
            ctrl.Font = FuenteNormal;

            if (ctrl is TextBox tb)
            {
                tb.BorderStyle = BorderStyle.FixedSingle;
            }
            if (ctrl is ComboBox cb)
            {
                cb.FlatStyle = FlatStyle.Flat;
            }
        }

        // ============================================================
        // LABELS
        // ============================================================

        public static void EstilizarLabelTitulo(Label lbl)
        {
            lbl.Font = FuenteTitulo;
            lbl.ForeColor = ColorTheme.TextoPrimario;
            lbl.BackColor = Color.Transparent;
        }

        public static void EstilizarLabelSub(Label lbl)
        {
            lbl.Font = FuenteSubtitulo;
            lbl.ForeColor = ColorTheme.TextoSecundario;
            lbl.BackColor = Color.Transparent;
        }

        // ============================================================
        // DATAGRIDVIEW
        // ============================================================

        public static void EstilizarDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorTheme.FondoCard;
            dgv.GridColor = ColorTheme.Borde;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Font = FuenteNormal;
            dgv.RowTemplate.Height = 36;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Cabeceras
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTheme.FondoStatCard;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTheme.TextoSecundario;
            dgv.ColumnHeadersDefaultCellStyle.Font = FuenteSmall;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.ColumnHeadersHeight = 32;

            // Filas pares e impares
            dgv.DefaultCellStyle.BackColor = ColorTheme.FondoCard;
            dgv.DefaultCellStyle.ForeColor = ColorTheme.TextoPrimario;
            dgv.DefaultCellStyle.SelectionBackColor = ColorTheme.PrimarioSuave;
            dgv.DefaultCellStyle.SelectionForeColor = ColorTheme.InfoTexto;
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTheme.FondoStatCard;
        }

        // ============================================================
        // NAVEGACIÓN SIDEBAR
        // ============================================================

        public static void EstilizarNavActivo(Button btn)
        {
            btn.BackColor = ColorTheme.FondoNavActivo;
            btn.ForeColor = ColorTheme.TextoNavActivo;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = FuenteBold;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(12, 0, 0, 0);
        }

        public static void EstilizarNavNormal(Button btn)
        {
            btn.BackColor = Color.Transparent;
            btn.ForeColor = ColorTheme.TextoNavNormal;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ColorTheme.FondoNavHover;
            btn.Font = FuenteNav;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(12, 0, 0, 0);
        }

        // ============================================================
        // BADGE DE ESTADO (devuelve un Panel con un Label dentro)
        // Uso: pnlEstado.Controls.Add(UIHelper.CrearBadgeEstado("activa"));
        // ============================================================

        public static Panel CrearBadgeEstado(string estado)
        {
            var (fondo, texto) = ColorTheme.ColoresBadgeEstado(estado);
            return CrearBadge(estado, fondo, texto);
        }

        public static Panel CrearBadgeRol(string rol)
        {
            var (fondo, texto) = ColorTheme.ColoresBadgeRol(rol);
            return CrearBadge(rol, fondo, texto);
        }

        private static Panel CrearBadge(string texto, Color fondo, Color textoColor)
        {
            var lbl = new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                ForeColor = textoColor,
                BackColor = Color.Transparent,
                AutoSize = true,
                Padding = new Padding(0)
            };

            var pnl = new Panel
            {
                BackColor = fondo,
                Padding = new Padding(8, 3, 8, 3),
                AutoSize = true
            };

            pnl.Controls.Add(lbl);
            lbl.Location = new Point(8, 3);

            // Bordes redondeados
            pnl.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = RoundedRect(pnl.ClientRectangle, 10))
                using (var brush = new SolidBrush(fondo))
                {
                    g.FillPath(brush, path);
                }
            };

            return pnl;
        }

        // ============================================================
        // BORDES REDONDEADOS para paneles/controles
        // Uso: pnl.Region = Region.FromHrgn(CreateRoundRectRgn(...))
        //   o usar en Paint con GraphicsPath
        // ============================================================

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ============================================================
        // APLICAR ESQUINAS REDONDEADAS A UN PANEL (en el evento Paint)
        // Uso: UIHelper.HacerCardRedondeada(panel1, 12);
        // ============================================================

        public static void HacerCardRedondeada(Panel pnl, int radio = 12)
        {
            pnl.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (var path = RoundedRect(pnl.ClientRectangle, radio))
                {
                    pnl.Region = new Region(path);
                    using (var pen = new Pen(ColorTheme.Borde, 1f))
                        g.DrawPath(pen, path);
                }
            };
        }

        // ============================================================
        // SEPARADOR HORIZONTAL
        // ============================================================

        public static Panel CrearSeparador(int ancho = 0)
        {
            return new Panel
            {
                BackColor = ColorTheme.Borde,
                Height = 1,
                Width = ancho > 0 ? ancho : 200,
                Padding = new Padding(0)
            };
        }

        // ============================================================
        // STAT CARD completa (Panel con número grande y etiqueta)
        // Uso: pnlStats.Controls.Add(UIHelper.CrearStatCard("12", "Reservas activas", ColorTheme.Primario));
        // ============================================================

        public static Panel CrearStatCard(string numero, string etiqueta, Color colorNumero)
        {
            var pnl = new Panel
            {
                BackColor = ColorTheme.FondoStatCard,
                Width = 150,
                Height = 80,
                Padding = new Padding(12)
            };

            var lblNum = new Label
            {
                Text = numero,
                Font = FuenteStatNum,
                ForeColor = colorNumero,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(12, 28)
            };

            var lblEtq = new Label
            {
                Text = etiqueta,
                Font = FuenteSmall,
                ForeColor = ColorTheme.TextoSecundario,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(12, 10)
            };

            pnl.Controls.Add(lblNum);
            pnl.Controls.Add(lblEtq);
            HacerCardRedondeada(pnl, 10);

            return pnl;
        }

        // ============================================================
        // MOSTRAR MENSAJE ESTILIZADO (reemplaza MessageBox plano)
        // ============================================================

        public static void MensajeExito(string texto, string titulo = "Éxito")
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MensajeError(string texto, string titulo = "Error")
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool MensajeConfirmar(string texto, string titulo = "Confirmar")
        {
            return MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes;
        }
    }
}