USE [20220804EX]
GO
/****** Object:  Table [dbo].[pacientes]    Script Date: 01/08/2022 16:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pacientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[pacientes] ON 

INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (1, N'Trey', N'Thebeau')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (2, N'Andre', N'Chesnut')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (3, N'Abram', N'Ravenscroftt')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (4, N'Aluino', N'Brazelton')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (5, N'Arda', N'Kindred')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (6, N'Martynne', N'Tipling')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (7, N'Jeri', N'Bigly')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (8, N'Farand', N'Stillwell')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (9, N'Lyssa', N'Symcox')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (10, N'Windy', N'Brownhill')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (11, N'Cam', N'Zaniolini')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (12, N'Elvina', N'Cherrington')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (13, N'Eugenia', N'Bulbrook')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (14, N'Holt', N'Persian')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (15, N'Aveline', N'Greswell')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (16, N'Ariella', N'Fonzo')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (17, N'Anica', N'McConaghy')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (18, N'Vern', N'MacMakin')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (19, N'Camellia', N'Townby')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (20, N'Hyacinthe', N'McCrohon')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (21, N'Cynthia', N'Prator')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (22, N'Burnard', N'Kershow')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (23, N'Farleigh', N'Divall')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (24, N'Wain', N'Kelwaybamber')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (25, N'Christabel', N'Endle')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (26, N'Terrance', N'Lanfranchi')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (27, N'Susette', N'Semeradova')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (28, N'Casi', N'Dominici')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (29, N'Robbie', N'Braham')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (30, N'Annabel', N'Stammers')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (31, N'Genvieve', N'Denyer')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (32, N'Delphinia', N'Raithmill')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (33, N'Seth', N'Raynes')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (34, N'Ursa', N'Marxsen')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (35, N'Benjy', N'Amdohr')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (36, N'Kattie', N'Syde')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (37, N'Christiana', N'Kastel')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (38, N'Pierette', N'Piers')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (39, N'Dene', N'Vicent')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (40, N'Clayborne', N'Planque')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (41, N'Nanette', N'Stearne')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (42, N'Paulita', N'Hollyer')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (43, N'Tore', N'Marden')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (44, N'Lindsey', N'Baudy')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (45, N'Imelda', N'Antosch')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (46, N'Obadiah', N'Nice')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (47, N'Lorain', N'Schimonek')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (48, N'Minnnie', N'Matuschek')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (49, N'Nancie', N'Jessup')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (50, N'Alanson', N'Reddin')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (51, N'Zorine', N'Northage')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (52, N'Kayla', N'Sagar')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (53, N'Nat', N'Chillingworth')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (54, N'Buddy', N'Longmire')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (55, N'Leonard', N'Villar')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (56, N'Lambert', N'Sackler')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (57, N'Tori', N'Brownlee')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (58, N'Garth', N'Benham')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (59, N'Fionnula', N'Northrop')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (60, N'Hector', N'Kembery')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (61, N'Roscoe', N'Crunkhurn')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (62, N'Anatola', N'Mila')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (63, N'Ansell', N'Bellie')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (64, N'Dot', N'Lehmann')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (65, N'Dorian', N'Pardew')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (66, N'Gonzalo', N'Fullwood')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (67, N'Alix', N'Melendez')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (68, N'Cassy', N'Trayes')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (69, N'Loise', N'Halfhide')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (70, N'Bord', N'Goburn')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (71, N'Maura', N'Lindelof')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (72, N'Farica', N'Files')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (73, N'Colet', N'Grain')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (74, N'Alphard', N'Orknay')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (75, N'Greg', N'Geffe')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (76, N'Ferdinand', N'Majury')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (77, N'Reena', N'Devennie')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (78, N'Aggie', N'Goathrop')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (79, N'Bartlet', N'Huggens')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (80, N'Tatiania', N'Tolcher')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (81, N'Alfons', N'de Merida')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (82, N'Silvano', N'Puckett')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (83, N'Grier', N'Shelford')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (84, N'Amos', N'Burbudge')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (85, N'Carly', N'Kann')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (86, N'Leontyne', N'Sallings')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (87, N'Elfie', N'Bendix')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (88, N'Isabeau', N'Craze')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (89, N'Wileen', N'Witherden')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (90, N'Rabbi', N'Coldridge')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (91, N'Minnnie', N'Burnep')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (92, N'Dell', N'Shiers')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (93, N'Arch', N'Fomichkin')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (94, N'Worthy', N'Riha')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (95, N'Samuele', N'Junkinson')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (96, N'Hermione', N'McAloren')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (97, N'Clayson', N'Coate')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (98, N'Forrest', N'Petrus')
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (99, N'Heinrick', N'Daouse')
GO
INSERT [dbo].[pacientes] ([id], [nombre], [apellido]) VALUES (100, N'Grady', N'Bartell')
SET IDENTITY_INSERT [dbo].[pacientes] OFF
GO
