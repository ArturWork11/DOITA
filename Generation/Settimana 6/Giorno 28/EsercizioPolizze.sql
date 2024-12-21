CREATE DATABASE Aon;
USE Aon;


CREATE TABLE Assicurazioni(id INT PRIMARY KEY IDENTITY(1,1),
tipo VARCHAR(255),
costoAnnuo FLOAT);

INSERT INTO Assicurazioni(tipo,costoAnnuo)
VALUES 
('Auto',500),('Moto',300),('Casa',1000),('Vita',2000),('Viaggio',100);

CREATE TABLE Persone(id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(255),
cognome VARCHAR(255),
dob DATE,
residenza VARCHAR(255),
nuovo_cliente BIT);

INSERT INTO Persone(nome, cognome,residenza, dob, nuovo_cliente)
VALUES
('Ive','Crowhurst','Mbinga','1946-08-04',1),('Sven','Springtorp','Libertad','1975-07-16',0),('Inge','Bedford','Zitong','1984-07-08',1),('Joel','Yeoland','Jastrebarsko','1940-04-12',0),('Liza','Garlette','Guam Government House','1914-10-12',1),('Carmella','Aizikov','Changgucheng','1947-11-14',1),('Tammy','Guidera','Jiebu','1934-01-22',1),('Sibel','Symonds','Uppsala','1986-12-07',1),('Ansell','Dorin','Orong','1945-11-05',0),('Barbara','Maddinon','Ciherang','1932-09-01',0);

-- tabella associativa o intermedia conterrà due FK, una relativa alla persona
-- l'altra relativa all'assicurazione in modo da poter capire quale persona ha stipulato quale assicurazione
-- e permettendo alle persone di stipulare più assicurazioni diverse 

CREATE TABLE Polizze(id INT PRIMARY KEY IDENTITY(1,1),
	dataInizio DATE,
	dataFine DATE,
	tassoInteresse FLOAT,
	id_persona INT,
	id_assicurazione INT,
	FOREIGN KEY (id_persona) REFERENCES Persone(id),
	-- per poter cancellare una persona, cioè una PK nella tabella Persone
	-- che ha una FK nella tabella polizze devo indicare 
	-- come si comporterà il valore della FK in caso di cancellazione
	-- in questo modo MANTENGO L'INTEGRITA' REFERENZIALE cioè l'integrità del vincolo tra PK E FK

	ON DELETE CASCADE -- cancellando la PK, quindi una Persona nella tabella Persone,
	-- con cascade  si ripercute a cascata lo stesso comportamento ovvero 
	-- si cancelleranno TUTTE le RIGHE che hanno una FK che fa riferimento a quella PK
	ON UPDATE CASCADE -- aggiornando il valore della PK indico come si comporta il  valore della FK associata
	-- anche sull'update se uso CASCADE, quando modifico il valore della PK
	-- si modificheranno in automatico tutti i valori della FK che fanno riferimento a quella PK 

	FOREIGN KEY (id_assicurazione) REFERENCES Assicurazioni(id)
	-- se ometto il comportamento della FK di default è settato sia ON DELETE sia ON UPDATE in
	-- modalità NO ACTION(RESTRICT) cioè non potete nè cancellare nè modificare il valore della PK
	-- se esistono FK ad essa associate
	ON DELETE SET NULL -- questo comportamento è possibile indicarlo solo se  la FK accetta
	-- valori null()
	-- quando metto SET NULL indico che il valore della FK viene settato a NULL in caso di cancellazione della PK
	-- di riferimento, cioè se cancello un'assicurazione che ha una o più polizze di riferimento allora
	-- il valore della FK nella tabella Polizze verrà settato a NULL, cioè la polizza non starà più facendo riferimento ad una specifica assicurazione
	ON UPDATE SET NULL -- se aggiorno il valore della PK allora il valore della/e FK associate a quella PK verrà settato a null. Se aggiorno l'id di un'assicurazione
	-- le polizze associate a quella specifica assicurazione non avranno più un'assicurazione associata
	);


INSERT INTO Polizze (dataInizio,dataFine,tassoInteresse,id_persona,id_assicurazione)VALUES('2024-01-01','2024-12-31',3.5,4,2),('2024-08-01','2025-05-01',2.8,7,1);-- visualizzo le persone che hanno stipulato un'assicurazione, il tipo di assicurazione e la data di fine SELECT * FROM Persone INNER JOIN PolizzeON Persone.id = Polizze.id_persona -- prendo tutte le persone che hanno stipulato una polizzaINNER JOIN AssicurazioniON Polizze.id_assicurazione = Assicurazioni.id; -- PK = FK mi permette di eliminare le combinazione -- date dalla CROSS JOIN che non hanno senso, quindi prendo solo le polizze che hanno un'assicurazione di riferimento--visualizzo tutte le persone,anche quelle che non hanno un'assicurazione.-- di quelle che invece ne hanno stipulata una vederne tutte le informazioniSELECT *FROM Persone LEFT JOIN PolizzeON Persone.id = Polizze.id_personaLEFT JOIN AssicurazioniON Polizze.id_assicurazione = Assicurazioni.id;-- aggiungere delle polizze INSERT INTO Polizze (dataInizio, dataFine, tassoInteresse, id_persona, id_assicurazione) 
VALUES 
('2024-02-01', '2025-01-31', 4.0, 3, 1),
('2024-03-15', '2025-03-14', 3.2, 5, 3),
('2023-06-01', '2024-06-01', 3.5, 6, 2),  -- Polizza scaduta
('2023-08-20', '2024-08-20', 2.7, 8, 4),  -- Polizza scaduta
('2024-07-01', '2025-06-30', 2.5, 10, 5);
INSERT INTO Polizze (dataInizio, dataFine, tassoInteresse, id_persona, id_assicurazione) 
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
INSERT INTO Polizze (dataInizio, dataFine, tassoInteresse, id_persona, id_assicurazione) 
VALUES 
('2024-02-01', '2025-01-31', 4.0, 3, 4);-- vedere quelle ancora attiveSELECT *FROM PolizzeWHERE dataFine > SYSDATETIME();-- vedere quelle non più attiveSELECT *FROM PolizzeWHERE dataFine < SYSDATETIME();-- vedere quante assicurazioni sulla vita per città SELECT residenza, COUNT(Persone.residenza) AS assicurazioniPerCittàFROM Persone JOIN PolizzeON Persone.id = Polizze.id_personaINNER JOIN AssicurazioniON Assicurazioni.id = Polizze.id_assicurazioneWHERE Assicurazioni.tipo = 'Vita'GROUP BY Persone.residenza;-- vedere il costo annuo totale di ogni persona,considerando che possa aver stipulato più assicurazioniSELECT Persone.nome, Persone.cognome, Assicurazioni.tipo, Assicurazioni.costoAnnuo + Assicurazioni.costoAnnuo / 100 * Polizze.tassoInteresse AS costoAnnuoTotaleFROM Persone  JOIN PolizzeON Persone.id = Polizze.id_persona JOIN AssicurazioniON Assicurazioni.id = Polizze.id_assicurazione-- le persone che hanno un'assicurazione e i giorni mancati alla scadenzaSELECT Persone.nome, Persone.cognome,Assicurazioni.tipo , DATEDIFF(DAY,SYSDATETIME(),dataFine) AS giorniMancantiFROM Persone JOIN Polizze ON Persone.id = Polizze.id_personaJOIN AssicurazioniON Assicurazioni.id = Polizze.id_assicurazioneWHERE dataFine > SYSDATETIME();-- la città di residenza dove ci sono più persone che hanno stipulato un'assicurazione
SELECT residenzaFROM Persone INNER JOIN PolizzeON Persone.id = Polizze.id_personaWHERE residenza = (SELECT MAX(Persone.residenza) AS cittaMaxPersoneAssicurate FROM Persone INNER JOIN PolizzeON Persone.id = Polizze.id_persona)GROUP BY Persone.residenza;