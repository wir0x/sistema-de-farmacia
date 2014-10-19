using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace BRL
{
    public class laboratorio:DAL.DAC
    {
        #region Atributos

        private int cod_lab;
        private string nombre;
        private string direccion;
        private string telefono;
        private string email;
        private string web;

        #endregion 


        #region Constructor

        public laboratorio()
        {
            cod_lab = 0;
            nombre = direccion = telefono = email = web = string.Empty;
        }

        #endregion 


        #region Propiedades

        public int Codigo
        {
            get { return this.cod_lab; }
            set { this.cod_lab = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
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

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Web
        {
            get { return this.web; }
            set { this.web = value; }
        }
        #endregion

        #region Metodos

        public void guardar()
        {
            try
            {
                PrepararSP("insertarLaboratorio");
                AddParametro("@nombre", nombre);
                AddParametro("@direccion", direccion);
                AddParametro("@telefono", telefono);
                AddParametro("@email", email);
                AddParametro("@web", web);
                ejecutarSP();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar laboratorio:" + e.ToString());
            }
        }
        public void modificar()
        {
            PrepararSP("modificar_laboratorio");
            AddParametro("@cod_lab", cod_lab.ToString());
            AddParametro("@nombre", nombre);
            AddParametro("@direccion", direccion);
            AddParametro("@telefono", telefono);
            AddParametro("@email", email);
            AddParametro("@web", web);
            ejecutarSP();
        }

        public void eliminar()
        {
            PrepararSP("eliminarLaboratorio");
            AddParametro("@cod_lab", cod_lab.ToString());
            ejecutarSP();
        }
        public DataSet buscar()
        {
            string s;
            s = "select * from laboratorio";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
        public DataSet buscarPorNombre(string criterio)
        {
            string s;
            s = "select cod_lab,  nombre, direccion, telefono, email, web from laboratorio where nombre like'" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }

        public DataSet buscarPorCodigo(string criterio)
        {
            string s;
            s = "select cod_lab,  nombre, direccion, telefono,web from laboratorio  where cod_lab like'" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
        #endregion

    }


}
