use ItLaboratory
go
begin try
	begin transaction
		insert into HDD(Type, Size)
			values	('PATA', 256),
					('PATA', 512),
					('SATA', 512),
					('SATA', 1024),
					('SSD', 128),
					('SSD', 256)
		insert into RAM(Type, Size)
			values	('DDR2', 512),
					--('DDR2', 1024),
					--('DDR3', 1024),
					('DDR3', 2048),
					--('DDR3', 4096),
					('DDR3L', 2048),
					--('DDR3L', 4096),
					--('DDR4', 2048),
					('DDR4', 4096)
		insert into Processor(Manufacturer, Series, Model, Cores, Frequency, MaxFrequency, Architecture, CacheL1, CacheL2, CacheL3)
			values	('Intel', 'i3', '8100', 4, 3600, 3800, 'x64', 24, 12, 6),
					('Intel', 'i5', '4210u', 2, 2400, 2700, 'x64', 1, 2, 3),
					('Amd', 'Turion II', 'P540', 2, 2400, 2400, 'x64', 1, 2, null),
					('Amd', 'Phenom II X4', 'P920', 4, 1600, 1600, 'x64', 1, 2, null)
		insert into VideoAdapter(Manufacturer, Series, Model, Frequency, DirectX11, RamSize)
			values	('Intel', 'HD', '520', 1050, 'Yes', 4096),
					('Amd', 'Radeon HD', '4200', 500, 'No', 512),
					('Nvidia', 'GT', '840m', 1029, 'Yes', 2048)
		insert into Computer(Type, Processor, VideoAdapter, RamType, RamSize, Hdd, PurchaseDate)
			values	('Server', 'Intel', null, 'DDR4',4096, 'SATA', convert(date,GetDate())),
					('Workstation', 'AMD', 'Nvidia', 'DDR2',512, 'IDE', '2018-12-24'),
					('Laptop', 'AMD', 'Intel hd', 'DDR3L',2048, 'SSD', '2010-08-12')
	commit transaction
end try
begin catch
	rollback transaction
	print 'Error!'
end catch
go
select * from RAM
select * from HDD
select * from Processor
select * from VideoAdapter
select * from Computer
