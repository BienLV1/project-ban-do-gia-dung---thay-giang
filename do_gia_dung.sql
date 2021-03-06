USE [master]
GO
/****** Object:  Database [do_gia_dung]    Script Date: 7/14/2021 9:37:54 PM ******/
CREATE DATABASE [do_gia_dung]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'do_gia_dung', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\do_gia_dung.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'do_gia_dung_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\do_gia_dung_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [do_gia_dung] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [do_gia_dung].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [do_gia_dung] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [do_gia_dung] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [do_gia_dung] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [do_gia_dung] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [do_gia_dung] SET ARITHABORT OFF 
GO
ALTER DATABASE [do_gia_dung] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [do_gia_dung] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [do_gia_dung] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [do_gia_dung] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [do_gia_dung] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [do_gia_dung] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [do_gia_dung] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [do_gia_dung] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [do_gia_dung] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [do_gia_dung] SET  ENABLE_BROKER 
GO
ALTER DATABASE [do_gia_dung] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [do_gia_dung] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [do_gia_dung] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [do_gia_dung] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [do_gia_dung] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [do_gia_dung] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [do_gia_dung] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [do_gia_dung] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [do_gia_dung] SET  MULTI_USER 
GO
ALTER DATABASE [do_gia_dung] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [do_gia_dung] SET DB_CHAINING OFF 
GO
ALTER DATABASE [do_gia_dung] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [do_gia_dung] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [do_gia_dung] SET DELAYED_DURABILITY = DISABLED 
GO
USE [do_gia_dung]
GO
/****** Object:  Table [dbo].[binhluan]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[binhluan](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NDBL] [nvarchar](1000) NULL,
	[NGAYDANG] [date] NULL,
	[EMAIL] [varchar](100) NULL,
	[SDT] [char](10) NULL,
	[ANH] [varchar](100) NULL,
	[TENKH] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hangsx]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hangsx](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MAHANGSX] [char](15) NULL,
	[TENHANG] [nvarchar](50) NULL,
	[ANH] [varchar](100) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[khachhang](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TENKH] [nvarchar](50) NULL,
	[SDT] [char](10) NULL,
	[EMAIL] [varchar](100) NULL,
	[ND] [ntext] NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[loaisp]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[loaisp](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MALOAI] [char](15) NULL,
	[TENLOAI] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[loaitintuc]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[loaitintuc](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LOAITIN] [varchar](10) NULL,
	[TENLOAITIN] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[Link] [nvarchar](250) NULL,
	[Status] [bit] NULL,
	[TypeID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuType](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[oder]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[oder](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[phone] [varchar](12) NULL,
	[address] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[total] [float] NULL,
	[ngaydathang] [date] NULL,
	[thanhtoan] [text] NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[oderdetail]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[oderdetail](
	[ID] [bigint] NOT NULL,
	[hoten] [nvarchar](100) NULL,
	[masp] [varchar](50) NULL,
	[tensp] [nvarchar](200) NULL,
	[soluong] [int] NULL,
	[giatien] [bigint] NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sanpham](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MASP] [char](15) NULL,
	[TENSP] [nvarchar](100) NULL,
	[GIAX] [bigint] NULL,
	[GIA] [bigint] NULL,
	[GIAMGIA] [int] NULL,
	[SOLUONG] [int] NULL,
	[NGAYNHAP] [date] NULL,
	[ANH] [varchar](100) NULL,
	[MOTA] [ntext] NULL,
	[MAHANGSX] [bigint] NULL,
	[MALOAI] [bigint] NULL,
	[TOPHOT] [datetime] NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tintuc]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tintuc](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MATIN] [char](15) NULL,
	[TIEUDE] [ntext] NULL,
	[ANH] [varchar](100) NULL,
	[NOIDUNG] [ntext] NULL,
	[NGAYDANG] [date] NULL,
	[NDNGAN] [ntext] NULL,
	[LOAITIN] [varchar](10) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK__tintuc__3214EC27E613AAB4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/14/2021 9:37:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[PassWord] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
	[Quyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[binhluan] ON 

INSERT [dbo].[binhluan] ([ID], [NDBL], [NGAYDANG], [EMAIL], [SDT], [ANH], [TENKH], [TrangThai]) VALUES (2, N'Chất lượng sản phẩm tuyệt vời. Dịch vụ chăm sóc khách hàng tốt. Shop nhiêt tình. Đóng gói sản phẩm chắc chắn.', CAST(N'2021-07-08' AS Date), N'bienlai1001@gmail.com', N'0123456789', N'/UploadData/files/test-1_12a98a11f5a778835ddcf69b749c39a1.jpg', N'Lisa', 1)
INSERT [dbo].[binhluan] ([ID], [NDBL], [NGAYDANG], [EMAIL], [SDT], [ANH], [TENKH], [TrangThai]) VALUES (3, N'Chất lượng sản phẩm tuyệt vời. Dịch vụ chăm sóc khách hàng tốt. Shop nhiêt tình. Đóng gói sản phẩm chắc chắn', CAST(N'2021-07-08' AS Date), N'rose@gmail.com', N'0123456789', N'/UploadData/files/test-2_edb7a8897dc97599314a3b1b116f89e3.jpg', N'Rose', 1)
INSERT [dbo].[binhluan] ([ID], [NDBL], [NGAYDANG], [EMAIL], [SDT], [ANH], [TENKH], [TrangThai]) VALUES (4, N'Chất lượng sản phẩm tuyệt vời. Dịch vụ chăm sóc khách hàng tốt. Shop nhiêt tình. Đóng gói sản phẩm chắc chắn', CAST(N'2021-07-08' AS Date), N'david@gmail.com', N'0123456789', N'/UploadData/files/test-4_01389a9387931b938602d882b584a9de.jpg', N'David', 1)
SET IDENTITY_INSERT [dbo].[binhluan] OFF
SET IDENTITY_INSERT [dbo].[hangsx] ON 

INSERT [dbo].[hangsx] ([ID], [MAHANGSX], [TENHANG], [ANH], [TrangThai]) VALUES (3, N'SNK            ', N'SANAKY', N'/UploadData/files/b1_cb1b9d0fbf6c2698b07dd770e4c9fd5f.png', 1)
INSERT [dbo].[hangsx] ([ID], [MAHANGSX], [TENHANG], [ANH], [TrangThai]) VALUES (4, N'SH             ', N'SUNHOUSE', N'/UploadData/files/b2_adbce5d80caa2e25fc3167f2c2f993fc.png', 1)
INSERT [dbo].[hangsx] ([ID], [MAHANGSX], [TENHANG], [ANH], [TrangThai]) VALUES (5, N'SP             ', N'SUPOR', N'/UploadData/files/b3_52f09b0b48fa1c109bc3248a3651efce.png', 1)
INSERT [dbo].[hangsx] ([ID], [MAHANGSX], [TENHANG], [ANH], [TrangThai]) VALUES (6, N'SHAP           ', N'SHAP', N'/UploadData/files/b4_3da4e61fbbddf147eb8c7d049b1c67cf.png', 1)
INSERT [dbo].[hangsx] ([ID], [MAHANGSX], [TENHANG], [ANH], [TrangThai]) VALUES (7, N'TOSHIBA        ', N'TOSHIBA ', N'/UploadData/files/b5_b4ecad55e17f7cb38b76c39b28b27db1.png', 1)
INSERT [dbo].[hangsx] ([ID], [MAHANGSX], [TENHANG], [ANH], [TrangThai]) VALUES (8, N'CUCKOO         ', N'CUCKOO', N'/UploadData/files/b6_1ed834704d1befc35deb1a095318f5ad.png', 1)
SET IDENTITY_INSERT [dbo].[hangsx] OFF
SET IDENTITY_INSERT [dbo].[khachhang] ON 

INSERT [dbo].[khachhang] ([ID], [TENKH], [SDT], [EMAIL], [ND], [TrangThai]) VALUES (4, N'Lisa', N'0123456789', N'lisa@gmail.com', N'lisa', 1)
SET IDENTITY_INSERT [dbo].[khachhang] OFF
SET IDENTITY_INSERT [dbo].[loaisp] ON 

INSERT [dbo].[loaisp] ([ID], [MALOAI], [TENLOAI], [TrangThai]) VALUES (3, N'BEPDT          ', N'BẾP ĐIỆN TỪ', 1)
INSERT [dbo].[loaisp] ([ID], [MALOAI], [TENLOAI], [TrangThai]) VALUES (4, N'NOICD          ', N'NỒI CƠM ĐIỆN', 1)
INSERT [dbo].[loaisp] ([ID], [MALOAI], [TENLOAI], [TrangThai]) VALUES (5, N'QUAT           ', N'QUẠT', 1)
SET IDENTITY_INSERT [dbo].[loaisp] OFF
SET IDENTITY_INSERT [dbo].[loaitintuc] ON 

INSERT [dbo].[loaitintuc] ([ID], [LOAITIN], [TENLOAITIN]) VALUES (1, N'Sale7', N'Siêu sale tháng 7')
INSERT [dbo].[loaitintuc] ([ID], [LOAITIN], [TENLOAITIN]) VALUES (2, N'Sale8', N'Siêu sale tháng 8')
SET IDENTITY_INSERT [dbo].[loaitintuc] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [Text], [Link], [Status], [TypeID]) VALUES (2, N'Trang chủ', N'Home/Index', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [Status], [TypeID]) VALUES (4, N'Sản phẩm', N'san-pham', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [Status], [TypeID]) VALUES (5, N'Tin tức', N'tin-tuc', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [Status], [TypeID]) VALUES (6, N'Liên hệ', N'lien-he', 1, 1)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuType] ON 

INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (1, N'menu')
INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (2, N'menu2')
SET IDENTITY_INSERT [dbo].[MenuType] OFF
SET IDENTITY_INSERT [dbo].[oder] ON 

INSERT [dbo].[oder] ([ID], [name], [phone], [address], [email], [total], [ngaydathang], [thanhtoan], [TrangThai]) VALUES (1, N'a a', N'123456789', N'Hà nam', N'bienlai1001@gmail.com', NULL, CAST(N'2021-07-05' AS Date), NULL, NULL)
INSERT [dbo].[oder] ([ID], [name], [phone], [address], [email], [total], [ngaydathang], [thanhtoan], [TrangThai]) VALUES (2, N'Lại Văn Biên', N'0877041914', N'Nhà van hoá thôn ch?m xã Liêm Thu?n', N'bienlai1001@gmail.com', 1300000, CAST(N'2021-07-05' AS Date), N'COD', 1)
INSERT [dbo].[oder] ([ID], [name], [phone], [address], [email], [total], [ngaydathang], [thanhtoan], [TrangThai]) VALUES (3, N'Lại Văn Biên', N'0877041914', N'Nhà van hoá thôn ch?m xã Liêm Thu?n', N'bienlai1001@gmail.com', 1300000, CAST(N'2021-07-05' AS Date), N'COD', 1)
INSERT [dbo].[oder] ([ID], [name], [phone], [address], [email], [total], [ngaydathang], [thanhtoan], [TrangThai]) VALUES (4, N'Lại Văn Biên', N'0877041914', N'Nhà van hoá thôn ch?m xã Liêm Thu?n', N'bienlai1001@gmail.com', 3900000, CAST(N'2021-07-05' AS Date), N'COD', 1)
INSERT [dbo].[oder] ([ID], [name], [phone], [address], [email], [total], [ngaydathang], [thanhtoan], [TrangThai]) VALUES (5, N'Lại Văn Biên', N'0877041914', N'Nhà van hoá thôn ch?m xã Liêm Thu?n', N'bienlai1001@gmail.com', 1470000, CAST(N'2021-07-09' AS Date), N'COD', 1)
INSERT [dbo].[oder] ([ID], [name], [phone], [address], [email], [total], [ngaydathang], [thanhtoan], [TrangThai]) VALUES (6, N'a a', N'123456789', N'Hà nam', N'bienlai1001@gmail.com', 1470000, CAST(N'2021-07-11' AS Date), N'COD', 1)
SET IDENTITY_INSERT [dbo].[oder] OFF
INSERT [dbo].[oderdetail] ([ID], [hoten], [masp], [tensp], [soluong], [giatien], [TrangThai]) VALUES (1, NULL, N'MLN01          ', NULL, 1, 1300000, NULL)
INSERT [dbo].[oderdetail] ([ID], [hoten], [masp], [tensp], [soluong], [giatien], [TrangThai]) VALUES (3, N'Lại Văn Biên', N'MAYEP01        ', N'Máy ép chậm Kalite KL-530', 1, 1300000, 1)
INSERT [dbo].[oderdetail] ([ID], [hoten], [masp], [tensp], [soluong], [giatien], [TrangThai]) VALUES (4, N'Lại Văn Biên', N'MAYEP01        ', N'Máy ép chậm Kalite KL-530', 2, 2600000, 1)
INSERT [dbo].[oderdetail] ([ID], [hoten], [masp], [tensp], [soluong], [giatien], [TrangThai]) VALUES (5, N'Lại Văn Biên', N'DR1608         ', N'Quạt đứng Senko DR1608 Môn', 3, 1470000, 1)
INSERT [dbo].[oderdetail] ([ID], [hoten], [masp], [tensp], [soluong], [giatien], [TrangThai]) VALUES (6, N'a a', N'DR1608         ', N'Quạt đứng Senko DR1608 Môn', 3, 1470000, 1)
SET IDENTITY_INSERT [dbo].[sanpham] ON 

INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (5, N'SNK-2018HG     ', N'Bếp hồng ngoại Sanaky SNK-2018HG', 950000, 800000, 490000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10038875-bep-hong-ngoai-sanaky-snk-2018hg-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 3, 3, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (6, N'SHD6011        ', N'Bếp hồng ngoại Sunhouse SHD6011', 650000, 400000, 490000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10020829-bep-hong-ngoai-sunhouse-shd6011-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 4, 3, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (7, N'CB36VN         ', N'Bếp điện từ Supor CB36VN', 990000, 400000, 490000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10038269-bep-tu-supor-cb36vn-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 5, 3, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (8, N'SNK 2524HGN    ', N'Bếp hồng ngoại Sanaky SNK 2524HGN', 950000, 800000, 900000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10019076-bep-hong-ngoai-sanaky-snk2524hgn-1_2011-gr.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 3, 3, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (9, N'SHB9102MT      ', N'Bếp hồng ngoại đôi Sunhouse', 2990000, 2200000, 2900000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10036592-bep-doi-hong-ngoai-sunhouse-shb9102mt-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 4, 3, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (10, N'ETD29PKB       ', N'Bếp điện từ Electrolux ETD29PKB', 1400000, 1200000, 1300000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10023560-bep-dien-tu-electrolux-etd29pkb-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 5, 3, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (11, N'SNK-2101HG     ', N'BẾP HỒNG NGOẠI SANAKY SNK-2101HG', 950000, 800000, 900000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10019803-bep-hong-ngoai-sanaky-snk-2101hg-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 3, 3, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (12, N' ASC-86        ', N'Bếp hồng ngoại Junger ASC-86', 2990000, 1200000, 2900000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10019076-bep-hong-ngoai-sanaky-snk2524hgn-1_2011-gr(1).jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 3, 3, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (13, N'SHD6017        ', N'Bếp hồng ngoại Sunhouse SHD6017', 1150000, 800000, 990000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10019076-bep-hong-ngoai-sanaky-snk2524hgn-1_2011-gr(2).jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 4, 3, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (14, N' SHD6015       ', N'Bếp hồng ngoại Sunhouse SHD6015', 1400000, 1200000, 1300000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10030633-bep-hong-ngoai-sunhouse-shd6015-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 4, 3, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (15, N'IC4200KS       ', N'Bếp điện từ hồng ngoại Ferroli IC4200KS', 990000, 800000, 900000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10043421-bep-dien-tu-hong-ngoai-ferroli-ic4200ks-1_qvmq-n7.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 5, 3, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (16, N'MMB9200MIX     ', N'Bếp điện từ hồng ngoại Sunhouse Mama MMB9200MIX', 1400000, 800000, 1300000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10047681-bep-dien-tu-hong-ngoai-sunhouse-mama-mmb9200mix-1.jpg', N'Kiểu dáng hiện đại, màu sắc sang trọng với hoa văn tinh tế
Công suất cao 2000W giúp nấu ăn trong thời gian ngắn
Mặt bếp bằng kính chịu nhiệt tốt, sáng bóng và bền bỉ
Bảng điều kiển cảm ứng tiện lợi khi điều chỉnh nhiệt độ
Cài đặt sẵn 6 chế độ nấu đa dạng cho bữa ăn phong phú', 4, 3, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (17, N'RC-10NMFVN     ', N'Nồi cơm điện Toshiba 1 lít RC-10NMFVN', 2990000, 2200000, 2250000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10032712-noi-com-dien-toshiba-1l-rc-10nmfvn-wt-1_mylz-oy.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 7, 4, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (18, N'CFXB40FC33VN-75', N'Nồi cơm điện Supor 1.5 lít CFXB40FC33VN-75', 1400000, 1200000, 1300000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10035245-noi-com-dien-supor-1-5l-cfxb40fc33vn-75-1.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 5, 4, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (19, N'RC-18DH2PV     ', N'Nồi cơm điện Toshiba 1.8 lít RC-18DH2PV(W)', 1400000, 800000, 900000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10046246-noi-com-dien-toshiba-1-8l-rc-18dh2pv-w-1.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 7, 4, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (20, N' SHD8602       ', N'Nồi cơm điện Sunhouse 1.8L SHD8602', 990000, 800000, 990000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10038430-noi-com-dien-sunhouse-1-8-lit-shd8602-1_x2am-5e.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 4, 4, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (21, N'KS-181TJV      ', N'Nồi cơm điện Sharp 1.8 lít KS-181TJV', 1400000, 800000, 990000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10027482-noi-com-dien-sharp-1-8-lit-ks-181tjv-1.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 6, 4, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (22, N'KSH-D11V       ', N'Nồi cơm điện Sharp 1.1 lít KSH-D11V', 990000, 400000, 490000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10034137-noi-com-dien-sharp-ksh-d11v-1.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 6, 4, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (23, N'KS-A08V-WH     ', N'Nồi cơm điện Sharp 0.72 lít KS-A08V-WH', 2990000, 2200000, 2900000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10047964-noi-com-dien-sharp-0-72-lit-ks-a08v-wh-1.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 6, 4, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (24, N' S102          ', N'Quạt điều hòa Boss S102', 6290000, 4200000, 4720000, 100, CAST(N'2021-07-07' AS Date), N'/UploadData/files/10031896-quat-dieu-hoa-boss-s102-1.jpg', N'Trang bị 3 tốc độ gió dễ dàng tùy chỉnh theo nhu cầu sử dụng
Điều khiển từ xa tiện dụng khi sử dụng, không di chuyển nhiều
Dung tích bình chứa lớn 14 lít hoạt động liên tục thoải mái
Bảng điều khiển có các nút nhấn chức năng dễ sử dụng', 3, 5, CAST(N'2021-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (25, N'DR1608         ', N'Quạt đứng Senko DR1608 Môn', 990000, 400000, 490000, 100, CAST(N'2021-07-08' AS Date), N'/UploadData/files/10032719-quat-dung-senko-dr1608-mon-1.jpg', N'Trang bị 3 tốc độ gió dễ dàng tùy chỉnh theo nhu cầu sử dụng
Điều khiển từ xa tiện dụng khi sử dụng, không di chuyển nhiều
Dung tích bình chứa lớn 14 lít hoạt động liên tục thoải mái
Bảng điều khiển có các nút nhấn chức năng dễ sử dụng', 8, 5, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[sanpham] ([ID], [MASP], [TENSP], [GIAX], [GIA], [GIAMGIA], [SOLUONG], [NGAYNHAP], [ANH], [MOTA], [MAHANGSX], [MALOAI], [TOPHOT], [TrangThai]) VALUES (26, N'KS-TH18        ', N'Nồi cơm điện Sharp 1.8 lít KS-TH18', 2990000, 1200000, 1300000, 100, CAST(N'2021-07-08' AS Date), N'/UploadData/files/10006620-noi-com-dien-sharp-1-8l-ks-th18-1.jpg', N'Dung tích 1 lít thích hợp cho gia đình 2 - 4 thành viên
Thiết kế nhỏ gọn hiện đại nâng tầm không gian bếp
Nồi cơm điện với hệ thống hẹn giờ nấu thông minh tiện lợi 
Lòng nồi dày, bền bỉ, an toàn và dễ dàng làm sạch
Nắp thoát hơi nước thông minh chống tràn hiệu quả
Màn hình hiển thị LCD rõ ràng dễ theo dõi và thao tác', 6, 4, CAST(N'2022-09-20 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[sanpham] OFF
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [Image], [CreateDate], [Status]) VALUES (8, N'/UploadData/images/PAYDAYT6_1008x405.jpg', CAST(N'2021-07-14 21:33:00.610' AS DateTime), 1)
INSERT [dbo].[Slide] ([ID], [Image], [CreateDate], [Status]) VALUES (9, N'/UploadData/images/Covy_1406-home-web-1008x405.png', CAST(N'2021-07-14 21:33:31.883' AS DateTime), 1)
INSERT [dbo].[Slide] ([ID], [Image], [CreateDate], [Status]) VALUES (10, N'/UploadData/images/Homepage%20Top%20Slide%20Banner_1008x405px-01.jpg', CAST(N'2021-07-14 21:33:43.440' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Slide] OFF
SET IDENTITY_INSERT [dbo].[tintuc] ON 

INSERT [dbo].[tintuc] ([ID], [MATIN], [TIEUDE], [ANH], [NOIDUNG], [NGAYDANG], [NDNGAN], [LOAITIN], [TrangThai]) VALUES (4, N'SALE7          ', N'Trợ giá lên đến 50% khi mua hàng online mùa "Cô Vy"', N'/UploadData/files/Covy_1406-home-web-1008x405.png', N'Một thực tế đã có từ lâu rằng người đọc sẽ bị phân tâm bởi nội dung có thể đọc được của một trang khi nhìn vào bố cục của nó. Điểm sử dụngLorem Ipsumlà nó có sự phân bố bình thường ít nhiều của các chữ cái, trái ngược với việc sử dụng ''Nội dung ở đây, nội dung ở đây'', khiến nó trông giống như tiếng Anh có thể đọc được. Nhiều gói xuất bản trên máy tính để bàn và trình chỉnh sửa trang web hiện sử dụng Lorem Ipsum làm văn bản mẫu mặc định của họ và tìm kiếm ''lorem ipsum'' sẽ phát hiện ra nhiều trang web vẫn còn sơ khai. Nhiều phiên bản khác nhau đã phát triển qua nhiều năm, đôi khi là do tình cờ, đôi khi là có chủ đích (tiêm chất hài hước và những thứ tương tự).Trái với suy nghĩ của nhiều người, Lorem Ipsum không chỉ đơn giản là văn bản ngẫu nhiên. Nó có nguồn gốc từ một tác phẩm văn học Latinh cổ điển từ năm 45 trước Công nguyên, khiến nó hơn 2000 năm tuổi. Richard McClintock, một giáo sư tiếng Latinh tại Đại học Hampden-Sydney ở Virginia, đã tra cứu một trong những từ Latinh khó hiểu hơn, consectetur, từ một đoạn văn của Lorem Ipsum, và xem qua các trích dẫn của từ này trong văn học cổ điển, đã phát hiện ra nguồn gốc không thể chối cãi. Lorem Ipsum xuất phát từ phần 1.10.32 và 1.10.33 của "de Finibus Bonorum et Malorum" (Cực đoan của Thiện và Ác) của Cicero, được viết vào năm 45 trước Công nguyên. Cuốn sách này là một chuyên luận về lý thuyết đạo đức, rất phổ biến trong thời kỳ Phục hưng. Dòng đầu tiên của Lorem Ipsum, "Lorem ipsum dolor sit amet ..", xuất phát từ một dòng trong phần 1.10.32.', CAST(N'2021-07-08' AS Date), N'Mùa "Cô vy" ở nhà cũng mua được hàng kèm theo nhiều ưu đãi hấp dẫn.', N'Sale7', 1)
INSERT [dbo].[tintuc] ([ID], [MATIN], [TIEUDE], [ANH], [NOIDUNG], [NGAYDANG], [NDNGAN], [LOAITIN], [TrangThai]) VALUES (5, N'SALE8          ', N'Mùa hè này không còn nóng nực với điều hoà Shap tiết kiệm điện năng', N'/UploadData/files/Homepage%20Top%20Slide%20Banner_1008x405px-01.jpg', N'Một thực tế đã có từ lâu rằng người đọc sẽ bị phân tâm bởi nội dung có thể đọc được của một trang khi nhìn vào bố cục của nó. Điểm sử dụngLorem Ipsumlà nó có sự phân bố bình thường ít nhiều của các chữ cái, trái ngược với việc sử dụng ''Nội dung ở đây, nội dung ở đây'', khiến nó trông giống như tiếng Anh có thể đọc được. Nhiều gói xuất bản trên máy tính để bàn và trình chỉnh sửa trang web hiện sử dụng Lorem Ipsum làm văn bản mẫu mặc định của họ và tìm kiếm ''lorem ipsum'' sẽ phát hiện ra nhiều trang web vẫn còn sơ khai. Nhiều phiên bản khác nhau đã phát triển qua nhiều năm, đôi khi là do tình cờ, đôi khi là có chủ đích (tiêm chất hài hước và những thứ tương tự).Trái với suy nghĩ của nhiều người, Lorem Ipsum không chỉ đơn giản là văn bản ngẫu nhiên. Nó có nguồn gốc từ một tác phẩm văn học Latinh cổ điển từ năm 45 trước Công nguyên, khiến nó hơn 2000 năm tuổi. Richard McClintock, một giáo sư tiếng Latinh tại Đại học Hampden-Sydney ở Virginia, đã tra cứu một trong những từ Latinh khó hiểu hơn, consectetur, từ một đoạn văn của Lorem Ipsum, và xem qua các trích dẫn của từ này trong văn học cổ điển, đã phát hiện ra nguồn gốc không thể chối cãi. Lorem Ipsum xuất phát từ phần 1.10.32 và 1.10.33 của "de Finibus Bonorum et Malorum" (Cực đoan của Thiện và Ác) của Cicero, được viết vào năm 45 trước Công nguyên. Cuốn sách này là một chuyên luận về lý thuyết đạo đức, rất phổ biến trong thời kỳ Phục hưng. Dòng đầu tiên của Lorem Ipsum, "Lorem ipsum dolor sit amet ..", xuất phát từ một dòng trong phần 1.10.32.', CAST(N'2021-07-08' AS Date), N'Mùa "Cô vy" ở nhà cũng mua được hàng kèm theo nhiều ưu đãi hấp dẫn.', N'Sale8', 1)
INSERT [dbo].[tintuc] ([ID], [MATIN], [TIEUDE], [ANH], [NOIDUNG], [NGAYDANG], [NDNGAN], [LOAITIN], [TrangThai]) VALUES (6, N'SALE9          ', N'Tháng 7 tràn ngập giảm giá cực sốc khi mua hàng', N'/UploadData/files/MDA_SANSALE_1008x405.jpg', N'Một thực tế đã có từ lâu rằng người đọc sẽ bị phân tâm bởi nội dung có thể đọc được của một trang khi nhìn vào bố cục của nó. Điểm sử dụngLorem Ipsumlà nó có sự phân bố bình thường ít nhiều của các chữ cái, trái ngược với việc sử dụng ''Nội dung ở đây, nội dung ở đây'', khiến nó trông giống như tiếng Anh có thể đọc được. Nhiều gói xuất bản trên máy tính để bàn và trình chỉnh sửa trang web hiện sử dụng Lorem Ipsum làm văn bản mẫu mặc định của họ và tìm kiếm ''lorem ipsum'' sẽ phát hiện ra nhiều trang web vẫn còn sơ khai. Nhiều phiên bản khác nhau đã phát triển qua nhiều năm, đôi khi là do tình cờ, đôi khi là có chủ đích (tiêm chất hài hước và những thứ tương tự).Trái với suy nghĩ của nhiều người, Lorem Ipsum không chỉ đơn giản là văn bản ngẫu nhiên. Nó có nguồn gốc từ một tác phẩm văn học Latinh cổ điển từ năm 45 trước Công nguyên, khiến nó hơn 2000 năm tuổi. Richard McClintock, một giáo sư tiếng Latinh tại Đại học Hampden-Sydney ở Virginia, đã tra cứu một trong những từ Latinh khó hiểu hơn, consectetur, từ một đoạn văn của Lorem Ipsum, và xem qua các trích dẫn của từ này trong văn học cổ điển, đã phát hiện ra nguồn gốc không thể chối cãi. Lorem Ipsum xuất phát từ phần 1.10.32 và 1.10.33 của "de Finibus Bonorum et Malorum" (Cực đoan của Thiện và Ác) của Cicero, được viết vào năm 45 trước Công nguyên. Cuốn sách này là một chuyên luận về lý thuyết đạo đức, rất phổ biến trong thời kỳ Phục hưng. Dòng đầu tiên của Lorem Ipsum, "Lorem ipsum dolor sit amet ..", xuất phát từ một dòng trong phần 1.10.32.', CAST(N'2021-07-08' AS Date), N'Mùa "Cô vy" ở nhà cũng mua được hàng kèm theo nhiều ưu đãi hấp dẫn.', N'Sale8', 1)
SET IDENTITY_INSERT [dbo].[tintuc] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Name], [Address], [Email], [Phone], [TrangThai], [Quyen]) VALUES (1, N'admin', N'202cb962ac59075b964b07152d234b70', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Name], [Address], [Email], [Phone], [TrangThai], [Quyen]) VALUES (4, N'admin1', N'e10adc3949ba59abbe56e057f20f883e', N'Lại Văn Biên', N'Nhà văn hoá thôn chằm xã Liêm Thuận', N'bienlai10@gmail.com', N'0877041914', 1, 0)
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Name], [Address], [Email], [Phone], [TrangThai], [Quyen]) VALUES (5, N'admin2', N'e10adc3949ba59abbe56e057f20f883e', N'a a', N'Hà nam', N'bienlai1@gmail.com', N'123456789', 1, 0)
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Name], [Address], [Email], [Phone], [TrangThai], [Quyen]) VALUES (6, N'admin3', N'123456', N'a a', N'Hà nam', N'bienlai1001@gmail.com', N'123456789', 1, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [do_gia_dung] SET  READ_WRITE 
GO
