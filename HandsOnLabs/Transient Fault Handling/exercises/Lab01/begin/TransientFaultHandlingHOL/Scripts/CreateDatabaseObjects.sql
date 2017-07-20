USE [ProductsSampleDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================
-- Create products table
-- =======================================================


CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[SupplierID] [int] NULL,
	[CategoryID] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitsOnOrder] [smallint] NULL,
	[ReorderLevel] [smallint] NULL,
	[Discontinued] [bit] NOT NULL
	)

GO

-- =======================================================
-- Insert data in products
-- =======================================================

INSERT INTO Products values ('Chai',1,1,'10 boxes x 20 bags',18,39,0,10,0)
INSERT INTO Products values ('Chang',1,1,'24 - 12 oz bottles',19,17,40,25,0)
INSERT INTO Products values ('Aniseed Syrup',1,2,'12 - 550 ml bottles',10,13,70,25,0)
INSERT INTO Products values ('Chef Anton''s Cajun Seasoning',2,2,'48 - 6 oz jars',22,53,0,0,0)
INSERT INTO Products values ('Chef Anton''s Gumbo Mix',2,2,'36 boxes',21.35,0,0,0,0)
INSERT INTO Products values ('Grandma''s Boysenberry Spread',3,2,'12 - 8 oz jars',25,120,0,25,0)
INSERT INTO Products values ('Uncle Bob''s Organic Dried Pears',3,7,'12 - 1 lb pkgs.',30,15,0,10,0)
INSERT INTO Products values ('Northwoods Cranberry Sauce',3,2,'12 - 12 oz jars',40,6,0,0,0)
INSERT INTO Products values ('Mishi Kobe Niku',4,6,'18 - 500 g pkgs.',97,29,0,0,0)
INSERT INTO Products values ('Ikura',4,8,'12 - 200 ml jars',31,31,0,0,0)


-- =======================================================
-- Create stored procedures
-- =======================================================

--/////////////////////////////////////////////////////////////////////
if exists (select * from sysobjects where id = object_id('dbo.GetProductDetails') and sysstat & 0xf = 4)
	drop procedure "dbo"."GetProductDetails"
GO

CREATE Procedure [dbo].[GetProductDetails]
(
@ProductID		int,
@SessionID		nvarchar (20),
@NumberOfTriesBeforeSucceeding int
)
AS

-- Code added for demo purpose: add a call counter table
IF OBJECT_ID('dbo.CallCountTable') IS NULL
CREATE TABLE CallCountTable (CurrentCallCount INT, SessionID VARCHAR(50));

IF EXISTS (select * from CallCountTable where SessionID = @SessionID)
UPDATE CallCountTable SET CurrentCallCount = CurrentCallCount + 1 where SessionID = @SessionID;
ELSE
INSERT INTO CallCountTable (CurrentCallCount, SessionID) VALUES (1, @SessionID);


-- Code added for demo purpose: add a call counter table
if EXISTS (select CurrentCallCount FROM CallCountTable WHERE CurrentCallCount < @NumberOfTriesBeforeSucceeding and SessionID = @SessionID)
BEGIN
	RAISERROR (N'A transient error has occurred', 16, 0)
END
ELSE
	SELECT * FROM Products WHERE ProductID = @ProductID

