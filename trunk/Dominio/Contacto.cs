using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Contacto
    {
        public Contacto()
        {}
        public Contacto(string Telefono, string Email)
        {
            this.email = Email;
            this.telefono = Telefono;
        }

        private string telefono;
        private string email;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Email
        {

            get { return email; }
            set { email = value; }
        }
    }
}
