﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--Adiciona os horários
DELETE FROM Horario;

INSERT INTO Horario (Id, Descricao)
VALUES (1, 'A');
INSERT INTO Horario (Id, Descricao)
VALUES (2, 'B');
INSERT INTO Horario (Id, Descricao)
VALUES (3, 'C');
INSERT INTO Horario (Id, Descricao)
VALUES (4, 'D');
INSERT INTO Horario (Id, Descricao)
VALUES (5, 'E');
INSERT INTO Horario (Id, Descricao)
VALUES (6, 'F');
INSERT INTO Horario (Id, Descricao)
VALUES (7, 'G');
INSERT INTO Horario (Id, Descricao)
VALUES (8, 'H');
INSERT INTO Horario (Id, Descricao)
VALUES (9, 'I');
INSERT INTO Horario (Id, Descricao)
VALUES (10, 'J');
INSERT INTO Horario (Id, Descricao)
VALUES (11, 'K');
INSERT INTO Horario (Id, Descricao)
VALUES (12, 'L');
INSERT INTO Horario (Id, Descricao)
VALUES (13, 'M');
INSERT INTO Horario (Id, Descricao)
VALUES (14, 'N');
INSERT INTO Horario (Id, Descricao)
VALUES (15, 'P');

GO

--Adiciona o curso de CC
DELETE FROM CursoDisciplina;
DELETE FROM Curso;

INSERT INTO [dbo].[Curso]
           ([Nome])
     VALUES
           ('Ciências da Computação')
GO


DELETE FROM Disciplina;

DECLARE @semestre INT = 1;
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Matematica Discreta',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Calculo A',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Geometria Analitica',2 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algoritmos e Programacao I',6 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Introducao A Ciencia da Computacao',4 , @semestre,1,0);	

SET @semestre = 2;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Calculo B',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algebra Matricial',2 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algoritmos e Programacao II',6 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Logica para Computacao',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Linguagens Formais',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Organizacao e Arquit. de Computadores I',4 , @semestre,1,0);	

SET @semestre = 3;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Modelagem de Software',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Laboratorio de Banco de Dados I',2 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algoritmos e Programacao III',6 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Paradigmas de Linguagens de Programacao',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Teoria da Computacao',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Organizacao e Arquit. de Computadores II',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao para Software Basico',4 , @semestre,1,0);	

SET @semestre = 4;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Modelagem Conceit. e Proj. de Banco Dados',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Complexidade e Otimizacao',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Tecnicas de Programacao',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Computacao Grafica I',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Organizacao e Arquit. de Computadores III',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Compiladores',4 , @semestre,1,0);	

SET @semestre = 5;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Metodos Estatisticos',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Gerencia de Projetos de Software',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Projeto de Interfaces',2 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Metodos Formais para Computacao',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Computacao Grafica II',2 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Sistemas Operacionais',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Redes de Computadores I',4 , @semestre,1,0);	

SET @semestre = 6;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Desenvolvimento de Sistemas',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Implementacao de Banco de Dados',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Entretenimento Digital',2 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Inteligencia Artificial',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Metodos Computacionais',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao de Perifericos',2 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Redes de Computadores II',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Laboratorio de Redes de Computadores',2 , @semestre,1,0);	

SET @semestre = 7;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Humanismo e Cultura Religiosa',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Trabalho de Conclusao I',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Avaliacao de Desempenho de Sistemas',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Redes de Computadores III',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao Paralela',2 , @semestre,1,0);	

SET @semestre = 8;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Etica e Filosofia da Ciencia',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Empreendimentos Empresariais',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Trabalho de Conclusao II',4 , @semestre,1,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Sistemas Embarcados',4 , @semestre,1,0);
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao Distribuida',4 , @semestre,1,0);

GO

--Adiciona as disciplinas no curso de CC.
DECLARE @CursoId INT;
SELECT TOP 1 @CursoId = Id FROM Curso;

INSERT INTO [dbo].[CursoDisciplina]
           ([CursoId]
           ,[DisciplinaId])
SELECT @CursoId, Id FROM Disciplina;

GO


