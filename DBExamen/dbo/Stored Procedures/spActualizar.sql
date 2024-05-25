
-- =============================================
-- Author:Gerardo de León
-- Create date: May  24
-- Description:	Acualiza un registro de examen
-- =============================================

CREATE PROCEDURE [dbo].[spActualizar]
(
	-- Parámetros
	@IdExamen INT,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255),
	@Idioma CHAR(2)
)
AS
BEGIN
	
	DECLARE @sError VARCHAR(500);

	SET @sError = dbo.fn_ValidarRegistro(@IdExamen, @Nombre, @Descripcion, @Idioma, 2);

	IF(LEN(@sError) > 0)
	BEGIN
		
		SELECT CAST(0 AS BIT) AS Success, @sError AS Message, 0 AS Dato

	END
	ELSE 
	BEGIN

		UPDATE dbo.tblExamen 
		SET Nombre = @Nombre, Descripcion = @Descripcion
		WHERE idExamen = @IdExamen

		SELECT CAST(1 AS BIT) AS Success, dbo.fn_ObtenerMensaje(3, @Idioma) AS Menssage, 0 AS Dato;

	END

END