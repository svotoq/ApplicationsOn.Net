use master
go
create database ItLaboratory
go
use ItLaboratory
go
--create table Processor
--(
--Id int primary key identity,
--Manufacturer varchar(10) check(Manufacturer in ('Intel', 'Amd')),
--Series varchar(30) not null,
--Model varchar(10) not null,
--Cores int not null,
--Frequency int not null,
--MaxFrequency int not null,
--Architecture varchar(3) check(Architecture in ('x64', 'x86')),
--CacheL1 int not null,
--CacheL2 int not null,
--CacheL3 int default null
--)
--go
create table RAM
(
--Id int primary key identity,
--Type varchar(10) check(Type in ('SDRAM', 'DDR', 'DDR2', 'DDR3', 'DDR3L', 'DDR4')),
Type varchar(10),
Size int,
primary key(Type, Size)
)
go
--create table VideoAdapter
--(
--Id int primary key identity,
--Manufacturer varchar(30) check(Manufacturer in ('Intel', 'Amd', 'Nvidia')),
--Series varchar(30) not null,
--Model varchar(10) not null,
--Frequency int not null,
--DirectX11 varchar(3) check(DirectX11 in ('Yes', 'No')),
--RamSize int not null
--)
--go
--create table HDD
--(
--Id int primary key identity,
--Type varchar(10) check(Type in ('PATA', 'SATA', 'SCSI', 'SSD')),
--Size int not null
--)
--go
create table Computer
(
Id int primary key identity,
Type varchar(50),
Processor varchar(50),
VideoAdapter varchar(50),
RamType varchar(10),
RamSize int,
Hdd varchar(50),
PurchaseDate date default convert(date, GetDate()),
    FOREIGN KEY (RamType, RamSize)
      REFERENCES RAM(Type, Size)
      ON UPDATE CASCADE ON DELETE CASCADE
)
go