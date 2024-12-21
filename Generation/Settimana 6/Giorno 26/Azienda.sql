/* 
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


insert into Persone (nome, cognome, dob, residenza) values ('Ive', 'Crowhurst', '1946-08-04', 'Mbinga');insert into Persone (nome, cognome, dob, residenza) values ('Sven', 'Springtorp', '1975-07-16', 'Libertad');insert into Persone (nome, cognome, dob, residenza) values ('Inge', 'Bedford', '1984-07-08', 'Zitong');insert into Persone (nome, cognome, dob, residenza) values ('Joel', 'Yeoland', '1940-04-12', 'Jastrebarsko');insert into Persone (nome, cognome, dob, residenza) values ('Liza', 'Garlette', '1914-10-12', 'Guam Government House');insert into Persone (nome, cognome, dob, residenza) values ('Carmella', 'Aizikov', '1947-11-14', 'Changgucheng');insert into Persone (nome, cognome, dob, residenza) values ('Tammy', 'Guidera', '1934-01-22', 'Jiebu');insert into Persone (nome, cognome, dob, residenza) values ('Sibel', 'Symonds', '1986-12-07', 'Uppsala');
insert into Persone (nome, cognome, dob, residenza) values ('Ansell', 'Dorin', '1945-11-05', 'Orong');insert into Persone (nome, cognome, dob, residenza) values ('Tabbie', 'Tootin', '1921-04-07', 'Derbur');insert into Persone (nome, cognome, dob, residenza) values ('Worth', 'Ivanets', '1955-06-14', 'São Miguel do Rio Torto');insert into Persone (nome, cognome, dob, residenza) values ('Chalmers', 'Orrocks', '1929-07-24', 'Kabo');insert into Persone (nome, cognome, dob, residenza) values ('Essy', 'Folker', '1996-05-15', 'Černovice');insert into Persone (nome, cognome, dob, residenza) values ('Charmian', 'Rainbird', '1961-12-07', 'San Diego');insert into Persone (nome, cognome, dob, residenza) values ('Pascal', 'Shakespeare', '1904-10-08', 'Xinning');insert into Persone (nome, cognome, dob, residenza) values ('Brynn', 'Balnaves', '1938-04-05', 'Donabate');insert into Persone (nome, cognome, dob, residenza) values ('Britni', 'Bullerwell', '1986-01-16', 'Aguada de Pasajeros');
insert into Persone (nome, cognome, dob, residenza) values ('Henriette', 'Fannon', '1966-07-30', 'Kujama');insert into Persone (nome, cognome, dob, residenza) values ('Giles', 'Weatherall', '1941-03-26', 'Thessalon');insert into Persone (nome, cognome, dob, residenza) values ('Barbara', 'Maddinon', '1932-09-01', 'Ciherang');

-- tabella dei dipendenti

CREATE TABLE Dipendenti(id INT PRIMARY KEY ,
	ufficio VARCHAR(255),
	numero_oreG INT,
	pagaOraria FLOAT,
	mensilita INT,
	FOREIGN KEY(id) REFERENCES Persone(id));

INSERT INTO Dipendenti(id,ufficio,numero_oreG,pagaOraria,mensilita)values(1,'Vendite',8,9.05,13),(3,'Vedite',8,9,14),(4,'Vendite',12,5,6),(14,'Risorse Umane',10,10,12);-- visualizzare le persone e i loro dati come dipendentiSELECT Persone.id AS id,nome,cognome,dob,ufficioFROM Persone JOIN DipendentiON Persone.id = Dipendenti.id;SELECT Persone.id AS id,nome,cognome,dob,ufficioFROM Persone LEFT JOIN DipendentiON Persone.id = Dipendenti.id;-- vedere il nominativo delle persone, la loro età e quanto guadagnano in un anno se lavoranoSELECT nome,DATEDIFF(YEAR,dob,SYSDATETIME()) AS eta, numero_oreG * pagaOraria * 5 * 4 * mensilita AS guadagnoAnnualeFROM Persone JOIN DipendentiON Persone.id = Dipendenti.id;-- contare il numnero di dipendenti per ufficioSELECT ufficio, COUNT(ufficio) AS dipendentiPerUfficioFROM Dipendenti GROUP BY ufficio;