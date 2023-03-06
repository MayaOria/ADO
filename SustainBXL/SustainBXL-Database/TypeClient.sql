CREATE TABLE [dbo].[TypeClient]
(
	[IdTypeClient] INT NOT NULL IDENTITY, 
    [nom] NVARCHAR(255) NOT NULL, 
    [description] NVARCHAR(MAX) NULL
	CONSTRAINT [PK_TypeClient] PRIMARY KEY ([IdTypeClient]) 
)

GO
