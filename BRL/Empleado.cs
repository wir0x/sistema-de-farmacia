using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace BRL
{
    public class Empleado:DAL.DAC
    {
        #region Atributos

        private int ci;        
        private string nombre;
        private string paterno;
        private string materno;
        private string telefono;
        private string direccion;

        #endregion

        #region Constructor
        public int Ci
        {
            get { return this.ci; }
            set { this.ci = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Paterno
        {
            get { return this.paterno; }
            set { this.paterno = value; }
        }

        public string Materno
        {
            get { return this.materno; }
            set { this.materno = value; }
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


        #endregion 

        public void guardar()
        {
            try
            {
                PrepararSP("insertarEmpleado");
                AddParametro("@nombre", this.nombre);
                AddParametro("@paterno", this.paterno);
                AddParametro("@materno", this.materno);
                AddParametro("@telefono", this.telefono);
                AddParametro("@direccion", this.direccion);               
                ejecutarSP();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar Empleado:" + e.ToString());
            }
        }
        public void modificar()
        {
            PrepararSP("modificarEmpleado");
            AddParametro("@ci", ci.ToString());
            AddParametro("@nombre", nombre);
            AddParametro("@paterno", paterno);
            AddParametro("@materno", materno);
            AddParametro("@direccion", direccion);
            AddParametro("@telefono", telefono);
            ejecutarSP();
        }

        public void eliminar()
        {
            PrepararSP("eliminarEmpleado");
            AddParametro("@ci", ci.ToString());
            ejecutarSP();
        }
        public DataSet buscar()
        {
            string s;
            s = "select * from empleado";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
        public DataSet buscarxNombre(string criterio)
        {
            string s;
            s = "select ci,nombre,paterno ,materno ,direccion, telefono from empleado where nombre like '"+ criterio +"%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }

        public DataSet buscarPorCodigo(string criterio)
        {
            string s;
            s = "select ci,  nombre,paterno ,materno ,direccion, telefono from empleado where empleado like'" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
    } 
    
}
