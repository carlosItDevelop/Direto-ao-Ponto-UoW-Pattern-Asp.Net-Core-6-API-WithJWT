IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pessoa]') AND type in (N'U'))
ALTER TABLE [dbo].[Pessoa] DROP CONSTRAINT IF EXISTS [FK_Pessoa_Voo_VooId]
GO
/****** Object:  Table [dbo].[Voo]    Script Date: 02/01/2022 16:11:15 ******/
DROP TABLE IF EXISTS [dbo].[Voo]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 02/01/2022 16:11:15 ******/
DROP TABLE IF EXISTS [dbo].[Pessoa]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/01/2022 16:11:15 ******/
DROP TABLE IF EXISTS [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/01/2022 16:11:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 02/01/2022 16:11:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[VooId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voo]    Script Date: 02/01/2022 16:11:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voo](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [varchar](40) NOT NULL,
	[Capacidade] [int] NOT NULL,
	[Disponibilidade] [int] NOT NULL,
	[Nota] [varchar](100) NULL,
 CONSTRAINT [PK_Voo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pessoa]  WITH CHECK ADD  CONSTRAINT [FK_Pessoa_Voo_VooId] FOREIGN KEY([VooId])
REFERENCES [dbo].[Voo] ([Id])
GO
ALTER TABLE [dbo].[Pessoa] CHECK CONSTRAINT [FK_Pessoa_Voo_VooId]
GO
