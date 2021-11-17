CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(50) NULL, 
    [Surname] NVARCHAR(50) NULL, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(500) NOT NULL
)
