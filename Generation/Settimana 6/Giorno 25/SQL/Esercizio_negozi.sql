
-- Creare un DB Negozi
CREATE DATABASE Negozi;

USE Negozi;

-- creare una tabella Prodotti
-- ogni prodotto avrà:
-- id,nome,tipo,prezzoBase,iva,quantita,dataCambio
CREATE TABLE Prodotti(id int PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	tipo VARCHAR(50),
	prezzoBase float,
	iva float,
	quantita int,
	dataCambio DATE
);

-- inserire almeno 15 prodotti
INSERT INTO Prodotti
(nome, tipo, prezzoBase, quantita, dataCambio)
VALUES
('iPhone','elettronica',800.99,4,NULL),
('Mele','alimentari',0.8,40,'2023-07-29'),
('Pane','alimentari',0.4,50,'2023-05-19'),
('Miele','alimentari',3.2,15,'2025-02-10'),
('Detersivo','casalinghi',12.99,20,'2026-08-14'),
('T-Shirt','vestiario',15.99,10,'2023-06-29'),
('rtx 3060','elettronica',999.99,1,NULL),
('rtx 3090','elettronica',3000.99,1,NULL),
('Calze','vestiario',3.99,20,NULL),
('Dentifricio','igiene personale',4.99,20,'2023-05-27'),
('Scarpe','vestiario',49.99,10,NULL),
('Mozzarella','alimentari',8.99,1,'2024-12-6'),
('Prosciutto crudo','alimentari',4.99,10,'2024-12-9'),
('Samsung','elettronica',499.99,7,NULL),
('Computer','elettronica',1299.99,3,NULL),
('Sciarpa','vestiario',19.99,5,NULL);

-- Impostare l'iva a 4 per il tipo 'alimentari', a 10 per 'casalinghi' e a 20 per tutti gli altri casi
UPDATE Prodotti SET iva = 4 WHERE tipo = 'alimentari';
UPDATE Prodotti SET iva = 10 WHERE tipo = 'casalinghi';
UPDATE Prodotti SET iva = 20 WHERE tipo != 'alimentari' AND tipo != 'casalinghi';

-- Creare una nuova colonna, prezzoFinale float
ALTER TABLE Prodotti ADD prezzoFinale float;

-- Inserire il valore di prezzoFinale, che sarà dato dal prezzoBase + il valore dell'IVA
UPDATE Prodotti SET prezzoFinale = prezzoBase + (prezzoBase * iva / 100);


-- ROUND() Funzione scalare che vuole 2 parametri: il numero da arrotondare e il numero di decimali che vogliamo tenere
UPDATE Prodotti SET prezzoFinale = ROUND(prezzoFinale,2); 

-- FLOOR() Funzione scalare che toglie la parte decimale del numero messo tra le tonde
UPDATE Prodotti SET prezzoBase = FLOOR(prezzoBase)
WHERE nome = 'calze';
-- Voglio vedere l'elenco dei Prodotti da cambiare (devono avere quantità = 1 e dataCambio entro 10 giorni da oggi)
SELECT *
FROM Prodotti
WHERE quantita = 1 AND DATEDIFF(DAY,dataCambio,SYSDATETIME()) < 10;

-- Voglio vedere l'elenco dei Prodotti di elettronica che si stanno esaurendo (quantita < 5)
SELECT * 
FROM Prodotti
WHERE tipo = 'elettronica' AND quantita < 5;

-- Voglio vedere il prezzoBase medio dei Prodotti per la casa
SELECT AVG(prezzoBase) AS media_prodotti_casa 
FROM Prodotti
WHERE tipo = 'casalinghi';
-- Voglio vedere il prezzoFinale più alto tra i Prodotti alimentari
SELECT MAX(prezzoFinale) AS alimento_più_caro 
FROM Prodotti	
WHERE tipo = 'alimentari';
-- Voglio vedere l'elenco dei Prodotti con il valore di IVA maggiore
SELECT * 
FROM Prodotti
WHERE iva = (SELECT MAX(iva) FROM Prodotti);
-- Eliminate tutti i Prodotti che hanno una quantità inferiore a 5
DELETE FROM Prodotti WHERE quantita < 5;
-- Modificate mettendo l'iva = 4 a tutti i Prodotti che prima l'avevano al 10
UPDATE Prodotti SET iva = 10 WHERE iva = 4;
-- Voglio vedere il numero dei Prodotti raggruppati per tipo
SELECT tipo, COUNT(*) AS numero_prodotti
FROM Prodotti
GROUP BY tipo;
-- Voglio vedere il numero dei Prodotti raggruppati per tipo a condizione che il numero dei Prodotti sia maggiore di 2
SELECT tipo, COUNT(*) AS numero_prodotti_oltre2
FROM Prodotti
GROUP BY tipo
HAVING COUNT(*) > 2
ORDER BY tipo DESC;
-- Voglio vedere l'elenco dei Prodotti che devono essere cambiati a Maggio
SELECT * 
FROM Prodotti
WHERE MONTH(dataCambio) = 5; 
-- Voglio vedere l'elenco dei Prodotti che NON devono essere cambiati di Lunedì
SELECT * 
FROM Prodotti
WHERE DATENAME(WEEKDAY,dataCambio) != 'Monday'; -- oppure DATEPART(WEEKDAY,dataCambio) != 2 , la conta parte da domenica che sarà 1 , lunedi sarà 2 ecc.
-- Voglio vedere il prezzoFinale medio dei Prodotti per ogni categoria
SELECT AVG(prezzoFinale) AS media_per_categoria 
FROM Prodotti 
GROUP BY tipo
-- Voglio vedere il guadagno totale nel negozio nel caso si venda ogni pezzo presente nella tabella
SELECT SUM(prezzoFinale) AS somma_prodotti
FROM Prodotti
