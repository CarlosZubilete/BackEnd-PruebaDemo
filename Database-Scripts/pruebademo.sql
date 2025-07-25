USE master
CREATE DATABASE [pruebademo]
ON (
	NAME = 'pruebademo',
	FILENAME = 'D:\BASE-DATOS\PRUEBA-DEMO-DB\pruebademo.mdf', -- Master Data File.
	SIZE = 10MB, 
	MAXSIZE = 50MB,
	FILEGROWTH = 5MB
)
LOG ON (
	NAME = 'pruebademo_log', -- extension _log 
	FILENAME = 'D:\BASE-DATOS\PRUEBA-DEMO-DB\pruebademo.ldf', -- Log Data File.
	SIZE = 5MB,
	MAXSIZE = 25MB,
	FILEGROWTH = 2MB 
);
GO

USE [pruebademo]

GO
/****** Object:  Table [dbo].[ventasitems]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventasitems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDVenta] [int] NOT NULL,
	[IDProducto] [int] NOT NULL,
	[PrecioUnitario] [float] NULL,
	[Cantidad] [float] NULL,
	[PrecioTotal] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Total] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[productos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Precio] [float] NULL,
	[Categoria] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](255) NOT NULL,
	[Telefono] [varchar](255) NULL,
	[Correo] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

-- 1. ventasitems.IDVenta -> ventas.ID
ALTER TABLE [dbo].[ventasitems]
ADD CONSTRAINT FK_ventasitems_ventas
FOREIGN KEY ([IDVenta]) REFERENCES [dbo].[ventas]([ID]);

-- 2. ventasitems.IDProducto -> productos.ID
ALTER TABLE [dbo].[ventasitems]
ADD CONSTRAINT FK_ventasitems_productos
FOREIGN KEY ([IDProducto]) REFERENCES [dbo].[productos]([ID]);

-- 3. ventas.IDCliente -> clientes.ID
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT FK_ventas_clientes
FOREIGN KEY ([IDCliente]) REFERENCES [dbo].[clientes]([ID]);
