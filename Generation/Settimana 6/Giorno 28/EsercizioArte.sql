



/* ESERCIZIO  
SCHEMA RELAZIONALE: 
MUSEI (NomeM, Città) 
ARTISTI (NomeA, Nazionalità) 
OPERE (Codice, Titolo, NomeM*, NomeA*) 
PERSONAGGI (Personaggio, Codice*) 
Le colonne contrassegnate da * contengono una FK che fa quindi riferimento ad una PK
In alcune query potrebbe essere comodo usare EXISTS -> documentazione 
https://www.w3schools.com/sql/sql_exists.asp */

CREATE DATABASE Art;
USE Art;


CREATE TABLE Musei(
    nomeMuseo VARCHAR(255) PRIMARY KEY,
    citta VARCHAR(255)
);

INSERT INTO Musei (nomeMuseo, citta)
VALUES
('Louvre', 'Parigi'),
('Museo del Prado', 'Madrid'),
('Galleria degli Uffizi', 'Firenze'),
('Museo d''Arte Moderna', 'New York'),
('National Gallery', 'Londra');


INSERT INTO Musei (nomeMuseo, citta)
VALUES
('Tate Modern', 'Londra');


CREATE TABLE Artisti (
    nomeArtista VARCHAR(255) PRIMARY KEY, 
    nazionalita VARCHAR(255)
);

INSERT INTO Artisti (nomeArtista, nazionalita)
VALUES
('Leonardo da Vinci', 'Italiano'),
('Pablo Picasso', 'Spagnolo'),
('Vincent van Gogh', 'Olandese'),
('Tiziano', 'Italiano'),
('Caravaggio', 'Italiano');


CREATE TABLE Opere (
    codice INT PRIMARY KEY IDENTITY(1,1),
    titolo VARCHAR(255), 
    nomeMuseo VARCHAR(255),
    nomeArtista VARCHAR(255),
    FOREIGN KEY(nomeMuseo) REFERENCES Musei(nomeMuseo),
    FOREIGN KEY(nomeArtista) REFERENCES Artisti(nomeArtista)
);


INSERT INTO Opere (titolo, nomeMuseo, nomeArtista)
VALUES
('Mona Lisa', 'Louvre', 'Leonardo da Vinci'),
('Ultima Cena', 'Louvre', 'Leonardo da Vinci'),
('Guernica', 'Museo del Prado', 'Pablo Picasso'),
('Les Demoiselles d''Avignon', 'Museo del Prado', 'Pablo Picasso'),
('La Notte Stellata', 'Museo d''Arte Moderna', 'Vincent van Gogh'),
('Campo di grano con corvi', 'Museo d''Arte Moderna', 'Vincent van Gogh'),
('Venere di Urbino', 'Galleria degli Uffizi', 'Tiziano'),
('Bacco e Arianna', 'National Gallery', 'Tiziano'),
('Ritratto di Carlo V a cavallo', 'Museo del Prado', 'Tiziano');

INSERT INTO Opere (titolo, nomeMuseo, nomeArtista)
VALUES
('Madonna con Bambino', 'National Gallery', 'Tiziano');

INSERT INTO Opere (titolo, nomeMuseo, nomeArtista)
VALUES
('La Calling of Saint Matthew', 'Louvre', 'Caravaggio'),
('Il San Giovanni Battista', 'Museo d''Arte Moderna', 'Caravaggio'),
('Giuditta che decapita Oloferne', 'Museo del Prado', 'Caravaggio');

INSERT INTO Opere (titolo, nomeMuseo, nomeArtista)
VALUES
('Il Bagnante', 'Galleria degli Uffizi', 'Pablo Picasso');

INSERT INTO Opere (titolo, nomeMuseo, nomeArtista)
VALUES
('Venere di Urbino', 'Tate Modern', 'Tiziano');

CREATE TABLE Personaggi(
    id INT PRIMARY KEY IDENTITY(1,1),
    personaggio VARCHAR(255),
    codice INT, 
    FOREIGN KEY (codice) REFERENCES Opere(codice)
);


INSERT INTO Personaggi (personaggio, codice)
VALUES
('Monna Lisa', 1),                     
('Ultima Cena', 2),                     
('Guernica', 3),                            
('La Notte Stellata', 5),
('Madonna',10);           




-- Scrivere le interrogazioni SQL che restituiscono le seguenti informazioni: 
-- 1- Il codice ed il titolo delle opere di Tiziano conservate alla “National Gallery”. 
SELECT Opere.codice , Opere.titolo
FROM Opere
WHERE Opere.nomeArtista = 'Tiziano' AND Opere.nomeMuseo = 'National Gallery';
--2- Il nome dell’artista ed il titolo delle opere conservate alla “Galleria degli Uffizi” o alla 
-- “National Gallery”. 
SELECT Opere.nomeArtista , Opere.titolo
FROM Opere
WHERE Opere.nomeMuseo = 'National Gallery' OR Opere.nomeMuseo = 'Galleria degli Uffizi';
--3- Il nome dell’artista ed il titolo delle opere conservate nei musei di Firenze 
SELECT Opere.nomeArtista, Opere.titolo 
FROM Opere JOIN Musei
ON Musei.nomeMuseo = Opere.nomeMuseo
WHERE citta = 'Firenze';
--4- Le città in cui son conservate opere di Caravaggio 
SELECT Musei.citta AS 'città con opere di Caravaggio'
FROM Musei JOIN Opere
ON Musei.nomeMuseo = Opere.nomeMuseo
WHERE Opere.nomeArtista = 'Caravaggio'
GROUP BY Musei.citta;
--5- Il codice ed il titolo delle opere di Tiziano conservate nei musei di Londra 
SELECT Opere.codice, Opere.titolo 
FROM Opere JOIN Musei
ON Opere.nomeMuseo = Musei.nomeMuseo
WHERE Opere.nomeArtista = 'Tiziano' AND Musei.citta = 'Londra';
--6- Il nome dell’artista ed il titolo delle opere di artisti spagnoli conservate nei musei di Firenze
SELECT Opere.nomeArtista, Opere.titolo
FROM Artisti JOIN Opere
ON Artisti.nomeArtista = Opere.nomeArtista
JOIN Musei
ON Opere.nomeMuseo = Musei.nomeMuseo
WHERE Artisti.nazionalita = 'Spagnolo' AND Musei.citta = 'Firenze';
--7- Il codice ed il titolo delle opere di artisti italiani conservate nei musei di Londra, in cui è 
--rappresentata la Madonna 
SELECT Opere.codice, Opere.titolo
FROM Artisti JOIN Opere
ON Artisti.nomeArtista = Opere.nomeArtista
JOIN Musei 
ON Opere.nomeMuseo = Musei.nomeMuseo
JOIN Personaggi 
ON Opere.codice = Personaggi.codice 
WHERE Personaggi.personaggio = 'Madonna' AND Musei.citta = 'Londra' AND Artisti.nazionalita = 'Italiano' ;
--8- Per ciascun museo di Londra, il numero di opere di artisti italiani ivi conservate 
SELECT Musei.nomeMuseo ,COUNT(Opere.codice) AS 'Opere per Museo'
FROM Artisti JOIN Opere
ON Artisti.nomeArtista = Opere.nomeArtista
JOIN Musei
ON Opere.nomeMuseo = Musei.nomeMuseo
WHERE Artisti.nazionalita = 'Italiano' AND Musei.citta = 'Londra'
GROUP BY Musei.nomeMuseo;
--9- Il nome dei musei di Londra che non conservano opere di Tiziano 
INSERT INTO Musei (nomeMuseo, citta)
VALUES
('Victoria and Albert Museum', 'Londra');
INSERT INTO Opere (titolo, nomeMuseo, nomeArtista)
VALUES
('La Vergine delle Rocce', 'Victoria and Albert Museum', 'Leonardo da Vinci');

SELECT Musei.nomeMuseo
FROM Musei JOIN Opere
ON Musei.nomeMuseo = Opere.nomeMuseo
WHERE Musei.citta = 'Londra' AND Opere.nomeArtista != 'Tiziano';
--10- Il nome dei musei di Londra che conservano solo opere di Tiziano 
SELECT Musei.nomeMuseo
FROM Musei JOIN Opere
ON Musei.nomeMuseo = Opere.nomeMuseo
WHERE Musei.citta = 'Londra'
GROUP BY Musei.nomeMuseo
HAVING COUNT(DISTINCT Opere.nomeArtista) = 1
AND MAX(Opere.nomeArtista) = 'Tiziano';
--11- Per ciascun artista, il nome dell’artista ed il numero di sue opere conservate alla “Galleria 
-- degli Uffizi” 
SELECT Opere.nomeArtista , COUNT(Opere.codice) AS 'Opere per museo'
FROM Opere
WHERE Opere.nomeMuseo = 'Galleria degli Uffizi'
GROUP BY Opere.nomeArtista 
--12- I musei che conservano almeno 20 opere di artisti italiani 

-- NUOVE OPERE PER TESTARE LA SELECT
INSERT INTO Opere (titolo, nomeMuseo, nomeArtista)
VALUES
('Mona Lisa', 'Louvre', 'Leonardo da Vinci'),
('Ultima Cena', 'Louvre', 'Leonardo da Vinci'),
('Annunciazione', 'Louvre', 'Leonardo da Vinci'),
('San Giovanni Battista', 'Louvre', 'Leonardo da Vinci'),
('La Vergine delle Rocce', 'Louvre', 'Leonardo da Vinci'),
('Bacco', 'Louvre', 'Caravaggio'),
('La Calling of Saint Matthew', 'Louvre', 'Caravaggio'),
('Giuditta e Oloferne', 'Louvre', 'Caravaggio'),
('David con la testa di Golia', 'Louvre', 'Caravaggio'),
('Amor Vincitore', 'Louvre', 'Caravaggio'),
('Venere di Urbino', 'Louvre', 'Tiziano'),
('Ritratto di Carlo V a cavallo', 'Louvre', 'Tiziano'),
('Assunzione della Vergine', 'Louvre', 'Tiziano'),
('Danae', 'Louvre', 'Tiziano'),
('Allegoria della Battaglia di Lepanto', 'Louvre', 'Tiziano'),
('Il Ritorno del Figlio Prodigo', 'Louvre', 'Caravaggio'),
('La Buona Ventura', 'Louvre', 'Caravaggio'),
('Ritratto di Papa Paolo III', 'Louvre', 'Tiziano'),
('Madonna della Serpente', 'Louvre', 'Caravaggio'),
('San Sebastiano', 'Louvre', 'Tiziano');

SELECT Opere.nomeMuseo
FROM Artisti JOIN Opere
ON Artisti.nomeArtista = Opere.nomeArtista
WHERE Artisti.nazionalita = 'Italiano' 
GROUP BY Opere.nomeMuseo
HAVING COUNT(Opere.codice) >= 20;
--13- Per le opere di artisti italiani che non hanno personaggi, il titolo dell’opera ed il nome 
--dell’artista 
SELECT Opere.titolo, Opere.nomeArtista
FROM Opere JOIN Artisti
ON Artisti.nomeArtista = Opere.nomeArtista
LEFT JOIN Personaggi
ON Opere.codice = Personaggi.codice
WHERE Artisti.nazionalita = 'Italiano'AND Personaggi.codice IS NULL;
--14- Il nome dei musei di Londra che non conservano opere di artisti italiani, eccettuato Tiziano 
SELECT Musei.nomeMuseo 
FROM Musei 
WHERE Musei.citta = 'Londra' AND NOT EXISTS (   SELECT 1 
												FROM Opere 
												JOIN Artisti 
												ON Opere.nomeArtista = Artisti.nomeArtista 
												WHERE Opere.nomeMuseo = Musei.nomeMuseo AND Artisti.nazionalita = 'Italiano' AND Artisti.nomeArtista != 'Tiziano' );
--15- Per ogni museo, il numero di opere divise per la nazionalità dell’artista
SELECT Opere.nomeMuseo,Artisti.nazionalita ,COUNT(Opere.codice) AS 'Opere per nazionalita'
FROM Opere JOIN Artisti
ON Opere.nomeArtista = Artisti.nomeArtista
GROUP BY Opere.nomeMuseo, Artisti.nazionalita;
