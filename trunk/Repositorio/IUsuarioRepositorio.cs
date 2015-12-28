using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
   public interface IUsuarioRepositorio
    {
        void Agregar(Usuario Usuario);

         void Modificar(Usuario Usuario);

         void Eliminar(Usuario Usuario);

         Usuario Buscar(int ID);

         List<Usuario> ListarUsuarios();

         List<Usuario> ListarUsuariosPorTipo(string Tipo);
 
    }
}
