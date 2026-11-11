using Programacion3.API.Data;
using Programacion3.API.Models;

namespace Programacion3.API.Services
{
    // Implementacion del servicio que coordina las operaciones de productos
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        // Inyeccion de dependencias: recibe el repositorio por constructor
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<Producto> ObtenerTodos()
        {
            return _productoRepository.ObtenerTodos();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productoRepository.ObtenerPorId(id);
        }
    }
}
