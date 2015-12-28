using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;
namespace Repositorio
{
    class FacturaRepositorio:IFacturaRepositorio,Imapeador<Factura>
    {
        Conexion Conexion;
        public FacturaRepositorio()
        {

            Conexion = new Conexion();
        }
        public void Agregar(Factura Factura)
        {
           string Valores = Factura.IdFactura + "," + Factura.NroFactura + "," + Factura.Fecha + "," + Factura.Importe + "," + Factura.Comercio.CUIL + "," + Factura.Estado + "," + Factura.TipoFactura;
           Conexion.AgregarSinId("Facturas","IdFactura,NroFactura,Fecha,Importe,CUIL,Estado,Tipo",Valores);
           
            foreach (Articulo Articulo in Factura.Detalle)
           {
               Conexion.AgregarSinId("Detalle", "IdFactura,IdArticulo", Factura.IdFactura + "," + Articulo.IdArticulo);
           }
        }

        public void Modificar(Factura Factura)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Factura Factura)
        {
            string Detalle = "Delete from Detalle where IdFactura = " + Factura.IdFactura;
            Conexion.ActualizarOEliminar(Detalle);
            string Consulta="Delete from Facturas where NumeroFactura = "+Factura.NroFactura;
            Conexion.ActualizarOEliminar(Consulta);
        }

        public Factura Buscar(int NumeroFactura)
        {   IArticuloRepositorio ArtRepo = new ArticuloRepositorio();
            List<Articulo> Detalle = new List<Articulo>();
            string Consulta = "Select * Factura where NroFactura = " + NumeroFactura;
            Factura factura = Mapear(Conexion.Buscar(Consulta));
            factura.Detalle = ArtRepo.Listar(factura.IdFactura);
            return factura;
        }

        public List<Factura> Listar()
        {
            Conexion Conex = new Conexion();
            List<Factura> Lista = new List<Factura>();
            Lista.Clear();
            DataTable Tabla = Conex.Listar("Select * From Facturas");
            foreach (DataRow fact in Tabla.Rows)
            {
                Factura Factura = Mapear(fact);
                Lista.Add(Factura);
            }
            return Lista;
        }

        public List<Factura> Listar(DateTime FechaInicio, DateTime FechaFin)
        {
            List<Factura> Lista = new List<Factura>();
            Lista.Clear();
            string consulta = "Select * from Facturas where Fecha<= " + FechaFin + "&& Fecha>=" + FechaInicio;
            DataTable Tabla = Conexion.Listar(consulta);
            foreach (DataRow Row in Tabla.Rows)
            {
                Lista.Add(Mapear(Row));
            }
            return Lista;
        }

        public Factura Mapear(System.Data.DataRow Fila)
        {
            int IdFactura = Convert.ToInt32(Fila["IdFactura"]);
            int NroFactura = Convert.ToInt32(Fila["NroFactura"]);
            DateTime Fecha = Convert.ToDateTime(Fila["Fecha"]);
            string Importe = Convert.ToString(Fila["Importe"]);
            string Tipo = Convert.ToString(Fila["TipoFactura"]);
            int Estado = Convert.ToInt32(Fila["Estado"]);
            int IdComercio = Convert.ToInt32(Fila["IdComercio"]);
            
            //DETALLE DEL COMERCIO
            IComercioRepositorio ComeRepo = new ComercioRepositorio();
            Comercio Comercio = ComeRepo.Buscar(IdComercio);
            //DETALLE DE LA FACTURA
            IArticuloRepositorio ArticuloRepo = new ArticuloRepositorio();
            List<Articulo> ListaArticulos = ArticuloRepo.Listar(IdFactura);
            
            Factura Factura = new Factura(IdFactura, NroFactura, Fecha, Importe, Comercio, Tipo, Estado, ListaArticulos);
            
            return Factura;
        }


        public void AgregarArticulo(Factura Factura, Articulo Articulo)
        {
            Conexion.AgregarSinId("Detalle", "IdFactura,IdArticulo", Factura.IdFactura + "," + Articulo.IdArticulo);
            ArticuloRepositorio ArtRepo = new ArticuloRepositorio();
            Articulo.Estado = 0;
            ArtRepo.Modificar(Articulo);
        }
    }
}
