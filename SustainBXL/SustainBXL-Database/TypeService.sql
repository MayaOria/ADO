CREATE TABLE [dbo].[TypeService]
(
	[IdTypeService] INT NOT NULL IDENTITY, 
    [nom] NVARCHAR(255) NOT NULL, 
    [description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_TypeService] PRIMARY KEY ([IdTypeService])
)
