USE [StudentskaSluzba]
GO
/****** Object:  Table [dbo].[Ispit]    Script Date: 5/24/2023 1:48:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ispit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vreme] [date] NOT NULL,
	[idPredmet] [int] NOT NULL,
	[idStudent] [int] NOT NULL,
	[polozen] [smallint] NOT NULL,
 CONSTRAINT [PK_Ispit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predmet]    Script Date: 5/24/2023 1:48:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predmet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NOT NULL,
	[katedra] [varchar](50) NOT NULL,
	[profesor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Predmet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/24/2023 1:48:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[prezime] [varchar](50) NOT NULL,
	[smer] [varchar](50) NOT NULL,
	[brojIndexa] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ispit]  WITH CHECK ADD  CONSTRAINT [FK_Ispit_Predmet] FOREIGN KEY([idPredmet])
REFERENCES [dbo].[Predmet] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ispit] CHECK CONSTRAINT [FK_Ispit_Predmet]
GO
ALTER TABLE [dbo].[Ispit]  WITH CHECK ADD  CONSTRAINT [FK_Ispit_Student] FOREIGN KEY([idStudent])
REFERENCES [dbo].[Student] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ispit] CHECK CONSTRAINT [FK_Ispit_Student]
GO
