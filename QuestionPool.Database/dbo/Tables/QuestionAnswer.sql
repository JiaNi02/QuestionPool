CREATE TABLE [dbo].[QuestionAnswer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Answer] NVARCHAR(MAX) NULL, 
    [QuestionId] INT NULL, 
    [Choice] NVARCHAR(MAX) NULL, 
    [Order] INT NULL, 
    [Image] NVARCHAR(MAX) NULL, 
    [IsTheAnswer] BIT NULL,
    CONSTRAINT [FK_QuestionAnswer_ToQuestion] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
)

GO

CREATE INDEX [IX_QuestionAnswer_QuestionId] ON [dbo].[QuestionAnswer] ([QuestionId])
