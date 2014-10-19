using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRL
{
    class ajuste
    {
        #region Atributos

        private int cod_ajt;
        private DateTime fecha;
        private string observacion;

        #endregion

        #region Constructor
        
        public ajuste()
        {
            cod_ajt = 0;
            fecha = DateTime.Today.Date;
            observacion = string.Empty;
        }

        #endregion 

        #region Propiedades
        public int Codigo
        {
            get { return this.cod_ajt; }
            set { this.cod_ajt = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public string Observacion
        {
            get { return this.observacion; }
            set { this.observacion = value; }
        }


        #endregion 

    }

}
