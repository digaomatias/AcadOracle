CREATE TABLE [dbo].[HoraAula]
(
	[HorarioId] INT NOT NULL , 
    [TurmaHorarioId] INT NOT NULL, 
    PRIMARY KEY ([HorarioId], [TurmaHorarioId]), 
    CONSTRAINT [FK_HoraAula_Horario] FOREIGN KEY ([HorarioId]) REFERENCES [Horario]([Id]), 
    CONSTRAINT [FK_HoraAula_TurmaHorario] FOREIGN KEY ([TurmaHorarioId]) REFERENCES [TurmaHorario]([Id]),
	
)
