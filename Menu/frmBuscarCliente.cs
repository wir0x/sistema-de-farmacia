using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRL;

namespace Menu
{
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            DataSet ds = new DataSet();
            ds = c.buscar();
            dgvCliente.DataSource = ds;
            dgvCliente.DataMember = "tc";
        }
        public TextBox txtCliente;
        public TextBox txtcodCliente;
        private void dgvCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //int indice = dgvCliente.CurrentRow.Index;
            ////Le devuelve el valor de este formulario a su propietario frmVenta          
            ////(this.Owner,frmVenta) txtCodigo.Text= int.Parse(dgvCliente[0,indice].Value.ToString());        
            ////CType(this.Owner, frmVenta).txtDescripcion.Text = Trim(dgConProducto.Item(indice, 1));
            //this.Close();
            int indice = dgvCliente.CurrentRow.Index;
            if (indice >= 0 && dgvCliente[indice, 0] != null)
            {
                txtcodCliente.Text = dgvCliente[0,indice].Value.ToString();
                txtCliente.Text = dgvCliente[1, indice].Value.ToString();
            }
            else
            {
                txtcodCliente.Text = "";
                txtCliente.Text = "";
            }
            this.Close();
        }
    }
}
