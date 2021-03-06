USE [master]
GO
/****** Object:  Database [eCademiaAppDB]    Script Date: 16.01.2022 16:25:47 ******/
CREATE DATABASE [eCademiaAppDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eCademiaAppDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eCademiaAppDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eCademiaAppDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eCademiaAppDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [eCademiaAppDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eCademiaAppDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eCademiaAppDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eCademiaAppDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eCademiaAppDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eCademiaAppDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eCademiaAppDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eCademiaAppDB] SET  MULTI_USER 
GO
ALTER DATABASE [eCademiaAppDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eCademiaAppDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eCademiaAppDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eCademiaAppDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eCademiaAppDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eCademiaAppDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [eCademiaAppDB] SET QUERY_STORE = OFF
GO
USE [eCademiaAppDB]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 16.01.2022 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[SalePrice] [decimal](10, 2) NULL,
	[Description] [text] NOT NULL,
	[Point] [float] NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[TypeId] [int] NULL,
	[InstructorId] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 16.01.2022 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 16.01.2022 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.01.2022 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [Price], [SalePrice], [Description], [Point], [CreationDate], [UpdateDate], [TypeId], [InstructorId]) VALUES (1, N'Deneme', CAST(12.20 AS Decimal(10, 2)), CAST(10.55 AS Decimal(10, 2)), N'Denem 123', 3.5, CAST(N'1968-10-23T05:45:37.123' AS DateTime), CAST(N'1968-10-23T05:45:37.123' AS DateTime), 1, 3)
INSERT [dbo].[Courses] ([Id], [Name], [Price], [SalePrice], [Description], [Point], [CreationDate], [UpdateDate], [TypeId], [InstructorId]) VALUES (2, N'Deneme2', CAST(25000.50 AS Decimal(10, 2)), CAST(2250.86 AS Decimal(10, 2)), N'Deneme 123123', 1.5, CAST(N'2022-01-15T16:08:18.177' AS DateTime), CAST(N'2022-01-15T16:08:18.177' AS DateTime), 1, 1)
INSERT [dbo].[Courses] ([Id], [Name], [Price], [SalePrice], [Description], [Point], [CreationDate], [UpdateDate], [TypeId], [InstructorId]) VALUES (5, N'string', CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), N'string', 0, CAST(N'2022-01-15T19:42:42.577' AS DateTime), CAST(N'2022-01-15T19:42:42.577' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'moderator')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'instructor')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (4, N'user')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (5, N'course.add')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (6, N'course.delete')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (7, N'course.update')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (8, N'course.view')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (9, N'user.delete')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (10, N'user.update')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (11, N'user.view')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (13, N'customer.update')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (14, N'customer.delete')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (15, N'customer.view')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
USE [master]
GO
ALTER DATABASE [eCademiaAppDB] SET  READ_WRITE 
GO
