using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Ubicacion
    {
        public Ubicacion()
        { }
        public Ubicacion(string Provincia, string Localidad, string Direccion)
        {
            this.provincia = Provincia;
            this.localidad = Localidad;
            this.direccion = Direccion;
        }
        private string provincia;
        private string localidad;
        private string direccion;

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
    }
}
