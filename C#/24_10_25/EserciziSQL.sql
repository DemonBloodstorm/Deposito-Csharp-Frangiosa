
/* Utilizzo di DISTINCT e WHERE*/
SELECT DISTINCT Region
FROM country
WHERE Continent = 'EUROPE';

/* UTILIZZO DI WHERE E GROUP BY */
SELECT Name, Population FROM city
WHERE CountryCode = 'USA' AND Population > 1000000
ORDER BY Population DESC;

/* UTILIZZO DI GROUP BY CON FUNZIONI DI AGGREGAZIONE */
SELECT Continent, COUNT(*) AS Numero_Paesi, SUM(Population) AS Popolazione_Totale
FROM country
GROUP BY Continent
ORDER BY Popolazione_Totale DESC;
