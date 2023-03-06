CREATE TABLE [dbo].[Adresse]
(
	[IdAdresse] INT NOT NULL IDENTITY, 
    [rue] NVARCHAR(255) NOT NULL, 
    [numero] NVARCHAR(50) NULL, 
    [idCodePostal] INT NOT NULL,
    CONSTRAINT [PK_Adresse] PRIMARY KEY ([IdAdresse]), 
    CONSTRAINT [FK_Adresse_CodePostal] FOREIGN KEY ([IdCodePostal]) REFERENCES [CodePostal]([IdCodePostal])
)
