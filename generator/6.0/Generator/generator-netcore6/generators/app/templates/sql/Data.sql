USE [Temporal]
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([id], [Name], [Active], [Create], [User], [UserCreated], [Created], [UserModified], [Modified]) VALUES (1, N'Miguel', 1, CAST(N'2023-04-26T00:00:00.000' AS DateTime), N'Admin', N'Admin', CAST(N'2023-04-26T00:00:00.000' AS DateTime), N'Admin', CAST(N'2023-04-26T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([id], [Name], [Active], [Create], [User], [UserCreated], [Created], [UserModified], [Modified]) VALUES (2, N'Andrea', 1, CAST(N'2023-04-26T00:00:00.000' AS DateTime), N'Admin', N'Admin', CAST(N'2023-04-26T00:00:00.000' AS DateTime), N'Admin', CAST(N'2023-04-26T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([id], [Name], [Active], [Create], [User], [UserCreated], [Created], [UserModified], [Modified]) VALUES (3, N'Ángel', 1, CAST(N'2023-04-26T00:00:00.000' AS DateTime), N'Admin', N'userToken', CAST(N'2023-04-26T21:50:16.827' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
