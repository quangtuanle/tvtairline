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
insert into airPort values('HPH', N'Hải Phòng', N'Miền Bắc')
insert into airPort values('DIN', N'Điện Biên', N'Miền Bắc')
insert into airPort values('THD', N'Thanh Hóa', N'Miền Bắc')
insert into airPort values('VII', N'Vinh', N'Miền Trung')
insert into airPort values('HUI', N'Huế', N'Miền Trung')
insert into airPort values('VDH', N'Đồng Hới', N'Miền Trung')
insert into airPort values('DLI', N'Đà Lạt', N'Miền Nam')
insert into airPort values('PQC', N'Phú Quốc', N'Miền Nam')
insert into airPort values('HAN', N'Hà Nội', N'Miền Bắc')
insert into airPort values('TBB', N'Tuy Hòa', N'Miền Trung')


insert into flight values ('BL326', 'SGN', 'TBB', '2016-10-05', '08:45', 'Y', 'E', 100, 100000)
insert into flight values ('BL326', 'SGN', 'TBB', '2016-10-05', '08:45', 'Y', 'F', 200, 10000)
insert into flight values ('BL326', 'SGN', 'TBB', '2016-10-05', '08:45', 'C', 'G', 10, 500000)
insert into flight values ('BL327', 'TBB', 'SGN', '2016-10-06', '10:30', 'Y', 'E', 100, 100000)
insert into flight values ('BL328', 'VDH', 'TBB', '2016-10-08', '07:30', 'C', 'E', 100, 100000)
insert into flight values ('BL329', 'PQC', 'HPH', '2016-10-11', '14:30', 'Y', 'G', 20, 100000)
insert into flight values ('BL330', 'DLI', 'HAN', '2016-10-12', '10:45', 'Y', 'E', 50, 200000)
insert into flight values ('BL331', 'VDH', 'DIN', '2016-10-13', '15:30', 'Y', 'E', 120, 150000)
insert into flight values ('BL332', 'VDH', 'HPH', '2016-10-13', '15:45', 'Y', 'F', 200, 100000)
insert into flight values ('BL333', 'HAN', 'DLI', '2016-10-14', '12:30', 'C', 'E', 20, 300000)
insert into flight values ('BL334', 'VII', 'THD', '2016-10-16', '18:00', 'Y', 'F', 100, 500000)
insert into flight values ('BL335', 'SGN', 'DLI', '2016-10-17', '17:20', 'C', 'G', 20, 250000)

insert into booking values('ABCXYZ', '2016-05-01 10:00:00', 400000, 1)
insert into booking values('AB7EDD', '2016-05-08 12:12:20', 200000, 1)
insert into booking values('AD5E73', '2016-05-09 18:20:15', 800000, 0)
insert into booking values('AB8DEZ', '2016-05-11 09:25:12', 1000000, 1)
insert into booking values('ABC48Z', '2016-05-01 10:00:00', 400000, 1)

insert into flightDetail values ('ABCXYZ', 'BL326', '2016-10-05', 'Y', 'E')
insert into flightDetail values ('ABCXYZ', 'BL327', '2016-10-06', 'Y', 'E')
insert into flightDetail values ('AB7EDD', 'BL328', '2016-10-07', 'C', 'E')
insert into flightDetail values ('AD5E73', 'BL331', '2016-10-07', 'Y', 'E')
insert into flightDetail values ('AB8DEZ', 'BL322', '2016-10-08', 'Y', 'F')
insert into flightDetail values ('ABC48Z', 'BL323', '2016-10-10', 'C', 'E')

insert into passenger values ('ABCXYZ', 'MR', 'NGUYEN', 'VAN A', 0)
insert into passenger values ('ABCXYZ', 'MR', 'TRAN', 'THI B', 1)
insert into passenger values ('AB7EDD', 'MR', 'NGUYEN', 'TUAN HOANG', 0)
insert into passenger values ('AD5E73', 'MRS', 'TRAN', 'THI CHI', 0)
insert into passenger values ('AB8DEZ', 'MRS', 'LE', 'HONG HOA', 1)
insert into passenger values ('ABC48Z', 'MR', 'LUONG', 'VAN DAT', 0)

 