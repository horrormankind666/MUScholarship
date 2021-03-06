USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetListStudentWithAuthenStaff]    Script Date: 12/7/2561 14:11:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๒๔/๐๒/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลนักศึกษาตามสิทธิ์ผู้ใช้งาน>
-- Parameter
--	1. username		เป็น varchar	รับค่าชื่อผู้ใช้งาน
--	2. userlevel	เป็น varchar	รับค่าระดับผู้ใช้งาน
--	3. systemGroup	เป็น varchar	รับค่าชื่อระบบงาน
--	4. keyword		เป็น varchar	รับค่าคำค้น
--	5. facultyId	เป็น varchar	รับค่ารหัสคณะ
--	6. programId	เป็น varchar	รับค่าหลักสูตร
--  7. yearEntry	เป็น varchar	รับค่าปีที่เข้าศึกษา
-- =============================================
ALTER procedure [dbo].[sp_schGetListStudentWithAuthenStaff]
(
	@username varchar(255) = null,
	@userlevel varchar(20) = null,
	@systemGroup varchar(50) = null,
	@keyword varchar(100) = null,
	@facultyId varchar(15) = null,
	@programId varchar(15) = null,
	@yearEntry varchar(4) = null
)
as
begin
	set concat_null_yields_null off
	
	set @username = ltrim(rtrim(isnull(@username, '')))
	set @userlevel = ltrim(rtrim(isnull(@userlevel, '')))
	set @systemGroup = ltrim(rtrim(isnull(@systemGroup, '')))
	set @keyword = ltrim(rtrim(isnull(@keyword, '')))
	set @facultyId = ltrim(rtrim(isnull(@facultyId, '')))
	set @programId = ltrim(rtrim(isnull(@programId, '')))
	set @yearEntry = ltrim(rtrim(isnull(@yearEntry, '')))

	declare	@userFaculty varchar(15) = null
	declare @userProgram varchar(15) = null
	
	select	@userFaculty = autusr.facultyId,
			@userProgram = autusr.programId
	from	autUserAccessProgram as autusr with(nolock)
	where	(autusr.username = @username) and
			(autusr.level = @userlevel) and
			(autusr.systemGroup = @systemGroup)
	
	set @userFaculty = isnull(@userFaculty, '')
	set @userProgram = isnull(@userProgram, '')	

	select	perstd.id,
			perstd.studentId,
			perstd.studentCode,
			perstd.titlePrefixFullNameTH,
			perstd.titlePrefixInitialsTH,
			perstd.titlePrefixFullNameEN,
			perstd.titlePrefixInitialsEN,
			perstd.firstName,
			perstd.middleName,
			perstd.lastName,
			perstd.firstNameEN,
			perstd.middleNameEN,
			perstd.lastNameEN,
			perstd.facultyId,
			perstd.facultyCode,
			perstd.facultyNameTH,
			perstd.facultyNameEN,
			perstd.programId,
			perstd.programCode,
			perstd.programNameTH,
			perstd.programNameEN,			
			perstd.majorCode,
			perstd.groupNum,
			perstd.yearEntry,
			perstd.status,
			perstd.statusTypeNameTH,
			perstd.statusTypeNameEN,
			perstd.statusGroup
	into	 #tmp1
	from	vw_schGetListPersonStudent as perstd with(nolock)
	where	(perstd.cancelStatus is null) and
			(@userFaculty = 'MU-01' or perstd.facultyId = @userFaculty) and
			(len(@userProgram) = 0 or perstd.programId = @userProgram) and
			(
				(isnull(perstd.studentCode, '') +
				 isnull(perstd.titlePrefixFullNameTH, '') +
				 isnull(perstd.titlePrefixInitialsTH, '') +
				 isnull(perstd.titlePrefixFullNameEN, '') +
				 isnull(perstd.titlePrefixInitialsEN, '') +
				 isnull(perstd.firstName, '') +
				 isnull(perstd.middleName, '') +
				 isnull(perstd.lastName, '') +
				 isnull(perstd.firstNameEN, '') +
				 isnull(perstd.middleNameEN, '') +
				 isnull(perstd.lastNameEN, '')) like
				('%' + @keyword + '%')
			) and
			(
				(len(@keyword) > 0) or
				(
					(len(@keyword) = 0) and
					(len(@facultyId) = 0 or perstd.facultyId = @facultyId) and
					(len(@programId) = 0 or perstd.programId = @programId) and
					(len(@yearEntry) = 0 or perstd.yearEntry = @yearEntry)
				)
			)
	
	select	 schtst.studentId,
			 count(schtst.studentId) AS numberScholar
	into	 #tmp2
	from	 schTranStudent as schtst with(nolock) inner join
			 #tmp1 as tbtmp1 on schtst.studentId = tbtmp1.studentId inner join
			 schScholarships AS sch with(nolock) ON schtst.schId = sch.id
	where	 (schtst.cancelStatus is null) and
			 (sch.schStatus = 'Y') 
	group by schtst.studentId

	select	row_number() over(order by tbtmp1.studentCode) AS rowNum,
			tbtmp1.*,
			isnull(tbtmp2.numberScholar, 0) as numberScholar
	from	#tmp1 as tbtmp1 left join
			#tmp2 as tbtmp2 on tbtmp1.studentId = tbtmp2.studentId
END