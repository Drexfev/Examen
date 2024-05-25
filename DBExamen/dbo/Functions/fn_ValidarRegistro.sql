-- =============================================
-- Author:		Gerardo De León
-- Create date: May, 24
-- Description:	Valida los registros del exámen
-- =============================================
CREATE FUNCTION [dbo].[fn_ValidarRegistro]
(
	-- Parameters
	@IdExamen INT = NULL,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255),
	@Idioma CHAR(2),
	@TypeTransaction TINYINT --(1- INSERT, 2- UPDATE, 3- DELETE, 4- SELECT)
)
RETURNS VARCHAR(500)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @sError VARCHAR(500);
	
	IF(@TypeTransaction = 2)
	BEGIN

		-- Valida que exista el Id del examen
		IF NOT EXISTS(SELECT NULL FROM dbo.tblExamen WHERE idExamen = @IdExamen)
		BEGIN 
			SET @sError = dbo.fn_ObtenerMensaje(1, @Idioma);
		END

	END

	IF(@TypeTransaction = 3)
	BEGIN

		-- Valida que exista el Id del examen
		IF NOT EXISTS(SELECT NULL FROM dbo.tblExamen WHERE idExamen = @IdExamen)
		BEGIN 
			SET @sError = dbo.fn_ObtenerMensaje(1, @Idioma);
		END

	END
	-- Return the result of the function
	RETURN @sError

END