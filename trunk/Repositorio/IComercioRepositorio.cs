using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IComercioRepositorio
    {
         void Agregar(Comercio Comercio);
         void Modificar(Comercio Comercio);
         void Eliminar(Comercio Comercio);
         Comercio Buscar(int Id);
    }
}
