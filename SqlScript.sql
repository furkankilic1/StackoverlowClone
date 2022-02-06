USE [DbStackoverflow]
GO

/****** Object:  Table [dbo].[Question]    Script Date: 6.02.2022 20:21:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Question](
	[Id] [uniqueidentifier] NOT NULL,
	[QuestionContent] [nvarchar](500) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF_Question_Id]  DEFAULT (newid()) FOR [Id]
GO

/****** Object:  Table [dbo].[Answer]    Script Date: 6.02.2022 20:20:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Answer](
	[Id] [uniqueidentifier] NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
	[AnswerContent] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Answer] ADD  CONSTRAINT [DF_Answer_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO

INSERT INTO [dbo].[Question]
           ([QuestionContent])
     VALUES
           ('How can I convert String to Int ?')
GO