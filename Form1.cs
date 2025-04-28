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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirDeLaAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saliendo de Aplicacion.");
            this.Close();
        }

        private void gestionDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmpleado formEmpleado=new FormEmpleado();
            formEmpleado.Show();
        }

        private void gestionDeDepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDepartamentos formDepartamentos=new FormDepartamentos();
            formDepartamentos.Show();
        }
    }
}
