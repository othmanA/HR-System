/****** Object:  Table [dbo].[Department]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
DROP TABLE [dbo].[Department]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Document]') AND type in (N'U'))
DROP TABLE [dbo].[Document]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Income]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Income]') AND type in (N'U'))
DROP TABLE [dbo].[Income]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
DROP TABLE [dbo].[Position]
GO
/****** Object:  Table [dbo].[Record]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Record]') AND type in (N'U'))
DROP TABLE [dbo].[Record]
GO
/****** Object:  Table [dbo].[Time_off]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Time_off]') AND type in (N'U'))
DROP TABLE [dbo].[Time_off]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/21/2013 23:39:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[user_password] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[user_email] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[user_full_name] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
/****** Object:  Table [dbo].[Time_off]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Time_off]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Time_off](
	[employee] [int] NULL,
	[time_off_start_date] [date] NULL,
	[time_off_end_date] [date] NULL,
	[time_off_paid_days] [int] NULL,
	[time_off_type] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[time_off_approved] [bit] NULL
)
END
GO
/****** Object:  Table [dbo].[Record]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Record]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Record](
	[employee] [int] NULL,
	[record_issue_date] [date] NULL,
	[record_expire_date] [date] NULL,
	[record_type] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[record_note] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[record_approved] [bit] NULL
)
END
GO
/****** Object:  Table [dbo].[Position]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Position](
	[position_id] [int] IDENTITY(1,1) NOT NULL,
	[position_name] [nchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
/****** Object:  Table [dbo].[Income]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Income]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Income](
	[employee] [int] NOT NULL,
	[income_type] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[income_amount] [numeric](18, 2) NULL,
	[income_per] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[income_approved] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_SSN] [numeric](18, 0) NULL,
	[employee_firstName] [nchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_middleInital] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_lastName] [nchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_dob] [date] NULL,
	[employee_gender] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_working_status] [int] NULL,
	[employee_contract] [nchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_hoursPerDay] [int] NULL,
	[employee_firstDay] [date] NULL,
	[employee_position] [int] NULL,
	[employee_approved] [bit] NULL,
	[employee_created_at] [timestamp] NULL,
	[employee_address1] [nchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_address2] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_city] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_state] [nchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[employee_zip_code] [numeric](5, 0) NULL,
	[employee_phone] [numeric](11, 0) NULL
)
END
GO
/****** Object:  Table [dbo].[Document]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Document]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Document](
	[employee] [int] NULL,
	[document_name] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[document_path] [nchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[document_size] [int] NULL,
	[document_note] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[document_approved] [bit] NULL
)
END
GO
/****** Object:  Table [dbo].[Department]    Script Date: 11/21/2013 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Department](
	[department_id] [int] IDENTITY(1,1) NOT NULL,
	[department_name] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
END
GO
