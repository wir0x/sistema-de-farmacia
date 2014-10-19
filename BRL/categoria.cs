using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BRL
{
    public class categoria:DAL.DAC
    {
        #region atributos

        private int cod_cat;
        private string nombre;

        #endregion 


        #region constructor

        public categoria()
        {
            cod_cat = 0;
            nombre = string.Empty;
        }

        #endregion 


        #region Propiedades

        public int Codigo
        {
            get { return this.cod_cat; }
            set { this.cod_cat = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion 
        
        
        public DataSet Buscar()
        {
            string s = "select *from categoria";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
        public DataSet traerCodigo(string criterio)
        {
            string s = "select cod_cat from categoria where nombre ='" + criterio + "'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }

        public DataSet buscarPorNombre( string criterio)
        {
            string s = "select cod_cat, nombre from categoria where nombre like '" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
        public void guardar(string nombre)
        {
            try
            {
                PrepararSP("insertarCategoria");
                AddParametro("@nombre", nombre);
                ejecutarSP();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar Categoria:" + e.ToString());
            }
        }

        public void eliminar()
        {
            PrepararSP("eliminarCategoria");
            AddParametro("@cod_cat", cod_cat.ToString());
            ejecutarSP();
        }

        public void modificar()
        {
            PrepararSP("modificarCategoria");
            AddParametro("@cod_cat", cod_cat.ToString());
            AddParametro("@nombre", nombre);
            ejecutarSP();
        }
    }
}
