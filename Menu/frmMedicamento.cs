using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRL;
using DAL;

namespace Menu
{
    public partial class frmMedicamento : Form
    {
        public frmMedicamento()
        {
            InitializeComponent();
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            medicamento med = new medicamento();
            med.Nombre = txtNombre.Text;
            med.Cod_categoria = int.Parse(txtCategoria.Text);
            med.Stock = int.Parse(txtStock.Text);
            med.Precio =double.Parse(txtPrecio.Text);
            med.guardar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            medicamento c = new medicamento();
            DataSet ds = new DataSet();
            ds = c.buscarPorNombre(txtBuscar.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tm";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            medicamento p = new medicamento();
            DataSet ds = new DataSet();
            ds = p.buscarPorNombre(txtBuscar.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tm";
            
        }
    }
}
