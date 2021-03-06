USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetListTranStudentFinanceScholarshipSavePeoplePayChequeWithAuthenStaff]    Script Date: 12/7/2561 14:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๑๗/๐๘/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลนักศึกษาที่อนุมัติรับเงินและจำแนกผู้รับเงินแล้วเตรียมบันทึกจ่ายเช็คตามสิทธิ์ผู้ใช้งาน>
-- Parameter
--	1. username			เป็น varchar	รับค่าชื่อผู้ใช้งาน
--	2. userlevel		เป็น varchar	รับค่าระดับผู้ใช้งาน
--	3. systemGroup		เป็น varchar	รับค่าชื่อระบบงาน
--	4. keyword			เป็น varchar	รับค่าคำค้น
--  5. payChequeYear	เป็น varchar	รับค่าปีที่จ่ายเช็ค
--  6. semester			เป็น varchar	รับค่าภาคเรียนที่จ่ายเช็ค
--  7. lotNo			เป็น varchar	รับค่างวดที่จ่าย / โอน
--  8. pvjvNo			เป็น varchar	รับค่าเลขที่ PV / JV
--  9. chequeNo			เป็น varchar	รับค่าเลขที่เช็ค
-- 10. groupReceiver	เป็น varchar	รับค่ากลุ่มผู้รับเงิน
-- 11. bankId			เป็น varchar	รับค่ารหัสธนาคาร
-- 12. payChequeStatus	เป็น varchar	รับค่าสถานะการบันทึกจ่ายเช็ค
-- 13. cancelStatus		เป็น varchar	รับค่าสถานะการยกเลิก
-- =============================================
ALTER procedure [dbo].[sp_schGetListTranStudentFinanceScholarshipSavePeoplePayChequeWithAuthenStaff]
(
	@username varchar(255) = null,
	@userlevel varchar(20) = null,
	@systemGroup varchar(50) = null,
	@keyword varchar(100) = null,
	@payChequeYear varchar(4) = null,
	@semester varchar(2) = null,
	@lotNo varchar(2) = null,
	@pvjvNo varchar(20) = null,
	@chequeNo varchar(20) = null,
	@groupReceiver varchar(2) = null,
	@bankId varchar(10) = null,
	@payChequeStatus varchar(1) = null,
	@cancelStatus varchar(1) = null
)
as
begin
	set concat_null_yields_null off
	
	set @username = ltrim(rtrim(isnull(@username, '')))
	set @userlevel = ltrim(rtrim(isnull(@userlevel, '')))
	set @systemGroup = ltrim(rtrim(isnull(@systemGroup, '')))
	set @keyword = ltrim(rtrim(isnull(@keyword, '')))
	set @payChequeYear = ltrim(rtrim(isnull(@payChequeYear, '')))
	set @semester = ltrim(rtrim(isnull(@semester, '')))
	set @lotNo = ltrim(rtrim(isnull(@lotNo, '')))
	set @pvjvNo = ltrim(rtrim(isnull(@pvjvNo, '')))
	set @chequeNo = ltrim(rtrim(isnull(@chequeNo, '')))
	set @groupReceiver = ltrim(rtrim(isnull(@groupReceiver, '')))
	set @bankId	= ltrim(rtrim(isnull(@bankId,  '')))
	set @payChequeStatus = ltrim(rtrim(isnull(@payChequeStatus, '')))
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
			schtst.schGroupReceiverId,
			schtst.tuition,
			schtst.createDate as registerDate,
			schtst.contractDate,
			schtst.approveDate,
			schtst.transferDate,
			schtst.chequeId,
			schtst.chequeDate,
			schche.chequeNo,
			schche.lotNo as schChequeLotNo,
			schche.PVJVNo,
			plcbnk.id as bankId,
			perbac.bankCode,
			schtst.cancelStatus
	from	schTranStudent as schtst with(nolock) inner join
			vw_schGetListPersonStudent as perstd with(nolock) on schtst.studentId = perstd.studentId left join
			schScholarships as schsch with(nolock) on schtst.schId = schsch.id left join
			schScholarshipsType as schstp with(nolock) on schsch.type = schstp.type left join
			schGroupReceiver as schgrc with(nolock) on schtst.schGroupReceiverId = schgrc.id left join
			schGroupReceiver as schgcr with(nolock) on perstd.facultyId = schgcr.acaFacultyId left join
			perBankAccount as perbac with(nolock) on perstd.id = perbac.perPersonId left join
			plcBank as plcbnk with(nolock) on perbac.bankCode = plcbnk.code left join
			schCheque as schche with(nolock) on schtst.chequeId = (schche.acaYear + convert(varchar, schche.semester) + convert(varchar, schche.lotNo) + schche.PVJVNo + schche.chequeNo)
	where	(@userFaculty = 'MU-01' or perstd.facultyId = @userFaculty) and
			(len(@userProgram) = 0 or perstd.programId = @userProgram) and
			((len(@cancelStatus) = 0 and schtst.cancelStatus is null) or schtst.cancelStatus = @cancelStatus) and
			(schsch.schStatus = 'Y') and
			(schgrc.cancelStatus is null) and
			(schgcr.cancelStatus is null) and
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
			(schtst.acaYear = @payChequeYear) and
			(schtst.semester = @semester) and
			(
				(schtst.chequeId = (@payChequeYear + @semester + @lotNo + @pvjvNo + @chequeNo)) or
				(schtst.chequeId is null and schtst.chequeDate is null)
			) and
			(plcbnk.id = @bankId) and
			(schtst.schGroupReceiverId = @groupReceiver) and
			(schtst.createDate is not null) and 
			(schtst.contractDate is not null) and
			(schtst.lotNo is not null) and
			(schtst.approveDate is not null) and
			(schtst.transferDate is not null) and
			(
				(len(@payChequeStatus) = 0) or
				(
					(len(@payChequeStatus) > 0) and
					(case when (schtst.chequeId is not null and schtst.chequeDate is not null) then 'true' else 'false' end) =
					(
						case @payChequeStatus
							when 'Y' then 'true'
							when 'N' then 'false'
						end
					)										
				)		
			)
end