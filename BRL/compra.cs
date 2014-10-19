using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRL
{
    class compra
    {
        #region Atributos

        private int cod_comp;
        private DateTime fecha;
        private int cod_prov;
        private int cod_emp;

        #endregion 

        #region Constructor

        public compra()
        {
            cod_comp = 0;
            fecha = DateTime.Today.Date;
        }

        #endregion 

        #region Propiedades
        public int Codigo
        {
            get { return this.cod_comp; }
            set { this.cod_comp = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public int Cod_prov
        {
            get { return this.cod_prov; }
            set { this.cod_prov = value; }
        }

        public int Cod_emp
        {
            get { return this.cod_emp; }
            set { this.cod_emp = value; }
        }

        #endregion 
    }
}
