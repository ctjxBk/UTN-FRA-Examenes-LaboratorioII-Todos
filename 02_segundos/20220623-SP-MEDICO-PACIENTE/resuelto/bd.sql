USE [master]
GO
/****** Object:  Database [202206-medico-paciente]    Script Date: 11/06/2022 23:42:11 ******/
CREATE DATABASE [202206-medico-paciente]
 CONTAINMENT = NONE
ALTER DATABASE [202206-medico-paciente] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [202206-medico-paciente].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [202206-medico-paciente] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET ARITHABORT OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [202206-medico-paciente] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [202206-medico-paciente] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET  DISABLE_BROKER 
GO
ALTER DATABASE [202206-medico-paciente] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [202206-medico-paciente] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [202206-medico-paciente] SET  MULTI_USER 
GO
ALTER DATABASE [202206-medico-paciente] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [202206-medico-paciente] SET DB_CHAINING OFF 
GO
ALTER DATABASE [202206-medico-paciente] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [202206-medico-paciente] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [202206-medico-paciente] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [202206-medico-paciente] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [202206-medico-paciente] SET QUERY_STORE = OFF
GO
USE [202206-medico-paciente]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 11/06/2022 23:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [nchar](10) NOT NULL,
	[nacimiento] [date] NOT NULL,
	[barrioResidencia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalMedico]    Script Date: 11/06/2022 23:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalMedico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nacimiento] [date] NOT NULL,
	[esRecidente] [bit] NOT NULL,
 CONSTRAINT [PK_PersonalMedico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON 
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (1, N'Hugo Benjamín', N'Ibarra    ', CAST(N'1974-04-01' AS Date), N'La Boca')
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (2, N'Jorge Hernán', N'Bermudez  ', CAST(N'1971-06-18' AS Date), N'Cali')
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (3, N'Mauricio Alberto', N'Serna     ', CAST(N'1968-01-22' AS Date), N'Medellín')
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (4, N'Cristian Alberto', N'Traverso  ', CAST(N'1972-04-17' AS Date), N'Tigre')
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (6, N'Sebastián Alejandro', N'Battaglia ', CAST(N'1980-11-08' AS Date), N'San Fernando')
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (7, N'José Horacio', N'Basualdo  ', CAST(N'1963-06-20' AS Date), N'Campana')
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (8, N'Marcelo Alejandro', N'Delgado   ', CAST(N'1973-03-24' AS Date), N'Avellaneda')
GO
INSERT [dbo].[Pacientes] ([id], [nombre], [apellido], [nacimiento], [barrioResidencia]) VALUES (9, N'Nicolás Andrés', N'Burdisso  ', CAST(N'1981-04-12' AS Date), N'Altos de Chipión')
GO
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalMedico] ON 
GO
INSERT [dbo].[PersonalMedico] ([id], [nombre], [apellido], [nacimiento], [esRecidente]) VALUES (1, N'Martín', N'Palermo', CAST(N'1973-11-07' AS Date), 0)
GO
INSERT [dbo].[PersonalMedico] ([id], [nombre], [apellido], [nacimiento], [esRecidente]) VALUES (2, N'Guillermo', N'Barros Schelotto', CAST(N'1973-05-04' AS Date), 0)
GO
INSERT [dbo].[PersonalMedico] ([id], [nombre], [apellido], [nacimiento], [esRecidente]) VALUES (3, N'Juan Román', N'Riquelme', CAST(N'1978-06-24' AS Date), 0)
GO
INSERT [dbo].[PersonalMedico] ([id], [nombre], [apellido], [nacimiento], [esRecidente]) VALUES (4, N'Anibal Samuel', N'Matellán', CAST(N'1977-05-08' AS Date), 1)
GO
INSERT [dbo].[PersonalMedico] ([id], [nombre], [apellido], [nacimiento], [esRecidente]) VALUES (5, N'Óscar Eduardo', N'Córdoba', CAST(N'1970-02-03' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[PersonalMedico] OFF
GO
USE [master]
GO
ALTER DATABASE [202206-medico-paciente] SET  READ_WRITE 
GO
