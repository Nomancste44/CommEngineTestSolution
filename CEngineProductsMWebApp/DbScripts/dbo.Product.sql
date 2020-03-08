/*Create Database*/
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE name = 'CommEngineProducts')
BEGIN
	CREATE DATABASE EnterpriseHee
END
GO

USE [CommEngineProducts]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('Product'))
BEGIN
	DROP TABLE [dbo].[Product];
END 
GO


CREATE TABLE [dbo].[Product] (
    [ProductId]         INT           IDENTITY (1, 1) NOT NULL,
    [ProductName]       VARCHAR (128) NULL,
    [ManufacturedDate]  DATE          NULL,
    [ExpiredDate]       DATE          NULL,
    [ProductPrice]      FLOAT (53)    NULL,
    [ProductCategoryId] INT           NULL
);
GO

SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (1, N'Coco Cola', N'2018-03-12', N'2021-03-18', 15, 2)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (2, N'Corn Falke', N'2020-01-01', N'2021-01-01', 200, 1)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (3, N'sdasdf', N'2001-01-01', N'2001-01-01', 3, 2)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (4, N'Milk', N'2020-03-18', N'2020-03-19', 200, 2)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (5, N'Sprite', N'2001-01-01', N'2001-01-01', 300, 2)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (6, N'Spinach', N'2020-03-11', N'2020-03-20', 20, 3)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (7, N'Spinach', N'2020-03-11', N'2020-03-20', 20, 3)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (1003, N'Soft', N'2020-03-18', N'2020-03-16', 22, 2)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (1004, N'Soft1', N'2020-03-18', N'2020-03-16', 22, 2)
INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [ManufacturedDate], [ExpiredDate], [ProductPrice], [ProductCategoryId]) VALUES (2003, N'dahdlksa', N'2020-03-10', N'2020-03-20', 23, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF