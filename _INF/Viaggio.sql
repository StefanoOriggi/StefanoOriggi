-- QUERY 1
SELECT * FROM Destinazioni JOIN Viaggi USING (IDDestinazione);

-- QUERY 2
SELECT *
FROM Destinazioni
WHERE
    IDDestinazione NOT IN(
        SELECT IDDestinazione
        FROM Viaggi
    );

-- QUERY 3
SELECT `Clienti`.`Nome`
FROM Clienti
    JOIN `Prenotazioni` USING (`IDCliente`)
HAVING
    COUNT(IDViaggio) > 1;

-- QUERY 4
SELECT Destinazioni.NomeDestinazione
FROM Destinazioni
WHERE
    IDDestinazione NOT IN(
        SELECT Viaggi.IDDestinazione
        FROM
            Prenotazioni
            JOIN Recensioni USING (IDViaggio)
            JOIN Viaggi USING (IDViaggio)
    );

-- QUERY 5
SELECT Nome
FROM `Clienti`
WHERE
    `Nome` NOT IN(
        SELECT `IDCliente`
        FROM `Prenotazioni`
            JOIN `Viaggi` USING (`IDViaggio`)
        WHERE
            `IDDestinazione` = 'Riccione'
    );

-- QUERY 6
SELECT `Clienti`.`Nome`, COUNT(`Prenotazioni`.`IDPrenotazione`)
FROM `Clienti`
    LEFT JOIN `Prenotazioni` USING (`IDCliente`)
GROUP BY `Clienti`.`Nome`;

-- QUERY 7
