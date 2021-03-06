USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetApprovalReceiveFinance]    Script Date: 12/7/2561 14:05:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๐๔/๐๗/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลรายการเงินทุนที่ได้รับอนุมัติ>
-- Parameter
--  1. scholarshipsTypeGroup	เป็น varchar	รับค่าประเภททุน
--  2. scholarshipsYear			เป็น varchar	รับค่าปีที่อนุมัติรับเงิน
--  3. semester					เป็น varchar	รับค่าภาคเรียนที่อนุมัติรับเงิน
--  4. lotNo					เป็น varchar	รับค่างวดที่
-- =============================================
ALTER procedure [dbo].[sp_schGetApprovalReceiveFinance]
(
	@scholarshipsTypeGroup varchar(30) = null,
	@scholarshipsYear varchar(4) = null,
	@semester varchar(2) = null,
	@lotNo varchar(2) = null
)
as
begin
	set concat_null_yields_null off
	
	set @scholarshipsTypeGroup = ltrim(rtrim(isnull(@scholarshipsTypeGroup, '')))
	set @scholarshipsYear = ltrim(rtrim(isnull(@scholarshipsYear, '')))
	set @semester = ltrim(rtrim(isnull(@semester, '')))
	set @lotNo = ltrim(rtrim(isnull(@lotNo, '')))
	
	select	 schstp.typeGroup as schScholarshipsTypeGroup,
			 schtst.acaYear,
			 schtst.semester,
			 schtst.lotNo,
			 count(schtst.studentCode) as totalApprove,
			 sum(schtst.tuition) as totalTuition
	into	 #tmp1
	from	 schTranStudent as schtst with(nolock) inner join
			 vw_schGetListPersonStudent as perstd with(nolock) on schtst.studentId = perstd.studentId left join
			 schScholarships as schsch with(nolock) on schtst.schId = schsch.id left join
			 schScholarshipsType as schstp with(nolock) on schsch.type = schstp.type
	where	 (schsch.schStatus = 'Y') and
			 (schstp.typeGroup = @scholarshipsTypeGroup) and
			 (schtst.createDate is not null) and
			 (schtst.contractDate is not null) and
			 (schtst.lotNo is not null) and
			 (schtst.approveDate is not null)
	group by schstp.typeGroup,
			 schtst.acaYear,
			 schtst.semester,
			 schtst.lotNo

	select	scharf.schScholarshipsTypeGroup,
			scharf.acaYear as scholarshipsYear,
			scharf.semester,
			case scharf.semester
				when 1 then (convert(varchar, scharf.semester) + ' ( ภาคต้น )')
				when 2 then (convert(varchar, scharf.semester) + ' ( ภาคปลาย )')
				when 3 then (convert(varchar, scharf.semester) + ' ( ภาคฤดูร้อน )')
			end as semesterNameTH,
			case scharf.semester
				WHEN 1 then (convert(varchar, scharf.semester) + ' ( First Semester )')
				WHEN 2 then (convert(varchar, scharf.semester) + ' ( Final Semester )')
				WHEN 3 then (convert(varchar, scharf.semester) + ' ( Summer )')
			end as semesterNameEN,
			scharf.lotNo,
			scharf.deliverNo,
			scharf.deliverDate,
			scharf.amount,
			tbtmp1.totalTuition,
			scharf.approveNumber,
			tbtmp1.totalApprove,
			scharf.approveDate,
			scharf.cancelStatus
	from	schApprovalReceiveFinance as scharf with(nolock) left join
			#tmp1 as tbtmp1 on (scharf.schScholarshipsTypeGroup = tbtmp1.schScholarshipsTypeGroup and scharf.acaYear = tbtmp1.acaYear and scharf.semester = tbtmp1.semester and scharf.lotNo = tbtmp1.lotNo)
	where	(scharf.schScholarshipsTypeGroup = @scholarshipsTypeGroup) and
			(scharf.acaYear = @scholarshipsYear) and
			(scharf.semester = @semester) and
			(scharf.lotNo = @lotNo)
end