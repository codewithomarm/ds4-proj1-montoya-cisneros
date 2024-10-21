-- -----------------------------------------------------
-- Verificar si la base de datos existe y eliminarla
-- -----------------------------------------------------
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'calculadoradb')
BEGIN
    DROP DATABASE calculadoradb;
END;
GO

-- -----------------------------------------------------
-- Crear la base de datos si no existe
-- -----------------------------------------------------
CREATE DATABASE calculadoradb;
GO

USE calculadoradb;
GO

-- -----------------------------------------------------
-- Verificar si la tabla existe y eliminarla
-- -----------------------------------------------------
IF OBJECT_ID('calculadoradb.dbo.calculos', 'U') IS NOT NULL
BEGIN
    DROP TABLE calculadoradb.dbo.calculos;
END;
GO

-- -----------------------------------------------------
-- Crear la tabla
-- -----------------------------------------------------
CREATE TABLE calculadoradb.dbo.calculos (
    id INT NOT NULL IDENTITY(1,1), -- IDENTITY para auto-incrementar
    expresion VARCHAR(250) NOT NULL,
    resultado VARCHAR(250) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(), -- GETDATE() para la fecha y hora actual
    PRIMARY KEY (id)
);
GO
