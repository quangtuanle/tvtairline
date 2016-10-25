create database AirplaneReservationDB
go
use AirplaneReservationDB
go

create table flight
(
	flightCode nchar(20),
	origin nchar(5),
	destination nchar(5),
	departureDates nchar(20),
	departureTimes nchar(20),
	classLevel nchar(3),
	priceLevel nchar(3),
	seatNumber int,
	price float,
	primary key (flightCode, departureDates, classLevel, priceLevel)
)
create table airPort
(
	airPortCode nchar(5),
	airPortName nvarchar(30),
	area nvarchar(30)
	primary key (airPortCode)
)
create table booking
(
	bookingCode nchar(20),
	bookingTimes nchar(50),
	payment float, 
	status bit,
	primary key (bookingCode)
)

create table flightDetail
(
	bookingCode nchar(20),
	flightCode nchar(20),
	departureDates nchar(20),
	classLevel nchar(3),
	priceLevel nchar(3),
	primary key (bookingCode, flightCode, departureDates)
)

create table passenger
(
	passengerCode int identity,
	bookingCode nchar(20),
	epithets nvarchar(20),
	firstname nvarchar(20),
	lastname nvarchar(20),
	ageCode int,
	primary key (passengerCode)
)

create table age
(
	ageCode int,
	ageDetail nvarchar(50)
	primary key (ageCode)
)

alter table flight
add constraint FK1_flight_airPort
foreign key (origin)
references airPort (airPortCode)

alter table flight
add constraint FK2_flight_airPort
foreign key (destination)
references airPort (airPortCode)

alter table flightDetail
add constraint FK_flightDetail_booking
foreign key (bookingCode)
references booking (bookingCode)

alter table flightDetail
add constraint FK_flightDetail_flight
foreign key (flightCode, departureDates, classLevel, priceLevel)
references flight (flightCode, departureDates, classLevel, priceLevel)

alter table passenger
add constraint FK_passenger_booking
foreign key (bookingCode)
references booking (bookingCode)

alter table passenger
add constraint FK_passenger_age
foreign key (ageCode)
references age (ageCode)

insert into age values('0', N'Người lớn (> 12 tuổi)')
insert into age values('1', N'Trẻ em (2 -> 12 tuổi)')
insert into age values('2', N'Em bé (< 2 tuổi)')

insert into airPort values('SGN', N'Sài Gòn', N'Miền Nam')
insert into airPort values('TBB', N'Hà Nội', N'Miền Bắc')
insert into airPort values('HBH', N'Hải Phòng', N'Miền Bắc')

insert into flight values ('BL326', 'SGN', 'TBB', '2016-10-05', '08:45', 'Y', 'E', 100, 100000)
insert into flight values ('BL326', 'SGN', 'TBB', '2016-10-05', '08:45', 'Y', 'F', 200, 10000)
insert into flight values ('BL326', 'SGN', 'TBB', '2016-10-05', '08:45', 'C', 'G', 10, 500000)
insert into flight values ('BL327', 'TBB', 'SGN', '2016-10-06', '10:30', 'Y', 'E', 100, 100000)

insert into booking values('ABCXYZ', '2016-05-01 10:00:00', 400000, 1)

insert into flightDetail values ('ABCXYZ', 'BL326', '2016-10-05', 'Y', 'E')
insert into flightDetail values ('ABCXYZ', 'BL327', '2016-10-06', 'Y', 'E')

insert into passenger values ('ABCXYZ', 'MR', 'NGUYEN', 'VAN A', 0)
insert into passenger values ('ABCXYZ', 'MR', 'TRAN', 'THI B', 1)


 