CREATE TABLE [dbo].[client]
(
	[IdClient] INT NOT NULL IDENTITY, 
    [email] NVARCHAR(255) NOT NULL, 
    [pass] VARBINARY(64) NOT NULL, 
    [nom] NVARCHAR(50) NOT NULL, 
    [prenom] NVARCHAR(50) NOT NULL, 
    [adresse] NVARCHAR(MAX) NULL, 

    CONSTRAINT [PK_Client] PRIMARY KEY ([IdClient]),
    CONSTRAINT [CK_client_nom] CHECK (LEN([nom]) >= 1), 
    CONSTRAINT [CK_client_prenom] CHECK (LEN([nom]) >=1), 
    
)

GO

CREATE UNIQUE INDEX [UK_client_email] 
ON [dbo].[client] ([email])
