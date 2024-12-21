USE Libreria;

-- FUNZIONE SCALARE
SELECT CONCAT(titolo,' scritto da ',autore)AS 'biblioteca' ,genere FROM Libri;

SELECT CONCAT(titolo,' scritto da ',autore)AS biblioteca ,genere FROM Libri WHERE genere = 'HORROR';


USE PrimoDB;

CREATE TABLE Persone(id int PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	cognome VARCHAR(100),
	dob DATE,
	residenza VARCHAR(200),
	sposato BIT,
	numero_civico INT
	);

	INSERT INTO Persone(nome,cognome,dob,residenza,sposato) VALUES
('Maria','Dell''Onofrio','2010-03-22','Cagliari',0);

-- LEGGE i dati salvati fino ad ora nella tabella Persone
-- SELECT -> seleziona le colonne di cui volete vedere i valori
-- FROM -> indica la tabella dalla quale prendete i dati 
SELECT *
FROM Persone; -- * indica ALL -> tutte le colonne della tabella Persone

SELECT nome,cognome FROM Persone;

-- per modificare/Aggiornare uno o pi� valori di una riga
/*UPDATE Persone SET residenza = 'Firenze',
					sposato = 1, dob = '1998-05-16';
se non indico la chiave identificativa aggiorno tutte le righe della tabella
					*/

UPDATE Persone SET dob = '2000-09-12',
				   residenza = 'Bergamo',
				   sposato = 0
				   WHERE id = 1; -- aggiorno solo la riga con id 1


UPDATE Persone SET dob = '2000-09-12',
				   residenza = 'Bergamo',
				   sposato = 0
				   WHERE nome = 'Mario'; 

-- il WHERE aggiunge una CONDIZIONE
SELECT * FROM Persone
WHERE residenza = 'Firenze';

SELECT * FROM Persone
WHERE residenza = 'Firenze' AND sposato = 1;
-- cerco tutte le persone che abitano a Firenze e che sono sposate
-- AND permette di aggiungere una condizione, ENTRAMBE devono essere VERE 
-- per poter prendere in considerazione la riga e aggiungerla al risultato

SELECT * FROM Persone
WHERE residenza = 'Firenze' AND sposato = 0;
-- non ci sono persone residenti a firenze non sposate

UPDATE Persone set residenza = 'Roma',
					dob ='2002-12-25'
					WHERE id >= 2;

-- cancello una riga della tabella Persone
DELETE FROM Persone WHERE id = 3; -- cancella la riga nella tabella
--Persone che ha id = 3

INSERT INTO Persone(nome,cognome,dob) VALUES
('Marta','Neri','2024-09-12');

SELECT * FROM Persone;
-- SAFE MODE, disattivata di DEFAULT su SQL Server ma attiva di default su altri 
-- DBMS che usano SQL
-- � una modalit� che non permetta l'aggiornamento(UPDATE) o la cancellazione
-- dei dati se non si specifica la chiave primaria(PK)

-- comando per svuotare una tabella dai suoi dati senza eliminare la struttura
TRUNCATE TABLE Persone; 

-- modicare una tabella nella sua struttura
ALTER TABLE Persone ADD numero_civico int;

-- cancellare una colonna dalla tabella
ALTER TABLE Persone DROP COLUMN numero_civico; 

-- cancello tutta la tabella sia la struttura che i dati
DROP TABLE Persone;

-- elimino tutto il db
DROP DATABASE PrimoDb;

/*
SOTTOCATEGORIE di SQL

- 1) comandi DDL: Data Definition Language 
permettono di gestire(creare e cancellare) e di moficare la STRUTTURA 
di un DB, cio� i METADATI 
-> creare un db, tabella, modificare una tebella oppre cancellare una colonna,una tabella un db

CREATE,ALTER,DROP,TRUCATE

- 2)comandi DML: Data Manipulation Language
permettono la manipolazione dei dati salvati nelle tabelle
agiscono sul contenuto di una tabella ma non sulla sua struttura

INSERT,UPDATE,DELETE

- 3) DQL: Data Query Language
permettono di eseguire delle interrogazioni/domande al db
servono per LEGGERE i dati salvati

SELECT,FROM



*/

	SELECT CONCAT(nome,' ',cognome) AS 'nominativo',
			DATEDIFF(YEAR, dob, SYSDATETIME()) AS eta  --DATEDIFF(intervallo,dataFINE,dataINIZIO)
	FROM Persone
	ORDER BY nominativo DESC;

-- FUNZIONE DI GRUPPO o AGGREGAZIONE
USE Libreria;

-- funzione che somma i valori(numerici) incontrati all'interno di una colonna
-- SUM(colonna)
-- vorrei sommare i prezzi di tutti i libri
SELECT SUM(prezzo) AS somma_totale
FROM Libri;


-- somma di tutti i prezzi dei libri il cui genere è BATTLE SHONEN
SELECT SUM(prezzo) AS somma_per_genere
FROM Libri
WHERE genere = 'BATTLE SHONEN';


-- media prezzo libri
SELECT AVG(prezzo) AS media
FROM Libri;

-- prezzo del libro più costoso
SELECT MAX(prezzo) as 'libro piu caro'  FROM Libri;

-- prezzo libro più economico
SELECT titolo, MIN(prezzo) as 'libro più economico' FROM Libri;

-- libro più economico , utilizziamo una subquery ovvero una query dentro un'altra query
SELECT CONCAT(titolo, ' - ', prezzo) AS 'libro più economico' FROM libri WHERE prezzo = (SELECT MIN(prezzo) FROM libri) ;

-- conto tutti i libri presenti nella tabella
SELECT COUNT(id) FROM Libri;  -- conta quanti id avrò in quella tabella
SELECT COUNT(*) FROM Libri;  -- conta tutte le righe che incontra

SELECT COUNT(*) FROM Libri
WHERE genere = 'HORROR';

-- ordina i primi due libri dal prezzo più alto al più basso
SELECT TOP 2 * 
FROM Libri
ORDER BY Prezzo DESC;

-- ordina i primi due libri dal più basso al più alto
SELECT TOP 2 * 
FROM Libri
ORDER BY Prezzo; -- order by di default ordina in modo crescente sia numeri che lettere

-- quanti libri ci sono per genere nel mio db
SELECT genere, COUNT(id) AS numero_libri
FROM Libri
GROUP BY genere;

-- distinct si usa per non contare le ripetizioni
SELECT genere, COUNT(DISTINCT titolo) AS numero_libri
FROM Libri
GROUP BY genere;

-- quanti libri ci sono per genere nel db con più di 3 libri per genere
SELECT genere, COUNT(DISTINCT titolo) AS numero_libri
FROM Libri
GROUP BY genere
HAVING COUNT (DISTINCT titolo) >= 3;

/* ORDINE SCRITTURA COMANDI:
SELECT colonna/colonne [funzioni scalari/gruppo]
FROM tabella/tabelle/subquery
WHERE condizione/i -> AND,OR,>,<,=,!=,is null
GROUP BY colonna,colonne
HAVING BY condizione/i
ORDER BY 

ORDINE ESECUZIONE COMANDI:

FROM tabella/e/subquery
WHERE condizione/i che agiscono su tutte le righe del FROM 
GROUP BY colonna/colonne -> creo tanti gruppi quante sono le variazioni del contenuto della colonna
- solo se c'è una funzione di GRUPPO viene letta la SELECT
- applico la funzione ad ogni gruppo
HAVING condizione/i
- SELECT (DISTINCT/CONCAT e altre colonne)
ORDER BY colonna/e
*/