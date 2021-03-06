USE [dbCard]
GO
/****** Object:  Table [dbo].[BirthdayDiscount]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BirthdayDiscount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiscountPercent] [decimal](2, 2) NOT NULL,
	[PartnerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](40) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[Age] [int] NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Foto] [varbinary](max) NULL,
	[DateOfRegistration] [date] NOT NULL,
	[IsPremium] [int] NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomersBalance]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoritePartners]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoritePartners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PartnerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filials]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartnerId] [int] NOT NULL,
	[Address] [nvarchar](40) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartnerId] [int] NOT NULL,
	[Foto] [varbinary](max) NULL,
	[Title] [nvarchar](40) NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[ShortBody] [nvarchar](100) NULL,
	[DateOfCreation] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Category] [nvarchar](40) NOT NULL,
	[Rating] [decimal](2, 2) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[Logo] [varbinary](max) NULL,
	[DateOfRegistration] [date] NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PremiumCustomers]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PremiumCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PartnerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PremiumDiscount]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PremiumDiscount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriceOfDiscount] [decimal](4, 2) NOT NULL,
	[DiscountPercent] [decimal](2, 2) NOT NULL,
	[AccumulationPercent] [decimal](2, 2) NOT NULL,
	[PartnerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rewiews]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewiews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartnerId] [int] NOT NULL,
	[CustomerId] [int] NULL,
	[Body] [nvarchar](1000) NOT NULL,
	[NumbersOfLikes] [int] NOT NULL,
	[NumbersOfDislakes] [int] NOT NULL,
	[AnswerRewiew] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StandartDiscount]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandartDiscount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AmountOfDiscount] [decimal](4, 2) NOT NULL,
	[DiscountPercent] [decimal](2, 2) NOT NULL,
	[PartnerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartnerName] [nvarchar](40) NOT NULL,
	[FilialAddress] [nvarchar](40) NOT NULL,
	[Category] [nvarchar](40) NOT NULL,
	[AllAmount] [decimal](10, 2) NOT NULL,
	[AmountForPay] [decimal](10, 2) NOT NULL,
	[DiscountAmount] [decimal](10, 2) NOT NULL,
	[AccumulationAmount] [decimal](10, 2) NULL,
	[CustomerId] [int] NOT NULL,
	[FilialId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.03.2020 15:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Customer__1788CC4DC9976E5E]    Script Date: 13.03.2020 15:38:43 ******/
ALTER TABLE [dbo].[Customers] ADD UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Filials__85FB4E389AEDA3A8]    Script Date: 13.03.2020 15:38:43 ******/
ALTER TABLE [dbo].[Filials] ADD UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Partners__1788CC4DF29C39CE]    Script Date: 13.03.2020 15:38:43 ******/
ALTER TABLE [dbo].[Partners] ADD UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Partners__737584F6C229528E]    Script Date: 13.03.2020 15:38:43 ******/
ALTER TABLE [dbo].[Partners] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534DCD92106]    Script Date: 13.03.2020 15:38:43 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__C9F2845692B3557E]    Script Date: 13.03.2020 15:38:43 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BirthdayDiscount] ADD  DEFAULT ((0)) FOR [DiscountPercent]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [DateOfRegistration]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [IsPremium]
GO
ALTER TABLE [dbo].[CustomersBalance] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[News] ADD  DEFAULT (getdate()) FOR [DateOfCreation]
GO
ALTER TABLE [dbo].[Partners] ADD  DEFAULT ('UNIVERSAL') FOR [Category]
GO
ALTER TABLE [dbo].[Partners] ADD  DEFAULT ((0)) FOR [Rating]
GO
ALTER TABLE [dbo].[Partners] ADD  DEFAULT (getdate()) FOR [DateOfRegistration]
GO
ALTER TABLE [dbo].[PremiumDiscount] ADD  DEFAULT ((0)) FOR [PriceOfDiscount]
GO
ALTER TABLE [dbo].[PremiumDiscount] ADD  DEFAULT ((0)) FOR [DiscountPercent]
GO
ALTER TABLE [dbo].[PremiumDiscount] ADD  DEFAULT ((0)) FOR [AccumulationPercent]
GO
ALTER TABLE [dbo].[Rewiews] ADD  DEFAULT ((0)) FOR [NumbersOfLikes]
GO
ALTER TABLE [dbo].[Rewiews] ADD  DEFAULT ((0)) FOR [NumbersOfDislakes]
GO
ALTER TABLE [dbo].[StandartDiscount] ADD  DEFAULT ((0)) FOR [AmountOfDiscount]
GO
ALTER TABLE [dbo].[StandartDiscount] ADD  DEFAULT ((0)) FOR [DiscountPercent]
GO
ALTER TABLE [dbo].[BirthdayDiscount]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomersBalance]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomersBalance]  WITH CHECK ADD FOREIGN KEY([DiscountId])
REFERENCES [dbo].[PremiumDiscount] ([Id])
GO
ALTER TABLE [dbo].[FavoritePartners]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[FavoritePartners]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[Filials]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[Partners]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PremiumCustomers]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[PremiumCustomers]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[PremiumDiscount]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rewiews]  WITH CHECK ADD FOREIGN KEY([AnswerRewiew])
REFERENCES [dbo].[Rewiews] ([Id])
GO
ALTER TABLE [dbo].[Rewiews]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Rewiews]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[StandartDiscount]  WITH CHECK ADD FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD FOREIGN KEY([FilialId])
REFERENCES [dbo].[Filials] ([Id])
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD CHECK  (([IsPremium]=(0) OR [IsPremium]=(1)))
GO
ALTER TABLE [dbo].[Rewiews]  WITH CHECK ADD CHECK  (([NumbersOfLikes]>(0)))
GO
ALTER TABLE [dbo].[Rewiews]  WITH CHECK ADD CHECK  (([NumbersOfDislakes]>(0)))
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD CHECK  (([AccumulationAmount]>(0)))
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD CHECK  (([AllAmount]>(0)))
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD CHECK  (([AmountForPay]>(0)))
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD CHECK  (([DiscountAmount]>(0)))
GO
