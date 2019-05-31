use ItLaboratory
go
create function FC_GetProcessorById(@ProcessorId int) returns varchar(300)
as
	begin
		declare	@ProcessorString varchar(300),
				@Manufacturer varchar(10),
				@Series varchar(30),
				@Model varchar(10),
				@Cores int,
				@MaxFrequency int
		select	@Manufacturer = Processor.Manufacturer,
				@Series = Processor.Series,
				@Model = Processor.Model,
				@Cores = Processor.Cores,
				@MaxFrequency = Processor.MaxFrequency
			from Processor
				where Processor.Id = @ProcessorId
		set @ProcessorString = @Manufacturer + ' ' + @Series + ' ' + @Model + ' ' + cast(@Cores as varchar(3)) + ' cores ' + cast(@MaxFrequency as varchar(10)) + 'MHz'
		return @ProcessorString
	end
go
create function FC_GetVideoAdapterById(@VideoAdapterId int) returns varchar(300)
as
	begin
		declare @VideoAdapterString varchar(300),
				@Manufacturer varchar(10),
				@Series varchar(30),
				@Model varchar(10),
				@RamSize int
		if not exists(select * from VideoAdapter where VideoAdapter.Id = @VideoAdapterId)
			return 'No video adapter'
		select	@Manufacturer = VideoAdapter.Manufacturer,
				@Series = VideoAdapter.Series,
				@Model = VideoAdapter.Model,
				@RamSize = VideoAdapter.RamSize
			from VideoAdapter
				where VideoAdapter.Id = @VideoAdapterId
		set @VideoAdapterString = @Manufacturer + ' ' + @Series + ' ' + @Model + ' ' + cast(@RamSize as varchar(10)) + 'MB'
		return @VideoAdapterString
	end
go
create function FC_GetRamById(@RamId int) returns varchar(50)
as
	begin
		declare @RamString varchar(50),
				@RamType varchar(10),
				@RamSize int
		select @RamType = RAM.Type, @RamSize = RAM.Size from RAM where RAM.Id = @RamId
		set @RamString = cast(@RamSize as varchar(10)) + 'MB' + ' ' + @RamType
		return @RamString
	end
go
create function FC_GetHddById(@HddId int) returns varchar(50)
as
	begin
		declare @HddString varchar(50),
				@HddType varchar(10),
				@HddSize int
		select @HddType = HDD.Type, @HddSize = HDD.Size from HDD where HDD.Id = @HddId
		set @HddString = cast(@HddSize as varchar(10)) + 'MB' + ' ' + @HddType
		return @HddString
	end
go
create view ComputersView
as
	select	Computer.Id,
			Computer.Type,
			dbo.FC_GetProcessorById(Computer.ProcessorID)[Processor],
			dbo.FC_GetVideoAdapterById(Computer.VideoAdapterID)[VideoAdapter],
			dbo.FC_GetRamById(Computer.RamID)[Ram],
			dbo.FC_GetHddById(Computer.HddID)[Hdd],
			Computer.PurchaseDate
				from Computer
go
alter procedure SP_INSERT_Computer @Type varchar(50), @Processor varchar(50), @VideoAdapter varchar(50),
									@RamType varchar(10), @RamSize int, @HDD varchar(50), @PurchaseDate date, @ID int output
as
	begin
		begin tran
			insert into Computer(Type, Processor, VideoAdapter, RamType, RamSize, HDD, PurchaseDate)
				values(@Type, @Processor, @VideoAdapter, @RamType, @RamSize, @HDD, @PurchaseDate)
				set @ID = SCOPE_IDENTITY()
		if @@TRANCOUNT > 0
			rollback tran
		commit tran
	end
go
alter procedure SP_INSERT_RAM @Type varchar(50), @Size int
as
	begin
			insert into Ram(Type, Size)
				values(@Type, @Size)
		
	end
go
select * from ram
delete ram where Type = ddr4 and size = 512