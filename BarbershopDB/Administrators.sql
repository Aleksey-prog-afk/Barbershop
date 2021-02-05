CREATE TABLE [dbo].[Administrators](
	[Id] [int] NOT NULL IDENTITY,
	[Name] [nchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[Login] [nchar](10) NULL,
	[Password] [nchar](10) NULL,
 CONSTRAINT [PK_Администратор] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


