CREATE TABLE [dbo].[UserDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AspNetUserId] NVARCHAR(450) NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [DepartmentId] INT NOT NULL, 
    [Status] NVARCHAR(MAX) NULL,
    CONSTRAINT [FK_UserDetails_ToDepartment] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id]),
     CONSTRAINT [FK_UserDetails_ToAspNetUsers] FOREIGN KEY ([AspNetUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]), 

)
