-- =============================================
-- Author:		Gerardo De León
-- Create date: May, 24
-- Description:	Regresa el mensaje traducido
-- =============================================
CREATE FUNCTION [dbo].[fn_ObtenerMensaje]
(
	-- Parameters
	@IdMensaje INT,
	@Idioma CHAR(2)
)
RETURNS VARCHAR(255)
AS
BEGIN
	
	DECLARE @sMensaje VARCHAR(255);

	SELECT @sMensaje = CASE WHEN @Idioma = 'es' THEN es WHEN @Idioma = 'en' THEN en WHEN @Idioma = 'pt' THEN pt WHEN @Idioma = 'fr' THEN fr END FROM dbo.catMensaje WHERE IdMensaje = @IdMensaje

	RETURN @sMensaje;

END