USE [IFB]
GO

/****** Object:  Table [dbo].[Items]    Script Date: 4/29/2023 8:04:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Items](
	[ItemId] [int] NOT NULL PRIMARY KEY,
	[UPC] [numeric](18, 0) NOT NULL,
	[SKU] [numeric](18, 0) NOT NULL,
	[Description] [nvarchar](512) NULL,
	[Unit_Price] [decimal](18, 2) NOT NULL,
	[On_Hand] [numeric](5, 0) NOT NULL,
 )