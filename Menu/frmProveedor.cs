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
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
            listar_lab();
            txtlab.Enabled=false;
        }
        public void Limpiar()
        {
            txtnombre.Clear();
            txtnit.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
        }
        void limpiar_text()
        {
            txtnombre.Text = "";
            txtnit.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtlab.Text = "";
        }
        public void habilitar()
        {
            limpiar_text();
            txtnombre.Enabled = true;
            txtnit.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
        }
        public bool verificarVacio()
        {
            if (txtnombre.Text == "")
                if (txtnit.Text == "")
                    if (txttelefono.Text == "")
                        if (txtdireccion.Text == "")
                            return true;
            return false;
        }
        public string retornar_id_lab(string s)
        {
            laboratorio c = new laboratorio();
            DataSet ds = new DataSet();
            ds = c.buscarPorNombre(cbolab.Text);
            DataRow reg = ds.Tables[0].Rows[0];
            string x = reg[0].ToString();
            return x;
        }
        public void mostrarlab()
        {
            laboratorio c = new laboratorio();
            DataSet ds = new DataSet();
            ds = c.buscar();
            foreach (DataRow reg in ds.Tables[0].Rows)
                cbolab.Items.Add(reg[1].ToString().Trim());
        }
        public void listar_lab()
        {
            laboratorio c = new laboratorio();
            DataSet ds = new DataSet();
            ds = c.buscar();
            foreach (DataRow reg in ds.Tables[0].Rows)
                cbolab.Items.Add(reg[1].ToString().Trim());

            
            DataRow r = ds.Tables[0].Rows[0];
            cbolab.Text = r[1].ToString();
        }
        


        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar_text();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (verificarVacio())
            {
                MessageBox.Show("Registre un Proveedor");
            }
            else
            {
                proveedor c = new proveedor();
                c.Nombre = txtnombre.Text;
                c.Nit = txtnit.Text;
                c.Direccion = txtdireccion.Text;
                c.Telefono = txttelefono.Text;
                string x = retornar_id_lab(cbolab.Text);
                c.Cod_laboratorio = int.Parse(x);
                //mostrarlab();
                c.guardar();
                Limpiar();
                MessageBox.Show("Registro del Cliente Correctamente");
                //btnbuscar_Click(sender, new EventArgs());
            }
       
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            proveedor c = new proveedor();
            c.Codigo = int.Parse(txtcodigo.Text);
            c.eliminar();
            btnbuscar_Click(sender, new EventArgs());
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (verificarVacio())
                MessageBox.Show("No hay ningun Proveedor a Modificar");
            else
            {
                proveedor c = new proveedor();
                c.Codigo = int.Parse(txtcodigo.Text);
                c.Nombre = txtnombre.Text;
                c.Nit = txtnit.Text;
                c.Direccion = txtdireccion.Text;
                c.Telefono = txttelefono.Text;

                c.modificar();

                MessageBox.Show("Modificacion Correcta");
                btnbuscar_Click(sender, new EventArgs());
            }
            Limpiar();
 
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rdbnombre.Checked)
            {
                proveedor c = new proveedor();
                DataSet ds = new DataSet();
                ds = c.buscarPorNombre(txtbuscar.Text);
                dgprov.DataSource = ds;
                dgprov.DataMember = "tc";
            }
            if (rdbcodigo.Checked)
            {
                proveedor c = new proveedor();
                DataSet ds = new DataSet();
                ds = c.buscarPorCodigo(txtbuscar.Text);
                dgprov.DataSource = ds;
                dgprov.DataMember = "tc";
            }
        }

        private void dgprov_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();
            DataGridViewSelectedCellCollection cell = dgprov.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgprov.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dgprov[0, fila].Value);
                txtnombre.Text = Convert.ToString(dgprov[1, fila].Value);
                txtnit.Text = Convert.ToString(dgprov[2, fila].Value);
                txtdireccion.Text = Convert.ToString(dgprov[5, fila].Value);
                txttelefono.Text = Convert.ToString(dgprov[4, fila].Value);
                txtlab.Text = Convert.ToString(dgprov[5, fila].Value);
                sw = true;

            }
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
