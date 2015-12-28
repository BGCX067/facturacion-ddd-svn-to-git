using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
   public class Usuario
    {
        public Usuario()
        { }
        public Usuario(int ID, string User, string Pass, TipoUsuario Tipo)
        {
            this.id = ID;
            this.user = User;
            this.pass = Pass;
            this.tipo = Tipo;
        }
        private int id;
        private string user;
        private string pass;
        private TipoUsuario tipo;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public TipoUsuario Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
