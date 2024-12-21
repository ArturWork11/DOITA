CREATE DATABASE Cinema;
USE Cinema;

CREATE TABLE Registi(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(150),
	cognome VARCHAR(150),
	nazionalita VARCHAR(150),
	dob DATE,
	dod DATE,
	annoEsordio INT,
	oscar BIT
	);

	INSERT INTO Registi
	(nome,cognome,nazionalita,dob,dod,annoEsordio,oscar)
	VALUES
	('Paolo','Sorrentino','italiana','1970-05-21',null,2001,1);

	INSERT INTO Registi
	(nome,cognome,nazionalita,dob,dod,annoEsordio,oscar)
	VALUES
	('Mario','Bros','italiana','2000-04-20',null,2001,1);

	SELECT * FROM Registi;

	-- ad un record della tabella dei registi possono essere associati N record nella tabella Film
	CREATE TABLE Film(
		id INT PRIMARY KEY IDENTITY(1,1),
		titolo VARCHAR(300),
		genere VARCHAR(100),
		durata_minuti INT,
		idRegista INT
		-- Creo una relazione
		FOREIGN KEY(idRegista) REFERENCES Registi(id)
		);

	INSERT INTO Film
	(titolo,genere,durata_minuti,idRegista)
	VALUES
	('La grande bellezza','drammatico',142,1);

	-- ora abbiamo creato una RELAZIONE tra la tabella Registi e la tabella Film nel momento in cui ho
	-- indicato che il film la grande bellezza ha un regista associato
	-- finché non ci sono associazioni la relazione non c'è

	-- interrogo il db chiedendo di vedere quali record sono associati 
	-- quindi di vedere i registi e i file che hanno prodotto
	-- quando si interroga il db e si fa una query -> SELECT
	-- se nella query volete anche vedere le associazioni/RELAZIONI tra due o più tabelle  dovete usare le JOIN
	-- una JOIN non è una relazione

	SELECT *
	FROM Registi,Film; -- almeno due tabelle nel from -> prodotto cartesiano o CROSS JOIN
	-- tutte le combinazioni possibili tra le righe della prima tabella con le righe della seconda tabella

	-- a una cross JOIN aggiungo una condizione che mi permetta di vedere solo le combinazioni
	-- in cui esiste davvero una relazione basata sul lavoro PK = FK

	-- INNER JOIN IMPLICITA
	SELECT *
	FROM Registi,Film
	WHERE Registi.id = Film.idRegista; -- INNER JOIN: prende in considerazione solo i record della tabella
	-- nata dalla cross join in cui esiste una relazione,cioè solo i record in cui la PK della tabella parent/Registi
	-- ha una FK con lo stesso valore nella tabella child/Film

	-- INNER JOIN ESPLICITA
	SELECT *
	FROM Registi INNER JOIN Film
	ON Registi.id = Film.idRegista
	WHERE nazionalita = 'italiana';


	-- LEFT JOIN permette di prendere anche i record della tabella a sinistra della parola JOIN
	-- che non relazioni con la tabella film 
	-- quindi mi permette di prendere tutti i registi che non hanno ancora prodotto film, che non hanno film associati
	-- vereanno riportati una serie di null nei campi del film per i registi che hanno film associati
	-- per cui quindi non esiste relazione del tipo PK = FK

	SELECT *
	FROM Registi LEFT JOIN Film
	ON Registi.id = Film.idRegista;



	-- vorrei vedere i registi che non hanno prodotto film  
	SELECT *
	FROM Registi LEFT JOIN Film
	ON Registi.id = Film.idRegista
	WHERE idRegista IS NULL;

	
	
	INSERT INTO Registi
	(nome,cognome,nazionalita,dob,dod,annoEsordio,oscar)
	VALUES
	('Steven', 'Spielberg', 'Americana', '1946-12-18', NULL, 1974, 2),
	('Martin', 'Scorsese', 'Americana', '1942-11-17', NULL, 1967, 1),
	('Quentin', 'Tarantino', 'Americana', '1963-03-27', NULL, 1992, 2),
	('Alfred', 'Hitchcock', 'Inglese', '1899-08-13', '1980-04-29', 1925, 0),
	('Federico', 'Fellini', 'Italiana', '1920-01-20', '1993-10-31', 1948, 5),
	('Jean-Luc', 'Godard', 'Francese', '1930-12-03', '2022-09-13', 1959, 1),
	('Jean-Pierre', 'Jeunet', 'Francese', '1972-09-29', NULL, 1991, 0),
	('Ari', 'Aster', 'Americana', '1986-07-15', NULL, 2011, 0),
	('James', 'Dean', 'Americana', '1931-02-08', '1955-09-30', 1955, 0),
	('Cameron', 'Boyce', 'Americana', '1999-05-28', '2019-07-06', 2013, 0);
	

	INSERT INTO Film
	(titolo,genere,durata_minuti,idRegista)
	VALUES
	('Schindler''s List', 'Drammatico', 195, 3),  -- Film di Steven Spielberg
	('Jurassic Park', 'Fantascienza', 127, 3),  -- Film di Steven Spielberg
	('E.T. l''extra-terrestre', 'Fantascienza', 115, 3),  -- Film di Steven Spielberg
	('Salvate il soldato Ryan', 'Drammatico', 169, 3),  -- Film di Steven Spielberg
	('Indiana Jones e i predatori dell''arca perduta', 'Azione', 115, 3),  -- Film di Steven Spielberg
	('The Post', 'Drammatico', 116, 3),  -- Film di Steven Spielberg

	('Goodfellas', 'Drammatico', 146, 4),  -- Film di Martin Scorsese
	('Taxi Driver', 'Drammatico', 114, 4),  -- Film di Martin Scorsese
	('The Irishman', 'Drammatico', 209, 4),  -- Film di Martin Scorsese
	('The Departed', 'Thriller', 151, 4),  -- Film di Martin Scorsese
	('Raging Bull', 'Sportivo', 129, 4),  -- Film di Martin Scorsese
	('Casino', 'Drammatico', 178, 4),  -- Film di Martin Scorsese

	('Pulp Fiction', 'Crimine', 154, 5),  -- Film di Quentin Tarantino
	('Inglourious Basterds', 'Azione', 153, 5),  -- Film di Quentin Tarantino
	('Kill Bill: Vol. 1', 'Azione', 111, 5),  -- Film di Quentin Tarantino
	('Kill Bill: Vol. 2', 'Azione', 137, 5),  -- Film di Quentin Tarantino
	('Django Unchained', 'Western', 165, 5),  -- Film di Quentin Tarantino
	('Once Upon a Time in Hollywood', 'Commedia', 161, 5),  -- Film di Quentin Tarantino

	('Psycho', 'Horror', 109, 6),  -- Film di Alfred Hitchcock
	('Rear Window', 'Thriller', 112, 6),  -- Film di Alfred Hitchcock
	('Vertigo', 'Thriller', 128, 6),  -- Film di Alfred Hitchcock
	('North by Northwest', 'Thriller', 136, 6),  -- Film di Alfred Hitchcock
	('The Birds', 'Horror', 119, 6),  -- Film di Alfred Hitchcock

	('8½', 'Drammatico', 138, 7),  -- Film di Federico Fellini
	('La dolce vita', 'Drammatico', 174, 7),  -- Film di Federico Fellini
	('Amarcord', 'Commedia', 123, 7),  -- Film di Federico Fellini
	('I vitelloni', 'Drammatico', 108, 7),  -- Film di Federico Fellini
	('La strada', 'Drammatico', 108, 7),
	('Nights of Cabiria', 'Drammatico', 110, 7),

	('Fino al''ultimo respiro', 'Drammatico', 90, 8),  -- Film di Jean-Luc Godard
	('Pierrot le Fou', 'Drammatico', 105, 8),  -- Film di Jean-Luc Godard
	('Alfabeto', 'Drammatico', 83, 8),  -- Film di Jean-Luc Godard
	('Le Petit Soldat', 'Drammatico', 98, 8),

	('Amélie', 'Commedia', 122, 9),  -- Film di Jean-Pierre Jeunet
	('Delicatessen', 'Commedia', 99, 9),  -- Film di Jean-Pierre Jeunet
	('A Very Long Engagement', 'Drammatico', 133, 9),  -- Film di Jean-Pierre Jeunet
	('Micmacs', 'Commedia', 104, 9),

	('Hereditary', 'Horror', 127, 10),  -- Film di Ari Aster
	('Midsommar', 'Horror', 148, 10),  -- Film di Ari Aster
	('Beau Is Afraid', 'Drammatico', 179, 10),  -- Film di Ari Aster
	('The Strange Thing About the Johnsons', 'Drammatico', 29, 10),

	('Gioventù bruciata', 'Drammatico', 121, 11),  -- Film di James Dean
	('Il gigante', 'Drammatico', 201, 11),  -- Film di James Dean

	('Descendants', 'Commedia', 111, 12),  -- Film di Cameron Boyce
	('Descendants 2', 'Commedia', 111, 12),  -- Film di Cameron Boyce
	('Descendants 3', 'Commedia', 108, 12),  -- Film di Cameron Boyce
	('The Gospel of Luke', 'Drammatico', 99, 12);  -- Film di Cameron Boyce

	SELECT *
	FROM Registi;

	SELECT *
	FROM Film;

	-- vedere il/i registi più giovani ancora in vita 
	SELECT *
	FROM Registi
	WHERE DATEDIFF(YEAR,dob,SYSDATETIME()) <= 30 AND dod IS NULL;

	-- vedere i film o il film più lunghi
	SELECT *
	FROM Film
	WHERE durata_minuti = (SELECT MAX(durata_minuti) FROM Film);
	-- vedere tutti film di un certo regista ma solo di un determinato genere a scelta
	SELECT *
	FROM Film 
	WHERE idRegista = 4 AND genere = 'Drammatico';

	-- il numero di film prodotti da un regista
	SELECT nome,cognome,COUNT(Film.id) AS NumeroFilm
	FROM Film INNER JOIN Registi
	ON Film.idRegista = Registi.id
	GROUP BY nome,cognome;
	
	-- il numero di film per genere, prendendo solo in considerazione solo quei generi che raggiungono almeno i 5 film
	SELECT genere,COUNT(id) AS film_per_genere
	FROM Film
	GROUP BY genere;
	-- vedere la durata media dei film per regista
	SELECT nome,cognome,AVG(durata_minuti) AS MediaDurata
	FROM Film INNER JOIN Registi
	ON Film.idRegista = Registi.id
	GROUP BY nome,cognome;
