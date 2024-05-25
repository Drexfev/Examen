CREATE TABLE [dbo].[tblExamenLog] (
    [idExamenLog] INT           IDENTITY (1, 1) NOT NULL,
    [idExamen]    INT           NOT NULL,
    [Nombre]      VARCHAR (255) NOT NULL,
    [Descripcion] VARCHAR (255) NOT NULL,
    [Fecha]       DATETIME      NOT NULL,
    CONSTRAINT [PK_tblExamenLog] PRIMARY KEY CLUSTERED ([idExamenLog] ASC)
);

