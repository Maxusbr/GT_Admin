USE [master]
GO
/****** Object:  Database [Getticket]    Script Date: 12.07.2016 19:48:42 ******/
CREATE DATABASE [Getticket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Getticket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Getticket.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Getticket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Getticket_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Getticket] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Getticket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Getticket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Getticket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Getticket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Getticket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Getticket] SET ARITHABORT OFF 
GO
ALTER DATABASE [Getticket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Getticket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Getticket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Getticket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Getticket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Getticket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Getticket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Getticket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Getticket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Getticket] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Getticket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Getticket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Getticket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Getticket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Getticket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Getticket] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Getticket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Getticket] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Getticket] SET  MULTI_USER 
GO
ALTER DATABASE [Getticket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Getticket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Getticket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Getticket] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Getticket] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Getticket]
GO
/****** Object:  Table [dbo].[AccessRoles]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_AccessRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Adress]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adress](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Adress] [varchar](1000) NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CountryPlaces]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CountryPlaces](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Country] [int] NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_CountryPlaces] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Event](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [varchar](1000) NOT NULL,
	[id_PlaceHall] [int] NOT NULL,
	[DateStartSold] [datetime] NOT NULL,
	[DateStopSold] [datetime] NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[id_Style] [int] NOT NULL,
	[TicketReturn] [datetime] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Event] [int] NOT NULL,
	[id_User] [int] NOT NULL,
	[Changefrom] [varchar](max) NOT NULL,
	[ChangeTo] [varchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_EventLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventLogs]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ChengeFrom] [nvarchar](max) NOT NULL,
	[ChangeTo] [nvarchar](max) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Event_Id] [int] NOT NULL,
 CONSTRAINT [PK_EventLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateStartSold] [datetime] NOT NULL,
	[DateStopSold] [datetime] NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[TicketReturn] [datetime] NOT NULL,
	[Platform_Id] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventStyle]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventStyle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_EventStyle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InviteCodes]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InviteCodes](
	[Id] [int] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[ActiveTo] [datetime] NOT NULL,
 CONSTRAINT [PK_InviteCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderLog]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLog](
	[Date] [datetime] NOT NULL,
	[id_Order] [int] NOT NULL,
	[id_OrderStatus] [int] NOT NULL,
 CONSTRAINT [PK_OrderLog] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] NOT NULL,
	[id_Ticket] [int] NOT NULL,
	[id_Customer] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[id_Status] [int] NOT NULL,
	[Cost] [money] NOT NULL,
	[id_PaymentMethod] [int] NOT NULL,
	[DatePay] [datetime] NOT NULL,
	[isClosed] [bit] NOT NULL,
	[isDelivered] [bit] NOT NULL,
	[isPaper] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Patronymic] [nvarchar](max) NOT NULL,
	[Bithday] [date] NOT NULL,
	[id_Bithplace] [int] NOT NULL,
	[id_Sex] [int] NOT NULL,
	[NameLatin] [nvarchar](max) NOT NULL,
	[LastNameLatin] [nvarchar](max) NOT NULL,
	[PatronymicLatin] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonAntro]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonAntro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Person] [int] NOT NULL,
	[id_Antro] [int] NOT NULL,
	[Value] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PersonAntro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonAntroNames]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonAntroNames](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PersonAntroNames] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonChangeLog]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonChangeLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Person] [int] NOT NULL,
	[id_ChangeParam] [int] NOT NULL,
	[ChangeFrom] [varchar](max) NOT NULL,
	[ChangeTo] [varchar](max) NOT NULL,
	[id_WhoChange] [int] NULL,
 CONSTRAINT [PK_PersonChangeLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonChangeParam]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonChangeParam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PersonChangeParam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonConnections]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonConnections](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Person] [int] NOT NULL,
	[id_ConnectionType] [int] NOT NULL,
	[id_PersonConnectTo] [int] NULL,
	[id_Event] [int] NOT NULL,
 CONSTRAINT [PK_PersonConnections] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonConnectionType]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonConnectionType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_PersonConnectionType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonDescriptions]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonDescriptions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Person] [int] NOT NULL,
	[id_DescriptionType] [int] NOT NULL,
	[DescriptionText] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PersonDescriptions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonDescriptionType]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonDescriptionType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PersonTextType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonMedia]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonMedia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Person] [int] NOT NULL,
	[MediaLink] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PersonMedia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonSocialLinks]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonSocialLinks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Person] [int] NOT NULL,
	[id_SocialMedia] [int] NOT NULL,
	[Link] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PersonSocialLinks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonSocialLinkTypes]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonSocialLinkTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PersonSocialLinkTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Place]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Place](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[id_Adress] [int] NOT NULL,
 CONSTRAINT [PK_Place] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlaceHall]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlaceHall](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[id_PlaceKorp] [int] NOT NULL,
 CONSTRAINT [PK_PlaceHall] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlaceKorp]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlaceKorp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Korp] [varchar](500) NOT NULL,
	[id_Place] [int] NOT NULL,
 CONSTRAINT [PK_PlaceKorp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlacePart]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlacePart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PartName] [varchar](200) NOT NULL,
	[id_Hall] [int] NOT NULL,
	[PartInsights] [varchar](max) NOT NULL,
	[Floor] [int] NOT NULL,
 CONSTRAINT [PK_PlacePart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlacePersons]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlacePersons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Place] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Phone] [varchar](200) NOT NULL,
	[Comment] [varchar](max) NULL,
 CONSTRAINT [PK_PlacePersons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlaceType]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlaceType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PlaceType] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PlaceType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlaceTypeLinks]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceTypeLinks](
	[id_Place] [int] NOT NULL,
	[id_PlaceType] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlatformEntrances]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlatformEntrances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Platform_Id] [int] NOT NULL,
 CONSTRAINT [PK_PlatformEntrances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlatformParts]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlatformParts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PartInsights] [nvarchar](max) NOT NULL,
	[Floor] [nvarchar](max) NOT NULL,
	[Platform_Id] [int] NOT NULL,
 CONSTRAINT [PK_PlatformParts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Platforms]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platforms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Place] [nvarchar](max) NOT NULL,
	[Korps] [nvarchar](max) NOT NULL,
	[Hall] [nvarchar](max) NOT NULL,
	[PlatformType_Id] [int] NOT NULL,
 CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlatformTypes]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlatformTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PlatformTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sex]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sex](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Sex] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TagLinks]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagLinks](
	[id_Event] [int] NOT NULL,
	[id_Tag] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Event] [int] NOT NULL,
	[id_PlacePart] [int] NOT NULL,
	[Rank] [int] NULL,
	[Place] [int] NULL,
	[Cost] [money] NOT NULL,
	[ServiceFee] [money] NOT NULL,
	[id_Status] [int] NOT NULL,
	[TicketGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TicketChangeLog]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TicketChangeLog](
	[id] [uniqueidentifier] NOT NULL,
	[id_User] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[id_Ticket] [int] NOT NULL,
	[ChangeFrom] [varchar](max) NOT NULL,
	[ChangeTo] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TicketChangeLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TicketStatus]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TicketStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](500) NOT NULL,
	[EnableSale] [bit] NOT NULL,
 CONSTRAINT [PK_TicketStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfoes]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfoes](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Company] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserInfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRoles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoleText] [varchar](500) NOT NULL,
	[RoleID] [int] NOT NULL,
	[RoleLevel] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](500) NOT NULL,
	[UserLogin] [varchar](200) NOT NULL,
	[LastEnter] [varchar](200) NULL,
	[UserPhone] [varchar](100) NOT NULL,
	[UserMail] [varchar](200) NOT NULL,
	[UserRank] [varchar](200) NOT NULL,
	[Password] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[id_User] [int] NOT NULL,
	[id_Role] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserStatuses]    Script Date: 12.07.2016 19:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatuses](
	[Id] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_UserStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_FK_EventLogEvent]    Script Date: 12.07.2016 19:48:42 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventLogEvent] ON [dbo].[EventLogs]
(
	[Event_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EventLogUser]    Script Date: 12.07.2016 19:48:42 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventLogUser] ON [dbo].[EventLogs]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EventPlatform]    Script Date: 12.07.2016 19:48:42 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventPlatform] ON [dbo].[Events]
(
	[Platform_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_PlatformPlatformEntrance]    Script Date: 12.07.2016 19:48:42 ******/
CREATE NONCLUSTERED INDEX [IX_FK_PlatformPlatformEntrance] ON [dbo].[PlatformEntrances]
(
	[Platform_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_PlatformPlatformPart]    Script Date: 12.07.2016 19:48:42 ******/
CREATE NONCLUSTERED INDEX [IX_FK_PlatformPlatformPart] ON [dbo].[PlatformParts]
(
	[Platform_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_PlatformPlatformType]    Script Date: 12.07.2016 19:48:42 ******/
CREATE NONCLUSTERED INDEX [IX_FK_PlatformPlatformType] ON [dbo].[Platforms]
(
	[PlatformType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CountryPlaces]  WITH CHECK ADD  CONSTRAINT [FK_CountryPlaces_Country] FOREIGN KEY([id_Country])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[CountryPlaces] CHECK CONSTRAINT [FK_CountryPlaces_Country]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventStyle] FOREIGN KEY([id_Style])
REFERENCES [dbo].[EventStyle] ([id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventStyle]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_Event] FOREIGN KEY([id_Event])
REFERENCES [dbo].[Event] ([id])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_Event]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_Users]
GO
ALTER TABLE [dbo].[EventLogs]  WITH CHECK ADD  CONSTRAINT [FK_EventLogEvent] FOREIGN KEY([Event_Id])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[EventLogs] CHECK CONSTRAINT [FK_EventLogEvent]
GO
ALTER TABLE [dbo].[EventLogs]  WITH CHECK ADD  CONSTRAINT [FK_EventLogUser] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[EventLogs] CHECK CONSTRAINT [FK_EventLogUser]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_EventPlatform] FOREIGN KEY([Platform_Id])
REFERENCES [dbo].[Platforms] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_EventPlatform]
GO
ALTER TABLE [dbo].[InviteCodes]  WITH CHECK ADD  CONSTRAINT [FK_UserInviteCode] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InviteCodes] CHECK CONSTRAINT [FK_UserInviteCode]
GO
ALTER TABLE [dbo].[OrderLog]  WITH CHECK ADD  CONSTRAINT [FK_OrderLog_Orders] FOREIGN KEY([id_Order])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[OrderLog] CHECK CONSTRAINT [FK_OrderLog_Orders]
GO
ALTER TABLE [dbo].[OrderLog]  WITH CHECK ADD  CONSTRAINT [FK_OrderLog_OrderStatus] FOREIGN KEY([id_OrderStatus])
REFERENCES [dbo].[OrderStatus] ([id])
GO
ALTER TABLE [dbo].[OrderLog] CHECK CONSTRAINT [FK_OrderLog_OrderStatus]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([id_Customer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PaymentMethod] FOREIGN KEY([id_PaymentMethod])
REFERENCES [dbo].[PaymentMethod] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PaymentMethod]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Ticket] FOREIGN KEY([id_Ticket])
REFERENCES [dbo].[Ticket] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Ticket]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_TicketStatus] FOREIGN KEY([id_Status])
REFERENCES [dbo].[TicketStatus] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_TicketStatus]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Sex] FOREIGN KEY([id_Bithplace])
REFERENCES [dbo].[CountryPlaces] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Sex]
GO
ALTER TABLE [dbo].[PersonAntro]  WITH CHECK ADD  CONSTRAINT [FK_PersonAntro_Person] FOREIGN KEY([id_Person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonAntro] CHECK CONSTRAINT [FK_PersonAntro_Person]
GO
ALTER TABLE [dbo].[PersonAntro]  WITH CHECK ADD  CONSTRAINT [FK_PersonAntro_PersonAntroNames] FOREIGN KEY([id_Antro])
REFERENCES [dbo].[PersonAntroNames] ([id])
GO
ALTER TABLE [dbo].[PersonAntro] CHECK CONSTRAINT [FK_PersonAntro_PersonAntroNames]
GO
ALTER TABLE [dbo].[PersonChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_PersonChangeLog_Person] FOREIGN KEY([id_Person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonChangeLog] CHECK CONSTRAINT [FK_PersonChangeLog_Person]
GO
ALTER TABLE [dbo].[PersonChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_PersonChangeLog_PersonChangeParam] FOREIGN KEY([id_ChangeParam])
REFERENCES [dbo].[PersonChangeParam] ([id])
GO
ALTER TABLE [dbo].[PersonChangeLog] CHECK CONSTRAINT [FK_PersonChangeLog_PersonChangeParam]
GO
ALTER TABLE [dbo].[PersonChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_PersonChangeLog_Users] FOREIGN KEY([id_WhoChange])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PersonChangeLog] CHECK CONSTRAINT [FK_PersonChangeLog_Users]
GO
ALTER TABLE [dbo].[PersonConnections]  WITH CHECK ADD  CONSTRAINT [FK_PersonConnections_Event] FOREIGN KEY([id_Event])
REFERENCES [dbo].[Event] ([id])
GO
ALTER TABLE [dbo].[PersonConnections] CHECK CONSTRAINT [FK_PersonConnections_Event]
GO
ALTER TABLE [dbo].[PersonConnections]  WITH CHECK ADD  CONSTRAINT [FK_PersonConnections_Person] FOREIGN KEY([id_Person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonConnections] CHECK CONSTRAINT [FK_PersonConnections_Person]
GO
ALTER TABLE [dbo].[PersonConnections]  WITH CHECK ADD  CONSTRAINT [FK_PersonConnections_Person1] FOREIGN KEY([id_PersonConnectTo])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonConnections] CHECK CONSTRAINT [FK_PersonConnections_Person1]
GO
ALTER TABLE [dbo].[PersonConnections]  WITH CHECK ADD  CONSTRAINT [FK_PersonConnections_PersonConnectionType] FOREIGN KEY([id_ConnectionType])
REFERENCES [dbo].[PersonConnectionType] ([id])
GO
ALTER TABLE [dbo].[PersonConnections] CHECK CONSTRAINT [FK_PersonConnections_PersonConnectionType]
GO
ALTER TABLE [dbo].[PersonDescriptions]  WITH CHECK ADD  CONSTRAINT [FK_PersonDescriptions_Person] FOREIGN KEY([id_Person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonDescriptions] CHECK CONSTRAINT [FK_PersonDescriptions_Person]
GO
ALTER TABLE [dbo].[PersonDescriptions]  WITH CHECK ADD  CONSTRAINT [FK_PersonDescriptions_PersonDescriptionType] FOREIGN KEY([id_DescriptionType])
REFERENCES [dbo].[PersonDescriptionType] ([id])
GO
ALTER TABLE [dbo].[PersonDescriptions] CHECK CONSTRAINT [FK_PersonDescriptions_PersonDescriptionType]
GO
ALTER TABLE [dbo].[PersonMedia]  WITH CHECK ADD  CONSTRAINT [FK_PersonMedia_Person] FOREIGN KEY([id_Person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonMedia] CHECK CONSTRAINT [FK_PersonMedia_Person]
GO
ALTER TABLE [dbo].[PersonSocialLinks]  WITH CHECK ADD  CONSTRAINT [FK_PersonSocialLinks_Person] FOREIGN KEY([id_Person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonSocialLinks] CHECK CONSTRAINT [FK_PersonSocialLinks_Person]
GO
ALTER TABLE [dbo].[PersonSocialLinks]  WITH CHECK ADD  CONSTRAINT [FK_PersonSocialLinks_PersonSocialLinkTypes] FOREIGN KEY([id_SocialMedia])
REFERENCES [dbo].[PersonSocialLinkTypes] ([id])
GO
ALTER TABLE [dbo].[PersonSocialLinks] CHECK CONSTRAINT [FK_PersonSocialLinks_PersonSocialLinkTypes]
GO
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [FK_Place_Adress] FOREIGN KEY([id_Adress])
REFERENCES [dbo].[Adress] ([id])
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [FK_Place_Adress]
GO
ALTER TABLE [dbo].[PlaceHall]  WITH CHECK ADD  CONSTRAINT [FK_PlaceHall_PlaceKorp] FOREIGN KEY([id_PlaceKorp])
REFERENCES [dbo].[PlaceKorp] ([id])
GO
ALTER TABLE [dbo].[PlaceHall] CHECK CONSTRAINT [FK_PlaceHall_PlaceKorp]
GO
ALTER TABLE [dbo].[PlaceKorp]  WITH CHECK ADD  CONSTRAINT [FK_PlaceKorp_Place] FOREIGN KEY([id_Place])
REFERENCES [dbo].[Place] ([id])
GO
ALTER TABLE [dbo].[PlaceKorp] CHECK CONSTRAINT [FK_PlaceKorp_Place]
GO
ALTER TABLE [dbo].[PlacePart]  WITH CHECK ADD  CONSTRAINT [FK_PlacePart_PlaceHall] FOREIGN KEY([id_Hall])
REFERENCES [dbo].[PlaceHall] ([id])
GO
ALTER TABLE [dbo].[PlacePart] CHECK CONSTRAINT [FK_PlacePart_PlaceHall]
GO
ALTER TABLE [dbo].[PlacePersons]  WITH CHECK ADD  CONSTRAINT [FK_PlacePersons_Place] FOREIGN KEY([id_Place])
REFERENCES [dbo].[Place] ([id])
GO
ALTER TABLE [dbo].[PlacePersons] CHECK CONSTRAINT [FK_PlacePersons_Place]
GO
ALTER TABLE [dbo].[PlaceTypeLinks]  WITH CHECK ADD  CONSTRAINT [FK_PlaceTypeLinks_Place] FOREIGN KEY([id_Place])
REFERENCES [dbo].[Place] ([id])
GO
ALTER TABLE [dbo].[PlaceTypeLinks] CHECK CONSTRAINT [FK_PlaceTypeLinks_Place]
GO
ALTER TABLE [dbo].[PlaceTypeLinks]  WITH CHECK ADD  CONSTRAINT [FK_PlaceTypeLinks_PlaceType] FOREIGN KEY([id_PlaceType])
REFERENCES [dbo].[PlaceType] ([id])
GO
ALTER TABLE [dbo].[PlaceTypeLinks] CHECK CONSTRAINT [FK_PlaceTypeLinks_PlaceType]
GO
ALTER TABLE [dbo].[PlatformEntrances]  WITH CHECK ADD  CONSTRAINT [FK_PlatformPlatformEntrance] FOREIGN KEY([Platform_Id])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlatformEntrances] CHECK CONSTRAINT [FK_PlatformPlatformEntrance]
GO
ALTER TABLE [dbo].[PlatformParts]  WITH CHECK ADD  CONSTRAINT [FK_PlatformPlatformPart] FOREIGN KEY([Platform_Id])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlatformParts] CHECK CONSTRAINT [FK_PlatformPlatformPart]
GO
ALTER TABLE [dbo].[Platforms]  WITH CHECK ADD  CONSTRAINT [FK_PlatformPlatformType] FOREIGN KEY([PlatformType_Id])
REFERENCES [dbo].[PlatformTypes] ([Id])
GO
ALTER TABLE [dbo].[Platforms] CHECK CONSTRAINT [FK_PlatformPlatformType]
GO
ALTER TABLE [dbo].[TagLinks]  WITH CHECK ADD  CONSTRAINT [FK_TagLinks_Event] FOREIGN KEY([id_Event])
REFERENCES [dbo].[Event] ([id])
GO
ALTER TABLE [dbo].[TagLinks] CHECK CONSTRAINT [FK_TagLinks_Event]
GO
ALTER TABLE [dbo].[TagLinks]  WITH CHECK ADD  CONSTRAINT [FK_TagLinks_Tags] FOREIGN KEY([id_Tag])
REFERENCES [dbo].[Tags] ([id])
GO
ALTER TABLE [dbo].[TagLinks] CHECK CONSTRAINT [FK_TagLinks_Tags]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Event] FOREIGN KEY([id_Event])
REFERENCES [dbo].[Event] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Event]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_PlacePart] FOREIGN KEY([id_PlacePart])
REFERENCES [dbo].[PlacePart] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_PlacePart]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_TicketStatus] FOREIGN KEY([id_Status])
REFERENCES [dbo].[TicketStatus] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_TicketStatus]
GO
ALTER TABLE [dbo].[TicketChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_TicketChangeLog_Ticket] FOREIGN KEY([id_Ticket])
REFERENCES [dbo].[Ticket] ([id])
GO
ALTER TABLE [dbo].[TicketChangeLog] CHECK CONSTRAINT [FK_TicketChangeLog_Ticket]
GO
ALTER TABLE [dbo].[TicketChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_TicketChangeLog_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[TicketChangeLog] CHECK CONSTRAINT [FK_TicketChangeLog_Users]
GO
ALTER TABLE [dbo].[UserInfoes]  WITH CHECK ADD  CONSTRAINT [FK_UserUserInfo] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInfoes] CHECK CONSTRAINT [FK_UserUserInfo]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_UserRoles] FOREIGN KEY([id_Role])
REFERENCES [dbo].[UserRoles] ([id])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_UserRoles]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Users]
GO
ALTER TABLE [dbo].[UserStatuses]  WITH CHECK ADD  CONSTRAINT [FK_UserUserStatus] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserStatuses] CHECK CONSTRAINT [FK_UserUserStatus]
GO
USE [master]
GO
ALTER DATABASE [Getticket] SET  READ_WRITE 
GO
