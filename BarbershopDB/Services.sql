﻿CREATE TABLE [dbo].[Services](
	[Id] [int] NOT NULL IDENTITY,
	[Title] [nvarchar](50) NULL,
	[Price] [numeric](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO