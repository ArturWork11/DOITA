CREATE DATABASE Aon;
USE Aon;


CREATE TABLE Assicurazioni(id INT PRIMARY KEY IDENTITY(1,1),
tipo VARCHAR(255),
costoAnnuo FLOAT);

INSERT INTO Assicurazioni(tipo,costoAnnuo)
VALUES 
('Auto',500),

CREATE TABLE Persone(id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(255),
cognome VARCHAR(255),
dob DATE,
residenza VARCHAR(255),
nuovo_cliente BIT);

INSERT INTO Persone(nome, cognome,residenza, dob, nuovo_cliente)
VALUES
('Ive','Crowhurst','Mbinga','1946-08-04',1),

-- tabella associativa o intermedia conterr� due FK, una relativa alla persona
-- l'altra relativa all'assicurazione in modo da poter capire quale persona ha stipulato quale assicurazione
-- e permettendo alle persone di stipulare pi� assicurazioni diverse 

CREATE TABLE Polizze(id INT PRIMARY KEY IDENTITY(1,1),
	dataInizio DATE,
	dataFine DATE,
	tassoInteresse FLOAT,
	id_persona INT,
	id_assicurazione INT,
	FOREIGN KEY (id_persona) REFERENCES Persone(id),
	-- per poter cancellare una persona, cio� una PK nella tabella Persone
	-- che ha una FK nella tabella polizze devo indicare 
	-- come si comporter� il valore della FK in caso di cancellazione
	-- in questo modo MANTENGO L'INTEGRITA' REFERENZIALE cio� l'integrit� del vincolo tra PK E FK

	ON DELETE CASCADE -- cancellando la PK, quindi una Persona nella tabella Persone,
	-- con cascade  si ripercute a cascata lo stesso comportamento ovvero 
	-- si cancelleranno TUTTE le RIGHE che hanno una FK che fa riferimento a quella PK
	ON UPDATE CASCADE -- aggiornando il valore della PK indico come si comporta il  valore della FK associata
	-- anche sull'update se uso CASCADE, quando modifico il valore della PK
	-- si modificheranno in automatico tutti i valori della FK che fanno riferimento a quella PK 

	FOREIGN KEY (id_assicurazione) REFERENCES Assicurazioni(id)
	-- se ometto il comportamento della FK di default � settato sia ON DELETE sia ON UPDATE in
	-- modalit� NO ACTION(RESTRICT) cio� non potete n� cancellare n� modificare il valore della PK
	-- se esistono FK ad essa associate
	ON DELETE SET NULL -- questo comportamento � possibile indicarlo solo se  la FK accetta
	-- valori null()
	-- quando metto SET NULL indico che il valore della FK viene settato a NULL in caso di cancellazione della PK
	-- di riferimento, cio� se cancello un'assicurazione che ha una o pi� polizze di riferimento allora
	-- il valore della FK nella tabella Polizze verr� settato a NULL, cio� la polizza non star� pi� facendo riferimento ad una specifica assicurazione
	ON UPDATE SET NULL -- se aggiorno il valore della PK allora il valore della/e FK associate a quella PK verr� settato a null. Se aggiorno l'id di un'assicurazione
	-- le polizze associate a quella specifica assicurazione non avranno pi� un'assicurazione associata
	);


INSERT INTO Polizze (dataInizio,dataFine,tassoInteresse,id_persona,id_assicurazione)
VALUES 
('2024-02-01', '2025-01-31', 4.0, 3, 1),
('2024-03-15', '2025-03-14', 3.2, 5, 3),
('2023-06-01', '2024-06-01', 3.5, 6, 2),  -- Polizza scaduta
('2023-08-20', '2024-08-20', 2.7, 8, 4),  -- Polizza scaduta
('2024-07-01', '2025-06-30', 2.5, 10, 5);

VALUES 
('2024-02-01', '2025-01-31', 4.0, 3, 1),
('2024-03-15', '2025-03-14', 3.2, 5, 3),
('2023-06-01', '2024-06-01', 3.5, 6, 2),  -- Polizza scaduta
('2023-08-20', '2024-08-20', 2.7, 8, 4),  -- Polizza scaduta
('2024-07-01', '2025-06-30', 2.5, 10, 5),
('2024-01-01', '2024-12-31', 3.5, 3, 1),  -- Id persona e assicurazione doppi
('2024-05-10', '2025-05-09', 3.0, 5, 3),  -- Id persona e assicurazione doppi
('2024-06-01', '2025-06-01', 3.7, 6, 2),  -- Id persona e assicurazione doppi
('2024-08-15', '2025-08-15', 4.2, 8, 4),  -- Id persona e assicurazione doppi
('2024-09-01', '2025-09-01', 3.8, 10, 5),  -- Id persona e assicurazione doppi
('2024-01-15', '2025-01-15', 3.4, 3, 1),  -- Id persona e assicurazione doppi
('2024-04-01', '2025-04-01', 3.3, 5, 3),  -- Id persona e assicurazione doppi
('2024-07-15', '2025-07-15', 3.6, 6, 2),  -- Id persona e assicurazione doppi
('2024-02-10', '2025-02-10', 2.9, 8, 4),  -- Id persona e assicurazione doppi
('2024-03-01', '2025-03-01', 3.1, 10, 5);  -- Id persona e assicurazione doppi

VALUES 
('2024-02-01', '2025-01-31', 4.0, 3, 4);
SELECT residenza