    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace BRL
{
    public class proveedor:DAL.DAC
    {
        #region Atributos

        private int cod_prov;
        private string nombre;
        private string nit;
        private string direccion;
        private string telefono;
        private int cod_lab;

        #endregion 


        #region Constructor

        public proveedor()
        {
            cod_prov = 0;
            nombre = direccion = telefono = string.Empty;
            nit = "";
        }
        #endregion

        #region Propiedades

        public int Codigo
        {
            get { return this.cod_prov; }
            set { this.cod_prov = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Nit
        {
            get { return this.nit; }
            set { this.nit = value; }
        }

        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        public int Cod_laboratorio
        {
            get { return this.cod_lab; }
            set { this.cod_lab = value; }
        }
        #endregion 

        #region Metodos

        public void guardar()
        {
            try
            {
                PrepararSP("insertarProveedor");
                AddParametro("@nombre", nombre);
                AddParametro("@nit", nit);
                AddParametro("@direccion", direccion);
                AddParametro("@telefono", telefono);
                AddParametro("@cod_lab", cod_lab.ToString());
                ejecutarSP();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar Proveedor:" + e.ToString());
            }
        }

        public DataSet buscar()
        {
            string s;
            s = "select * from proveedor";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
        public DataSet buscarPorNombre(string criterio)
        {
            string s;
            s = "select cod_provee,  nombre ,nit,direccion, telefono,cod_lab  from proveedor where nombre like'" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }

        public DataSet buscarPorCodigo(string criterio)
        {
            string s;
            s = "select  cod_provee,  nombre ,nit,direccion, telefono,cod_lab  from proveedor where cod_provee like'" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }

        public void eliminar()
        {
            PrepararSP("eliminarProveedor");
            AddParametro("@cod_provee", cod_prov.ToString());
            ejecutarSP();
        }
        public void modificar()
        {
            PrepararSP("modificarProveedor");
            AddParametro("@cod_provee", cod_prov.ToString());
            AddParametro("nombre", nombre);
            AddParametro("@nit", nit);
            AddParametro("@direccion", direccion);
            AddParametro("@telefono", telefono);
            ejecutarSP();
        }


        #endregion
    }
}
