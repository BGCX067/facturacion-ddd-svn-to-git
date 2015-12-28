using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class TipoArticulo
    {
        public TipoArticulo()
        {}
        public TipoArticulo(int ID,string Descripcion)
        {
            this.idtipoarticulo = ID;
            this.descripcion = Descripcion;
        }
        private int idtipoarticulo;
        private string descripcion;

        public int ID
        {
            get { return idtipoarticulo; }
            set { idtipoarticulo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
