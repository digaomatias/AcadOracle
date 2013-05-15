CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TipoUsuarioId] INT NOT NULL, 
	[Nome] NCHAR(100) NOT NULL, 
    [Email] NCHAR(255) NOT NULL, 
    [Senha] NCHAR(100) NOT NULL, 
    CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY (TipoUsuarioId) REFERENCES [TipoUsuario]([Id])
)
