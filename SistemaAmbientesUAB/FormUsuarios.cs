using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormUsuarios : Form
    {
        private const string BuscarPlaceholder = "Buscar usuario...";

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarUsuarios();
        }

        // ── TEMA MINIMALISTA ──────────────────────────────────
        private void AplicarTema()
        {
            this.BackColor = Color.White;

            lblTitulo.ForeColor      = TemaManager.TextoPrincipal;
            lblTitulo.Font           = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblBuscar.ForeColor      = TemaManager.TextoSecundario;
            lblTipoFiltro.ForeColor  = TemaManager.TextoSecundario;
            lblMensaje.ForeColor     = TemaManager.TextoMuted;

            AplicarEstiloTabla(dgvUsuarios);

            txtBuscar.BackColor    = Color.White;
            txtBuscar.ForeColor    = TemaManager.TextoMuted;
            txtBuscar.BorderStyle  = BorderStyle.FixedSingle;

            cmbTipoFiltro.BackColor = Color.White;
            cmbTipoFiltro.ForeColor = TemaManager.TextoPrincipal;
            cmbTipoFiltro.FlatStyle = FlatStyle.Flat;

            EstiloBotonOutline(btnFiltrar,       TemaManager.Acento);
            EstiloBotonSolido(btnNuevo,          Color.FromArgb(40, 120, 40));
            EstiloBotonSolido(btnEditar,         Color.FromArgb(40, 80, 160));
            EstiloBotonSolido(btnToggleEstado,   Color.FromArgb(160, 100, 0));
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

        private static void EstiloBotonOutline(Button btn, Color color)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = color;
            btn.FlatAppearance.BorderSize  = 1;
            btn.Cursor = Cursors.Hand;
        }

        private static void EstiloBotonSolido(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }

        // ── DATOS ─────────────────────────────────────────────
        private void CargarUsuarios(string buscar = "", string tipo = "Todos")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string filtroBuscar = !string.IsNullOrWhiteSpace(buscar)
                        ? "AND (nombre_completo LIKE @buscar OR codigo LIKE @buscar OR username LIKE @buscar OR correo LIKE @buscar)" : "";
                    string filtroTipo = tipo != "Todos" ? "AND tipo_usuario = @tipo" : "";

                    string query = $@"
                        SELECT
                            id_usuario      AS ID,
                            codigo          AS Código,
                            nombre_completo AS Nombre,
                            tipo_usuario    AS Tipo,
                            carrera_area    AS [Carrera/Área],
                            correo          AS Correo,
                            username        AS Usuario,
                            CASE WHEN es_admin=1 THEN '✅' ELSE '❌' END AS Admin,
                            estado          AS Estado
                        FROM Usuario
                        WHERE 1=1 {filtroBuscar} {filtroTipo}
                        ORDER BY nombre_completo";

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (!string.IsNullOrWhiteSpace(buscar)) cmd.Parameters.AddWithValue("@buscar", $"%{buscar}%");
                    if (tipo != "Todos")                    cmd.Parameters.AddWithValue("@tipo", tipo);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsuarios.DataSource = dt;

                    if (dgvUsuarios.Columns.Contains("ID"))
                        dgvUsuarios.Columns["ID"].Visible = false;

                    lblMensaje.Text = $"Total: {dt.Rows.Count} usuario(s)";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar usuarios: " + ex.Message); }
        }

        // ── PINTURA DE CELDAS ─────────────────────────────────
        private void dgvUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string col = dgvUsuarios.Columns[e.ColumnIndex].Name;

            if (col == "Estado")
                PintarBadgeEstadoUsuario(e);
            else if (col == "Tipo")
                PintarBadgeTipo(e);
        }

        private void PintarBadgeEstadoUsuario(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string estado = Convert.ToString(e.Value);
            Color fondo = estado == "activo"
                ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
            Color texto = estado == "activo"
                ? Color.FromArgb(16, 185, 129)  : Color.FromArgb(239, 68, 68);

            PintarBadge(e, estado, fondo, texto);
        }

        private void PintarBadgeTipo(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string tipo = Convert.ToString(e.Value);
            Color fondo, texto;
            switch (tipo)
            {
                case "docente":
                    fondo = Color.FromArgb(209, 250, 229); texto = Color.FromArgb(6, 95, 70);  break;
                case "estudiante":
                    fondo = Color.FromArgb(219, 234, 254); texto = Color.FromArgb(30, 64, 175); break;
                case "iglesia":
                    fondo = Color.FromArgb(237, 233, 254); texto = Color.FromArgb(92, 45, 145); break;
                default: // administrativo
                    fondo = Color.FromArgb(254, 243, 199); texto = Color.FromArgb(146, 64, 14); break;
            }

            PintarBadge(e, tipo, fondo, texto);
        }

        private void PintarBadge(DataGridViewCellPaintingEventArgs e, string texto, Color fondo, Color colorTexto)
        {
            Size ts = TextRenderer.MeasureText(texto, new Font("Segoe UI Semibold", 8F, FontStyle.Bold));
            Rectangle badge = new Rectangle(
                e.CellBounds.Left + 9,
                e.CellBounds.Top + (e.CellBounds.Height - 22) / 2,
                ts.Width + 18, 22);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var gp = RoundedPath(badge, badge.Height))
            using (var br = new SolidBrush(fondo))
                e.Graphics.FillPath(br, gp);

            TextRenderer.DrawText(e.Graphics, texto,
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                badge, colorTexto,
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

        // ── PLACEHOLDER BUSCADOR ──────────────────────────────
        private string ObtenerTextoBusqueda()
        {
            string t = txtBuscar.Text.Trim();
            return t == BuscarPlaceholder ? "" : t;
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text != BuscarPlaceholder) return;
            txtBuscar.Text      = "";
            txtBuscar.ForeColor = TemaManager.TextoPrincipal;
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            txtBuscar.Text      = BuscarPlaceholder;
            txtBuscar.ForeColor = TemaManager.TextoMuted;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == BuscarPlaceholder) return;
            CargarUsuarios(ObtenerTextoBusqueda(), cmbTipoFiltro.SelectedItem?.ToString() ?? "Todos");
        }

        // ── EVENTOS ───────────────────────────────────────────
        private void btnFiltrar_Click(object sender, EventArgs e) =>
            CargarUsuarios(ObtenerTextoBusqueda(), cmbTipoFiltro.SelectedItem?.ToString() ?? "Todos");

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new FormUsuarioDetalle(0).ShowDialog();
            CargarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["ID"].Value);
            new FormUsuarioDetalle(id).ShowDialog();
            CargarUsuarios();
        }

        private void btnToggleEstado_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int    id           = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["ID"].Value);
            string estadoActual = dgvUsuarios.SelectedRows[0].Cells["Estado"].Value?.ToString();
            string nombre       = dgvUsuarios.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            string nuevoEstado  = estadoActual == "activo" ? "inactivo" : "activo";

            if (MessageBox.Show($"¿Cambiar estado de '{nombre}' a '{nuevoEstado}'?",
                    "Cambiar Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Usuario SET estado=@estado WHERE id_usuario=@id", con);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                lblMensaje.Text      = $"✅ '{nombre}' ahora está {nuevoEstado}.";
                lblMensaje.ForeColor = TemaManager.Exito;
                CargarUsuarios();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
