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
	('Caligola', 'Giulio-Claudia', '0012-08-31', '0041-01-24', 1),

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
	('Popolo Germanico', '0015-09-01', 1, 'Foresta di Teutoburgo', 2),