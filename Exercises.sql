select FirstName, LastName
from Guest
where FirstName = 'Ann'and LastName = 'Doe'

SELECT r.LocationID,
	   g.LastName,
	   g.GuestID
FROM Reservation r
	INNER JOIN Room ro ON r.LocationID = ro.LocationID
	INNER JOIN Guest g ON g.GuestID = r.GuestID
WHERE g.Country = 'France'


SELECT TypeofRoom, Price
From RoomType
ORDER BY Price asc

SELECT FirstName, LastName
From Guest
WHERE Country = 'USA'
GROUP BY FirstName, LastName

SELECT TOP 3 * FROM Guest;
