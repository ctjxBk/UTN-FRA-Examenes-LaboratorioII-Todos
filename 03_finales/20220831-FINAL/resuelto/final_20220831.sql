CREATE DATABASE [final_20220831]
GO
USE [final_20220831]
GO
/****** Object:  Table [dbo].[Autos]    Script Date: 02/09/2022 20:51:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[presion] [int] NOT NULL,
	[patente] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
