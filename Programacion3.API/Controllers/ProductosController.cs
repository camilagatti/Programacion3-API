using Microsoft.AspNetCore.Mvc;
using Programacion3.API.Models;
using Programacion3.API.Services;

namespace Programacion3.API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        // Inyeccion de dependencias: el Controller recibe el Service por constructor
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET /api/productos -> Devuelve todos los productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                List<Producto> productos = _productoService.ObtenerTodos();
                return Ok(productos);
            }
            catch (Exception)
            {
                // Manejo de errores: devolvemos 500 sin exponer datos sensibles del servidor
                return StatusCode(500, "Ocurrio un error al consultar los productos en la base de datos.");
            }
        }

        // GET /api/productos/{id} -> Devuelve un producto por Id (o 404 si no existe)
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                Producto? producto = _productoService.ObtenerPorId(id);

                if (producto == null)
                {
                    return NotFound($"No se encontro ningun producto con el Id {id}.");
                }

                return Ok(producto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error al consultar el producto en la base de datos.");
            }
        }
    }
}
