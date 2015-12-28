using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Repositorio
{
    interface IArticuloRepositorio
    {
        void Agregar(Articulo Articulo);
        void Modificar(Articulo Articulo);
        void Borrar(Articulo Articulo);
        List<Articulo> Listar();
        List<Articulo> Listar(int IdFactura);
        List<Articulo> ListarActivos();
        
    }
}
