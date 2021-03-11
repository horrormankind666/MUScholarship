using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

public class SCHFinanceScholarshipUtil
{
    public class ICLUtil
    {
        public class ApprovalReceiveFinanceUtil
        {
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                StringBuilder _list = new StringBuilder();
                StringBuilder _navPage = new StringBuilder();
                string _page = String.Empty;

                _ds                 = SCHDB.GetListApprovalReceiveFinance(_paramSearch);
                _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                _recordCount        = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                if (_paramSearch["ScholarshipsTypeGroup"].Equals(SCHUtil.SUBJECT_ICL))
                {
                    _list   = SCHFinanceScholarshipUI.ICLUI.ApprovalReceiveFinanceUI.ListUI.GetMain(_dr);
                    _page   = SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_MAIN;
                }
                _navPage            = SCHUtil.GetNavPage(_recordCount, (int)(_paramSearch["CurrentPage"]), _page, (int)(_paramSearch["RowPerPage"]));

                _ds.Dispose();

                _searchResult.Add("RecordCount",        _recordCount);
                _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
                _searchResult.Add("Sum",                0);
                _searchResult.Add("List",               _list);
                _searchResult.Add("NavPage",            _navPage);

                return _searchResult;
            }

            public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
            {
                DataRow _dr = null;

                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                        _dr = _ds.Tables[0].Rows[0];
                }
                
                _dataRecorded.Add("ScholarshipsTypeGroup",  (_dr != null && !String.IsNullOrEmpty(_dr["schScholarshipsTypeGroup"].ToString()) ? _dr["schScholarshipsTypeGroup"] : String.Empty));
                _dataRecorded.Add("ScholarshipsYear",       (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsYear"].ToString()) ? _dr["scholarshipsYear"] : String.Empty));
                _dataRecorded.Add("Semester",               (_dr != null && !String.IsNullOrEmpty(_dr["semester"].ToString()) ? _dr["semester"] : String.Empty));
                _dataRecorded.Add("SemesterNameTH",         (_dr != null && !String.IsNullOrEmpty(_dr["semesterNameTH"].ToString()) ? _dr["semesterNameTH"] : String.Empty));
                _dataRecorded.Add("SemesterNameEN",         (_dr != null && !String.IsNullOrEmpty(_dr["semesterNameEN"].ToString()) ? _dr["semesterNameEN"] : String.Empty));
                _dataRecorded.Add("LotNo",                  (_dr != null && !String.IsNullOrEmpty(_dr["lotNo"].ToString()) ? _dr["lotNo"] : String.Empty));
                _dataRecorded.Add("DeliverNo",              (_dr != null && !String.IsNullOrEmpty(_dr["deliverNo"].ToString()) ? _dr["deliverNo"] : String.Empty));
                _dataRecorded.Add("DeliverDate",            (_dr != null && !String.IsNullOrEmpty(_dr["deliverDate"].ToString()) ? DateTime.Parse(_dr["deliverDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                _dataRecorded.Add("Amount",                 (_dr != null && !String.IsNullOrEmpty(_dr["amount"].ToString()) ? double.Parse(_dr["amount"].ToString()).ToString("#,##0.00") : String.Empty));
                _dataRecorded.Add("TotalTuition",           (_dr != null && !String.IsNullOrEmpty(_dr["totalTuition"].ToString()) ? double.Parse(_dr["totalTuition"].ToString()).ToString("#,##0.00") : String.Empty));
                _dataRecorded.Add("ApproveNumber",          (_dr != null && !String.IsNullOrEmpty(_dr["approveNumber"].ToString()) ? double.Parse(_dr["approveNumber"].ToString()).ToString("#,##0") : String.Empty));
                _dataRecorded.Add("TotalApprove",           (_dr != null && !String.IsNullOrEmpty(_dr["totalApprove"].ToString()) ? double.Parse(_dr["totalApprove"].ToString()).ToString("#,##0") : String.Empty));
                _dataRecorded.Add("ApproveDate",            (_dr != null && !String.IsNullOrEmpty(_dr["approveDate"].ToString()) ? DateTime.Parse(_dr["approveDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));            

                return _dataRecorded;
            }
        }
        
        public class SavePeopleApprovedUtil
        {
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                string _username = _loginResult["Username"].ToString();
                string _userlevel = _loginResult["Userlevel"].ToString();
                string _systemGroup = _loginResult["SystemGroup"].ToString();
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                object _sum = 0;
                StringBuilder _list = new StringBuilder();

                _ds                 = SCHDB.GetListTranStudentFinanceScholarshipSavePeopleApproved(_username, _userlevel, _systemGroup, _paramSearch);               
                _dr                 = _ds.Tables[0].Select();
                _recordCount        = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                _sum                = _ds.Tables[0].Compute("SUM(tuition)", "");
                _list               = SCHFinanceScholarshipUI.ICLUI.SavePeopleApprovedUI.ListUI.GetMain(_dr);

                _ds.Dispose();

                _searchResult.Add("RecordCount",        _recordCount);
                _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
                _searchResult.Add("Sum",                (!String.IsNullOrEmpty(_sum.ToString()) ? _sum : 0));
                _searchResult.Add("List",               _list);
                _searchResult.Add("NavPage",            new StringBuilder());

                return _searchResult;
            }
        }

        public class ClassificationRecipientFinanceUtil
        {
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                string _username = _loginResult["Username"].ToString();
                string _userlevel = _loginResult["Userlevel"].ToString();
                string _systemGroup = _loginResult["SystemGroup"].ToString();
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                object _sum = 0;
                StringBuilder _list = new StringBuilder();
                StringBuilder _navPage = new StringBuilder();
                
                _ds                 = SCHDB.GetListTranStudentFinanceScholarshipClassificationRecipient(_username, _userlevel, _systemGroup, _paramSearch);                               
                _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                _recordCount        = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                _sum                = _ds.Tables[0].Compute("SUM(tuition)", "");                
                _list               = SCHFinanceScholarshipUI.ICLUI.ClassificationRecipientFinanceUI.ListUI.GetMain(_dr);
                _navPage            = SCHUtil.GetNavPage(_recordCount, (int)(_paramSearch["CurrentPage"]), SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_MAIN, (int)(_paramSearch["RowPerPage"]));

                _ds.Dispose();
                
                _searchResult.Add("RecordCount",        _recordCount);
                _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
                _searchResult.Add("Sum",                (!String.IsNullOrEmpty(_sum.ToString()) ? _sum : 0));
                _searchResult.Add("List",               _list);
                _searchResult.Add("NavPage",            _navPage);

                return _searchResult;
            }
        }

        public class PayChequeUtil
        {
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                StringBuilder _list = new StringBuilder();
                StringBuilder _navPage = new StringBuilder();
                
                _ds                 = SCHDB.GetListCheque(_paramSearch);
                _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                _recordCount        = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                _list               = SCHFinanceScholarshipUI.ICLUI.PayChequeUI.ListUI.GetMain(_dr);
                _navPage            = SCHUtil.GetNavPage(_recordCount, (int)(_paramSearch["CurrentPage"]), SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_MAIN, (int)(_paramSearch["RowPerPage"]));               

                _ds.Dispose();

                _searchResult.Add("RecordCount",        _recordCount);
                _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
                _searchResult.Add("Sum",                0);
                _searchResult.Add("List",               _list);
                _searchResult.Add("NavPage",            _navPage);

                return _searchResult;
            }

            public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
            {
                DataRow _dr = null;

                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                        _dr = _ds.Tables[0].Rows[0];
                }
                
                _dataRecorded.Add("PayChequeYear",          (_dr != null && !String.IsNullOrEmpty(_dr["payChequeYear"].ToString()) ? _dr["payChequeYear"] : String.Empty));
                _dataRecorded.Add("Semester",               (_dr != null && !String.IsNullOrEmpty(_dr["semester"].ToString()) ? _dr["semester"] : String.Empty));
                _dataRecorded.Add("SemesterNameTH",         (_dr != null && !String.IsNullOrEmpty(_dr["semesterNameTH"].ToString()) ? _dr["semesterNameTH"] : String.Empty));
                _dataRecorded.Add("SemesterNameEN",         (_dr != null && !String.IsNullOrEmpty(_dr["semesterNameEN"].ToString()) ? _dr["semesterNameEN"] : String.Empty));
                _dataRecorded.Add("LotNo",                  (_dr != null && !String.IsNullOrEmpty(_dr["lotNo"].ToString()) ? _dr["lotNo"] : String.Empty));
                _dataRecorded.Add("PVJVNo",                 (_dr != null && !String.IsNullOrEmpty(_dr["PVJVNo"].ToString()) ? _dr["PVJVNo"] : String.Empty));
                _dataRecorded.Add("ChequeNo",               (_dr != null && !String.IsNullOrEmpty(_dr["chequeNo"].ToString()) ? _dr["chequeNo"] : String.Empty));
                _dataRecorded.Add("GroupReceiverId",        (_dr != null && !String.IsNullOrEmpty(_dr["schGroupReceiverId"].ToString()) ? _dr["schGroupReceiverId"] : String.Empty));
                _dataRecorded.Add("GroupReceiverNameTH",    (_dr != null && !String.IsNullOrEmpty(_dr["groupReceiverNameTH"].ToString()) ? _dr["groupReceiverNameTH"] : String.Empty));
                _dataRecorded.Add("GroupReceiverNameEN",    (_dr != null && !String.IsNullOrEmpty(_dr["groupReceiverNameEN"].ToString()) ? _dr["groupReceiverNameEN"] : String.Empty));
                _dataRecorded.Add("Amount",                 (_dr != null && !String.IsNullOrEmpty(_dr["amount"].ToString()) ? double.Parse(_dr["amount"].ToString()).ToString("#,##0.00") : String.Empty));
                _dataRecorded.Add("TotalTuition",           (_dr != null && !String.IsNullOrEmpty(_dr["totalTuition"].ToString()) ? double.Parse(_dr["totalTuition"].ToString()).ToString("#,##0.00") : String.Empty));
                _dataRecorded.Add("ReceiverNumber",         (_dr != null && !String.IsNullOrEmpty(_dr["receiverNumber"].ToString()) ? double.Parse(_dr["receiverNumber"].ToString()).ToString("#,##0") : String.Empty));
                _dataRecorded.Add("TotalRecipient",         (_dr != null && !String.IsNullOrEmpty(_dr["totalRecipient"].ToString()) ? double.Parse(_dr["totalRecipient"].ToString()).ToString("#,##0") : String.Empty));
                _dataRecorded.Add("BankId",                 (_dr != null && !String.IsNullOrEmpty(_dr["plcBankId"].ToString()) ? _dr["plcBankId"] : String.Empty));
                _dataRecorded.Add("BankCode",               (_dr != null && !String.IsNullOrEmpty(_dr["bankCode"].ToString()) ? _dr["bankCode"] : String.Empty));
                _dataRecorded.Add("PaidDate",               (_dr != null && !String.IsNullOrEmpty(_dr["paidDate"].ToString()) ? DateTime.Parse(_dr["paidDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                _dataRecorded.Add("PrepareDate",            (_dr != null && !String.IsNullOrEmpty(_dr["prepareDate"].ToString()) ? DateTime.Parse(_dr["prepareDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));            

                return _dataRecorded;
            }
        }

        public class SavePeoplePayChequeUtil
        {
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                string _username = _loginResult["Username"].ToString();
                string _userlevel = _loginResult["Userlevel"].ToString();
                string _systemGroup = _loginResult["SystemGroup"].ToString();
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                object _sum = 0;
                StringBuilder _list = new StringBuilder();

                _ds                 = SCHDB.GetListTranStudentFinanceScholarshipSavePeoplePayCheque(_username, _userlevel, _systemGroup, _paramSearch);               
                _dr                 = _ds.Tables[0].Select();
                _recordCount        = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                _sum                = _ds.Tables[0].Compute("SUM(tuition)", "");
                _list               = SCHFinanceScholarshipUI.ICLUI.SavePeoplePayChequeUI.ListUI.GetMain(_dr);

                _ds.Dispose();

                _searchResult.Add("RecordCount",        _recordCount);
                _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
                _searchResult.Add("Sum",                (!String.IsNullOrEmpty(_sum.ToString()) ? _sum : 0));
                _searchResult.Add("List",               _list);
                _searchResult.Add("NavPage",            new StringBuilder());

                return _searchResult;
            }
        }

        public class StudentCVUtil
        {
            public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
            {
                DataRow _dr = null;

                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                        _dr = _ds.Tables[0].Rows[0];
                }

                _dataRecorded.Add("ScholarshipsYear",       (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsYear"].ToString()) ? _dr["scholarshipsYear"] : String.Empty));
                _dataRecorded.Add("Semester",               (_dr != null && !String.IsNullOrEmpty(_dr["semester"].ToString()) ? _dr["semester"] : String.Empty));
                _dataRecorded.Add("ScholarshipsId",         (_dr != null && !String.IsNullOrEmpty(_dr["schScholarshipsId"].ToString()) ? _dr["schScholarshipsId"] : String.Empty));
                _dataRecorded.Add("ScholarshipsNameTH",     (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsNameTH"].ToString()) ? _dr["scholarshipsNameTH"] : String.Empty));
                _dataRecorded.Add("ScholarshipsNameEN",     (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsNameEN"].ToString()) ? _dr["scholarshipsNameEN"] : String.Empty));
                _dataRecorded.Add("ScholarshipsTypeId",     (_dr != null && !String.IsNullOrEmpty(_dr["schScholarshipsTypeId"].ToString()) ? _dr["schScholarshipsTypeId"] : String.Empty));
                _dataRecorded.Add("ScholarshipsTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsTypeNameTH"].ToString()) ? _dr["scholarshipsTypeNameTH"] : String.Empty));
                _dataRecorded.Add("ScholarshipsTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsTypeNameEN"].ToString()) ? _dr["scholarshipsTypeNameEN"] : String.Empty));
                _dataRecorded.Add("ScholarshipsTypeGroup",  (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsTypeGroup"].ToString()) ? _dr["scholarshipsTypeGroup"] : String.Empty));
                _dataRecorded.Add("ResponsibleAgency",      (_dr != null && !String.IsNullOrEmpty(_dr["responsibleAgency"].ToString()) ? _dr["responsibleAgency"] : String.Empty));
                _dataRecorded.Add("RegisCase",              (_dr != null && !String.IsNullOrEmpty(_dr["regisCase"].ToString()) ? _dr["regisCase"] : String.Empty));
                _dataRecorded.Add("RegisCaseNameTH",        (_dr != null && !String.IsNullOrEmpty(_dr["regisCaseNameTH"].ToString()) ? _dr["regisCaseNameTH"] : String.Empty));
                _dataRecorded.Add("RegisCaseNameEN",        (_dr != null && !String.IsNullOrEmpty(_dr["regisCaseNameEN"].ToString()) ? _dr["regisCaseNameEN"] : String.Empty));
                _dataRecorded.Add("Tuition",                (_dr != null && !String.IsNullOrEmpty(_dr["tuition"].ToString()) ? _dr["tuition"] : String.Empty));
                _dataRecorded.Add("TotalTuition",           (_dr != null && !String.IsNullOrEmpty(_dr["totalTuition"].ToString()) ? _dr["totalTuition"] : String.Empty));
                _dataRecorded.Add("InvoiceNo",              (_dr != null && !String.IsNullOrEmpty(_dr["invoiceNo"].ToString()) ? _dr["invoiceNo"] : String.Empty));
                _dataRecorded.Add("InvoiceAmount",          (_dr != null && !String.IsNullOrEmpty(_dr["invoiceAmount"].ToString()) ? _dr["invoiceAmount"] : String.Empty));
                _dataRecorded.Add("StdPayAmount",           (_dr != null && !String.IsNullOrEmpty(_dr["stdPayAmount"].ToString()) ? _dr["stdPayAmount"] : String.Empty));
                _dataRecorded.Add("GroupReceiverNameTH",    (_dr != null && !String.IsNullOrEmpty(_dr["groupReceiverNameTH"].ToString()) ? _dr["groupReceiverNameTH"] : String.Empty));
                _dataRecorded.Add("GroupReceiverNameEN",    (_dr != null && !String.IsNullOrEmpty(_dr["groupReceiverNameEN"].ToString()) ? _dr["groupReceiverNameEN"] : String.Empty));
                _dataRecorded.Add("RatePerYear",            (_dr != null && !String.IsNullOrEmpty(_dr["ratePerYear"].ToString()) ? _dr["ratePerYear"] : String.Empty));
                _dataRecorded.Add("DiscountAmount",         (_dr != null && !String.IsNullOrEmpty(_dr["discountAmount"].ToString()) ? _dr["discountAmount"] : String.Empty));
                _dataRecorded.Add("RatePerYearRemain",      (_dr != null && !String.IsNullOrEmpty(_dr["ratePerYearRemain"].ToString()) ? _dr["ratePerYearRemain"] : String.Empty));
                _dataRecorded.Add("RegisterDate",           (_dr != null && !String.IsNullOrEmpty(_dr["registerDate"].ToString()) ? _dr["registerDate"] : String.Empty));
                _dataRecorded.Add("ContractDate",           (_dr != null && !String.IsNullOrEmpty(_dr["contractDate"].ToString()) ? _dr["contractDate"] : String.Empty));
                _dataRecorded.Add("ApproveDate",            (_dr != null && !String.IsNullOrEmpty(_dr["approveDate"].ToString()) ? _dr["approveDate"] : String.Empty));
                _dataRecorded.Add("TransferDate",           (_dr != null && !String.IsNullOrEmpty(_dr["transferDate"].ToString()) ? _dr["transferDate"] : String.Empty));
                _dataRecorded.Add("CancelStatus",           (_dr != null && !String.IsNullOrEmpty(_dr["cancelStatus"].ToString()) ? _dr["cancelStatus"] : String.Empty));
                _dataRecorded.Add("Reason",                 (_dr != null && !String.IsNullOrEmpty(_dr["remark"].ToString()) ? _dr["remark"] : String.Empty));
                _dataRecorded.Add("TotalCredit",            (_dr != null && !String.IsNullOrEmpty(_dr["totalCredit"].ToString()) ? _dr["totalCredit"] : String.Empty));

                return _dataRecorded;
            }
        }
    }
}