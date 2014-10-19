using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace BRL
{
    public class Cliente:DAL.DAC
    {
        private int cod_cliente;
        private string nombre;
        private string paterno;
        private string materno;
        private string telefono;
        private string direccion;
        private string correo;
        public Cliente()
        {
            cod_cliente = 0;
            nombre = paterno = materno = telefono = direccion = correo = string.Empty;

        }
        public int cod_clt
        {
            get { return this.cod_cliente; }
            set { this.cod_cliente = value; }
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
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        public string Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }
        public void guardar()
        {
            try
            {
                PrepararSP("insertarCliente");
                AddParametro("@nombre", nombre);
                AddParametro("@paterno", paterno);
                AddParametro("@materno", materno);
                AddParametro("@telefono", telefono);
                AddParametro("@direccion", direccion);
                AddParametro("@correo", correo);
                ejecutarSP();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar cliente:" + e.ToString());
            }
        }
        public void modificar()
        {
            PrepararSP("modificar_cliente");
            AddParametro("@cod_clt", cod_clt.ToString());
            AddParametro("@nombre", nombre);
            AddParametro("@paterno", paterno);
            AddParametro("@materno", materno);
            AddParametro("@direccion", direccion);
            AddParametro("@telefono", telefono);
            AddParametro("@correo", correo);
            ejecutarSP();
        }

        public void eliminar()
        {
            PrepararSP("eliminarCliente");
            AddParametro("@cod_clt", cod_cliente.ToString());
            ejecutarSP();
        }
        public DataSet buscar()
        {
            string s;
            s = "select * from cliente";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
        public DataSet buscarPorNombre(string criterio)
        {
            string s;
            s = "select cod_clt,  nombre,paterno ,materno ,direccion, telefono,correo as ID  from cliente where nombre like'" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }

        public DataSet buscarPorCodigo(string criterio)
        {
            string s;
            s = "select cod_clt,  nombre,paterno ,materno ,direccion, telefono,correo as ID from cliente where cod_clt like'" + criterio + "%'";
            DataSet ds = new DataSet();
            ejecutarSQL(s, "tc", ds);
            return ds;
        }
    }
}
