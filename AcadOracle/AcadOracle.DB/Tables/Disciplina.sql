CREATE TABLE [dbo].[Disciplina]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(255) NOT NULL, 
    [Creditos] INT NOT NULL, 
    [PreCreditos] INT NOT NULL, 
    [Semestre] SMALLINT NOT NULL,
	[Eletiva] BIT NOT NULL
)
