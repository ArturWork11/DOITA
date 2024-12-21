-- CONNESSIONE AL DATABASE
-- Libreria
CREATE DATABASE LibreriaDOITA14;
USE LibreriaDOITA14;

CREATE TABLE Libri
(
	id	INT PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(255),
	autore VARCHAR(150),
	genere VARCHAR(100),
	anno_pubblicazione INT
);

INSERT INTO Libri(titolo,autore,genere,anno_pubblicazione)VALUES('Cujo','King','Horror',1997),('Il gatto Nero','Poe','Horror',1890),('Il veliero','Lewis','Fantasy',2000),('Torno a prenderti','King','Horror',2015),('Brising','Paolini','Fantasy',2017),('Tre giorni di Buio','Trentalance','Thriller',2020),('La casa delle voci','Carrisi','Thriller',2018),('Io sono Dio','Faletti','Romanzo',2003),('Misery','King','Horror',1990),('Quella strada per l''inferno','King','Romanzo',1999),('Addicted','Roversi','Thriller',2019),('Ash','Bho','Romanzo',2015),('Carmilla','LeFanou','Romanzo',1889),('Lo scudo di Talos','Manfredi','Romanzo',2004),('I delitti dell''anatomista','Bho','Romanzo',2024);SELECT * FROM Libri;SELECT * FROM Libri WHERE anno_pubblicazione > 2000;SELECT * FROM LibriWHERE autore = 'King';