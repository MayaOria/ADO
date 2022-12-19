CREATE TABLE [dbo].[ticket]
(
	[IdTicket] INT NOT NULL IDENTITY, 
    [dateTicket] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [idClient] INT NOT NULL, 
    [idRepresentation] INT NOT NULL, 
    [idType] INT NOT NULL, 

    CONSTRAINT [PK_Ticket] PRIMARY KEY ([IdTicket]),
    CONSTRAINT [FK_ticket_client] FOREIGN KEY ([idClient]) REFERENCES [client]([idClient]), 
    CONSTRAINT [FK_ticket_representation] FOREIGN KEY ([idRepresentation]) REFERENCES [representation]([idRepresentation]), 
    CONSTRAINT [FK_ticket_type] FOREIGN KEY ([idType]) REFERENCES [type]([idType])
)
