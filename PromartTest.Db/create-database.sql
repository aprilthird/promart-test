CREATE DATABASE [PromartTestDB]
GO

USE [PromartTestDB];
GO

CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DocumentNumber] [nvarchar](max) NOT NULL,
	[Salary] [float] NOT NULL,
	[Age] [int] NOT NULL,
	[Profile] [nvarchar](max) NOT NULL,
	[AdmissionDate] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY ClUSTERED ( [Id] ));
GO

SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (1, N'Empleado 0', N'95465780', 3000, 20, N'Empleado', CAST(N'2020-01-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0860860' AS DateTime2), CAST(N'2022-12-20T18:02:12.6658266' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (2, N'Empleado 1', N'95955780', 9000, 19, N'Empleado', CAST(N'2020-04-17T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861434' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861431' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (3, N'Empleado 2', N'98087333', 6000, 18, N'Empleado', CAST(N'2020-11-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861439' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861438' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (4, N'Empleado 3', N'97728647', 3000, 22, N'Empleado', CAST(N'2020-04-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861441' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861441' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (5, N'Empleado 4', N'98695593', 4000, 18, N'Empleado', CAST(N'2020-09-13T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861445' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861444' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (6, N'Empleado 5', N'97390336', 4000, 28, N'Empleado', CAST(N'2021-08-18T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861447' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861447' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (7, N'Empleado 6', N'88198876', 6000, 19, N'Empleado', CAST(N'2021-08-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861450' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861449' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (8, N'Empleado 7', N'99828547', 7000, 20, N'Empleado', CAST(N'2021-04-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861452' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861452' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (9, N'Empleado 8', N'99270324', 9000, 23, N'Empleado', CAST(N'2021-11-11T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861456' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861455' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (10, N'Empleado 9', N'81666690', 4000, 30, N'Empleado', CAST(N'2021-02-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861458' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861458' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (11, N'Empleado 10', N'90397924', 6000, 33, N'Empleado', CAST(N'2022-01-03T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861462' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861461' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (12, N'Empleado 11', N'86188533', 6000, 22, N'Empleado', CAST(N'2022-08-03T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861465' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861464' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (13, N'Empleado 12', N'86631674', 4000, 30, N'Empleado', CAST(N'2022-04-05T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861468' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861467' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (14, N'Empleado 13', N'92583770', 9000, 33, N'Empleado', CAST(N'2022-03-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861470' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861470' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (15, N'Empleado 14', N'81718872', 4000, 28, N'Empleado', CAST(N'2022-02-24T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861472' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861472' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (16, N'Empleado 15', N'82252880', 6000, 21, N'Empleado', CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861477' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861476' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (17, N'Empleado 16', N'81983985', 4000, 19, N'Empleado', CAST(N'2022-04-18T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861480' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861480' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (18, N'Empleado 17', N'87882895', 7000, 28, N'Empleado', CAST(N'2022-11-27T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861483' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861483' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (19, N'Empleado 18', N'82733468', 6000, 26, N'Empleado', CAST(N'2022-08-14T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861486' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861486' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [DocumentNumber], [Salary], [Age], [Profile], [AdmissionDate], [CreatedAt], [UpdatedAt]) VALUES (20, N'Empleado 19', N'87681701', 4000, 21, N'Empleado', CAST(N'2022-07-28T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861488' AS DateTime2), CAST(N'2022-12-20T17:48:09.0861488' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
