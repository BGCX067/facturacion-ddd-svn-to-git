using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
   public interface IFacturaRepositorio
    {
        void Agregar(Factura Factura);
        void AgregarArticulo(Factura Factura, Articulo Articulo);
        void Modificar(Factura Factura);
        void Eliminar(Factura Factura);
        Factura Buscar(int NumeroFactura);
        List<Factura> Listar();
        List<Factura> Listar(DateTime FechaInicio, DateTime FechaFin);

    }
}
