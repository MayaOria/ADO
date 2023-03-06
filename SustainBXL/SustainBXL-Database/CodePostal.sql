CREATE TABLE [dbo].[CodePostal]
(
	[IdCodePostal] INT NOT NULL IDENTITY, 
    [code] INT NOT NULL, 
    [localite] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_CodePostal] PRIMARY KEY ([IdCodePostal]), 
    CONSTRAINT [CK_CodePostal_code] CHECK ([code] > 999 AND [code] < 1999) 
)
