//USE[master]
//GO
///****** Object:  Database [SwordLMSTwo]    Script Date: 8/14/2023 2:05:11 PM ******/
//CREATE DATABASE [SwordLMSTwo]
//CONTAINMENT = NONE
// ON PRIMARY
//(NAME = N'SwordLMSTwo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SwordLMSTwo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
// LOG ON
//(NAME = N'SwordLMSTwo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SwordLMSTwo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
// WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
//GO
//ALTER DATABASE [SwordLMSTwo] SET COMPATIBILITY_LEVEL = 160
//GO
//IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
//begin
//EXEC[SwordLMSTwo].[dbo].[sp_fulltext_database] @action = 'enable'
//end
//GO
//ALTER DATABASE [SwordLMSTwo] SET ANSI_NULL_DEFAULT OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET ANSI_NULLS OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET ANSI_PADDING OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET ANSI_WARNINGS OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET ARITHABORT OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET AUTO_CLOSE OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET AUTO_SHRINK OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET AUTO_UPDATE_STATISTICS ON 
//GO
//ALTER DATABASE [SwordLMSTwo] SET CURSOR_CLOSE_ON_COMMIT OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET CURSOR_DEFAULT  GLOBAL 
//GO
//ALTER DATABASE [SwordLMSTwo] SET CONCAT_NULL_YIELDS_NULL OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET NUMERIC_ROUNDABORT OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET QUOTED_IDENTIFIER OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET RECURSIVE_TRIGGERS OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET ENABLE_BROKER 
//GO
//ALTER DATABASE [SwordLMSTwo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET DATE_CORRELATION_OPTIMIZATION OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET TRUSTWORTHY OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET PARAMETERIZATION SIMPLE 
//GO
//ALTER DATABASE [SwordLMSTwo] SET READ_COMMITTED_SNAPSHOT OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET HONOR_BROKER_PRIORITY OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET RECOVERY FULL 
//GO
//ALTER DATABASE [SwordLMSTwo] SET MULTI_USER 
//GO
//ALTER DATABASE [SwordLMSTwo] SET PAGE_VERIFY CHECKSUM  
//GO
//ALTER DATABASE [SwordLMSTwo] SET DB_CHAINING OFF 
//GO
//ALTER DATABASE [SwordLMSTwo] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF)
//GO
//ALTER DATABASE [SwordLMSTwo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
//GO
//ALTER DATABASE [SwordLMSTwo] SET DELAYED_DURABILITY = DISABLED 
//GO
//ALTER DATABASE [SwordLMSTwo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
//GO
//EXEC sys.sp_db_vardecimal_storage_format N'SwordLMSTwo', N'ON'
//GO
//ALTER DATABASE [SwordLMSTwo] SET QUERY_STORE = ON
//GO
//ALTER DATABASE [SwordLMSTwo] SET QUERY_STORE(OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
//GO
//USE[SwordLMSTwo]
//GO
///****** Object:  Table [dbo].[Category]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[Category] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (40) NOT NULL,
// CONSTRAINT[PK_Category] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[City]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[City] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (20) NOT NULL,

//    [StateId] [int] NOT NULL,

//    [IsActive] [bit] NOT NULL,

//    [IsDeleted] [bit] NOT NULL,
// CONSTRAINT[PK_City] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[ContentType]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[ContentType] (

//    [Id][int] NOT NULL,

//    [Type] [char] (10) NOT NULL,
// CONSTRAINT[PK_ContentType] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Country]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[Country] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [char] (50) NOT NULL,

//    [IsActive] [bit] NOT NULL,

//    [IsDeleted] [bit] NOT NULL,
// CONSTRAINT[PK_Country_1] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Course]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[Course] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (250) NOT NULL,

//    [Description] [nvarchar] (500) NOT NULL,

//    [AuthorId] [int] NOT NULL,

//    [DurationInMins] [int] NOT NULL,

//    [DateOfPublish] [date] NULL,
//	[Ratings][float] NULL,
//	[DisplayImagePath][nvarchar] (500) NOT NULL,

//    [Price] [float] NOT NULL,
// CONSTRAINT[PK_Course] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[CourseContent]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[CourseContent] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (10) NOT NULL,

//    [TopicId] [int] NOT NULL,

//    [ContentTypeId] [int] NOT NULL,

//    [DurationInMins] [int] NOT NULL,

//    [ContentPath] [varchar] (500) NOT NULL,
// CONSTRAINT[PK_CourseContent] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[CourseReview]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[CourseReview] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [CourseId] [int] NOT NULL,

//    [UserId] [int] NOT NULL,

//    [AuthorId] [int] NOT NULL,

//    [Rating] [int] NOT NULL,

//    [Comments] [nvarchar] (500) NOT NULL,
// CONSTRAINT[PK_CourseReview] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[CourseSkills]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[CourseSkills] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [CourseId] [int] NOT NULL,

//    [SkillsId] [int] NOT NULL,
// CONSTRAINT[PK_Course_Skills] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[CourseTopic]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[CourseTopic] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [CourseId] [int] NOT NULL,

//    [Name] [nchar] (50) NOT NULL,

//    [DurationInMins] [int] NOT NULL,
// CONSTRAINT[PK_CourseTopics] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[FeedBack]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[FeedBack] (

//    [Id][int] NOT NULL,

//    [Rating] [float] NOT NULL,

//    [FeedBack] [nvarchar] (500) NOT NULL,

//    [UserId] [int] NOT NULL,

//    [CourseId] [int] NOT NULL
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Role]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[Role] (

//    [Id][int] NOT NULL,

//    [Name] [nvarchar] (50) NOT NULL,

//    [Description] [nvarchar] (50) NULL,
// CONSTRAINT[PK_Role] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Skills]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[Skills] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (50) NOT NULL,

//    [Version] [nvarchar] (10) NULL,

//    [Description] [nvarchar] (500) NULL,

//    [SubCategoryId] [int] NOT NULL,
// CONSTRAINT[PK_Skills] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[State]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[State] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (20) NOT NULL,

//    [CountryId] [int] NOT NULL,

//    [IsActive] [bit] NOT NULL,

//    [IsDeleted] [bit] NOT NULL,
// CONSTRAINT[PK_State_1] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[SubCategory]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[SubCategory] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (40) NOT NULL,

//    [CategoryId] [int] NOT NULL,
// CONSTRAINT[PK_SubCategory] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[User]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[User] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [FirstName] [varchar] (150) NULL,

//    [LastName] [varchar] (150) NULL,

//    [Email] [varchar] (50) NOT NULL,

//    [DateOfBirth] [datetime] NOT NULL,

//    [Address] [nvarchar] (250) NOT NULL,

//    [City] [int] NULL,
//	[Pincode][int] NOT NULL,

//    [UserName] [nvarchar] (50) NOT NULL,

//    [State] [int] NULL,
//	[PhoneNumber][nchar] (10) NOT NULL,

//    [Country] [int] NULL,
//	[RoleId][int] NOT NULL,

//    [IsActive] [bit] NOT NULL,

//    [Password] [nvarchar] (200) NOT NULL,
// CONSTRAINT[PK_User_1] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[UserContent]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[UserContent] (

//    [Id][int] IDENTITY(1, 1) NOT NULL,

//    [UserId] [int] NOT NULL,

//    [ContentId] [int] NOT NULL,

//    [IsCompleted] [bit] NOT NULL,

//    [WatchedDuration] [int] NULL,
// CONSTRAINT[PK_UserContent] PRIMARY KEY CLUSTERED 
//(

//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[UserCourses]    Script Date: 8/14/2023 2:05:11 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[UserCourses] (

//    [UserId][int] NOT NULL,

//    [CourseId] [int] NOT NULL,

//    [DateOfEnroll] [date] NULL,
//	[WatchedDuration][int] NULL,
//	[IsCompleted][bit] NULL,
// CONSTRAINT[PK_UserCourses] PRIMARY KEY CLUSTERED 
//(

//    [UserId] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
//ALTER TABLE [dbo].[City] WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateId])
//REFERENCES[dbo].[State]([Id])
//GO
//ALTER TABLE [dbo].[City] CHECK CONSTRAINT[FK_City_State]
//GO
//ALTER TABLE [dbo].[CourseContent] WITH CHECK ADD  CONSTRAINT [FK_CourseContent_Course] FOREIGN KEY([ContentTypeId])
//REFERENCES[dbo].[ContentType]([Id])
//GO
//ALTER TABLE [dbo].[CourseContent] CHECK CONSTRAINT[FK_CourseContent_Course]
//GO
//ALTER TABLE [dbo].[CourseContent] WITH CHECK ADD  CONSTRAINT [FK_CourseContent_CourseType] FOREIGN KEY([TopicId])
//REFERENCES[dbo].[CourseTopic]([Id])
//GO
//ALTER TABLE [dbo].[CourseContent] CHECK CONSTRAINT[FK_CourseContent_CourseType]
//GO
//ALTER TABLE [dbo].[CourseReview] WITH CHECK ADD  CONSTRAINT [FK_CourseReview_Course] FOREIGN KEY([Id])
//REFERENCES[dbo].[Course]([Id])
//GO
//ALTER TABLE [dbo].[CourseReview] CHECK CONSTRAINT[FK_CourseReview_Course]
//GO
//ALTER TABLE [dbo].[CourseSkills] WITH CHECK ADD  CONSTRAINT [FK_CourseSkills_Course] FOREIGN KEY([CourseId])
//REFERENCES[dbo].[Course]([Id])
//GO
//ALTER TABLE [dbo].[CourseSkills] CHECK CONSTRAINT[FK_CourseSkills_Course]
//GO
//ALTER TABLE [dbo].[CourseTopic] WITH CHECK ADD  CONSTRAINT [FK_CourseTopics_Course] FOREIGN KEY([CourseId])
//REFERENCES[dbo].[Course]([Id])
//GO
//ALTER TABLE [dbo].[CourseTopic] CHECK CONSTRAINT[FK_CourseTopics_Course]
//GO
//ALTER TABLE [dbo].[FeedBack] WITH CHECK ADD  CONSTRAINT [FK_FeedBack_Course] FOREIGN KEY([CourseId])
//REFERENCES[dbo].[Course]([Id])
//GO
//ALTER TABLE [dbo].[FeedBack] CHECK CONSTRAINT[FK_FeedBack_Course]
//GO
//ALTER TABLE [dbo].[FeedBack] WITH CHECK ADD  CONSTRAINT [FK_FeedBack_User] FOREIGN KEY([UserId])
//REFERENCES[dbo].[User]([Id])
//GO
//ALTER TABLE [dbo].[FeedBack] CHECK CONSTRAINT[FK_FeedBack_User]
//GO
//ALTER TABLE [dbo].[Skills] WITH CHECK ADD  CONSTRAINT [FK_Skills_SubCategory] FOREIGN KEY([SubCategoryId])
//REFERENCES[dbo].[SubCategory]([Id])
//GO
//ALTER TABLE [dbo].[Skills] CHECK CONSTRAINT[FK_Skills_SubCategory]
//GO
//ALTER TABLE [dbo].[State] WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
//REFERENCES[dbo].[Country]([Id])
//GO
//ALTER TABLE [dbo].[State] CHECK CONSTRAINT[FK_State_Country]
//GO
//ALTER TABLE [dbo].[SubCategory] WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([CategoryId])
//REFERENCES[dbo].[Category]([Id])
//GO
//ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT[FK_SubCategory_Category]
//GO
//ALTER TABLE [dbo].[User] WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
//REFERENCES[dbo].[Role]([Id])
//GO
//ALTER TABLE [dbo].[User] CHECK CONSTRAINT[FK_User_Role]
//GO
//ALTER TABLE [dbo].[UserContent] WITH CHECK ADD  CONSTRAINT [FK_UserContent_Course] FOREIGN KEY([ContentId])
//REFERENCES[dbo].[CourseContent]([Id])
//GO
//ALTER TABLE [dbo].[UserContent] CHECK CONSTRAINT[FK_UserContent_Course]
//GO
//ALTER TABLE [dbo].[UserContent] WITH CHECK ADD  CONSTRAINT [FK_UserContent_User] FOREIGN KEY([UserId])
//REFERENCES[dbo].[User]([Id])
//GO
//ALTER TABLE [dbo].[UserContent] CHECK CONSTRAINT[FK_UserContent_User]
//GO
//ALTER TABLE [dbo].[UserCourses] WITH CHECK ADD  CONSTRAINT [FK_UserCourses_Courses] FOREIGN KEY([CourseId])
//REFERENCES[dbo].[Course]([Id])
//GO
//ALTER TABLE [dbo].[UserCourses] CHECK CONSTRAINT[FK_UserCourses_Courses]
//GO
//ALTER TABLE [dbo].[UserCourses] WITH CHECK ADD  CONSTRAINT [FK_UserCourses_User] FOREIGN KEY([UserId])
//REFERENCES[dbo].[User]([Id])
//GO
//ALTER TABLE [dbo].[UserCourses] CHECK CONSTRAINT[FK_UserCourses_User]
//GO
//USE [master]
//GO
//ALTER DATABASE [SwordLMSTwo] SET READ_WRITE 
//GO
