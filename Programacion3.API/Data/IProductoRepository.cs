using Programacion3.API.Models;

namespace Programacion3.API.Data
{
    // Define el contrato para el acceso a datos de productos
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
    }
}
