/*!40101 SET NAMES utf8 */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET SQL_NOTES=0 */;
DROP TABLE IF EXISTS conoscenza_lingua;
CREATE TABLE `conoscenza_lingua` (
  `scritto` int(11) NOT NULL,
  `orale` int(11) NOT NULL,
  `matricola_studente` varchar(45) DEFAULT NULL,
  `id_lingua` int(11) DEFAULT NULL,
  KEY `fk_matricola_studente_lingua` (`matricola_studente`),
  KEY `fk_id_lingua` (`id_lingua`),
  CONSTRAINT `fk_id_lingua` FOREIGN KEY (`id_lingua`) REFERENCES `lingua` (`id`),
  CONSTRAINT `fk_matricola_studente_lingua` FOREIGN KEY (`matricola_studente`) REFERENCES `studente` (`matricola`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS corso;
CREATE TABLE `corso` (
  `sigla` varchar(10) NOT NULL,
  `titolo` varchar(45) DEFAULT NULL,
  `id_docente` int(11) DEFAULT NULL,
  PRIMARY KEY (`sigla`),
  KEY `fk_docente` (`id_docente`),
  CONSTRAINT `fk_docente` FOREIGN KEY (`id_docente`) REFERENCES `docente` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS corso_laurea;
CREATE TABLE `corso_laurea` (
  `id` int(11) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `area` int(11) DEFAULT NULL,
  `id_dipartimento` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_dipartimento` (`id_dipartimento`),
  CONSTRAINT `fk_dipartimento` FOREIGN KEY (`id_dipartimento`) REFERENCES `dipartimento` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS dipartimento;
CREATE TABLE `dipartimento` (
  `id` int(11) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS docente;
CREATE TABLE `docente` (
  `id` int(11) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `cognome` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS esame;
CREATE TABLE `esame` (
  `anno` int(11) NOT NULL,
  `voto` int(11) NOT NULL,
  `matricola_studente` varchar(45) DEFAULT NULL,
  `sigla_corso` varchar(10) DEFAULT NULL,
  `Superato` tinyint(1) DEFAULT NULL,
  KEY `fk_matricola_studente_esame` (`matricola_studente`),
  KEY `fk_sigla_corso` (`sigla_corso`),
  CONSTRAINT `fk_matricola_studente_esame` FOREIGN KEY (`matricola_studente`) REFERENCES `studente` (`matricola`),
  CONSTRAINT `fk_sigla_corso` FOREIGN KEY (`sigla_corso`) REFERENCES `corso` (`sigla`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS lingua;
CREATE TABLE `lingua` (
  `id` int(11) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS scuola;
CREATE TABLE `scuola` (
  `id` int(11) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `citta` varchar(45) DEFAULT NULL,
  `titolo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS studente;
CREATE TABLE `studente` (
  `matricola` varchar(45) NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `cognome` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `data_nascita` datetime DEFAULT NULL,
  `comune_nascita` varchar(45) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `id_laurea` int(11) DEFAULT NULL,
  PRIMARY KEY (`matricola`),
  KEY `fk_laurea` (`id_laurea`),
  CONSTRAINT `fk_laurea` FOREIGN KEY (`id_laurea`) REFERENCES `corso_laurea` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

DROP TABLE IF EXISTS titolo_studio;
CREATE TABLE `titolo_studio` (
  `id_scuola` int(11) NOT NULL,
  `voto` int(11) NOT NULL,
  `matricola_studente` varchar(45) DEFAULT NULL,
  KEY `fk_matricola_studente` (`matricola_studente`),
  CONSTRAINT `fk_matricola_studente` FOREIGN KEY (`matricola_studente`) REFERENCES `studente` (`matricola`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

INSERT INTO conoscenza_lingua(scritto,orale,matricola_studente,id_lingua) VALUES('80','85','''S12345''','1'),('75','70','''S67890''','2');

INSERT INTO corso(sigla,titolo,id_docente) VALUES('''INF01''','''Programmazione''','1'),('''LET01''','''Letteratura Italiana''','2');

INSERT INTO corso_laurea(id,nome,area,id_dipartimento) VALUES('1','''Ingegneria Informatica''','1','1'),('2','''Lettere Moderne''','2','2');

INSERT INTO dipartimento(id,nome) VALUES('1','''Ingegneria Informatica'''),('2','''Lettere Moderne''');

INSERT INTO docente(id,nome,cognome,email) VALUES('1','''Mario''','''Rossi''','''RossiMario@gmail.com'''),('2','''Anna''','''Bianchi''','''anna.bianchi@universita.it''');

INSERT INTO esame(anno,voto,matricola_studente,sigla_corso,Superato) VALUES('2021','28','''S12345''','''INF01''','NULL'),('2022','30','''S67890''','''LET01''','NULL'),('2021','26','''S12345''','''INF01''','NULL'),('2022','12','''S67890''','''LET01''','NULL');

INSERT INTO lingua(id,nome) VALUES('1','''Inglese'''),('2','''Francese''');

INSERT INTO scuola(id,nome,citta,titolo) VALUES('1','''Liceo Scientifico''','''Roma''','''Diploma Scientifico'''),('2','''Liceo Classico''','''Milano''','''Diploma Classico''');

INSERT INTO studente(matricola,nome,cognome,email,data_nascita,comune_nascita,telefono,id_laurea) VALUES('''S12345''','''Luca''','''Verdi''','''luca.verdi@studenti.it''','''2000-01-15 00:00:00''','''Napoli''','''3331234567''','1'),('''S67890''','''Giulia''','''Neri''','''giulia.neri@studenti.it''','''1999-05-22 00:00:00''','''Roma''','''3339876543''','2');
INSERT INTO titolo_studio(id_scuola,voto,matricola_studente) VALUES('1','90','''S12345'''),('2','85','''S67890''');