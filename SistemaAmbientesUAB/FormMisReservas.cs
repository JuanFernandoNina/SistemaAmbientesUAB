using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormMisReservas : Form
    {
        // Variables locales para almacenar los datos heredados del login/menú
        private int _idUsuario;
        private bool _esAdmin;

        // Constructor corregido que recibe los 2 parámetros requeridos
        public FormMisReservas(int idUsuario, bool esAdmin)
        {
            InitializeComponent();
            this._idUsuario = idUsuario;
            this._esAdmin = esAdmin;
        }

        private void FormMisReservas_Load(object sender, EventArgs e)
        {
            // Forzar colores institucionales en la grilla mediante código lógico
            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 236, 247); // Celeste claro
            dgvReservas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(28, 37, 58);    // Texto oscuro institucional

            // Configurar diseño plano y limpio para las cabeceras de la tabla
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgvReservas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);

            // EJEMPLO DE USO FUTURO:
            // if (_esAdmin) { /* Cargar todas las reservas del sistema */ }
            // else { /* Cargar solo las reservas donde id_usuario == _idUsuario */ }
        }

        // ── PINTADO CONTORNO BUSCADOR FLAT ──────────────────────────────────────────
        private void panelBuscar_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, panelBuscar.Width - 1, panelBuscar.Height - 1);
            using (Pen pen = new Pen(Color.FromArgb(218, 224, 233), 1f))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        // ── MANEJO FIRME DEL CELLPAINTING (Firma estándar de WinForms) ─────────────────
        private void dgvReservas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.Handled = false; // Permite el renderizado nativo respetando el SelectionBackColor asignado
            }
        }

        // ── CONTROL DE PLACEHOLDER EN BUSCADOR ──────────────────────────────────────
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar reserva...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.FromArgb(28, 37, 58);
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar reserva...";
                txtBuscar.ForeColor = Color.FromArgb(150, 161, 184);
            }
        }

        // ── MÉTODOS DE LOGICA DE LA INTERFAZ COMPLEMENTARIOS ────────────────────────
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void btnEditar_Click(object sender, EventArgs e) { }
        private void btnCancelarReserva_Click(object sender, EventArgs e) { }
        private void btnEliminar_Click(object sender, EventArgs e) { }
        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void btnActualizar_Click(object sender, EventArgs e) { }
        private void dgvReservas_SelectionChanged(object sender, EventArgs e) { }
        private void btnAnterior_Click(object sender, EventArgs e) { }
        private void btnSiguiente_Click(object sender, EventArgs e) { }
        private void btnPagina_Click(object sender, EventArgs e) { }
        private void FormMisReservas_Resize(object sender, EventArgs e) { }
    }
}