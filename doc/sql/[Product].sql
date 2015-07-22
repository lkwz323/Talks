USE [TalksDB]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 07/22/2015 16:16:37 ******/
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


