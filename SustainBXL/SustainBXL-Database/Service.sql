CREATE TABLE [dbo].[Service]
(
	[IdService] INT NOT NULL IDENTITY, 
    [nomSociete] NVARCHAR(255) NOT NULL, 
    [telephone] CHAR(13) NULL, 
    [email] NVARCHAR(255) NULL, 
    [description] NVARCHAR(MAX) NULL, 
    [idAdresse] INT NOT NULL, 
    [idTypeClient] INT NOT NULL, 
    CONSTRAINT [PK_Service] PRIMARY KEY ([IdService]), 
    CONSTRAINT [FK_Service_Adresse] FOREIGN KEY ([IdAdresse]) REFERENCES [Adresse]([IdAdresse]), 
    CONSTRAINT [FK_Service_TypeClient] FOREIGN KEY ([IdTypeClient]) REFERENCES [TypeClient]([IdTypeClient]), 
    CONSTRAINT [CK_Service_email] CHECK ([email] LIKE '%___@___%.__%'), 
    CONSTRAINT [CK_Service_telephone] CHECK (ISNUMERIC(REPLACE(REPLACE(REPLACE([telephone],'+','00'),'/',''), '.', '')) = 1 )
)
