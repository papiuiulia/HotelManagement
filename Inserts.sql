DELETE From Guest;
DELETE From GuestType;

insert into [GuestType] 
(GuestType) values ('Individual');
insert into [GuestType] 
(GuestType) values ('Group');
insert into [GuestType] 
(GuestType) values ('Agency');
insert into [GuestType] 
(GuestType) values ('Bussines Partner');


insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('DAC965EB-893D-94D3-136F-73EC397EF190','Joey','Smith','joeysmith@aol.com','0634535669', 'strada Brasov 7', 'Constanta', 'Romania', 'Individual', 'NoInfo' );
insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('C0B61866-E341-441A-CA7D-7CACA9EDAA36','Ann', 'Doe', 'anndoeh@aol.com','0735632462', 'Hill Street', 'Boston', 'USA', 'Agency','NoInfo');
insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('C75DDDE3-1E9B-59C7-320E-FBFB9B8CD56F','George', 'Will', 'georgewill@aol.com','0436723416', 'W Street', 'Barcelona', 'Spain', 'Group','He has a dog');
insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('F22F1530-A563-30E9-F475-32E75369D4A0','Miranda', 'Smith', 'mirandasmith@aol.com','0257356285', 'Fly Street', 'Paris', 'France', 'Bussines Partner','NoInfo');
insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('2B2F830B-B32F-ED2A-C2B8-8FD3A5B9A014','Julia', 'Smith', 'juliasmith@aol.com','0257356285', 'North Street', 'Chicago', 'USA', 'Group','NoInfo');
insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('6574F732-AFBF-E498-A2E9-44ED6545E05D','Phoebe', 'Buffay', 'phoebebuffay@hotmail.com','0257356285', 'West Street', 'Paris', 'France', 'Agency','NoInfo');
insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('D281AA81-A605-D384-704F-8A373B4DDA74','Monica', 'Geller', 'monicageller@yahoo.com','0257356285', 'South Street', 'New York', 'USA', 'Individual','NoInfo');
insert into Guest([GuestID],[FirstName],[LastName],[Email],[Phone],[Adresa],[City],[Country],[GuestType],[AditionalInfo]) values('1DBE8E35-2889-1547-B5FA-CB73743C2705', 'Chandler', 'Bing', 'chandlerbing@hotmail.com','0257356285', 'North Street', 'London', 'UK','Agency', 'NoInfo');


DELETE From Room;
DELETE From RoomType;

DELETE From AcomodationType;

insert into [AcomodationType]
(TypeofAcomodation) values ('Bed and Breakfast');
insert into [AcomodationType]
(TypeofAcomodation) values ('All inclusive');

insert into [RoomType]
(RoomTypeID, TypeofRoom, Price) values ('FB5297E5-C754-E8AD-2A61-B4FE918DB967', 'Single', '150$');
insert into [RoomType]
(RoomTypeID, TypeofRoom, Price) values ('E77A8D29-CBEF-0FD9-6797-780923DB84F9','Double', '250$');
insert into [RoomType]
(RoomTypeID, TypeofRoom, Price) values ('03D89659-0BF0-CA7C-174E-C899F4D0987C','Single', '180$');

insert into [Room]
(RoomNr, RoomTypeID, LocationID, AditionalInfo, TypeofAcomodation) values ('23', 'E77A8D29-CBEF-0FD9-6797-780923DB84F9', '92253C67-3FE9-B5A3-1815-06370B145B62', 'No info', 'Bed and Breakfast');
insert into [Room]
(RoomNr, RoomTypeID, LocationID, AditionalInfo, TypeofAcomodation) values ('17', '03D89659-0BF0-CA7C-174E-C899F4D0987C', '9A0DBEAA-4AF4-F792-A393-561C13AA57C6', 'No info', 'All inclusive');
insert into [Room]
(RoomNr, RoomTypeID, LocationID, AditionalInfo, TypeofAcomodation) values ('10', 'FB5297E5-C754-E8AD-2A61-B4FE918DB967', '9E5060AB-E64C-4E3A-DC3F-5C5B627FB6C2', 'Pet friendly', 'Bed and Breakfast');





DELETE From ReservationType;

insert into [ReservationType]
(ReservationType) values ('Booking');
insert into [ReservationType]
(ReservationType) values ('Agency');
insert into [ReservationType]
(ReservationType) values ('Phone');

DELETE From Reservation;

insert into [Reservation]
(DateCreation, CheckIn, CheckOut, Adults, Children, Meal, IdGuest, LocationID, ReservationID, ReservationType, GuestID, RoomsID) values ('2019/03/15', '2019/08/15', '2019/08/24', '2', '0', 'True', '2345','9A0DBEAA-4AF4-F792-A393-561C13AA57C6' ,'2564','Phone' , 'F22F1530-A563-30E9-F475-32E75369D4A0', '3453');
insert into [Reservation]
(DateCreation, CheckIn, CheckOut, Adults, Children, Meal, IdGuest, LocationID, ReservationID, ReservationType, GuestID, RoomsID) values ('2019/10/10', '2019/12/03', '2019/12/07', '2', '1', 'False', '0453','92253C67-3FE9-B5A3-1815-06370B145B62' ,'2456','Agency' , '1DBE8E35-2889-1547-B5FA-CB73743C2705', '2904');
insert into [Reservation]
(DateCreation, CheckIn, CheckOut, Adults, Children, Meal, IdGuest, LocationID, ReservationID, ReservationType, GuestID, RoomsID) values ('2019/03/15', '2019/08/15', '2019/08/24', '2', '0', 'True', '2845', '9E5060AB-E64C-4E3A-DC3F-5C5B627FB6C2','2064','Booking', 'C0B61866-E341-441A-CA7D-7CACA9EDAA36', '3453');










