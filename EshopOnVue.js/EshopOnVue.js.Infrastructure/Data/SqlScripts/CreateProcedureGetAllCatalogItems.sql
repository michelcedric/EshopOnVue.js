CREATE PROCEDURE [dbo].[GetAllCatalogItems]  
AS
BEGIN    
    SELECT [Id],
		   [Name],
		   [Description],
		   [Price],
		   [PictureImageName]
    FROM [dbo].[CatalogItems]     
END    
GO  