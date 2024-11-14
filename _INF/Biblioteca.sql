-- -----------------------------------------------------
-- Table `Biblioteca`.`Autori`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Biblioteca`.`Autori` (
    `ID_Autore` INT(11) NOT NULL AUTO_INCREMENT,
    `Nome` VARCHAR(50) NULL DEFAULT NULL,
    `Cognome` VARCHAR(50) NULL DEFAULT NULL,
    `Nazionalita` VARCHAR(50) NULL DEFAULT NULL,
    PRIMARY KEY (`ID_Autore`)
) ENGINE = InnoDB AUTO_INCREMENT = 5;

-- -----------------------------------------------------
-- Table `Biblioteca`.`Libri`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Biblioteca`.`Libri` (
    `ID_Libro` INT(11) NOT NULL AUTO_INCREMENT,
    `Titolo` VARCHAR(100) NULL DEFAULT NULL,
    `Anno_Pubblicazione` INT(11) NULL DEFAULT NULL,
    `ID_Autore` INT(11) NULL DEFAULT NULL,
    PRIMARY KEY (`ID_Libro`),
    INDEX `ID_Autore` (`ID_Autore` ASC) VISIBLE,
    CONSTRAINT `Libri_ibfk_1` FOREIGN KEY (`ID_Autore`) REFERENCES `Biblioteca`.`Autori` (`ID_Autore`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 6;

-- -----------------------------------------------------
-- Table `Biblioteca`.`Utenti`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Biblioteca`.`Utenti` (
    `ID_Utente` INT(11) NOT NULL AUTO_INCREMENT,
    `Nome` VARCHAR(50) NULL DEFAULT NULL,
    `Cognome` VARCHAR(50) NULL DEFAULT NULL,
    `Email` VARCHAR(100) NULL DEFAULT NULL,
    PRIMARY KEY (`ID_Utente`)
) ENGINE = InnoDB AUTO_INCREMENT = 4;

-- -----------------------------------------------------
-- Table `Biblioteca`.`Prestiti`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Biblioteca`.`Prestiti` (
    `ID_Prestito` INT(11) NOT NULL AUTO_INCREMENT,
    `ID_Libro` INT(11) NULL DEFAULT NULL,
    `ID_Utente` INT(11) NULL DEFAULT NULL,
    `Data_Prestito` DATE NULL DEFAULT NULL,
    `Data_Restituzione` DATE NULL DEFAULT NULL,
    PRIMARY KEY (`ID_Prestito`),
    INDEX `ID_Libro` (`ID_Libro` ASC) VISIBLE,
    INDEX `ID_Utente` (`ID_Utente` ASC) VISIBLE,
    CONSTRAINT `Prestiti_ibfk_1` FOREIGN KEY (`ID_Libro`) REFERENCES `Biblioteca`.`Libri` (`ID_Libro`) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT `Prestiti_ibfk_2` FOREIGN KEY (`ID_Utente`) REFERENCES `Biblioteca`.`Utenti` (`ID_Utente`) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 6;

-- Query 1
CREATE VIEW LibriAutori AS
SELECT
    Libri.Titolo AS TitoloLibri,
    Autori.Nome AS NomeAutore,
    Autori.Cognome AS CognomeAutore
FROM Libri
    JOIN Autori ON Libri.ID_Libro = Autori.ID_Autore;

-- Query 2
SELECT *
FROM LibriAutori
    JOIN Autori
WHERE
    Autori.Nazionalita = 'Italiana';

-- Query 3
CREATE VIEW PrestitiAttivi AS
SELECT
    Prestiti.ID_Prestito,
    Libri.Titolo AS TitoloLibri,
    Libri.Anno_Pubblicazione,
    Utenti.Nome AS NomeUtente,
    Utenti.Cognome AS CognomeUtente,
    Utenti.Email AS EmailUtente
FROM Prestiti
    JOIN Libri ON Prestiti.ID_Libro = Libri.ID_Libro
    JOIN Utenti ON Prestiti.ID_Utente = Utenti.ID_Utente
WHERE
    Data_Restituzione IS NULL;

-- Query 4
SELECT
    NomeUtente,
    CognomeUtente,
    EmailUtente
FROM PrestitiAttivi;

-- Query 5
CREATE VIEW NumeroLibri AS
SELECT Autori.Nome AS NomeAutore, Autori.Cognome AS CognomeAutore, count(Libri.ID_Libro)
FROM Autori
    JOIN Libri ON Autori.ID_Autore = Libri.ID_Autore
GROUP BY
    NomeAutore,
    CognomeAutore;

-- Query 7
CREATE VIEW VistaNumeroPrestitiLibri AS
SELECT Libri.Titolo AS TitoloLibro, COUNT(Prestiti.ID_Prestito) AS NumeroPrestiti
FROM Libri
    LEFT JOIN Prestiti ON Libri.ID_Libro = Prestiti.ID_Libro
GROUP BY
    Libri.Titolo;

-- Query 8
CREATE VIEW VistaNumeroPrestiti AS
SELECT Libri.Titolo AS TitoloLibro, COUNT(Prestiti.ID_Prestito) AS NumeroPrestiti
FROM Libri
    LEFT JOIN Prestiti ON Libri.ID_Libro = Prestiti.ID_Libro
GROUP BY
    Libri.Titolo;