/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [spectacle]([nom], [description])
VALUES (N'Inauguration', N'Ouverture du théâtre')

GO

INSERT INTO [type]([nom], [prix])
VALUES (N'Enfant', 5),
       (N'Etudiant', 8),
       (N'Adulte', 10)

