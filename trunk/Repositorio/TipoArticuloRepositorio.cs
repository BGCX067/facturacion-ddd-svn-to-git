using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;

namespace Repositorio
{
    class TipoArticuloRepositorio:ITipoArticuloRepositorio,Imapeador<TipoArticulo>
    {
        Conexion Conexion;
        public TipoArticuloRepositorio()
        {
            Conexion = new Conexion();
        }

        public void Agregar(TipoArticulo Tipo)
        {
            throw new NotImplementedException();
        }

        public void Borrar(TipoArticulo Tipo)
        {
            throw new NotImplementedException();
        }

        public void Listar()
        {
            throw new NotImplementedException();
        }

        public TipoArticulo Buscar(int Id)
        {
            string Consulta = "Select * From TipoArticulos WHERE IdTipoArticulo = "+Id;
            return Mapear(Conexion.Buscar(Consulta));
        }

        public TipoArticulo Mapear(System.Data.DataRow Fila)
        {
            TipoArticulo Tipo = new TipoArticulo(Convert.ToInt32(Fila["IdTipo"]), Fila["Descripcion"].ToString());
            return Tipo;
        }
    }
}
