using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menu
{
    public partial class Presentacion : Form
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.Show();

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCategoria fc = new frmCategoria();
            fc.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            frmVenta fv = new frmVenta();
            fv.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmProveedor fm = new frmProveedor();
            fm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmLaboratorio fm = new frmLaboratorio();
            fm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmMedicamento fm = new frmMedicamento();
            fm.Show();
        }

       
    }
}
