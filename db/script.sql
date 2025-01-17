CREATE DATABASE ISO810_AN2
GO

--DROP TABLE Autodeterminacion_TSS 
CREATE TABLE Autodeterminacion_TSS 
(
    id_registro INT PRIMARY KEY IDENTITY,
    rnc_empresa CHAR(11),
    fecha_transmision DATE,
    periodo_cotizable CHAR(7),
    nss CHAR(12),
    cedula CHAR(9),
    nombres VARCHAR(30),
    apellidos VARCHAR(30),
    sueldo_mensual DECIMAL(10, 2),
    monto_cotizable DECIMAL(10, 2),
    fecha_ingreso DATE,
    tipo_contrato CHAR(1) CHECK (tipo_contrato IN ('P', 'T')),
    estado CHAR(1) CHECK (estado IN ('A', 'S'))
);
GO