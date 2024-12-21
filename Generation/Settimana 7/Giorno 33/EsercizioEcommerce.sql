CREATE DATABASE Ecommerce

use Ecommerce

create table Prodotti( id INT PRIMARY KEY IDENTITY(1,1),
					   nome VARCHAR(250),
					   categoria VARCHAR(250),
					   marca VARCHAR(250),
					   quantita INT,
					   dataInserimento DATE);



INSERT INTO Prodotti (nome, categoria, marca, quantita, dataInserimento)
VALUES
('Smartphone Galaxy S23', 'Elettronica', 'Samsung', 50, '2024-12-01'),
('Laptop MacBook Air', 'Elettronica', 'Apple', 30, '2024-11-28'),
('Televisore 55" LED 4K', 'Elettronica', 'LG', 20, '2024-12-05'),
('Cuffie Bluetooth Sony', 'Elettronica', 'Sony', 0, '2023-12-07'),
('Tablet iPad Pro', 'Elettronica', 'Apple', 40, '2024-11-30'),
('Occhiali da sole Ray-Ban', 'Moda', 'Ray-Ban', 75, '2024-12-06'),
('Pantaloni Jeans Levi''s', 'Abbigliamento', 'Levi''s', 120, '2024-12-02'),
('Sneakers Nike Air Max', 'Calzature', 'Nike', 60, '2024-12-01'),
('Borsa a mano Gucci', 'Accessori', 'Gucci', 15, '2024-11-29'),
('Orologio Casio G-Shock', 'Accessori', 'Casio', 90, '2024-12-03'),
('Fotocamera Reflex Canon EOS', 'Elettronica', 'Canon', 25, '2024-12-04'),
('Caffettiera Espresso DeLonghi', 'Casa', 'DeLonghi', 80, '2024-11-27'),
('Frigorifero Samsung Serie 6', 'Elettrodomestici', 'Samsung', 35, '2024-12-05'),
('Macchina da caffè Nespresso', 'Elettrodomestici', 'Nespresso', 50, '2024-12-02'),
('Frullatore KitchenAid', 'Elettrodomestici', 'KitchenAid', 45, '2024-11-30'),
('Zaino Laptop Samsonite', 'Accessori', 'Samsonite', 40, '2024-12-01'),
('Sedia Ergonomica Ikea', 'Casa', 'Ikea', 60, '2024-12-06'),
('Giacca da inverno North Face', 'Abbigliamento', 'North Face', 110, '2024-12-05'),
('Monitor Dell 27" 4K', 'Elettronica', 'Dell', 55, '2024-12-07'),
('Smartwatch Apple Watch Series 8', 'Elettronica', 'Apple', 0, '2024-12-04'),
('Smartphone iPhone 13', 'Elettronica', 'Apple', 35, '2023-10-15'),
('Laptop HP Spectre x360', 'Elettronica', 'HP', 50, '2023-09-12'),
('Televisore OLED 65" LG', 'Elettronica', 'LG', 18, '2023-11-10'),
('Cuffie Noise Cancelling Bose', 'Elettronica', 'Bose', 70, '2023-08-18'),
('Tablet Samsung Galaxy Tab S7', 'Elettronica', 'Samsung', 45, '2023-12-01'),
('Occhiali da sole Oakley', 'Moda', 'Oakley', 85, '2023-07-10'),
('Camicia in cotone Hugo Boss', 'Abbigliamento', 'Hugo Boss', 110, '2023-06-21'),
('Scarpe da corsa Adidas Ultraboost', 'Calzature', 'Adidas', 50, '2023-10-05'),
('Borsa a tracolla Prada', 'Accessori', 'Prada', 25, '2023-05-25'),
('Orologio Rolex Submariner', 'Accessori', 'Rolex', 5, '2023-09-02'),
('Fotocamera mirrorless Sony Alpha 7', 'Elettronica', 'Sony', 30, '2023-04-15'),
('Aspirapolvere Dyson V15', 'Elettrodomestici', 'Dyson', 40, '2023-03-20'),
('Forno elettrico Bosch Serie 8', 'Elettrodomestici', 'Bosch', 22, '2022-11-10'),
('Macchina del pane Kenwood', 'Elettrodomestici', 'Kenwood', 60, '2022-12-03'),
('Mixer Braun Multiquick', 'Elettrodomestici', 'Braun', 55, '2022-08-18'),
('Tavolo da pranzo in legno Ikea', 'Casa', 'Ikea', 80, '2022-06-28'),
('Sedia da ufficio ergonomic La-Z-Boy', 'Casa', 'La-Z-Boy', 40, '2022-04-22'),
('Giacca di pelle Schott NYC', 'Abbigliamento', 'Schott NYC', 50, '2022-12-01'),
('Giaccone impermeabile Columbia', 'Abbigliamento', 'Columbia', 65, '2022-10-30'),
('Bicicletta da corsa Trek Madone', 'Sport', 'Trek', 25, '2022-07-15'),
('GoPro Hero 10', 'Elettronica', 'GoPro', 45, '2022-09-05'),
('Tapis Roulant NordicTrack', 'Sport', 'NordicTrack', 0, '2023-10-25'),
('Pallone da calcio Adidas Predator', 'Sport', 'Adidas', 100, '2022-12-15');

