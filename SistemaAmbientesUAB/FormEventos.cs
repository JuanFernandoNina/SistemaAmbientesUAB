using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormEventos : Form
    {
        private const string BuscarPlaceholder = "Buscar evento...";

        public FormEventos()
        {
            InitializeComponent();
        }

        private void FormEventos_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarEventos();
        }

        // ── TEMA MINIMALISTA (mismo estilo que FormAmbientes / FormUsuarios) ──
        private void AplicarTema()
        {
            this.BackColor = Color.White;

            lblTitulo.ForeColor = TemaManager.TextoPrincipal;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblBuscar.ForeColor = TemaManager.TextoSecundario;
            lblMensaje.ForeColor = TemaManager.TextoMuted;

            AplicarEstiloTabla(dgvEventos);

            txtBuscar.BackColor = Color.White;
            txtBuscar.ForeColor = TemaManager.TextoMuted;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;

            EstiloBotonOutline(btnFiltrar, TemaManager.Acento);
            EstiloBotonSolido(btnNuevo, Color.FromArgb(40, 120, 40));
            EstiloBotonSolido(btnEditar, Color.FromArgb(40, 80, 160));
            EstiloBotonSolido(btnEliminar, Color.FromArgb(160, 40, 40));
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

        private static void EstiloBotonOutline(Button btn, Color color)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = color;
            btn.FlatAppearance.BorderSize = 1;
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
        private void CargarEventos()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string buscar = ObtenerTextoBusqueda();
                    string filtroBuscar = !string.IsNullOrWhiteSpace(buscar)
                        ? @"AND (e.nombre_evento LIKE @buscar
                              OR u.nombre_completo LIKE @buscar
                              OR e.requerimientos LIKE @buscar)"
                        : "";

                    string query = $@"
                        SELECT
                            e.id_evento           AS ID,
                            e.nombre_evento        AS [Nombre del Evento],
                            u.nombre_completo       AS Responsable,
                            e.cantidad_asistentes   AS Asistentes,
                            CONVERT(VARCHAR,e.fecha_evento,103) AS [Fecha Evento],
                            e.requerimientos        AS Requerimientos,
                            ISNULL(a.codigo, 'Sin asignar') AS Ambiente,
                            ISNULL(r.estado, 'sin reserva')  AS [Estado Reserva]
                        FROM Evento e
                        INNER JOIN Usuario u  ON e.id_responsable = u.id_usuario
                        LEFT JOIN  Reserva r  ON r.id_evento = e.id_evento
                        LEFT JOIN  Ambiente a ON r.id_ambiente = a.id_ambiente
                        WHERE 1=1 {filtroBuscar}
                        ORDER BY e.fecha_evento DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (!string.IsNullOrWhiteSpace(buscar))
                        cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEventos.DataSource = dt;

                    if (dgvEventos.Columns.Contains("ID"))
                        dgvEventos.Columns["ID"].Visible = false;

                    lblMensaje.Text = $"Total: {dt.Rows.Count} evento(s)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar eventos: " + ex.Message);
            }
        }

        // ── PINTURA DE CELDAS (badge de estado de reserva) ────
        private void dgvEventos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvEventos.Columns[e.ColumnIndex].Name == "Estado Reserva")
                PintarBadgeEstado(e);
        }

        private void PintarBadgeEstado(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            PintarFondoCelda(e);

            string estado = Convert.ToString(e.Value);
            Color fondo, texto;

            switch (estado)
            {
                case "activa":
                    fondo = Color.FromArgb(220, 252, 231); texto = Color.FromArgb(16, 185, 129); break;
                case "cancelada":
                    fondo = Color.FromArgb(254, 226, 226); texto = Color.FromArgb(239, 68, 68); break;
                case "finalizada":
                    fondo = Color.FromArgb(241, 245, 249); texto = Color.FromArgb(100, 116, 139); break;
                default: // sin reserva
                    fondo = Color.FromArgb(254, 243, 199); texto = Color.FromArgb(245, 158, 11); break;
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
            CargarEventos();
        }

        // ── EVENTOS ───────────────────────────────────────────
        private void btnFiltrar_Click(object sender, EventArgs e) => CargarEventos();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new FormEventoDetalle(0).ShowDialog();
            CargarEventos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEventos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un evento para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvEventos.SelectedRows[0].Cells["ID"].Value);
            new FormEventoDetalle(id).ShowDialog();
            CargarEventos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEventos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un evento para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvEventos.SelectedRows[0].Cells["ID"].Value);
            string nombre = dgvEventos.SelectedRows[0].Cells["Nombre del Evento"].Value?.ToString();
            string estadoReserva = dgvEventos.SelectedRows[0].Cells["Estado Reserva"].Value?.ToString();

            string advertenciaReserva = estadoReserva == "activa"
                ? "\n\n⚠️ Este evento tiene una reserva ACTIVA asociada. " +
                  "La reserva quedará sin evento vinculado (no se cancela ni se borra)."
                : "";

            if (MessageBox.Show($"¿Eliminar el evento '{nombre}'?{advertenciaReserva}",
                    "Eliminar Evento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    // Desvincular la reserva (si existe) antes de borrar el evento,
                    // porque Reserva.id_evento es FK nullable hacia Evento.
                    SqlCommand cmdDesvincular = new SqlCommand(
                        "UPDATE Reserva SET id_evento = NULL WHERE id_evento = @id", con);
                    cmdDesvincular.Parameters.AddWithValue("@id", id);
                    cmdDesvincular.ExecuteNonQuery();

                    SqlCommand cmdEliminar = new SqlCommand(
                        "DELETE FROM Evento WHERE id_evento = @id", con);
                    cmdEliminar.Parameters.AddWithValue("@id", id);
                    cmdEliminar.ExecuteNonQuery();
                }

                lblMensaje.Text = $"✅ Evento '{nombre}' eliminado correctamente.";
                lblMensaje.ForeColor = TemaManager.Exito;
                CargarEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }
    }
}