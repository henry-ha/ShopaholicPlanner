USE [aspnet-ShopaholicPlanner-20180820085048]
GO

/****** Object:  Table [dbo].[SP_SHOPPING_BASKET]    Script Date: 22/08/2018 19:54:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SP_SHOPPING_BASKET](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[Url] [nvarchar](2500) NULL,
	[Currency] [nvarchar](1) NOT NULL,
	[Price] [decimal](19, 2) NOT NULL,
	[CreateDateUTC] [datetime] NOT NULL,
	[UpdateDateUTC] [datetime] NULL,
	[ArchiveDateUTC] [datetime] NULL,
	[UserID] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_SP_SHOPPING_BASKET] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SP_SHOPPING_BASKET] ADD  CONSTRAINT [DF_SP_SHOPPING_BASKET_CreateDateUTC]  DEFAULT (getutcdate()) FOR [CreateDateUTC]
GO

ALTER TABLE [dbo].[SP_SHOPPING_BASKET]  WITH CHECK ADD CONSTRAINT [FK_dbo.SP_SHOPPING_BASKET_dbo.AspNetUsers_UserId] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[SP_SHOPPING_BASKET] CHECK CONSTRAINT [FK_dbo.SP_SHOPPING_BASKET_dbo.AspNetUsers_UserId]
GO