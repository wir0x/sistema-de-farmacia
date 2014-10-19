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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtdireccion.Clear();
            txtpaterno.Clear();
            txtmaterno.Clear();
            txtcorreo.Clear();
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
            txtcorreo.Text = "";
        }

        private void btnuevo_Click(object sender, EventArgs e)
        {
            limpiar_text();
        }

        private void btbuscar_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Cliente c = new Cliente();
                DataSet ds = new DataSet();
                ds = c.buscarPorNombre(txtbuscar.Text);
                dgcliente.DataSource = ds;
                dgcliente.DataMember = "tc";
            }
            if (radioButton2.Checked)
            {
                Cliente c = new Cliente();
                DataSet ds = new DataSet();
                ds = c.buscarPorCodigo(txtbuscar.Text);
                dgcliente.DataSource = ds;
                dgcliente.DataMember = "tc";
            }
        }
        public bool verificarVacio()
        {
            if (txtnombre.Text == "")
                if (txtpaterno.Text == "")
                    if (txtmaterno.Text == "")
                        if (txtdireccion.Text == "")
                            if (txttelefono.Text == "")
                                if (txtcorreo.Text == "")
                                    return true;
            return false;
        }
        private void btguardar_Click_1(object sender, EventArgs e)
        {
            if (verificarVacio())
            {
                MessageBox.Show("Registre un Cliente");
            }
            else
            {
                Cliente c = new Cliente();
                c.Nombre = txtnombre.Text;
                c.Paterno = txtpaterno.Text;
                c.Materno = txtmaterno.Text;
                c.Telefono = txttelefono.Text;
                c.Direccion = txtdireccion.Text;
                c.Correo = txtcorreo.Text;
                c.guardar();
                Limpiar();
                MessageBox.Show("Registro del Cliente Correctamente");
                btbuscar_Click_1(sender, new EventArgs());
            }
        }

        private void dgcliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();  
            DataGridViewSelectedCellCollection cell = dgcliente.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgcliente.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dgcliente[0, fila].Value);
                txtnombre.Text = Convert.ToString(dgcliente[1, fila].Value);
                txtpaterno.Text = Convert.ToString(dgcliente[2, fila].Value);
                txtmaterno.Text = Convert.ToString(dgcliente[3, fila].Value);
                txttelefono.Text = Convert.ToString(dgcliente[4, fila].Value);
                txtdireccion.Text = Convert.ToString(dgcliente[5, fila].Value);
                txtcorreo.Text = Convert.ToString(dgcliente[6, fila].Value);
                sw = true;
                
            }
                      
        }

        private void btmodificar_Click(object sender, EventArgs e)
        {
            if (verificarVacio())
                MessageBox.Show("No hay ningun Cliente a Modificar");
            else
            {
                Cliente c = new Cliente();
                c.cod_clt = int.Parse(txtcodigo.Text);
                c.Nombre = txtnombre.Text;
                c.Paterno = txtpaterno.Text;
                c.Materno = txtmaterno.Text;
                c.Direccion = txtdireccion.Text;
                c.Telefono = txttelefono.Text;
                c.Correo = txtcorreo.Text;
                c.modificar();
                
                MessageBox.Show("Modificacion Correcta");
                btbuscar_Click_1(sender, new EventArgs());
            }
            Limpiar();
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            c.cod_clt = int.Parse(txtcodigo.Text);
            c.eliminar();
            btbuscar_Click_1(sender, new EventArgs());
        }
        public void habilitar()
        {
            limpiar_text();
            txtnombre.Enabled = true;
            txtpaterno.Enabled = true;
            txtmaterno.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            txtcorreo.Enabled = true;
        }
        private void btnuevo_Click_1(object sender, EventArgs e)
        {
            limpiar_text();
            habilitar();
        }
    }
}
