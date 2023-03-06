CREATE PROCEDURE [dbo].[SP_AdresseAdd]
	@rue nvarchar(255),
	@numero nvarchar(50),
	@localite nvarchar(50)
AS
	INSERT INTO [Adresse] ([rue], [numero], [idCodePostal]) 
	OUTPUT ([inserted].[idAdresse])
	VALUES (@rue, @numero, (SELECT [idCodePostal] FROM [CodePostal] WHERE [localite] = @localite))
