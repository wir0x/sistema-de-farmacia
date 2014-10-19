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

namespace Menu
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            CrearDataTable();
        }
        void CrearDataTable()
        {
            DataColumn cod_med = new DataColumn("cod_med");
            cod_med.AllowDBNull = false;
            cod_med.DataType = System.Type.GetType("System.Int32");
            cod_med.Unique = true; //Para que los valores de CodPro sean unicos en dgDetalle
            cod_med.Caption = "cod_med";
            tablaTmp.Columns.Add(cod_med);
            cod_med.ReadOnly = true;

            DataColumn Descripcion = new DataColumn("Descripcion");
            Descripcion.AllowDBNull = true;
            Descripcion.DataType = System.Type.GetType("System.String");
            Descripcion.Caption = "Descripcion";
            Descripcion.MaxLength = 1000;
            tablaTmp.Columns.Add(Descripcion);
            Descripcion.ReadOnly = true;

            DataColumn PrecioV = new DataColumn("PrecioV");
            PrecioV.AllowDBNull = true;
            PrecioV.DataType = System.Type.GetType("System.Double");
            PrecioV.Caption = "PrecioV";
            tablaTmp.Columns.Add(PrecioV);
            PrecioV.ReadOnly = false;

            DataColumn Cantidad = new DataColumn("Cantidad");
            Cantidad.AllowDBNull = true;
            Cantidad.DataType = System.Type.GetType("System.Int32");
            Cantidad.Caption = "Cantidad";
            tablaTmp.Columns.Add(Cantidad);
            Cantidad.ReadOnly = false;

            DataColumn subTotal = new DataColumn("SubTotal");
            subTotal.AllowDBNull = true;
            subTotal.DataType = System.Type.GetType("System.Double");
            subTotal.Caption = "SubTotal";
            tablaTmp.Columns.Add(subTotal);
            subTotal.ReadOnly = true;
            //asignamos las caracteristicas al datagrid
            this.dgvDetallVenta.DataSource = tablaTmp;
            this.dgvMedicamento.DataSource = tablaTmp;
        }

        void GuardarCabecera()
        {
            venta v = new venta();
            v.Fecha = DateTime.Parse(dtpFecha.Value.ToString());
            v.Cod_Cliente = int.Parse(txtCodCliente.Text);
            v.Cod_Empleado = int.Parse(cboEmpleado.Text);
            v.Guardar();
        }
        private DataTable tablaTmp = new DataTable("dventa");
        void GuardarDetalle()
        {
            detalleVenta dv;
            foreach (DataRow reg in this.tablaTmp.Rows)
            {
                dv = new detalleVenta();
                dv.CodigoMedicamento = int.Parse(reg[0].ToString());
                dv.Precio = float.Parse(reg[2].ToString());
                dv.Cantidad = int.Parse(reg[3].ToString());
                dv.Guardar();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCabecera();
                GuardarDetalle();
            }
            
            catch (Exception )
            {
                MessageBox.Show("Error");
            }

            
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            habiliatar();
            frmBuscarCliente fc= new frmBuscarCliente();
            fc.txtCliente = this.txtCliente;
            fc.txtcodCliente = this.txtCodCliente;
            fc.Show();
            lblCodEmp.Visible = true;
            txtCodCliente.Visible = true;
            txtCodEmpleado.Visible = true;
            
            

        }
        public void listaEmpleados()
        {
            Empleado e = new Empleado();
            DataSet ds = new DataSet();
            ds = e.buscar();
            foreach (DataRow reg in ds.Tables[0].Rows)
                cboEmpleado.Text = reg[0].ToString();

            DataRow r = ds.Tables[0].Rows[0];
            cboEmpleado.Text = r[0].ToString().Trim();
        }
        void listaCategoria()
        {
            categoria c = new categoria();
            DataSet ds = new DataSet();
            ds = c.Buscar();
            foreach (DataRow reg in ds.Tables[0].Rows)
                cobCategoria.Items.Add(reg[1].ToString());

            DataRow r = ds.Tables[0].Rows[0];
            cobCategoria.Text = r[0].ToString().Trim();
            //cobCategoria.Text = r[1].ToString().Trim();
        }
        private void frmVenta_Load(object sender, EventArgs e)
        {
            listaEmpleados();
            listaCategoria();
                
        }

        private void txtMedicamento_TextChanged(object sender, EventArgs e)
        {
            medicamento p = new medicamento();
            DataSet ds = new DataSet();
            ds = p.buscarPorNombre(txtMedicamento.Text);
            dgvMedicamento.DataSource = ds;
            dgvMedicamento.DataMember = "tm";
            //dgv.Visible = true;
        }
        public void habiliatar()
        {
            txtCliente.Enabled = true;
            txtMedicamento.Enabled = true;
            cboEmpleado.Enabled = true;
            cobCategoria.Enabled = true;
            txtCodEmpleado.Enabled = true;
        }
        void limpiar()
        {
            txtCliente.Text = "";
            txtCodCliente.Text="";
            txtMedicamento.Text = "";

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habiliatar();
        }
        void calcularTotal()
        {
            double s = 0;
            foreach (DataRow reg in this.tablaTmp.Rows)
                s = s + double.Parse(reg[4].ToString());

            txtTotal.Text = s.ToString();
        }
        string obtenerDescripcion(int cod)
        {
            DAL.DAC cn = new DAL.DAC();
            DataSet ds = new DataSet();
            DataRow reg;
            string s = "select nombre from medicamento where cod_med=" + cod;
            cn.ejecutarSQL(s, "nro", ds);
            reg = ds.Tables["nro"].Rows[0];
            return reg[0].ToString();
        }

        private void dgvMedicamento_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRow newReg;
            int indice = dgvMedicamento.CurrentRow.Index;
            try
            {
                newReg = this.tablaTmp.NewRow();
                newReg["cod_med"] = dgvMedicamento[0, indice].Value.ToString();
                newReg["Descripcion"] = obtenerDescripcion(int.Parse(newReg["cod_med"].ToString()));
                newReg["PrecioV"] = dgvMedicamento[2, indice].Value.ToString();
                newReg["cantidad"] = 1;
                newReg["SubTotal"] = double.Parse(newReg["PrecioV"].ToString()) * double.Parse(newReg["cantidad"].ToString());
                this.tablaTmp.Rows.Add(newReg);
                //this.dgvMedicamento.Visible = false;
                this.dgvDetallVenta.Visible = true;
                calcularTotal();
                this.txtMedicamento.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Datos duplicados...!!");
            }        
        }

        public void buscar()
        {
            //medicamento med=new medicamento();
            //string key=
            //DataSet ds = med.llamarMedicamento(txtMedicamento.Text, key.ToString());
            //string[] columnNames = new string[] { "Codigo", "Nombre", "Precio", "Stock" };
            //int i=0;
            //while (i < dgvMedicamento.NewRowIndex)
            //{
            //    dgvMedicamento[0, i].Value = ds.Container;
            //    dgvMedicamento[1, i].Value = ds.Container;
            //    dgvMedicamento[2, i].Value = ds.Container;
            //    dgvMedicamento[3, i].Value = ds.Container;
            //    i++;
            //}
            
        }
        private void cobCategoria_SelectedValueChanged(object sender, EventArgs e)
        {

        }

    }
}
