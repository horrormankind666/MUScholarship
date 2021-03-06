USE [Infinity]
GO
/****** Object:  Trigger [dbo].[tg_schScholarships]    Script Date: 19/3/2561 12:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_schScholarships]
   on [dbo].[schScholarships]
   after insert, delete, update
as
begin
    set concat_null_yields_null off

	declare @table varchar(50) = 'schScholarships'
    declare @action varchar(10) = NULL
	
	if exists (select * from inserted)
	begin
		if exists (select * from deleted)
			set @action = 'UPDATE'
		else
			set @action = 'INSERT'
			
		insert into InfinityLog..schScholarshipsLog
		(
			schScholarshipsId,
			KeyCode,
			schNameTh,
			schNameEn,
			type,
			owner,
			schStatus,
			fundStatus,
			createDate,
			createBy,
			createIp,
			modifyDate,
			modifyBy,			
			modifyIp,
			logDatabase,
			logTable,
			logAction,
			logActionDate,
			logActionBy,
			logIp
		)
		select	*,
				db_name(),
				@table,
				@action,
				getdate(),
				system_user,
				null
		from	inserted				
	end
	else
		begin
			set @action = 'DELETE'
			
			insert into InfinityLog..schScholarshipsLog
			(			
				schScholarshipsId,
				KeyCode,
				schNameTh,
				schNameEn,
				type,
				owner,
				schStatus,
				fundStatus,
				createDate,
				createBy,
				createIp,
				modifyDate,
				modifyBy,			
				modifyIp,				
				logDatabase,
				logTable,
				logAction,
				logActionDate,
				logActionBy,
				logIp
			)
			select	*,
					db_name(),
					@table,
					@action,
					getdate(),
					system_user,
					null
			from	deleted			
		end
end
