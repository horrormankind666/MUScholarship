USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetListTranStudentFinanceScholarshipSavePeopleApprovedWithAuthenStaff]    Script Date: 12/7/2561 14:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๑๗/๐๘/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลนักศึกษาที่สมัครรับทุนแล้วเตรียมบันทึกอนุมัติรับเงินตามสิทธิ์ผู้ใช้งาน>
-- Parameter
--	1. username					เป็น varchar	รับค่าชื่อผู้ใช้งาน
--	2. userlevel				เป็น varchar	รับค่าระดับผู้ใช้งาน
--	3. systemGroup				เป็น varchar	รับค่าชื่อระบบงาน
--	4. keyword					เป็น varchar	รับค่าคำค้น
--  5. scholarshipsTypeGroup	เป็น varchar	รับค่าประเภททุน
--  6. scholarshipsYear			เป็น varchar	รับค่าปีที่อนุมัติรับเงิน
--  7. semester					เป็น varchar	รับค่าภาคเรียนที่อนุมัติรับเงิน
--  8. lotNo					เป็น varchar	รับค่างวดที่
--  9. approveStatus			เป็น varchar	รับค่าสถานะอนุมัติรับเงิน
-- 10. cancelStatus				ป็น varchar	รับค่าสถานะการยกเลิก
-- =============================================
ALTER procedure [dbo].[sp_schGetListTranStudentFinanceScholarshipSavePeopleApprovedWithAuthenStaff]
(
	@username varchar(255) = null,
	@userlevel varchar(20) = null,
	@systemGroup varchar(50) = null,
	@keyword varchar(100) = null,
	@scholarshipsTypeGroup varchar(30) = null,
	@scholarshipsYear varchar(4) = null,
	@semester varchar(2) = null,
	@lotNo varchar(2) = null,
	@approveStatus varchar(1) = null,
	@cancelStatus varchar(1) = null
)
as
begin
	set concat_null_yields_null off

	set @username = ltrim(rtrim(isnull(@username, '')))
	set @userlevel = ltrim(rtrim(isnull(@userlevel, '')))
	set @systemGroup = ltrim(rtrim(isnull(@systemGroup, '')))
	set @keyword = ltrim(rtrim(isnull(@keyword, '')))
	set @scholarshipsTypeGroup = ltrim(rtrim(isnull(@scholarshipsTypeGroup, '')))
	set @scholarshipsYear = ltrim(rtrim(isnull(@scholarshipsYear, '')))
	set @semester = ltrim(rtrim(isnull(@semester, '')))
	set @lotNo = ltrim(rtrim(isnull(@lotNo, '')))
	set @approveStatus = ltrim(rtrim(isnull(@approveStatus, '')))
	set @cancelStatus = ltrim(rtrim(isnull(@cancelStatus, '')))
		
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

	select	row_number() over(order by perstd.studentCode, schtst.acaYear, schtst.semester, schtst.schId, schtst.lotNo) as rowNum,
			perstd.id,
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
			perstd.statusGroup,
			schtst.acaYear as scholarshipsYear,
			schtst.semester,
			schtst.schId as schScholarshipsId,
			schsch.schNameTh as scholarshipsNameTH,
			schsch.schNameEn as scholarshipsNameEN,
			schsch.type as schScholarshipsTypeId,
			schstp.typeName as scholarshipsTypeNameTH,
			schstp.typeNameEN as scholarshipsTypeNameEN,
			schstp.typeGroup as scholarshipsTypeGroup,
			schtst.lotNo,
			schtst.tuition,
			schtst.createDate as registerDate,
			schtst.contractDate,
			schtst.approveDate,
			schtst.cancelStatus
	from	schTranStudent as schtst with(nolock) inner join
			vw_schGetListPersonStudent as perstd with(nolock) on schtst.studentId = perstd.studentId left join
			schScholarships as schsch with(nolock) on schtst.schId = schsch.id left join
			schScholarshipsType as schstp with(nolock) on schsch.type = schstp.type
	where	(@userFaculty = 'MU-01' or perstd.facultyId = @userFaculty) and
			(len(@userProgram) = 0 or perstd.programId = @userProgram) and
			((len(@cancelStatus) = 0 and schtst.cancelStatus is null) or schtst.cancelStatus = @cancelStatus) and
			(schsch.schStatus = 'Y') and
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
				 isnull(perstd.lastNameEN, '') +
				 isnull(schtst.deptResponsible, '') +
				 isnull(perstd.facultyCode, '') +
				 isnull(perstd.facultyNameTH, '') +
				 isnull(perstd.facultyNameEN, '') +
				 isnull(perstd.programCode, '') +
				 isnull(perstd.programNameTH, '') +
				 isnull(perstd.programNameEN, '')) like
				('%' + @keyword + '%')
			) and
			(schstp.typeGroup = @scholarshipsTypeGroup) and
			(schtst.acaYear = @scholarshipsYear) and
			(schtst.semester = @semester) and
			(
				(schtst.lotNo = @lotNo) or
				(schtst.lotNo is null and schtst.approveDate is null)
			) and
			(schtst.createDate is not null) and
			(
				(case when (schtst.contractDate is not null) then 'true' else 'false' end) =
				(
					case @scholarshipsTypeGroup
						when 'ICL' then 'true'
						else 'false'
					end
				)
			) and
			(schtst.tuition is not null) and
			(
				(len(@approveStatus) = 0) or
				(
					(len(@approveStatus) > 0) and
					(case when (schtst.approveDate is not null) then 'true' else 'false' end) =
					(
						case @approveStatus
							when 'Y' then 'true'
							when 'N' then 'false'
						end
					)										
				)		
			)
end