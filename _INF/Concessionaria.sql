-- Active: 1731527324137@@127.0.0.1@3306
CREATE DATABASE Concessionaria;

USE Concessionaria;

CREATE TABLE Clienti (
    clienteID INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    cognome VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    telefono VARCHAR(20)
);

CREATE TABLE Automobili (
    autoID INT PRIMARY KEY AUTO_INCREMENT,
    marca VARCHAR(100) NOT NULL,
    modello VARCHAR(100) NOT NULL,
    anno INT,
    prezzo DECIMAL(10, 2)
);

CREATE TABLE Vendite (
    venditaID INT PRIMARY KEY AUTO_INCREMENT,
    clienteID INT,
    autoID INT,
    dataVendita DATE,
    FOREIGN KEY (clienteID) REFERENCES Clienti (clienteID),
    FOREIGN KEY (autoID) REFERENCES Automobili (autoID)
);

CREATE TABLE Servizi (
    servizioID INT PRIMARY KEY AUTO_INCREMENT,
    descrizione VARCHAR(255) NOT NULL,
    prezzo DECIMAL(10, 2)
);

CREATE TABLE Prenotazioni (
    prenotazioneID INT PRIMARY KEY AUTO_INCREMENT,
    clienteID INT,
    servizioID INT,
    dataPrenotazione DATE,
    FOREIGN KEY (clienteID) REFERENCES Clienti (clienteID),
    FOREIGN KEY (servizioID) REFERENCES Servizi (servizioID)
);

-- QUERY 1
SELECT *
FROM Clienti c
WHERE
    c.clienteID IN (
        SELECT v.clienteID
        FROM Vendite v
            JOIN Automobili a ON v.autoID = a.autoID
        WHERE
            a.prezzo > 20000
    );

-- QUERY 2
SELECT *
FROM Servizi s
WHERE
    s.prezzo > (
        SELECT AVG(prezzo)
        FROM Servizi
    );

-- QUERY 3
SELECT DISTINCT
    c.*
FROM Clienti c
WHERE
    c.clienteID IN (
        SELECT p.clienteID
        FROM Prenotazioni p
        WHERE
            p.servizioID IN (
                SELECT s.servizioID
                FROM Servizi s
                WHERE
                    s.descrizione = 'cambio olio'
            )
    );

-- QUERY 4
SELECT a.*
FROM Automobili a
    JOIN Vendite v ON a.autoID = v.autoID
WHERE
    a.prezzo > (
        SELECT AVG(a2.prezzo)
        FROM Automobili a2
            JOIN Vendite v2 ON a2.autoID = v2.autoID
);

-- QUERY 5
SELECT *
FROM Clienti c
WHERE
    c.clienteID NOT IN(
        SELECT p.clienteID
        FROM Prenotazioni p
    );

-- QUERY 6
SELECT DISTINCT
    *
FROM Servizi s
    JOIN Prenotazioni p ON s.servizioID = p.servizioID
WHERE
    p.clienteID IN (
        SELECT v.clienteID
        FROM Vendite v
    );

-- QUERY 7
SELECT DISTINCT
    *
FROM Automobili a
    JOIN Vendite v ON a.autoID = v.autoID
WHERE
    v.clienteID IN (
        SELECT p.clienteID
        FROM Prenotazioni p
    );