IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE name = 'CommEngineProducts')
BEGIN
	CREATE DATABASE EnterpriseHee
END
GO

USE [CommEngineProducts]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('ProductCategory'))
BEGIN
	DROP TABLE [dbo].[ProductCategory];
END 
GO


GO
CREATE TABLE [dbo].[ProductCategory] (
    [ProductCategoryId] INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName]      VARCHAR (128) NULL
);

SET IDENTITY_INSERT [dbo].[ProductCategory] ON
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [CategoryName]) VALUES (1, N'Child Food')
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [CategoryName]) VALUES (2, N'Beverage')
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [CategoryName]) VALUES (3, N'Curry')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF

