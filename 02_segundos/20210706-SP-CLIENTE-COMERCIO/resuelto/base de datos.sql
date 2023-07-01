USE [master]
GO

/****** Object:  Database [20210706-SP]    Script Date: 25/06/2021 16:07:06 ******/
CREATE DATABASE [20210706-SP]
GO
USE [20210706-SP]
GO

/****** Object:  Table [dbo].[atenciones]    Script Date: 25/06/2021 16:07:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[atenciones](
	[atendidos] [int] NOT NULL,
	[noAtendidos] [int] NOT NULL,
	[alumno] [varbinary](50) NOT NULL
) ON [PRIMARY]
GO