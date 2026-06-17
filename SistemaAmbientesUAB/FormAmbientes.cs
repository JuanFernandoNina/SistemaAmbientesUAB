using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormAmbientes : Form
    {
        private const string BuscarPlaceholder = "Buscar ambiente...";

        public FormAmbientes()
        {
            InitializeComponent();
        }

        private void FormAmbientes_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarBloques();
            CargarAmbientes();
        }

        // ── TEMA MINIMALISTA (mismo estilo que MisReservas) ───
        private void AplicarTema()
        {
            this.BackColor = Color.White;

            lblTitulo.ForeColor = TemaManager.TextoPrincipal;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);

            lblBloque.ForeColor = TemaManager.TextoSecundario;
            lblTipo.ForeColor   = TemaManager.TextoSecundario;
            lblMensaje.ForeColor = TemaManager.TextoMuted;

            AplicarEstiloTabla(dgvAmbientes);

            cmbBloque.BackColor = Color.White;
            cmbBloque.ForeColor = TemaManager.TextoPrincipal;
            cmbBloque.FlatStyle = FlatStyle.Flat;

            cmbTipo.BackColor = Color.White;
            cmbTipo.ForeColor = TemaManager.TextoPrincipal;
            cmbTipo.FlatStyle = FlatStyle.Flat;

            // Botón filtrar — estilo outline azul
            EstiloBotonOutline(btnFiltrar, TemaManager.Acento);

            // Botones de acción
            EstiloBotonSolido(btnNuevo,        Color.FromArgb(40, 120, 40));
            EstiloBotonSolido(btnEditar,       Color.FromArgb(40, 80, 160));
            EstiloBotonSolido(btnCambiarEstado, Color.FromArgb(160, 100, 0));
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

            // Filas
            dgv.DefaultCellStyle.BackColor           = Color.White;
            dgv.DefaultCellStyle.ForeColor           = TemaManager.TextoPrincipal;
            dgv.DefaultCellStyle.SelectionBackColor  = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor  = TemaManager.TextoPrincipal;
            dgv.DefaultCellStyle.Font                = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding             = new Padding(9, 0, 9, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor          = Color.FromArgb(247, 249, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TemaManager.TextoPrincipal;

            // Cabecera
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
        private void CargarBloques()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_bloque, nombre FROM Bloque ORDER BY nombre", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    cmbBloque.Items.Clear();
                    cmbBloque.Items.Add(new { id = 0, nombre = "Todos" });
                    while (dr.Read())
                        cmbBloque.Items.Add(new { id = dr["id_bloque"], nombre = dr["nombre"].ToString() });

                    cmbBloque.DisplayMember = "nombre";
                    cmbBloque.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar bloques: " + ex.Message); }
        }

        private void CargarAmbientes(int idBloque = 0, string tipo = "Todos")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string buscar      = ObtenerTextoBusqueda();
                    string filtroBuscar = !string.IsNullOrWhiteSpace(buscar)
                        ? "AND (a.codigo LIKE @buscar OR b.nombre LIKE @buscar OR a.tipo LIKE @buscar OR a.estado LIKE @buscar)" : "";
                    string filtroBloque = idBloque > 0 ? "AND a.id_bloque = @idBloque" : "";
                    string filtroTipo   = tipo != "Todos" ? "AND a.tipo = @tipo" : "";

                    string query = $@"
                        SELECT
                            a.id_ambiente  AS ID,
                            b.nombre       AS Bloque,
                            a.codigo       AS Código,
                            a.tipo         AS Tipo,
                            a.capacidad    AS Capacidad,
                            CASE WHEN a.tiene_proyector    = 1 THEN '✅' ELSE '❌' END AS Proyector,
                            CASE WHEN a.tiene_computadoras = 1 THEN '✅' ELSE '❌' END AS Computadoras,
                            CASE WHEN a.tiene_enchufes     = 1 THEN '✅' ELSE '❌' END AS Enchufes,
                            a.estado       AS Estado
                        FROM Ambiente a
                        INNER JOIN Bloque b ON a.id_bloque = b.id_bloque
                        WHERE 1=1 {filtroBloque} {filtroTipo} {filtroBuscar}
                        ORDER BY b.nombre, a.codigo";

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (idBloque > 0)                       cmd.Parameters.AddWithValue("@idBloque", idBloque);
                    if (tipo != "Todos")                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    if (!string.IsNullOrWhiteSpace(buscar)) cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAmbientes.DataSource = dt;

                    // Ocultar ID
                    if (dgvAmbientes.Columns.Contains("ID"))
                        dgvAmbientes.Columns["ID"].Visible = false;

                    lblMensaje.Text = $"Total: {dt.Rows.Count} ambiente(s)";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar ambientes: " + ex.Message); }
        }

        // ── PINTURA DE CELDAS ─────────────────────────────────
        private void dgvAmbientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAmbientes.Columns[e.ColumnIndex].Name == "Estado")
                PintarBadgeEstadoAmbiente(e);
        }

        private void PintarBadgeEstadoAmbiente(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string estado = Convert.ToString(e.Value);
            Color fondo, texto;

            switch (estado)
            {
                case "disponible":
                    fondo = Color.FromArgb(220, 252, 231); texto = Color.FromArgb(16, 185, 129); break;
                case "mantenimiento":
                    fondo = Color.FromArgb(254, 243, 199); texto = Color.FromArgb(245, 158, 11); break;
                default: // inhabilitado
                    fondo = Color.FromArgb(254, 226, 226); texto = Color.FromArgb(239, 68, 68);  break;
            }

            Size ts = TextRenderer.MeasureText(estado, new Font("Segoe UI Semibold", 8F, FontStyle.Bold));
            Rectangle badge = new Rectangle(
                e.CellBounds.Left + 10,
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
            gp.AddArc(r.X,           r.Y,            d, d, 180, 90);
            gp.AddArc(r.Right - d,   r.Y,            d, d, 270, 90);
            gp.AddArc(r.Right - d,   r.Bottom - d,   d, d, 0,   90);
            gp.AddArc(r.X,           r.Bottom - d,   d, d, 90,  90);
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
            txtBuscar.Text = "";
            txtBuscar.ForeColor = TemaManager.TextoPrincipal;
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            txtBuscar.Text = BuscarPlaceholder;
            txtBuscar.ForeColor = TemaManager.TextoMuted;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == BuscarPlaceholder) return;
            int idBloque = 0;
            dynamic sel = cmbBloque.SelectedItem;
            if (sel != null) idBloque = (int)sel.id;
            CargarAmbientes(idBloque, cmbTipo.SelectedItem?.ToString() ?? "Todos");
        }

        // ── EVENTOS ───────────────────────────────────────────
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int idBloque = 0;
            dynamic sel = cmbBloque.SelectedItem;
            if (sel != null) idBloque = (int)sel.id;
            CargarAmbientes(idBloque, cmbTipo.SelectedItem?.ToString() ?? "Todos");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new FormAmbienteDetalle(0).ShowDialog();
            CargarAmbientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAmbientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ambiente para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvAmbientes.SelectedRows[0].Cells["ID"].Value);
            new FormAmbienteDetalle(id).ShowDialog();
            CargarAmbientes();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvAmbientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ambiente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int    id           = Convert.ToInt32(dgvAmbientes.SelectedRows[0].Cells["ID"].Value);
            string estadoActual = dgvAmbientes.SelectedRows[0].Cells["Estado"].Value?.ToString();
            string codigo       = dgvAmbientes.SelectedRows[0].Cells["Código"].Value?.ToString();
            string nuevoEstado  = estadoActual == "disponible"   ? "mantenimiento"
                                : estadoActual == "mantenimiento" ? "inhabilitado"
                                : "disponible";

            if (MessageBox.Show($"¿Cambiar {codigo} de '{estadoActual}' a '{nuevoEstado}'?",
                    "Cambiar Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Ambiente SET estado=@estado WHERE id_ambiente=@id", con);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                lblMensaje.Text      = $"✅ Estado actualizado a '{nuevoEstado}'";
                lblMensaje.ForeColor = TemaManager.Exito;
                CargarAmbientes();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
