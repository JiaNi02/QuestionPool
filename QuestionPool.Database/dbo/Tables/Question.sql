CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NULL, 
    [QuestionNumber] NVARCHAR(MAX) NULL, 
    [Questions] NVARCHAR(MAX) NULL, 
     [Choice] NVARCHAR(MAX) NULL,
    [Mark] INT NULL,
    [SubjectId] INT NULL,
    [ExamTypeId] INT NULL, 
    [Year] DATE NULL, 
    [TermId] INT NULL, 
    [CreatedByUserDetailsId] INT NULL, 
    [DataAdded] DATETIME NULL, 
    [IsDeleted] BIT NULL, 
    [Image] NVARCHAR(MAX) NULL,
     
    CONSTRAINT [FK_Question_ToExamType] FOREIGN KEY ([ExamTypeId]) REFERENCES [dbo].[ExamType] ([Id]),
    CONSTRAINT [FK_Question_ToSubjects] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subjects] ([Id]),
    CONSTRAINT [FK_Question_ToTerms] FOREIGN KEY ([TermId]) REFERENCES [dbo].[Terms] ([Id]),
    CONSTRAINT [FK_Question_ToUserDetails] FOREIGN KEY ([CreatedByUserDetailsId]) REFERENCES [dbo].[UserDetails] ([Id])
)

GO

CREATE INDEX [IX_Question_ExamType] ON [dbo].[Question] ([ExamTypeId])
