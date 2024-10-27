-- Active: 1729347607622@@127.0.0.1@3306@classicmodels
-- Active: 1729332167935@@127.0.0.1@3306@dbEsami
CREATE TABLE scuola (
    id INT PRIMARY KEY,
    nome VARCHAR(45),
    citta VARCHAR(45),
    titolo VARCHAR(45)
);

CREATE TABLE dipartimento (id INT PRIMARY KEY, nome VARCHAR(45));

CREATE TABLE docente (
    id INT PRIMARY KEY,
    nome VARCHAR(45),
    cognome VARCHAR(45),
    email VARCHAR(45)
);

CREATE TABLE lingua (id INT PRIMARY KEY, nome VARCHAR(45));

CREATE TABLE corso_laurea (
    id INT PRIMARY KEY,
    nome VARCHAR(45),
    area INT,
    id_dipartimento INT,
    CONSTRAINT fk_dipartimento FOREIGN KEY (id_dipartimento) REFERENCES dipartimento (id)
);

CREATE TABLE studente (
    matricola VARCHAR(45) PRIMARY KEY,
    nome VARCHAR(45),
    cognome VARCHAR(45),
    email VARCHAR(45),
    data_nascita DATETIME,
    comune_nascita VARCHAR(45),
    telefono VARCHAR(45),
    id_laurea INT,
    CONSTRAINT fk_laurea FOREIGN KEY (id_laurea) REFERENCES corso_laurea (id)
);

CREATE TABLE titolo_studio (
    id_scuola INT NOT NULL,
    voto INT NOT NULL,
    matricola_studente VARCHAR(45),
    CONSTRAINT fk_matricola_studente FOREIGN KEY (matricola_studente) REFERENCES studente (matricola)
);

CREATE TABLE conoscenza_lingua (
    scritto INT NOT NULL,
    orale INT NOT NULL,
    matricola_studente VARCHAR(45),
    CONSTRAINT fk_matricola_studente_lingua FOREIGN KEY (matricola_studente) REFERENCES studente (matricola),
    id_lingua INT,
    CONSTRAINT fk_id_lingua FOREIGN KEY (id_lingua) REFERENCES lingua (id)
);

CREATE TABLE corso (
    sigla VARCHAR(10) PRIMARY KEY,
    titolo VARCHAR(45),
    ssd VARCHAR(10),
    id_docente INT,
    CONSTRAINT fk_docente FOREIGN KEY (id_docente) REFERENCES docente (id)
);

CREATE TABLE esame (
    anno INT NOT NULL,
    voto INT NOT NULL,
    matricola_studente VARCHAR(45),
    sigla_corso VARCHAR(10),
    CONSTRAINT fk_matricola_studente_esame FOREIGN KEY (matricola_studente) REFERENCES studente (matricola),
    CONSTRAINT fk_sigla_corso FOREIGN KEY (sigla_corso) REFERENCES corso (sigla)
);

CREATE USER 'admin' @'%' IDENTIFIED BY 'admin';

GRANT ALL PRIVILEGES ON dbEsami.* TO 'admin' @'%'; 

USE dbEsami;

INSERT INTO
    scuola (id, nome, citta, titolo)
VALUES
    (
        1,
        'Liceo Scientifico',
        'Roma',
        'Diploma Scientifico'
    ),
    (
        2,
        'Liceo Classico',
        'Milano',
        'Diploma Classico'
    );

INSERT INTO
    dipartimento (id, nome)
VALUES
    (1, 'Ingegneria Informatica'),
    (2, 'Lettere Moderne');

INSERT INTO
    docente (id, nome, cognome, email)
VALUES
    (
        1,
        'Mario',
        'Rossi',
        'mario.rossi@universita.it'
    ),
    (
        2,
        'Anna',
        'Bianchi',
        'anna.bianchi@universita.it'
    );

INSERT INTO
    lingua (id, nome)
VALUES
    (1, 'Inglese'),
    (2, 'Francese');

INSERT INTO
    corso_laurea (
        id,
        nome,
        area,
        id_dipartimento
    )
VALUES
    (
        1,
        'Ingegneria Informatica',
        1,
        1
    ),
    (2, 'Lettere Moderne', 2, 2);

INSERT INTO
    studente (
        matricola,
        nome,
        cognome,
        email,
        data_nascita,
        comune_nascita,
        telefono,
        id_laurea
    )
VALUES
    (
        'S12345',
        'Luca',
        'Verdi',
        'luca.verdi@studenti.it',
        '2000-01-15',
        'Napoli',
        '3331234567',
        1
    ),
    (
        'S67890',
        'Giulia',
        'Neri',
        'giulia.neri@studenti.it',
        '1999-05-22',
        'Roma',
        '3339876543',
        2
    );

INSERT INTO
    titolo_studio (
        id_scuola,
        voto,
        matricola_studente
    )
VALUES
    (1, 90, 'S12345'),
    (2, 85, 'S67890');

INSERT INTO
    conoscenza_lingua (
        scritto,
        orale,
        matricola_studente,
        id_lingua
    )
VALUES
    (80, 85, 'S12345', 1),
    (75, 70, 'S67890', 2);

INSERT INTO
    corso (
        sigla,
        titolo,
        ssd,
        id_docente
    )
VALUES
    (
        'INF01',
        'Programmazione',
        'INF01',
        1
    ),
    (
        'LET01',
        'Letteratura Italiana',
        'LET01',
        2
    );

INSERT INTO
    esame (
        anno,
        voto,
        matricola_studente,
        sigla_corso
    )
VALUES
    (2021, 26, 'S12345', 'INF01'),
    (2022, 12, 'S67890', 'LET01');

-- QUERY1
SELECT
    studente.nome,
    studente.cognome
FROM
    studente
WHERE
    studente.data_nascita BETWEEN '2000-01-01'
    AND '2003-12-31';

-- QUERY2
SELECT
    scuola.nome
FROM
    scuola
WHERE
    scuola.citta LIKE 'M%';

--QUERY3
SELECT
    *
FROM
    esame
ORDER BY
    anno,
    voto DESC;

--QUERY4
UPDATE
    docente
SET
    email = 'RossiMario@gmail.com'
WHERE
    nome = 'Mario'
    AND cognome = 'Rossi';

--QUERY5
DELETE FROM
    esame
WHERE
    voto BETWEEN 18
    AND 20;

--QUERY6
ALTER TABLE
    esame
ADD
    COLUMN Superato BOOL; --AFTER 'nome colonna' per inserire in pos specifica

--QUERY7
ALTER TABLE corso 
DROP COLUMN ssd;


CREATE USER 'segrataria'@'localhost' IDENTIFIED BY 'segrataria';

GRANT SELECT ON dbEsami.* TO 'segrataria'@localhost;
GRANT INSERT ON dbEsami.* TO 'segrataria'@localhost;
GRANT UPDATE ON dbEsami.* TO 'segrataria'@localhost;

CREATE USER 'guest'@'%' IDENTIFIED BY 'guest';

GRANT SELECT ON dbEsami.studente TO 'guest'@'%';
GRANT SELECT ON dbEsami.titolo_studio TO 'guest' @'%';
GRANT SELECT ON dbEsami.scuola TO 'guest' @'%';

CREATE ROLE esami;
GRANT SELECT, INSERT, UPDATE ON dbEsami.esame TO esami;

CREATE ROLE modifica;
GRANT SELECT, UPDATE ON dbEsami.* TO modifica;

CREATE USER utente1,utente2,utente3 IDENTIFIED BY 'prova';

GRANT esami to utente1,utente2;
GRANT modifica to utente3;
