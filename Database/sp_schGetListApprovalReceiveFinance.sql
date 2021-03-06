USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetListApprovalReceiveFinance]    Script Date: 12/7/2561 14:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๒๓/๐๖/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลรายการเงินทุนที่ได้รับอนุมัติ>
-- Parameter
--  1. scholarshipsTypeGroup	เป็น varchar	รับค่าประเภททุน
--  2. scholarshipsYear			เป็น varchar	รับค่าปีที่อนุมัติรับเงิน
--  3. semester					เป็น varchar	รับค่าภาคเรียนที่อนุมัติรับเงิน
--  4. cancelStatus				เป็น varchar	รับค่าสถานะการยกเลิก
-- =============================================
ALTER procedure [dbo].[sp_schGetListApprovalReceiveFinance]
(
	@scholarshipsTypeGroup varchar(30) = null,
	@scholarshipsYear varchar(4) = null,
	@semester varchar(2) = null,
	@cancelStatus varchar(1) = null
)
as
begin
	set concat_null_yields_null off

	set @scholarshipsTypeGroup = ltrim(rtrim(isnull(@scholarshipsTypeGroup, '')))
	set @scholarshipsYear = ltrim(rtrim(isnull(@scholarshipsYear, '')))
	set @semester = ltrim(rtrim(isnull(@semester, '')))
	set @cancelStatus = ltrim(rtrim(isnull(@cancelStatus, '')))

	select	 schstp.typeGroup as schScholarshipsTypeGroup,
			 schtst.acaYear,
			 schtst.semester,
			 schtst.lotNo,
			 count(schtst.studentCode) as totalApprove
	into	 #tmp1
	from	 schTranStudent as schtst with(nolock) INNER JOIN
			 vw_schGetListPersonStudent as perstd with(nolock) on schtst.studentId = perstd.studentId left join
			 schScholarships as schsch with(nolock) on schtst.schId = schsch.id left join
			 schScholarshipsType as schstp with(nolock) on schsch.type = schstp.type
	where	 (schtst.cancelStatus is null) and
			 (schsch.schStatus = 'Y') and			 
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
			scharf.lotNo,
			scharf.deliverNo,
			scharf.deliverDate,
			scharf.amount,
			scharf.approveNumber,
			isnull(tbtmp1.totalApprove, 0) as totalApprove,
			scharf.approveDate,
			scharf.cancelStatus
	into	#tmp2
	from	schApprovalReceiveFinance as scharf with(nolock) left join
			#tmp1 as tbtmp1 on (scharf.schScholarshipsTypeGroup = tbtmp1.schScholarshipsTypeGroup and scharf.acaYear = tbtmp1.acaYear and scharf.semester = tbtmp1.semester and scharf.lotNo = tbtmp1.lotNo)
	where	(scharf.schScholarshipsTypeGroup = @scholarshipsTypeGroup) and
			(len(@scholarshipsYear) = 0 or scharf.acaYear = @scholarshipsYear) and
			(len(@scholarshipsYear) = 0 or scharf.semester = @semester) and
			(len(@cancelStatus) = 0 or scharf.cancelStatus = @cancelStatus)
	
	select	row_number() over(order by tbtmp2.scholarshipsYear desc, tbtmp2.semester desc, tbtmp2.lotNo desc) as rowNum,
			*
	from	#tmp2 as tbtmp2
	
	select	max(tbtmp2.lotNo) as maxLotNo
	from	#tmp2 as tbtmp2
end