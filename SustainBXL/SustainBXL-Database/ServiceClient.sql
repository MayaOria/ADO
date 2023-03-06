CREATE TABLE [dbo].[ServiceClient]
(
	[IdService] INT NOT NULL, 
    [IdTypeClient] INT NOT NULL, 
    CONSTRAINT [PK_ServiceClient] PRIMARY KEY ([IdService], [IdTypeClient]), 
    CONSTRAINT [FK_ServiceClient_Service] FOREIGN KEY ([IdService]) REFERENCES [Service]([IdService]), 
    CONSTRAINT [FK_ServiceClient_TypeClient] FOREIGN KEY ([IdTypeClient]) REFERENCES [TypeClient]([IdTypeClient]) 
)
