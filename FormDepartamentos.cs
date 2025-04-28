using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormEmpleados
{
    public partial class FormDepartamentos : Form
    {
        public FormDepartamentos()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private bool ValidateCodigo()
        {
            string codigoText = txtCodigo.Text.Trim();

            if (string.IsNullOrEmpty(codigoText))
            {
                MessageBox.Show("Por favor ingrese un código",
                              "Error de validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }

            if (codigoText.Length != 4)
            {
                MessageBox.Show("El código debe tener exactamente 4 dígitos",
                               "Error de validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }

            if (!codigoText.All(char.IsDigit))
            {
                MessageBox.Show("El código solo debe contener números",
                               "Error de validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }

            return true;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = new string(txtCodigo.Text.Where(char.IsDigit).ToArray());
            txtCodigo.SelectionStart = txtCodigo.Text.Length;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
                    }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Console.WriteLine("buscando por código de departamento" + txtCodigoBuscar);
            Departamento departamento = new Departamento();
            string codigo = txtCodigoBuscar.Text;
            departamento = DepartamentoDAO.buscarDepartamento(codigo);
            if (departamento != null)
            {
                textBox6.Text = departamento.codigo.ToString();
                textBox5.Text = departamento.nombre;
            }
        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidateCodigo())
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para el departamento",
                               "Error de validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                textNombre.Focus();
                return;
            }
            int codigo = int.Parse(txtCodigo.Text.Trim());
            try
            {
                Departamento departamento = new Departamento();
                DepartamentoDAO departamentoDAO = new DepartamentoDAO();
                departamento.codigo = codigo;
                departamento.nombre = textNombre.Text.Trim();

                int resp = departamentoDAO.crearDepartamento(departamento);

                if (resp > 0)
                {
                    MessageBox.Show("Departamento registrado en Base de Datos",
                                  "AVISO DE SISTEMA",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Departamento No fue registrado en Base de Datos.",
                                  "AVISO DE SISTEMA",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar departamento: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
           
        }

        private void ClearForm()
        {
            txtCodigo.Text = "";
            textNombre.Text = "";
            txtCodigo.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRutBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Departamento departamento = new Departamento();
            DepartamentoDAO departamentoDAO = new DepartamentoDAO();
            departamento.codigo = int.Parse(textBox6.Text);
            departamento.nombre = textBox5.Text;
            int resp = departamentoDAO.modificarDepartamento(departamento);
            if (resp > 0)
            {
                MessageBox.Show("Departamento Modificado.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Departamento No fue Modificado, Verificar.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dataGridDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dataGridDepartamentos.DataSource = DepartamentoDAO.listarDepartamentos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DepartamentoDAO departamentoDAO = new DepartamentoDAO();
            string codigo = txtCodigoBuscar.Text;
            int resp = departamentoDAO.eliminarDepartamento(codigo);
            if (resp > 0)
            {
                MessageBox.Show("Departamento Eliminado de la Tabla.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Departamento No fue Eliminado.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
