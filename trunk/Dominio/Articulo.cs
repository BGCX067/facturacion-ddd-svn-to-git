using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
   public class Articulo
    {
        public Articulo()
        { 
        
        }
       //CONSTRUCTOR COMPLETO
        public Articulo(int ID, TipoArticulo Tipo, string Marca, string Modelo, string Talle, string Precio, string Costo, DateTime FechaAlta, int Estado)
        {
            this.idarticulo = ID;
            this.tipoarticulo = Tipo;
            this.marca = Marca;
            this.modelo = Modelo;
            this.talle = Talle;
            this.precio = Precio;
            this.costo = Costo;
            this.fechaalta = FechaAlta;
            this.estado = Estado;
        }
       //CONSTRUCTOR PARA EL DETALLE DE LA FACTURA
        public Articulo(int ID, TipoArticulo Tipo, string Marca, string Modelo, string Talle, string Precio)
        {
            this.idarticulo = ID;
            this.tipoarticulo = Tipo;
            this.marca = Marca;
            this.modelo = Modelo;
            this.talle = Talle;
            this.precio = Precio;
        }

        private int idarticulo;
        private TipoArticulo tipoarticulo;
        private string marca;
        private string modelo;
        private string talle;
        private string precio;
        private string costo;
        private DateTime fechaalta;
        private DateTime fechamodificacion;
        private int estado;

        public int IdArticulo
        {
            get { return idarticulo; }
            set { idarticulo = value; }
        }

        public TipoArticulo TipoArticulo
        {
            get { return tipoarticulo; }
            set { tipoarticulo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Talle
        {
            get { return talle; }
            set { talle = value; }
        }

        public string Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public DateTime FechaAlta
        {
            get { return fechaalta; }
            set { fechaalta = value; }
        }

        public DateTime FechaModificacion
        {

            get { return fechamodificacion; }
            set { fechamodificacion = value; }
        }
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
