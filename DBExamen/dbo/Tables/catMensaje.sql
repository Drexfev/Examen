CREATE TABLE [dbo].[catMensaje] (
    [IdMensaje] INT           IDENTITY (1, 1) NOT NULL,
    [es]        VARCHAR (250) NOT NULL,
    [en]        VARCHAR (250) NOT NULL,
    [pt]        VARCHAR (250) NOT NULL,
    [fr]        VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_catMensaje] PRIMARY KEY CLUSTERED ([IdMensaje] ASC)
);

