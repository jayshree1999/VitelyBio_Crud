USE [master]
GO
/****** Object:  Database [Vitely_CrudPractical]    Script Date: 23-02-2024 15:50:49 ******/
CREATE DATABASE [Vitely_CrudPractical]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vitely_CrudPractical', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Vitely_CrudPractical.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vitely_CrudPractical_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Vitely_CrudPractical_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Vitely_CrudPractical] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vitely_CrudPractical].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vitely_CrudPractical] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vitely_CrudPractical] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vitely_CrudPractical] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Vitely_CrudPractical] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vitely_CrudPractical] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET RECOVERY FULL 
GO
ALTER DATABASE [Vitely_CrudPractical] SET  MULTI_USER 
GO
ALTER DATABASE [Vitely_CrudPractical] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vitely_CrudPractical] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vitely_CrudPractical] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vitely_CrudPractical] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Vitely_CrudPractical] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Vitely_CrudPractical] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Vitely_CrudPractical', N'ON'
GO
ALTER DATABASE [Vitely_CrudPractical] SET QUERY_STORE = OFF
GO
USE [Vitely_CrudPractical]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 23-02-2024 15:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 23-02-2024 15:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Salary] [decimal](18, 0) NOT NULL,
	[JoinDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (1, N'HR', 1)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (2, N'It', 1)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (5, N'Sales', 0)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (6, N'HRBP', 0)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (7, N'Test', 0)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (8, N'HRBP', 0)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (9, N'Test', 0)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (10, N'Sales', 0)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [IsActive]) VALUES (11, N'Sales', 0)
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Salary], [JoinDate], [IsActive]) VALUES (1, N'Jayshree', N'Solankii', 1, CAST(2000 AS Decimal(18, 0)), CAST(N'2024-02-23T10:53:36.453' AS DateTime), 1)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Salary], [JoinDate], [IsActive]) VALUES (8, N'Vrusti', N'Manavadariya', 2, CAST(2000 AS Decimal(18, 0)), CAST(N'2024-02-23T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Salary], [JoinDate], [IsActive]) VALUES (9, N'Devang', N'Solanki', 2, CAST(20000 AS Decimal(18, 0)), CAST(N'2024-02-23T15:19:23.410' AS DateTime), 1)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Salary], [JoinDate], [IsActive]) VALUES (11, N'Yamini', N'Parmar', 5, CAST(2000 AS Decimal(18, 0)), CAST(N'2024-02-23T15:22:24.710' AS DateTime), 1)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Salary], [JoinDate], [IsActive]) VALUES (12, N'Vishal', N'Prajapati', 2, CAST(34000 AS Decimal(18, 0)), CAST(N'2024-02-23T15:23:57.633' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeDetail]    Script Date: 23-02-2024 15:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEmployeeDetail]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT FIRSTNAME,Employee.EmployeeId,Employee.DepartmentId,LastName,JoinDate,DepartmentName,Salary,Employee.IsActive  FROM Employee 
		Left join Department on Employee.DepartmentId=Department.DepartmentId
		where Employee.IsActive='true'
END
GO
USE [master]
GO
ALTER DATABASE [Vitely_CrudPractical] SET  READ_WRITE 
GO
