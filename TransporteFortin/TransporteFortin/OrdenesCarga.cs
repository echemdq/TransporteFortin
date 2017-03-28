using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class OrdenesCarga
    {
        int idordenescarga;

        public int Idordenescarga
        {
            get { return idordenescarga; }
            set { idordenescarga = value; }
        }

        string nrocarga;

        public string Nrocarga
        {
            get { return nrocarga; }
            set { nrocarga = value; }
        }

        Sucursales sucursales;

        public Sucursales Sucursales
        {
            get { return sucursales; }
            set { sucursales = value; }
        }
        Clientes clientes;

        public Clientes Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }
        Fleteros fleteros;

        public Fleteros Fleteros
        {
            get { return fleteros; }
            set { fleteros = value; }
        }
        Empresas empresas;

        public Empresas Empresas
        {
            get { return empresas; }
            set { empresas = value; }
        }
        string porcuentade;

        public string Porcuentade
        {
            get { return porcuentade; }
            set { porcuentade = value; }
        }
        string productos;

        public string Productos
        {
            get { return productos; }
            set { productos = value; }
        }
        string origen;

        public string Origen
        {
            get { return origen; }
            set { origen = value; }
        }
        string destino;

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }
        decimal valordeclarado;

        public decimal Valordeclarado
        {
            get { return valordeclarado; }
            set { valordeclarado = value; }
        }
        int valorizado;

        public int Valorizado
        {
            get { return valorizado; }
            set { valorizado = value; }
        }
        Unidades unidades;

        public Unidades Unidades
        {
            get { return unidades; }
            set { unidades = value; }
        }
        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        decimal valorunidad;

        public decimal Valorunidad
        {
            get { return valorunidad; }
            set { valorunidad = value; }
        }
        string tipocomision;

        public string Tipocomision
        {
            get { return tipocomision; }
            set { tipocomision = value; }
        }
        decimal valorcomision;

        public decimal Valorcomision
        {
            get { return valorcomision; }
            set { valorcomision = value; }
        }
        int pagodestino;

        public int Pagodestino
        {
            get { return pagodestino; }
            set { pagodestino = value; }
        }
        decimal totalviaje;

        public decimal Totalviaje
        {
            get { return totalviaje; }
            set { totalviaje = value; }
        }
        decimal ivaviaje;

        public decimal Ivaviaje
        {
            get { return ivaviaje; }
            set { ivaviaje = value; }
        }
        decimal comision;

        public decimal Comision
        {
            get { return comision; }
            set { comision = value; }
        }
        decimal importecliente;

        public decimal Importecliente
        {
            get { return importecliente; }
            set { importecliente = value; }
        }
        string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        int ptoventa;

        public int Ptoventa
        {
            get { return ptoventa; }
            set { ptoventa = value; }
        }

        int puesto;

        public int Puesto
        {
            get { return puesto; }
            set { puesto = value; }
        }
        decimal valorunidadcte;

        public decimal Valorunidadcte
        {
            get { return valorunidadcte; }
            set { valorunidadcte = value; }
        }
        decimal ivacliente;

        public decimal Ivacliente
        {
            get { return ivacliente; }
            set { ivacliente = value; }
        }
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        int anulado;

        public int Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }
        Usuarios usu;

        public Usuarios Usu
        {
            get { return usu; }
            set { usu = value; }
        }

        string conceptfact;

        public string Conceptfact
        {
            get { return conceptfact; }
            set { conceptfact = value; }
        }

        public OrdenesCarga(int id, string nro, int pto, int pue, DateTime fe,Sucursales suc, Clientes cli, Fleteros fle, Empresas emp, string porcta, string prod, string or, string dest, decimal valordec, int valoriz, Unidades uni, int cant, decimal valoru, decimal valoructe, string tipocom, decimal valorcom, int pagodes, decimal totalvia, decimal ivav, decimal ivacte, decimal comi, decimal impcli, string obs, int anu, Usuarios us, string cf)
        {
            conceptfact = cf;
            anulado = anu;
            fecha = fe;
            nrocarga = nro;
            idordenescarga = id;
            sucursales = suc;
            clientes = cli;
            fleteros = fle;
            empresas = emp;
            porcuentade = porcta;
            productos = prod;
            origen = or;
            destino = dest;
            valordeclarado = valordec;
            valorizado = valoriz;
            unidades = uni;
            cantidad = cant;
            valorunidad = valoru;
            usu = us;
            tipocomision = tipocom;
            valorcomision = valorcom;
            pagodestino = pagodes;
            totalviaje = totalvia;
            ivaviaje = ivav;
            comision = comi;
            importecliente = impcli;
            observaciones = obs;
            valorunidadcte = valoructe;
            ivacliente = ivacte;
            ptoventa = pto;
            puesto = pue;
        }
    }
}
