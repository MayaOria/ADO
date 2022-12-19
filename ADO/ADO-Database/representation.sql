CREATE TABLE [dbo].[representation]
(
	[IdRepresentation] INT IDENTITY NOT NULL,
	[dateRepresentation] DATE NOT NULL,
	[heureRepresentation] TIME NOT NULL,
	[idSpectacle] INT NOT NULL,
	CONSTRAINT PK_Representation PRIMARY KEY ([idRepresentation]),
	CONSTRAINT [CK_Representation_date] CHECK ([dateRepresentation] > GETDATE()), 
    CONSTRAINT [FK_representation_spectacle] FOREIGN KEY ([idSpectacle]) REFERENCES [spectacle]([idSpectacle])
)
