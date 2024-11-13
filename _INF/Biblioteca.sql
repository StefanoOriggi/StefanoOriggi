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
    CONSTRAINT `Libri_ibfk_1` FOREIGN KEY (`ID_Autore`) REFERENCES `Biblioteca`.`Autori` (`ID_Autore`) on delete cascade on update cascade
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
    CONSTRAINT `Prestiti_ibfk_1` FOREIGN KEY (`ID_Libro`) REFERENCES `Biblioteca`.`Libri` (`ID_Libro`) on delete cascade on update cascade,
    CONSTRAINT `Prestiti_ibfk_2` FOREIGN KEY (`ID_Utente`) REFERENCES `Biblioteca`.`Utenti` (`ID_Utente`) on update cascade on delete cascade
) ENGINE = InnoDB AUTO_INCREMENT = 6;

-- Query 1
create view LibriAutori as
select
    Libri.Titolo as TitoloLibri,
    Autori.Nome as NomeAutore,
    Autori.Cognome as CognomeAutore
from
    Libri
    join Autori on Libri.ID_Libro = Autori.ID_Autore;

-- Query 2
select
    *
from
    LibriAutori
    join Autori
where
    Autori.Nazionalita = 'Italiana';

-- Query 3
create view PrestitiAttivi as
select
    Prestiti.ID_Prestito,
    Libri.Titolo as TitoloLibri,
    Libri.Anno_Pubblicazione,
    Utenti.Nome as NomeUtente,
    Utenti.Cognome as CognomeUtente,
    Utenti.Email as EmailUtente
from
    Prestiti
    join Libri on Prestiti.ID_Libro = Libri.ID_Libro
    join Utenti on Prestiti.ID_Utente = Utenti.ID_Utente
where
    Data_Restituzione is null;

-- Query 4
select
    NomeUtente,
    CognomeUtente,
    EmailUtente
from
    PrestitiAttivi;

-- Query 5
create view NumeroLibri as
select
    Autori.Nome as NomeAutore,
    Autori.Cognome as CognomeAutore,
    count(Libri.ID_Libro)
from
    Autori
    join Libri on Autori.ID_Autore = Libri.ID_Autore
group by
    NomeAutore,
    CognomeAutore;

-- Query 7
CREATE VIEW VistaNumeroPrestitiLibri AS
SELECT
    Libri.Titolo as TitoloLibro,
    COUNT(Prestiti.ID_Prestito) as NumeroPrestiti
FROM
    Libri
    LEFT JOIN Prestiti on Libri.ID_Libro = Prestiti.ID_Libro
GROUP BY
    Libri.Titolo;

-- Query 8
CREATE VIEW VistaNumeroPrestiti AS
SELECT
    Libri.Titolo as TitoloLibro,
    COUNT(Prestiti.ID_Prestito) as NumeroPrestiti
FROM
    Libri
    LEFT JOIN Prestiti on Libri.ID_Libro = Prestiti.ID_Libro
GROUP BY
    Libri.Titolo;