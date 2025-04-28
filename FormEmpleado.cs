using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormEmpleados
{
    public partial class FormEmpleado : Form
    {
        public FormEmpleado()
        {
            InitializeComponent();
            LoadDepartamentos();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            // dataGridEmpleados.DataSource=EmpleadoDAO.listarEmpleados();
            var empleados = EmpleadoDAO.listarEmpleados();

            var displayList = empleados.Select(emp => {
                string nombreDepartamento = emp.departamento != null
                    ? DepartamentoDAO.buscarDepartamento(emp.departamento.codigo.ToString())?.nombre
                    : null;

                return new
                {
                    emp.rut,
                    emp.nombre,
                    emp.apellido,
                    emp.sueldo,
                    Departamento = nombreDepartamento
                };
            }).ToList();
            dataGridEmpleados.DataSource = displayList;
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            empleado.rut = txtRut.Text;
            empleado.nombre = txtNombre.Text;
            empleado.apellido = txtApellido.Text;
            empleado.sueldo = int.Parse(textBox2.Text);
            if (comboBox1.SelectedItem != null)
            {
                empleado.departamento = (Departamento)comboBox1.SelectedItem;
            }
            int resp=empleadoDAO.ingresarEmpleado(empleado);
            if (resp > 0) {
                MessageBox.Show("Empleado registrado en Base de Datos","AVISO DE SISTEMA",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Empleado No fue registrado en Base de Datos.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Departamento> departamentos = DepartamentoDAO.listarDepartamentos();
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            Empleado empleado = new Empleado();
            string rut=txtRutBuscar.Text;
            empleado=empleadoDAO.buscarEmpleado(rut);
            if (empleado != null) {
                txtRutEd.Text = empleado.rut;
                txtNombreEd.Text=empleado.nombre;
                txtApelEd.Text = empleado.apellido;
                textBox1.Text = empleado.sueldo.ToString();
                comboBox2.DataSource = new List<Departamento>(departamentos);
                if (empleado.departamento != null)
                {
                    foreach (Departamento dept in comboBox2.Items)
                    {
                        if (dept.codigo == empleado.departamento.codigo)
                        {
                            comboBox2.SelectedItem = dept;
                            break;
                        }
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            empleado.rut = txtRutEd.Text;
            empleado.nombre = txtNombreEd.Text;
            empleado.apellido = txtApelEd.Text;
            empleado.sueldo = int.Parse(textBox1.Text);
            empleado.departamento = (Departamento)comboBox2.SelectedItem;
            int resp = empleadoDAO.modificarEmpleado(empleado);
            if (resp > 0)
            {
                MessageBox.Show("Empleado Modificado en la Tabla.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Empleado No fue Modificado.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            string rut = txtRutEd.Text;
            int resp = empleadoDAO.eliminarEmpleado(rut);
            if (resp > 0)
            {
                MessageBox.Show("Empleado Eliminado de la Tabla.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Empleado No fue Eliminado.", "AVISO DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtRutBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadDepartamentos()
        {
            try
            {
                List<Departamento> departamentos = DepartamentoDAO.listarDepartamentos();
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "codigo";
                comboBox1.DataSource = departamentos;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DisplayMember = "nombre";
                comboBox2.ValueMember = "codigo";
                comboBox2.DataSource = new List<Departamento>();
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los departamentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
