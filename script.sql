USE [master]
GO
/****** Object:  Database [UCRMS-DB]    Script Date: 01-09-16 01.16.28 ******/
CREATE DATABASE [UCRMS-DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UCRMS-DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UCRMS-DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UCRMS-DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UCRMS-DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UCRMS-DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UCRMS-DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UCRMS-DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UCRMS-DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UCRMS-DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UCRMS-DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UCRMS-DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UCRMS-DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UCRMS-DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UCRMS-DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UCRMS-DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UCRMS-DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UCRMS-DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UCRMS-DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UCRMS-DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UCRMS-DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UCRMS-DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UCRMS-DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UCRMS-DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UCRMS-DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UCRMS-DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UCRMS-DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UCRMS-DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UCRMS-DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UCRMS-DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UCRMS-DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UCRMS-DB] SET  MULTI_USER 
GO
ALTER DATABASE [UCRMS-DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UCRMS-DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UCRMS-DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UCRMS-DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UCRMS-DB]
GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classrooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[Day] [nvarchar](50) NULL,
	[ClassStartFrom] [time](7) NULL,
	[ClassEndAt] [time](7) NULL,
	[ClassroomId] [int] NULL,
 CONSTRAINT [PK_Classrooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Credit] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[DepartmentId] [int] NULL,
	[SemesterId] [int] NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](7) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designations]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Designations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grades]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentCourses]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Student_Id] [int] NULL,
	[Course_Id] [int] NULL,
	[EnrollDate] [date] NULL,
	[GradeId] [int] NULL,
 CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNumber] [nvarchar](max) NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[ContactNo] [nvarchar](15) NULL,
	[Date] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](100) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[CreditToBeTaken] [decimal](18, 2) NULL,
	[RemainingCredit] [decimal](18, 2) NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[VW_CourseStatistics]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE VIEW [dbo].[VW_CourseStatistics]
 AS
 SELECT C.Id, C.Code,C.DepartmentId,C.SemesterId,C.TeacherId, C.Name, S.Name AS SemesterName, T.Name AS TeacherName
 FROM Courses AS C LEFT OUTER JOIN Departments AS D 
 ON C.DepartmentId = D.Id LEFT OUTER JOIN Semesters AS S
 ON C.SemesterId = S.Id LEFT OUTER JOIN Teachers AS T ON C.TeacherId = T.Id

GO
/****** Object:  View [dbo].[VW_ScheduleInformation]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_ScheduleInformation]
AS
SELECT c.DepartmentId, c.Code, c.Name, r.RoomNo, cr.Day, cr.ClassStartFrom, cr.ClassEndAt
FROM  dbo.Classrooms AS cr INNER JOIN
dbo.Rooms AS r ON cr.RoomId = r.Id RIGHT OUTER JOIN
dbo.Courses AS c ON cr.CourseId = c.Id INNER JOIN
dbo.Departments AS dt ON c.DepartmentId = dt.Id

GO
/****** Object:  View [dbo].[VW_StudentCoursesGrade]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_StudentCoursesGrade]
AS
SELECT SC.Id,SC.Student_Id,SC.Course_Id,SC.EnrollDate,C.Code,C.Name,G.Name As GradeName
FROM StudentCourses SC 
LEFT OUTER JOIN Courses C
ON SC.Course_Id=C.Id
LEFT OUTER JOIN Grades G
ON SC.GradeId=G.Id

GO
/****** Object:  View [dbo].[VW_StudentsDepartments]    Script Date: 01-09-16 01.16.28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_StudentsDepartments]
AS
SELECT S.Id,S.RegistrationNumber,S.Name,S.Email,S.ContactNo,S.Date,S.DepartmentId,D.Id AS DeptId,D.Name AS DeptName,D.Code
FROM Students S
LEFT OUTER JOIN Departments D 
ON S.DepartmentId=D.Id

GO
/****** Object:  Index [IX_Courses]    Script Date: 01-09-16 01.16.28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Courses] ON [dbo].[Courses]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_1]    Script Date: 01-09-16 01.16.28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Courses_1] ON [dbo].[Courses]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Code]    Script Date: 01-09-16 01.16.28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Code] ON [dbo].[Departments]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Name]    Script Date: 01-09-16 01.16.28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name] ON [dbo].[Departments]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactNo]    Script Date: 01-09-16 01.16.28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ContactNo] ON [dbo].[Teachers]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Email]    Script Date: 01-09-16 01.16.28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Email] ON [dbo].[Teachers]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Classrooms]  WITH CHECK ADD  CONSTRAINT [FK_Classrooms_Classrooms] FOREIGN KEY([Id])
REFERENCES [dbo].[Classrooms] ([Id])
GO
ALTER TABLE [dbo].[Classrooms] CHECK CONSTRAINT [FK_Classrooms_Classrooms]
GO
ALTER TABLE [dbo].[Classrooms]  WITH CHECK ADD  CONSTRAINT [FK_Classrooms_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Classrooms] CHECK CONSTRAINT [FK_Classrooms_Courses]
GO
ALTER TABLE [dbo].[Classrooms]  WITH CHECK ADD  CONSTRAINT [FK_Classrooms_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Classrooms] CHECK CONSTRAINT [FK_Classrooms_Departments]
GO
ALTER TABLE [dbo].[Classrooms]  WITH CHECK ADD  CONSTRAINT [FK_Classrooms_Rooms] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Classrooms] CHECK CONSTRAINT [FK_Classrooms_Rooms]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Courses] FOREIGN KEY([Id])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Courses]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Semesters] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Semesters]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Teachers]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Courses] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Courses]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Grades] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grades] ([Id])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Grades]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Students] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Courses]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Departments]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Students] FOREIGN KEY([Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Students]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Departments]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Designations] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Designations]
GO
USE [master]
GO
ALTER DATABASE [UCRMS-DB] SET  READ_WRITE 
GO
