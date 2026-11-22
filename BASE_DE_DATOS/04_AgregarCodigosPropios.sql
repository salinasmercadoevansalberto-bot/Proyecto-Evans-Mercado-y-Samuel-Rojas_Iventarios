USE SistemaInventarioVentas;
GO

SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    -- Agregar los códigos propios si las columnas todavía no existen.
    IF COL_LENGTH('dbo.Clientes', 'Codigo') IS NULL
    BEGIN
        ALTER TABLE dbo.Clientes ADD Codigo NVARCHAR(30) NULL;
    END;

    IF COL_LENGTH('dbo.Proveedores', 'Codigo') IS NULL
    BEGIN
        ALTER TABLE dbo.Proveedores ADD Codigo NVARCHAR(30) NULL;
    END;

    -- Asignar códigos iniciales a los registros existentes.
    UPDATE dbo.Clientes
    SET Codigo = N'CLI-' + RIGHT(REPLICATE('0', 10) + CONVERT(VARCHAR(10), IdCliente), 10)
    WHERE Codigo IS NULL;

    UPDATE dbo.Proveedores
    SET Codigo = N'PRO-' + RIGHT(REPLICATE('0', 10) + CONVERT(VARCHAR(10), IdProveedor), 10)
    WHERE Codigo IS NULL;

    -- Exigir que cada cliente y proveedor tenga un código.
    ALTER TABLE dbo.Clientes ALTER COLUMN Codigo NVARCHAR(30) NOT NULL;
    ALTER TABLE dbo.Proveedores ALTER COLUMN Codigo NVARCHAR(30) NOT NULL;

    -- Evitar que se repita el código propio en cada tabla.
    IF NOT EXISTS (
        SELECT 1
        FROM sys.indexes AS i
        INNER JOIN sys.index_columns AS ic
            ON ic.object_id = i.object_id AND ic.index_id = i.index_id
        INNER JOIN sys.columns AS c
            ON c.object_id = ic.object_id AND c.column_id = ic.column_id
        WHERE i.object_id = OBJECT_ID(N'dbo.Clientes')
          AND i.is_unique = 1
          AND ic.key_ordinal = 1
          AND c.name = N'Codigo'
    )
    BEGIN
        CREATE UNIQUE INDEX UX_Clientes_Codigo ON dbo.Clientes (Codigo);
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM sys.indexes AS i
        INNER JOIN sys.index_columns AS ic
            ON ic.object_id = i.object_id AND ic.index_id = i.index_id
        INNER JOIN sys.columns AS c
            ON c.object_id = ic.object_id AND c.column_id = ic.column_id
        WHERE i.object_id = OBJECT_ID(N'dbo.Proveedores')
          AND i.is_unique = 1
          AND ic.key_ordinal = 1
          AND c.name = N'Codigo'
    )
    BEGIN
        CREATE UNIQUE INDEX UX_Proveedores_Codigo ON dbo.Proveedores (Codigo);
    END;

    COMMIT TRANSACTION;
    PRINT N'Los códigos propios de clientes y proveedores se agregaron correctamente.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
GO
