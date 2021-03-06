DROP PROCEDURE IF EXISTS dbo.GuestType_ReadById
DROP PROCEDURE IF EXISTS dbo.GuestType_Delete;
DROP PROCEDURE IF EXISTS dbo.GuestType_Update;
GO

CREATE PROCEDURE  dbo.GuestType_ReadByID
(
   @GuestTypeID uniqueidentifier
)
AS
SELECT * FROM GuestType WHERE ID = @GuestTypeID
GO

CREATE PROCEDURE dbo.GuestType_Update
(
  @GuestTypeID uniqueidentifier,
  @GuestType nvarchar(50)
)
AS
UPDATE dbo.GuestType SET Type = @GuestType WHERE ID = @GuestTypeID
GO

CREATE PROCEDURE dbo.GuestType_Delete
(
  @GuestTypeID uniqueidentifier
)
AS
DELETE FROM GuestType WHERE ID = @GuestTypeID
GO

DECLARE @GuestTypeID uniqueidentifier = '00C7F69F-EAC4-3D0B-7F1E-3EA36EA2D0DE'
EXECUTE [dbo].[GuestType_ReadById] @GuestTypeID
EXECUTE [dbo].[GuestType_Update] @GuestTypeID, 'Agency'
EXECUTE [dbo].[GuestType_Delete] @GuestTypeID


DROP PROCEDURE IF EXISTS dbo.Guest_ReadById
DROP PROCEDURE IF EXISTS dbo.Guest_Delete;
DROP PROCEDURE IF EXISTS dbo.Guest_Update;
GO


CREATE PROCEDURE  dbo.Guest_ReadByID
(
   @GuestID uniqueidentifier
)
AS
SELECT * FROM Guest WHERE ID = @GuestID
GO

CREATE PROCEDURE dbo.Guest_Update
(
  @GuestID uniqueidentifier,
  @FirstName nvarchar(50)
)
AS
UPDATE dbo.Guest SET FirstName = @FirstName WHERE ID = @GuestID
GO

CREATE PROCEDURE dbo.Guest_Delete
(
  @GuestID uniqueidentifier
)
AS
DELETE FROM Guest WHERE ID = @GuestID
GO

DECLARE @GuestID uniqueidentifier = 'C75DDDE3-1E9B-59C7-320E-FBFB9B8CD56F'
EXECUTE [dbo].[Guest_ReadById] @GuestID
EXECUTE [dbo].[Guest_Update] @GuestID, 'Michael'
EXECUTE [dbo].[Guest_Delete] @GuestID


DROP PROCEDURE IF EXISTS dbo.Reservation_ReadById
DROP PROCEDURE IF EXISTS dbo.Reservation_Delete;
DROP PROCEDURE IF EXISTS dbo.Reservation_Update;
DROP PROCEDURE IF EXISTS dbo.Reservation_Insert;
GO

CREATE PROCEDURE  dbo.Reservation_ReadByID
(
   @ReservationID nvarchar(50)
)
AS
SELECT * FROM Reservation WHERE ID = @ReservationID
GO

CREATE PROCEDURE dbo.Reservation_Update
(
  @ReservationID nvarchar(50),
  @Meal nvarchar(50)
)
AS
UPDATE dbo.Reservation SET Meal = @Meal WHERE ID = @ReservationID
GO

CREATE PROCEDURE dbo.Reservation_Delete
(
  @ReservationID nvarchar(50)
)
AS
DELETE FROM Reservation WHERE ID = @ReservationID
GO

CREATE PROCEDURE dbo.Reservation_Insert
(
	@ID uniqueidentifier,
	@DateCreation date,
	@CheckIn date,
	@CheckOut date,
	@NumberOfAdults nvarchar(50),
	@NumberOfChildren nvarchar(50),
	@Meal bit,
	@ReservationTypeID uniqueidentifier,
	@GuestID uniqueidentifier,
	@RoomID uniqueidentifier
)
AS
INSERT INTO Reservation(ID, DateCreation, CheckIn, CheckOut, NumberOfAdults, NumberOfChildren, Meal, ReservationTypeID, GuestID, RoomID)
VALUES(@ID, @DateCreation, @CheckIn, @CheckOut, @NumberOfAdults, @NumberOfChildren, @Meal, @ReservationTypeID, @GuestID, @RoomID)
GO

DECLARE @ReservationID nvarchar(50) = '0856B808-C2E4-B5F3-7AF6-035E096B238A'
EXECUTE [dbo].[Reservation_ReadById] @ReservationID
EXECUTE [dbo].[Reservation_Update] @ReservationID, 'False'
EXECUTE [dbo].[Reservation_Delete] @ReservationID


DELETE From Reservation;
DELETE From Room;



DROP PROCEDURE IF EXISTS dbo.RoomType_ReadAll;
DROP PROCEDURE IF EXISTS dbo.RoomType_ReadById;
DROP PROCEDURE IF EXISTS dbo.RoomType_Delete;
DROP PROCEDURE IF EXISTS dbo.RoomType_Update;
GO

CREATE PROCEDURE dbo.RoomType_ReadAll
AS
SELECT * FROM dbo.RoomType;
GO

CREATE PROCEDURE  dbo.RoomType_ReadByID
(
   @RoomTypeID uniqueidentifier
)
AS
SELECT * FROM RoomType WHERE ID = @RoomTypeID
GO

CREATE PROCEDURE dbo.RoomType_Update
(
  @RoomTypeID uniqueidentifier,
  @Name nvarchar(50)
)
AS
UPDATE dbo.RoomType SET Name = @Name WHERE ID = @RoomTypeID
GO

CREATE PROCEDURE dbo.RoomType_Delete
(
  @RoomTypeID uniqueidentifier
)
AS
DELETE FROM RoomType WHERE ID = @RoomTypeID
GO

DECLARE @RoomTypeID uniqueidentifier = 'FB5297E5-C754-E8AD-2A61-B4FE918DB967'
EXECUTE [dbo].[RoomType_ReadById] @RoomTypeID
EXECUTE [dbo].[RoomType_Update] @RoomTypeID, 'Double'
EXECUTE [dbo].[RoomType_Delete] @RoomTypeID

DROP PROCEDURE IF EXISTS dbo.Room_GetAllAvailable;
DROP PROCEDURE IF EXISTS dbo.Room_ReadAll;
DROP PROCEDURE IF EXISTS dbo.Room_ReadById;
DROP PROCEDURE IF EXISTS dbo.Room_Delete;
DROP PROCEDURE IF EXISTS dbo.Room_Update;
GO

CREATE PROCEDURE dbo.Room_GetAllAvailable
AS
SELECT * FROM Room WHERE ID NOT IN (SELECT RoomID FROM dbo.Reservation)
GO

CREATE PROCEDURE dbo.Room_ReadAll
AS
SELECT * FROM Room
GO

CREATE PROCEDURE  dbo.Room_ReadByID
(
   @RoomID uniqueidentifier
)
AS
SELECT * FROM Room WHERE ID = @RoomID
GO

CREATE PROCEDURE dbo.Room_Update
(
  @RoomID uniqueidentifier,
  @RoomNr nvarchar(50)
)
AS
UPDATE dbo.Room SET RoomNr = @RoomNr WHERE ID = @RoomID
GO

CREATE PROCEDURE dbo.Room_Delete
(
  @RoomID uniqueidentifier
)
AS
DELETE FROM Room WHERE ID = @RoomID
GO

DECLARE @RoomID uniqueidentifier = '92253C67-3FE9-B5A3-1815-06370B145B62'
EXECUTE [dbo].[Room_ReadById] @RoomID
EXECUTE [dbo].[Room_Update] @RoomID, '24'
EXECUTE [dbo].[Room_Delete] @RoomID



DROP PROCEDURE IF EXISTS dbo.AccommodationType_ReadById
DROP PROCEDURE IF EXISTS dbo.AccommodationType_Delete;
DROP PROCEDURE IF EXISTS dbo.AccommodationType_Update;
GO


CREATE PROCEDURE  dbo.AccommodationType_ReadByID
(
   @TypeofAccommodationID uniqueidentifier
)
AS
SELECT * FROM AccommodationType WHERE ID = @TypeofAccommodationID
GO

CREATE PROCEDURE dbo.AccommodationType_Update
(
  @TypeofAccommodationID uniqueidentifier,
  @TypeofAccommodation nvarchar(50)
)
AS
UPDATE dbo.AccommodationType SET ID = @TypeofAccommodation WHERE ID = @TypeofAccommodationID
GO

CREATE PROCEDURE dbo.AccommodationType_Delete
(
  @TypeofAccommodationID uniqueidentifier
)
AS
DELETE FROM AccommodationType WHERE ID = @TypeofAccommodationID
GO

DECLARE @TypeofAccommodationID uniqueidentifier = '62984B65-907F-BF97-9FB3-366FBACA30D9'
EXECUTE [dbo].[AccommodationType_ReadById] @TypeofAccommodationID
EXECUTE [dbo].[AccommodationType_Update] @TypeofAccommodationID, 'All inclusive'
EXECUTE [dbo].[AccommodationType_Delete] @TypeofAccommodationID



DROP PROCEDURE IF EXISTS dbo.ReservationType_ReadById
DROP PROCEDURE IF EXISTS dbo.ReservationType_Delete;
DROP PROCEDURE IF EXISTS dbo.ReservationType_Update;
GO


CREATE PROCEDURE  dbo.ReservationType_ReadByID
(
   @ReservationTypeID uniqueidentifier
)
AS
SELECT * FROM ReservationType WHERE ID = @ReservationTypeID
GO

CREATE PROCEDURE dbo.ReservationType_Update
(
  @ReservationTypeID uniqueidentifier,
  @ReservationType nvarchar(50)
)
AS
UPDATE dbo.ReservationType SET Type = @ReservationType WHERE ID = @ReservationTypeID
GO

CREATE PROCEDURE dbo.ReservationType_Delete
(
  @ReservationTypeID uniqueidentifier
)
AS
DELETE FROM ReservationType WHERE ID = @ReservationTypeID
GO

DECLARE @ReservationTypeID uniqueidentifier = '1AB4F8C3-3F8D-2ABF-10E7-B24BE5F781AA'
EXECUTE [dbo].[ReservationType_ReadById] @ReservationTypeID
EXECUTE [dbo].[ReservationType_Update] @ReservationTypeID, 'Phone'
EXECUTE [dbo].[ReservationType_Delete] @ReservationTypeID
