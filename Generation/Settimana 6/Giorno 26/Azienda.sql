﻿/* 
RELAZIONE 1 A 1
un record della tabella 1 a 1 è associato ad un solo record della tabella 2
abbiamo

*/

CREATE DATABASE Azienda;
USE Azienda;

CREATE TABLE Persone(id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(255),
	cognome VARCHAR(255),
	residenza VARCHAR(255),
	dob DATE);


insert into Persone (nome, cognome, dob, residenza) values ('Ive', 'Crowhurst', '1946-08-04', 'Mbinga');
insert into Persone (nome, cognome, dob, residenza) values ('Ansell', 'Dorin', '1945-11-05', 'Orong');
insert into Persone (nome, cognome, dob, residenza) values ('Henriette', 'Fannon', '1966-07-30', 'Kujama');

-- tabella dei dipendenti

CREATE TABLE Dipendenti(id INT PRIMARY KEY ,
	ufficio VARCHAR(255),
	numero_oreG INT,
	pagaOraria FLOAT,
	mensilita INT,
	FOREIGN KEY(id) REFERENCES Persone(id));

INSERT INTO Dipendenti