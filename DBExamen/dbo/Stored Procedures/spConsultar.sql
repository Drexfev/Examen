
-- =============================================
-- Author:Gerardo de León
-- Create date: May  24
-- Description:	Cunsulta registros de examen
-- =============================================

CREATE PROCEDURE [dbo].[spConsultar]
(
	-- Parámetros
	@FilNombre VARCHAR(255) = NULL
)
AS
BEGIN

	SELECT idExamen AS IdExamen, Nombre, Descripcion
	FROM dbo.tblExamen
	WHERE (@FilNombre IS NULL OR Nombre LIKE(CONCAT('%', @FilNombre, '%')));
	
END