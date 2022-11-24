# Prueba_AFEX
Prueba realizada con la version de .NET 6.0  

## Requerimientos
Ejecución del siguiente script SQL en una base de datos SQL Server:
```sql
CREATE DATABASE [PruebaAFEX]
GO
USE [PruebaAFEX]
GO
CREATE TABLE [dbo].[videos](
	[VideoId] [int] IDENTITY(1,1) NOT NULL,
	[VideoURL] [nvarchar](150) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Titulo] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[ImagenAlbum] [nvarchar](150) NOT NULL,
	[FechaVideo] [datetime] NOT NULL,
	[Duracion] [datetime] NOT NULL,
	[Estado] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_videos] PRIMARY KEY ([VideoId] ASC)
)
```
Configurar la cadena de conexion en el archivo appsettings.json del proyecto WebAppplication1
![appsettings.json](/capturas/captura1.png "appsettings.json")

## Funcionamiento
Ejecutar localmente primero el proyecto WebApplication1
