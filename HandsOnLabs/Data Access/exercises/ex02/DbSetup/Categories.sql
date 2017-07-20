use EntlibQuickStarts

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategories]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategories]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Products_Categories]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Products] DROP CONSTRAINT FK_Products_Categories
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Categories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Categories]
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Categories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Categories] (
	[CategoryID] [int] IDENTITY (1, 1) NOT NULL ,
	[CategoryName] [nvarchar] (15) COLLATE Latin1_General_CI_AS NOT NULL ,
	[Description] [ntext] COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

ALTER TABLE [dbo].[Categories] WITH NOCHECK ADD 
	CONSTRAINT [PK_Categories] PRIMARY KEY  CLUSTERED 
	(
		[CategoryID]
	)  ON [PRIMARY] 
GO

 CREATE  INDEX [CategoryName] ON [dbo].[Categories]([CategoryName]) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCategories
AS
            /* SET NOCOUNT ON */
            SELECT     CategoryID, CategoryName, Description
            FROM         Categories 
            RETURN
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

DELETE CATEGORIES
SET IDENTITY_INSERT CATEGORIES ON

INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (1,'Beverages','Soft drinks, coffees, teas, beers, and ales')
INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (2,'Condiments','Sweet and savory sauces, relishes, spreads, and seasonings')
INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (3,'Confections','Desserts, candies, and sweet breads')
INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (4,'Dairy Products','Cheeses')
INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (5,'Grains/Cereals','Breads, crackers, pasta, and cereal')
INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (6,'Meat/Poultry','Prepared meats')
INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (7,'Produce','Dried fruit and bean curd')
INSERT INTO CATEGORIES(CategoryID,CategoryName,Description) VALUES (8,'Seafood','Seaweed and fish')

SET IDENTITY_INSERT CATEGORIES OFF