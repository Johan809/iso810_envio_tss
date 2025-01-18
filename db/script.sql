CREATE DATABASE ISO810_AN2
GO

USE ISO810_AN2
GO

--DROP TABLE Autodeterminacion_TSS 
CREATE TABLE Autodeterminacion_TSS 
(
    IdRegistro INT PRIMARY KEY IDENTITY,
    RncEmpresa varchar(11),
    FechaTransmision DATE,
    PeriodoCotizable VARCHAR(7),
    Nss VARCHAR(12),
    Cedula VARCHAR(9),
    Nombres VARCHAR(30),
    Apellidos VARCHAR(30),
    SueldoMensual DECIMAL(10, 2),
    MontoCotizable DECIMAL(10, 2),
    FechaIngreso DATE,
    TipoContrato CHAR(1) CHECK (TipoContrato IN ('P', 'T')),
    Estado CHAR(1) CHECK (estado IN ('A', 'S'))
);
GO

SELECT * FROM Autodeterminacion_TSS
