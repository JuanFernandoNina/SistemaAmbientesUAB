using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormDetalleMisReservas : Form
    {
        private int _idReserva;
        private bool _esCancelacion;

        // Modificamos el constructor para recibir los parámetros esenciales
        public FormDetalleMisReservas(int idReserva, bool esCancelacion)
        {
            InitializeComponent();
            this._idReserva = idReserva;
            this._esCancelacion = esCancelacion;
        }

        private void FormDetalleMisReservas_Load(object sender, EventArgs e)
        {
            EstilarFormulario();
            CargarDatosReserva();
            ConfigurarModoInterfaz();
        }

        private void EstilarFormulario()
        {
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Paleta de colores consistente con TemaManager
            lblTitulo.ForeColor = TemaManager.TextoPrincipal;

            // Botón Cancelar/Cerrar común
            btnCerrar.BackColor = Color.White;
            btnCerrar.ForeColor = TemaManager.TextoSecundario;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(218, 224, 233);
        }

        private void ConfigurarModoInterfaz()
        {
            if (_esCancelacion)
            {
                this.Text = "Cancelar Reserva - Sistema Ambientes UAB";
                lblTitulo.Text = "Cancelar Reserva";

                // Mostrar controles para ingresar el motivo de la cancelación
                lblMotivoCancelacion.Visible = true;
                txtMotivoCancelacion.Visible = true;

                // Bloquear los datos de la reserva (Solo lectura en modo cancelación)
                txtMotivoEvento.ReadOnly = true;
                numAsistentes.Enabled = false;

                // Estilo botón de acción peligro (Rojo elegante)
                btnGuardar.Text = "Confirmar Cancelación";
                btnGuardar.BackColor = TemaManager.Peligro;
                btnGuardar.ForeColor = Color.White;
                btnGuardar.FlatStyle = FlatStyle.Flat;
                btnGuardar.FlatAppearance.BorderSize = 0;
            }
            else
            {
                this.Text = "Detalle y Edición de Reserva - Sistema Ambientes UAB";
                lblTitulo.Text = "Editar Reserva";

                // Ocultar sección de cancelación
                lblMotivoCancelacion.Visible = false;
                txtMotivoCancelacion.Visible = false;

                // Permitir edición de los datos permitidos
                txtMotivoEvento.ReadOnly = false;
                numAsistentes.Enabled = true;

                // Estilo botón de acción éxito/acento (Azul institucional)
                btnGuardar.Text = "Guardar Cambios";
                btnGuardar.BackColor = TemaManager.Acento;
                btnGuardar.ForeColor = Color.White;
                btnGuardar.FlatStyle = FlatStyle.Flat;
                btnGuardar.FlatAppearance.BorderSize = 0;
            }
        }

        private void CargarDatosReserva()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT r.motivo, r.cantidad_asistentes, r.fecha_inicio, 
                               r.hora_inicio, r.hora_fin, a.codigo AS Ambiente, b.nombre AS Bloque
                        FROM Reserva r
                        INNER JOIN Ambiente a ON r.id_ambiente = a.id_ambiente
                        INNER JOIN Bloque b ON a.id_bloque = b.id_bloque
                        WHERE r.id_reserva = @idReserva";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idReserva", _idReserva);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Llenar campos informativos fijos
                                lblInfoAmbiente.Text = $"{reader["Bloque"]} - Aula {reader["Ambiente"]}";
                                lblInfoHorario.Text = $"{Convert.ToDateTime(reader["fecha_inicio"]):dd/MM/yyyy} ({reader["hora_inicio"]} - {reader["hora_fin"]})";

                                // Campos editables
                                txtMotivoEvento.Text = reader["motivo"].ToString();
                                numAsistentes.Value = Convert.ToInt32(reader["cantidad_asistentes"]);
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron los detalles de la reserva seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar datos de la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_esCancelacion)
            {
                EjecutarCancelacion();
            }
            else
            {
                EjecutarEdicion();
            }
        }

        private void EjecutarEdicion()
        {
            if (string.IsNullOrWhiteSpace(txtMotivoEvento.Text))
            {
                MessageBox.Show("El motivo o nombre del evento no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        UPDATE Reserva 
                        SET motivo = @motivo, cantidad_asistentes = @asistentes 
                        WHERE id_reserva = @idReserva";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@motivo", txtMotivoEvento.Text.Trim());
                        cmd.Parameters.AddWithValue("@asistentes", (int)numAsistentes.Value);
                        cmd.Parameters.AddWithValue("@idReserva", _idReserva);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Reserva actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar las modificaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EjecutarCancelacion()
        {
            if (string.IsNullOrWhiteSpace(txtMotivoCancelacion.Text))
            {
                MessageBox.Show("Es obligatorio que especifique un motivo detallado para cancelar esta reserva.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Confirmar la cancelación definitiva de este espacio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    using (SqlTransaction transaccion = con.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insertar rastro en tabla Cancelacion
                            string queryCancelacion = @"
                                INSERT INTO Cancelacion (id_reserva, fecha_cancelacion, motivo) 
                                VALUES (@idReserva, GETDATE(), @motivoCancel)";

                            using (SqlCommand cmdCancel = new SqlCommand(queryCancelacion, con, transaccion))
                            {
                                cmdCancel.Parameters.AddWithValue("@idReserva", _idReserva);
                                cmdCancel.Parameters.AddWithValue("@motivoCancel", txtMotivoCancelacion.Text.Trim());
                                cmdCancel.ExecuteNonQuery();
                            }

                            // 2. Modificar estado de la Reserva principal
                            string queryUpdate = "UPDATE Reserva SET estado = 'cancelada' WHERE id_reserva = @idReserva";
                            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con, transaccion))
                            {
                                cmdUpdate.Parameters.AddWithValue("@idReserva", _idReserva);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            MessageBox.Show("La reserva ha sido cancelada y el espacio liberado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception exTrans)
                        {
                            transaccion.Rollback();
                            throw exTrans;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el proceso de cancelación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}