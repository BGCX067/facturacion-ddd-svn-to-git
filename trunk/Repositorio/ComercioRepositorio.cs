using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
namespace Repositorio
{
   public class ComercioRepositorio:IComercioRepositorio,Imapeador<Comercio>
    {
        Conexion Conexion;
        public ComercioRepositorio()
        {
            Conexion = new Conexion();
        }
        public void Agregar(Comercio Comercio)
        {
            string Valores = Comercio.RazonSocial+",";
            Valores+=Comercio.CUIL+",";
            Valores+=Comercio.Ubicacion.Provincia+",";
            Valores+=Comercio.Ubicacion.Localidad+",";
            Valores+=Comercio.Ubicacion.Direccion+",";
            Valores+=Comercio.Contacto.Telefono+",";
            Valores+=Comercio.Contacto.Email;
            Conexion.AgregarSinId("Comercio", "RazonSocial,CUIL,Provincia,Localidad,Direccion,Telefono,Email", Valores);
        }

        public void Modificar(Comercio Comercio)
        {
            string Consulta = "Update Comercio set ";
            Consulta += "RazonSocial=" + Comercio.RazonSocial+", ";
            Consulta += "CUIL=" + Comercio.CUIL + ", ";
            Consulta+="Provincia="+Comercio.Ubicacion.Provincia+", ";
            Consulta += "Localidad=" + Comercio.Ubicacion.Localidad+", ";
            Consulta += "Direccion=" + Comercio.Ubicacion.Direccion + ", ";
            Consulta+="Telefono="+Comercio.Contacto.Telefono;
            Consulta += "Email=" + Comercio.Contacto.Email;
            Conexion.ActualizarOEliminar(Consulta);
        }

        public void Eliminar(Comercio Comercio)
        {
            string Consulta = "Delete from Comercio";
            Conexion.ActualizarOEliminar(Consulta);
        }

        public Comercio Buscar(int Id)
        {
            string Consulta = "Select * From Comercio";
            return Mapear(Conexion.Buscar(Consulta));
        }

        public Comercio Mapear(System.Data.DataRow Fila)
        {
            Ubicacion Ubicacion = new Ubicacion(Fila["Provincia"].ToString(),Fila["Localidad"].ToString(),Fila["Direccion"].ToString());
            Contacto Contacto = new Contacto(Fila["Telefono"].ToString(), Fila["Email"].ToString());
            Comercio Comercio = new Comercio(Fila["RazonSocial"].ToString(), Fila["CUIL"].ToString(), Contacto, Ubicacion);
            return Comercio;
        }
    }
}
