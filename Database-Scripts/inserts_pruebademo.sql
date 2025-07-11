Use [pruebademo]
GO

-- Clientes:
INSERT INTO clientes (Cliente, Telefono, Correo) VALUES
('Juan Pérez', '111-123456', 'juan.perez@email.com'),
('María Gómez', '222-234567', 'maria.gomez@email.com'),
('Carlos Díaz', '333-345678', 'carlos.diaz@email.com'),
('Laura Torres', '444-456789', 'laura.torres@email.com'),
('Pedro Sánchez', '555-567890', 'pedro.sanchez@email.com'),
('Ana Martínez', '666-678901', 'ana.martinez@email.com'),
('Jorge Ramírez', '777-789012', 'jorge.ramirez@email.com'),
('Lucía Rojas', '888-890123', 'lucia.rojas@email.com'),
('Ricardo López', '999-901234', 'ricardo.lopez@email.com'),
('Sofía Fernández', '101-012345', 'sofia.fernandez@email.com');


GO

--PRODUCTOS
INSERT INTO productos (Nombre, Precio, Categoria) VALUES
('Pan Baguette', 150.0, 'Panadería'),
('Leche Entera', 120.0, 'Lácteos'),
('Galletitas Dulces', 200.0, 'Snacks'),
('Queso Cremoso', 600.0, 'Lácteos'),
('Jugo de Naranja', 250.0, 'Bebidas'),
('Harina 000', 100.0, 'Panadería'),
('Azúcar', 90.0, 'Almacén'),
('Yerba Mate', 800.0, 'Infusiones'),
('Aceite de Girasol', 1000.0, 'Almacén'),
('Cerveza Rubia', 500.0, 'Bebidas');

GO

-- VENTAS:
INSERT INTO ventas (IDCliente, Fecha, Total) VALUES
(1, '2025-07-01', 720.0),
(2, '2025-07-02', 1030.0),
(3, '2025-07-03', 620.0),
(4, '2025-07-04', 1200.0),
(5, '2025-07-05', 950.0),
(6, '2025-07-06', 800.0),
(7, '2025-07-06', 300.0),
(8, '2025-07-07', 1600.0),
(9, '2025-07-07', 760.0),
(10, '2025-07-08', 1350.0);

GO

-- Ventasitems.
INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES
-- Venta 1
(1, 1, 150.0, 2, 300.0),
(1, 2, 120.0, 2, 240.0),
(1, 3, 180.0, 1, 180.0),

-- Venta 2
(2, 4, 600.0, 1, 600.0),
(2, 5, 250.0, 1.72, 430.0),

-- Venta 3
(3, 6, 100.0, 3, 300.0),
(3, 7, 90.0, 2, 180.0),
(3, 2, 120.0, 1.2, 140.0),

-- Venta 4
(4, 8, 800.0, 1, 800.0),
(4, 3, 200.0, 2, 400.0),

-- Venta 5
(5, 10, 500.0, 1, 500.0),
(5, 1, 150.0, 3, 450.0),

-- Venta 6
(6, 2, 120.0, 2, 240.0),
(6, 9, 1000.0, 0.56, 560.0),

-- Venta 7
(7, 3, 200.0, 1, 200.0),
(7, 5, 250.0, 0.4, 100.0),

-- Venta 8
(8, 4, 600.0, 2, 1200.0),
(8, 6, 100.0, 4, 400.0),

-- Venta 9
(9, 1, 150.0, 3, 450.0),
(9, 7, 90.0, 3.4, 310.0),

-- Venta 10
(10, 8, 800.0, 1, 800.0),
(10, 10, 500.0, 1.1, 550.0);




