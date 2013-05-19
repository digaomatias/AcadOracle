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