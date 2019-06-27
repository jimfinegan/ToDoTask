﻿USE [master]
GO

/****** Object:  Database [ToDoTasks]    Script Date: 27/06/2019 20:28:39 ******/
CREATE DATABASE [ToDoTasks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToDoTasks', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LOCAL\MSSQL\DATA\ToDoTasks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToDoTasks_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LOCAL\MSSQL\DATA\ToDoTasks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [ToDoTasks] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToDoTasks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ToDoTasks] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ToDoTasks] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ToDoTasks] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ToDoTasks] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ToDoTasks] SET ARITHABORT OFF 
GO

ALTER DATABASE [ToDoTasks] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ToDoTasks] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ToDoTasks] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ToDoTasks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ToDoTasks] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ToDoTasks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ToDoTasks] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ToDoTasks] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ToDoTasks] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ToDoTasks] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ToDoTasks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ToDoTasks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ToDoTasks] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ToDoTasks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ToDoTasks] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ToDoTasks] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ToDoTasks] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ToDoTasks] SET RECOVERY FULL 
GO

ALTER DATABASE [ToDoTasks] SET  MULTI_USER 
GO

ALTER DATABASE [ToDoTasks] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ToDoTasks] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ToDoTasks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ToDoTasks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ToDoTasks] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ToDoTasks] SET QUERY_STORE = OFF
GO

USE [ToDoTasks]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [ToDoTasks] SET  READ_WRITE 
GO

USE [ToDoTasks]
GO

/****** Object:  Table [dbo].[ToDoTasks]    Script Date: 27/06/2019 20:29:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ToDoTasks](
	[ToDoTaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskUserId] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[TaskDescription] [nvarchar](100) NULL,
	[CheckedDone] [bit] NULL,
 CONSTRAINT [PK_DoToTasks] PRIMARY KEY CLUSTERED 
(
	[ToDoTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ToDoTasks] ADD  CONSTRAINT [DF_DoToTasks_CheckedDone]  DEFAULT ((0)) FOR [CheckedDone]
GO


USE [ToDoTasks]
GO

/****** Object:  Table [dbo].[TaskUsers]    Script Date: 27/06/2019 20:29:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaskUsers](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaskUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



