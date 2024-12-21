-- Creare il database Losco
CREATE DATABASE Losco;
USE Losco;
-- Creare la tabella criminali che avrà id PK, nome, cognome, alias, dob, gruppo
CREATE TABLE Criminali(id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(255),
	cognome VARCHAR(255),
	alias VARCHAR(255),
	dob DATE,
	gruppo VARCHAR(255));
-- Creare la tabella armi che avrà id PK, nome, caricatore, calibro, automatica(1-0), colore, id_criminale FK
CREATE TABLE Armi(id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(255),
	caricatore INT,
	calibro VARCHAR(255),
	automatica BIT,
	colore VARCHAR(255),
	id_criminale INT,
	FOREIGN KEY (id_criminale) REFERENCES Criminali(id));


-- Inserite almeno 3 criminali e 5 armi
INSERT INTO Criminali
(nome, cognome, alias, dob, gruppo)
VALUES
('Piero','Ettore','Achille','1998-11-26','Escapar'),
('Pino','Pane','Baguette','1978-09-03','ChioscoNostro'),
('Franco','Franchi','Don','2000-09-29','ChioscoNostro'),
('Carla','Cracci','Ciclope','1989-12-07','Camoscio D''oro'),
('Giada','Furla','Biancaneve','1997-10-31','Escapar');
INSERT INTO Armi
(nome,caricatore,calibro,automatica,colore,id_Criminale)
VALUES
('Pulisci Tutto',30,'10mm',1,'Nero',3),
('Multipla',113,'MM54',1,'Verde Bosco',3),
('Beretta',12,'9mm',0,'Grigio',null),
('Desert Eagle',20,'12mm',1,'Oro',1),
('Beretta',12,'9mm',0,'Grigio',2),
('Revolver',6,'6mm',0,'Argento',4);


-- visualizzare:
-- Per ogni criminale, il suo alias e la sua età
SELECT alias, DATEDIFF(YEAR,dob,SYSDATETIME()) AS etaCriminale
FROM Criminali;
-- Per ogni criminale il numero di armi che possiede
SELECT Criminali.nome, Criminali.cognome, COUNT(Armi.id) AS numeroArmi
FROM Armi JOIN Criminali
ON Criminali.id = Armi.id_criminale
GROUP BY Criminali.nome, Criminali.cognome;
-- i criminali che non possiedono armi 
SELECT Criminali.alias AS criminaliSenzaArmi
FROM Criminali LEFT JOIN Armi
ON Criminali.id = Armi.id_criminale
WHERE Armi.id IS NULL;
-- L'alias della persona/e che possiede/ono l'arma con il caricatore maggiore
SELECT Criminali.alias, MAX(Armi.caricatore) AS caricatoreMaggiore
FROM Criminali JOIN Armi
ON Criminali.id = Armi.id_criminale
WHERE armi.Caricatore = (SELECT MAX(Armi.caricatore) AS caricatoreMaggiore FROM Armi)
GROUP BY Criminali.alias;
-- Il numero di armi automatiche e non(-- e se ho delle armi che hanno automatica=null?)
SELECT COUNT(*) AS armiAutomatiche
FROM Armi
WHERE automatica = 1;

SELECT COUNT(*) AS armiAutomaticheNull
FROM Armi
WHERE automatica IS NULL;

SELECT COUNT(*) AS armiNonAutomatiche 
FROM Armi
WHERE automatica = 0;
-- i criminali armati
SELECT DISTINCT Criminali.nome, Criminali.cognome 
FROM Criminali JOIN Armi
ON Criminali.id = Armi.id_criminale;
-- Il numero di criminali armati(devono possedere almeno un arma) per ogni gruppo
SELECT COUNT(DISTINCT Criminali.id) AS criminaliArmati, Criminali.gruppo
FROM Criminali INNER JOIN Armi
ON Criminali.id = Armi.id_criminale
GROUP BY Criminali.gruppo
-- La media dei colpi dei caricatori per le armi automatiche
SELECT AVG(caricatore) AS mediaColpi
FROM Armi
WHERE automatica = 1;
-- Il numero di colpi totali per ogni criminale
SELECT Criminali.alias,SUM(Armi.caricatore) AS colpiTotali
FROM Criminali JOIN Armi
ON Criminali.id = Armi.id_criminale
GROUP BY Criminali.alias
-- La/e persona/e più anziana senza armi in suo possesso

insert into criminali(nome,cognome,alias,dob,gruppo)
VALUES
('bomber','shave','pirla','1996-12-30','gilette'),
('gufo','d''oro','occhi blu','1996-11-30','gufata')

insert into criminali(nome,cognome,alias,dob,gruppo)
VALUES
('bomber','shave','pirla','1970-12-30','gilette');


SELECT Criminali.nome , Criminali.cognome, Criminali.dob, COUNT(Armi.id_criminale) AS numeroArmiCriminale
FROM Criminali LEFT JOIN Armi
ON Criminali.id = Armi.id_criminale
WHERE  Armi.id_criminale IS NULL AND Criminali.dob = (SELECT MIN(Criminali.dob) FROM Criminali)
GROUP BY Criminali.nome, Criminali.cognome,Criminali.dob; 
