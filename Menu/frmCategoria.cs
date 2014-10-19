using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using BRL;
using System.Collections;

namespace Menu
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            categoria c= new categoria();
            DataSet ds = new DataSet();
            ds = c.buscarPorNombre(txtBuscar.Text);
            dgvCategoria.DataSource = ds;
            dgvCategoria.DataMember = "tc";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            categoria c = new categoria();
            c.guardar(txtNombre.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            categoria c = new categoria();
            c.Codigo = int.Parse(txtcod.Text);
            c.Nombre = txtNombre.Text;
            c.modificar();
            MessageBox.Show("Modificacion Correcta");
            txtcod.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            categoria c = new categoria();
            c.Codigo = int.Parse(txtcod.Text);
            c.Nombre = txtNombre.Text;
            c.eliminar();
            txtcod.Visible = false;
            txtNombre.Text = "";
            txtcod.Text = "";
            
        }

        private void dgvCategoria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewSelectedCellCollection cell = dgvCategoria.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgvCategoria.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcod.Text = Convert.ToString(dgvCategoria[0, fila].Value);
                txtNombre.Text = Convert.ToString(dgvCategoria[1, fila].Value);
                sw = true;
            }
                      
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            categoria p = new categoria();
            DataSet ds = new DataSet();
            ds = p.buscarPorNombre(txtBuscar.Text);
            dgvCategoria.DataSource = ds;
            dgvCategoria.DataMember = "tc";
        }
        
    }
}
