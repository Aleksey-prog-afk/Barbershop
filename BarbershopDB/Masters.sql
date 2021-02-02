CREATE TABLE [dbo].[Masters](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](10) NULL,
	[SheduleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Masters]  WITH CHECK ADD  CONSTRAINT [FK_Мастер_Расписание] FOREIGN KEY([SheduleId])
REFERENCES [dbo].[Schedules] ([Id])
GO

ALTER TABLE [dbo].[Masters] CHECK CONSTRAINT [FK_Мастер_Расписание]
GO