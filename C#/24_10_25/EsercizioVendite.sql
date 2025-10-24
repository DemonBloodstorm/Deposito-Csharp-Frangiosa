USE world;

CREATE TABLE VENDITE(
    ID INT PRIMARY KEY AUTO_INCREMENT,
    prodotto VARCHAR(100),
    categoria VARCHAR(50),
    quantita INT,
    prezzo_unitario DECIMAL(5,2),
    data_vendita DATE
)

INSERT INTO VENDITE (prodotto, categoria, quantita, prezzo_unitario, data_vendita) VALUES
('Laptop ASUS ZenBook', 'Elettronica', 3, 899.99, '2025-10-01'),
('Smartphone Samsung Galaxy', 'Elettronica', 5, 699.50, '2025-10-02'),
('Tavolo da pranzo in legno', 'Arredamento', 2, 249.90, '2025-10-03'),
('Sedia da ufficio ergonomica', 'Arredamento', 4, 129.99, '2025-10-04'),
('Libro "Python Avanzato"', 'Libri', 10, 39.90, '2025-10-05'),
('Auricolari Wireless', 'Elettronica', 6, 59.99, '2025-10-06'),
('Lampada da scrivania LED', 'Arredamento', 8, 29.99, '2025-10-07'),
('Notebook Moleskine', 'Cancelleria', 15, 12.50, '2025-10-08'),
('Penna Stilografica', 'Cancelleria', 20, 8.90, '2025-10-09'),
('Zaino da trekking', 'Sport', 3, 89.99, '2025-10-10');
('Laptop ASUS ZenBook', 'Elettronica', 3, 899.99, '2025-10-01'),
('Smartphone Samsung Galaxy', 'Elettronica', 5, 699.50, '2025-10-02'),
('Tavolo da pranzo in legno', 'Arredamento', 2, 249.90, '2025-10-03'),
('Sedia da ufficio ergonomica', 'Arredamento', 4, 129.99, '2025-10-04'),
('Libro "Python Avanzato"', 'Libri', 10, 39.90, '2025-10-05'),
('Auricolari Wireless', 'Elettronica', 6, 59.99, '2025-10-06'),
('Lampada da scrivania LED', 'Arredamento', 8, 29.99, '2025-10-07'),
('Notebook Moleskine', 'Cancelleria', 15, 12.50, '2025-10-08'),
('Penna Stilografica', 'Cancelleria', 20, 8.90, '2025-10-09'),
('Zaino da trekking', 'Sport', 3, 89.99, '2025-10-10'),
('Bicicletta da corsa', 'Sport', 2, 499.99, '2025-10-11'),
('T-shirt cotone', 'Abbigliamento', 12, 19.99, '2025-10-12'),
('Jeans Levi\'s', 'Abbigliamento', 6, 59.90, '2025-10-13'),
('Scarpe da corsa Nike', 'Abbigliamento', 5, 99.99, '2025-10-14'),
('Orologio da polso Casio', 'Elettronica', 4, 49.90, '2025-10-15'),
('Cuffie Bluetooth Sony', 'Elettronica', 7, 79.99, '2025-10-16'),
('Tavolino da caffè', 'Arredamento', 3, 69.90, '2025-10-17'),
('Divano 3 posti', 'Arredamento', 1, 599.99, '2025-10-18'),
('Agenda 2025', 'Cancelleria', 25, 9.90, '2025-10-19'),
('Set penne colorate', 'Cancelleria', 30, 5.99, '2025-10-20'),
('Pallone da calcio', 'Sport', 10, 24.99, '2025-10-21'),
('Racchetta da tennis', 'Sport', 4, 79.90, '2025-10-22'),
('Maglione lana', 'Abbigliamento', 8, 49.99, '2025-10-23'),
('Giacca invernale', 'Abbigliamento', 3, 129.99, '2025-10-24'),
('Libro "Data Science"', 'Libri', 7, 44.90, '2025-10-25'),
('Monitor 24"', 'Elettronica', 5, 159.99, '2025-10-26'),
('Tavolo da ufficio', 'Arredamento', 2, 199.90, '2025-10-27'),
('Lampada da terra', 'Arredamento', 3, 39.99, '2025-10-28'),
('Quaderno A4', 'Cancelleria', 50, 2.50, '2025-10-29'),
('Calzini cotone', 'Abbigliamento', 20, 3.99, '2025-10-30'),
('Scarpe da trekking', 'Abbigliamento', 4, 129.99, '2025-10-31'),
('Tablet Samsung', 'Elettronica', 3, 349.99, '2025-11-01'),
('Smartwatch Apple', 'Elettronica', 2, 399.99, '2025-11-02'),
('Poltrona relax', 'Arredamento', 1, 299.90, '2025-11-03'),
('Tavolo pieghevole', 'Arredamento', 5, 89.99, '2025-11-04'),
('Set evidenziatori', 'Cancelleria', 40, 7.50, '2025-11-05'),
('Zaino scuola', 'Abbigliamento', 10, 29.99, '2025-11-06'),
('Pantaloni sportivi', 'Abbigliamento', 12, 24.99, '2025-11-07'),
('Libro "Machine Learning"', 'Libri', 6, 49.90, '2025-11-08'),
('Cuffie gaming', 'Elettronica', 5, 89.99, '2025-11-09'),
('Lampada da comodino', 'Arredamento', 7, 19.99, '2025-11-10'),
('Quaderno sketch', 'Cancelleria', 20, 14.90, '2025-11-11'),
('Set pennelli', 'Cancelleria', 15, 12.99, '2025-11-12'),
('Bicicletta mountain bike', 'Sport', 2, 399.99, '2025-11-13'),
('Pallone basket', 'Sport', 8, 29.99, '2025-11-14'),
('Felpa con cappuccio', 'Abbigliamento', 9, 39.99, '2025-11-15'),
('Giacca a vento', 'Abbigliamento', 5, 69.99, '2025-11-16'),
('Libro "Algoritmi e strutture dati"', 'Libri', 10, 54.90, '2025-11-17'),
('Cuffie over-ear', 'Elettronica', 6, 99.99, '2025-11-18'),
('Scrivania in legno', 'Arredamento', 2, 199.99, '2025-11-19'),
('Lampada da parete', 'Arredamento', 4, 49.99, '2025-11-20');


/* Calcola il totale delle vendite per ogni categoria*/
SELECT categoria, SUM(quantita * prezzo_unitario) AS totale_vendite
FROM VENDITE
GROUP BY categoria;

/*Mostra per ogni categoria, il prezzo medio dei prodotti venduti*/
SELECT categoria, AVG(Prezzo_unitario) AS prezzo_medio_venduto
FROM VENDITE
GROUP BY categoria;

/*Mostra la quantita totale venduta per ogni prodotto*/
SELECT prodotto, SUM(quantita) AS quantita_totale_venduta
FROM VENDITE
GROUP BY prodotto;

/*Mostra il prezzo massimo e minimo per ogni prodotto*/
SELECT prodotto, MAX(prezzo_unitario) AS prezzo_massimo, MIN(prezzo_unitario) AS prezzo_minimo
FROM VENDITE
GROUP BY prodotto;

/* Conta quante vendite sono state registrate nella tabella Vendite.*/
SELECT COUNT(ID) AS numero_vendite
FROM VENDITE

/* Mostra i 5 prodotti più costosi venduti*/
SELECT prodotto, prezzo_unitario
FROM VENDITE 
ORDER BY prezzo_unitario DESC
LIMIT 5;

/* Mostra i 3 prodotti più venduti (in termini di quantità)*/
SELECT prodotto, SUM(quantita) AS quantita_totale_venduta
FROM VENDITE
GROUP BY prodotto
ORDER BY quantita_totale_venduta 
LIMIT 3;
