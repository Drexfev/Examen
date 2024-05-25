CREATE TABLE [dbo].[tblExamen] (
    [idExamen]    INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (255) NOT NULL,
    [Descripcion] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_tblExamen] PRIMARY KEY CLUSTERED ([idExamen] ASC)
);

