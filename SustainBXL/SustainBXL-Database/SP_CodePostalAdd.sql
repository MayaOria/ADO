CREATE PROCEDURE [dbo].[SP_CodePostalAdd]
	@code int = 0,
	@localite nvarchar(50)
AS
	INSERT INTO [CodePostal] ([code], [localite]) 
	OUTPUT ([inserted].[IdCodePostal])
	VALUES (@code, @localite)
