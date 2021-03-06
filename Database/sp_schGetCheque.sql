USE [Infinity]
GO
/****** Object:  StoredProcedure [dbo].[sp_schGetCheque]    Script Date: 12/7/2561 14:08:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: <ยุทธภูมิ ตวันนา>
-- Create date	: <๓๐/๐๗/๒๕๖๐>
-- Description	: <สำหรับแสดงข้อมูลรายการจ่ายเช็ค>
-- Parameter
--  1. payChequeYear	เป็น varchar	รับค่าปีที่จ่ายเช็ค
--  2. semester			เป็น varchar	รับค่าภาคเรียนที่จ่ายเช็ค
--  3. lotNo			เป็น varchar	รับค่างวดที่จ่าย / โอน
--  4. pvjvNo			เป็น varchar	รับค่าเลขที่ PV / JV
--  5. chequeNo			เป็น varchar	รับค่าเลขที่เช็ค
-- =============================================
ALTER procedure [dbo].[sp_schGetCheque]
(
	@payChequeYear varchar(4) = null,
	@semester varchar(2) = null,
	@lotNo varchar(2) = null,
	@pvjvNo varchar(20) = null,
	@chequeNo varchar(20) = null
)
as
begin
	set concat_null_yields_null off

	set @payChequeYear = ltrim(rtrim(isnull(@payChequeYear, '')))
	set @semester = ltrim(rtrim(isnull(@semester, '')))
	set @lotNo = ltrim(rtrim(isnull(@lotNo, '')))
	set @pvjvNo = ltrim(rtrim(isnull(@pvjvNo, '')))
	set @chequeNo = ltrim(rtrim(isnull(@chequeNo, '')))

	select	 schtst.chequeId,
			 count(schtst.studentCode) as totalRecipient,
			 sum(schtst.tuition) as totalTuition
	into	 #tmp1
	from	 schTranStudent as schtst with(nolock) inner join
			 vw_schGetListPersonStudent as perstd with(nolock) on schtst.studentId = perstd.studentId left join
			 schScholarships as schsch with(nolock) on schtst.schId = schsch.id left join
			 schScholarshipsType as schstp with(nolock) on schsch.type = schstp.type
	where	 (schsch.schStatus = 'Y') and
			 (schtst.createDate is not null) and
			 (schtst.approveDate is not null) and
			 (schtst.transferDate is not null) and
			 (schtst.schGroupReceiverId is not null) and
			 (schtst.chequeId is not null) and
			 (schtst.chequeDate is not null)
	group by schtst.chequeId

	select	schche.acaYear as payChequeYear,
			schche.semester,
			case schche.semester
				when 1 then (convert(varchar, schche.semester) + ' ( ภาคต้น )')
				when 2 then (convert(varchar, schche.semester) + ' ( ภาคปลาย )')
				when 3 then (convert(varchar, schche.semester) + ' ( ภาคฤดูร้อน )')
			end as semesterNameTH,
			case schche.semester
				when 1 then (convert(varchar, schche.semester) + ' ( First Semester )')
				when 2 then (convert(varchar, schche.semester) + ' ( Final Semester )')
				when 3 then (convert(varchar, schche.semester) + ' ( Summer )')
			end as semesterNameEN,
			schche.lotNo,
			schche.PVJVNo,
			schche.chequeNo,
			schche.schGroupReceiverId,
			schgrc.nameTH as groupReceiverNameTH,
			schgrc.nameEN as groupReceiverNameEN,
			schche.amount,
			isnull(tbtmp1.totalTuition, 0) as totalTuition,
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
	where	(schche.acaYear = @payChequeYear) and
			(schche.semester = @semester) and
			(schche.lotNo = @lotNo) and
			(schche.PVJVNo = @pvjvNo) and
			(schche.chequeNo = @chequeNo)
end
