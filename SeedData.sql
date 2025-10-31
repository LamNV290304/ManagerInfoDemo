/*
 Navicat Premium Data Transfer

 Source Server         : SQL Server
 Source Server Type    : SQL Server
 Source Server Version : 16004210 (16.00.4210)
 Source Host           : localhost:1433
 Source Catalog        : ManagerInfo
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16004210 (16.00.4210)
 File Encoding         : 65001

 Date: 31/10/2025 14:53:22
*/


-- ----------------------------
-- Table structure for Customers
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type IN ('U'))
	DROP TABLE [dbo].[Customers]
GO

CREATE TABLE [dbo].[Customers] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [FullName] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Email] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Phone] nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Address] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DateOfBirth] date  NULL,
  [CreatedAt] datetime DEFAULT getdate() NULL,
  [IsVerify] bit DEFAULT 0 NULL,
  [CreatedBy] int  NULL
)
GO

ALTER TABLE [dbo].[Customers] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Customers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Customers] ON
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'21', N'Nguyễn Văn A', N'vana@example.com', N'0912345001', N'Hà Nội', N'1995-01-12', N'2025-10-31 04:53:29.990', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'22', N'Trần Thị B', N'thib@example.com', N'0912345002', N'Hồ Chí Minh', N'1998-03-25', N'2025-10-31 04:53:29.990', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'23', N'Lê Văn C', N'vanc@example.com', N'0912345003', N'Đà Nẵng', N'1992-07-19', N'2025-10-31 04:53:29.990', N'1', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'24', N'Phạm Thị D', N'thid@example.com', N'0912345004', N'Cần Thơ', N'2000-11-05', N'2025-10-31 04:53:29.990', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'25', N'Hoàng Minh E', N'minhe@example.com', N'0912345005', N'Hải Phòng', N'1996-09-14', N'2025-10-31 04:53:29.990', N'1', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'26', N'Vũ Thị F', N'thif@example.com', N'0912345006', N'Nam Định', N'1999-02-22', N'2025-10-31 04:53:29.990', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'27', N'Đặng Văn G', N'vang@example.com', N'0912345007', N'Hà Nam', N'1993-05-08', N'2025-10-31 04:53:29.990', N'1', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'28', N'Phan Thị H', N'thih@example.com', N'0912345008', N'Bắc Ninh', N'2001-04-30', N'2025-10-31 04:53:29.990', N'1', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'29', N'Ngô Văn I', N'vani@example.com', N'0912345009', N'Nghệ An', N'1997-06-17', N'2025-10-31 04:53:29.990', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'32', N'Lưu Thị Linh', N'thil@example.com', N'0912345011', N'Hải Dương', N'1990-08-15', N'2025-10-31 04:54:06.700', N'1', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'33', N'Tạ Văn M', N'vanm@example.com', N'0912345012', N'Quảng Ninh', N'1992-10-09', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'34', N'Đỗ Thị N', N'thin@example.com', N'0912345013', N'Hưng Yên', N'1998-12-27', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'35', N'Nguyễn Hữu O', N'huuo@example.com', N'0912345014', N'Bình Dương', N'1995-04-11', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'36', N'Lý Thị P', N'thip@example.com', N'0912345015', N'Bắc Giang', N'2000-01-05', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'37', N'Võ Văn Q', N'vanq@example.com', N'0912345016', N'Tây Ninh', N'1993-06-30', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'38', N'Hà Thị R', N'thir@example.com', N'0912345017', N'Ninh Bình', N'1999-09-12', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'39', N'Phùng Văn S', N'vans@example.com', N'0912345018', N'Thái Bình', N'1997-03-04', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'40', N'Trịnh Thị T', N'thit@example.com', N'0912345019', N'Lào Cai', N'1994-07-22', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

INSERT INTO [dbo].[Customers] ([Id], [FullName], [Email], [Phone], [Address], [DateOfBirth], [CreatedAt], [IsVerify], [CreatedBy]) VALUES (N'41', N'Cao Văn U', N'vanu@example.com', N'0912345020', N'Long An', N'1991-11-17', N'2025-10-31 04:54:06.700', N'0', N'1')
GO

SET IDENTITY_INSERT [dbo].[Customers] OFF
GO


-- ----------------------------
-- Table structure for Staffs
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Staffs]') AND type IN ('U'))
	DROP TABLE [dbo].[Staffs]
GO

CREATE TABLE [dbo].[Staffs] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Username] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [PasswordHash] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [CreatedAt] datetime DEFAULT getdate() NULL,
  [Email] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Staffs] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Staffs
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Staffs] ON
GO

INSERT INTO [dbo].[Staffs] ([Id], [Username], [PasswordHash], [CreatedAt], [Email]) VALUES (N'1', N'admin', N'$2a$11$IWu0o3UgPtXQ/zN35a5LVeOnCm0QQILHD3hahx52yOjgHlf9Uua6y', N'2025-10-31 01:26:46.880', N'')
GO

SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO


-- ----------------------------
-- Table structure for Tokens
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Tokens]') AND type IN ('U'))
	DROP TABLE [dbo].[Tokens]
GO

CREATE TABLE [dbo].[Tokens] (
  [Email] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Token] char(36) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ExpiresAt] datetime  NOT NULL,
  [Status] bit  NULL
)
GO

ALTER TABLE [dbo].[Tokens] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Tokens
-- ----------------------------
INSERT INTO [dbo].[Tokens] ([Email], [Token], [ExpiresAt], [Status]) VALUES (N'vietlam2k4@gmail.com', N'7aaf2d0a-e141-4140-a5ca-0b5289244987', N'2025-11-01 07:40:53.473', N'0')
GO

INSERT INTO [dbo].[Tokens] ([Email], [Token], [ExpiresAt], [Status]) VALUES (N'vietlamkc@gmail.com', N'1b1c65c5-1ade-426b-a64f-0f0213f9e4f9', N'2025-10-31 07:32:18.477', N'1')
GO


-- ----------------------------
-- Auto increment value for Customers
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Customers]', RESEED, 1005)
GO


-- ----------------------------
-- Uniques structure for table Customers
-- ----------------------------
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [UQ__Customer__A9D10534C2381D86] UNIQUE NONCLUSTERED ([Email] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Customers
-- ----------------------------
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [PK__Customer__3214EC07C2DDA206] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Staffs
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Staffs]', RESEED, 1)
GO


-- ----------------------------
-- Uniques structure for table Staffs
-- ----------------------------
ALTER TABLE [dbo].[Staffs] ADD CONSTRAINT [UQ__Staffs__536C85E4792D8F77] UNIQUE NONCLUSTERED ([Username] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Staffs
-- ----------------------------
ALTER TABLE [dbo].[Staffs] ADD CONSTRAINT [PK__Staffs__3214EC0778C01481] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Tokens
-- ----------------------------
ALTER TABLE [dbo].[Tokens] ADD CONSTRAINT [PK__Tokens__A9D105355439D309] PRIMARY KEY CLUSTERED ([Email])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Customers
-- ----------------------------
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [FK__Customers__Creat__5070F446] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Staffs] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

