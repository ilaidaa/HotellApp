--SELECT
-- H�mta alla kolumner fr�n tabellen Customer  
SELECT *
FROM Customers;

-- H�mta alla kolumner fr�n tabellen Rooms
SELECT *
FROM Rooms

-- H�mta bara namn och email fr�n Customers tabellen
SELECT Name, Email
FROM Customers;







--WHERE
--H�mta alla kunder med en viss e-postadress:
SELECT *
FROM Customers
WHERE Email = 'alice@hotmail.com';

-- H�mta alla lediga rum:
SELECT *
FROM Rooms
WHERE IsAvailable = 1;

-- H�mta uppgifter f�r rum 101
SELECT *
FROM Rooms
WHERE RoomName = 101;





--ORDER BY
-- Sortera kunder i bokstavsordning A-�
SELECT *
FROM Customers
ORDER BY Name ASC;

-- Sortera kunder i bokstavsordning �-A
SELECT *
FROM Customers
ORDER BY Name DESC;

-- Sortera rum baserat p� rumstyp minst-st�rst:
SELECT *
FROM Rooms
ORDER BY RoomType DESC;