﻿using SistemaGestorEscolar.MessageBox_Personalizados;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaGestorEscolar
{
    public partial class IRegistroPago : Form
    {
        public IRegistroPago()
        {
            InitializeComponent();
        }
        public static Image image;
        IMessageBoxCheck box = new IMessageBoxCheck();
        IMessageBoxError boxError = new IMessageBoxError();
        clsUtilidades utilidades = new clsUtilidades();
        IMessageBoxCheck message = new IMessageBoxCheck();
        private databaseConnection dbConn = new databaseConnection();
        
        private int idUltimaMensualidad;

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {
        }

        private void IRegistroPago_Load(object sender, EventArgs e)
        {
            txtMontoPagar.Enabled = false;
            txtDescuento.Enabled = false;
            btnRegistrarPago.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void grpDatosPago_Enter(object sender, EventArgs e)
        {
        }

        private void txtIdentidadEstudiante_TextChanged(object sender, EventArgs e)
        {
            String idEstudiante;

            long number = 0;
            try
            {
                if (txtIdentidadEstudiante.Text != String.Empty)
                {
                    txtIdentidadEstudiante.ForeColor = Color.Black;
                    errorIdentidad.Clear();
                    if (long.TryParse(txtIdentidadEstudiante.Text, out number))
                    {
                        txtIdentidadEstudiante.ForeColor = Color.Black;
                        errorIdentidad.Clear();

                        if (txtIdentidadEstudiante.TextLength == 13)
                        {
                            txtIdentidadEstudiante.ForeColor = Color.Green;
                            errorIdentidad.Clear();

                            idEstudiante = dbConn.obtenerVariableString("SELECT MAX(id_Mensualidad) FROM detalleMensualidades WHERE id_Estudiante = " + txtIdentidadEstudiante.Text);

                            if (!string.IsNullOrEmpty(idEstudiante))
                            {
                                dbConn.llenarTextBox(txtNombreEstudiante, "SELECT concat(primerNombre, ' ', segundoNombre, ' ', primerApellido, ' ', segundoApellido) FROM datosEstudiante WHERE identidadEstudiante = " + txtIdentidadEstudiante.Text);
                                idUltimaMensualidad = dbConn.obtenerVariableEntera("SELECT MAX(id_Mensualidad) FROM detalleMensualidades WHERE id_Estudiante = " + txtIdentidadEstudiante.Text);
                                txtMontoPagar.Enabled = true;
                                dbConn.llenarTextBox(txtNombreEncargado, "SELECT concat(primerNombre, ' ', segundoNombre, ' ', primerApellido, ' ', segundoApellido) " +
                                                        "FROM datosEncargado de inner join matricula m on de.identidadEncargado = m.id_EncargadoAlumno WHERE m.id_Estudiante = " + txtIdentidadEstudiante.Text);
                                dbConn.llenarTextBox(txtNoFactura, "SELECT count(*) FROM detalleMensualidades WHERE id_Estudiante = " + txtIdentidadEstudiante.Text);
                                dbConn.llenarTextBox(txtFechaFacturacion, "SELECT fechaFacturacion FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad); dbConn.llenarTextBox(txtFechaFacturacion, "SELECT fechaFacturacion FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                                dbConn.llenarTextBox(txtTotalPagar, "SELECT deudaPendiente FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                                dbConn.llenarTextBox(txtSaldoDisponible, "SELECT saldoDisponible FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                            }
                        }
                        else if (txtIdentidadEstudiante.TextLength > 13 || txtIdentidadEstudiante.TextLength < 13)
                        {
                            txtIdentidadEstudiante.ForeColor = Color.Red;
                            errorIdentidad.SetError(this.txtIdentidadEstudiante, "El numero de Identidad no es Correcto!");
                            limpiarPantalla();
                            txtMontoPagar.Enabled = false;
                        }
                    }
                    else
                    {
                        txtIdentidadEstudiante.ForeColor = Color.Red;
                        errorIdentidad.SetError(this.txtIdentidadEstudiante, "Solo se Permiten Numeros!");
                        limpiarPantalla();
                        txtMontoPagar.Enabled = false;
                    }
                }
                else
                {
                    errorIdentidad.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void limpiarPantalla()
        {
            txtNombreEncargado.Clear();
            txtNombreEstudiante.Clear();
            txtNoFactura.Clear();
            txtFechaFacturacion.Clear();
            txtTotalPagar.Clear();
            txtSaldoDisponible.Clear();
            txtDescuento.Clear();
            txtMontoPagar.Clear();
        }

        private void txtNoFactura_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSaldoDisponible_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
        }

        private void txtTotalPagar_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFechaFacturacion_TextChanged(object sender, EventArgs e)
        {
        }

        private void chkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDescuento.Checked == true)
            {
                txtDescuento.Enabled = true;
                txtMontoPagar.Enabled = false;
            }
            else if (chkDescuento.Checked == false)
            {
                txtDescuento.Clear();
                txtDescuento.Enabled = false;
                txtMontoPagar.Enabled = true;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDescuento.Checked == true)
                {
                        if (image != null)
                        {
                            if (dbConn.PARegistroPago(txtIdentidadEstudiante.Text, Double.Parse(txtMontoPagar.Text), DateTime.Now, Double.Parse(txtDescuento.Text), image))
                            {

                                message.lblCheck.Text = "PAGO REGISTRADO";
                                message.ShowDialog();

                                dbConn.llenarTextBox(txtTotalPagar, "SELECT deudaPendiente FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                                dbConn.llenarTextBox(txtSaldoDisponible, "SELECT saldoDisponible FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                                txtMontoPagar.Clear();
                                txtDescuento.Clear();
                                chkDescuento.Checked = false;
                            }
                            else
                            {
                                MessageBox.Show("Error al Realizar el Pago", "Error Inesperado", MessageBoxButtons.OK);
                            }
                    }
                    else
                    {
                            MessageBox.Show("Ingrese un Comprobante de Pago", "Sin Comprobante", MessageBoxButtons.OK);
                    }
                }
                else if (chkDescuento.Checked == false)
                {
                    if (image != null)
                    {
                        if (dbConn.PARegistroPago(txtIdentidadEstudiante.Text, Double.Parse(txtMontoPagar.Text), DateTime.Now, 0, image))
                        {
                        message.lblCheck.Text = "PAGO REGISTRADO";
                        message.ShowDialog();
                        dbConn.llenarTextBox(txtTotalPagar, "SELECT deudaPendiente FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                        dbConn.llenarTextBox(txtSaldoDisponible, "SELECT saldoDisponible FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                        txtMontoPagar.Clear();
                        txtDescuento.Clear();
                        chkDescuento.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Error al Realizar el Pago", "Error Inesperado", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un Comprobante de Pago", "Sin Comprobante", MessageBoxButtons.OK);
                    }
                }
            }
                if(image != null)
                {
                    if (dbConn.PARegistroPago(txtIdentidadEstudiante.Text, Double.Parse(txtMontoPagar.Text), DateTime.Now, 0, image))
                    {
                        box.lblCheck.Text = "PAGO REGISTRADO EXITOSAMENTE";
                        box.ShowDialog();
                        //MessageBox.Show("Pago Registrado Exitosamente", "Pago Realizado", MessageBoxButtons.OK);
                        dbConn.llenarTextBox(txtTotalPagar, "SELECT deudaPendiente FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                        dbConn.llenarTextBox(txtSaldoDisponible, "SELECT saldoDisponible FROM detalleMensualidades WHERE id_Mensualidad = " + idUltimaMensualidad);
                        txtMontoPagar.Clear();
                        txtDescuento.Clear();
                        chkDescuento.Checked = false;
                    }
                    else
                    {
                        boxError.lblError.Text = "ERROR INESPERADO EN PAGO";
                        boxError.ShowDialog();
                        //MessageBox.Show("Error al Realizar el Pago", "Error Inesperado", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    boxError.lblError.Text = "INGRESE UN COMPROBANTE";
                    boxError.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtMontoPagar_TextChanged(object sender, EventArgs e)
        {
            int number = 0;
            try
            {
                if (txtMontoPagar.Text != String.Empty)
                {
                    txtMontoPagar.ForeColor = Color.Black;
                    errorIdentidad.Clear();

                    if (int.TryParse(txtMontoPagar.Text, out number))
                    {
                        if (Int32.Parse(txtMontoPagar.Text) > 1)
                        {
                            if (txtNoFactura.Text != string.Empty)
                            {
                                btnRegistrarPago.Enabled = true;
                            }
                            else
                            {
                                btnRegistrarPago.Enabled = false;
                            }
                        }
                        else
                        {
                            txtMontoPagar.ForeColor = Color.Red;
                            btnRegistrarPago.Enabled = false;
                            errorIdentidad.SetError(this.txtMontoPagar, "Debe pagar un monto mayor a 0!");
                        }
                    }
                    else
                    {
                        txtMontoPagar.ForeColor = Color.Red;
                        btnRegistrarPago.Enabled = false;
                        errorIdentidad.SetError(this.txtMontoPagar, "Solo se Permiten Numeros!");
                    }
                }
                else
                {
                    errorIdentidad.Clear();
                    btnRegistrarPago.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            int number = 0;

            try
            {
                if (txtDescuento.Text != String.Empty)
                {
                    txtDescuento.ForeColor = Color.Black;
                    errorIdentidad.Clear();

                    if (int.TryParse(txtDescuento.Text, out number))
                    {
                        if (Int32.Parse(txtDescuento.Text) > 100)
                        {
                            if (txtNoFactura.Text != string.Empty)
                            {
                                txtDescuento.ForeColor = Color.Green;
                                txtMontoPagar.Enabled = true;
                      
                            }
                            else
                            {
                                btnRegistrarPago.Enabled = false;
                            }
                        }
                        else
                        {
                            txtDescuento.ForeColor = Color.Red;
                            txtMontoPagar.Enabled = false;
                            errorIdentidad.SetError(this.txtDescuento, "Debe pagar un monto mayor a 0!");
                        }
                    }
                    else
                    {
                        txtDescuento.ForeColor = Color.Red;
                        txtMontoPagar.Enabled = false;
                        errorIdentidad.SetError(this.txtDescuento, "Solo se Permiten Numeros!");
                    }
                }
                else
                {
                    errorIdentidad.Clear();
                    txtMontoPagar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnImagenAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Imagen JPG|*.JPG|Imagen PNG|*.PNG";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image = Image.FromFile(fileDialog.FileName);
            }
        }

        private void btnImagenExistente_Click(object sender, EventArgs e)
        {
            frmMostrarImagenEvidencia frmImagen = new frmMostrarImagenEvidencia();
            if(image != null)
            {
                frmImagen.pictureBox1.Image = image;
            }
            else
            {
                frmImagen.pictureBox1.Image = Properties.Resources.imgComprobantePendiente;
            }
            frmImagen.label2.Text = "Fecha de Ingreso: " + DateTime.Now.ToShortDateString();
            frmImagen.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            frmImagen.Show();
        }
    }
}