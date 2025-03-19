--SELECT
-- Hämta alla kolumner från tabellen Customer  
SELECT *
FROM Customers;

-- Hämta alla kolumner från tabellen Rooms
SELECT *
FROM Rooms

-- Hämta bara namn och email från Customers tabellen
SELECT Name, Email
FROM Customers;







--WHERE
--Hämta alla kunder med en viss e-postadress:
SELECT *
FROM Customers
WHERE Email = 'alice@hotmail.com';

-- Hämta alla lediga rum:
SELECT *
FROM Rooms
WHERE IsAvailable = 1;

-- Hämta uppgifter för rum 101
SELECT *
FROM Rooms
WHERE RoomName = 101;





--ORDER BY
-- Sortera kunder i bokstavsordning A-Ö
SELECT *
FROM Customers
ORDER BY Name ASC;

-- Sortera kunder i bokstavsordning Ö-A
SELECT *
FROM Customers
ORDER BY Name DESC;

-- Sortera rum baserat på rumstyp minst-störst:
SELECT *
FROM Rooms
ORDER BY RoomType DESC;