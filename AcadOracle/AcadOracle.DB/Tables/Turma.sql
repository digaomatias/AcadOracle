CREATE TABLE [dbo].[Turma]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[DisciplinaId] INT NOT NULL,
    [Numero] INT NOT NULL,
	[TurmaHorario] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Turma_Disciplina] FOREIGN KEY ([DisciplinaId]) REFERENCES [Disciplina]([Id])
)
