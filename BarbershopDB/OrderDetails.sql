CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[MasterId] [int] NULL,
	[Cost] [numeric](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([MasterId])
REFERENCES [dbo].[Masters] ([Id])
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO