CREATE DATABASE Concessionaria;
USE Concessionaria;

CREATE TABLE Prodotti(id INT PRIMARY KEY IDENTITY(1,1),
categoria VARCHAR(150),
marca VARCHAR(150),
modello VARCHAR(200),
affittabile BIT,
annoImmatricolazione INT,
consumoMedioAKM FLOAT,
capienzaSerbatoio FLOAT);



INSERT INTO Prodotti (categoria, marca, modello, affittabile, annoImmatricolazione, consumoMedioAKM, capienzaSerbatoio)
VALUES
('Moto', 'Harley Davidson', 'Iron 883', 1, 2018, 0.06, 20),
('Macchina', 'Ferrari', '488 GTB', 0, 2020, 0.12, 70),
('Moto', 'Ducati', 'Monster 821', 1, 2016, 0.05, 14),
('Camion', 'Volvo', 'FH16', 1, 2018, 0.35, 300),
('Macchina', 'BMW', 'Serie 3', 1, 2020, 0.08, 60),
('Macchina', 'Peugeot', '308', 1, 2020, 0.09, 55),
('Moto', 'Yamaha', 'MT-07', 1, 2021, 0.05, 15),
('Moto', 'Kawasaki', 'Ninja 650', 1, 2020, 0.05, 16),
('Macchina', 'Audi', 'A4', 1, 2022, 0.07, 58),
('Furgone', 'Ford', 'Transit', 1, 2021, 0.25, 80),
('Moto', 'BMW', 'R1250 GS', 1, 2021, 0.06, 30),
('Macchina', 'Volkswagen', 'Golf', 1, 2019, 0.08, 50),
('Macchina', 'Rolls Royce', 'Phantom', 0, 2022, 0.09, 100),
('Moto', 'Harley Davidson', 'Street 750', 0, 2018, 0.06, 17),
('Macchina', 'Fiat', 'Panda', 1, 2023, 0.07, 40),
('Quad', 'Polaris', 'Sportsman 570', 1, 2020, 0.07, 20),
('Moto', 'Honda', 'CBR500R', 1, 2022, 0.05, 18),
('Macchina', 'Ford', 'Focus', 1, 2021, 0.09, 52),
('Camion', 'Mercedes', 'Actros', 1, 2019, 0.45, 320),
('Moto', 'Suzuki', 'V-Strom 650', 1, 2020, 0.05, 19),
('Furgone', 'Renault', 'Trafic', 1, 2022, 0.2, 75),
('Moto', 'Triumph', 'Street Triple', 1, 2021, 0.06, 17),
('Macchina', 'Toyota', 'Corolla', 1, 2022, 0.08, 55),
('Macchina', 'Fiat', '500', 1, 2023, 0.07, 35),
('Moto', 'Ducati', 'Panigale V4', 1, 2021, 0.06, 18),
('Macchina', 'Mercedes', 'Classe C', 1, 2021, 0.08, 65),
('Macchina', 'Renault', 'Clio', 1, 2022, 0.08, 45),
('Camion', 'MAN', 'TGX', 1, 2020, 0.45, 350),
('Moto', 'KTM', 'Duke 390', 1, 2023, 0.05, 14),
('Macchina', 'Honda', 'Civic', 1, 2023, 0.07, 47),
('Macchina', 'Ferrari', 'LaFerrari', 0, 2019, 0.13, 85),
('Moto', 'Yamaha', 'FZ6', 1, 2007, 0.05, 15),
('Macchina', 'Peugeot', '208', 1, 2021, 0.08, 45),
('Moto', 'Kawasaki', 'Z900', 1, 2020, 0.06, 17),
('Furgone', 'Ford', 'Custom', 1, 2022, 0.2, 70),
('Moto', 'Harley Davidson', 'Fat Boy', 1, 2019, 0.06, 19),
('Macchina', 'Nissan', 'Qashqai', 1, 2022, 0.08, 60),
('Quad', 'Can-Am', 'Outlander', 1, 2021, 0.08, 25),
('Macchina', 'BMW', 'X5', 1, 2022, 0.09, 80),
('Camion', 'Scania', 'R Series', 1, 2021, 0.4, 330);


CREATE TABLE Macchine(id INT PRIMARY KEY,
cilindrata VARCHAR(200),
velocitaMax INT,
postiMacchina INT,
FOREIGN KEY (id) REFERENCES Prodotti(id) ON DELETE CASCADE);

INSERT INTO Macchine (id,cilindrata, velocitaMax, postiMacchina)
VALUES
(2,3900, 330, 2),   
(5,2000, 250, 5),   
(6,1600, 180, 5),   
(9,2000, 240, 5),   
(12,1600, 180, 5), 
(13,2000, 200, 2),  
(15,1200, 160, 4),  
(18,1500, 200, 5),  
(23,2000, 180, 5),  
(24,1200, 140, 4), 
(26,1500, 180, 5),  
(27,1500, 170, 5),  
(30,1600, 180, 5),  
(31,6300, 370, 2),  
(33,1200, 160, 5),  
(37,2000, 200, 5),  
(39,3000, 250, 5);  




CREATE TABLE Moto(id INT PRIMARY KEY,
passeggeri bit,
FOREIGN KEY(id)REFERENCES Prodotti(id) ON DELETE CASCADE);

INSERT INTO Moto (id, passeggeri)
VALUES
(1, 1),  
(3, 1), 
(7, 1),  
(8, 1),  
(11, 1), 
(14, 0), 
(17, 1), 
(20, 1), 
(22, 1), 
(25, 1), 
(29, 1), 
(32, 1), 
(34, 1), 
(36, 1);

SELECT p.id AS ProdottoId, m.id, p.categoria,p.marca,p.modello,p.affittabile,p.annoImmatricolazione,p.consumoMedioAKM,p.capienzaSerbatoio,m.passeggeri 
FROM Moto m 
JOIN Prodotti p 
ON p.id = m.id

SELECT p.id AS ProdottoId, m.id, p.categoria,p.marca,p.modello,p.affittabile,p.annoImmatricolazione,p.consumoMedioAKM,p.capienzaSerbatoio,m.cilindrata,m.velocitaMax,m.postiMacchina
FROM Macchine m 
JOIN Prodotti p 
ON p.id = m.id


SELECT Prodotti.categoria, Prodotti.marca, Prodotti.modello,YEAR(GETDATE()) - Prodotti.annoImmatricolazione AS anniVeicolo
FROM Prodotti
WHERE YEAR(GETDATE()) - Prodotti.annoImmatricolazione > 8


SELECT Prodotti.categoria, COUNT(id) AS prodottiPerCategoria
FROM Prodotti
GROUP BY Prodotti.categoria


SELECT p.id AS ProdottoId, m.id, p.categoria,p.marca,p.modello,p.affittabile,p.annoImmatricolazione,p.consumoMedioAKM,p.capienzaSerbatoio,m.cilindrata,m.velocitaMax,m.postiMacchina
FROM Prodotti p join Macchine m
ON m.id = p.id
WHERE categoria = 'macchina';


SELECT p.id AS ProdottoId, m.id, p.categoria,p.marca,p.modello,p.affittabile,p.annoImmatricolazione,p.consumoMedioAKM,p.capienzaSerbatoio,m.cilindrata,m.velocitaMax,m.postiMacchina
FROM Prodotti p join Macchine m
ON m.id = p.id
WHERE categoria = 'macchina' AND velocitaMax > {velocita};

