using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;
namespace Repositorio
{
    public class ArticuloRepositorio:IArticuloRepositorio,Imapeador<Articulo>
    {
        Conexion Conexion;
        public ArticuloRepositorio()
        {
            Conexion = new Conexion();
        }

        public void Agregar(Articulo Articulo)
        {
            string Campos="IdArticulo,IdTipoArticulo,Marca,Modelo,Talle,Precio,Costo,FechaAlta,Estado";
            string Valores = Articulo.IdArticulo + "," + Articulo.TipoArticulo.ID + "," + Articulo.Marca+",";
            Valores += Articulo.Modelo + "," + Articulo.Talle + "," + Articulo.Precio + "," + Articulo.Costo + "," + DateTime.Today + "," + 1;

           Conexion.AgregarSinId("Articulo", Campos, Valores);
        }

        public void Modificar(Articulo Articulo)
        {
        string consulta = "Update Articulos Set IdTipoArticulo = "+Articulo.TipoArticulo.ID+",";
        consulta += "Marca = " + Articulo.Marca+",";
        consulta += "Modelo = " + Articulo.Modelo + ",";
        consulta += "Talle = " + Articulo.Talle + ",";
        consulta += "Precio = " + Articulo.Precio + ",";
        consulta += "Costo = " + Articulo.Costo + ",";
        consulta += "Estado = " + Articulo.Estado + ",";
        consulta += "Where IdArticulo = " + Articulo.IdArticulo;
        Conexion.ActualizarOEliminar(consulta);
        }

        public void Borrar(Articulo Articulo)
        {
            string Consulta = "Delete from Articulos Where IdArticulo= " + Articulo.IdArticulo;
            Conexion.ActualizarOEliminar(Consulta);
        }

        public List<Articulo> Listar()
        {
           List<Articulo> Lista = new List<Articulo>();
           DataTable Tabla =  Conexion.Listar("Select * From Articulos");
           foreach (DataRow Dr in Tabla.Rows)
           {
               Lista.Add(Mapear(Dr));
           }
           return Lista;
        }

        public Articulo Mapear(System.Data.DataRow Fila)
        {
            ITipoArticuloRepositorio TipoRepo = new TipoArticuloRepositorio();
            int IdArticulo = Convert.ToInt32(Fila["IdArticulo"]);
            TipoArticulo Tipo = TipoRepo.Buscar(Convert.ToInt32(Fila["IdTipoArticulo"]));
            string Marca = Fila["Marca"].ToString();
            string Modelo = Fila["Modelo"].ToString();
            string Talle = Fila["Talle"].ToString();
            string Precio = Fila["Precio"].ToString();
            string Costo = Fila["Costo"].ToString();
            DateTime FechaAlta = Convert.ToDateTime(Fila["FechaAlta"]);
            DateTime FechaModificacion = Convert.ToDateTime(Fila["FechaModificacion"]);
            int Estado = Convert.ToInt32(Fila["Estado"]);
            return new Articulo(IdArticulo, Tipo, Marca, Modelo, Talle, Precio, Costo, FechaAlta, Estado);
        }


        public List<Articulo> Listar(int IdFactura)
        {
            List<Articulo> Lista = new List<Articulo>();
            string Consulta = "Select * from Articulos A inner join Detalle d on a.IdArticulo = d.IdArticulo where d.IdFactura = " + IdFactura;
            DataTable Tabla = Conexion.Listar(Consulta);
            foreach (DataRow Row in Tabla.Rows)
            { 
            Lista.Add(Mapear(Row));
            }
            return Lista;
        }


        public List<Articulo> ListarActivos()
        {
            List<Articulo> Lista = new List<Articulo>();
            DataTable Tabla = Conexion.Listar("Select * From Articulos where Estado = 1");
            foreach (DataRow Dr in Tabla.Rows)
            {
                Lista.Add(Mapear(Dr));
            }
            return Lista;
        }
    }
}
