﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Conceptos
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        string doc;

        public string Doc
        {
            get { return doc; }
            set { doc = value; }
        }

        

        public Conceptos(int i, string c, string t)
        {
            codigo = i;
            descripcion = c;
            doc = t;
        }
    }
}
