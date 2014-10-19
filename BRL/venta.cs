using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRL
{
    public class venta :DAL.DAC
    {
        #region Atributos
        private int nro_ven;
        private DateTime fecha;
        private int cod_clt;
        private int cod_emp;
        #endregion 

        #region Constructor
        public venta()
        {
            nro_ven = 0;
            fecha = DateTime.Today.Date;
            cod_clt = 0;
            cod_emp = 0;
        }
        #endregion 

        #region Propiedades
        public int Numero_venta
        {
            get { return this.nro_ven; }
            set { this.nro_ven = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public int Cod_Cliente
        {
            get { return this.cod_clt; }
            set { this.cod_clt = value; }
        }

        public int Cod_Empleado
        {
            get { return this.cod_emp; }
            set { this.cod_emp = value; }
        }
        #endregion

        #region Metodos
        public void Guardar()
        {
            try
            {
                PrepararSP("insertarVenta");
                AddParametro("@fecha", fecha.ToString());
                AddParametro("@cod_clt", cod_clt.ToString());
                AddParametro("@ci",cod_emp.ToString());
                ejecutarSP();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar la venta:" + e.ToString());
            }
        }
        #endregion
    }
}
