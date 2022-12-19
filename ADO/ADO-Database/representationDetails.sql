CREATE VIEW [dbo].[representationDetails]
	AS SELECT [idRepresentation],
			  [dateRepresentation],
			  [heureRepresentation],
			  
			  S.[nom] AS [nomSpectacle]
			  
			  
		FROM [representation] as R
			JOIN [spectacle] as S
			ON R.[idSpectacle] = S.[idSpectacle]
