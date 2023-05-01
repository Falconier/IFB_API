USE [IFB]
GO

/****** Object:  Table [dbo].[OrderItems]    Script Date: 4/29/2023 8:11:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [OrderItems](
	[Id] [int] NOT NULL PRIMARY KEY,
	[OrderId] [numeric](18, 0) NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
	[ItemId] [int] NOT NULL FOREIGN KEY REFERENCES Items(ItemId),
	[Quantity] [int] NOT NULL,
)

