USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetListCheque]    Script Date: 12/7/2561 14:10:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๒๖/๐๗/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลรายการจ่ายเช็ค>
-- Parameter
--  1. payChequeYear	เป็น varchar	รับค่าปีที่จ่ายเช็ค
--  2. semester			เป็น varchar	รับค่าภาคเรียนที่จ่ายเช็ค
--  3. cancelStatus		เป็น varchar	รับค่าสถานะการยกเลิก
-- =============================================
ALTER procedure [dbo].[sp_schGetListCheque]
(
	@payChequeYear varchar(4) = null,
	@semester varchar(2) = null,
	@cancelStatus varchar(1) = null
)
as
begin
	set concat_null_yields_null off

	set @payChequeYear = ltrim(rtrim(isnull(@payChequeYear, '')))
	set @semester = ltrim(rtrim(isnull(@semester, '')))
	set @cancelStatus = ltrim(rtrim(isnull(@cancelStatus, '')))

	select	 schtst.chequeId,
			 count(schtst.studentCode) as totalRecipient
	into	 #tmp1
	from	 schTranStudent as schtst with(nolock) inner join
			 vw_schGetListPersonStudent as perstd with(nolock) on schtst.studentId = perstd.studentId left join
			 schScholarships as schsch with(nolock) on schtst.schId = schsch.id left join
			 schScholarshipsType as schstp with(nolock) on schsch.type = schstp.type
	where	 (schtst.cancelStatus is null) and
			 (schsch.schStatus = 'Y') and
			 (schtst.createDate is not null) and
			 (schtst.approveDate is not null) and
			 (schtst.transferDate is not null) and
			 (schtst.schGroupReceiverId is not null) and
			 (schtst.chequeId is not null) and
			 (schtst.chequeDate is not null)
	group by schtst.chequeId

	select	row_number() over(order by schche.acaYear desc, schche.semester desc, schche.lotNo desc) as rowNum,
			schche.acaYear as payChequeYear,
			schche.semester,
			schche.lotNo,
			schche.PVJVNo,
			schche.chequeNo,
			schche.schGroupReceiverId,
			schgrc.nameTH as groupReceiverNameTH,
			schgrc.nameEN as groupReceiverNameEN,
			schche.amount,
			schche.receiverNumber,
			isnull(tbtmp1.totalRecipient, 0) as totalRecipient,
			schche.plcBankId,
			plcbnk.code as bankCode,
			schche.paidDate,
			schche.prepareDate,
			schche.cancelStatus
	from	schCheque as schche with(nolock) left join
			schGroupReceiver as schgrc with(nolock) on schche.schGroupReceiverId = schgrc.id left join
			plcBank as plcbnk with(nolock) on schche.plcBankId = plcbnk.id left join
			#tmp1 as tbtmp1 on ((schche.acaYear + convert(varchar, schche.semester) + convert(varchar, schche.lotNo) + schche.PVJVNo + schche.chequeNo) = tbtmp1.chequeId)
	where	(len(@payChequeYear) = 0 or schche.acaYear = @payChequeYear) and
			(len(@semester) = 0 or schche.semester = @semester) and
			(len(@cancelStatus) = 0 or schche.cancelStatus = @cancelStatus)
end
