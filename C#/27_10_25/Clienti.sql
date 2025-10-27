
USE world;

CREATE TABLE Clienti (
id INT,
nome VARCHAR(100),
cognome VARCHAR(100),
email VARCHAR(100),
eta INT,
citta VARCHAR(100)
)


INSERT INTO Clienti (id, nome, cognome, email, eta, citta)
VALUES
(1, 'Luca', 'Rossi', 'luca.rossi@gmail.com', 32, 'Milano'),
(2, 'Giulia', 'Bianchi', 'giulia.bianchi@yahoo.it', 28, 'Roma'),
(3, 'Marco', 'Verdi', 'marco.verdi@outlook.com', 45, 'Torino'),
(4, 'Sara', 'Esposito', 'sara.esposito@gmail.com', 22, 'Napoli'),
(5, 'Francesco', 'Ricci', 'francesco.ricci@libero.it', 39, 'Bologna'),
(6, 'Elena', 'Galli', 'elena.galli@gmail.com', 30, 'Firenze'),
(7, 'Matteo', 'Fontana', 'matteo.fontana@icloud.com', 27, 'Venezia'),
(8, 'Chiara', 'Marino', 'chiara.marino@gmail.com', 34, 'Genova'),
(9, 'Davide', 'Greco', 'davide.greco@outlook.it', 41, 'Palermo'),
(10, 'Alice', 'Conti', 'alice.conti@gmail.com', 25, 'Verona'),
(11, 'Simone', 'Ferrari', 'simone.ferrari@libero.it', 36, 'Padova'),
(12, 'Valentina', 'Romano', 'valentina.romano@gmail.com', 29, 'Trieste'),
(13, 'Andrea', 'Barbieri', 'andrea.barbieri@yahoo.it', 47, 'Modena'),
(14, 'Elisa', 'Fonti', 'elisa.fonti@gmail.com', 31, 'Perugia'),
(15, 'Riccardo', 'Serra', 'riccardo.serra@outlook.com', 52, 'Cagliari'),
(16, 'Beatrice', 'Moretti', 'beatrice.moretti@gmail.com', 24, 'Brescia'),
(17, 'Stefano', 'Villa', 'stefano.villa@live.it', 33, 'Ancona'),
(18, 'Laura', 'Marchetti', 'laura.marchetti@gmail.com', 38, 'Salerno'),
(19, 'Roberto', 'Bruni', 'roberto.bruni@yahoo.com', 44, 'Lecce'),
(20, 'Federica', 'Corsi', 'federica.corsi@gmail.com', 26, 'Pisa'),
(21, 'Giorgio', 'Bernardi', 'giorgio.bernardi@outlook.it', 50, 'Taranto'),
(22, 'Martina', 'Vitale', 'martina.vitale@gmail.com', 23, 'Lucca'),
(23, 'Alessandro', 'Rinaldi', 'alessandro.rinaldi@libero.it', 39, 'Reggio Emilia'),
(24, 'Francesca', 'Parisi', 'francesca.parisi@gmail.com', 34, 'Potenza'),
(25, 'Paolo', 'Sartori', 'paolo.sartori@yahoo.it', 41, 'Bolzano'),
(26, 'Caterina', 'Riva', 'caterina.riva@gmail.com', 29, 'Trento'),
(27, 'Emanuele', 'Longo', 'emanuele.longo@outlook.com', 43, 'Salerno'),
(28, 'Sara', 'Fabbri', 'sara.fabbri@gmail.com', 35, 'Catanzaro'),
(29, 'Michele', 'Mariani', 'michele.mariani@icloud.com', 48, 'Como'),
(30, 'Ilaria', 'Negri', 'ilaria.negri@gmail.com', 27, 'Pavia'),
(31, 'Davide', 'Costa', 'davide.costa@outlook.com', 31, 'Bari'),
(32, 'Silvia', 'Gentile', 'silvia.gentile@gmail.com', 36, 'L’Aquila'),
(33, 'Alberto', 'Ferri', 'alberto.ferri@libero.it', 55, 'Foggia'),
(34, 'Martina', 'Palumbo', 'martina.palumbo@gmail.com', 28, 'Salerno'),
(35, 'Lorenzo', 'Villa', 'lorenzo.villa@yahoo.it', 40, 'Savona'),
(36, 'Noemi', 'Marchetti', 'noemi.marchetti@gmail.com', 22, 'Siracusa'),
(37, 'Giovanni', 'Costantini', 'giovanni.costantini@outlook.it', 46, 'Novara'),
(38, 'Barbara', 'Rossi', 'barbara.rossi@gmail.com', 37, 'Rimini'),
(39, 'Riccardo', 'D’Angelo', 'riccardo.dangelo@gmail.com', 49, 'Aosta'),
(40, 'Paola', 'Morelli', 'paola.morelli@libero.it', 30, 'Caserta'),
(41, 'Vincenzo', 'Martini', 'vincenzo.martini@virgilio.it', 53, 'Pordenone'),
(42, 'Lucia', 'Bianco', 'lucia.bianco@gmail.com', 25, 'Savona'),
(43, 'Ludovica', 'Neri', 'ludovica.neri@yahoo.it', 29, 'Catania'),
(44, 'Tommaso', 'Costi', 'tommaso.costi@outlook.com', 34, 'Pordenone'),
(45, 'Elisa', 'Barone', 'elisa.barone@gmail.com', 42, 'Taranto'),
(46, 'Edoardo', 'Silvestri', 'edoardo.silvestri@hotmail.com', 38, 'Vicenza'),
(47, 'Chiara', 'Riccardi', 'chiara.riccardi@gmail.com', 33, 'Livorno'),
(48, 'Federico', 'Cattaneo', 'federico.cattaneo@tiscali.it', 27, 'Lucca'),
(49, 'Beatrice', 'Pellegrini', 'beatrice.pellegrini@gmail.com', 31, 'Messina'),
(50, 'Giuseppe', 'Sanna', 'giuseppe.sanna@sanna.giuseppe@gmail.com', 45, 'Sassari'),
(51, 'Anna', 'Marchetti', 'anna.marchetti@icloud.com', 26, 'Fermo'),
(52, 'Luca', 'Martini', 'luca.martini@gmail.com', 35, 'Agrigento'),
(53, 'Irene', 'Conti', 'irene.conti@libero.it', 29, 'Lodi'),
(54, 'Stefania', 'Orlando', 'stefania.orlando@yahoo.it', 44, 'Asti'),
(55, 'Paolo', 'Gentili', 'paolo.gentili@outlook.it', 38, 'Colegna'),
(56, 'Cinzia', 'Ferri', 'cinzia.ferri@gmail.com', 49, 'Potenza'),
(57, 'Daniele', 'Morelli', 'daniele.morelli@libero.it', 32, 'Campobasso'),
(58, 'Marta', 'Sala', 'marta.sala@gmail.com', 23, 'Grosseto'),
(59, 'Alessia', 'Palmeri', 'alessia.palmeri@yahoo.it', 37, 'Brindisi'),
(60, 'Gianluca', 'Rossi', 'gianluca.rossi@outlook.com', 51, 'Tarvisio'),
(61, 'Elena', 'Pellegrino', 'elena.pellegrino@gmail.com', 30, 'Sondrio'),
(62, 'Giorgia', 'Ferrari', 'giorgia.ferrari@icloud.com', 28, 'Piacenza'),
(63, 'Franco', 'Donati', 'franco.donati@hotmail.com', 47, 'Verbania'),
(64, 'Susanna', 'Milani', 'susanna.milani@yahoo.it', 34, 'Arezzo'),
(65, 'Riccardo', 'Villa', 'riccardo.villa@gmail.com', 29, 'Latina'),
(66, 'Martina', 'Rossi', 'martina.rossi@libero.it', 41, 'Avellino'),
(67, 'Giacomo', 'Moretti', 'giacomo.moretti@gmail.com', 39, 'Pordenone'),
(68, 'Stefania', 'Ferraro', 'stefania.ferraro@outlook.com', 33, 'Varese'),
(69, 'Alessandra', 'Sala', 'alessandra.sala@gmail.com', 52, 'Ragusa'),
(70, 'Emanuele', 'Serra', 'emanuele.serra@yahoo.it', 35, 'Barletta'),
(71, 'Valentina', 'Ricci', 'valentina.ricci@gmail.com', 29, 'Cuneo'),
(72, 'Paolo', 'Ferrari', 'paolo.ferrari@virgilio.it', 46, 'Siracusa'),
(73, 'Maria', 'Morelli', 'maria.morelli@hotmail.com', 53, 'Viterbo'),
(74, 'Francesca', 'Silvestri', 'francesca.silvestri@gmail.com', 38, 'Livorno'),
(75, 'Giorgio', 'Riva', 'giorgio.riva@yahoo.it', 40, 'Lucca'),
(76, 'Simona', 'Zanetti', 'simona.zanetti@gmail.com', 26, 'Ravenna'),
(77, 'Maurizio', 'Sala', 'maurizio.sala@libero.it', 58, 'Bolzano'),
(78, 'Monica', 'Grassi', 'monica.grassi@hotmail.com', 31, 'Vicenza'),
(79, 'Adriano', 'Bernardi', 'adriano.bernardi@gmail.com', 43, 'Trento'),
(80, 'Paola', 'Rinaldi', 'paola.rinaldi@outlook.com', 37, 'Lidi'),
(81, 'Sara', 'Marchetti', 'sara.marchetti@gmail.com', 32, 'Forlì'),
(82, 'Enrico', 'De Luca', 'enrico.deluca@yahoo.it', 54, 'Frosinone'),
(83, 'Teresa', 'Romani', 'teresa.romani@gmail.com', 28, 'Pordenone'),
(84, 'Mario', 'Bruno', 'mario.bruno@libero.it', 60, 'Carrara'),
(85, 'Laura', 'Colombo', 'laura.colombo@gmail.com', 33, 'Monza'),
(86, 'Federico', 'Serafini', 'federico.serafini@outlook.it', 29, 'Cesena'),
(87, 'Elena', 'Rossi', 'elena.rossi@yahoo.it', 42, 'Cremona'),
(88, 'Simone', 'Gatti', 'simone.gatti@gmail.com', 27, 'Mantova'),
(89, 'Barbara', 'Sala', 'barbara.sala@icloud.com', 50, 'Marsala'),
(90, 'Nicola', 'Grasso', 'nicola.grasso@hotmail.com', 36, 'Gela'),
(91, 'Irene', 'Bellini', 'irene.bellini@gmail.com', 24, 'Caltanissetta'),
(92, 'Vittorio', 'D\'Angelo', 'vittorio.dangelo@outlook.com', 47, 'Rieti'),
(93, 'Claudia', 'Marzo', 'claudia.marzo@yahoo.it', 31, 'Oristano'),
(94, 'Raffaele', 'Caputo', 'raffaele.caputo@gmail.com', 38, 'Aversa'),
(95, 'Marta', 'Luciani', 'marta.luciani@libero.it', 26, 'Sanremo'),
(96, 'Gabriele', 'Palma', 'gabriele.palma@gmail.com', 44, 'Cosenza'),
(97, 'Beatrice', 'Serafini', 'beatrice.serafini@outlook.com', 30, 'Imperia'),
(98, 'Vincenzo', 'Rossi', 'vincenzo.rossi@yahoo.it', 55, 'Avellino'),
(99, 'Alessio', 'De Santis', 'alessio.desantis@gmail.com', 28, 'Castellammare'),
(100, 'Sara', 'Bellotti', 'sara.bellotti@virgilio.it', 35, 'Termoli');

SELECT * FROM clienti;

/* CLIENTI CON EMAIL SU DOMINIO GMAIL.COM */
SELECT * FROM Clienti
WHERE email LIKE '%@gmail%';

/* CLIENTI CON NOME CHE INIZIA CON A */
SELECT * FROM clienti
WHERE nome LIKE 'A%'
ORDER BY nome;

/* CLIENTI CON COGNOME DI 5 CARATTERI */
SELECT * FROM clienti
WHERE cognome LIKE '_____'
ORDER BY cognome;

/* CLIENTI CON ETÀ compresa tra 30 e 40 anni (INCLUSI) */
SELECT * FROM clienti
WHERE eta BETWEEN 30 AND 40
ORDER BY eta;

/* CLIENTI CON ETÀ compresa tra 30 e 40 anni (COMPRESI) */
SELECT * FROM clienti
WHERE eta > 30 AND eta < 40
ORDER BY eta;

/* CLIENTI NASCUTI IN ROMA */
SELECT * FROM clienti
WHERE citta LIKE 'ROMA'
ORDER BY cognome;

/* CLIENTI NASCUTI IN ROMA E CON ETÀ compresa tra 30 e 40 anni */
SELECT * FROM clienti
WHERE citta LIKE 'ROMA'
ORDER BY nome;

INSERT INTO Clienti (id, nome, cognome, email, eta, citta)
VALUES
(101, 'Alessandro', 'Galli', 'alessandro.galli@gmail.com', 33, 'Milano'),
(102, 'Martina', 'Rossi', 'martina.rossi@yahoo.it', 29, 'Milano'),
(103, 'Luca', 'Esposito', 'luca.esposito@outlook.com', 40, 'Milano'),
(104, 'Giulia', 'Ferrari', 'giulia.ferrari@gmail.com', 26, 'Milano'),
(105, 'Marco', 'Moretti', 'marco.moretti@libero.it', 35, 'Milano'),
(106, 'Sara', 'Marini', 'sara.marini@gmail.com', 31, 'Milano'),
(107, 'Francesco', 'Bruni', 'francesco.bruni@yahoo.it', 38, 'Milano'),
(108, 'Elena', 'Bernardi', 'elena.bernardi@outlook.com', 27, 'Milano'),
(109, 'Davide', 'Fontana', 'davide.fontana@gmail.com', 42, 'Milano'),
(110, 'Alice', 'Giorgi', 'alice.giorgi@libero.it', 24, 'Milano'),
(111, 'Stefania', 'Conti', 'stefania.conti@gmail.com', 36, 'Milano'),
(112, 'Simone', 'Rinaldi', 'simone.rinaldi@yahoo.it', 30, 'Milano'),
(113, 'Chiara', 'Fabbri', 'chiara.fabbri@outlook.com', 28, 'Milano'),
(114, 'Roberto', 'Sala', 'roberto.sala@gmail.com', 39, 'Milano'),
(115, 'Federica', 'Palmeri', 'federica.palmeri@libero.it', 25, 'Milano'),
(116, 'Lorenzo', 'Marino', 'lorenzo.marino@gmail.com', 37, 'Roma'),
(117, 'Ilaria', 'Gatti', 'ilaria.gatti@yahoo.it', 32, 'Roma'),
(118, 'Alessia', 'Romano', 'alessia.romano@outlook.com', 29, 'Roma'),
(119, 'Giorgio', 'Costa', 'giorgio.costa@gmail.com', 45, 'Roma'),
(120, 'Elisa', 'Fontana', 'elisa.fontana@libero.it', 26, 'Roma'),
(121, 'Paolo', 'Ferrari', 'paolo.ferrari@gmail.com', 41, 'Roma'),
(122, 'Claudia', 'Riva', 'claudia.riva@yahoo.it', 34, 'Roma'),
(123, 'Michele', 'Serra', 'michele.serra@outlook.com', 48, 'Roma'),
(124, 'Valentina', 'Bruni', 'valentina.bruni@gmail.com', 27, 'Roma'),
(125, 'Francesco', 'Marchetti', 'francesco.marchetti@libero.it', 35, 'Roma'),
(126, 'Martina', 'Bianco', 'martina.bianco@gmail.com', 30, 'Roma'),
(127, 'Davide', 'Bellini', 'davide.bellini@yahoo.it', 38, 'Roma'),
(128, 'Sara', 'Romani', 'sara.romani@outlook.com', 24, 'Roma'),
(129, 'Andrea', 'Grassi', 'andrea.grassi@gmail.com', 39, 'Roma'),
(130, 'Barbara', 'Neri', 'barbara.neri@libero.it', 33, 'Roma'),
(131, 'Simone', 'Sala', 'simone.sala@gmail.com', 40, 'Torino'),
(132, 'Elena', 'Rossi', 'elena.rossi@yahoo.it', 35, 'Torino'),
(133, 'Marco', 'Conti', 'marco.conti@outlook.com', 42, 'Torino'),
(134, 'Chiara', 'Galli', 'chiara.galli@gmail.com', 29, 'Torino'),
(135, 'Francesco', 'Ferrari', 'francesco.ferrari@libero.it', 36, 'Torino'),
(136, 'Alice', 'Fontana', 'alice.fontana@gmail.com', 31, 'Torino'),
(137, 'Luca', 'Marini', 'luca.marini@yahoo.it', 38, 'Torino'),
(138, 'Federica', 'Serra', 'federica.serra@outlook.com', 27, 'Torino'),
(139, 'Paolo', 'Moretti', 'paolo.moretti@gmail.com', 44, 'Torino'),
(140, 'Martina', 'Costa', 'martina.costa@libero.it', 25, 'Torino'),
(141, 'Andrea', 'Romano', 'andrea.romano@gmail.com', 39, 'Torino'),
(142, 'Laura', 'Bianco', 'laura.bianco@yahoo.it', 33, 'Torino'),
(143, 'Giorgio', 'Bellini', 'giorgio.bellini@outlook.com', 41, 'Torino'),
(144, 'Sara', 'Grassi', 'sara.grassi@gmail.com', 28, 'Torino'),
(145, 'Davide', 'Neri', 'davide.neri@libero.it', 32, 'Torino');

/* EXTRA: CLIENTI CON ETÀ compresa tra 20 e 40 anni NASCUTI IN ROMA */ 
SELECT * FROM clienti
where eta BETWEEN '20' AND '40'
AND
citta LIKE 'ROMA';

delete from clienti
where id BETWEEN 1 AND 300


