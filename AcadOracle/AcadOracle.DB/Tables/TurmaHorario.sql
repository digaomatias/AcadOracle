CREATE TABLE [dbo].[TurmaHorario]
(
	[TurmaId] INT NOT NULL, 
	[HorarioId] INT NOT NULL ,
    [DiaSemana] INT NOT NULL, 
    CONSTRAINT [PK_TurmaHorario] PRIMARY KEY ([HorarioId], [TurmaId]), 
    CONSTRAINT [FK_TurmaHorario_Horario] FOREIGN KEY ([HorarioId]) REFERENCES [Horario]([Id]), 
    CONSTRAINT [FK_TurmaHorario_Turma] FOREIGN KEY ([TurmaId]) REFERENCES [Turma]([Id])  
)
