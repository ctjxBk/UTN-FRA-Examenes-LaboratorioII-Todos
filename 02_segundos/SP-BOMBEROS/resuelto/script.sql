USE [bomberos-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log](
[id] [int] IDENTITY(1,1) NOT NULL,
[entrada] [varchar](100) NOT NULL,
[alumno] [varchar](60) NOT NULL
) ON [PRIMARY]
GO