using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRL
{
    class detalleAjuste
    {
        #region Atributos
        private int cod_ajt;
        private int cod_med;
        private int cantidad;
        #endregion 

        #region Constructor
        public detalleAjuste()
        {
            cod_ajt = 0;
            cod_med = 0;
            cantidad = 0;
        }
        #endregion 

        #region Propiedades
        public int CodigoAjuste
        {
            get { return this.cod_ajt; }
            set { this.cod_ajt = value; }
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
        #endregion 
    }
}
