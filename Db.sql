CREATE DATABASE Securitydb;
use Securitydb;

-- Tablas que no dependen de otra tabla --
CREATE TABLE Pais(
    Id INT NOT NULL,
    NombrePais VARCHAR(50) NOT NULL,
    CONSTRAINT PkPais PRIMARY KEY (Id)
);
CREATE TABLE TipoPersona(
    Id INT NOT NULL,
    Descripcion TEXT NULL,
    CONSTRAINT PkTpPersona PRIMARY KEY (Id)
);
CREATE TABLE TipoContacto(
    Id INT NOT NULL,
    Descripcion TEXT NULL,
    CONSTRAINT PkTpContacto PRIMARY KEY (Id)
);
CREATE TABLE TipoDireccion(
    Id INT NOT NULL,
    Descripcion TEXT NULL,
    CONSTRAINT PkTpDireccion PRIMARY KEY (Id)
);
CREATE TABLE CategoriaPersona(
    Id INT NOT NULL,
    NombreCategoria VARCHAR(50) NOT NULL,
    CONSTRAINT PkCtPersona PRIMARY KEY (Id)
);
CREATE TABLE Turno(
    Id INT NOT NULL,
    NombreTurno VARCHAR(50) NOT NULL,
    HoraTurNOT TIME NOT NULL,
    HoraTurnoF TIME NOT NULL,
    CONSTRAINT PkTurno PRIMARY KEY (Id)
);
CREATE TABLE Estado(
    Id INT NOT NULL,
    Descripcion TEXT NULL,
    CONSTRAINT PkEstado PRIMARY KEY (Id)
);

-- Tablas que si dependen de otra tabla --
CREATE TABLE Departamento(
    Id INT NOT NULL,
    NombreDepar VARCHAR(50) NOT NULL,
    IdPaisFk INT NOT NULL,
    CONSTRAINT PkDepartamento PRIMARY KEY (Id),
    CONSTRAINT FkPais FOREIGN KEY (IdPaisFk) REFERENCES Pais(Id)
);
CREATE TABLE Ciudad(
    Id INT NOT NULL,
    NombreCiudad VARCHAR(50) NOT NULL,
    IdDeparFk INT NOT NULL,
    CONSTRAINT PkCiudad PRIMARY KEY (Id),
    CONSTRAINT FkDepar FOREIGN KEY (IdDeparFk) REFERENCES Departamento(Id)
);
CREATE TABLE Persona(
    Id INT NOT NULL,
    IdPerUq INT NOT NULL,
    NombrePersona VARCHAR(50) NOT NULL,
    FechaReg date NOT NULL,
    IdTpPersonaFk INT NOT NULL,
    IdCategoriaP INT NOT NULL,
    IdCiudadFk INT NOT NULL,
    CONSTRAINT PkPersona PRIMARY KEY (Id),
    CONSTRAINT UqPer UNIQUE(IdPerUq),
    CONSTRAINT FkTpPer FOREIGN KEY (IdTpPersonaFk) REFERENCES TipoPersona(Id),
    CONSTRAINT FkCatP FOREIGN KEY (IdCategoriaP) REFERENCES CategoriaPersona(Id),
    CONSTRAINT FkCiudad FOREIGN KEY (IdCiudadFk) REFERENCES Ciudad(Id)
);
CREATE TABLE Contrato(
    Id INT NOT NULL,
    FechaContrato DATE NOT NULL,
    FechaFin DATE NOT NULL,
    IdClienteFk INT NOT NULL,
    IdEmpleadoFk INT NOT NULL,
    IdEstadoFk INT NOT NULL,
    CONSTRAINT PkContrato PRIMARY KEY (Id),
    CONSTRAINT FkCliente FOREIGN KEY (IdClienteFk) REFERENCES Persona(Id),
    CONSTRAINT FkEmpleado FOREIGN KEY (IdEmpleadoFk) REFERENCES Persona(Id),
    CONSTRAINT FkEstado FOREIGN KEY (IdEstadoFk) REFERENCES Estado(Id)
);
CREATE TABLE DireccionPersona(
    Id INT NOT NULL,
    Direccion VARCHAR(100) NULL,
    IdTpDireccionFk INT NOT NULL,
    IdPersonaFk INT NOT NULL,
    CONSTRAINT PkDireccionP PRIMARY KEY (Id),
    CONSTRAINT FkTpDireccion FOREIGN KEY (IdTpDireccionFk) REFERENCES TipoDireccion(Id),
    CONSTRAINT FkPersona FOREIGN KEY (IdPersonaFk) REFERENCES Persona(Id)
);
CREATE TABLE ContactoPersona(
    Id INT NOT NULL,
    Descripcion VARCHAR(100) NULL,
    IdTpContactoFk INT NOT NULL,
    IdPersonaFk INT NOT NULL,
    CONSTRAINT PkContactoP PRIMARY KEY (Id),
    CONSTRAINT UqCtPersona UNIQUE(Descripcion),
    CONSTRAINT FkTpContacto FOREIGN KEY (IdTpContactoFk) REFERENCES TipoContacto(Id),
    CONSTRAINT FkPersonaC FOREIGN KEY (IdPersonaFk) REFERENCES Persona(Id)
);

CREATE TABLE Programacion(
    Id INT NOT NULL,
    IdContratoFk INT NOT NULL,
    IdTurnoFk INT NOT NULL,
    IdEmpleadoFk INT NOT NULL,
    CONSTRAINT FkContrato FOREIGN KEY (IdContratoFk) REFERENCES Contrato(Id),
    CONSTRAINT FkTurno FOREIGN KEY (IdTurnoFk) REFERENCES Turno(Id),
    CONSTRAINT FkEmpleadoO FOREIGN KEY (IdEmpleadoFk) REFERENCES Persona(Id)
);

