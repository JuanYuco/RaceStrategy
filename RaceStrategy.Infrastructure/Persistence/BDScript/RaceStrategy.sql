USE [RaceStrategyManager]
GO
/****** Object:  User [RaceStrategy]    Script Date: 3/06/2025 8:50:53 a. m. ******/
CREATE USER [RaceStrategy] FOR LOGIN [RaceStrategy] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_datareader] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [RaceStrategy]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [RaceStrategy]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 3/06/2025 8:50:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[TeamId] [int] NOT NULL,
	[NationalityId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nationality]    Script Date: 3/06/2025 8:50:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Strategy]    Script Date: 3/06/2025 8:50:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Strategy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DriverId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[TotalLaps] [int] NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 3/06/2025 8:50:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tire]    Script Date: 3/06/2025 8:50:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tire](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[EstimatedLaps] [int] NOT NULL,
	[ConsumedPerLap] [decimal](3, 1) NOT NULL,
	[Performance] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TireByStrategy]    Script Date: 3/06/2025 8:50:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TireByStrategy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TireId] [int] NOT NULL,
	[StrategyId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Driver] ON 

INSERT [dbo].[Driver] ([Id], [Name], [TeamId], [NationalityId]) VALUES (1, N'Charles Leclerc', 1, 1)
INSERT [dbo].[Driver] ([Id], [Name], [TeamId], [NationalityId]) VALUES (2, N'Fernando Alonso', 2, 2)
SET IDENTITY_INSERT [dbo].[Driver] OFF
GO
SET IDENTITY_INSERT [dbo].[Nationality] ON 

INSERT [dbo].[Nationality] ([Id], [Description]) VALUES (1, N'Monegasque')
INSERT [dbo].[Nationality] ([Id], [Description]) VALUES (2, N'Spanish')
SET IDENTITY_INSERT [dbo].[Nationality] OFF
GO
SET IDENTITY_INSERT [dbo].[Strategy] ON 

INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (1, 1, CAST(N'2025-06-01T15:09:54.910' AS DateTime), 52, N'Juan Fernando')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (2, 2, CAST(N'2025-06-01T15:09:54.910' AS DateTime), 45, N'Juan Fernando')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (3, 1, CAST(N'2025-06-02T17:07:28.647' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (4, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (5, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (6, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (7, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (8, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (9, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (10, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (11, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (12, 1, CAST(N'2025-06-02T17:07:28.650' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (13, 1, CAST(N'2025-06-02T17:13:23.610' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (14, 1, CAST(N'2025-06-02T17:13:23.613' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (15, 1, CAST(N'2025-06-02T17:13:23.613' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (16, 1, CAST(N'2025-06-02T17:13:23.613' AS DateTime), 50, N'juan')
INSERT [dbo].[Strategy] ([Id], [DriverId], [Date], [TotalLaps], [CreatedBy]) VALUES (17, 1, CAST(N'2025-06-02T17:13:23.613' AS DateTime), 50, N'juan')
SET IDENTITY_INSERT [dbo].[Strategy] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([Id], [Name]) VALUES (1, N'Ferrari')
INSERT [dbo].[Team] ([Id], [Name]) VALUES (2, N'Aston Martin')
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[Tire] ON 

INSERT [dbo].[Tire] ([Id], [Type], [EstimatedLaps], [ConsumedPerLap], [Performance]) VALUES (1, N'Soft', 12, CAST(4.5 AS Decimal(3, 1)), 95)
INSERT [dbo].[Tire] ([Id], [Type], [EstimatedLaps], [ConsumedPerLap], [Performance]) VALUES (2, N'Medium', 20, CAST(4.0 AS Decimal(3, 1)), 88)
INSERT [dbo].[Tire] ([Id], [Type], [EstimatedLaps], [ConsumedPerLap], [Performance]) VALUES (3, N'Hard', 25, CAST(3.8 AS Decimal(3, 1)), 80)
SET IDENTITY_INSERT [dbo].[Tire] OFF
GO
SET IDENTITY_INSERT [dbo].[TireByStrategy] ON 

INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (1, 1, 1)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (2, 1, 1)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (3, 3, 1)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (4, 2, 2)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (5, 3, 2)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (6, 1, 3)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (7, 1, 3)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (8, 1, 3)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (9, 1, 3)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (10, 1, 4)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (11, 1, 4)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (12, 2, 4)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (13, 1, 5)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (14, 1, 5)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (15, 3, 5)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (16, 1, 6)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (17, 2, 6)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (18, 1, 6)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (19, 1, 7)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (20, 3, 7)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (21, 1, 7)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (22, 2, 8)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (23, 1, 8)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (24, 1, 8)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (25, 2, 9)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (26, 3, 9)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (27, 3, 10)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (28, 1, 10)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (29, 1, 10)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (30, 3, 11)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (31, 2, 11)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (32, 3, 12)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (33, 3, 12)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (34, 1, 13)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (35, 1, 13)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (36, 1, 13)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (37, 1, 13)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (38, 1, 14)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (39, 1, 14)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (40, 2, 14)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (41, 1, 15)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (42, 1, 15)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (43, 3, 15)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (44, 2, 16)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (45, 3, 16)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (46, 3, 17)
INSERT [dbo].[TireByStrategy] ([Id], [TireId], [StrategyId]) VALUES (47, 3, 17)
SET IDENTITY_INSERT [dbo].[TireByStrategy] OFF
GO
ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Driver_Nationality] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationality] ([Id])
GO
ALTER TABLE [dbo].[Driver] CHECK CONSTRAINT [FK_Driver_Nationality]
GO
ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Driver_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Driver] CHECK CONSTRAINT [FK_Driver_Team]
GO
ALTER TABLE [dbo].[Strategy]  WITH CHECK ADD  CONSTRAINT [FK_Strategy_Driver] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Driver] ([Id])
GO
ALTER TABLE [dbo].[Strategy] CHECK CONSTRAINT [FK_Strategy_Driver]
GO
ALTER TABLE [dbo].[TireByStrategy]  WITH CHECK ADD  CONSTRAINT [FK_TireByStrategy_Strategy] FOREIGN KEY([StrategyId])
REFERENCES [dbo].[Strategy] ([Id])
GO
ALTER TABLE [dbo].[TireByStrategy] CHECK CONSTRAINT [FK_TireByStrategy_Strategy]
GO
ALTER TABLE [dbo].[TireByStrategy]  WITH CHECK ADD  CONSTRAINT [FK_TireByStrategy_Tire] FOREIGN KEY([TireId])
REFERENCES [dbo].[Tire] ([Id])
GO
ALTER TABLE [dbo].[TireByStrategy] CHECK CONSTRAINT [FK_TireByStrategy_Tire]
GO
