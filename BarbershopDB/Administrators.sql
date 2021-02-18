CREATE TABLE [dbo].[Administrators](
	[Id] [int] NOT NULL IDENTITY,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50)  NULL,
	[Login] [nvarchar](50)  NULL,
	[Password] [nvarchar](50)  NULL,
	[Salt] [nvarchar](50)  NULL,
 CONSTRAINT [PK_Администратор] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


