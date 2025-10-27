CREATE TABLE Libri (
   id INT,
   titolo VARCHAR(100),
   autore VARCHAR(100),
   genere VARCHAR(50),
   anno_pubblicazione INT,
   prezzo DECIMAL(6,2)
);
CREATE TABLE Vendite (
   id INT,
   id_libro INT,
   data_vendita DATE,
   quantita INT,
   negozio VARCHAR(100)
);

-- Inserimento dati nella tabella Libri
INSERT INTO Libri (id, titolo, autore, genere, anno_pubblicazione, prezzo) VALUES
(1, 'Il segreto del vento', 'Luca Bianchi', 'Fantasy', 2010, 19.90),
(2, 'Stelle lontane', 'Maria Rossi', 'Fantascienza', 2015, 22.50),
(3, 'Cuore ribelle', 'Francesca Neri', 'Romance', 2012, 14.90),
(4, 'La mente del detective', 'Giovanni Verdi', 'Giallo', 2018, 18.00),
(5, 'Oltre il confine', 'Alessandro Russo', 'Avventura', 2020, 20.50),
(6, 'Città senza nome', 'Silvia Fontana', 'Thriller', 2016, 21.00),
(7, 'Il giardino segreto', 'Claudia Marchetti', 'Infantile', 2011, 12.90),
(8, 'Anime perdute', 'Marco Esposito', 'Horror', 2019, 23.50),
(9, 'Sotto il cielo di Roma', 'Elena Greco', 'Storico', 2014, 17.90),
(10, 'Voci dal passato', 'Paolo Moretti', 'Giallo', 2013, 16.50),
(11, 'Il richiamo del mare', 'Lara Conti', 'Avventura', 2017, 19.00),
(12, 'Segreti e bugie', 'Federico Leone', 'Thriller', 2021, 24.00),
(13, 'La danza delle ombre', 'Giulia Piras', 'Fantasy', 2012, 18.50),
(14, 'Il canto della foresta', 'Alberto Romano', 'Fantascienza', 2018, 21.50),
(15, 'Ricordi lontani', 'Valentina Galli', 'Romance', 2016, 15.50),
(16, 'Misteri italiani', 'Daniele Ferrari', 'Giallo', 2020, 22.00),
(17, 'Il labirinto oscuro', 'Sofia Vitale', 'Horror', 2015, 20.00),
(18, 'Avventure nel tempo', 'Matteo Bianchi', 'Avventura', 2019, 23.00),
(19, 'Luce nascosta', 'Chiara De Luca', 'Fantasy', 2013, 19.50),
(20, 'Vento di libertà', 'Riccardo Sala', 'Storico', 2011, 18.00),
(21, 'Shining', 'Stephen King', 'Horror', 1977, 20.00),
(22, 'It', 'Stephen King', 'Horror', 1986, 22.50),
(23, 'Misery', 'Stephen King', 'Thriller', 1987, 19.90),
(24, 'Carrie', 'Stephen King', 'Horror', 1974, 18.50),
(25, 'The Institute', 'Stephen King', 'Thriller', 2019, 24.00),
(26, 'Doctor Sleep', 'Stephen King', 'Horror', 2013, 21.00),
(27, 'Pet Sematary', 'Stephen King', 'Horror', 1983, 19.50),
(28, 'The Outsider', 'Stephen King', 'Thriller', 2018, 23.00),
(29, 'Under the Dome', 'Stephen King', 'Fantascienza', 2009, 22.50),
(30, 'Joyland', 'Stephen King', 'Giallo', 2013, 18.90),
(31, 'Lumière sul lago', 'Andrea Ferri', 'Fantasy', 2008, 18.50),
(32, 'Notte senza fine', 'Sara Mancini', 'Horror', 2016, 21.00),
(33, 'Il custode dei segreti', 'Giorgio Conti', 'Giallo', 2019, 19.90),
(34, 'Tra le stelle', 'Lucia Romano', 'Fantascienza', 2010, 22.50),
(35, 'Ombre nella foresta', 'Paola Greco', 'Horror', 2018, 23.00),
(36, 'Avventura sulle montagne', 'Marco Vitale', 'Avventura', 2021, 20.50),
(37, 'Il mistero del castello', 'Claudia Riva', 'Giallo', 2012, 17.90),
(38, 'Vento di sabbia', 'Alessandro Moretti', 'Fantasy', 2015, 19.00),
(39, 'Segreti del passato', 'Elena Baroni', 'Romance', 2017, 16.50),
(40, 'Orizzonti lontani', 'Fabio Russo', 'Storico', 2009, 18.90);

-- Inserimento dati nella tabella Vendite
INSERT INTO Vendite (id, id_libro, data_vendita, quantita, negozio) VALUES
(1, 1, '2025-01-10', 3, 'Libreria Central'),
(2, 2, '2025-02-12', 2, 'Libri & Co.'),
(3, 3, '2025-03-05', 1, 'BookWorld'),
(4, 4, '2025-01-20', 4, 'Libreria Central'),
(5, 5, '2025-04-15', 2, 'Libri & Co.'),
(6, 6, '2025-05-10', 5, 'BookWorld'),
(7, 7, '2025-02-25', 3, 'Libreria Central'),
(8, 8, '2025-03-30', 2, 'Libri & Co.'),
(9, 9, '2025-04-05', 1, 'BookWorld'),
(10, 10, '2025-05-12', 4, 'Libreria Central'),
(11, 11, '2025-01-18', 2, 'Libri & Co.'),
(12, 12, '2025-02-22', 3, 'BookWorld'),
(13, 13, '2025-03-08', 1, 'Libreria Central'),
(14, 14, '2025-04-17', 5, 'Libri & Co.'),
(15, 15, '2025-05-20', 2, 'BookWorld'),
(16, 16, '2025-01-28', 3, 'Libreria Central'),
(17, 17, '2025-02-14', 1, 'Libri & Co.'),
(18, 18, '2025-03-21', 4, 'BookWorld'),
(19, 19, '2025-04-12', 2, 'Libreria Central'),
(20, 20, '2025-05-25', 3, 'Libri & Co.'),
(21, 21, '2025-06-01', 3, 'BookWorld'),
(22, 22, '2025-06-05', 2, 'Libreria Central'),
(23, 23, '2025-06-10', 1, 'Libri & Co.'),
(24, 24, '2025-06-15', 4, 'BookWorld'),
(25, 25, '2025-06-20', 2, 'Libreria Central'),
(26, 26, '2025-06-25', 2, 'BookStore Milano'),
(27, 27, '2025-06-28', 3, 'BookStore Roma'),
(28, 28, '2025-07-01', 1, 'BookWorld'),
(29, 29, '2025-07-05', 4, 'Libreria Central'),
(30, 30, '2025-07-10', 2, 'BookCity Milano'),
(31, 31, '2025-01-05', 2, 'FantasyStore Roma'),
(32, 32, '2025-02-12', 3, 'HorrorStore Milano'),
(33, 33, '2025-03-15', 1, 'MysteryStore Napoli'),
(34, 34, '2025-04-10', 4, 'SciFiStore Firenze'),
(35, 35, '2025-05-18', 2, 'HorrorStore Roma'),
(36, 36, '2025-06-22', 5, 'AdventureStore Torino'),
(37, 37, '2025-07-01', 2, 'MysteryStore Milano'),
(38, 38, '2025-07-05', 1, 'FantasyStore Napoli'),
(39, 39, '2025-07-10', 3, 'RomanceStore Roma'),
(40, 40, '2025-07-15', 2, 'HistoryStore Milano'),
(41, 31, '2020-03-15', 2, 'BookStore Milano'),
(42, 32, '2020-07-20', 3, 'FantasyStore Roma'),
(43, 33, '2021-01-05', 1, 'MysteryStore Napoli'),
(44, 34, '2021-06-18', 4, 'BookWorld Firenze'),
(45, 35, '2021-11-12', 2, 'HorrorStore Roma'),
(46, 36, '2022-02-25', 5, 'AdventureStore Torino'),
(47, 37, '2022-05-30', 2, 'BookCity Milano'),
(48, 38, '2022-08-15', 1, 'FantasyStore Napoli'),
(49, 39, '2022-10-10', 3, 'RomanceStore Roma'),
(50, 40, '2022-12-05', 2, 'HistoryStore Milano');

/* Esercizio 1 - INNER JOIN + WHERE + LIKE */
SELECT titolo, autore , vendite.quantita, vendite.data_vendita AS 'Data vendita'
FROM libri
INNER JOIN vendite ON libri.id = vendite.id_libro
WHERE libri.autore LIKE '%king';

/* Esercizio 2 - LEFT JOIN + WHERE + BETWEEN */
SELECT titolo, anno_pubblicazione AS 'Anno di pubblicazione', prezzo, vendite.data_vendita AS 'Data vendita'
FROM libri
LEFT JOIN vendite ON libri.id = vendite.id_libro
WHERE libri.anno_pubblicazione BETWEEN 2000 AND 2010;

/* Esercizio 3 - INNER JOIN + WHERE + IN */
SELECT titolo, negozio, quantita, prezzo * quantita AS 'Prezzo totale'
FROM vendite
INNER JOIN libri ON vendite.id_libro = libri.id
WHERE vendite.negozio IN ('Libreria Central', 'BookCity Milano', 'Cartoleria Roma');

/* Esercizio 4 - INNER JOIN + WHERE + LIKE + BETWEEN */
SELECT libri.titolo, vendite.data_vendita AS 'Data vendita', libri.prezzo, vendite.quantita
FROM libri
RIGHT JOIN vendite ON libri.id = vendite.id_libro
WHERE vendite.negozio LIKE '%Book%'
AND vendite.data_vendita BETWEEN '2020-01-01' AND '2022-12-31';

/* INNER JOIN + WHERE CONBINATO*/
SELECT titolo, autore, prezzo, data_vendita AS 'Data vendita'
FROM vendite
INNER JOIN libri ON vendite.id_libro = libri.id
WHERE libri.genere IN ('Horror', 'Fantasy', 'Giallo')
AND libri.anno_pubblicazione > 2015
AND vendite.negozio LIKE '%STORE%'
ORDER BY libri.anno_pubblicazione ASC;




