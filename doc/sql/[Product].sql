USE [TalksDB]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Product__Product__060DEAE8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF__Product__Product__060DEAE8]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Product__Name__07020F21]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF__Product__Name__07020F21]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Product__Descrip__07F6335A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF__Product__Descrip__07F6335A]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Product__Company__08EA5793]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF__Product__Company__08EA5793]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Product__Price__09DE7BCC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF__Product__Price__09DE7BCC]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Product__Categor__0AD2A005]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF__Product__Categor__0AD2A005]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Product_AddTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF_Product_AddTime]
END

GO

USE [TalksDB]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 07/23/2015 15:00:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO

USE [TalksDB]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 07/23/2015 15:00:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Product](
	[ProductID] [varchar](50) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[Company] [varchar](500) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT (newid()) FOR [ProductID]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [Description]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [Company]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [Category]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO


