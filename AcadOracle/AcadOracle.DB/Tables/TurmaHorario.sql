CREATE TABLE [dbo].[TurmaHorario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TurmaId] INT NOT NULL, 
    [DiaSemana] INT NOT NULL, 
    CONSTRAINT [FK_TurmaHorario_Turma] FOREIGN KEY ([TurmaId]) REFERENCES [Turma]([Id])  
)
