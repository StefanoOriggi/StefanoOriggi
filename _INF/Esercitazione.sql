CREATE DATABASE Esercitazione;
USE Esercitazione;

CREATE TABLE passeggeri(
	id_passeggero INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(10),
    cognome VARCHAR(10),
    nazionalita VARCHAR(10),
    tipo_documento ENUM('cartaID', 'passaporto', 'patente'),
    numero_documento VARCHAR(10));
    
CREATE TABLE addetti(
	id_addetto INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(10),
    cognome VARCHAR(10));
    
CREATE TABLE viaggi(
		id_viaggio INT AUTO_INCREMENT PRIMARY KEY,
        DataPartenza DATE NOT NULL,
        nomeAeroporto VARCHAR(10),
        motivo VARCHAR(10),
        id_passeggero INT,
        CONSTRAINT fk_passeggero
        FOREIGN KEY(id_passeggero) REFERENCES passeggeri(id_passeggero)
        ON DELETE CASCADE);
	
CREATE TABLE merci(
		id_merce INT AUTO_INCREMENT PRIMARY KEY,
        categoria VARCHAR(10),
        descrizione VARCHAR(10),
        quantita INT(2),
        id_viaggio INT,
        CONSTRAINT fk_viaggio
        FOREIGN KEY(id_viaggio) REFERENCES viaggi(id_viaggio)
        ON DELETE CASCADE);