CREATE TABLE [school].[StudentInformation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentNumber] VARCHAR(50) NULL, 
    [Name] VARCHAR(50) NULL, 
    [Surname] VARCHAR(50) NULL,
    [SemesterId] INT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_StudentInformation_SemesterInformation] FOREIGN KEY ([SemesterId]) REFERENCES [school].[SemesterInformation]([Id]),
    CONSTRAINT [FK_StudentInformation_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id])
)
