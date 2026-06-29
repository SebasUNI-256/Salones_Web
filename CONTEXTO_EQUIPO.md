# CONTEXTO DEL EQUIPO - SALONIC

## Objetivo del proyecto

Construir un sistema de reservacion de salones sobre ASP.NET Core MVC, ADO.NET y SQL Server, manteniendo separadas las capas de presentacion, aplicacion, dominio e infraestructura.

## Estado real del repositorio

Actualmente el proyecto ya no esta solo en fase de estructura inicial.

Lo que ya existe en el repo:

- Solucion en 4 capas: `Web`, `Application`, `Domain`, `Infrastructure`
- Script SQL principal en `BD/Reservaciones.sql`
- Entidades de dominio para el modelo base
- DTOs, interfaces y services en `SaloNic.Application`
- Conexion SQL y repositorios ADO.NET iniciales en `SaloNic.Infrastructure`
- Landing page inicial en `SaloNic.Web`

Lo que todavia no esta completo:

- No todos los repositorios de `Application` tienen implementacion concreta en `Infrastructure`
- No estan cerrados todos los flujos end-to-end desde vista hasta base de datos
- La capa web sigue principalmente en estado base
- Todavia falta aterrizar procedimientos almacenados, validaciones y casos de uso completos

## Alcance realista por rama

### `feature/bd-modelo`

Responsable de:

- Tablas, relaciones, restricciones y normalizacion
- Catalogos, llaves foraneas y consistencia del esquema
- Procedimientos almacenados, vistas o scripts SQL que el sistema necesite
- Ajustes del archivo `BD/Reservaciones.sql`

No deberia asumir como terminado:

- La logica web
- El cableado de servicios o controladores

### `feature/application-contratos`

Responsable de:

- DTOs de entrada y salida
- Interfaces de repositorio
- Services de aplicacion
- Contratos entre `Web` e `Infrastructure`

Estado actual real:

- Esta rama o area ya va adelantada en cantidad de archivos
- Hay muchos contratos creados, pero varios todavia dependen de repositorios no implementados

### `feature/infrastructure-ado`

Responsable de:

- Conexion a SQL Server
- Repositorios ADO.NET
- Ejecucion de procedimientos almacenados
- Mapeo de resultados de BD hacia entidades
- Registro en DI de repositorios e infraestructura

Estado actual real:

- Ya existe `DBConnectionFactory`
- Ya hay repositorios iniciales implementados
- Falta completar el resto de repositorios para acompanar los contratos ya creados en `Application`

### `feature/web-mvc`

Responsable de:

- Controladores
- Vistas Razor
- Formularios
- Flujo visual y validaciones del lado MVC
- Consumo de services de `Application`

Estado actual real:

- La parte web todavia esta bastante base
- El siguiente avance realista es conectar vistas y controladores con casos de uso que ya existan de verdad

## Orden recomendado de trabajo

Para evitar trabajo fantasma o codigo que no conecta con nada, el orden mas realista es este:

1. Definir o ajustar el modelo SQL y los procedimientos necesarios.
2. Confirmar los contratos de `Application` para esos casos de uso.
3. Implementar los repositorios reales en `Infrastructure`.
4. Conectar la capa `Web` solo cuando el flujo backend ya exista.

## Riesgo actual del proyecto

El principal riesgo ahora no es la estructura, sino la desalineacion entre capas:

- `Application` ya tiene mucho contrato creado.
- `Infrastructure` aun no cubre todo ese contrato.
- `Web` todavia no representa todos los flujos reales del sistema.

Eso significa que el proyecto se puede ver mas avanzado de lo que realmente esta si uno solo mira la cantidad de archivos.

## Conclusion

El alcance del equipo sigue siendo valido como division general por capas, pero ya no es realista describir el proyecto como solo una base inicial.

La descripcion honesta hoy es:

- La arquitectura ya esta armada.
- La base de datos ya tiene una estructura importante.
- `Application` avanzo bastante en contratos.
- `Infrastructure` va en progreso.
- `Web` aun esta en etapa inicial de integracion funcional.
