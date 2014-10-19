using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRL
{
    public class detalleVenta:DAL.DAC
    {
        #region Atributos
        private int nro_ven;
        private int cod_med;
        private int cantidad;
        private float precio;
        #endregion

        #region Constructor
        public detalleVenta()
        {
            nro_ven = 0;
            cod_med = 0;
            cantidad = 0;
            precio = 0;
        }
        #endregion 

        #region Propiedades
        public int NumeroVenta
        {
            get { return this.nro_ven; }
            set { this.nro_ven = value; }
        }

        public int CodigoMedicamento
        {
            get { return this.cod_med; }
            set { this.cod_med = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        #endregion 

        public void Guardar()
        {
            try
            {
                PrepararSP("insertarDetalleVenta");
                AddParametro("@cod_med", cod_med.ToString());
                AddParametro("@precio", precio.ToString());
                AddParametro("@cantidad", cantidad.ToString());
                ejecutarSP();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar la venta:" + e.ToString());
            }
        }
    }
}
