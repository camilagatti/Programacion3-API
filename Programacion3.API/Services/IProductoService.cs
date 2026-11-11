using Programacion3.API.Models;

namespace Programacion3.API.Services
{
    // Define el contrato para la logica de negocio de productos
    public interface IProductoService
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
    }
}
