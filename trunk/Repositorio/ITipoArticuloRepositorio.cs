using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    interface ITipoArticuloRepositorio
    {
        void Agregar(TipoArticulo Tipo);
        void Borrar(TipoArticulo Tipo);
        void Listar();
        TipoArticulo Buscar(int Id);
    }
}
