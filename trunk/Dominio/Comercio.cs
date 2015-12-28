using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Comercio
    {
        public Comercio()
        { }
        public Comercio(string RazonSocial, string CUIL, Contacto Contacto, Ubicacion Ubicacion)
        {
            this.razonsocial = RazonSocial;
            this.cuil = CUIL;
            this.contacto = Contacto;
            this.ubicacion = Ubicacion;
        }
       private string razonsocial;
       private string cuil;
       private Contacto contacto;
       private Ubicacion ubicacion;

       public string RazonSocial
       {
           get { return razonsocial; }
           set { razonsocial = value; }
       }
       public string CUIL
       {
           get { return cuil; }
           set { cuil = value; }
       }
       public Contacto Contacto
       {
           get { return contacto; }
           set { contacto = value; }
       }
       public Ubicacion Ubicacion
       {
           get { return ubicacion; }
           set { ubicacion = value; }
       }
    }
}
