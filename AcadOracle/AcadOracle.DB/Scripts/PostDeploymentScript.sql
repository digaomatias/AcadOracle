/*
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

GO

--Adiciona o curso de CC
DELETE FROM CursoDisciplina;
DELETE FROM Curso;

INSERT INTO [dbo].[Curso]
           ([Nome])
     VALUES
           ('Ciências da Computação')
GO


DELETE FROM DisciplinasPreRequisitos;
DELETE FROM Disciplina;

DECLARE @semestre INT = 1;
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Matematica Discreta',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Calculo A',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Geometria Analitica',2 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algoritmos e Programacao I',6 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Introducao A Ciencia da Computacao',4 , 0, @semestre,0);	

SET @semestre = 2;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Calculo B',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algebra Matricial',2 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algoritmos e Programacao II',6 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Logica para Computacao',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Linguagens Formais',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Organizacao e Arquit. de Computadores I',4 , 0, @semestre,0);	


SET @semestre = 3;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Modelagem de Software',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Laboratorio de Banco de Dados I',2 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Algoritmos e Programacao III',6 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Paradigmas de Linguagens de Programacao',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Teoria da Computacao',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Organizacao e Arquit. de Computadores II',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao para Software Basico',4 , 0, @semestre,0);	

SET @semestre = 4;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Modelagem Conceit. e Proj. de Banco Dados',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Complexidade e Otimizacao',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Tecnicas de Programacao',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Computacao Grafica I',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Organizacao e Arquit. de Computadores III',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Compiladores',4 , 0, @semestre,0);	

SET @semestre = 5;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Metodos Estatisticos',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Gerencia de Projetos de Software',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Projeto de Interfaces',2 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Metodos Formais para Computacao',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Computacao Grafica II',2 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Sistemas Operacionais',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Redes de Computadores I',4 , 0, @semestre,0);	

SET @semestre = 6;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Desenvolvimento de Sistemas',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Implementacao de Banco de Dados',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Entretenimento Digital',2 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Inteligencia Artificial',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Metodos Computacionais',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao de Perifericos',2 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Redes de Computadores II',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Laboratorio de Redes de Computadores',2 , 0, @semestre,0);	

SET @semestre = 7;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Humanismo e Cultura Religiosa',4 , 60, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Trabalho de Conclusao I',4 , 100, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Avaliacao de Desempenho de Sistemas',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Redes de Computadores III',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao Paralela',2 , 0, @semestre,0);	

SET @semestre = 8;

INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Etica e Filosofia da Ciencia',4 , 60, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Empreendimentos Empresariais',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Trabalho de Conclusao II',4 , 0, @semestre,0);	
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Sistemas Embarcados',4 , 0, @semestre,0);
INSERT INTO [dbo].[Disciplina] ([Nome], [Creditos], [PreCreditos], [Semestre], [Eletiva])
VALUES ('Programacao Distribuida',4 , 0, @semestre,0);

GO

INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Calculo B'), (SELECT ID FROM Disciplina WHERE Nome='Calculo A'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao II'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Linguagens Formais'), (SELECT ID FROM Disciplina WHERE Nome='Matematica Discreta'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Linguagens Formais'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Organizacao e Arquit. de Computadores I'), (SELECT ID FROM Disciplina WHERE Nome='Introducao A Ciencia da Computacao'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Logica para Computacao'), (SELECT ID FROM Disciplina WHERE Nome='Matematica Discreta'));

INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Teoria da Computacao'), (SELECT ID FROM Disciplina WHERE Nome='Logica para Computacao'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Paradigmas de Linguagens de Programacao'), (SELECT ID FROM Disciplina WHERE Nome='Logica para Computacao'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Paradigmas de Linguagens de Programacao'), (SELECT ID FROM Disciplina WHERE Nome='Linguagens Formais'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Paradigmas de Linguagens de Programacao'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao II'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Organizacao e Arquit. de Computadores II'), (SELECT ID FROM Disciplina WHERE Nome='Organizacao e Arquit. de Computadores I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Laboratorio de Banco de Dados I'), (SELECT ID FROM Disciplina WHERE Nome='Matematica Discreta'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Modelagem de Software'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao II'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Programacao para Software Basico'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao II'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao III'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao II'));

INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Organizacao e Arquit. de Computadores III'), (SELECT ID FROM Disciplina WHERE Nome='Organizacao e Arquit. de Computadores II'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Compiladores'), (SELECT ID FROM Disciplina WHERE Nome='Organizacao e Arquit. de Computadores II'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Compiladores'), (SELECT ID FROM Disciplina WHERE Nome='Paradigmas de Linguagens de Programacao'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Modelagem Conceit. e Proj. de Banco Dados'), (SELECT ID FROM Disciplina WHERE Nome='Laboratorio de Banco de Dados I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Tecnicas de Programacao'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao III'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Complexidade e Otimizacao'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao III'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Computacao Grafica I'), (SELECT ID FROM Disciplina WHERE Nome='Algebra Matricial'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Computacao Grafica I'), (SELECT ID FROM Disciplina WHERE Nome='Programacao para Software Basico'));

INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Metodos Formais para Computacao'), (SELECT ID FROM Disciplina WHERE Nome='Logica para Computacao'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Redes de Computadores I'), (SELECT ID FROM Disciplina WHERE Nome='Programacao para Software Basico'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Sistemas Operacionais'), (SELECT ID FROM Disciplina WHERE Nome='Programacao para Software Basico'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Projeto de Interfaces'), (SELECT ID FROM Disciplina WHERE Nome='Modelagem de Software'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Gerencia de Projetos de Software'), (SELECT ID FROM Disciplina WHERE Nome='Modelagem de Software'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Computacao Grafica II'), (SELECT ID FROM Disciplina WHERE Nome='Computacao Grafica I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Metodos Estatisticos'), (SELECT ID FROM Disciplina WHERE Nome='Calculo A'));

INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Laboratorio de Redes de Computadores'), (SELECT ID FROM Disciplina WHERE Nome='Redes de Computadores I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Redes de Computadores II'), (SELECT ID FROM Disciplina WHERE Nome='Redes de Computadores I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Programacao de Perifericos'), (SELECT ID FROM Disciplina WHERE Nome='Sistemas Operacionais'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Implementacao de Banco de Dados'), (SELECT ID FROM Disciplina WHERE Nome='Modelagem Conceit. e Proj. de Banco Dados'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Desenvolvimento de Sistemas'), (SELECT ID FROM Disciplina WHERE Nome='Modelagem Conceit. e Proj. de Banco Dados'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Desenvolvimento de Sistemas'), (SELECT ID FROM Disciplina WHERE Nome='Tecnicas de Programacao'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Desenvolvimento de Sistemas'), (SELECT ID FROM Disciplina WHERE Nome='Gerencia de Projetos de Software'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Inteligencia Artificial'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao III'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Entretenimento Digital'), (SELECT ID FROM Disciplina WHERE Nome='Computacao Grafica I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Metodos Computacionais'), (SELECT ID FROM Disciplina WHERE Nome='Algoritmos e Programacao I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Metodos Computacionais'), (SELECT ID FROM Disciplina WHERE Nome='Calculo B'));

INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Redes de Computadores III'), (SELECT ID FROM Disciplina WHERE Nome='Redes de Computadores II'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Programacao Paralela'), (SELECT ID FROM Disciplina WHERE Nome='Sistemas Operacionais'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Avaliacao de Desempenho de Sistemas'), (SELECT ID FROM Disciplina WHERE Nome='Metodos Estatisticos'));

INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Programacao Distribuida'), (SELECT ID FROM Disciplina WHERE Nome='Redes de Computadores I'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Sistemas Embarcados'), (SELECT ID FROM Disciplina WHERE Nome='Programacao Paralela'));
INSERT INTO [dbo].DisciplinasPreRequisitos ([DisciplinaId], [PreRequisitoId]) VALUES ((SELECT ID FROM Disciplina WHERE Nome='Trabalho de Conclusao II'), (SELECT ID FROM Disciplina WHERE Nome='Trabalho de Conclusao I'));

GO

INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao I'), 128, '2JK4JK6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao I'), 138, '2JK4JK6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao I'), 148, '2NP4NP6NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Calculo A'), 128, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Calculo A'), 138, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Geometria Analitica'), 128, '6LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Geometria Analitica'), 138, '6LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Introducao a Ciencia da Computacao'), 128, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Introducao a Ciencia da Computacao'), 138, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Matematica Discreta'), 128, '3JK5JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Matematica Discreta'), 138, '3NP5NP');

INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='algebra Matricial'), 128, '3NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='algebra Matricial'), 138, '3LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao II'), 128, '2JK4JK6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao II'), 138, '2LM4LM6LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao II'), 148, '2JK4JK6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Calculo B'), 128, '2NP4NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Calculo B'), 138, '2NP4NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Linguagens Formais'), 128, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Linguagens Formais'), 138, '3JK5JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Logica para Computacao'), 128, '3JK5JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Logica para Computacao'), 138, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Organizacao e Arquitetura de Computadores I'), 128, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Organizacao e Arquitetura de Computadores I'), 138, '2JK4JK');

INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao III'), 128, '2LM4LM6LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao III'), 138, '2JK4JK6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Algoritmos e Programacao III'), 148, '2JK4JK6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Laboratorio de Banco de Dados I'), 128, '6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Laboratorio de Banco de Dados I'), 138, '6LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Laboratorio de Banco de Dados I'), 148, '6LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Modelagem de Software'), 128, '2NP4NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Modelagem de Software'), 138, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Organizacao e Arquitetura de Computadores II'), 128, '3JK5JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Paradigmas de Linguagens de Programacao'), 128, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Programacao para Software Basico'), 128, '2JK4JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Programacao para Software Basico'), 138, '2NP4NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Teoria da Computacao'), 128, '3NP5NP');

INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Compiladores'), 128, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Complexidade e Otimizacao'), 128, '2NP4NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Computacao Grafica I'), 128, '2JK4JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Modelagem Conceitual e Projeto de Banco de Dados'), 128, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Organizacao e Arquitetura de Computadores III'), 128, '3JK5JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='TEcnicas de Programacao'), 128, '3NP5NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='TEcnicas de Programacao'), 138, '3JK5JK');

INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Computacao Grafica II'), 128, '3JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Gerencia de Projeto de Software'), 128, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='MEtodos Estatisticos'), 128, '3NP5NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='MEtodos Formais para Computacao'), 128, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Projeto de Interfaces'), 128, '5JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Projeto de Interfaces'), 138, '6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Redes de Computadores I'), 128, '2JK4JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Sistemas Operacionais'), 128, '2NP4NP');

INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Desenvolvimento de Sistemas'), 128, '3NP5NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Entretenimento Digital'), 128, '2JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Implementacao de Banco de Dados'), 128, '2NP4NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Inteligencia Artificial'), 128, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Laboratorio de Redes de Computadores'), 128, '6JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Laboratorio de Redes de Computadores'), 138, '6LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='MEtodos Computacionais'), 128, '2LM4LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Programacao de PerifEricos'), 128, '4JK');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Redes de Computadores II'), 128, '3JK5JK');

INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Empreendimentos Empresariais'), 128, '3LM5LM');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Etica e Filosofia da Ciencia'), 128, '6LM6NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Programacao Distribuida'), 128, '3NP5NP');
INSERT INTO Turma (DisciplinaId, Numero, TurmaHorario) VALUES((SELECT Id FROM Disciplina WHERE Nome='Sistemas Embarcados'), 128, '2LM4LM');

GO

--Adiciona as disciplinas no curso de CC.
DECLARE @CursoId INT;
SELECT TOP 1 @CursoId = Id FROM Curso;

INSERT INTO [dbo].[CursoDisciplina]
           ([CursoId]
           ,[DisciplinaId])
SELECT @CursoId, Id FROM Disciplina;

GO


