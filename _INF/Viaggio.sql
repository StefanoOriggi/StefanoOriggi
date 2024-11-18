-- QUERY 1
SELECT *
FROM `Destinazioni`
JOIN `Viaggi` USING(`IDDestinazione`);

-- QUERY 2
SELECT NomeDestinazione
FROM `Destinazioni`
WHERE `IDDestinazione` in(
    SELECT `IDDestinazione`
    FROM `Viaggi`
);

-- QUERY 3

