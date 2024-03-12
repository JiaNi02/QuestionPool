CREATE TABLE [dbo].[ExamPaperDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ExamPaperId] INT NULL, 
    [QuestionId] INT NULL,
     [Title] NVARCHAR(MAX) NOT NULL, 
    [Status] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_ExamPaperDetails_ToQuestion] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]),
    CONSTRAINT [FK_ExamPaperDetails_ToExamPapers] FOREIGN KEY ([ExamPaperId]) REFERENCES [dbo].[ExamPapers] ([Id])
)
