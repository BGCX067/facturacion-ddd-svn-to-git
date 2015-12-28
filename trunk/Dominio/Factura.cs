using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
   public class Factura
    {
        public Factura()
        { }

        public Factura(int ID, int NRO, DateTime Fecha, string Importe, Comercio Comercio, string Tipo, int Estado, List<Articulo> Detalle)
        {
            this.idfactura = ID;
            this.nrofactura = NRO;
            this.fecha = Fecha;
            this.importe = Importe;
            this.comercio = Comercio;
            this.tipofactura = Tipo;
            this.estado = Estado;
            this.detalle = Detalle;
        }
       private int idfactura;
       private int nrofactura;
       private DateTime fecha;
       private string importe;
       private Comercio comercio;
       private string tipofactura;
       private int estado;
       private List<Articulo> detalle;

       public int IdFactura
       {
           get { return idfactura; }
           set { idfactura = value; }
       }
       public int NroFactura
       {
           get { return nrofactura; }
           set { nrofactura = value; }
       }
       public DateTime Fecha
       {
           get { return fecha; }
           set { fecha = value; }
       }
       public string Importe
       {
           get { return importe; }
           set { importe = value; }
       }
       public Comercio Comercio
       {
           get { return comercio; }
           set { comercio = value; }
       }
       public string TipoFactura
       {
           get { return tipofactura; }
           set { tipofactura = value; }
       }
       public int Estado
       {
           get { return estado; }
           set { estado = value; }
       }
       public List<Articulo> Detalle
       {
           get { return detalle; }
           set { detalle = value; }
       }
    }
}
