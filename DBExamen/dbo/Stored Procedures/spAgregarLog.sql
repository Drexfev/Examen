-- =============================================
-- Author:Gerardo de León
-- Create date: May  24
-- Description:	Crea un registro al log examen
-- =============================================

CREATE PROCEDURE [dbo].[spAgregarLog]
(
	-- Parámetros
	@IdExamen INT,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255)
)
AS
BEGIN

		INSERT INTO dbo.tblExamenLog (idExamen, Nombre, Descripcion, Fecha)
		VALUES(@IdExamen, @Nombre, @Descripcion, GETDATE())

END