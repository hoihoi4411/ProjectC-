USE [master]
GO
/****** Object:  Database [SRF]    Script Date: 12/24/2016 9:18:54 AM ******/
CREATE DATABASE [SRF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SRF', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SRF.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SRF_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SRF_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SRF] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SRF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SRF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SRF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SRF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SRF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SRF] SET ARITHABORT OFF 
GO
ALTER DATABASE [SRF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SRF] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SRF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SRF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SRF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SRF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SRF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SRF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SRF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SRF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SRF] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SRF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SRF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SRF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SRF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SRF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SRF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SRF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SRF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SRF] SET  MULTI_USER 
GO
ALTER DATABASE [SRF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SRF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SRF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SRF] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SRF]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 12/24/2016 9:18:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 12/24/2016 9:18:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginId] [nvarchar](50) NOT NULL,
	[LoginPassword] [nvarchar](50) NOT NULL,
	[Roles] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 12/24/2016 9:18:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffId] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NULL,
	[StaffName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/24/2016 9:18:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [nvarchar](7) NOT NULL,
	[StudentName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentRequest]    Script Date: 12/24/2016 9:18:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentRequest](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [nvarchar](7) NULL,
	[ReceiverId] [nvarchar](50) NULL,
	[ApprovalId] [nvarchar](50) NULL,
	[ReceiveDate] [smalldatetime] NULL,
	[CloseDate] [smalldatetime] NULL,
	[Content] [ntext] NOT NULL,
	[Notes] [ntext] NULL,
	[Status] [bit] NULL,
	[DepartmentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (1, N'Academic')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (2, N'IT')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (3, N'Mentor')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (4, N'Partner')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (5, N'Finacial')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (6, N'Business')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (7, N'Harry Potter')
SET IDENTITY_INSERT [dbo].[Department] OFF
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SB72001', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SB72100', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SB74001', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SB75001', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SB77001', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE01254', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE02289', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE02771', N'123456', 2)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE02772', N'123456', 2)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE02774', N'123456', 2)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE02775', N'123456', 2)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE02777', N'123456', 2)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE02789', N'123456', 2)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE03851', N'123456', 1)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE12345', N'123456', 2)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE12348', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE1478', N'123456', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE20123', N'dsdsdsa', 3)
INSERT [dbo].[Login] ([LoginId], [LoginPassword], [Roles]) VALUES (N'SE25683', N'123456', 3)
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SB72001', 4, N'Staff Partner')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SB72100', 4, N'Staff Partner')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SB74001', 3, N'Staff Mentor')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SB75001', 2, N'Staff IT')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SB77001', 5, N'Staff Fin')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE01254', 1, N'Ha Bui')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE02289', 1, N'hieu tran')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE02771', 6, N'Admin Business')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE02772', 4, N'Admin Partner')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE02774', 3, N'Admin Mentor')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE02775', 2, N'Admin IT')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE02777', 5, N'Admin Finacial')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE02789', 1, N'Admin IT')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE12345', 1, N'Hoa Nguyen')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE12348', 1, N'Hieu hieu')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE1478', 1, N'Nghia Nguyen')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE20123', 1, N'ngoc')
INSERT [dbo].[Staff] ([StaffId], [DepartmentId], [StaffName]) VALUES (N'SE25683', 2, N'Hoa Tran')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'czxcxzc', N'xzcxzcxzc', N'cxzcxzcxz@dsd.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SB01210', N'Ha Ha', N'abc@gmail.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SB01234', N'Ngoc Hieu', N'abc@gamil.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SB01235', N'Nhu Nhu', N'abc@gmail.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SB01236', N'Nhu Nhu', N'abc@gmail.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SB01237', N'Van Hoc', N'abc@gmail.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SB01238', N'Tu Tu', N'abc@gmail.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SB01239', N'Ngao Ngao', N'abc@gmail.com')
INSERT [dbo].[Student] ([StudentId], [StudentName], [Email]) VALUES (N'SE03851', N'Dung Nguyen', N'dungnttse03851@gmail.com')
SET IDENTITY_INSERT [dbo].[StudentRequest] ON 

INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (1, N'SB01210', N'SE02289', N'SE25683', CAST(0xA3FF0000 AS SmallDateTime), CAST(0xA56C0000 AS SmallDateTime), N'Change ABC to abc', N'Change ABC to abc', 1, 1)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (3, N'SB01210', N'SE02289', N'SE12345', CAST(0xA67F0000 AS SmallDateTime), CAST(0xA6D9058D AS SmallDateTime), N'Change abc', N'Yeu luon', 1, 1)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (4, N'SB01210', N'SE02289', N'SE12345', CAST(0xA6D90175 AS SmallDateTime), CAST(0xA6DA001A AS SmallDateTime), N'sadsadsa', N'', 1, 1)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (5, N'SB01239', N'SE02289', N'SE12345', CAST(0xA6D90177 AS SmallDateTime), CAST(0xA6DA001F AS SmallDateTime), N'doi dim mad sang 10', N'sdsdfdfdfd', 1, 1)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (6, N'SB01236', N'SE02289', NULL, CAST(0xA6D90179 AS SmallDateTime), NULL, N'Cai lại win ', NULL, 0, 1)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (7, N'SB01239', N'SE02289', NULL, CAST(0xA6D9017B AS SmallDateTime), NULL, N'Doi lich hoc lop SE1005', NULL, 0, 1)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (8, N'SB01210', N'SB72001', NULL, CAST(0xA6DA020B AS SmallDateTime), NULL, N'Boring Partner', NULL, 0, 4)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (9, N'SB01210', N'SB72001', NULL, CAST(0xA6DA020C AS SmallDateTime), NULL, N'sccxzcx', NULL, 0, 4)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (10, N'SB01235', N'SB72001', NULL, CAST(0xA6DA020D AS SmallDateTime), NULL, N'dsadsdsa', NULL, 0, 4)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (11, N'SE03851', N'SB72001', NULL, CAST(0xA6DA020D AS SmallDateTime), NULL, N'dsadsadsa', NULL, 0, 4)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (12, N'SB01210', N'SB72001', NULL, CAST(0xA6DA0210 AS SmallDateTime), NULL, N'sadsadsadsa', NULL, 0, 4)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (13, N'SB01238', N'SB74001', NULL, CAST(0xA6DA0212 AS SmallDateTime), NULL, N'Seems a better answer to me because you have a return value you can save temporary ', NULL, 0, 3)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (14, N'SB01236', N'SB74001', NULL, CAST(0xA6DA0213 AS SmallDateTime), NULL, N'Additional information: Object reference not set to an instance of an object.', NULL, 0, 3)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (15, N'SB01239', N'SB74001', NULL, CAST(0xA6DA0213 AS SmallDateTime), NULL, N'Additional information: Object reference not set to an instance of an object.', NULL, 0, 3)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (16, N'SB01238', N'SB75001', NULL, CAST(0xA6DA0215 AS SmallDateTime), NULL, N'Additional information: Object reference not set to an instance of an object.', NULL, 0, 2)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (17, N'SB01239', N'SB75001', NULL, CAST(0xA6DA0215 AS SmallDateTime), NULL, N'Additional information: Object reference not set to an instance of an object.', NULL, 0, 2)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (18, N'SB01237', N'SB77001', NULL, CAST(0xA6DA0216 AS SmallDateTime), NULL, N'All of the above really just hints at .NET Type Fundamentals, for further information I''d recommend either picking up CLR via C# or reading this MSDN', NULL, 0, 5)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (19, N'SB01237', N'SB77001', NULL, CAST(0xA6DA0216 AS SmallDateTime), NULL, N'All of the above really just hints at .NET Type Fundamentals, for further information I''d recommend either picking up CLR via C# or reading this MSDN', NULL, 0, 6)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (20, N'SB01237', N'SB77001', NULL, CAST(0xA6DA0216 AS SmallDateTime), NULL, N'All of the above really just hints at .NET Type Fundamentals, for further information I''d recommend either picking up CLR via C# or reading this MSDN', NULL, 0, 7)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (21, N'SB01237', N'SB77001', NULL, CAST(0xA6DA0216 AS SmallDateTime), NULL, N'All of the above really just hints at .NET Type Fundamentals, for further information I''d recommend either picking up CLR via C# or reading this MSDN', NULL, 0, 6)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (22, N'SB01239', N'SB77001', NULL, CAST(0xA6DA0217 AS SmallDateTime), NULL, N'All of the above really just hints at .NET Type Fundamentals, for further information I''d recommend either picking up CLR via C# or reading this MSDN', NULL, 0, 7)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (23, N'SB01236', N'SE02289', NULL, CAST(0xA6DA024C AS SmallDateTime), NULL, N'cxzcxz', NULL, 0, 1)
INSERT [dbo].[StudentRequest] ([RequestId], [StudentId], [ReceiverId], [ApprovalId], [ReceiveDate], [CloseDate], [Content], [Notes], [Status], [DepartmentId]) VALUES (24, N'SB01239', N'SE02289', N'SE02775', CAST(0xA6DA0267 AS SmallDateTime), CAST(0xA6DA0269 AS SmallDateTime), N'Internet ', N'OK Internet is fixed', 1, 2)
SET IDENTITY_INSERT [dbo].[StudentRequest] OFF
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([StaffId])
REFERENCES [dbo].[Login] ([LoginId])
GO
ALTER TABLE [dbo].[StudentRequest]  WITH CHECK ADD FOREIGN KEY([ApprovalId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[StudentRequest]  WITH CHECK ADD FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[StudentRequest]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
USE [master]
GO
ALTER DATABASE [SRF] SET  READ_WRITE 
GO
