# Contexto del proyecto SaloNic

Este documento explica la idea del proyecto y como debe dividirse el trabajo. La intencion es que todos trabajen con el mismo criterio y no mezclen responsabilidades entre capas.

## Objetivo del sistema

SaloNic es un sistema web para reservacion de salones de eventos.

El cliente podra registrarse, iniciar sesion, ver salones disponibles, solicitar reservaciones y consultar sus propias reservaciones.

El personal interno podra gestionar reservaciones. En especial, la recepcionista podra aceptar, rechazar, reprogramar o cancelar reservaciones sin borrarlas. El administrador tendra permisos mas amplios para gestionar usuarios internos, salones, catalogos y reportes.

## Tecnologia base

- .NET 10
- ASP.NET Core MVC
- SQL Server
- ADO.NET
- Arquitectura en 4 capas

## Capas del proyecto

### SaloNic.Domain

Contiene las entidades principales del sistema.

Aqui van clases como:

- `Usuario`
- `Rol`
- `Cliente`
- `Empleado`
- `Salon`
- `Reservacion`
- `EstadoReservacion`

Regla: esta capa no debe tener SQL, vistas MVC, controladores ni acceso directo a base de datos.

### SaloNic.Application

Contiene los contratos y la logica de aplicacion.

Aqui iran:

- DTOs
- interfaces
- casos de uso
- validaciones de flujo

Ejemplos futuros:

- `LoginRequest`
- `ClienteDto`
- `CrearReservacionRequest`
- `IReservacionRepository`
- `IClienteRepository`
- `IAuthService`

Regla: esta capa no debe implementar ADO.NET ni consultar SQL directamente. Solo define lo que se necesita hacer.

### SaloNic.Infrastructure

Contiene la implementacion tecnica.

Aqui iran:

- repositorios con ADO.NET
- consultas SQL desde C#
- conexion a SQL Server
- implementacion de bcrypt para contrasenas

Regla: esta capa implementa las interfaces definidas en `Application`.

### SaloNic.Web

Contiene la aplicacion MVC.

Aqui van:

- controladores
- vistas
- modelos de vista si hacen falta
- estilos
- flujo visual del cliente, recepcionista y administrador

Regla: esta capa no debe tener SQL directo. Debe consumir servicios o casos de uso de `Application`.

## Modelo de usuarios

El sistema usara `Usuarios` como tabla central para iniciar sesion.

Cada usuario tendra un rol:

- `Administrador`
- `Recepcionista`
- `Cliente`

Los clientes tendran datos adicionales en `Clientes`.

Los usuarios internos, como administrador y recepcionista, tendran datos adicionales en `Empleados`.

Las contrasenas no se guardaran en texto plano. La columna correcta es `ClaveHash`, pensada para almacenar el hash con bcrypt.

## Flujo del cliente

El cliente debe poder:

- entrar a la pagina
- registrarse
- iniciar sesion
- ver catalogo de salones
- solicitar una reservacion
- ver sus reservaciones
- actualizar su perfil

Una reservacion creada por el cliente debe iniciar como `Pendiente`.

## Flujo de recepcionista

La recepcionista debe poder:

- ver reservaciones pendientes
- aceptar reservaciones
- rechazar reservaciones
- crear reservaciones para clientes presenciales
- cambiar fecha y hora de una reservacion
- cancelar reservaciones sin borrarlas
- consultar calendario de ocupacion
- agregar observaciones o seguimiento

La recepcionista no debe borrar reservaciones. Solo cambia estados y registra historial.

## Flujo de administrador

El administrador debe poder hacer todo lo de recepcionista y ademas:

- gestionar empleados
- gestionar usuarios internos
- gestionar salones
- gestionar sedes
- gestionar tipos de salon
- gestionar tipos de evento
- gestionar servicios y equipos
- revisar bitacora
- ver reportes

## Estados de reservacion

Estados base:

- `Pendiente`
- `Aprobada`
- `Rechazada`
- `Cancelada`
- `Finalizada`

Regla importante: una reservacion no se elimina. Si ya no aplica, se cambia a `Cancelada` y se registra el motivo.

## Ramas de trabajo

Cada integrante debe trabajar en su rama correspondiente.

### Base de datos

Rama:

```powershell
git switch feature/bd-modelo
```

Responsabilidad:

- `BD/Reservaciones.sql`
- constraints
- relaciones
- datos semilla
- coherencia entre tablas

No debe tocar vistas MVC ni repositorios sin coordinarlo.

### Application

Rama:

```powershell
git switch feature/application-contratos
```

Responsabilidad:

- DTOs
- interfaces
- contratos
- estructura de casos de uso

No debe implementar SQL ni ADO.NET.

### Infrastructure

Rama:

```powershell
git switch feature/infrastructure-ado
```

Responsabilidad:

- ADO.NET
- repositorios
- consultas SQL desde C#
- implementacion de bcrypt
- conexion con SQL Server

Debe respetar las interfaces definidas por `Application`.

### Web MVC

Rama:

```powershell
git switch feature/web-mvc
```

Responsabilidad:

- controladores
- vistas
- landing page
- pantallas cliente
- pantallas recepcionista
- pantallas administrador
- estilos

No debe consultar SQL directamente.

## Reglas de trabajo en Git

Antes de empezar:

```powershell
git fetch
git switch nombre-de-la-rama
git pull
```

Antes de subir cambios:

```powershell
dotnet build .\SaloNic.slnx --no-restore
git status --short
git add .
git commit -m "Mensaje descriptivo en espanol"
git push
```

No trabajar directo sobre `main`.

No mezclar cambios de varias capas en un mismo commit si no es necesario.

## Convenciones

- Commits en espanol.
- Nombres claros.
- No guardar contrasenas en texto plano.
- No borrar reservaciones.
- No meter SQL en controladores.
- No modificar la capa de otro integrante sin avisar.
- Si una capa necesita algo de otra, se define primero el contrato.

## Estado actual del proyecto

Ya existe:

- solucion base en 4 capas
- landing page inicial
- script SQL principal
- entidades base de dominio
- modelo inicial de usuarios, clientes, empleados y reservaciones
- ramas de trabajo publicadas en GitHub

Falta implementar:

- DTOs y contratos de `Application`
- repositorios ADO.NET en `Infrastructure`
- autenticacion real
- pantallas internas de cliente, recepcionista y administrador
- logica de reservaciones
- validaciones completas de disponibilidad
