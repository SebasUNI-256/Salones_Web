# SaloNic

Proyecto base para la reservacion de salones con arquitectura limpia, ASP.NET MVC, ADO.NET y SQL Server.

## Stack

- .NET 10
- ASP.NET Core MVC
- SQL Server
- ADO.NET

## Estructura

- `SaloNic.Web`: capa de presentacion
- `SaloNic.Application`: capa de aplicacion y contratos
- `SaloNic.Domain`: entidades del dominio
- `SaloNic.Infrastructure`: acceso a datos e infraestructura
- `BD`: script SQL de la base de datos

## Estado actual

- Solucion base en 4 capas
- Entidades con data annotations
- Landing page inicial para la pantalla de inicio
- Script SQL con restricciones principales

## Ejecucion local

1. Restaurar dependencias:

```powershell
dotnet restore .\SaloNic.slnx
```

2. Ejecutar el proyecto web:

```powershell
dotnet run --project .\SaloNic.Web\SaloNic.Web.csproj --launch-profile http
```

3. Abrir en el navegador:

`http://localhost:5213`

## Base de datos

La cadena de conexion actual esta en [SaloNic.Web/appsettings.json](C:/Users/PC/Desktop/Reservacion_Salones/SaloNic.Web/appsettings.json) y apunta a:

`BD_ReservacionesSalones`

El script de base de datos se encuentra en [BD/Reservaciones.sql](C:/Users/PC/Desktop/Reservacion_Salones/BD/Reservaciones.sql).

## Notas

Por ahora el proyecto esta enfocado en la estructura inicial y el diseno de la landing page. La logica de negocio y los flujos completos de reservacion se iran incorporando despues.
