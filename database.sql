USE [master]
GO
/****** Object:  Database [Practice]    Script Date: 11/18/2019 11:34:13 AM ******/
CREATE DATABASE [Practice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Practice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Practice.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Practice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Practice_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Practice] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Practice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Practice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Practice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Practice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Practice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Practice] SET ARITHABORT OFF 
GO
ALTER DATABASE [Practice] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Practice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Practice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Practice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Practice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Practice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Practice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Practice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Practice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Practice] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Practice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Practice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Practice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Practice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Practice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Practice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Practice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Practice] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Practice] SET  MULTI_USER 
GO
ALTER DATABASE [Practice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Practice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Practice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Practice] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Practice] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Practice] SET QUERY_STORE = OFF
GO
USE [Practice]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/18/2019 11:34:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[Birthday] [smalldatetime] NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Address] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 11/18/2019 11:34:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[loginID] [int] NOT NULL,
	[username] [varchar](20) NULL,
	[password] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[loginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (1, N'Nguyễn Long', N'Male', NULL, N'0258741369', N'nguyenlong@gmail.com', N'Hồ Chí Minh')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (2, N'Hương Thị', N'Female', NULL, N'0259631478', N'huongthi@gmail.com', N'Phú Yên')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (3, N'Trần Hạo Nam', N'Female', NULL, N'0258741369', N'haonam@gmail.com', N'Hồ Chí Minh')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (4, N'Lê Thị Mén', N'Female', NULL, N'0321456987', N'menthi@gmail.com', N'Phú Thọ')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (5, N'Phan Văn Hớn', N'Male', NULL, N'0369852147', N'honvan@gmail.com', N'Bình Định')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (6, N'Phan Ngọc Thủy', N'Female', NULL, N'0254136987', N'honvan@gmail.com', N'Đồng Nai')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (7, N'Nguyễn Ninh Kiều', N'Female', NULL, N'0125478963', N'ninhkieu@gmail.com', N'Long An')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (8, N'Nguyễn Ninh Hậu', N'Male', NULL, N'0125478986', N'ninhhau@gmail.com', N'Long An')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (9, N'Nguyễn Ninh Bá', N'Female', NULL, N'012547236', N'ninhba@gmail.com', N'Vũng Tàu')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (10, N'Nguyễn Ninh Thuận', N'Male', NULL, N'0125472367', N'ninhthuan@gmail.com', N'Long An')
INSERT [dbo].[Customer] ([CustomerID], [Name], [Gender], [Birthday], [Phone], [Email], [Address]) VALUES (11, N'Lê Minh Hoa', N'Female', NULL, N'0214569873', N'minhhoa@gmail.com', N'Hồ Chí Minh')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (1, N'admin', N'admin')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (2, N'anhtuan', N'nguyenhoang')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (3, N'anh', N'anh')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (4, N'g', N'g')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (5, N'ah', N'a')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (6, N'ah', N'ak')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (7, N'viet', N'a')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (8, N'vieth', N'a')
INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (9, N'ki', N'k')
/****** Object:  StoredProcedure [dbo].[findInfor]    Script Date: 11/18/2019 11:34:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[findInfor] 
 @infor_Name nvarchar(50), 
 @infor_Gender nvarchar(10),
 @infor_Phone nvarchar(15),
 @infor_Email nvarchar(50),
 @infor_Address nvarchar(max)

 as

 begin 
 select * from dbo.Customer where (Name like concat('%', @infor_Name , '%') and 
									 Gender like COALESCE(@infor_Gender, '%%') and
									 Phone like concat('%', @infor_Phone , '%') and
									 Email like concat('%', @infor_Email , '%') and
									 Address like concat('%', @infor_Address , '%'))

 end
GO
/****** Object:  StoredProcedure [dbo].[Verify]    Script Date: 11/18/2019 11:34:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Verify]
@userName varchar(20), 
@passWord varchar(20)

as

begin 
select * from dbo.Login where username = @userName and password = @passWord

end 
GO
USE [master]
GO
ALTER DATABASE [Practice] SET  READ_WRITE 
GO
