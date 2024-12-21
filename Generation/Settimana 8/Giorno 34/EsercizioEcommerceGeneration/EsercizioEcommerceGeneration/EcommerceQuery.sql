create database GenerationEcommerce
use GenerationEcommerce;

create table Prodotti(id INT PRIMARY KEY IDENTITY(1,1),
			 nome VARCHAR(255),
			 quantitaMagazzino INT,
			 dataCambio DATE,
			 dataScadenza DATE,
			 categoria VARCHAR(255),
			 prezzo FLOAT);

INSERT INTO Prodotti (nome, quantitaMagazzino, dataCambio, dataScadenza, categoria, prezzo)
VALUES 

('Pane Integrale', 200, '2024-12-20', '2024-12-20', 'Alimentari', 2.00),
('Caffè Lavazza 250g', 200, '2025-06-01', '2025-06-01', 'Alimentari', 4.99),
('Cioccolato Fondente Lindt', 150, '2025-04-15', '2025-04-15', 'Alimentari', 2.50),
('Pasta Barilla 500g', 300, '2025-01-15', '2025-01-15', 'Alimentari', 1.20),
('Olio Extra Vergine di Oliva', 80, '2025-12-01', '2025-12-01', 'Alimentari', 7.00),
('Petto di Pollo', 120, '2024-12-15', '2024-12-15', 'Alimentari', 5.00),
('Latte Intero', 150, '2024-12-16', '2024-12-16', 'Alimentari', 1.50),
('Mela Golden', 300, '2024-12-25', '2024-12-25', 'Alimentari', 0.80),
('Succo d''Arancia', 250, '2024-12-30', '2024-12-30', 'Alimentari', 1.80),
('Acqua Naturale 1.5L', 400, '2026-06-12', '2026-06-12', 'Alimentari', 0.50),
('Frigorifero LG 300L', 20, '2026-06-15', NULL, 'Casa', 599.99),
('Smartphone Samsung Galaxy S24', 50, '2025-12-01', NULL, 'Elettronica', 899.99),
('Felpa Puma', 150, '2025-03-10', NULL, 'Abbigliamento', 39.99),
('Aspirapolvere Dyson V12', 35, '2026-06-20', NULL, 'Casa', 399.99),
('Auricolari Bluetooth Sony', 120, '2025-12-15', NULL, 'Elettronica', 59.99),
('Scarpe Adidas Running', 80, '2025-04-01', NULL, 'Abbigliamento', 89.99),
('Stampante HP LaserJet', 35, '2026-01-20', NULL, 'Elettronica', 129.99),
('Tavolo da Pranzo in Legno', 15, '2026-06-01', NULL, 'Casa', 249.99),
('Giacca in Pelle', 50, '2025-01-15', NULL, 'Abbigliamento', 199.99),
('Monitor 27" Dell', 40, '2026-03-12', NULL, 'Elettronica', 299.00),
('Smartwatch Garmin Venu', 60, '2026-02-01', NULL, 'Elettronica', 199.99),
('Cappotto Invernale Zara', 70, '2025-11-01', NULL, 'Abbigliamento', 129.99),
('Televisore Samsung 4K 55"', 25, '2027-03-01', NULL, 'Elettronica', 899.00),
('Aspirapolvere Rowenta', 20, '2026-04-01', NULL, 'Casa', 199.99),
('Specchio da Parete 100x70', 25, '2025-08-01', NULL, 'Casa', 49.99),
('Lampada da Terra Moderna', 70, '2026-02-15', NULL, 'Casa', 79.99),
('Laptop HP Pavilion', 30, '2026-06-10', NULL, 'Elettronica', 1099.99),
('Console PlayStation 5', 25, '2026-06-15', NULL, 'Elettronica', 549.99),
('Sedia Ergonomica Ufficio', 50, '2025-12-12', NULL, 'Casa', 129.99),
('Set Pentole Acciaio', 40, '2026-01-01', NULL, 'Casa', 129.99),
('Divano 3 Posti Grigio', 10, '2027-01-10', NULL, 'Casa', 799.00),
('Zaino Eastpak Nero', 120, '2025-03-01', NULL, 'Abbigliamento', 59.99),
('Mouse Wireless Logitech', 300, '2025-06-01', NULL, 'Elettronica', 19.99),
('Tablet Apple iPad Air', 40, '2026-01-15', NULL, 'Elettronica', 699.00),
('Cintura in Pelle', 90, '2025-03-01', NULL, 'Abbigliamento', 19.99),
('Occhiali da Sole Ray-Ban', 60, '2026-04-01', NULL, 'Abbigliamento', 149.99),
('Maglietta Nike', 200, '2025-06-01', NULL, 'Abbigliamento', 24.99);


CREATE TABLE Cliente(id INT PRIMARY KEY IDENTITY(1,1),
			 username VARCHAR(150),
			 dataIscrizione DATE,
			 maggiorenne BIT);
		

INSERT INTO Cliente (username, dataIscrizione, maggiorenne)
VALUES
('LucaRossi', '2023-05-01', 1),
('GiuliaBianchi', '2022-09-15', 1),
('MarcoVerdi', '2024-02-10', 1),
('AliceNeri', '2024-11-20', 0),
('DavideBlu', '2024-12-01', 1),
('SofiaGialli', '2023-08-12', 1),
('MattiaViola', '2024-01-05', 0),
('ChiaraRosa', '2022-11-25', 1),
('FedericoAzzurro', '2023-03-15', 1),
('ElenaGrigio', '2024-03-30', 0),
('GiorgiaMarrone', '2024-06-10', 1),
('TommasoBianco', '2023-01-20', 1),
('MartinaRosso', '2024-09-12', 0),
('AndreaVerde', '2023-07-05', 1),
('FrancescaBlu', '2023-12-22', 1);

CREATE TABLE Carrello (idCliente INT,
			 idProdotto INT,
			 quantitaAcquisto INT,
			 PRIMARY KEY (idCliente, idProdotto),
			 FOREIGN KEY (idCliente) REFERENCES Cliente(id),
			 FOREIGN KEY (idProdotto) REFERENCES Prodotti(id));

INSERT INTO Carrello (idCliente, idProdotto, quantitaAcquisto)
VALUES (1, 1, 2),
       (1, 3, 1),
       (1, 5, 4),
       (2, 7, 1),
       (2, 9, 3),
       (3, 11, 2),
       (3, 13, 1),
       (4, 15, 5),
       (5, 17, 2),
       (6, 19, 3);

--QUERY PER VISUALIZZARE I DATI (UTILIZZATA PER AVERE UN QUADRO PER CREARE LE QUERY SUCCESSIVE) 
	select *  FROM 
    Carrello ca
INNER JOIN 
    Cliente c ON ca.idCliente = c.id
INNER JOIN 
    Prodotti m ON ca.idProdotto = m.id;


	
-- QUERY PER VEDERE L'UTENTE CHE HA SPESO DI PIU'	
SELECT TOP 1 
    Cliente.username,
    SUM(Carrello.quantitaAcquisto * Prodotti.prezzo) AS TotaleSpeso
FROM 
    Carrello
INNER JOIN 
    Cliente ON Carrello.idCliente = Cliente.id
INNER JOIN 
    Prodotti ON Carrello.idProdotto = Prodotti.id
GROUP BY 
     Cliente.username
ORDER BY 
    TotaleSpeso DESC;


-- INSERT PER PROVARE SE LA QUERY TORNAVA LA SOMMA DI ARTICOLI ACQUISTATI PIU' VOLTE
INSERT INTO Carrello (idCliente,idProdotto, quantitaAcquisto) VALUES (1,9,3); 

-- QUERY PER VEDERE L'ARTICOLO CHE E'STATO ACQUISTATO PIU' VOLTE
SELECT top 1 Prodotti.nome, sum(carrello.quantitaAcquisto) AS volteAcquistato
FROM 
    Carrello
INNER JOIN 
    Cliente ON Carrello.idCliente = Cliente.id
INNER JOIN 
    Prodotti ON Carrello.idProdotto = Prodotti.id
GROUP BY Prodotti.nome
order by volteAcquistato desc;


-- INSERISCO DUE PRODOTTI CHE ABBIANO DA 1 A 3 GIORNI RIMANENTI ALLA SCADENZA
INSERT INTO Prodotti (nome, quantitaMagazzino, dataCambio, dataScadenza, categoria, prezzo)
VALUES 
('Pane Ciabatta', 20, '2024-12-18', '2024-12-18', 'Alimentari', 1.00),
('Brioche', 2, '2024-12-19', '2024-12-19', 'Alimentari', 1.20);
-- QUERY PER VEDERE I PRODOTTI PROSSIMI ALLA SCADENZA
SELECT Prodotti.nome, dataScadenza, DATEDIFF(DAY,SYSDATETIME(),dataScadenza) as giorniAllaScadenza
FROM Prodotti
WHERE categoria = 'Alimentari' AND DATEDIFF(DAY,SYSDATETIME(),dataScadenza) <= 3


