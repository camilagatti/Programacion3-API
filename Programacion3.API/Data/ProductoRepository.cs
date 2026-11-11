using Microsoft.Data.SqlClient;
using Programacion3.API.Models;

namespace Programacion3.API.Data
{
    // Implementacion del repositorio utilizando ADO.NET para consultar SQL Server
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        // Inyectamos IConfiguration para leer la cadena de conexion desde appsettings.json
        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        // Obtiene la lista de todos los productos
        public List<Producto> ObtenerTodos()
        {
            List<Producto> productos = new List<Producto>();

            // using garantiza que la conexion se cierre y libere los recursos automaticamente
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Id, Nombre, Precio, Stock FROM Productos";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()!,
                                Precio = Convert.ToDecimal(reader["Precio"]),
                                Stock = Convert.ToInt32(reader["Stock"])
                            };

                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }

        // Obtiene un producto por su identificador unico
        public Producto? ObtenerPorId(int id)
        {
            Producto? producto = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Id, Nombre, Precio, Stock FROM Productos WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Usamos parametros SQL para evitar ataques de SQL Injection
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()!,
                                Precio = Convert.ToDecimal(reader["Precio"]),
                                Stock = Convert.ToInt32(reader["Stock"])
                            };
                        }
                    }
                }
            }

            return producto;
        }
    }
}
