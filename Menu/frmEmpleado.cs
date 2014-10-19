using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BRL;
using DAL;

namespace Menu
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtdireccion.Clear();
            txtpaterno.Clear();
            txtmaterno.Clear();            
            txttelefono.Clear();
            txtnombre.Clear();
        }
        void limpiar_text()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtpaterno.Text = "";
            txtmaterno.Text = "";
            txttelefono.Text = "";
            txtdireccion.Text = "";            
        }

        private void btguardar_Click(object sender, EventArgs e)
        {
            Empleado em = new Empleado();
            em.Nombre = txtnombre.Text;
            em.Paterno = txtpaterno.Text;
            em.Materno = txtmaterno.Text;
            em.Telefono = txttelefono.Text;
            em.Direccion = txtdireccion.Text;
            em.guardar();
            Limpiar();
        }

        private void btbuscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Empleado c = new Empleado();
                DataSet ds = new DataSet();
                ds = c.buscarxNombre(txtbuscar.Text);
                dgempleado.DataSource = ds;
                dgempleado.DataMember = "tc";
            }
            if (radioButton2.Checked)
            {
                Empleado c = new Empleado();
                DataSet ds = new DataSet();
                ds = c.buscarPorCodigo(txtbuscar.Text);
                dgempleado.DataSource = ds;
                dgempleado.DataMember = "tc";
            }


        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            Empleado c = new Empleado();
            c.Ci = int.Parse(txtcodigo.Text);
            c.eliminar();
            btbuscar_Click(sender,new EventArgs());
            limpiar_text();

        }

        private void dgempleado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewSelectedCellCollection cell = dgempleado.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgempleado.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dgempleado[0, fila].Value);
                txtnombre.Text = Convert.ToString(dgempleado[1, fila].Value);
                txtpaterno.Text = Convert.ToString(dgempleado[2, fila].Value);
                txtmaterno.Text = Convert.ToString(dgempleado[3, fila].Value);
                txtdireccion.Text = Convert.ToString(dgempleado[4, fila].Value);
                txttelefono.Text = Convert.ToString(dgempleado[5, fila].Value);
                sw = true;
            }
        }

        private void btmodificar_Click(object sender, EventArgs e)
        {
            Empleado c = new Empleado();
            c.Ci= int.Parse(txtcodigo.Text);
            c.Nombre = txtnombre.Text;
            c.Paterno = txtpaterno.Text;
            c.Materno = txtmaterno.Text;
            c.Direccion = txtdireccion.Text;
            c.Telefono = txttelefono.Text;
            c.modificar();
            Limpiar();
            btbuscar_Click(sender, new EventArgs());
        }

    }
}
