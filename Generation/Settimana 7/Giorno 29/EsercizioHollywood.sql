-- Ripasso N-N
CREATE DATABASE Hollywood;
USE Hollywood;
-- Immaginiamo di avere una serie di film e gli attori

-- RECORD O TUPLA (SINOMINI DI RIGA, RECORD è IL TERMINE TECNICO,TUPLA è IL TERMINE AULICO)
CREATE TABLE Films
(
	id INT PRIMARY KEY IDENTITY(1,1), -- 
	titolo VARCHAR(200),
	genere VARCHAR(100),
	durata INT,
	paese_produzione VARCHAR(150),
	oscar BIT
);
CREATE TABLE Attori
(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	cognome VARCHAR(150),
	dob DATE,
	nazionalita VARCHAR(100),
	premi BIT,
	stipendio FLOAT
);
CREATE TABLE Cast_
(
	id INT PRIMARY KEY IDENTITY(1,1),
	idFilm INT,
	idAttore INT,
	data_inizio_riprese DATE,
	data_fine_riprese DATE,
	FOREIGN KEY(idFilm) REFERENCES Films(id)
	ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY(idAttore) REFERENCES Attori(id)
	ON UPDATE CASCADE ON DELETE SET NULL
);

INSERT INTO Films
(titolo,genere,durata,paese_produzione,oscar)
VALUES
('Panama Papers','Commedia',96,'America',0),
('La grande Bellezza','Drammatico',146,'Italia',1),
('Pirati dei Caraibi: 1','Azione',141,'America',0),
('Interstellar','Sci-fi',169,'America',1),
('Paraside','Thriller',132,'Sud Corea',1),
('C''era una volta in America','Drammatico',251,'Italia-America',0),
('Spy Kids','Azione',90,'America',0),
('Blow','Biografico-Drammatico-Giallo',124,'America',0);

INSERT INTO Attori
(nome,cognome,dob,nazionalita,premi,stipendio)
VALUES
('Antonio','Banderas','1960-08-10','Spagnolo',1,20),
('Tony','Servillo','1959-01-25','Italiana',1,2),
('Keira','Knightley','1985-03-26','Brittanica',1,15),
('Matt','Damon','1970-10-08','Americano',0,30),
('Song Kang','Ho','1967-01-17','Coreano',0,5.5),
('Jhonny','Depp','1963-06-09','Americano',0,100.1);

INSERT INTO Cast_
(idFilm,idAttore,data_inizio_riprese,data_fine_riprese)
VALUES
(1,1,'2005-04-02','2005-09-29'),
(2,2,'2012-08-09','2012-12-24'),
(3,3,'2002-10-28','2003-03-07'),
(3,6,'2002-10-28','2003-03-07'),
(4,4,'2013-08-12',null),
(7,1,'2000-05-21','2000-06-30'),
(8,6,'2000-02-01','2000-05-20');

-- voglio vedere tutti gli attori che hanno recitato in almeno 1 film
SELECT DISTINCT CONCAT(Attori.nome,' ',Attori.cognome) AS Nominativo
FROM Attori INNER JOIN Cast_ 
ON Attori.id = Cast_.idAttore

-- voglio vedere i titoli dei film che hanno almeno 2 attori
SELECT Films.titolo
FROM Films INNER JOIN Cast_
ON Films.id = Cast_.idFilm
GROUP BY Films.id , Films.titolo
HAVING COUNT(Films.id) >= 2;

-- voglio vedere quale nazione ha prodotto il maggior numero di film
SELECT *
FROM (SELECT Films.paese_produzione AS Nazione, COUNT(Films.id) AS Prodotti
FROM Films 
GROUP BY Films.paese_produzione) tabella
WHERE tabella.Prodotti = (SELECT MAX(tab.Prodotti)
						 FROM (
						        SELECT Films.paese_produzione AS Nazione,
								COUNT(Films.id) AS Prodotti
								FROM Films
								GROUP BY Films.paese_produzione
								) tab);

-- VIEW: è una tabella fittizia memorizzata nel server
-- PRO -> Ho la tabella risultante già pronta e si aggiorna coi dati originali, ed è leggera
-- CONTRO -> Mi mancano i metadati

CREATE VIEW Conta_per_Nazione AS
	SELECT Films.paese_produzione AS Nazione, COUNT(Films.id) AS Prodotti
	FROM Films
	GROUP BY Films.paese_produzione;

SELECT *
FROM Conta_per_Nazione
WHERE Prodotti = (SELECT MAX(Prodotti) FROM Conta_per_Nazione);

-- Voglio vedere quale nazione ha prodotto il maggior numero di film con attori autoctoni
CREATE VIEW Conta2 AS
SELECT Films.paese_produzione AS Nazione,COUNT(Films.id) AS Conteggio
FROM Films JOIN Cast_ 
ON  Films.id = Cast_.idFilm
JOIN Attori 
ON Attori.id = Cast_.idAttore
WHERE Attori.nazionalita LIKE CONCAT('%',Films.paese_produzione,'%')
GROUP BY Films.paese_produzione

SELECT * FROM Conta2 WHERE Conteggio = (SELECT MAX(Conteggio) FROM Conta2);

-- ESERCIZI
-- Voglio vedere lo stipendio medio per ogni nazionalità
SELECT Attori.nazionalita ,ROUND(AVG(Attori.stipendio),2) AS 'Stipendio per nazionalità'
FROM Attori
GROUP BY Attori.nazionalita;
-- Voglio vedere quanti film hanno vinto un'oscar e quanti no
SELECT COUNT(Films.id) AS FilmVincitoriOscar
FROM Films
WHERE Films.oscar = 1
GROUP BY Films.oscar 

SELECT COUNT(Films.id) AS FilmNonVincitoriOscar
FROM Films
WHERE Films.oscar = 0
GROUP BY Films.oscar 

-- Voglio vedere quale attore non ha recitato in nessun film
SELECT CONCAT(Attori.nome,' ',Attori.cognome) AS nominativo
FROM Attori 
WHERE NOT EXISTS (
    SELECT 1
    FROM Cast_
    WHERE Cast_.idAttore = Attori.id
);

SELECT Attori.id, nome, cognome
FROM Attori LEFT JOIN Cast_
ON Attori.id = Cast_.idAttore
WHERE Cast_.id IS NULL
-- Voglio vedere la persona più giovane ad aver recitato in un filmù
SELECT CONCAT(Attori.nome,' ',Attori.cognome) AS nominativo
FROM Attori JOIN Cast_
ON Cast_.idAttore = Attori.id
JOIN Films 
ON Cast_.idFilm = Films.id
WHERE Attori.dob = (SELECT MAX(Attori.dob) FROM Attori) 
-- Voglio vedere per ogni persona l'età che avevano quando hanno recitato nei loro filmSELECT Films.titolo, CONCAT(Attori.nome,' ',Attori.cognome) AS nominativo ,DATEDIFF(YEAR,Attori.dob,Cast_.data_inizio_riprese) AS EtaFROM Attori JOIN Cast_
ON Cast_.idAttore = Attori.id
JOIN Films 
ON Cast_.idFilm = Films.id-- Voglio vedere i giorni di riprese totali per ogni attoreSELECT Films.titolo, CONCAT(Attori.nome,' ',Attori.cognome) AS nominativo ,DATEDIFF(DAY,Cast_.data_inizio_riprese,Cast_.data_fine_riprese) AS giorniTotaliPerFilmFROM Attori JOIN Cast_
ON Cast_.idAttore = Attori.id
JOIN Films 
ON Cast_.idFilm = Films.id
-- Voglio vedere per ogni attore in quanti generi ha recitatoCREATE VIEW GeneriPerAttore ASSELECT Attori.id, Attori.nome,Films.genere, COUNT(Films.id) AS genereRecitatiFROM Attori JOIN Cast_
ON Cast_.idAttore = Attori.id
JOIN Films 
ON Cast_.idFilm = Films.id
GROUP BY Attori.id,Attori.nome, Films.genere

SELECT	nome, COUNT(id) AS genereRecitati
FROM	GeneriPerAttore
GROUP BY nome;