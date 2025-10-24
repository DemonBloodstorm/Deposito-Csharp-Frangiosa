DELETE FROM Libri;

CREATE TABLE Libri (
id INT PRIMARY KEY,
titolo VARCHAR(100),
autore VARCHAR(100),
genere VARCHAR(50),
prezzo DECIMAL(5,2),
anno_pubblicazione INT
)



INSERT INTO Libri (id, titolo, autore, genere, prezzo, anno_pubblicazione)
VALUES
(1, '1984', 'George Orwell', 'Distopico', 12.50, 1949),
(2, 'Il nome della rosa', 'Umberto Eco', 'Storico', 14.90, 1980),
(3, 'Harry Potter e la pietra filosofale', 'J.K. Rowling', 'Fantasy', 9.99, 1997),
(4, 'Orgoglio e pregiudizio', 'Jane Austen', 'Romanzo', 8.50, 1813),
(5, 'Il signore degli anelli', 'J.R.R. Tolkien', 'Fantasy', 22.00, 1954),
(6, 'Cronache marziane', 'Ray Bradbury', 'Fantascienza', 10.75, 1950),
(7, 'Il piccolo principe', 'Antoine de Saint-Exupéry', 'Fiaba', 7.20, 1943),
(8, 'La coscienza di Zeno', 'Italo Svevo', 'Romanzo psicologico', 11.00, 1923),
(9, 'Cent\'anni di solitudine', 'Gabriel García Márquez', 'Realismo magico', 13.40, 1967),
(10, 'Dune', 'Frank Herbert', 'Fantascienza', 15.90, 1965);


INSERT INTO Libri (id, titolo, autore, genere, prezzo, anno_pubblicazione)
VALUES
(11, 'La ragazza del treno', 'Paula Hawkins', 'Thriller', 11.99, 2015),
(12, 'L’amica geniale', 'Elena Ferrante', 'Romanzo', 13.50, 2011),
(13, 'Ready Player One', 'Ernest Cline', 'Fantascienza', 12.80, 2011),
(14, 'Il potere del cane', 'Don Winslow', 'Crime', 14.90, 2015),
(15, 'Il cacciatore di aquiloni', 'Khaled Hosseini', 'Drammatico', 10.50, 2013),
(16, 'It Ends With Us', 'Colleen Hoover', 'Romance', 9.99, 2016),
(17, 'La casa sul mare celeste', 'T.J. Klune', 'Fantasy', 15.70, 2020),
(18, 'Project Hail Mary', 'Andy Weir', 'Fantascienza', 16.20, 2021),
(19, 'La biblioteca di mezzanotte', 'Matt Haig', 'Narrativa', 12.60, 2020),
(20, 'Il caso Alaska Sanders', 'Joël Dicker', 'Giallo', 18.00, 2022);



SELECT genere, COUNT(*) AS numero_libri, ROUND(AVG(prezzo), 2) AS prezzo_medio
FROM Libri
GROUP BY genere
ORDER BY genere ASC;

SELECT *
FROM Libri
WHERE anno_pubblicazione > 2010
ORDER BY anno_pubblicazione DESC, prezzo ASC;