USE [master]
GO
/****** Object:  Database [WordDB]    Script Date: 6/17/2022 1:13:10 AM ******/
CREATE DATABASE [WordDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WordDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WordDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WordDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WordDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WordDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WordDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WordDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WordDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WordDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WordDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WordDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WordDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WordDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WordDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WordDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WordDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WordDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WordDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WordDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WordDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WordDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WordDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WordDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WordDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WordDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WordDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WordDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WordDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WordDB] SET RECOVERY FULL 
GO
ALTER DATABASE [WordDB] SET  MULTI_USER 
GO
ALTER DATABASE [WordDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WordDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WordDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WordDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WordDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WordDB', N'ON'
GO
ALTER DATABASE [WordDB] SET QUERY_STORE = OFF
GO
USE [WordDB]
GO
/****** Object:  Table [dbo].[Word]    Script Date: 6/17/2022 1:13:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lines] [int] NULL,
	[Words] [nvarchar](max) NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Word] ON 
GO
INSERT [dbo].[Word] ([Id], [Lines], [Words]) VALUES (2, 9, N'I love football. I also love to play cricket sometimes too.')
GO
INSERT [dbo].[Word] ([Id], [Lines], [Words]) VALUES (3, 7, N'Humty dumty hump. Dummy tummy empty tummy.')
GO
SET IDENTITY_INSERT [dbo].[Word] OFF
GO
USE [master]
GO
ALTER DATABASE [WordDB] SET  READ_WRITE 
GO