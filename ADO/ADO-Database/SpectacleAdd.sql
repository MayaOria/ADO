CREATE PROCEDURE [dbo].[SP_SpectacleAdd]
	@nom NVARCHAR (50),
	@desc NVARCHAR (MAX)
AS
	INSERT INTO [spectacle] ([nom], [description])
	OUTPUT ([inserted].[idSpectacle])
	VALUES (@nom, @desc)


