CREATE TABLE [dbo].[Table]
(
	[Username] NVARCHAR(50) NOT NULL ,
	[FirstName] NVARCHAR(50) NOT NULL , 
    [LastName] NVARCHAR(50) NOT NULL, 
    [MiddleInitial] NCHAR(10) NULL, 
    [Title] NVARCHAR(50) NULL, 
    [Role] INT NOT NULL DEFAULT 0, 
    [QReception] BIT NOT NULL , 
    [QTshirt] INT NOT NULL DEFAULT 0, 
    [QDiet] NVARCHAR(MAX) NULL, 
    [QSponsor] NVARCHAR(MAX) NULL, 
    [QRegion] INT NOT NULL, 
    PRIMARY KEY ([Username])
)
