CREATE TABLE [dbo].[CursoDisciplina]
(
	[CursoId] INT NOT NULL, 
    [DisciplinaId] INT NOT NULL,
	CONSTRAINT [PK_CursoDisciplina] PRIMARY KEY CLUSTERED([CursoId], [DisciplinaId]), 
    CONSTRAINT [FK_CursoDisciplina_Curso] FOREIGN KEY (CursoId) REFERENCES [Curso]([Id]), 
    CONSTRAINT [FK_CursoDisciplina_Disciplina] FOREIGN KEY ([DisciplinaId]) REFERENCES [Disciplina]([Id])
)

