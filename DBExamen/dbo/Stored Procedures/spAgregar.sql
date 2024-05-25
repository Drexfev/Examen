-- =============================================
-- Author:Gerardo de León
-- Create date: May  24
-- Description:	Crea un registro de examen
-- =============================================

CREATE PROCEDURE [dbo].[spAgregar]
(
	-- Parámetros
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255),
	@Idioma CHAR(2)
)
AS
BEGIN
	
	DECLARE @sError VARCHAR(500);

	SET @sError = dbo.fn_ValidarRegistro(NULL, @Nombre, @Descripcion, @Idioma, 1);

	IF(LEN(@sError) > 0)
	BEGIN
		
		SELECT CAST(0 AS BIT) AS Success, @sError AS Menssage, 0 AS Dato

	END
	ELSE 
	BEGIN

		INSERT INTO dbo.tblExamen (Nombre, Descripcion)
		VALUES(@Nombre, @Descripcion)

	END

	SELECT CAST(1 AS BIT) AS Success, dbo.fn_ObtenerMensaje(2, @Idioma) AS Menssage, SCOPE_IDENTITY() AS Dato;
	
END