using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRL
{
    class detalleCompra
    {
        #region Atributos
        private int cod_comp;
        private int cod_med;
        private int cantidad;
        private float costo;
        #endregion 

        #region Constructor
        public detalleCompra()
        {
            cod_comp = 0;
            cod_med = 0;
            cantidad = 0;
            costo = 0;
        }
        #endregion 

        #region Propiedades
        public int Cod_compra
        {
            get { return this.cod_comp; }
            set { this.cod_comp = value; }
        }

        public int Cod_medicamento
        {
            get { return this.cod_med; }
            set { this.cod_med = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public float Costo
        {
            get { return this.costo; }
            set { this.costo = value; }
        }
        #endregion
    }
}
