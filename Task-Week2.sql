DROP FUNCTION IF EXISTS dbo.Guest_GetNoOfRoom

-- create stored procedure
DROP PROCEDURE IF EXISTS dbo.Guest_ReadById;
GO

CREATE PROCEDURE dbo.Guest_ReadById 
(
	@ID uniqueidentifier
)
AS
BEGIN
	SELECT  g.FirstName,
			g.LastName,
		   --(ro.RoomNr)
			COUNT(ro.ID) as NoOfRoom
	FROM Guest g
		INNER JOIN Reservation r ON r.GuestID = g.ID
		INNER JOIN Room ro ON ro.ID = r.RoomID
	GROUP BY g.ID, g.LastName, g.FirstName
	HAVING g.ID = @ID
	END
GO

--declarations
DECLARE @ID uniqueidentifier = 'F22F1530-A563-30E9-F475-32E75369D4A0'
EXECUTE dbo.[Guest_ReadById] @ID


--function
DROP FUNCTION IF EXISTS [dbo].[Guest_GetNoOfRoom]
GO

CREATE FUNCTION [dbo].[Guest_GetNoOfRoom]
(
	@ID uniqueidentifier
)
RETURNS int
AS
BEGIN
	DECLARE @result int

	SELECT @result = COUNT(ro.ID)
	FROM Guest g
		INNER JOIN Reservation r ON r.GuestID = g.ID
		INNER JOIN Room ro ON ro.ID = r.RoomID
	WHERE g.ID = @ID
	RETURN @result
END
GO


DROP PROCEDURE IF EXISTS dbo.Guest_ReadById_With_Procedure
GO

--call function from within SP
CREATE PROCEDURE [dbo].[Guest_ReadById_With_Procedure] 
(
	@ID uniqueidentifier
)
AS
BEGIN
	SELECT g.ID,
			g.LastName,
			dbo.Guest_GetNoOfRoom(ID) as NoOfRoom
	FROM Guest g
	WHERE g.ID = @ID
END
GO


-- table valued function
DROP FUNCTION IF EXISTS [dbo].[Guest_GetRoomforGuest]

CREATE FUNCTION [dbo].[Guest_GetRoomforGuest]
(
    @ID uniqueidentifier
)
RETURNS TABLE
AS
RETURN
    SELECT 
      g.[FirstName],
	  g.[LastName],
	  ro.[RoomNr]
	  FROM Guest g 
	  INNER JOIN Reservation r ON r.GuestID = g.ID
	  INNER JOIN Room ro ON ro.ID = r.RoomID
    WHERE
        g.ID = @ID
GO

select * from dbo.Guest_GetRoomforGuest('F22F1530-A563-30E9-F475-32E75369D4A0')


--views
DROP VIEW if EXISTS [dbo].[GuestAndRoom]

CREATE VIEW [dbo].[GuestAndRoom]
AS
SELECT g.ID,
		g.LastName,
		COUNT(r.ID) as NoOfRoom
FROM Guest g
	LEFT JOIN Reservation r ON r.GuestID = g.ID
	LEFT JOIN Room ro ON ro.ID = r.RoomID
GROUP BY g.ID, g.LastName
GO

SELECT * from [dbo].[GuestAndRoom]
