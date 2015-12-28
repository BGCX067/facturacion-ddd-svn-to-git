using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class TipoUsuario
    {
        public TipoUsuario()
        { }
        public TipoUsuario(int Id, string Descripcion)
        {
            this.idtipo = Id;
            this.descripcion = Descripcion;
        }

        private int idtipo;
        private string descripcion;

       public int IdTipo
        {
            get { return idtipo; }
            set { idtipo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
