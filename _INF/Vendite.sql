CREATE DATABASE Vendite;
USE Vendite;

CREATE TABLE Cliente(
	cod_cliente INT(7) PRIMARY KEY,
    cognome VARCHAR(10) NOT NULL,
    citta VARCHAR(10) NOT NULL);

CREATE TABLE Categoria(
	cod_categoria INT(7) PRIMARY KEY,
    nome VARCHAR(10) NOT NULL);
    
CREATE TABLE Prodotto(
	cod_prodotto INT(7) PRIMARY KEY,
    nome VARCHAR(10) NOT NULL,
    prezzo DECIMAL(5,2) NOT NULL,
    sconto TINYINT(3),
    cod_categoria INT(7),
    FOREIGN KEY(cod_categoria) REFERENCES Categoria(cod_categoria));
    
CREATE TABLE Acquisto(
	id_acquisto INT AUTO_INCREMENT PRIMARY KEY,
    cod_cliente INT(7),
    FOREIGN KEY(cod_cliente) REFERENCES Cliente(cod_cliente),
	cod_prodotto INT(7),
    FOREIGN KEY(cod_prodotto) REFERENCES Prodotto(cod_prodotto));

INSERT INTO Cliente(cod_cliente,cognome,citta)
VALUES
	(1,'cognome1','citta1'),
    (2,'cognome2','citta2'),
    (3,'cognome3','citta3');

INSERT INTO Categoria(cod_categoria,nome)
VALUES
	(1,'nome1'),
    (2,'nome2'),
    (3,'nome3');

INSERT INTO Prodotto(cod_prodotto,nome,prezzo,sconto,cod_categoria)
VALUES
	(1,'nome1',100.00,10,1),
    (2,'nome2',101.01,11,2),
    (3,'nome3',102.02,12,3);

INSERT INTO Acquisto(cod_cliente, cod_prodotto)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (1, 2),
    (2, 1);

SELECT * FROM Acquisto;
    