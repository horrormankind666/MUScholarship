USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schSetScholarships]    Script Date: 19/3/2561 12:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๒๓/๐๒/๒๕๖๐>
-- Description	: <สำหรับบันทึกข้อมูลตาราง schScholarships ครั้งละ ๑ เรคคอร์ด>
-- Parameter
--  1. action				เป็น varchar	รับค่าการกระทำกับฐานข้อมูล
--  2. id					เป็น varchar	รับค่ารหัสทุน
--  3. scholarshipsNameTH	เป็น varchar	รับค่าชื่อทุนภาษาไทย
--  4. scholarshipsNameEN	เป็น varchar	รับค่าชื่อทุนภาษาอังกฤษ
--  5. scholarshipsTypeId	เป็น varchar	รับค่ารหัสประเภททุน
--  6. owner				เป็น varchar	รับค่าเจ้าของทุน
--  7. approvalStatus		เป็น varchar	รับค่าสถานะการยกเลิก
--  8. by					เป็น varchar	รับค่าชื่อของผู้ที่กระทำกับฐานข้อมูล
--  9. ip					เป็น varchar	รับค่าหมายเลขไอพีของผู้ที่กระทำกับฐานข้อมูล
-- =============================================
ALTER procedure [dbo].[sp_schSetScholarships]
(
	@action varchar(10) = null,
	@id varchar(5) = null,
	@scholarshipsNameTH varchar(200) = null,
	@scholarshipsNameEN	varchar(200) = null,
	@scholarshipsTypeId varchar(2) = null,
	@owner varchar(200)	= null,
	@approvalStatus varchar(2) = null,
	@by varchar(255) = null,
	@ip varchar(255) = null
)
as
begin
	set concat_null_yields_null off

	set @action = ltrim(rtrim(@action))
	set @id = ltrim(rtrim(@id))
	set @scholarshipsNameTH = ltrim(rtrim(@scholarshipsNameTH))
	set @scholarshipsNameEN	= ltrim(rtrim(@scholarshipsNameEN))
	set @scholarshipsTypeId = ltrim(rtrim(@scholarshipsTypeId))
	set @owner = ltrim(rtrim(@owner))
	set @approvalStatus = ltrim(rtrim(@approvalStatus))
	set @by = ltrim(rtrim(@by))
	set @ip = ltrim(rtrim(@ip))

	declare @keycode varchar(16) = 'A001'
	declare @table varchar(50) = 'schScholarships'
	declare @rowCount int = 0
	declare @rowCountUpdate int = 0
	declare @value nvarchar(max) = null
	declare @scholarshipsId varchar(5) = null
	declare	@strBlank varchar(50) = '----------**********.........0.0000000000000000000'
	
	set @action = upper(@action)
	
	if (@action = 'INSERT' or @action = 'UPDATE' or @action = 'DELETE')
	begin
		set @value = 'id='			+ (case when (@id is not null and len(@id) > 0 and charindex(@id, @strBlank) = 0) then ('"' + @id + '"') else 'null' end) + ', ' +
					 'KeyCode='		+ (case when (@keycode is not null and len(@keycode) > 0 and charindex(@keycode, @strBlank) = 0) then ('"' + @keycode + '"') else 'null' end) + ', ' +
					 'schNameTh='	+ (case when (@scholarshipsNameTH is not null and len(@scholarshipsNameTH) > 0 and charindex(@scholarshipsNameTH, @strBlank) = 0) then ('"' + @scholarshipsNameTH + '"') else 'null' end) + ', ' +
					 'schNameEn='	+ (case when (@scholarshipsNameEN is not null and len(@scholarshipsNameEN) > 0 and charindex(@scholarshipsNameEN, @strBlank) = 0) then ('"' + @scholarshipsNameEN + '"') else 'null' end) + ', ' +
					 'type='		+ (case when (@scholarshipsTypeId is not null and len(@scholarshipsTypeId) > 0 and charindex(@scholarshipsTypeId, @strBlank) = 0) then ('"' + @scholarshipsTypeId + '"') else 'null' end) + ', ' +
					 'owner='		+ (case when (@owner is not null and len(@owner) > 0 and charindex(@owner, @strBlank) = 0) then ('"' + @owner + '"') else 'null' end) + ', ' +
					 'schStatus='	+ (case when (@approvalStatus is not null and len(@approvalStatus) > 0 and charindex(@approvalStatus, @strBlank) = 0) then ('"' + @approvalStatus + '"') else 'null' end)
		begin try
			begin tran
				if (@action = 'INSERT')
				begin
					exec	sp_schGenerateScholarshipsId
							@scholarshipsId = @scholarshipsId output
				
					set @id = @scholarshipsId

					if (@id is not null and len(@id) > 0 and charindex(@id, @strBlank) = 0)
					begin
						set @rowCountUpdate = (select count(id) from schScholarships with(nolock) where id = @id)
						
						if (@rowCountUpdate = 0)
						begin
 							insert into schScholarships
 							(
								id,
								KeyCode,
								schNameTh,
								schNameEn,
								type,
								owner,
								schStatus,
								createDate,
								createBy,
								createIp,
								modifyDate,
								modifyBy,
								modifyIp
							)
							values
							(
								case when (@id is not null and len(@id) > 0 and charindex(@id, @strBlank) = 0) then @id else null end,
								@keycode,
								case when (@scholarshipsNameTH is not null and len(@scholarshipsNameTH) > 0 and charindex(@scholarshipsNameTH, @strBlank) = 0) then @scholarshipsNameTH else null end,
								case when (@scholarshipsNameEN is not null and len(@scholarshipsNameEN) > 0 and charindex(@scholarshipsNameEN, @strBlank) = 0) then @scholarshipsNameEN else null end,
								case when (@scholarshipsTypeId is not null and len(@scholarshipsTypeId) > 0 and charindex(@scholarshipsTypeId, @strBlank) = 0) then @scholarshipsTypeId else null end,
								case when (@owner is not null and len(@owner) > 0 and charindex(@owner, @strBlank) = 0) THEN @owner else null end,
								case when (@approvalStatus is not null and len(@approvalStatus) > 0 and charindex(@approvalStatus, @strBlank) = 0) then @approvalStatus else null end,
								getdate(),
								case when (@by is not null and len(@by) > 0 and charindex(@by, @strBlank) = 0) then @by else null end,
								case when (@ip is not null and len(@ip) > 0 and charindex(@ip, @strBlank) = 0) then @ip else null end,
								null,
								null,
								null
							)		
					
							set @rowCount = @rowCount + 1
						end
					end
				end
				
				if (@action = 'UPDATE' or @action = 'DELETE')					
				begin
					if (@id is not null and len(@id) > 0 and charindex(@id, @strBlank) = 0)
					begin
						set @rowCountUpdate = (select count(id) from schScholarships with(nolock) where id = @id)
						
						if (@rowCountUpdate > 0)
						begin
							if (@action = 'UPDATE')
							begin
								update schScholarships set
									KeyCode		= @keycode,
									schNameTh	= case when (@scholarshipsNameTH is not null and len(@scholarshipsNameTH) > 0 and charindex(@scholarshipsNameTH, @strBlank) = 0) then @scholarshipsNameTH else (case when (@scholarshipsNameTH is not null and (len(@scholarshipsNameTH) = 0 or charindex(@scholarshipsNameTH, @strBlank) > 0)) then null else schNameTh end) end,
									schNameEn	= case when (@scholarshipsNameEN is not null and len(@scholarshipsNameEN) > 0 and charindex(@scholarshipsNameEN, @strBlank) = 0) then @scholarshipsNameEN else (case when (@scholarshipsNameEN is not null and (len(@scholarshipsNameEN) = 0 or charindex(@scholarshipsNameEN, @strBlank) > 0)) then null else schNameEn end) end,
									type		= case when (@scholarshipsTypeId is not null and len(@scholarshipsTypeId) > 0 and charindex(@scholarshipsTypeId, @strBlank) = 0) then @scholarshipsTypeId else (case when (@scholarshipsTypeId is not null and (len(@scholarshipsTypeId) = 0 or charindex(@scholarshipsTypeId, @strBlank) > 0)) then null else type end) end,
									owner		= case when (@owner is not null and len(@owner) > 0 and charindex(@owner, @strBlank) = 0) then @owner else (case when (@owner is not null and (len(@owner) = 0 or charindex(@owner, @strBlank) > 0)) then null else owner end) end,
									schStatus	= case when (@approvalStatus is not null and len(@approvalStatus) > 0 and charindex(@approvalStatus, @strBlank) = 0) then @approvalStatus else (case when (@approvalStatus is not null and (len(@approvalStatus) = 0 or charindex(@approvalStatus, @strBlank) > 0)) then null else schStatus end) end,
									modifyDate	= getdate(),
									modifyBy	= case when (@by is not null and len(@by) > 0 and charindex(@by, @strBlank) = 0) then @by else (case when (@by is not null and (len(@by) = 0 or charindex(@by, @strBlank) > 0)) then null else modifyBy end) end,
									modifyIp	= case when (@ip is not null and len(@ip) > 0 and charindex(@ip, @strBlank) = 0) then @ip else (case when (@ip is not null and (len(@ip) = 0 or charindex(@ip, @strBlank) > 0)) then null else modifyIp end) end
								where id = @id
							end						
							
							if (@action = 'DELETE')
							begin
								delete from schScholarships where id = @id
							end
							
							set @rowCount = @rowCount + 1							
						end
					end
				end
			commit tran
		end try
		begin catch
			rollback tran
			insert into InfinityLog..sysError
			(
				systemName,
				errorNumber,
				errorMessage,
				hint,
				url,
				logDate,
				sendMail,
				sendDate
			)
			values
			(
				'MUScholarship',				
				error_number(),
				error_message(),
				(error_procedure() + ' Error -> ' + @action + ' id : ' + @id),
				null,
				getdate(),
				null,
				null
			)	
		end catch
	end
	
	select @rowCount, @id
end