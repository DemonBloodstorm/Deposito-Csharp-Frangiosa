CREATE TABLE Clienti2 (
id INT,
nome VARCHAR(100),
città VARCHAR(100)
);
CREATE TABLE Ordini (
id INT,
id_cliente INT,
data_ordine DATE,
importo DECIMAL(7,2)
);

-- Tabella Clienti2
INSERT INTO Clienti2 (id, nome, città) VALUES
(1, 'Luca Rossi', 'Milano'),
(2, 'Giulia Bianchi', 'Roma'),
(3, 'Marco Verdi', 'Torino'),
(4, 'Sara Esposito', 'Napoli'),
(5, 'Francesco Ricci', 'Bologna'),
(6, 'Elena Galli', 'Firenze'),
(7, 'Matteo Fontana', 'Venezia'),
(8, 'Chiara Marino', 'Genova'),
(9, 'Davide Greco', 'Palermo'),
(10, 'Alice Conti', 'Verona'),
(11, 'Simone Ferrari', 'Padova'),
(12, 'Valentina Romano', 'Trieste'),
(13, 'Andrea Barbieri', 'Modena'),
(14, 'Elisa Fonti', 'Perugia'),
(15, 'Riccardo Serra', 'Cagliari'),
(16, 'Beatrice Moretti', 'Brescia'),
(17, 'Stefano Villa', 'Ancona'),
(18, 'Laura Marchetti', 'Salerno'),
(19, 'Roberto Bruni', 'Lecce'),
(20, 'Federica Corsi', 'Pisa'),
(21, 'Giovanna Leone', 'Catania'),
(22, 'Filippo Neri', 'Messina');

-- Tabella Ordini (id_cliente tra 1 e 20, date casuali nel 2025, importi casuali)
INSERT INTO Ordini (id, id_cliente, data_ordine, importo) VALUES
(1, 1, '2025-01-12', 250.50),
(2, 2, '2025-02-05', 120.00),
(3, 3, '2025-03-17', 340.75),
(4, 4, '2025-04-01', 89.99),
(5, 5, '2025-01-28', 450.00),
(6, 6, '2025-02-15', 310.25),
(7, 7, '2025-03-20', 75.50),
(8, 8, '2025-04-10', 199.99),
(9, 9, '2025-01-05', 520.00),
(10, 10, '2025-02-22', 145.75),
(11, 11, '2025-03-03', 299.99),
(12, 12, '2025-04-15', 180.00),
(13, 13, '2025-01-18', 410.50),
(14, 14, '2025-02-27', 225.30),
(15, 15, '2025-03-12', 350.00),
(16, 16, '2025-04-20', 99.95),
(17, 17, '2025-01-30', 275.80),
(18, 18, '2025-02-10', 310.00),
(19, 19, '2025-03-25', 150.25),
(20, 20, '2025-04-05', 420.00);


INSERT INTO Ordini (id, id_cliente, data_ordine, importo) VALUES
(21, FLOOR(1 + RAND()*20), '2025-01-08', 180.50),
(22, FLOOR(1 + RAND()*20), '2025-01-15', 245.00),
(23, FLOOR(1 + RAND()*20), '2025-01-20', 310.25),
(24, FLOOR(1 + RAND()*20), '2025-02-05', 95.75),
(25, FLOOR(1 + RAND()*20), '2025-02-12', 400.00),
(26, FLOOR(1 + RAND()*20), '2025-02-18', 150.50),
(27, FLOOR(1 + RAND()*20), '2025-03-02', 220.00),
(28, FLOOR(1 + RAND()*20), '2025-03-10', 330.75),
(29, FLOOR(1 + RAND()*20), '2025-03-15', 175.25),
(30, FLOOR(1 + RAND()*20), '2025-03-22', 280.00),
(31, FLOOR(1 + RAND()*20), '2025-04-01', 90.00),
(32, FLOOR(1 + RAND()*20), '2025-04-05', 345.50),
(33, FLOOR(1 + RAND()*20), '2025-04-10', 260.00),
(34, FLOOR(1 + RAND()*20), '2025-04-12', 195.75),
(35, FLOOR(1 + RAND()*20), '2025-04-15', 410.00),
(36, FLOOR(1 + RAND()*20), '2025-04-18', 150.25),
(37, FLOOR(1 + RAND()*20), '2025-04-20', 300.00),
(38, FLOOR(1 + RAND()*20), '2025-04-22', 120.50),
(39, FLOOR(1 + RAND()*20), '2025-04-25', 275.75),
(40, FLOOR(1 + RAND()*20), '2025-04-28', 390.00)
(41, 99, '2025-05-01', 150.00),
(42, 100, '2025-05-03', 200.00);

SELECT * FROM ordini;
SELECT * FROM clienti2;

/* INNER JOIN */
SELECT clienti2.nome AS 'Nome Cliente', ordini.data_ordine AS 'Data Ordine', ordini.importo AS 'Importo' FROM ordini
INNER JOIN clienti2 ON ordini.id_cliente = clienti2.id
ORDER BY id_cliente;

/* LEFT JOIN */
SELECT clienti2.nome AS 'Nome Cliente', ordini.data_ordine AS 'Data Ordine', ordini.importo AS 'Importo'  FROM ordini
LEFT JOIN clienti2 ON  clienti2.id = ordini.id_cliente
ORDER BY id_cliente;

/* RIGHT JOIN */
SELECT clienti2.nome AS 'Nome Cliente', ordini.data_ordine AS 'Data Ordine', ordini.importo AS 'Importo'  FROM ordini
RIGHT JOIN clienti2 ON  clienti2.id = ordini.id_cliente
ORDER BY id_cliente;

/* EXTRA */

SELECT clienti2.id AS id_cliente, clienti2.nome AS 'Nome Cliente', ordini.data_ordine AS 'Data Ordine', ordini.importo AS 'Importo'
FROM ordini
LEFT JOIN clienti2 ON clienti2.id = ordini.id_cliente

UNION

SELECT clienti2.id AS id_cliente, clienti2.nome AS 'Nome Cliente', ordini.data_ordine AS 'Data Ordine', ordini.importo AS 'Importo'
FROM ordini
RIGHT JOIN clienti2 ON clienti2.id = ordini.id_cliente

ORDER BY id_cliente;


