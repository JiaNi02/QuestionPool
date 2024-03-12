CREATE TABLE [dbo].[Subjects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [SubjectCode] NVARCHAR(MAX) NOT NULL, 
    [DateCreated] DATETIME NULL, 
    [Status] NVARCHAR(MAX) NULL
)
