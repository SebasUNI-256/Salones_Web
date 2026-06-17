CREATE DATABASE BD_ReservacionesSalones;
GO

USE BD_ReservacionesSalones;
GO

/*=========================================
  ROLES
=========================================*/
CREATE TABLE Roles(
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200),
    Activo BIT NOT NULL DEFAULT 1
);

/*=========================================
  USUARIOS
=========================================*/
CREATE TABLE Usuarios(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,

    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Clave VARCHAR(255) NOT NULL,

    Activo BIT NOT NULL DEFAULT 1,

    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL,

    IdRol INT NOT NULL,

    FOREIGN KEY(IdRol)
        REFERENCES Roles(IdRol)
);

/*=========================================
  BITACORA
=========================================*/
CREATE TABLE Bitacora(
    IdBitacora INT IDENTITY(1,1) PRIMARY KEY,

    IdUsuario INT NOT NULL,

    Accion VARCHAR(50) NOT NULL,
    Modulo VARCHAR(50) NOT NULL,

    TablaAfectada VARCHAR(100),
    RegistroAfectado INT,

    ValorAnterior VARCHAR(MAX),
    ValorNuevo VARCHAR(MAX),

    Fecha DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY(IdUsuario)
        REFERENCES Usuarios(IdUsuario)
);

/*=========================================
  CLIENTES
=========================================*/
CREATE TABLE Clientes(
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,

    Cedula VARCHAR(20) NOT NULL UNIQUE,

    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,

    Telefono VARCHAR(20),
    Correo VARCHAR(100),

    Direccion VARCHAR(200),

    Activo BIT NOT NULL DEFAULT 1,

    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);

/*=========================================
  CONTACTOS CLIENTE
=========================================*/
CREATE TABLE ContactosCliente(
    IdContacto INT IDENTITY(1,1) PRIMARY KEY,

    IdCliente INT NOT NULL,

    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Correo VARCHAR(100),

    CONSTRAINT UQ_ContactosCliente_Cliente_Correo
        UNIQUE(IdCliente, Correo),

    FOREIGN KEY(IdCliente)
        REFERENCES Clientes(IdCliente)
);

/*=========================================
  TIPOS EVENTO
=========================================*/
CREATE TABLE TiposEvento(
    IdTipoEvento INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion VARCHAR(300),

    Activo BIT DEFAULT 1
);

/*=========================================
  SEDES
=========================================*/
CREATE TABLE Sedes(
    IdSede INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),

    Activo BIT DEFAULT 1
);

/*=========================================
  TIPOS SALON
=========================================*/
CREATE TABLE TiposSalon(
    IdTipoSalon INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL UNIQUE,

    Activo BIT DEFAULT 1
);

/*=========================================
  SALONES
=========================================*/
CREATE TABLE Salones(
    IdSalon INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL,

    Capacidad INT NOT NULL
        CHECK(Capacidad > 0),

    PrecioBase DECIMAL(12,2) NOT NULL
        CHECK(PrecioBase >= 0),

    Descripcion VARCHAR(300),

    Activo BIT DEFAULT 1,

    IdSede INT NOT NULL,
    IdTipoSalon INT NOT NULL,

    CONSTRAINT UQ_Salones_Sede_Nombre
        UNIQUE(IdSede, Nombre),

    FOREIGN KEY(IdSede)
        REFERENCES Sedes(IdSede),

    FOREIGN KEY(IdTipoSalon)
        REFERENCES TiposSalon(IdTipoSalon)
);

/*=========================================
  TIPOS EQUIPO
=========================================*/
CREATE TABLE TiposEquipo(
    IdTipoEquipo INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL UNIQUE
);

/*=========================================
  EQUIPOS
=========================================*/
CREATE TABLE Equipos(
    IdEquipo INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL UNIQUE,

    CantidadDisponible INT NOT NULL
        CHECK(CantidadDisponible >= 0),

    Activo BIT DEFAULT 1,

    IdTipoEquipo INT NOT NULL,

    FOREIGN KEY(IdTipoEquipo)
        REFERENCES TiposEquipo(IdTipoEquipo)
);

/*=========================================
  HORARIOS BLOQUEADOS
=========================================*/
CREATE TABLE HorariosBloqueados(
    IdBloqueo INT IDENTITY(1,1) PRIMARY KEY,

    IdSalon INT NOT NULL,

    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,

    Motivo VARCHAR(300),

    CONSTRAINT CHK_HorariosBloqueados_RangoValido
        CHECK(FechaFin > FechaInicio),

    FOREIGN KEY(IdSalon)
        REFERENCES Salones(IdSalon)
);

CREATE TABLE TiposServicio(
    IdTipoServicio INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Servicios(
    IdServicio INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL UNIQUE,

    Precio DECIMAL(12,2) NOT NULL
        CHECK(Precio >= 0),

    Activo BIT DEFAULT 1,

    IdTipoServicio INT NOT NULL,

    FOREIGN KEY(IdTipoServicio)
        REFERENCES TiposServicio(IdTipoServicio)
);

CREATE TABLE Promociones(
    IdPromocion INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL,

    Porcentaje DECIMAL(5,2) NOT NULL
        CHECK(Porcentaje BETWEEN 0 AND 100),

    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,

    Activo BIT DEFAULT 1,

    CONSTRAINT CHK_Promociones_RangoFechas
        CHECK(FechaFin >= FechaInicio)
);

CREATE TABLE SalonPromocion(
    IdSalonPromocion INT IDENTITY(1,1) PRIMARY KEY,

    IdSalon INT NOT NULL,
    IdPromocion INT NOT NULL,

    FOREIGN KEY(IdSalon)
        REFERENCES Salones(IdSalon),

    FOREIGN KEY(IdPromocion)
        REFERENCES Promociones(IdPromocion),

    CONSTRAINT UQ_SalonPromocion
        UNIQUE(IdSalon, IdPromocion)
);

CREATE TABLE EstadosReservacion(
    IdEstadoReservacion INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Reservaciones(
    IdReservacion INT IDENTITY(1,1) PRIMARY KEY,

    CodigoReservacion VARCHAR(50) NOT NULL UNIQUE,

    IdCliente INT NOT NULL,
    IdSalon INT NOT NULL,
    IdTipoEvento INT NOT NULL,
    IdEstadoReservacion INT NOT NULL,

    FechaEvento DATE NOT NULL,

    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,

    CantidadInvitados INT NOT NULL
        CHECK(CantidadInvitados > 0),

    Total DECIMAL(12,2) NOT NULL
        CHECK(Total >= 0),

    FechaRegistro DATETIME DEFAULT GETDATE(),

    CONSTRAINT CHK_Reservaciones_HoraFinMayor
        CHECK(HoraFin > HoraInicio),
    CONSTRAINT CHK_Reservaciones_FechaRegistro
        CHECK(FechaRegistro IS NULL OR FechaRegistro <= GETDATE()),

    FOREIGN KEY(IdCliente)
        REFERENCES Clientes(IdCliente),

    FOREIGN KEY(IdSalon)
        REFERENCES Salones(IdSalon),

    FOREIGN KEY(IdTipoEvento)
        REFERENCES TiposEvento(IdTipoEvento),

    FOREIGN KEY(IdEstadoReservacion)
        REFERENCES EstadosReservacion(IdEstadoReservacion)
);

CREATE TABLE ReservacionServicio(
    IdReservacionServicio INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL,
    IdServicio INT NOT NULL,

    Cantidad INT NOT NULL
        CHECK(Cantidad > 0),

    Precio DECIMAL(12,2) NOT NULL
        CHECK(Precio >= 0),

    CONSTRAINT UQ_ReservacionServicio_Reservacion_Servicio
        UNIQUE(IdReservacion, IdServicio),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion),

    FOREIGN KEY(IdServicio)
        REFERENCES Servicios(IdServicio)
);

CREATE TABLE ReservacionEquipo(
    IdReservacionEquipo INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL,
    IdEquipo INT NOT NULL,

    Cantidad INT NOT NULL
        CHECK(Cantidad > 0),

    CONSTRAINT UQ_ReservacionEquipo_Reservacion_Equipo
        UNIQUE(IdReservacion, IdEquipo),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion),

    FOREIGN KEY(IdEquipo)
        REFERENCES Equipos(IdEquipo)
);

CREATE TABLE MetodosPago(
    IdMetodoPago INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE EstadosPago(
    IdEstadoPago INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Pagos(
    IdPago INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL,
    IdMetodoPago INT NOT NULL,
    IdEstadoPago INT NOT NULL,

    Monto DECIMAL(12,2) NOT NULL
        CHECK(Monto > 0),

    FechaPago DATETIME DEFAULT GETDATE(),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion),

    FOREIGN KEY(IdMetodoPago)
        REFERENCES MetodosPago(IdMetodoPago),

    FOREIGN KEY(IdEstadoPago)
        REFERENCES EstadosPago(IdEstadoPago)
);

CREATE TABLE Facturas(
    IdFactura INT IDENTITY(1,1) PRIMARY KEY,

    NumeroFactura VARCHAR(50) NOT NULL UNIQUE,

    IdReservacion INT NOT NULL,

    SubTotal DECIMAL(12,2) NOT NULL,
    Impuesto DECIMAL(12,2) NOT NULL,
    Total DECIMAL(12,2) NOT NULL,

    FechaFactura DATETIME DEFAULT GETDATE(),

    CONSTRAINT UQ_Facturas_IdReservacion
        UNIQUE(IdReservacion),
    CONSTRAINT CHK_Facturas_MontosValidos
        CHECK (
            SubTotal >= 0 AND
            Impuesto >= 0 AND
            Total >= 0 AND
            Total = SubTotal + Impuesto
        ),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion)
);

CREATE TABLE Contratos(
    IdContrato INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL UNIQUE,

    NumeroContrato VARCHAR(50) NOT NULL UNIQUE,

    FechaContrato DATETIME DEFAULT GETDATE(),

    RutaDocumento VARCHAR(500),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion)
);

CREATE TABLE Cancelaciones(
    IdCancelacion INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL,

    Motivo VARCHAR(300),

    FechaCancelacion DATETIME DEFAULT GETDATE(),

    CONSTRAINT UQ_Cancelaciones_IdReservacion
        UNIQUE(IdReservacion),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion)
);

CREATE TABLE EvidenciasReservacion(
    IdEvidencia INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL,

    NombreArchivo VARCHAR(255),
    RutaArchivo VARCHAR(500),

    FechaSubida DATETIME DEFAULT GETDATE(),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion)
);

CREATE TABLE HistorialReservacion(
    IdHistorial INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL,

    EstadoAnterior VARCHAR(50),
    EstadoNuevo VARCHAR(50),

    FechaCambio DATETIME DEFAULT GETDATE(),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion)
);

CREATE TABLE EncuestasSatisfaccion(
    IdEncuesta INT IDENTITY(1,1) PRIMARY KEY,

    IdReservacion INT NOT NULL,

    Calificacion INT
        CHECK(Calificacion BETWEEN 1 AND 5),

    Comentario VARCHAR(500),

    FechaEncuesta DATETIME DEFAULT GETDATE(),

    CONSTRAINT UQ_EncuestasSatisfaccion_IdReservacion
        UNIQUE(IdReservacion),

    FOREIGN KEY(IdReservacion)
        REFERENCES Reservaciones(IdReservacion)
);

CREATE TABLE Notificaciones(
    IdNotificacion INT IDENTITY(1,1) PRIMARY KEY,

    IdCliente INT NOT NULL,

    Mensaje VARCHAR(500),

    FechaEnvio DATETIME DEFAULT GETDATE(),

    FOREIGN KEY(IdCliente)
        REFERENCES Clientes(IdCliente)
);
