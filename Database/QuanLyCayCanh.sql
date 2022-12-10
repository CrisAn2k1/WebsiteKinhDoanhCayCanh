USE [master]
GO
/****** Object:  Database [QuanLyCayCanh]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE DATABASE [QuanLyCayCanh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCayCanh', FILENAME = N'D:\Database\QuanLyCayCanh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyCayCanh_log', FILENAME = N'D:\Database\QuanLyCayCanh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyCayCanh] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCayCanh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCayCanh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyCayCanh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCayCanh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCayCanh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyCayCanh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCayCanh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyCayCanh] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCayCanh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCayCanh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCayCanh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCayCanh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyCayCanh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyCayCanh] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyCayCanh] SET QUERY_STORE = OFF
GO
USE [QuanLyCayCanh]
GO
/****** Object:  User [CrisDame]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE USER [CrisDame] FOR LOGIN [CrisDame] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [CrisDame]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[id_BinhLuan] [int] IDENTITY(1,1) NOT NULL,
	[ngayDangBinhLuan] [datetime] NULL,
	[noiDung] [nvarchar](250) NULL,
	[trangThai] [bit] NULL,
	[id_User] [nvarchar](128) NULL,
	[id_SP] [varchar](10) NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[id_BinhLuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CachChamSoc]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CachChamSoc](
	[id_CCS] [varchar](10) NOT NULL,
	[tuoiNuoc] [ntext] NULL,
	[dat] [ntext] NULL,
	[anhSang] [ntext] NULL,
	[viTriDatCay] [ntext] NULL,
	[duongChat] [ntext] NULL,
	[tenCCS] [nvarchar](50) NULL,
 CONSTRAINT [PK_CachChamSoc] PRIMARY KEY CLUSTERED 
(
	[id_CCS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTCapNhat]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTCapNhat](
	[id_CTCN] [bigint] IDENTITY(1,1) NOT NULL,
	[id_User] [nvarchar](128) NOT NULL,
	[id_SP] [varchar](10) NOT NULL,
	[ngayCapNhat] [datetime] NULL,
	[thaoTac] [nvarchar](50) NULL,
 CONSTRAINT [PK_CTCapNhat_1] PRIMARY KEY CLUSTERED 
(
	[id_CTCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTDH]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDH](
	[id_DH] [int] NOT NULL,
	[id_SP] [varchar](10) NOT NULL,
	[soLuong] [int] NULL,
	[thanhTien] [bigint] NULL,
 CONSTRAINT [PK_CTDH] PRIMARY KEY CLUSTERED 
(
	[id_DH] ASC,
	[id_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[id_DanhGia] [int] IDENTITY(1,1) NOT NULL,
	[soSao] [int] NULL,
	[ngayDG] [datetime] NULL,
	[trangThai] [char](1) NULL,
	[id_User] [nvarchar](128) NULL,
	[id_SP] [varchar](10) NULL,
 CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED 
(
	[id_DanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[id_DH] [int] IDENTITY(1,1) NOT NULL,
	[ngayDat] [date] NULL,
	[ngayGiao] [date] NULL,
	[trangThaiThanhToan] [bit] NULL,
	[trangThaiGiaoHang] [char](1) NULL,
	[phuongThucThanhToan] [char](1) NULL,
	[tongTien] [bigint] NULL,
	[diaChiGiao] [nvarchar](250) NULL,
	[id_User] [nvarchar](128) NULL,
	[id_Voucher] [varchar](10) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[id_DH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HinhAnhSP]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnhSP](
	[id_Hinh] [int] IDENTITY(1,1) NOT NULL,
	[duongDan] [varchar](250) NULL,
	[id_SP] [varchar](10) NULL,
 CONSTRAINT [PK_HinhAnhSP] PRIMARY KEY CLUSTERED 
(
	[id_Hinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomSP]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomSP](
	[id_Nhom] [varchar](10) NOT NULL,
	[tenNhom] [nvarchar](50) NULL,
	[id_CCS] [varchar](10) NULL,
 CONSTRAINT [PK_NhomSP] PRIMARY KEY CLUSTERED 
(
	[id_Nhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[id_SP] [varchar](10) NOT NULL,
	[tenSP] [nvarchar](50) NULL,
	[mota] [nvarchar](250) NULL,
	[gia] [bigint] NULL,
	[soLuong] [int] NULL,
	[DVT] [nvarchar](10) NULL,
	[phanTramGiamGia] [int] NULL,
	[id_Nhom] [varchar](10) NULL,
	[trangThai] [bit] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[id_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinThemVeSP]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinThemVeSP](
	[id_SP] [varchar](10) NOT NULL,
	[congDung] [nvarchar](255) NULL,
	[cachTrong] [nvarchar](255) NULL,
 CONSTRAINT [PK_ThongTinThemVeSP] PRIMARY KEY CLUSTERED 
(
	[id_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](128) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserVoucher]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVoucher](
	[id_voucher] [varchar](10) NOT NULL,
	[id_User] [nvarchar](128) NOT NULL,
	[soLuotConLai] [int] NULL,
 CONSTRAINT [PK_UserVoucher] PRIMARY KEY CLUSTERED 
(
	[id_voucher] ASC,
	[id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 10/12/2022 11:42:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[id_voucher] [varchar](10) NOT NULL,
	[tenVoucher] [nvarchar](50) NULL,
	[noiDung] [nvarchar](250) NULL,
	[phanTramGiamGia] [int] NULL,
	[thoiGianBatDau] [smalldatetime] NULL,
	[thoiGianKetThuc] [smalldatetime] NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[id_voucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BinhLuan] ON 

INSERT [dbo].[BinhLuan] ([id_BinhLuan], [ngayDangBinhLuan], [noiDung], [trangThai], [id_User], [id_SP]) VALUES (1, CAST(N'2022-11-20T21:55:46.723' AS DateTime), N'Sản phẩm đẹp ', 1, N'4666529f-6975-4e91-b14a-a7708c8bc87c', N'CTS01')
INSERT [dbo].[BinhLuan] ([id_BinhLuan], [ngayDangBinhLuan], [noiDung], [trangThai], [id_User], [id_SP]) VALUES (2, CAST(N'2022-11-20T22:20:49.473' AS DateTime), N'Sản phẩm quá đẹp ', 1, N'4666529f-6975-4e91-b14a-a7708c8bc87c', N'CDB02')
SET IDENTITY_INSERT [dbo].[BinhLuan] OFF
GO
INSERT [dbo].[CachChamSoc] ([id_CCS], [tuoiNuoc], [dat], [anhSang], [viTriDatCay], [duongChat], [tenCCS]) VALUES (N'CaySenDa', N'Cây tưới ít nước thôi', N'Dùng đất cát, sỏi.', N'Để nơi có ánh sáng vừa đủ.', N'Đặt nơi khô ráo tránh mưa nhiều', N'Bón phân vừa đủ cho cây phát triển', N'Cách chăm sóc cây sen đá')
INSERT [dbo].[CachChamSoc] ([id_CCS], [tuoiNuoc], [dat], [anhSang], [viTriDatCay], [duongChat], [tenCCS]) VALUES (N'CCS01CDB', N'Mỗi ngày tưới qua cho cây để thứ nhất là rửa sạch bụi trên lá giúp cây dễ quang hợp hơn, thông thoáng hơn, và thường tưới và buổi sáng sớm hoặc chiều tối, tránh tưới buổi trưa nắng nóng dễ làm cây sốc nhiệt mà chết. Nhưng thường cây được để ở môi trường văn phòng, có máy lạnh, hoặc trong nhà ít nắng, thiếu gió nên nước có tốc độ bay hơi thấp, đất giữ ẩm lâu. Vì vậy bạn chỉ nên tưới nước 1 tuần/ 2 lần mỗi lần đủ ẩm 1/2 đất là được. Chỉ nên tưới ở gốc còn lá nếu bẩn thì nên dùng khăn ướt lau.', N'Loại đất trồng sẵn ở cây thường đã là loại đất tốt có nhiều mùn đảm bảo cho cây phát triển tốt trong vòng 3 đến 6 tháng. Nếu trồng lâu thấy hiện tượng vàng lá do thiếu chất bạn có thể bổ sung đất, mùn, thay đất cho cây hoặc các đơn giản là mua đạm, phân bón tan chậm rắc nên gốc cây là được.', N'Sống được trong môi trường thiếu sáng nhưng màu sắc của lá sẽ bớt đậm và xanh tươi, vì thế cuối tuần bạn nên để cây ra ngoài hiên để cây có thể tiếp xúc trực tiếp với nắng gió ngoài trời, còn không tốt nhất hay để cây gần cửa sổ nơi có ánh sáng chiếu qua.', N'Vị trí đặt cây là rất quan trọng ảnh hưởng lớn đến sự phát triển và sống của cây văn phòng, cây trong nhà. Vị trí đặt cây tốt nhất là nơi thoáng mát có ánh nắng nhẹ. Nếu bạn thấy cây phải buộc đặt nơi khuất, tối tăm, ít thoáng thì bạn nên để cây ở nơi thoáng có ánh nắng nhẹ hoặc dưới ánh điện.', N'Bón phân vừa đủ cho cây phát triển.', N'Cách chăm sóc cây để bàn')
INSERT [dbo].[CachChamSoc] ([id_CCS], [tuoiNuoc], [dat], [anhSang], [viTriDatCay], [duongChat], [tenCCS]) VALUES (N'CCS01CTN', N'Thường nếu để cây ở ngoài trời có nắng và gió thì ngày nào bạn tưới nước cũng được, mỗi ngày tưới qua cho cây để thứ nhất là rửa sạch bụi trên lá giúp cây dễ quang hợp hơn, thông thoáng hơn, và thường tưới và buổi sáng sớm hoặc chiều tối, tránh tưới buổi trưa nắng nóng dễ làm cây sốc nhiệt mà chết. Nhưng thường cây được để ở môi trường văn phòng, có máy lạnh, hoặc trong nhà ít nắng, thiếu gió nên nước có tốc độ bay hơi thấp, đất giữ ẩm lâu. Vì vậy bạn chỉ nên tưới nước 1 tuần/ 2 lần mỗi lần đủ ẩm 1/2 đất là được. Chỉ nên tưới ở gốc còn lá nếu bẩn thì nên dùng khăn ướt lau.', N'Loại đất trồng sẵn ở cây thường đã là loại đất tốt có nhiều mùn đảm bảo cho cây phát triển tốt trong vòng 3 đến 6 tháng. Nếu trồng lâu thấy hiện tượng vàng lá do thiếu chất bạn có thể bổ sung đất, mùn, thay đất cho cây hoặc các đơn giản là mua đạm, phân bón tan chậm rắc nên gốc cây là được.', N'Sống được trong môi trường thiếu sáng nhưng màu sắc của lá sẽ bớt đậm và xanh tươi, vì thế cuối tuần bạn nên để cây ra ngoài hiên để cây có thể tiếp xúc trực tiếp với nắng gió ngoài trời, còn không tốt nhất hay để cây gần cửa sổ nơi có ánh sáng chiếu qua.', N'Vị trí đặt cây là rất quan trọng ảnh hưởng lớn đến sự phát triển và sống của cây văn phòng, cây trong nhà. Vị trí đặt cây tốt nhất là nơi thoáng mát có ánh nắng nhẹ. Nếu bạn thấy cây phải buộc đặt nơi khuất, tối tăm, ít thoáng thì bạn nên để cây ở nơi thoáng có ánh nắng nhẹ hoặc dưới ánh điện.', N'Bón phân vừa đủ cho cây phát triển.', N'Cách chăm sóc cây trong nhà')
INSERT [dbo].[CachChamSoc] ([id_CCS], [tuoiNuoc], [dat], [anhSang], [viTriDatCay], [duongChat], [tenCCS]) VALUES (N'CCS02CTS', N'Bạn cần để ý nước của cây thủy sinh, nhất là thời gian ban đầu nếu nước có mùi thì bạn cần thay nước luôn và loại bỏ rễ thối. Nếu bạn không có thời gian để ý thì thời điểm ban đầu cứ 1 tuần bạn thay nước một lần.  Khi thay nước nên đổ nước đi, đổ nước lại nhiều lần để tạo không khí trong nước, cây sẽ phát triển rễ tốt hơn.', N'Cây thủy sinh', N'Sống được trong môi trường thiếu sáng nhưng màu sắc của lá sẽ bớt đậm và xanh tươi, vì thế cuối tuần bạn nên để cây ra ngoài hiên để cây có thể tiếp xúc trực tiếp với nắng gió ngoài trời, còn không tốt nhất hay để cây gần cửa sổ nơi có ánh sáng chiếu qua.', N'. Vị trí đặt cây tốt nhất là nơi thoáng mát có ánh nắng nhẹ. Nếu bạn thấy cây phải buộc đặt nơi khuất, tối tăm, ít thoáng thì bạn nên để cây ở nơi thoáng có ánh nắng nhẹ hoặc dưới ánh điện.', N'Bạn cần thêm dung dịch thủy canh vào hàng tuần để giúp cây có đủ chất dinh dưỡng, sao cho PPM( nồng độ dung dịch dinh dưỡng ) trong nước trong khoảng từ 600 -1000 ppm là được. PH dao động từ 5,5 đến 6,5.', N'Cách chăm sóc cây thủy sinh')
GO
SET IDENTITY_INSERT [dbo].[CTCapNhat] ON 

INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (2, N'4666529f-6975-4e91-b14a-a7708c8bc87c', N'CTN01', CAST(N'2022-11-08T11:27:25.000' AS DateTime), N'Sửa')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (3, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-19T20:20:23.397' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (4, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-19T20:33:10.673' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (5, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB02', CAST(N'2022-11-19T20:43:12.793' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (6, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS02', CAST(N'2022-11-20T09:59:45.917' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (7, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:12:15.100' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (8, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:12:22.840' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (9, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:13:00.013' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (10, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:20:14.513' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (11, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:34:08.153' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (12, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:34:15.293' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (13, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:34:57.397' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (14, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:35:24.600' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (15, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:39:16.517' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (16, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:42:41.127' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (17, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB02', CAST(N'2022-11-20T11:44:50.373' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (18, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS02', CAST(N'2022-11-20T11:45:30.337' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (19, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS02', CAST(N'2022-11-20T11:55:38.853' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (20, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB02', CAST(N'2022-11-20T11:55:50.340' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (21, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-20T11:57:48.003' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (22, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS02', CAST(N'2022-11-20T12:01:38.950' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (23, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-24T15:59:04.347' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (24, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS02', CAST(N'2022-11-24T16:00:44.757' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (25, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-24T16:01:30.923' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (26, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'SD02', CAST(N'2022-11-24T17:28:05.763' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (27, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB03', CAST(N'2022-11-24T17:30:44.107' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (28, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-24T21:35:18.110' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (29, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-11-24T21:37:12.580' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (30, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CSD01', CAST(N'2022-11-25T11:16:23.160' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (31, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CSD01', CAST(N'2022-11-25T20:29:04.013' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (32, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS03', CAST(N'2022-11-26T10:52:21.637' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (33, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS02', CAST(N'2022-11-26T10:52:44.330' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (34, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTS04', CAST(N'2022-11-26T10:53:52.610' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (35, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CSD03', CAST(N'2022-11-26T10:57:17.987' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (36, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CSD04', CAST(N'2022-11-26T10:58:42.673' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (37, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB04', CAST(N'2022-11-26T11:01:26.393' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (38, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CSD01', CAST(N'2022-11-26T14:11:58.293' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (39, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTN05', CAST(N'2022-12-05T20:29:06.527' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (40, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTN06', CAST(N'2022-12-05T20:30:36.313' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (41, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTN07', CAST(N'2022-12-05T20:32:03.807' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (42, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTN08', CAST(N'2022-12-05T20:37:21.077' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (43, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CTN08', CAST(N'2022-12-05T20:39:31.213' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (44, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CXR01', CAST(N'2022-12-05T20:47:21.257' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (45, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CXR02', CAST(N'2022-12-05T20:48:26.187' AS DateTime), N'Create')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (46, N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'CDB01', CAST(N'2022-12-05T20:50:47.557' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (47, N'759139e0-612c-48e4-b920-7cf084ecb96e', N'CDB01', CAST(N'2022-12-08T22:59:21.230' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (48, N'759139e0-612c-48e4-b920-7cf084ecb96e', N'CDB01', CAST(N'2022-12-08T22:59:32.793' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (49, N'759139e0-612c-48e4-b920-7cf084ecb96e', N'CDB01', CAST(N'2022-12-08T23:05:36.840' AS DateTime), N'Update')
INSERT [dbo].[CTCapNhat] ([id_CTCN], [id_User], [id_SP], [ngayCapNhat], [thaoTac]) VALUES (50, N'759139e0-612c-48e4-b920-7cf084ecb96e', N'CDB01', CAST(N'2022-12-09T01:27:55.423' AS DateTime), N'Update')
SET IDENTITY_INSERT [dbo].[CTCapNhat] OFF
GO
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (12, N'CTS01', 1, 99000)
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (13, N'CDB02', 1, 100000)
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (14, N'CTS01', 1, 99000)
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (15, N'CDB03', 1, 180000)
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (16, N'CDB03', 1, 180000)
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (16, N'SD02', 1, 120000)
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (17, N'CDB01', 1, 10200)
INSERT [dbo].[CTDH] ([id_DH], [id_SP], [soLuong], [thanhTien]) VALUES (18, N'CDB01', 1, 82170)
GO
SET IDENTITY_INSERT [dbo].[DanhGia] ON 

INSERT [dbo].[DanhGia] ([id_DanhGia], [soSao], [ngayDG], [trangThai], [id_User], [id_SP]) VALUES (1, 5, CAST(N'2022-11-20T22:20:28.053' AS DateTime), NULL, N'4666529f-6975-4e91-b14a-a7708c8bc87c', N'CDB02')
SET IDENTITY_INSERT [dbo].[DanhGia] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([id_DH], [ngayDat], [ngayGiao], [trangThaiThanhToan], [trangThaiGiaoHang], [phuongThucThanhToan], [tongTien], [diaChiGiao], [id_User], [id_Voucher]) VALUES (12, CAST(N'2022-11-20' AS Date), CAST(N'2022-11-21' AS Date), 1, N'1', N'0', 99000, N'19/25 Đường 102 TP HCM', N'4666529f-6975-4e91-b14a-a7708c8bc87c', NULL)
INSERT [dbo].[DonHang] ([id_DH], [ngayDat], [ngayGiao], [trangThaiThanhToan], [trangThaiGiaoHang], [phuongThucThanhToan], [tongTien], [diaChiGiao], [id_User], [id_Voucher]) VALUES (13, CAST(N'2022-11-20' AS Date), CAST(N'2022-11-21' AS Date), 1, N'2', N'0', 100000, N'19/25 Đường 102 TP HCM', N'4666529f-6975-4e91-b14a-a7708c8bc87c', NULL)
INSERT [dbo].[DonHang] ([id_DH], [ngayDat], [ngayGiao], [trangThaiThanhToan], [trangThaiGiaoHang], [phuongThucThanhToan], [tongTien], [diaChiGiao], [id_User], [id_Voucher]) VALUES (14, CAST(N'2022-11-23' AS Date), CAST(N'2022-11-23' AS Date), 1, N'2', N'0', 99000, NULL, N'4666529f-6975-4e91-b14a-a7708c8bc87c', NULL)
INSERT [dbo].[DonHang] ([id_DH], [ngayDat], [ngayGiao], [trangThaiThanhToan], [trangThaiGiaoHang], [phuongThucThanhToan], [tongTien], [diaChiGiao], [id_User], [id_Voucher]) VALUES (15, CAST(N'2022-11-24' AS Date), CAST(N'2022-11-25' AS Date), 1, N'1', N'0', 180000, N'19/25 Đường 102 Bình Thạnh TP HCM', N'4666529f-6975-4e91-b14a-a7708c8bc87c', NULL)
INSERT [dbo].[DonHang] ([id_DH], [ngayDat], [ngayGiao], [trangThaiThanhToan], [trangThaiGiaoHang], [phuongThucThanhToan], [tongTien], [diaChiGiao], [id_User], [id_Voucher]) VALUES (16, CAST(N'2022-11-24' AS Date), CAST(N'2022-11-25' AS Date), 1, N'1', N'0', 300000, N'123 Lạng Sơn Cao Bằng', N'313764dd-e470-4473-9794-0e31ff52aace', NULL)
INSERT [dbo].[DonHang] ([id_DH], [ngayDat], [ngayGiao], [trangThaiThanhToan], [trangThaiGiaoHang], [phuongThucThanhToan], [tongTien], [diaChiGiao], [id_User], [id_Voucher]) VALUES (17, CAST(N'2022-11-24' AS Date), CAST(N'2022-11-26' AS Date), 0, N'0', N'0', 10200, N'123 Lạng Sơn Cao Bằng', N'313764dd-e470-4473-9794-0e31ff52aace', NULL)
INSERT [dbo].[DonHang] ([id_DH], [ngayDat], [ngayGiao], [trangThaiThanhToan], [trangThaiGiaoHang], [phuongThucThanhToan], [tongTien], [diaChiGiao], [id_User], [id_Voucher]) VALUES (18, CAST(N'2022-12-09' AS Date), CAST(N'2022-12-10' AS Date), 1, N'0', N'1', 73953, N'205/45 Huyện Lộ 14, TT Mỹ Xuyên, Mỹ Xuyên, Sóc Trăng', N'759139e0-612c-48e4-b920-7cf084ecb96e', N'VC03')
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[HinhAnhSP] ON 

INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (1, N'/Template/img/cayluoiho.jpg', N'CTN01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (3, N'/Template/img/cayngocngan.jpg', N'CTN03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (4, N'/Template/img/caytieutram.jpg', N'CTN04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (7, N'/Template/img/cayhongmon.jpg', N'CTS01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (8, N'/Template/img/cayngocngan3.jpg', N'CTN03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (9, N'/Template/img/cayngocngan2.jpg', N'CTN03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (10, N'/Template/img/Product/cayluoiho2.jpg', N'CTN01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (11, N'/Template/img/Product/cayluoiho3.jpg', N'CTN01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (12, N'/Template/img/Product/caycauvang2.jpg', N'CTN02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (13, N'/Template/img/Product/caycauvang.jpg', N'CTN02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (14, N'/Template/img/Product/caycauvang3.jpg', N'CTN02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (17, N'/Template/img/Product/cayhuongthao.png', N'CDB01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (18, N'/Template/img/Product/cayhuongthao2.png', N'CDB01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (19, N'/Template/img/Product/cayhuongthao3.png', N'CDB01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (20, N'/Template/img/Product/caynganhau.jpg', N'CDB02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (21, N'/Template/img/Product/caylany.jpg', N'CTS02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (22, N'/Template/img/Product/caylany2.jpg', N'CTS02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (23, N'/Template/img/Product/caylany3.jpg', N'CTS02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (24, N'/Template/img/Product/sendatuphuong.jpg', N'SD02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (25, N'/Template/img/Product/sendatuphuong2.jpg', N'SD02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (26, N'/Template/img/Product/sendatuphuong3.jpg', N'SD02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (27, N'/Template/img/Product/cayvannienthanh.jpg', N'CDB03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (28, N'/Template/img/Product/caytieutram2.jpg', N'CTN04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (29, N'/Template/img/Product/caytieutram3.jpg', N'CTN04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (31, N'/Template/img/Product/sendaruby.jpg', N'CSD01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (32, N'/Template/img/Product/sendaruby2.jpg', N'CSD01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (33, N'/Template/img/Product/sendaruby3.jpg', N'CSD01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (34, N'/Template/img/Product/cayphuquydo.jpg', N'CTS03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (35, N'/Template/img/Product/caytrauba.jpg', N'CTS04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (38, N'/Template/img/Product/caytrauba3.jpg', N'CTS04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (39, N'/Template/img/Product/caytrauba2.jpg', N'CTS04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (40, N'/Template/img/Product/sendamongrong.jpg', N'CSD03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (43, N'/Template/img/Product/sendaphatba.jpg', N'CSD04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (44, N'/Template/img/Product/sendaphatba2.jpg', N'CSD04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (45, N'/Template/img/Product/sendaphatba3.jpg', N'CSD04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (49, N'/Template/img/Product/caykimngan.jpg', N'CTN05')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (50, N'/Template/img/Product/caykimtien.jpg', N'CTN06')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (51, N'/Template/img/Product/caythietmoclan.jpg', N'CTN07')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (52, N'/Template/img/Product/caythietmoclan1.jpg', N'CTN07')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (53, N'/Template/img/Product/caythietmoclan3.jpg', N'CTN07')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (54, N'/Template/img/Product/caykimtien2.png', N'CTN06')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (55, N'/Template/img/Product/caykimtien3.jpg', N'CTN06')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (56, N'/Template/img/Product/caykimngan2.jpg', N'CTN05')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (57, N'/Template/img/Product/caykimngan3.jpg', N'CTN05')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (58, N'/Template/img/Product/cayphonglochoa.jpg', N'CTN08')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (59, N'/Template/img/Product/cayphonglochoa2.jpg', N'CTN08')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (60, N'/Template/img/Product/cayphonglochoa3.jpg', N'CTN08')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (61, N'/Template/img/Product/xuongrongthanhson.jpg', N'CXR01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (62, N'/Template/img/Product/xuongrongtho.jpg', N'CXR02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (63, N'/Template/img/Product/xuongrongtho2.jpg', N'CXR02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (64, N'/Template/img/Product/xuongrongtho3.jpg', N'CXR02')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (65, N'/Template/img/Product/xuongrongthanhson2.jpg', N'CXR01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (66, N'/Template/img/Product/xuongrongthanhson3.jpg', N'CXR01')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (68, N'/Template/img/Product/caytraubadevuong2.jpg', N'CDB04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (69, N'/Template/img/Product/caytraubadevuong.jpg', N'CDB04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (70, N'/Template/img/Product/caytraubadevuong3.jpg', N'CDB04')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (72, N'/Template/img/Product/cayphuquydo2.jpg', N'CTS03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (73, N'/Template/img/Product/cayphuquydo3.jpg', N'CTS03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (75, N'/Template/img/Product/sendamongrong2.jpg', N'CSD03')
INSERT [dbo].[HinhAnhSP] ([id_Hinh], [duongDan], [id_SP]) VALUES (76, N'/Template/img/Product/sendamongrong3.jpg', N'CSD03')
SET IDENTITY_INSERT [dbo].[HinhAnhSP] OFF
GO
INSERT [dbo].[NhomSP] ([id_Nhom], [tenNhom], [id_CCS]) VALUES (N'CDB', N'Cây để bàn', N'CCS01CDB')
INSERT [dbo].[NhomSP] ([id_Nhom], [tenNhom], [id_CCS]) VALUES (N'CSD', N'Cây sen đá', N'CaySenDa')
INSERT [dbo].[NhomSP] ([id_Nhom], [tenNhom], [id_CCS]) VALUES (N'CTN', N'Cây trong nhà', N'CCS01CTN')
INSERT [dbo].[NhomSP] ([id_Nhom], [tenNhom], [id_CCS]) VALUES (N'CTS', N'Cây thủy sinh', N'CCS02CTS')
INSERT [dbo].[NhomSP] ([id_Nhom], [tenNhom], [id_CCS]) VALUES (N'CXR', N'Cây xương rồng', N'CaySenDa')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'1', N'admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'2', N'user ')
GO
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CDB01', N'Cây Hương thảo', N'Cây cảnh thích hợp để bàn, trang trí nhà cửa', 99000, 104, N'Chậu', 17, N'CDB', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CDB02', N'Cây Ngân hậu', N'Cây cảnh nhỏ thích hợp để bàn, trang trí nhà cửa, văn phòng', 100000, 8, N'chậu', 0, N'CDB', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CDB03', N'Cây vạn niên thanh', N'Cây để bàn trong nhà, văn phòng kích thước nhỏ', 200000, 18, N'chậu', 10, N'CDB', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CDB04', N'Cây trầu bà đế vương', N'Cây cảnh để bàn trang trí trong nhà, văn phòng.', 200000, 20, N'chậu', 15, N'CDB', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CSD01', N'Sen ruby', N'Cây sen đá nhỏ thích hợp để bàn', 12000, 5, N'chậu', 0, N'CSD', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CSD03', N'Sen đá móng rồng', N'Cây sen đá nhỏ thích hợp để bàn trang trí nhà cửa', 99000, 10, N'chậu', 0, N'CSD', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CSD04', N'Sen đá phật bà', N'Cây sen đá nhỏ thích hợp để bàn trang trí nhà cửa', 99000, 50, N'chậu', 0, N'CSD', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN01', N'Cây lưỡi hổ vàng pro', N'Cây trong nhà, văn phòng', 150000, 10, N'chậu', 10, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN02', N'Cây cau vàng', N'Cây trong nhà, văn phòng', 150000, 9, N'chậu', 10, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN03', N'Cây ngọc ngân', N'Cây trong nhà, van phòng', 100000, 10, N'chậu', 0, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN04', N'Cây tiểu trâm', N'Cây trong nhà, van phòng', 250000, 10, N'chậu', 20, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN05', N'Cây kim ngân', N'Cây cảnh trong nhà, văn phòng kích thước trung bình trang trí nhà cửa', 234000, 100, N'chậu', 10, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN06', N'Cây kim tiền', N'Cây trong nhà, văn phòng ', 123000, 100, N'chậu', 0, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN07', N'Cây thiết mộc lan', N'Cây cảnh trong nhà, văn phòng kích thước trung bình trang trí nhà cửa', 300000, 100, N'chậu', 11, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTN08', N'Cây phong lộc hoa', N'Cây cảnh trong nhà, văn phòng kích thước trung bình trang trí nhà cửa', 341000, 100, N'chậu', 12, N'CTN', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTS01', N'Cây hồng môn', N'Cây trong nhà, van phòng, cây thủy sinh', 110000, 8, N'chậu', 10, N'CTS', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTS02', N'Cây Lan ý', N'Cây thủy sinh thích hợp để bàn, trang trí nhà cửa', 120000, 10, N'chậu', 10, N'CTS', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTS03', N'Cây phú quý đỏ', N'Cây thủy sinh thích hợp để bàn, trang trí nhà cửa', 222000, 20, N'chậu', 12, N'CTS', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CTS04', N'Cây trầu bà', N'Cây thủy sinh thích hợp để bàn, trang trí nhà cửa', 100000, 10, N'chậu', 0, N'CTS', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CXR01', N'Xương rồng thanh sơn', N'Cây xương rồng nhỏ thích hợp để bàn', 59000, 100, N'chậu', 0, N'CXR', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'CXR02', N'Xương rồng thỏ', N'Cây xương rồng nhỏ thích hợp để bàn', 69000, 100, N'chậu', 0, N'CXR', 1)
INSERT [dbo].[SanPham] ([id_SP], [tenSP], [mota], [gia], [soLuong], [DVT], [phanTramGiamGia], [id_Nhom], [trangThai]) VALUES (N'SD02', N'Sen đá tứ phương', N'Cây sen đá nhỏ thích hợp để bàn', 120000, 19, N'chậu', 0, N'CSD', 1)
GO
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CDB01', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn', N'Trồng trong chậu đất nhỏ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CDB02', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn   ', N'Trồng trong chậu đất nhỏ   ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CDB03', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CDB04', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CSD01', N'Trang trí bàn học, nhà cửa   ', N'Trồng trong chậu đất   ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CSD03', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất nhỏ ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CSD04', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất nhỏ ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN01', N'Thanh lọc không khí ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN02', N'Thanh lọc không khí  ', N'Trồng trong chậu đất  ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN03', N'Thanh lọc không khí ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN04', N'Thanh lọc không khí ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN05', N'Thanh lọc không khí, trang trí nhà cửa ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN06', N'Thanh lọc không khí, trang trí nhà cửa ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN07', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTN08', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn  ', N'Trồng trong chậu đất  ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTS01', N'Giup thanh l?c không khí, t?o s?c xanh cho ngôi nhà c?a b?n  ', N'Trồng thủy sinh trong chậu nước ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTS02', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn      ', N'Trồng thủy sinh trong chậu nước      ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTS03', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng thủy sinh trong chậu nước ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CTS04', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng thủy sinh trong chậu nước ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CXR01', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất nhỏ ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'CXR02', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất nhỏ ')
INSERT [dbo].[ThongTinThemVeSP] ([id_SP], [congDung], [cachTrong]) VALUES (N'SD02', N'Trang trí bàn học, nhà cửa, tạo sắc xanh cho ngôi nhà của bạn ', N'Trồng trong chậu đất nhỏ ')
GO
INSERT [dbo].[UserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Google', N'107952444835844066045', N'313764dd-e470-4473-9794-0e31ff52aace')
INSERT [dbo].[UserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Google', N'114404637065516781531', N'4666529f-6975-4e91-b14a-a7708c8bc87c')
INSERT [dbo].[UserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Google', N'103142987106782533216', N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4')
INSERT [dbo].[UserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Google', N'106287268621771717428', N'759139e0-612c-48e4-b920-7cf084ecb96e')
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'1477661d-6621-4a5a-90fa-fb4313b37ab5', N'1')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'1')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'759139e0-612c-48e4-b920-7cf084ecb96e', N'1')
GO
INSERT [dbo].[Users] ([Id], [FullName], [Address], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1477661d-6621-4a5a-90fa-fb4313b37ab5', N'NGUYEN TRONG TUAN', N'19/25 Đường 102 TP HCM', N'tuan123@gmail.com', 0, N'ALE8jww8lG8EZTwbueXy4sSnME0dRn2yIn6kWTEu7qa84Idr+q59pKZwHtUMPwjmxw==', N'c9253df5-4031-422d-97c7-ba8429b8b3f7', N'0789654123', 0, 0, NULL, 0, 0, N'tuan123@gmail.com')
INSERT [dbo].[Users] ([Id], [FullName], [Address], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'313764dd-e470-4473-9794-0e31ff52aace', N'Tuấn Nguyễn', N'123 Lạng Sơn Cao Bằng', N'20010511nvt@gmail.com', 0, NULL, N'a2d5d7fb-01bf-4fd0-bd73-4651b3ca3e99', N'0987654321', 0, 0, NULL, 0, 0, N'20010511nvt@gmail.com')
INSERT [dbo].[Users] ([Id], [FullName], [Address], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4666529f-6975-4e91-b14a-a7708c8bc87c', N'Tuan', N'19/25 Đường 102 TP HCM', N'tuantrong.26072001@gmail.com', 0, NULL, N'2a96105c-8322-44e6-ab51-cc9736eff9a8', N'0789654123', 0, 0, NULL, 0, 0, N'tuantrong.26072001@gmail.com')
INSERT [dbo].[Users] ([Id], [FullName], [Address], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', N'Tuấn admin', N'XL Hà Nội', N'tuannguyen267bon@gmail.com', 0, NULL, N'dd9ac122-b26d-4085-bf84-0a236ddb21c7', N'0987654321', 0, 0, NULL, 0, 0, N'tuannguyen267bon@gmail.com')
INSERT [dbo].[Users] ([Id], [FullName], [Address], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'759139e0-612c-48e4-b920-7cf084ecb96e', N'Dương Quốc An', N'205/45 Huyện Lộ 14, TT Mỹ Xuyên, Mỹ Xuyên, Sóc Trăng', N'duongquocan222@gmail.com', 0, NULL, N'148ee561-f9e6-45af-a494-02b9180b162a', N'0335183057', 0, 0, NULL, 0, 0, N'duongquocan222@gmail.com')
GO
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC01', N'313764dd-e470-4473-9794-0e31ff52aace', 1)
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC01', N'4666529f-6975-4e91-b14a-a7708c8bc87c', 5)
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC01', N'759139e0-612c-48e4-b920-7cf084ecb96e', 1)
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC02', N'313764dd-e470-4473-9794-0e31ff52aace', 1)
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC02', N'4666529f-6975-4e91-b14a-a7708c8bc87c', 1)
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC02', N'6ca1ed7a-79e2-4525-ba19-37b54d1759a4', 1)
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC02', N'759139e0-612c-48e4-b920-7cf084ecb96e', 1)
INSERT [dbo].[UserVoucher] ([id_voucher], [id_User], [soLuotConLai]) VALUES (N'VC03', N'759139e0-612c-48e4-b920-7cf084ecb96e', 1)
GO
INSERT [dbo].[Voucher] ([id_voucher], [tenVoucher], [noiDung], [phanTramGiamGia], [thoiGianBatDau], [thoiGianKetThuc]) VALUES (N'VC01', N'Khuyen mai tet', N'Giam gia cho mua tet den', 15, CAST(N'2022-12-11T00:00:00' AS SmallDateTime), CAST(N'2022-12-12T00:00:00' AS SmallDateTime))
INSERT [dbo].[Voucher] ([id_voucher], [tenVoucher], [noiDung], [phanTramGiamGia], [thoiGianBatDau], [thoiGianKetThuc]) VALUES (N'VC02', N'voucher02', N'Giam gia cho mua tet den', 10, CAST(N'2022-12-11T00:00:00' AS SmallDateTime), CAST(N'2022-12-12T00:00:00' AS SmallDateTime))
INSERT [dbo].[Voucher] ([id_voucher], [tenVoucher], [noiDung], [phanTramGiamGia], [thoiGianBatDau], [thoiGianKetThuc]) VALUES (N'VC03', N'Khuyen mai tet', N'Giam gia cho mua tet den 2', 10, CAST(N'2022-11-11T00:00:00' AS SmallDateTime), CAST(N'2022-12-12T00:00:00' AS SmallDateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Roles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/12/2022 11:42:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_SanPham] FOREIGN KEY([id_SP])
REFERENCES [dbo].[SanPham] ([id_SP])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_SanPham]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_Users]
GO
ALTER TABLE [dbo].[CTCapNhat]  WITH CHECK ADD  CONSTRAINT [FK_CTCapNhat_SanPham] FOREIGN KEY([id_SP])
REFERENCES [dbo].[SanPham] ([id_SP])
GO
ALTER TABLE [dbo].[CTCapNhat] CHECK CONSTRAINT [FK_CTCapNhat_SanPham]
GO
ALTER TABLE [dbo].[CTCapNhat]  WITH CHECK ADD  CONSTRAINT [FK_CTCapNhat_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CTCapNhat] CHECK CONSTRAINT [FK_CTCapNhat_Users]
GO
ALTER TABLE [dbo].[CTDH]  WITH CHECK ADD  CONSTRAINT [FK_CTDH_DonHang] FOREIGN KEY([id_DH])
REFERENCES [dbo].[DonHang] ([id_DH])
GO
ALTER TABLE [dbo].[CTDH] CHECK CONSTRAINT [FK_CTDH_DonHang]
GO
ALTER TABLE [dbo].[CTDH]  WITH CHECK ADD  CONSTRAINT [FK_CTDH_SanPham] FOREIGN KEY([id_SP])
REFERENCES [dbo].[SanPham] ([id_SP])
GO
ALTER TABLE [dbo].[CTDH] CHECK CONSTRAINT [FK_CTDH_SanPham]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_SanPham] FOREIGN KEY([id_SP])
REFERENCES [dbo].[SanPham] ([id_SP])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_SanPham]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_Users]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_Users]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_Voucher] FOREIGN KEY([id_Voucher])
REFERENCES [dbo].[Voucher] ([id_voucher])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_Voucher]
GO
ALTER TABLE [dbo].[HinhAnhSP]  WITH CHECK ADD  CONSTRAINT [FK_HinhAnhSP_SanPham] FOREIGN KEY([id_SP])
REFERENCES [dbo].[SanPham] ([id_SP])
GO
ALTER TABLE [dbo].[HinhAnhSP] CHECK CONSTRAINT [FK_HinhAnhSP_SanPham]
GO
ALTER TABLE [dbo].[NhomSP]  WITH CHECK ADD  CONSTRAINT [FK_NhomSP_CachChamSoc] FOREIGN KEY([id_CCS])
REFERENCES [dbo].[CachChamSoc] ([id_CCS])
GO
ALTER TABLE [dbo].[NhomSP] CHECK CONSTRAINT [FK_NhomSP_CachChamSoc]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhomSP] FOREIGN KEY([id_Nhom])
REFERENCES [dbo].[NhomSP] ([id_Nhom])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhomSP]
GO
ALTER TABLE [dbo].[ThongTinThemVeSP]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinThemVeSP_SanPham] FOREIGN KEY([id_SP])
REFERENCES [dbo].[SanPham] ([id_SP])
GO
ALTER TABLE [dbo].[ThongTinThemVeSP] CHECK CONSTRAINT [FK_ThongTinThemVeSP_SanPham]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserClaims_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_dbo.UserClaims_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserLogins_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_dbo.UserLogins_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRoles_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_dbo.UserRoles_dbo.Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRoles_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_dbo.UserRoles_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[UserVoucher]  WITH CHECK ADD  CONSTRAINT [FK_UserVoucher_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserVoucher] CHECK CONSTRAINT [FK_UserVoucher_Users]
GO
ALTER TABLE [dbo].[UserVoucher]  WITH CHECK ADD  CONSTRAINT [FK_UserVoucher_Voucher] FOREIGN KEY([id_voucher])
REFERENCES [dbo].[Voucher] ([id_voucher])
GO
ALTER TABLE [dbo].[UserVoucher] CHECK CONSTRAINT [FK_UserVoucher_Voucher]
GO
USE [master]
GO
ALTER DATABASE [QuanLyCayCanh] SET  READ_WRITE 
GO
