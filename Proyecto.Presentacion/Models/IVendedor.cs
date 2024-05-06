using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Presentacion.Models
{
    public interface IVendedor
    {
        //Definir los métodos de mantenimiento de vendedor
        //para los listados:
        IEnumerable<Vendedor> listadoVendedor();
        IEnumerable<VendedorO> listadoVendedorO();
        IEnumerable<Distrito> listadoDistrito();

        //para el merge
        string nuevoVendedor(VendedorO objV);
        string modificaVendedor(VendedorO objV);
    }
}
