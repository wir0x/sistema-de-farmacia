using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRL
{
    public class busqueda
    {
        #region Atributos
        private int cod_lab;
        private int cod_med;
        #endregion 

        #region Constructor
        public busqueda()
        {
            cod_lab = 0;
            cod_med = 0;
        }
        #endregion 

        #region Propiedades
        public int CodigoLaboratorio
        {
            get { return this.cod_lab; }
            set { this.cod_lab = value; }
        }

        public int CodigoMedicamento
        {
            get { return this.cod_med; }
            set { this.cod_med = value; }
        }
        #endregion 
    }
}
