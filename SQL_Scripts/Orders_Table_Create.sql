USE [IFB]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 4/29/2023 8:09:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Orders](
	[OrderId] [numeric](18, 0) NOT NULL PRIMARY KEY,
	[CustomerId] [int] NULL FOREIGN KEY REFERENCES Customers(CustomerId) ,
	[Total_Cost] [decimal](18, 2) NOT NULL,
)

