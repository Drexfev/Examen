
-- =============================================
-- Author:Gerardo de León
-- Create date: May  24
-- Description:	Elimina un registro de examen
-- =============================================

CREATE PROCEDURE [dbo].[spEliminar]
(
	-- Parámetros
	@IdExamen INT,
	@Idioma CHAR(2)
)
AS
BEGIN
	
	DECLARE @sError VARCHAR(500), @sNombre VARCHAR(255), @sDescripcion VARCHAR(255);

	SET @sError = dbo.fn_ValidarRegistro(@IdExamen, NULL, NULL, @Idioma, 3);

	IF(LEN(@sError) > 0)
	BEGIN
		
		SELECT CAST(0 AS BIT) AS Success, @sError AS Menssage, 0 AS Dato

	END
	ELSE 
	BEGIN

		DELETE FROM dbo.tblExamen 
		WHERE idExamen = @IdExamen

		SELECT @sNombre = Nombre, @sDescripcion = Descripcion FROM dbo.tblExamen WHERE idExamen = @IdExamen

		EXEC dbo.spAgregarLog @IdExamen, @sNombre, @sDescripcion;

	END

	SELECT CAST(1 AS BIT) AS Success, dbo.fn_ObtenerMensaje(4, @Idioma) AS Menssage, 0 AS Dato;
	
END