USE [master]
GO

/****** Object:  Database [MySPADb]    Script Date: 10/10/2022 6:39:58 PM ******/
CREATE DATABASE [MySPADb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MySPADb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MySPADb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MySPADb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MySPADb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MySPADb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MySPADb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MySPADb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MySPADb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MySPADb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MySPADb] SET ARITHABORT OFF 
GO

ALTER DATABASE [MySPADb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MySPADb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MySPADb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MySPADb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MySPADb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MySPADb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MySPADb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MySPADb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MySPADb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MySPADb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MySPADb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MySPADb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MySPADb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MySPADb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MySPADb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MySPADb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MySPADb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MySPADb] SET RECOVERY FULL 
GO

ALTER DATABASE [MySPADb] SET  MULTI_USER 
GO

ALTER DATABASE [MySPADb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MySPADb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MySPADb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MySPADb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MySPADb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MySPADb] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MySPADb] SET  READ_WRITE 
GO
