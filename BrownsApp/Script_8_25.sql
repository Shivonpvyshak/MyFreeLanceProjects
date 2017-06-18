USE [master]
GO
/****** Object:  Database [BrownsAppDB]    Script Date: 8/25/2016 2:10:07 PM ******/
CREATE DATABASE [BrownsAppDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BrownsAppDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BrownsAppDB.mdf' , SIZE = 207872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BrownsAppDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BrownsAppDB_log.ldf' , SIZE = 164672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BrownsAppDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BrownsAppDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BrownsAppDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BrownsAppDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BrownsAppDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BrownsAppDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BrownsAppDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BrownsAppDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BrownsAppDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BrownsAppDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BrownsAppDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BrownsAppDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BrownsAppDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BrownsAppDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BrownsAppDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BrownsAppDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BrownsAppDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BrownsAppDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BrownsAppDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BrownsAppDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BrownsAppDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BrownsAppDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BrownsAppDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BrownsAppDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BrownsAppDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BrownsAppDB] SET  MULTI_USER 
GO
ALTER DATABASE [BrownsAppDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BrownsAppDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BrownsAppDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BrownsAppDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BrownsAppDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BrownsAppDB]
GO
/****** Object:  Schema [Billing]    Script Date: 8/25/2016 2:10:07 PM ******/
CREATE SCHEMA [Billing]
GO
/****** Object:  Table [Billing].[Customer]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Billing].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address1] [varchar](max) NOT NULL,
	[Address2] [varchar](max) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Zip] [varchar](50) NOT NULL,
	[ShippingStreet] [varchar](max) NULL,
	[ShippingCity] [varchar](50) NULL,
	[ShippingState] [varchar](50) NULL,
	[ShippingZip] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NULL,
	[AddedDate] [datetime] NULL,
	[AddedBy] [varchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL CONSTRAINT [DF_Customer_LastUpdatedDate]  DEFAULT (getdate()),
	[LastUpdatedBy] [varchar](50) NULL,
	[Street] [varchar](max) NULL,
	[ShippingAddress1] [varchar](max) NULL,
	[ShippingAddress2] [varchar](max) NULL,
 CONSTRAINT [PK_Billing.Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Billing].[Invoice]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Billing].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceType] [varchar](50) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[InvoiceNumber] [varchar](50) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[OrderNumber] [varchar](50) NULL,
	[ShippingMethod] [varchar](50) NOT NULL,
	[PaymentStatus] [varchar](50) NOT NULL,
	[CustomerPO] [varchar](50) NULL,
	[SubTotal] [money] NOT NULL,
	[Tax] [money] NOT NULL,
	[Freight] [money] NULL,
	[Total] [money] NOT NULL,
	[BalanceDue] [money] NULL,
	[Comments] [varchar](max) NULL,
	[Make] [varchar](100) NULL,
	[Model] [varchar](max) NULL,
	[SerialNumber] [varchar](max) NULL,
	[UnitNumber] [varchar](100) NULL,
	[TravelCharge] [money] NULL,
	[TravelExpense] [money] NULL,
	[AddedDate] [datetime] NULL,
	[AddedBy] [varchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL,
	[SaleRep] [varchar](50) NULL,
	[PartsSubTotal] [money] NULL,
	[LaborSubTotal] [money] NULL,
	[InvoiceStatus] [varchar](50) NULL,
	[InvoiceStatusID] [int] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Billing].[InvoiceItems]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Billing].[InvoiceItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[Description] [varchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[AddedBy] [varchar](50) NULL,
	[AddedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_InvoiceItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Billing].[InvoiceLabor]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Billing].[InvoiceLabor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[LaborType] [varchar](50) NOT NULL,
	[Hours] [float] NOT NULL,
	[Rate] [money] NOT NULL,
	[Amount] [money] NULL,
	[AddedDate] [datetime] NULL,
	[AddedBy] [varchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_InvoiceLabor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExceptionHistory]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExceptionHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](200) NULL,
	[Message] [varchar](max) NULL,
	[StackTrace] [varchar](max) NULL,
	[ExceptionDate] [datetime] NULL CONSTRAINT [DF_dbo.ExceptionHistory_ExceptionDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_ExceptionHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parts]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parts](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[Make] [varchar](50) NULL,
	[Model] [varchar](500) NULL,
	[SerialNumberRange] [varchar](max) NULL,
	[PartNumber] [varchar](100) NULL,
	[PartManual] [varchar](max) NULL,
	[PartDescription] [varchar](max) NULL,
	[ListPrice] [varchar](100) NULL,
	[AddedBy] [varchar](50) NULL,
	[AddedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL CONSTRAINT [DF_Parts_LastUpdatedBy]  DEFAULT (getdate()),
	[LastUpdatedDate] [datetime] NULL CONSTRAINT [DF_Parts_LastUpdatedDate]  DEFAULT (getdate()),
	[IsDeleted] [bit] NULL CONSTRAINT [DF_Parts_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Parts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [Billing].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Invoice_Customer] FOREIGN KEY([CustomerID])
REFERENCES [Billing].[Customer] ([ID])
GO
ALTER TABLE [Billing].[Invoice] CHECK CONSTRAINT [FK_Invoice_Invoice_Customer]
GO
ALTER TABLE [Billing].[InvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceItems_InvoiceItems_Invoice] FOREIGN KEY([InvoiceID])
REFERENCES [Billing].[Invoice] ([ID])
GO
ALTER TABLE [Billing].[InvoiceItems] CHECK CONSTRAINT [FK_InvoiceItems_InvoiceItems_Invoice]
GO
ALTER TABLE [Billing].[InvoiceLabor]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLabor_InvoiceLabor_Invoice] FOREIGN KEY([InvoiceID])
REFERENCES [Billing].[Invoice] ([ID])
GO
ALTER TABLE [Billing].[InvoiceLabor] CHECK CONSTRAINT [FK_InvoiceLabor_InvoiceLabor_Invoice]
GO
/****** Object:  StoredProcedure [dbo].[AddException]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddException]
	
	@Source [varchar](200) NULL,
	@Message [varchar](max) NULL,
	@StackTrace [varchar](max) NULL,
	@ExceptionDate [date] NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
     INSERT INTO dbo.ExceptionHistory
          ( 
            [Source],                   
            [Message],                  
            [StackTrace],                     
            [ExceptionDate]                   
            
          ) 
     VALUES 
          ( 
            @Source,@Message,@StackTrace,CURRENT_TIMESTAMP
          ) 

END

GO
/****** Object:  StoredProcedure [dbo].[GetPartReportData]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetPartReportData]
    /* Input Parameters */
  	@Make varchar(100) = null,
	@Model varchar(100) = null,
	@SerialNumberRange varchar(MAX) = null,
	@PartNumber varchar(100) = null,
	@PartManual text = null,
	@PartDescription varchar(MAX) = null
        
AS

--exec GetPartReportData 'JLG',NULL,NULL,NULL,NULL,NULL
--exec GetPartReportData NULL,NULL,NULL,'test',NULL,NULL
--exec GetPartReportData '','','','test','',''
    Set NoCount ON
    /* Variable Declaration */
    Declare @SQLQuery AS NVarchar(4000)
    Declare @ParamDefinition AS NVarchar(2000) 
    Set @SQLQuery = 'Select * From dbo.Parts where 1=1' 
    
    If @Make Is Not Null and @Make !='All'
         Set @SQLQuery = @SQLQuery + ' And (Make = @Make)'

    If @Model Is Not Null
         Set @SQLQuery = @SQLQuery + ' And (Model = @Model)' 
  
    If @SerialNumberRange Is Not Null
         Set @SQLQuery = @SQLQuery + ' And (SerialNumberRange = @SerialNumberRange)'
  
    If @PartNumber IS NOT NULL 
         Set @SQLQuery = @SQLQuery + ' And (PartNumber = @PartNumber)'

	If @PartManual Is Not Null
		Set @SQLQuery = @SQLQuery + ' And (PartManual = @PartManual)'

	If @PartDescription Is Not Null
		Set @SQLQuery = @SQLQuery + ' And (PartDescription = @PartDescription)'

		Set @SQLQuery = @SQLQuery +  ' ORDER BY PARTNUMBER'

    /* Specify Parameter Format for all input parameters included 
     in the stmt */
    Set @ParamDefinition =      ' @Make varchar(100),
	@Model varchar(100),
	@SerialNumberRange varchar,
	@PartNumber varchar(100),
	@PartManual text,
	@PartDescription varchar'
    /* Execute the Transact-SQL String with all parameter value's 
       Using sp_executesql Command */
    Execute sp_Executesql     @SQLQuery, 
                @ParamDefinition, 
                @Make,
				@Model,
				@SerialNumberRange,
				@PartNumber,
				@PartManual,
				@PartDescription
                
    If @@ERROR <> 0 GoTo ErrorHandler
    Set NoCount OFF
    Return(0)
  
ErrorHandler:
    Return(@@ERROR)

GO
/****** Object:  StoredProcedure [dbo].[UpdatePartsPrice]    Script Date: 8/25/2016 2:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePartsPrice]
	
	@PartNumber varchar(100) ,
	@ListPrice varchar(50) 
AS
-- EXEC dbo.UpdatePartsPrice '160000337','25'
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	  DECLARE @RowCount1 INTEGER
  UPDATE [dbo].[Parts]
   SET [ListPrice] = @ListPrice
 WHERE [PartNumber]  = @PartNumber 
  SELECT @RowCount1 = @@ROWCOUNT
  SELECT @RowCount1 AS UPDATEDCOUNT
END

GO
USE [master]
GO
ALTER DATABASE [BrownsAppDB] SET  READ_WRITE 
GO
