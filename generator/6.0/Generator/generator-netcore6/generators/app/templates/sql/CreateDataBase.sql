USE [master]
GO

/****** Object:  Database [Temporal]    Script Date: 24/04/2023 03:40:29 p. m. ******/
CREATE DATABASE [Temporal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Temporal', FILENAME = N'/var/opt/mssql/data/Temporal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Temporal_log', FILENAME = N'/var/opt/mssql/data/Temporal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Temporal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Temporal] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Temporal] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Temporal] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Temporal] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Temporal] SET ARITHABORT OFF 
GO

ALTER DATABASE [Temporal] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Temporal] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Temporal] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Temporal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Temporal] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Temporal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Temporal] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Temporal] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Temporal] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Temporal] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Temporal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Temporal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Temporal] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Temporal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Temporal] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Temporal] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Temporal] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Temporal] SET RECOVERY FULL 
GO

ALTER DATABASE [Temporal] SET  MULTI_USER 
GO

ALTER DATABASE [Temporal] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Temporal] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Temporal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Temporal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Temporal] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Temporal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Temporal] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Temporal] SET  READ_WRITE 
GO


