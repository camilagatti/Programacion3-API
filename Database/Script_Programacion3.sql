-- 1. Crear la base de datos Programacion3 si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Programacion3')
BEGIN
    CREATE DATABASE Programacion3;
END
GO

USE Programacion3;
GO

-- 2. Crear la tabla Productos si no existe
IF OBJECT_ID('dbo.Productos', 'U') IS NULL
BEGIN
    CREATE TABLE Productos (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Nombre NVARCHAR(100) NOT NULL,
        Precio DECIMAL(18,2) NOT NULL,
        Stock INT NOT NULL
    );
END
GO

-- 3. Insertar 5 productos de prueba
IF NOT EXISTS (SELECT 1 FROM Productos)
BEGIN
    INSERT INTO Productos (Nombre, Precio, Stock) VALUES
    ('Mouse Logitech G203', 35000.00, 15),
    ('Teclado Mecanico Redragon', 58000.50, 10),
    ('Monitor Samsung 24 Pulgadas', 210000.00, 5),
    ('Disco Solido SSD 480GB', 49500.00, 20),
    ('Memoria RAM 16GB DDR4', 45000.00, 12);
END
GO

-- 4. Consulta de verificacion
SELECT Id, Nombre, Precio, Stock FROM Productos;
GO
