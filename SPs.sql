DROP PROCEDURE IF EXISTS dbo.GuestType_ReadById
DROP PROCEDURE IF EXISTS dbo.GuestType_Delete;
DROP PROCEDURE IF EXISTS dbo.GuestType_Update;
GO


CREATE PROCEDURE  dbo.GuestType_ReadByID
(
   @ID uniqueidentifier
)
AS
SELECT * FROM GuestType WHERE ID = @ID
GO

CREATE PROCEDURE dbo.GuestType_Update
(
  @ID uniqueidentifier,
  @Type nvarchar(50)
)
AS
UPDATE dbo.GuestType SET Type = @Type WHERE ID = @ID
GO

CREATE PROCEDURE dbo.GuestType_Delete
(
  @ID uniqueidentifier
)
AS
DELETE FROM GuestType WHERE ID = @ID
GO

DECLARE @ID uniqueidentifier = '00C7F69F-EAC4-3D0B-7F1E-3EA36EA2D0DE'
EXECUTE [dbo].[GuestType_ReadById] @ID
EXECUTE [dbo].[GuestType_Update] @ID, 'Agency'
EXECUTE [dbo].[GuestType_Delete] @ID


DROP PROCEDURE IF EXISTS dbo.Guest_ReadById
DROP PROCEDURE IF EXISTS dbo.Guest_Delete;
DROP PROCEDURE IF EXISTS dbo.Guest_Update;
GO


CREATE PROCEDURE  dbo.Guest_ReadByID
(
   @ID uniqueidentifier
)
AS
SELECT * FROM Guest WHERE ID = @ID
GO

CREATE PROCEDURE dbo.Guest_Update
(
  @ID uniqueidentifier,
  @FirstName nvarchar(50)
)
AS
UPDATE dbo.Guest SET FirstName = @FirstName WHERE ID = @ID
GO

CREATE PROCEDURE dbo.Guest_Delete
(
  @ID uniqueidentifier
)
AS
DELETE FROM Guest WHERE ID = @ID
GO

DECLARE @ID uniqueidentifier = 'C75DDDE3-1E9B-59C7-320E-FBFB9B8CD56F'
EXECUTE [dbo].[Guest_ReadById] @ID
EXECUTE [dbo].[Guest_Update] @ID, 'Michael'
EXECUTE [dbo].[Guest_Delete] @ID


DROP PROCEDURE IF EXISTS dbo.Reservation_ReadById
DROP PROCEDURE IF EXISTS dbo.Reservation_Delete;
DROP PROCEDURE IF EXISTS dbo.Reservation_Update;
GO


CREATE PROCEDURE  dbo.Reservation_ReadByID
(
   @ID nvarchar(50)
)
AS
SELECT * FROM Reservation WHERE ID = @ID
GO

CREATE PROCEDURE dbo.Reservation_Update
(
  @ID nvarchar(50),
  @Meal nvarchar(50)
)
AS
UPDATE dbo.Reservation SET Meal = @Meal WHERE ID = @ID
GO

CREATE PROCEDURE dbo.Reservation_Delete
(
  @ID nvarchar(50)
)
AS
DELETE FROM Reservation WHERE ID = @ID
GO

DECLARE @ID nvarchar(50) = '0856B808-C2E4-B5F3-7AF6-035E096B238A'
EXECUTE [dbo].[Reservation_ReadById] @ID
EXECUTE [dbo].[Reservation_Update] @ID, 'False'
EXECUTE [dbo].[Reservation_Delete] @ID


DELETE From Reservation;
DELETE From Room;




DROP PROCEDURE IF EXISTS dbo.RoomType_ReadById
DROP PROCEDURE IF EXISTS dbo.RoomType_Delete;
DROP PROCEDURE IF EXISTS dbo.RoomType_Update;
GO


CREATE PROCEDURE  dbo.RoomType_ReadByID
(
   @ID uniqueidentifier
)
AS
SELECT * FROM RoomType WHERE ID = @ID
GO

CREATE PROCEDURE dbo.RoomType_Update
(
  @ID uniqueidentifier,
  @Name nvarchar(50)
)
AS
UPDATE dbo.RoomType SET Name = @Name WHERE ID = @ID
GO

CREATE PROCEDURE dbo.RoomType_Delete
(
  @ID uniqueidentifier
)
AS
DELETE FROM RoomType WHERE ID = @ID
GO

DECLARE @ID uniqueidentifier = 'FB5297E5-C754-E8AD-2A61-B4FE918DB967'
EXECUTE [dbo].[RoomType_ReadById] @ID
EXECUTE [dbo].[RoomType_Update] @ID, 'Double'
EXECUTE [dbo].[RoomType_Delete] @ID


DROP PROCEDURE IF EXISTS dbo.Room_ReadById
DROP PROCEDURE IF EXISTS dbo.Room_Delete;
DROP PROCEDURE IF EXISTS dbo.Room_Update;
GO


CREATE PROCEDURE  dbo.Room_ReadByID
(
   @ID uniqueidentifier
)
AS
SELECT * FROM Room WHERE ID = @ID
GO

CREATE PROCEDURE dbo.Room_Update
(
  @ID uniqueidentifier,
  @RoomNr nvarchar(50)
)
AS
UPDATE dbo.Room SET RoomNr = @RoomNr WHERE ID = @ID
GO

CREATE PROCEDURE dbo.Room_Delete
(
  @ID uniqueidentifier
)
AS
DELETE FROM Room WHERE ID = @ID
GO

DECLARE @ID uniqueidentifier = '92253C67-3FE9-B5A3-1815-06370B145B62'
EXECUTE [dbo].[Room_ReadById] @ID
EXECUTE [dbo].[Room_Update] @ID, '24'
EXECUTE [dbo].[Room_Delete] @ID



DROP PROCEDURE IF EXISTS dbo.AccommodationType_ReadById
DROP PROCEDURE IF EXISTS dbo.AccommodationType_Delete;
DROP PROCEDURE IF EXISTS dbo.AccommodationType_Update;
GO


CREATE PROCEDURE  dbo.AccommodationType_ReadByID
(
   @ID uniqueidentifier
)
AS
SELECT * FROM AccommodationType WHERE ID = @ID
GO

CREATE PROCEDURE dbo.AccommodationType_Update
(
  @ID uniqueidentifier,
  @Type nvarchar(50)
)
AS
UPDATE dbo.AccommodationType SET Type = @Type WHERE ID = @ID
GO

CREATE PROCEDURE dbo.AccommodationType_Delete
(
  @ID uniqueidentifier
)
AS
DELETE FROM AccommodationType WHERE ID = @ID
GO

DECLARE @ID uniqueidentifier = '62984B65-907F-BF97-9FB3-366FBACA30D9'
EXECUTE [dbo].[AccommodationType_ReadById] @ID
EXECUTE [dbo].[AccommodationType_Update] @ID, 'All inclusive'
EXECUTE [dbo].[AccommodationType_Delete] @ID



DROP PROCEDURE IF EXISTS dbo.ReservationType_ReadById
DROP PROCEDURE IF EXISTS dbo.ReservationType_Delete;
DROP PROCEDURE IF EXISTS dbo.ReservationType_Update;
GO


CREATE PROCEDURE  dbo.ReservationType_ReadByID
(
   @ID uniqueidentifier
)
AS
SELECT * FROM ReservationType WHERE ID = @ID
GO

CREATE PROCEDURE dbo.ReservationType_Update
(
  @ID uniqueidentifier,
  @Type nvarchar(50)
)
AS
UPDATE dbo.ReservationType SET Type = @Type WHERE ID = @ID
GO

CREATE PROCEDURE dbo.ReservationType_Delete
(
  @ID uniqueidentifier
)
AS
DELETE FROM ReservationType WHERE ID = @ID
GO

DECLARE @ID uniqueidentifier = '1AB4F8C3-3F8D-2ABF-10E7-B24BE5F781AA'
EXECUTE [dbo].[ReservationType_ReadById] @ID
EXECUTE [dbo].[ReservationType_Update] @ID, 'Phone'
EXECUTE [dbo].[ReservationType_Delete] @ID
