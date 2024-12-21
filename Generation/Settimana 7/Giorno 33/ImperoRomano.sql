CREATE DATABASE ImperoRomano;
use ImperoRomano

CREATE TABLE Imperatori
(
		id INT PRIMARY KEY IDENTITY(1,1),
		nome VARCHAR(150),
		dinastia VARCHAR(200),
		dob DATE,
		dod DATE,
		assassinio BIT
);

INSERT INTO Imperatori
(nome,dinastia, dob,dod,assassinio)
VALUES
	('Caligola', 'Giulio-Claudia', '0012-08-31', '0041-01-24', 1),	('Claudio', 'Giulio-Claudia', '0010-08-01', '0054-10-13', 1),	('Nerone', 'Giulio-Claudia', '0037-12-15', '0068-06-09', 1),	('Galba', 'Anno dei quattro imperatori', '0003-12-24', '0069-01-15', 1),	('Otone', 'Anno dei quattro imperatori', '0032-04-28', '0069-04-16', 1),	('Vitellio', 'Anno dei quattro imperatori', '0015-09-24', '0069-12-22', 1),	('Vespasiano', 'Flavia', '0009-11-17', '0079-06-23', 0),	('Tito', 'Flavia', '0039-12-30', '0081-09-13', 0),	('Domiziano', 'Flavia', '0051-10-24', '0096-09-18', 1),	('Nerva', 'Antonina', '0030-11-08', '0098-01-27', 0),	('Traiano', 'Antonina', '0053-09-18', '0117-08-08', 0),	('Adriano', 'Antonina', '0076-01-24', '0138-07-10', 0),	('Antonino Pio', 'Antonina', '0086-09-19', '0161-03-07', 0),	('Marco Aurelio', 'Antonina', '0121-04-26', '0180-03-17', 0),	('Lucio Vero', 'Antonina', '0130-12-15', '0169-03-23', 0);

CREATE TABLE Battaglie
(
		id INT PRIMARY KEY IDENTITY(1,1),
		nemico VARCHAR(200),
		data_battaglia DATE,
		vincitore BIT,
		luogo VARCHAR(200),
		idImperatore INT,
		FOREIGN KEY(idImperatore) REFERENCES Imperatori(id)
		ON UPDATE CASCADE ON DELETE SET NULL
);

INSERT INTO Battaglie
(nemico,data_battaglia,vincitore,luogo,idImperatore)
VALUES
	('Mare','0040-07-07',1,'Canale della Manica',1),
	('Britanni','0043-01-01',1,'Kent',2),
	('Popolo Germanico', '0015-09-01', 1, 'Foresta di Teutoburgo', 2),	('Popolo Britanno', '0043-07-01', 1, 'Tamigi', 3),	('Ebrei', '0070-08-30', 1, 'Gerusalemme', 8),	('Daci', '0102-05-01', 1, 'Dacia', 11),	('Parti', '0117-01-15', 1, 'Mesopotamia', 11),	('Macedoni Ribelli', '0136-04-10', 1, 'Betar', 12),	('Quadi e Marcomanni', '0166-06-01', 1, 'Danubio', 14),	('Goti', '0169-09-25', 1, 'Pannonia', 14),	('Persiani', '0164-02-11', 1, 'Ctesifonte', 15);SElect * from Battaglie