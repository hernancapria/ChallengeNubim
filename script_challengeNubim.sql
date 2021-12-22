USE [master]
GO

/****** Object:  Database [ChallengeNubim]    Script Date: 21/12/2021 16:07:03 ******/
CREATE DATABASE [ChallengeNubim]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChallengeNubim', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChallengeNubim.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChallengeNubim_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChallengeNubim_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChallengeNubim].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ChallengeNubim] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ChallengeNubim] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ChallengeNubim] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ChallengeNubim] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ChallengeNubim] SET ARITHABORT OFF 
GO

ALTER DATABASE [ChallengeNubim] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ChallengeNubim] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ChallengeNubim] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ChallengeNubim] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ChallengeNubim] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ChallengeNubim] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ChallengeNubim] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ChallengeNubim] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ChallengeNubim] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ChallengeNubim] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ChallengeNubim] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ChallengeNubim] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ChallengeNubim] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ChallengeNubim] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ChallengeNubim] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ChallengeNubim] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ChallengeNubim] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ChallengeNubim] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ChallengeNubim] SET  MULTI_USER 
GO

ALTER DATABASE [ChallengeNubim] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ChallengeNubim] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ChallengeNubim] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ChallengeNubim] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ChallengeNubim] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ChallengeNubim] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ChallengeNubim] SET  READ_WRITE 
GO


USE [ChallengeNubim]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21/12/2021 17:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


use ChallengeNubim
go

delete from [User];

insert into [User] (nombre, apellido, email, password)
values ('Amalia', 'Bissi', 'amaliabissi@gmail.com', '1234');

insert into [User] (nombre, apellido, email, password)
values ('Hernan', 'Capria', 'hernancapria@gmail.com', 'clave231');

insert into [User] (nombre, apellido, email, password)
values ('Roman', 'Luna', 'lunaroman@gmail.com', 'password1000');