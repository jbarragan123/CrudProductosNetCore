# Crud Productos en .NET Core MVC

Este proyecto es una aplicación CRUD de productos desarrollada con ASP.NET Core MVC.

## Funcionalidades

- Crear, leer, actualizar y eliminar productos.
- Validaciones en frontend y backend.
- API REST para operaciones con productos.
- Uso de Entity Framework Core con SQL Server.

## Cómo ejecutar

1. Clona el repositorio:

 - git clone https://github.com/jbarragan123/CrudProductosNetCore

1.1 Ejecutar archivo de base de datos (se encuentra en esta misma ruta readme), existe un archivo llamado productos.sql que contiene ya información 
quemada para esta crud, ejecuta paso por paso tanto la creación de la bd, tabla e inserts, sugiero hacero con sql server management studio

2. Abre el proyecto en Visual Studio o VS Code.

3. Asegúrate de tener configurado tu `appsettings.json` con la cadena de conexión

4. Ejecuta con: el botón ejecutar de visual studio o en consola en la raiz del proyecto escribe: dotnet run 

## Como utilizar el api y consumirlo

1. En la raiz de este proyecto, en esta misma ubicación de readme existe un archivo postman llamado Crud_productos.postman_colection.json
2. Descargarlo y ejecutar este proyecto
3. Importarlo como nueva colección postman, ya incluyen ejemplos del api y funcionamiento para su uso directo

## Autor

Juan Barragán – abril 2025