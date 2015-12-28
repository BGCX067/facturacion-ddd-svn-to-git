using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    class UsuarioRepositorio:IUsuarioRepositorio, Imapeador<Usuario>
    {
        Conexion Conexion;
        public UsuarioRepositorio()
        {
            Conexion = new Conexion();
        }
        public void Agregar(Usuario Usuario)
        {
            string valores = Usuario.User+",";
            valores += Usuario.Pass+",";
            valores += Usuario.Tipo.IdTipo; 
            Conexion.AgregarSinId("Usuarios", "User" + "," + "Pass" + "," + "IdTipoUsuario", valores);
        }

        public void Modificar(Usuario Usuario)
        {
            string Consulta = "Update Usuarios set ";
            Consulta += "User = " + Usuario.User + ", ";
            Consulta += "Pass = " + Usuario.Pass + " ";
            Consulta += "Where Id = " + Usuario.ID;
            Conexion.ActualizarOEliminar(Consulta);
        }

        public void Eliminar(Usuario Usuario)
        {
            string Consulta = "Delete From Usuarios where ID = "+Usuario.ID;
            Conexion.ActualizarOEliminar(Consulta);
        }
        public Usuario Buscar(int ID)
        {
           string Consulta ="Select (U.IdUsuario,U.User,U.Pass,T.IdTipoUsuario,T.Descripcion) FROM Usuarios U inner join TipoUsuarios T ON U.IdTipoUsuario = T.IdTipoUsuario  WHERE U.IdUsuario = "+ID;
           return Mapear(Conexion.Buscar(Consulta));
           
        }
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> Lista = new List<Usuario>();
            DataTable Tabla = Conexion.Listar("Select * From Usuarios");
            foreach (DataRow Fila in Tabla.Rows)
            {
                Lista.Add(Mapear(Fila));
            }
            return Lista;
        }

        public List<Usuario> ListarUsuariosPorTipo(string Tipo)
        {
            List<Usuario> Lista = new List<Usuario>();
            DataTable Tabla = Conexion.Listar("Select * From Usuarios where Tipo= "+Tipo);
            foreach (DataRow Fila in Tabla.Rows)
            {
                Lista.Add(Mapear(Fila));
            }
            return Lista;
        }

        public Usuario Mapear(System.Data.DataRow Fila)
        {
            Usuario Usuario = null;
            if (Fila != null)
            { 
                int ID= Convert.ToInt32(Fila["ID"]);
                string User = Fila["User"].ToString();
                string Pass = Fila["Pass"].ToString();
                
                TipoUsuario Tipo = new TipoUsuario(Convert.ToInt32(Fila["IdTipo"]), Fila["Tipo"].ToString());

                Usuario = new Usuario(ID, User, Pass, Tipo);
            }
            return Usuario;
        }
    }
}
