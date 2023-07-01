CREATE DATABASE COMBATE_DB
GO

USE [COMBATE_DB]
GO

CREATE TABLE [dbo].[PERSONAJES](
    [id] [int] NOT NULL,
    [nombre] [varchar](150) NOT NULL,
    [nivel] [smallint] NOT NULL,
    [clase] [smallint] NOT NULL,
    [titulo] [varchar](500) NULL,
 CONSTRAINT [PK_PERSONAJES] PRIMARY KEY CLUSTERED 
(
    [id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[PERSONAJES]
           ([id]
           ,[nombre]
           ,[nivel]
           ,[clase]
           ,[titulo])
     VALUES
           (1
           ,'Falcorn'
           ,1
           ,1
           ,'Defender of the Alliance');

INSERT INTO [dbo].[PERSONAJES]
           ([id]
           ,[nombre]
           ,[nivel]
           ,[clase]
           ,[titulo])
     VALUES
           (2
           ,'NWBZPWNR'
           ,1
           ,2
           ,null);

GO