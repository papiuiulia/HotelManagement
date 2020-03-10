create table [GuestType] 
(
[ID] uniqueidentifier NOT NULL,
[Type] nvarchar(50) NOT NULL,
CONSTRAINT [PK_GuestType] PRIMARY KEY ([ID]));



create table [Guest]
(
[ID] uniqueidentifier NOT NULL,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[Phone] nvarchar(50) NOT NULL,
[Address] nvarchar(50) NOT NULL,
[City] nvarchar(50)NOT NULL,
[Country] nvarchar(50) NOT NULL,
[GuestTypeID] uniqueidentifier NOT NULL,
[AditionalInfo] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Guest] PRIMARY KEY ([ID]),
CONSTRAINT [FK_Guest_GuestType] FOREIGN KEY ([GuestTypeID])
     REFERENCES [GuestType]([ID]));



create table [RoomType]
(
[ID] uniqueidentifier NOT NULL,
[Name] nvarchar(50) NOT NULL,
[Price] nvarchar(50) NOT NULL,
CONSTRAINT [PK_RoomType] PRIMARY KEY ([ID]));



create table [AccommodationType] 
(
[ID] uniqueidentifier NOT NULL,
[Type] nvarchar(50) NOT NULL,
CONSTRAINT [PK_AccommodationType] PRIMARY KEY ([ID])
)



create table [Room] 
(
[ID] uniqueidentifier NOT NULL,
[RoomNr] nvarchar(50) NOT NULL,
[RoomTypeID] uniqueidentifier NOT NULL,
[AditionalInfo] nvarchar(50) NOT NULL,
[TypeofAccommodationID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_Room] PRIMARY KEY ([ID]),
CONSTRAINT [FK_Room_RoomType] FOREIGN KEY ([RoomTypeID])
     REFERENCES [RoomType]([ID]),
CONSTRAINT [FK_Room_AccommodationType] FOREIGN KEY ([TypeofAccommodationID])
     REFERENCES [AccommodationType]([ID]));




create table [ReservationType]
(
[ID] uniqueidentifier NOT NULL,
[Type] nvarchar(50) NOT NULL,
CONSTRAINT [PK_ReservationType] PRIMARY KEY ([ID])
)




create table [Reservation] 
(
[ID] nvarchar(50),
[DateCreation] date,
[CheckIn] date,
[CheckOut] date,
[NumberOfAdults] nvarchar(50) NOT NULL,
[NumberOfChildren] nvarchar(50) NOT NULL,
[Meal] bit,
[ReservationTypeID] uniqueidentifier NOT NULL,
[GuestID] uniqueidentifier NOT NULL,
[RoomID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_Reservation] PRIMARY KEY ([ID]),
CONSTRAINT [FK_Reservation_ReservationType] FOREIGN KEY ([ReservationTypeID])
     REFERENCES [ReservationType]([ID]),
CONSTRAINT [FK_Reservation_Room] FOREIGN KEY ([RoomID])
     REFERENCES [Room]([ID]),
CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY ([GuestID])
     REFERENCES [Guest]([ID]));
