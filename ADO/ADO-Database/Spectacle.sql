CREATE TABLE [dbo].[Spectacle]
(
	[IdSpectacle] INT NOT NULL IDENTITY , 
    [nom] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Spectacle] PRIMARY KEY ([IdSpectacle]), 
    CONSTRAINT [CK_Spectacle_nom] CHECK (LEN([nom]) >=3)
)

GO

CREATE UNIQUE INDEX [UK_Spectacle_nom] ON [dbo].[Spectacle] ([nom])
