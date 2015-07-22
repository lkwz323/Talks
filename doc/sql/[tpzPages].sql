USE [TalksDB]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__tpzPages__PageID__014935CB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tpzPages] DROP CONSTRAINT [DF__tpzPages__PageID__014935CB]
END

GO

USE [TalksDB]
GO

/****** Object:  Table [dbo].[tpzPages]    Script Date: 07/22/2015 16:16:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tpzPages]') AND type in (N'U'))
DROP TABLE [dbo].[tpzPages]
GO

USE [TalksDB]
GO

/****** Object:  Table [dbo].[tpzPages]    Script Date: 07/22/2015 16:16:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tpzPages](
	[PageID] [varchar](50) NOT NULL,
	[FriendlyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tpzPages] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tpzPages] ADD  DEFAULT (newid()) FOR [PageID]
GO


