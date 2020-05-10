DELETE From Reservation;
DELETE From Room;
DELETE From AccommodationType;
DELETE From ReservationType;
DELETE From Guest;
DELETE From GuestType;
DELETE From RoomType;

insert into GuestType([ID], [Type]) values ('464220A9-66ED-769C-05BA-EC20A0CF6E4B', 'Individual');
insert into GuestType([ID], [Type]) values ('00C7F69F-EAC4-3D0B-7F1E-3EA36EA2D0DE', 'Group');
insert into GuestType([ID], [Type]) values ('5ADC35CF-1AB1-CB2D-8759-CC337F294BE9', 'Agency');
insert into GuestType([ID], [Type]) values ('2E109928-7C6C-B075-80ED-802BE949CBED', 'Bussines Partner');
insert into GuestType([ID], [Type]) values ('05DC4757-C2C5-FDEB-78FF-7FBB356BCAEC', 'Group');
insert into GuestType([ID], [Type]) values ('8C3247BA-744B-B22D-3F74-052AB990E14D', 'Individual');
insert into GuestType([ID], [Type]) values ('F1DF267A-10A5-AFA6-9C5D-0EBD8382EB38', 'Bussines Partner');
insert into GuestType([ID], [Type]) values ('F3F94A50-623F-7D08-D119-AFD660F57C5D', 'Agency');

insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('DAC965EB-893D-94D3-136F-73EC397EF190','Joey','Smith','joeysmith@aol.com','0634535669', 'strada Brasov 7', 'Constanta', 'Romania', '464220A9-66ED-769C-05BA-EC20A0CF6E4B', 'NoInfo' );
insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('C0B61866-E341-441A-CA7D-7CACA9EDAA36','Ann', 'Doe', 'anndoeh@aol.com','0735632462', 'Hill Street', 'Boston', 'USA', '464220A9-66ED-769C-05BA-EC20A0CF6E4B','NoInfo');
insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('C75DDDE3-1E9B-59C7-320E-FBFB9B8CD56F','George', 'Will', 'georgewill@aol.com','0436723416', 'W Street', 'Barcelona', 'Spain', '5ADC35CF-1AB1-CB2D-8759-CC337F294BE9','He has a dog');
insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('F22F1530-A563-30E9-F475-32E75369D4A0','Miranda', 'Smith', 'mirandasmith@aol.com','0257356285', 'Fly Street', 'Paris', 'France', '2E109928-7C6C-B075-80ED-802BE949CBED','NoInfo');
insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('2B2F830B-B32F-ED2A-C2B8-8FD3A5B9A014','Julia', 'Smith', 'juliasmith@aol.com','0257356285', 'North Street', 'Chicago', 'USA', '05DC4757-C2C5-FDEB-78FF-7FBB356BCAEC','NoInfo');
insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('6574F732-AFBF-E498-A2E9-44ED6545E05D','Phoebe', 'Buffay', 'phoebebuffay@hotmail.com','0257356285', 'West Street', 'Paris', 'France', '8C3247BA-744B-B22D-3F74-052AB990E14D','NoInfo');
insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('D281AA81-A605-D384-704F-8A373B4DDA74','Monica', 'Geller', 'monicageller@yahoo.com','0257356285', 'South Street', 'New York', 'USA', 'F1DF267A-10A5-AFA6-9C5D-0EBD8382EB38','NoInfo');
insert into Guest([ID],[FirstName],[LastName],[Email],[Phone],[Address],[City],[Country],[GuestTypeID],[AditionalInfo]) values('1DBE8E35-2889-1547-B5FA-CB73743C2705', 'Chandler', 'Bing', 'chandlerbing@hotmail.com','0257356285', 'North Street', 'London', 'UK','F3F94A50-623F-7D08-D119-AFD660F57C5D', 'NoInfo');

insert into [AccommodationType] ([ID], [Type]) values ('3457D994-9ACF-6907-EB01-95C9DB8A1661', 'Bed and Breakfast');
insert into [AccommodationType] ([ID], [Type]) values ('F7D82AFA-4507-3DA2-72A6-B7FB4D59119F', 'All inclusive');
insert into [AccommodationType] ([ID], [Type]) values ('62984B65-907F-BF97-9FB3-366FBACA30D9', 'Bed and Breakfast');

insert into [RoomType]
(ID, Name, Price) values ('FB5297E5-C754-E8AD-2A61-B4FE918DB967', 'Single', 150);
insert into [RoomType]
(ID, Name, Price) values ('E77A8D29-CBEF-0FD9-6797-780923DB84F9','Double', 250);
insert into [RoomType]
(ID, Name, Price) values ('03D89659-0BF0-CA7C-174E-C899F4D0987C','Family', 180);
insert into [RoomType]
(ID, Name, Price) values ('B3975393-568E-49A3-ABC1-66B841ED3E0A','Presidential', 300);

insert into [Room]
(RoomNr, RoomTypeID, ID, AditionalInfo, TypeofAccommodationID) values ('23', 'E77A8D29-CBEF-0FD9-6797-780923DB84F9', '92253C67-3FE9-B5A3-1815-06370B145B62', 'No info', '3457D994-9ACF-6907-EB01-95C9DB8A1661');
insert into [Room]
(RoomNr, RoomTypeID, ID, AditionalInfo, TypeofAccommodationID) values ('17', '03D89659-0BF0-CA7C-174E-C899F4D0987C', '9A0DBEAA-4AF4-F792-A393-561C13AA57C6', 'No info', 'F7D82AFA-4507-3DA2-72A6-B7FB4D59119F');
insert into [Room]
(RoomNr, RoomTypeID, ID, AditionalInfo, TypeofAccommodationID) values ('10', 'FB5297E5-C754-E8AD-2A61-B4FE918DB967', '9E5060AB-E64C-4E3A-DC3F-5C5B627FB6C2', 'Pet friendly', '62984B65-907F-BF97-9FB3-366FBACA30D9');
insert into [Room]
(RoomNr, RoomTypeID, ID, AditionalInfo, TypeofAccommodationID) values ('2', 'FB5297E5-C754-E8AD-2A61-B4FE918DB967', '86E5FF43-2D28-41F4-A7E5-B42CEE567FA7', 'Pet friendly', '62984B65-907F-BF97-9FB3-366FBACA30D9');

insert into [ReservationType] ([ID], [Type]) values ('1AB4F8C3-3F8D-2ABF-10E7-B24BE5F781AA', 'Booking');
insert into [ReservationType] ([ID], [Type]) values ('7B611782-B94A-181B-C8A8-03810636217B', 'Agency');
insert into [ReservationType] ([ID], [Type]) values ('0856B808-C2E4-B5F3-7AF6-035E096B238A', 'Phone');


insert into [Reservation]
(DateCreation, CheckIn, CheckOut, NumberOfAdults, NumberOfChildren, Meal, ID, ReservationTypeID, GuestID, RoomID) values ('2019/03/15', '2019/08/15', '2019/08/24', '2', '0', 'True', '2564','0856B808-C2E4-B5F3-7AF6-035E096B238A' , 'F22F1530-A563-30E9-F475-32E75369D4A0', '9A0DBEAA-4AF4-F792-A393-561C13AA57C6');
insert into [Reservation]
(DateCreation, CheckIn, CheckOut, NumberOfAdults, NumberOfChildren, Meal, ID, ReservationTypeID, GuestID, RoomID) values ('2019/10/10', '2019/12/03', '2019/12/07', '2', '1', 'False', '2456','7B611782-B94A-181B-C8A8-03810636217B' , '1DBE8E35-2889-1547-B5FA-CB73743C2705', '92253C67-3FE9-B5A3-1815-06370B145B62');
insert into [Reservation]
(DateCreation, CheckIn, CheckOut, NumberOfAdults, NumberOfChildren, Meal, ID, ReservationTypeID, GuestID, RoomID) values ('2019/03/15', '2019/08/15', '2019/08/24', '2', '0', 'True', '2064','1AB4F8C3-3F8D-2ABF-10E7-B24BE5F781AA', 'C0B61866-E341-441A-CA7D-7CACA9EDAA36', '9E5060AB-E64C-4E3A-DC3F-5C5B627FB6C2');
