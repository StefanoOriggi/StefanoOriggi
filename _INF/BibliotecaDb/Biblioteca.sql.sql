-- Active: 1730280279384@@127.0.0.1@3306@Biblioteca
-- QUERY 1
CREATE VIEW LibriAutori AS
SELECT
    Libri.Titolo AS TitoloLibro,
    Autori.Nome AS NomeAutore,
    Autori.Cognome AS CognomeAutore
FROM
    Libri
    JOIN Autori ON Libri.ID_Libro = Autori.ID_Autore;

