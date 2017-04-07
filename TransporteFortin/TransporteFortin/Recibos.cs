using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Recibos
    {
        int idrecibos;

        public int Idrecibos
        {
            get { return idrecibos; }
            set { idrecibos = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        Conceptos conceptos;

        public Conceptos Conceptos
        {
            get { return conceptos; }
            set { conceptos = value; }
        }

        int nro;

        public int Nro
        {
            get { return nro; }
            set { nro = value; }
        }

        decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        Fleteros fleteros;

        public Fleteros Fleteros
        {
            get { return fleteros; }
            set { fleteros = value; }
        }

        string comentarios;

        public string Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }

        int ptoventa;

        public int Ptoventa
        {
            get { return ptoventa; }
            set { ptoventa = value; }
        }

        Clientes clientes;

        public Clientes Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }

        Proveedores proveedores;

        public Proveedores Proveedores
        {
            get { return proveedores; }
            set { proveedores = value; }
        }
        int puesto;

        public int Puesto
        {
            get { return puesto; }
            set { puesto = value; }
        }
        Usuarios usuarios;

        public Usuarios Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }
        Sucursales sucursales;

        public Sucursales Sucursales
        {
            get { return sucursales; }
            set { sucursales = value; }
        }
        int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public Recibos(int i, DateTime f, Conceptos c, int n, decimal im, Fleteros fl, string co, int p, Clientes cl, Proveedores prov, int pu, Usuarios usu, Sucursales suc, int t)
        {
            idrecibos = i;
            fecha = f;
            conceptos = c;
            nro = n;
            importe = im;
            fleteros = fl;
            comentarios = co;
            ptoventa = p;
            clientes = cl;
            proveedores = prov;
            puesto = pu;
            usuarios = usu;
            sucursales = suc;
            tipo = t;
        }
    }
}
