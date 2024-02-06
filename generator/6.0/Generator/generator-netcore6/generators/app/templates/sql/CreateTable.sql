USE [Temporal]
GO

/****** Object:  Table [dbo].[User]    Script Date: 26/04/2023 04:02:36 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[Create] [datetime] NULL,
	[User] [nvarchar](50) NULL,
	[UserCreated] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
	[UserModified] [nvarchar](50) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


