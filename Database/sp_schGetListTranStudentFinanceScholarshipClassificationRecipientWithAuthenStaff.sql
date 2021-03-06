USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetListTranStudentFinanceScholarshipClassificationRecipientWithAuthenStaff]    Script Date: 12/7/2561 14:12:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๑๗/๐๘/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลนักศึกษาที่อนมุัติรับเงินแล้วเตรียมบันทึกจำแนกผู้รับเงินตามสิทธิ์ผู้ใช้งาน>
-- Parameter
--	1. username					เป็น varchar	รับค่าชื่อผู้ใช้งาน
--	2. userlevel				เป็น varchar	รับค่าระดับผู้ใช้งาน
--	3. systemGroup				เป็น varchar	รับค่าชื่อระบบงาน
--	4. keyword					เป็น varchar	รับค่าคำค้น
--	5. facultyId				เป็น varchar	รับค่ารหัสคณะ
--	6. programId				เป็น varchar	รับค่าหลักสูตร
--  7. yearEntry				เป็น varchar	รับค่าปีที่เข้าศึกษา
--  8. scholarshipsTypeGroup	เป็น varchar	รับค่าประเภททุน
--  9. scholarshipsYear			เป็น varchar	รับค่าปีที่อนุมัติรับเงิน
-- 10. semester					เป็น varchar	รับค่าภาคเรียนที่อนุมัติรับเงิน
-- 11. lotNo					เป็น varchar	รับค่างวดที่
-- 12. groupReceiver			เป็น varchar	รับค่ากลุ่มผู้รับเงิน
-- 13. recipientStatus			เป็น varchar	รับค่าสถานะการจำแนกผู้รับเงิน
-- 14. cancelStatus				ป็น varchar	รับค่าสถานะการยกเลิก
-- =============================================
ALTER procedure [dbo].[sp_schGetListTranStudentFinanceScholarshipClassificationRecipientWithAuthenStaff]
(
	@username varchar(255) = null,
	@userlevel varchar(20) = null,
	@systemGroup varchar(50) = null,
	@keyword varchar(100) = null,
	@facultyId varchar(15) = null,
	@programId varchar(15) = null,
	@yearEntry varchar(4) = null,
	@scholarshipsTypeGroup varchar(30) = null,
	@scholarshipsYear varchar(4) = null,
	@semester varchar(2) = null,
	@lotNo varchar(2) = null,
	@groupReceiver varchar(2) = null,
	@recipientStatus varchar(1) = null,
	@cancelStatus varchar(1) = null
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
	set @scholarshipsTypeGroup = ltrim(rtrim(isnull(@scholarshipsTypeGroup, '')))
	set @scholarshipsYear = ltrim(rtrim(isnull(@scholarshipsYear, '')))
	set @semester = ltrim(rtrim(isnull(@semester, '')))
	set @lotNo = ltrim(rtrim(isnull(@lotNo, '')))
	set @groupReceiver = ltrim(rtrim(isnull(@groupReceiver, '')))
	set @recipientStatus = ltrim(rtrim(isnull(@recipientStatus, '')))
	set @cancelStatus = ltrim(rtrim(isnull(@cancelStatus, '')))

	declare	@userFaculty varchar(15) = null
	declare @userProgram varchar(15) = null
	declare @recipientMU varchar(2) = null
	declare @recipientStudent varchar(2) = null
	
	select	@userFaculty = autusr.facultyId,
			@userProgram = autusr.programId
	from	autUserAccessProgram as autusr with(nolock)
	where	(autusr.username = @username) and
			(autusr.level = @userlevel) and
			(autusr.systemGroup = @systemGroup)
	
	set @userFaculty = isnull(@userFaculty, '')
	set @userProgram = isnull(@userProgram, '')	

	select	@recipientMU = id
	from	schGroupReceiver as schgrc with(nolock)
	where	(acaFacultyId = 'MU-01') and
			(classify = 'Y')

	select	@recipientStudent = id
	from	schGroupReceiver as schgrc with(nolock)
	where	(acaFacultyId is null) and
			(classify = 'Y')

	select	 regtsr.studentCode,			
			 min(convert(int, regtsr.invoiceNo)) as invoiceNo
	into	 #tmp1
	from	 vwRegTransSubjectRegis as regtsr with(nolock)
	where	 (regtsr.regisType = 'N') and
			 (regtsr.acaYear = @scholarshipsYear) and
			 (regtsr.semester = @semester)
	group by regtsr.studentCode
	
	select	 regtsr.studentCode,
			 regtsr.acaYear,
			 regtsr.semester,
			 regtsr.invoiceNo,
			 regtsr.invoiceAmount,
			 regtsr.paidStatus,
			 regtsr.paidDate
	into	 #tmp2
	from	 schTranStudent as schtst with(nolock) inner join
			 vwRegTransSubjectRegis as regtsr with(nolock) on (regtsr.studentCode = schtst.studentCode and regtsr.acaYear = schtst.acaYear and regtsr.semester = schtst.semester) inner join
			 #tmp1 as tbtmp1 on (regtsr.studentCode = tbtmp1.studentCode and regtsr.invoiceNo = tbtmp1.invoiceNo)
	where	 (regtsr.regisType = 'N') and
			 (regtsr.acaYear = @scholarshipsYear) and
			 (regtsr.semester = @semester)
	group by regtsr.regisType,
			 regtsr.studentCode,
			 regtsr.acaYear,
			 regtsr.semester,
			 regtsr.invoiceNo,
			 regtsr.invoiceAmount,
			 regtsr.paidStatus,
			 regtsr.paidDate

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
			tbtmp2.invoiceAmount,
			tbtmp2.paidStatus,
			(
				case when schtst.schGroupReceiverId is null
					then
						(			
							case when schgcr.id is not null
								then
									schgcr.id
								else
									case when (tbtmp2.invoiceNo is not null and tbtmp2.paidStatus is null) 
										then @recipientMU
										else @recipientStudent
								end
							end
						)
					else
						schtst.schGroupReceiverId
				end
			) as schGroupReceiverId,
			schgrc.acaFacultyId as schGroupReceiverFacultyId,
			schtst.tuition,
			perstd.plcBankCode,
			perstd.accNo,
			perstd.plcBankNameTH,
			perstd.plcBankNameEN,
			schtst.createDate as registerDate,
			schtst.contractDate,
			schtst.approveDate,
			schtst.transferDate,
			schtst.cancelStatus
	into	#tmp3
	from	schTranStudent as schtst with(nolock) inner join
			vw_schGetListPersonStudent as perstd with(nolock) on schtst.studentId = perstd.studentId left join
			#tmp2 as tbtmp2 on (schtst.studentCode = tbtmp2.studentCode and schtst.acaYear = tbtmp2.acaYear and schtst.semester = tbtmp2.semester) left join
			schScholarships as schsch with(nolock) on schtst.schId = schsch.id left join
			schScholarshipsType as schstp with(nolock) on schsch.type = schstp.type left join
			schGroupReceiver as schgrc with(nolock) on schtst.schGroupReceiverId = schgrc.id left join
			schGroupReceiver as schgcr with(nolock) on perstd.facultyId = schgcr.acaFacultyId
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
			(len(@facultyId) = 0 or perstd.facultyId = @facultyId) and
			(len(@programId) = 0 or perstd.programId = @programId) and
			(len(@yearEntry) = 0 or perstd.yearEntry = @yearEntry) and
			(len(@scholarshipsTypeGroup) = 0 or schstp.typeGroup = @scholarshipsTypeGroup) and
			(len(@scholarshipsYear) = 0 or schtst.acaYear = @scholarshipsYear) and
			(len(@semester) = 0 or schtst.semester = @semester) and
			(len(@lotNo) = 0 or schtst.lotNo = @lotNo) and
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
			(schtst.approveDate is not null) and
			(
				(len(@recipientStatus) = 0) or
				(
					(len(@recipientStatus) > 0) and					
					(case when (schtst.transferDate is not null) then 'true' else 'false' end) =
					(
						case @recipientStatus
							when 'Y' then 'true'
							when 'N' then 'false'
						end
					)		
				)
			)

	select	row_number() over(order by tbtmp3.studentCode, tbtmp3.scholarshipsYear, tbtmp3.semester, tbtmp3.schScholarshipsId, tbtmp3.lotNo) as rowNum,
			tbtmp3.*,
			schgrc.nameTH as groupReceiverNameTH,
			schgrc.nameEN as groupReceiverNameEN
	from	#tmp3 as tbtmp3 left join
			schGroupReceiver as schgrc with(nolock) ON tbtmp3.schGroupReceiverId = schgrc.id
	where	(len(@groupReceiver) = 0 or tbtmp3.schGroupReceiverId = @groupReceiver)
end