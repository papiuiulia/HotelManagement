create table [GuestType] 
(
[GuestTypeID] uniqueidentifier NOT NULL,
[GuestType] nvarchar(50) NOT NULL,
CONSTRAINT [PK_GuestType] PRIMARY KEY ([GuestTypeID]));



create table [Guest]
(
[GuestID] uniqueidentifier NOT NULL,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[Phone] nvarchar(50) NOT NULL,
[Address] nvarchar(50) NOT NULL,
[City] nvarchar(50)NOT NULL,
[Country] nvarchar(50) NOT NULL,
[GuestTypeID] uniqueidentifier NOT NULL,
[AditionalInfo] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Guest] PRIMARY KEY ([GuestID]),
CONSTRAINT [FK_Guest_GuestType] FOREIGN KEY ([GuestTypeID])
     REFERENCES [GuestType]([GuestTypeID]));



create table [RoomType]
(
[RoomTypeID] uniqueidentifier NOT NULL,
[Name] nvarchar(50) NOT NULL,
[Price] nvarchar(50) NOT NULL,
CONSTRAINT [PK_RoomType] PRIMARY KEY ([RoomTypeID]));



create table [AccommodationType] 
(
[TypeofAccommodationID] uniqueidentifier NOT NULL,
[TypeofAccommodation] nvarchar(50) NOT NULL,
CONSTRAINT [PK_AccommodationType] PRIMARY KEY ([TypeofAccommodationID])
)



create table [Room] 
(
[RoomNr] nvarchar(50) NOT NULL,
[RoomTypeID] uniqueidentifier NOT NULL,
[RoomID] uniqueidentifier NOT NULL,
[AditionalInfo] nvarchar(50) NOT NULL,
[TypeofAccommodationID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_Room] PRIMARY KEY ([RoomID]),
CONSTRAINT [FK_Room_RoomType] FOREIGN KEY ([RoomTypeID])
     REFERENCES [RoomType]([RoomTypeID]),
CONSTRAINT [FK_Room_AccommodationType] FOREIGN KEY ([TypeofAccommodationID])
     REFERENCES [AccommodationType]([TypeofAccommodationID]));




create table [ReservationType]
(
[ReservationTypeID] uniqueidentifier NOT NULL,
[ReservationType] nvarchar(50) NOT NULL,
CONSTRAINT [PK_ReservationType] PRIMARY KEY ([ReservationTypeID])
)




create table [Reservation] 
(
[DateCreation] date,
[CheckIn] date,
[CheckOut] date,
[NumberOfAdults] nvarchar(50) NOT NULL,
[NumberOfChildren] nvarchar(50) NOT NULL,
[Meal] bit,
[ReservationID] nvarchar(50),
[ReservationTypeID] uniqueidentifier NOT NULL,
[GuestID] uniqueidentifier NOT NULL,
[RoomID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_Reservation] PRIMARY KEY ([ReservationID]),
CONSTRAINT [FK_Reservation_ReservationType] FOREIGN KEY ([ReservationTypeID])
     REFERENCES [ReservationType]([ReservationTypeID]),
CONSTRAINT [FK_Reservation_Room] FOREIGN KEY ([RoomID])
     REFERENCES [Room]([RoomID]),
CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY ([GuestID])
     REFERENCES [Guest]([GuestID]));
