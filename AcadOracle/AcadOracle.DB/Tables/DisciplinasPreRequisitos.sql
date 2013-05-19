CREATE TABLE [dbo].[DisciplinasPreRequisitos]
(
	[DisciplinaId] INT NOT NULL ,
	[PreRequisitoId] INT NOT NULL, 
    PRIMARY KEY ([DisciplinaId], [PreRequisitoId]), 
    CONSTRAINT [FK_DisciplinasPreRequisitos_Disciplina] FOREIGN KEY ([DisciplinaId]) REFERENCES [Disciplina]([Id]),
	CONSTRAINT [FK_DisciplinasPreRequisitos_PreRequisito] FOREIGN KEY ([PreRequisitoId]) REFERENCES [Disciplina]([Id])
)
