-- Crear la base de datos
CREATE DATABASE productos;
GO

-- Usar la base de datos
USE productos;
GO

-- Crear la tabla Productos
CREATE TABLE Productos (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255),
    precio DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL,
    tms DATETIME DEFAULT GETDATE()
);

-- Datos de prueba

INSERT INTO Productos (nombre, descripcion, precio, stock)
VALUES 
('Tequila Don Julio', 'Tequila reposado 750ml', 450.00, 20),
('Cerveza Corona', 'Botella de 355ml', 25.50, 100),
('Ron Bacardí Blanco', 'Botella de ron blanco 750ml', 210.00, 35),
('Whisky Johnnie Walker Black', 'Botella de 750ml', 820.00, 10);


SELECT * FROM Productos; 