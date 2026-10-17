USE SistemaInventarioVentas;
GO

-- 1. Categorías de productos
CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL,
    Descripcion NVARCHAR(200)
);
GO

-- 2. Productos
CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    IdCategoria INT NOT NULL,
    Codigo NVARCHAR(30) NOT NULL UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    PrecioCosto DECIMAL(10,2) NOT NULL,
    PrecioVenta DECIMAL(10,2) NOT NULL,
    Existencias INT NOT NULL DEFAULT 0,
    Estado BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Productos_Categorias
        FOREIGN KEY (IdCategoria)
        REFERENCES Categorias(IdCategoria),

    CONSTRAINT CK_Productos_Precios
        CHECK (PrecioCosto >= 0 AND PrecioVenta >= 0),

    CONSTRAINT CK_Productos_Existencias
        CHECK (Existencias >= 0)
);
GO

-- 3. Clientes
CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(30),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100),
    Direccion NVARCHAR(200),
    Estado BIT NOT NULL DEFAULT 1
);
GO

-- 4. Proveedores
CREATE TABLE Proveedores (
    IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100),
    Direccion NVARCHAR(200),
    Estado BIT NOT NULL DEFAULT 1
);
GO

-- 5. Compras
CREATE TABLE Compras (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    IdProveedor INT NOT NULL,
    FechaCompra DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Total DECIMAL(12,2) NOT NULL DEFAULT 0,
    Estado NVARCHAR(20) NOT NULL DEFAULT N'Registrada',

    CONSTRAINT FK_Compras_Proveedores
        FOREIGN KEY (IdProveedor)
        REFERENCES Proveedores(IdProveedor),

    CONSTRAINT CK_Compras_Total CHECK (Total >= 0)
);
GO

-- 6. Detalle de cada compra
CREATE TABLE DetalleCompra (
    IdDetalleCompra INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioCosto DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(12,2) NOT NULL,

    CONSTRAINT FK_DetalleCompra_Compras
        FOREIGN KEY (IdCompra) REFERENCES Compras(IdCompra),

    CONSTRAINT FK_DetalleCompra_Productos
        FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto),

    CONSTRAINT CK_DetalleCompra_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetalleCompra_Precio CHECK (PrecioCosto >= 0),
    CONSTRAINT CK_DetalleCompra_Subtotal CHECK (Subtotal >= 0)
);
GO

-- 7. Ventas
CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NULL,
    FechaVenta DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Total DECIMAL(12,2) NOT NULL DEFAULT 0,
    Estado NVARCHAR(20) NOT NULL DEFAULT N'Registrada',

    CONSTRAINT FK_Ventas_Clientes
        FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),

    CONSTRAINT CK_Ventas_Total CHECK (Total >= 0)
);
GO

-- 8. Detalle de cada venta
CREATE TABLE DetalleVenta (
    IdDetalleVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(12,2) NOT NULL,

    CONSTRAINT FK_DetalleVenta_Ventas
        FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta),

    CONSTRAINT FK_DetalleVenta_Productos
        FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto),

    CONSTRAINT CK_DetalleVenta_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetalleVenta_Precio CHECK (PrecioUnitario >= 0),
    CONSTRAINT CK_DetalleVenta_Subtotal CHECK (Subtotal >= 0)
);
GO