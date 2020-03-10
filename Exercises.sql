select FirstName, LastName
from Guest
where FirstName = 'Ann'and LastName = 'Doe'

SELECT r.RoomID,
	   g.LastName,
	   g.ID
FROM Reservation r
	INNER JOIN Room ro ON r.RoomID = ro.ID
	INNER JOIN Guest g ON g.ID = r.GuestID
WHERE g.Country = 'France'


SELECT Name, Price
From RoomType
ORDER BY Price asc

SELECT FirstName, LastName
From Guest
WHERE Country = 'USA'
GROUP BY FirstName, LastName

SELECT TOP 3 * FROM Guest;
