CREATE TABLE [dbo].[ExamPapers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NULL, 
    [UserDetailId] INT NULL, 
    [DateAdded] DATETIME NULL, 
    [IsDeleted] BIT NULL
)
