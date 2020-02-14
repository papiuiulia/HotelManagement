create table [GuestType] 
(
[GuestType] nvarchar(50) NOT NULL,
CONSTRAINT [PK_GuestType] PRIMARY KEY ([GuestType]));



create table [Guest]
(
[GuestID] uniqueidentifier NOT NULL,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[Phone] nvarchar(50) NOT NULL,
[Adresa] nvarchar(50) NOT NULL,
[City] nvarchar(50)NOT NULL,
[Country] nvarchar(50) NOT NULL,
[GuestType] nvarchar(50) NOT NULL,
[AditionalInfo] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Guest] PRIMARY KEY ([GuestID]),
CONSTRAINT [FK_Guest_GuestType] FOREIGN KEY ([GuestType])
     REFERENCES [GuestType]([GuestType]));



create table [RoomType]
(
[RoomTypeID] uniqueidentifier NOT NULL,
[TypeofRoom] nvarchar(50) NOT NULL,
[Price] nvarchar(50) NOT NULL,
CONSTRAINT [PK_RoomType] PRIMARY KEY ([RoomTypeID]));



create table [AcomodationType] 
(
[TypeofAcomodation] nvarchar(50) NOT NULL,
CONSTRAINT [PK_AcomodationType] PRIMARY KEY ([TypeofAcomodation])
)



create table [Room] 
(
[RoomNr] nvarchar(50) NOT NULL,
[RoomTypeID] uniqueidentifier NOT NULL,
[LocationID] uniqueidentifier NOT NULL,
[AditionalInfo] nvarchar(50) NOT NULL,
[TypeofAcomodation] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Room] PRIMARY KEY ([LocationID]),
CONSTRAINT [FK_Room_RoomType] FOREIGN KEY ([RoomTypeID])
     REFERENCES [RoomType]([RoomTypeID]),
CONSTRAINT [FK_Room_AcomodationType] FOREIGN KEY ([TypeofAcomodation])
     REFERENCES [AcomodationType]([TypeofAcomodation]));




create table [ReservationType]
(
[ReservationType] nvarchar(50) NOT NULL,
CONSTRAINT [PK_ReservationType] PRIMARY KEY ([ReservationType])
)




create table [Reservation] 
(
[DateCreation] date,
[CheckIn] date,
[CheckOut] date,
[Adults] nvarchar(50) NOT NULL,
[Children] nvarchar(50) NOT NULL,
[Meal] bit,
[IdGuest] nvarchar(50),
[LocationID] uniqueidentifier NOT NULL,
[ReservationID] nvarchar(50),
[ReservationType] nvarchar(50) NOT NULL,
[GuestID] uniqueidentifier NOT NULL,
[RoomsID] nvarchar(50),
CONSTRAINT [PK_Reservation] PRIMARY KEY ([ReservationID]),
CONSTRAINT [FK_Reservation_ReservationType] FOREIGN KEY ([ReservationType])
     REFERENCES [ReservationType]([ReservationType]),
CONSTRAINT [FK_Reservation_Room] FOREIGN KEY ([LocationID])
     REFERENCES [Room]([LocationID]),
CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY ([GuestID])
     REFERENCES [Guest]([GuestID]));

