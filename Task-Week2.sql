-- create stored procedure
DROP PROCEDURE IF EXISTs dbo.Guest_ReadById;
GO

CREATE PROCEDURE dbo.Guest_ReadById 
(
	@GuestID uniqueidentifier
)
AS
BEGIN
	SELECT  g.FirstName,
			g.LastName,
		   --(ro.RoomNr)
			COUNT(ro.RoomID) as NoOfRoom
	FROM Guest g
		INNER JOIN Reservation r ON r.GuestID = g.GuestID
		INNER JOIN Room ro ON ro.RoomID = r.RoomID
	GROUP BY g.GuestID, g.LastName, g.FirstName
	HAVING g.GuestID = @GuestID
	END
GO

--declarations
DECLARE @GuestID uniqueidentifier = 'E5C24E7A-A819-1E62-E37C-0700402A1B8C'
EXECUTE dbo.[Guest_ReadById] @GuestID


--function
CREATE FUNCTION dbo.Guest_GetNoOfRoom
(
	@GuestID uniqueidentifier
)
RETURNS int
AS
BEGIN
	DECLARE @result int

	SELECT @result = COUNT(ro.RoomID)
	FROM Guest g
		INNER JOIN Reservation r ON r.GuestID = g.GuestID
		INNER JOIN Room ro ON ro.RoomID = r.RoomID
	WHERE g.GuestID = @GuestID
	RETURN @result
END
GO


--call function from within SP
CREATE PROCEDURE [dbo].[Guest_ReadById_With_Function] 
(
	@GuestID uniqueidentifier
)
AS
BEGIN
	SELECT g.GuestID,
			g.LastName,
			dbo.Guest_GetNoOfRoom(GuestID) as NoOfRoom
	FROM Guest g
	WHERE g.GuestID = @GuestID
END
GO


-- table valued function
CREATE FUNCTION dbo.Guest_GetRoomforGuest (
    @GuestID uniqueidentifier
)
RETURNS TABLE
AS
RETURN
    SELECT 
      g.[FirstName],
	  g.[LastName],
	  ro.[RoomNr]
	  FROM Guest g 
	  INNER JOIN Reservation r ON r.GuestID = g.GuestID
	  INNER JOIN Room ro ON ro.RoomID = r.RoomID
    WHERE
        g.GuestID = @GuestID

select * from dbo.Guest_GetRoomforGuest('E5C24E7A-A819-1E62-E37C-0700402A1B8C')


--views
CREATE VIEW [dbo].[GuestAndRoom]
AS
SELECT g.GuestID,
		g.LastName,
		COUNT(r.RoomID) as NoOfRoom
FROM Guest g
	LEFT JOIN Reservation r ON r.GuestID = g.GuestID
	LEFT JOIN Room ro ON ro.RoomID = r.RoomID
GROUP BY g.GuestID, g.LastName
GO

--SELECT * from [dbo].[GuestAndRoom]
