
USE SistemaInventarioVentas;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    -- =========================================
    -- 1. CATEGORIAS
    -- =========================================
    INSERT INTO dbo.Categorias (Nombre, Descripcion)
    VALUES
        ('Abarrotes', 'Arroz, frijoles y productos basicos'),
        ('Bebidas', 'Leche y otras bebidas'),
        ('Limpieza', 'Productos de limpieza');

    -- =========================================
    -- 2. PRODUCTOS
    -- =========================================
    INSERT INTO dbo.Productos
        (IdCategoria, Codigo, Nombre, PrecioCosto,
         PrecioVenta, Existencias, Estado)
    SELECT IdCategoria, 'P001', 'Arroz 1 kg', 700, 1000, 0, 1
    FROM dbo.Categorias WHERE Nombre = 'Abarrotes';

    INSERT INTO dbo.Productos
        (IdCategoria, Codigo, Nombre, PrecioCosto,
         PrecioVenta, Existencias, Estado)
    SELECT IdCategoria, 'P002', 'Frijoles 1 kg', 850, 1200, 0, 1
    FROM dbo.Categorias WHERE Nombre = 'Abarrotes';

    INSERT INTO dbo.Productos
        (IdCategoria, Codigo, Nombre, PrecioCosto,
         PrecioVenta, Existencias, Estado)
    SELECT IdCategoria, 'P003', 'Leche 1 litro', 900, 1250, 0, 1
    FROM dbo.Categorias WHERE Nombre = 'Bebidas';

    INSERT INTO dbo.Productos
        (IdCategoria, Codigo, Nombre, PrecioCosto,
         PrecioVenta, Existencias, Estado)
    SELECT IdCategoria, 'P004', 'Detergente', 1200, 1700, 0, 1
    FROM dbo.Categorias WHERE Nombre = 'Limpieza';

    -- =========================================
    -- 3. CLIENTES
    -- =========================================
    INSERT INTO dbo.Clientes
        (Nombre, Cedula, Telefono, Correo, Direccion, Estado)
    VALUES
        ('Ana Rodriguez', '101110111', '8888-1111',
         'ana@example.com', 'San Jose', 1),
        ('Carlos Mendez', '202220222', '8888-2222',
         'carlos@example.com', 'Perez Zeledon', 1);

    -- =========================================
    -- 4. PROVEEDORES
    -- =========================================
    INSERT INTO dbo.Proveedores
        (Nombre, Telefono, Correo, Direccion, Estado)
    VALUES
        ('Distribuidora Central', '2222-1111',
         'central@example.com', 'San Jose', 1),
        ('Comercial La Economica', '2222-2222',
         'economica@example.com', 'Cartago', 1);

    -- =========================================
    -- 5. COMPRA DE PRUEBA
    -- 10 unidades de cada producto.
    -- Total: 7000 + 8500 + 9000 + 12000 = 36500
    -- =========================================
    DECLARE @Proveedor INT;
    DECLARE @Compra INT;

    SELECT @Proveedor = IdProveedor
    FROM dbo.Proveedores
    WHERE Nombre = 'Distribuidora Central';

    INSERT INTO dbo.Compras (IdProveedor, Total, Estado)
    VALUES (@Proveedor, 36500, 'Registrada');

    SET @Compra = SCOPE_IDENTITY();

    INSERT INTO dbo.DetalleCompra
        (IdCompra, IdProducto, Cantidad, PrecioCosto, Subtotal)
    SELECT @Compra, IdProducto, 10, PrecioCosto, PrecioCosto * 10
    FROM dbo.Productos
    WHERE Codigo IN ('P001', 'P002', 'P003', 'P004');

    -- Actualizar existencias por la compra.
    UPDATE dbo.Productos
    SET Existencias = Existencias + 10
    WHERE Codigo IN ('P001', 'P002', 'P003', 'P004');

    -- =========================================
    -- 6. VENTA DE PRUEBA
    -- 2 arroces y 1 leche.
    -- Total: 2000 + 1250 = 3250
    -- =========================================
    DECLARE @Cliente INT;
    DECLARE @Venta INT;

    SELECT @Cliente = IdCliente
    FROM dbo.Clientes
    WHERE Cedula = '101110111';

    INSERT INTO dbo.Ventas (IdCliente, Total, Estado)
    VALUES (@Cliente, 3250, 'Registrada');

    SET @Venta = SCOPE_IDENTITY();

    INSERT INTO dbo.DetalleVenta
        (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal)
    SELECT
        @Venta,
        IdProducto,
        CASE Codigo
            WHEN 'P001' THEN 2
            WHEN 'P003' THEN 1
        END,
        PrecioVenta,
        PrecioVenta *
        CASE Codigo
            WHEN 'P001' THEN 2
            WHEN 'P003' THEN 1
        END
    FROM dbo.Productos
    WHERE Codigo IN ('P001', 'P003');

    -- Descontar las unidades vendidas.
    UPDATE dbo.Productos
    SET Existencias = Existencias -
        CASE Codigo
            WHEN 'P001' THEN 2
            WHEN 'P003' THEN 1
        END
    WHERE Codigo IN ('P001', 'P003');

    COMMIT TRANSACTION;

    PRINT 'Datos de prueba insertados correctamente.';

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT 'Error al insertar los datos de prueba.';
    PRINT ERROR_MESSAGE();
END CATCH;
GO

-- =========================================
-- 7. CONSULTAR LOS RESULTADOS
-- =========================================
SELECT * FROM dbo.Categorias;
SELECT * FROM dbo.Productos;
SELECT * FROM dbo.Clientes;
SELECT * FROM dbo.Proveedores;
SELECT * FROM dbo.Compras;
SELECT * FROM dbo.DetalleCompra;
SELECT * FROM dbo.Ventas;
SELECT * FROM dbo.DetalleVenta;
GO

