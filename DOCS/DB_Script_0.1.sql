USE [master]
GO
/****** Object:  Database [Getticket]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[Adress]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[Event]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[EventLog]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[EventStyle]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[OrderLog]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[Place]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[PlaceHall]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[PlaceKorp]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[PlacePart]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[PlacePersons]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[PlaceType]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[PlaceTypeLinks]    Script Date: 26.05.2016 13:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceTypeLinks](
	[id_Place] [int] NOT NULL,
	[id_PlaceType] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagLinks]    Script Date: 26.05.2016 13:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagLinks](
	[id_Event] [int] NOT NULL,
	[id_Tag] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[Ticket]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[TicketChangeLog]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[TicketStatus]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[UserRoles]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 26.05.2016 13:11:46 ******/
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
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 26.05.2016 13:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[id_User] [int] NOT NULL,
	[id_Role] [int] NOT NULL
) ON [PRIMARY]

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
USE [master]
GO
ALTER DATABASE [Getticket] SET  READ_WRITE 
GO
