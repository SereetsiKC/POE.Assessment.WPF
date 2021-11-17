CREATE TABLE [school].[ModuleInformation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentInformationId] INT NOT NULL, 
    [CodeId] INT NOT NULL, 
    [Code] VARCHAR(20) NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [NumberOfCredits] INT NOT NULL, 
    [ClassHoursPerWeek] INT NOT NULL, 
    [HoursOfSelfStudy] INT NOT NULL, 
    [SelfStudyHoursPerWeek] DECIMAL(18, 10) NULL, 
    [StudyDate] DATETIME NOT NULL,   
    CONSTRAINT [FK_ModuleInformation_Module] FOREIGN KEY ([CodeId]) REFERENCES [school].[Modules]([Id]),
    CONSTRAINT [FK_ModuleInformation_StudentInformation] FOREIGN KEY ([StudentInformationId]) REFERENCES [school].[StudentInformation]([Id])
)
