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
    public partial class frmLaboratorio : Form
    {
        public frmLaboratorio()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtWeb.Clear();

        }
        void limpiar_text()
        {
            txtcodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtWeb.Text = "";
        }
        public bool verificarVacio()
        {
            if (txtNombre.Text == "")
                if (txtDireccion.Text == "")
                    if (txtTelefono.Text == "")
                        if (txtEmail.Text == "")
                            if (txtWeb.Text == "")
                                return true;
            return false;
        }
        public void habilitar()
        {
            limpiar_text();
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            txtWeb.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            limpiar_text();
            habilitar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificarVacio())
            {
                MessageBox.Show("Registre un Laboratorio");
            }
            else
            {
                laboratorio c = new laboratorio();
                c.Nombre = txtNombre.Text;
                c.Direccion = txtDireccion.Text;
                c.Telefono = txtTelefono.Text;
                c.Email = txtEmail.Text;
                c.Web = txtWeb.Text;
                c.guardar();
                Limpiar();
                MessageBox.Show("Registro del Cliente Correctamente");
                btnBuscar_Click(sender, new EventArgs());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioButton.Checked)
            {
                laboratorio c = new laboratorio();
                DataSet ds = new DataSet();
                ds = c.buscarPorNombre(txtBuscar.Text);
                dglab.DataSource = ds;
                dglab.DataMember = "tc";
            }
            if (radioButton1.Checked)
            {
                laboratorio c = new laboratorio();
                DataSet ds = new DataSet();
                ds = c.buscarPorCodigo(txtBuscar.Text);
                dglab.DataSource = ds;
                dglab.DataMember = "tc";
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (verificarVacio())
                MessageBox.Show("No hay ningun Laboratorio a Modificar");
            else
            {
                laboratorio c = new laboratorio();
                c.Codigo = int.Parse(txtcodigo.Text);
                c.Nombre = txtNombre.Text;
                c.Direccion = txtDireccion.Text;
                c.Telefono = txtTelefono.Text;
                c.Email = txtEmail.Text;
                c.modificar();

                MessageBox.Show("Modificacion Correcta");
                btnBuscar_Click(sender, new EventArgs());
            }
            Limpiar();
        }

        private void dglab_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();
            DataGridViewSelectedCellCollection cell = dglab.SelectedCells;
            DataGridViewSelectedRowCollection rows = dglab.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dglab[0, fila].Value);
                txtNombre.Text = Convert.ToString(dglab[1, fila].Value);
                txtDireccion.Text = Convert.ToString(dglab[2, fila].Value);
                txtTelefono.Text = Convert.ToString(dglab[3, fila].Value);
                txtEmail.Text = Convert.ToString(dglab[4, fila].Value);
                txtWeb.Text = Convert.ToString(dglab[5, fila].Value);
                sw = true;

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            laboratorio c = new laboratorio();
            c.Codigo = int.Parse(txtcodigo.Text);
            c.eliminar();
            btnBuscar_Click(sender, new EventArgs());
        }
    }
}
