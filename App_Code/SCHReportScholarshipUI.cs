using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;

public class SCHReportScholarshipUI
{
    public class MainUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_REPORTSCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("<div class='ui horizontal divider header container'>");
            _str.AppendLine("   <i class='area dashboard icon font-th regular black'></i>&nbsp;");
            _str.AppendLine("   <span class='lang lang-th f7 font-th regular black'>รายงาน</span>");
            _str.AppendLine("   <span class='lang lang-en f7 font-en regular black'>Report Scholarship</span>");
            _str.AppendLine("</div>");
            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
            _str.AppendLine("       <div class='fluid vertical item tabular ui menu'>");
            _str.AppendFormat("         <a class='item' data-tab='{0}'>", SCHUtil.SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL.ToLower());
            _str.AppendLine("               <span class='lang lang-th f9 font-th regular black'>รายชื่อผู้ที่ได้รับอนุมัติเงินจาก กรอ.</span>");
            _str.AppendLine("               <span class='lang lang-en f9 font-en regular black'>List of People Approved Finance From ICL</span>");
            _str.AppendLine("           </a>");
            _str.AppendLine("       </div>");
            _str.AppendFormat("     <div id='tab-{0}'></div>", SCHUtil.SUBJECT_REPORTSCHOLARSHIP.ToLower());
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");

            return _str;
        }
    }

    public class ListOfPeopleApprovedFinanceFromICLUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("<div>");
            _str.AppendLine("   <div class='ui form orange inverted segment'>");
            _str.AppendLine("       <div class='ui left floated header'>");
            _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>รายชื่อผู้ที่ได้รับอนุมัติเงินจาก กรอ.</span>");
            _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>List of People Approved Finance From ICL</span>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui right floated header'>");
            _str.AppendLine("           <i class='close icon link font-th regular white btnclose'></i>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui header'></div>");
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");
            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
            _str.AppendFormat("     <div id='{0}'>{1}</div>", SearchUI._idContent, SearchUI.GetMain());
            _str.AppendFormat("     <div id='{0}'></div>", ListUI._idContent);
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");

            return _str;
        }

        public class SearchUI
        {
            public static string _idContent = ("search-" + SCHUtil.SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL.ToLower());

            public static StringBuilder GetMain()
            {
                StringBuilder _str = new StringBuilder();

                _str.AppendLine("<div class='ui form blue inverted segment'>");
                _str.AppendLine("   <div class='ui left floated header'>");
                _str.AppendLine("       <span class='lang lang-th f9 font-th regular white'>ค้นหา</span>");
                _str.AppendLine("       <span class='lang lang-en f9 font-en regular white'>Search</span>");
                _str.AppendLine("   </div>");
                _str.AppendLine("   <div class='ui right floated header'>");
                _str.AppendFormat("     <i class='minus square icon link btnshrink font-th regular white' alt='{0}'></i>", _idContent);
                _str.AppendLine("   </div>");
                _str.AppendLine("   <div class='ui header'></div>");
                _str.AppendLine("   <div class='paddingTop5 panel-bodys'>");
                _str.AppendLine("       <div class='ui inverted dividing header'></div>");
                _str.AppendLine("       <div class='panel-body'>");                
                _str.AppendLine("           <div class='three fields'>");
                _str.AppendLine("               <div class='five wide field'>");
                _str.AppendLine("                   <label>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>คณะ</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Faculty</span>");
                _str.AppendLine("                   </label>");
                _str.AppendLine(                    SCHUI.DDLFaculty(_idContent + "-faculty").ToString());
                _str.AppendLine("               </div>");
                _str.AppendLine("               <div class='six wide field'>");
                _str.AppendLine("                   <label>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>หลักสูตร</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Program</span>");
                _str.AppendLine("                   </label>");
                _str.AppendFormat("                 <div id='{0}-program-dropdown'>{1}</div>", _idContent, SCHUI.DDLProgram((_idContent + "-program"), "", ""));
                _str.AppendLine("               </div>");
                _str.AppendLine("               <div class='five wide field'>");
                _str.AppendLine("                   <label>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>ปีที่เข้าศึกษา</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Entries Year</span>");
                _str.AppendLine("                   </label>");
                _str.AppendLine(                    SCHUI.DDLYearEntry(_idContent + "-yearentry").ToString());
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("           <div class='three fields'>");
                _str.AppendLine("               <div class='five wide field'>");
                _str.AppendLine("                   <label>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>ปี / ภาคเรียนที่อนุมัติรับเงิน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Approval Receive Finance on Year / Semester</span>");
                _str.AppendLine("                   </label>");
                _str.AppendLine(                    SCHUI.DDLScholarshipsYearSemester((_idContent + "-scholarshipsyearsemester"), SCHUtil.SUBJECT_ICL).ToString());
                _str.AppendLine("               </div>");
                _str.AppendLine("               <div class='six wide field'>");
                _str.AppendLine("                   <label>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>งวดที่อนุมัติรับเงิน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Approval Receive Finance on Period</span>");
                _str.AppendLine("                   </label>");
                _str.AppendFormat("                 <div id='{0}-lotno-dropdown'>{1}</div>", _idContent, SCHUI.DDLLotNoApprovalReceiveFinance((_idContent + "-lotno"), "", "", ""));
                _str.AppendLine("               </div>");
                _str.AppendLine("               <div class='five wide field'>");
                _str.AppendLine("                   <label>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>ผู้รับเงิน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Group Receiver</span>");
                _str.AppendLine("                   </label>");
                _str.AppendLine(                    SCHUI.DDLGroupReceiver((_idContent + "-groupreceiver"), "").ToString());
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("           <div class='field'>");
                _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsearch'>", _idContent);
                _str.AppendLine("                   <i class='search icon font-th regular white'></i>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular white'>ค้นหา</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular white'>Search</span>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("</div>");

                return _str;
            }
        }

        public class ListUI
        {
            public static string _idContent = ("list-" + SCHUtil.SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL.ToLower());

            public static StringBuilder GetMain(DataRow[] _dr)
            {
                StringBuilder _str = new StringBuilder();
                string _row = String.Empty;
                string _personId = String.Empty;
                string _studentCode = String.Empty;
                string _fullNameTH = String.Empty;
                string _fullNameEN = String.Empty;
                string _statusGroup = String.Empty;
                string _facultyCode = String.Empty;
                string _scholarshipsId = String.Empty;
                string _scholarshipsTypeGroup = String.Empty;
                string _scholarshipsYear = String.Empty;
                string _semester = String.Empty;
                string _lotNo = String.Empty;
                string _tuition = String.Empty;                
                string _groupReceiverId = String.Empty;
                string _groupReceiverNameTH = String.Empty;
                string _groupReceiverNameEN = String.Empty;
                string _bankCode = String.Empty;
			    string _accountNo = String.Empty;
			    string _bankNameTH = String.Empty;
			    string _bankNameEN = String.Empty;
                int _recordCount = _dr.GetLength(0);

                _str.AppendLine("<div class='paddingTop10'>");
                _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                _str.AppendFormat("         <div class='mini ui grey inverted button btnexport-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                _str.AppendLine("               <i class='file excel outline icon font-th regular white'></i>");
                _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>ส่งออก</span>");
                _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Export</span>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount nobtnoption'>");
                _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <br />");
                _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>จำนวนเงิน <span class='sum-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Amount <span class='sum-search'></span></span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("   <table class='ui table unstackable'>");
                _str.AppendLine("       <thead>");
                _str.AppendLine("           <tr class='center aligned'>");
                _str.AppendLine("               <th class='col1'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ที่</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>No.</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col2'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>รหัสนักศึกษา</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Student ID</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col3'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ชื่อ - สกุล</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Full Name</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col4'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>คณะ</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Faculty</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col5'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงินที่ขอกู้<br />( บาท )</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount of Loan<br />( bath )</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col6'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ผู้รับเงิน</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Recipient</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col7'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ธนาคาร</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Bank</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col8'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>เลขที่บัญชี</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Account<br />No.</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col9'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ปี / ภาคเรียน<br />ที่อนุมัติรับเงิน</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Approval Receive Finance<br />on Year / Semester</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col10'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>งวดที่<br />อนุมัติรับเงิน</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Period</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("           </tr>");
                _str.AppendLine("       </thead>");
                _str.AppendLine("       <tbody>");

                if (_recordCount > 0)
                {
                    foreach(DataRow _dr1 in _dr)
                    {
                        _row                    = _dr1["rowNum"].ToString();
                        _personId               = _dr1["id"].ToString();
                        _studentCode            = _dr1["studentCode"].ToString();
                        _fullNameTH             = SCHUtil.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString());
                        _fullNameEN             = SCHUtil.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper();
                        _statusGroup            = _dr1["statusGroup"].ToString();
                        _facultyCode            = _dr1["facultyCode"].ToString();
                        _scholarshipsId         = _dr1["schScholarshipsId"].ToString();
                        _scholarshipsTypeGroup  = _dr1["scholarshipsTypeGroup"].ToString();
                        _scholarshipsYear       = _dr1["scholarshipsYear"].ToString();
                        _semester               = _dr1["semester"].ToString();
                        _lotNo                  = _dr1["lotNo"].ToString();
                        _tuition                = (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()).ToString("#,##0.00") : "");
                        _tuition                = (_tuition.Equals("0.00") ? "" : _tuition);
                        _groupReceiverId        = _dr1["schGroupReceiverId"].ToString();
                        _groupReceiverNameTH    = _dr1["groupReceiverNameTH"].ToString();
                        _groupReceiverNameEN    = _dr1["groupReceiverNameEN"].ToString();
                        _bankCode               = _dr1["plcBankCode"].ToString();
                        _accountNo              = _dr1["accNo"].ToString();
                        _bankNameTH             = _dr1["plcBankNameTH"].ToString();
                        _bankNameEN             = _dr1["plcBankNameEN"].ToString();

                        _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId));
                        _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col2' data-content='' data-contentth='รหัสนักศึกษา' data-contenten='Student ID'>");
                        _str.AppendLine("           <div class='ui green button btnstudentcv' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\"}'>");
                        _str.AppendFormat("             <span class='lang lang-th f10 font-th regular white'>{0}</span>", _studentCode);
                        _str.AppendFormat("             <span class='lang lang-en f10 font-en regular white'>{0}</span>", _studentCode);                
                        _str.AppendLine("           </div>");
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col3 left aligned' data-content='' data-contentth='ชื่อ - สกุล' data-contenten='Full Name'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _fullNameTH);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _fullNameEN);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col4' data-content='' data-contentth='คณะ' data-contenten='Faculty'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _facultyCode);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _facultyCode);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col5 right aligned' data-content='' data-contentth='จำนวนเงินที่ขอกู้' data-contenten='Amount of Loan'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _tuition);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _tuition);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='ผู้รับเงิน' data-contenten='Recipient'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _groupReceiverNameTH);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _groupReceiverNameEN);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col7' data-content='' data-contentth='ธนาคาร' data-contenten='Bank'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _bankCode);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _bankCode);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col8' data-content='' data-contentth='เลขที่บัญชี' data-contenten='Account No.'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _accountNo);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _accountNo);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='ปี / ภาคเรียนที่อนุมัติรับเงิน' data-contenten='Approval Receive Finance on Year / Semester'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0} / {1}</span>", _scholarshipsYear, _semester);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0} / {1}</span>", _scholarshipsYear, _semester);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col10' data-content='' data-contentth='งวดที่อนุมัติรับเงิน' data-contenten='Approval Receive Finance on Period'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _lotNo);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _lotNo);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("   </tr>");
                        _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                        _str.AppendFormat("     <td class='preloading' colspan='10' id='{0}-id-{1}{2}{3}{4}'></td>", SCHReportScholarshipUI.ListOfPeopleApprovedFinanceFromICLUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                        _str.AppendLine("   </tr>");
                    }
                }
                    
                _str.AppendLine("       </tbody>");
                _str.AppendLine("   </table>");
                _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                _str.AppendFormat("         <div class='mini ui grey inverted button btnexport-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                _str.AppendLine("               <i class='file excel outline icon font-th regular white'></i>");
                _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>ส่งออก</span>");
                _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Export</span>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount nobtnoption'>");
                _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <br />");
                _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>จำนวนเงิน <span class='sum-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Amount <span class='sum-search'></span></span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("   <div class='table-navpage'></div>");
                _str.AppendLine("</div>");

                return _str;
            }
        }

        public class ExportUI
        {
            public static string _idContent = ("export-" + SCHUtil.SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL.ToLower());

            public static StringBuilder GetMain()
            {
                StringBuilder _str = new StringBuilder();

                _str.AppendFormat("<div id='{0}'>", _idContent);
                _str.AppendFormat("     <input type='hidden' id='{0}-exportresult' value=''>", _idContent);
                _str.AppendLine("       <div class='view' >");
                _str.AppendLine("           <div class='iform' >");
                _str.AppendLine("               <div class='iform-row'>");
                _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ส่งออกจำนวน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Export Total of</span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='total'></span> รายการ</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='total'></span> items</span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("               <div class='iform-row'>");
                _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ส่งออกสำเร็จจำนวน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Export Complete Total of</span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalcomplete'></span> <span class='totalunit'>รายการ</span></span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalcomplete'></span> <span class='totalunit'>items</span></span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("               <div class='iform-row'>");
                _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ส่งออกไม่สำเร็จจำนวน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Export Incomplete Total of</span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalincomplete'></span> <span class='totalunit'>รายการ</span></span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalincomplete'></span> <span class='totalunit'>items</span></span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui form'>");
                _str.AppendLine("           <div class='field'>");
                _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnexport' alt='{1}'>", _idContent, SCHUtil.PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT);
                _str.AppendLine("                   <i class='file excel outline icon font-th regular black'></i>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ส่งออก</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Export</span>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("  </div>");

                return _str;
            }
        }
    }

    public class StudentCVUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_REPORTSCHOLARSHIPSTUDENTCV.ToLower());

        public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
        {
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_REPORTSCHOLARSHIPSTUDENTCV] : null);

            _str.AppendFormat("<input class='studentpicture-hidden' type='hidden' value='{0}' />", (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "StudentPicture", _dataRecorded["StudentPicture"], "") : ""));

            return _str;
        }

        public static StringBuilder GetMain(string _id)
        {
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
            Dictionary<string, object> _valueDataRecorded = new Dictionary<string, object>();
            Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
            string _studentCode = String.Empty;
            string _fullNameTH = String.Empty;
            string _fullNameEN = String.Empty;
            string _facultyNameTH = String.Empty;
            string _facultyNameEN = String.Empty;
            string _programNameTH = String.Empty;
            string _programNameEN = String.Empty;
            string _statusTypeNameTH = String.Empty;
            string _statusTypeNameEN = String.Empty;
            string _scholarshipsNameTH = String.Empty;
            string _scholarshipsNameEN = String.Empty;
            string _scholarshipsTypeGroup = String.Empty;
            string _responsibleAgency = String.Empty;
            string _registerDate = String.Empty;
            string _scholarshipsYear = String.Empty;
            string _semester = String.Empty;
            string _tuition = String.Empty;
            string _regisCase = String.Empty;
            string _regisCaseNameTH = String.Empty;
            string _regisCaseNameEN = String.Empty;
            string _groupReceiverNameTH = String.Empty;
            string _groupReceiverNameEN = String.Empty;
            string _contractDate = String.Empty;
            string _approveDate = String.Empty;
            string _transferDate = String.Empty;
            string _cancelStatus = String.Empty;
            string _reason = String.Empty;
            string[] _valueArray = _id.Split('|');

            _paramSearch.Clear();
            _paramSearch.Add("PersonId",            _valueArray[0]);
            _paramSearch.Add("ScholarshipsYear",    _valueArray[1]);
            _paramSearch.Add("Semester",            _valueArray[2]);
            _paramSearch.Add("ScholarshipsId",      _valueArray[3]);

            _valueDataRecorded      = SCHUtil.SetValueDataRecorded(SCHUtil.SUBJECT_REPORTSCHOLARSHIPSTUDENTCV, "", _paramSearch);
            _dataRecorded           = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_REPORTSCHOLARSHIPSTUDENTCV] : null);
            _studentCode            = _dataRecorded["StudentCode"].ToString();
            _fullNameTH             = SCHUtil.GetFullName(_dataRecorded["TitleInitialsTH"].ToString(), _dataRecorded["TitleFullNameTH"].ToString(), _dataRecorded["FirstName"].ToString(), _dataRecorded["MiddleName"].ToString(), _dataRecorded["LastName"].ToString());
            _fullNameEN             = SCHUtil.GetFullName(_dataRecorded["TitleInitialsEN"].ToString(), _dataRecorded["TitleFullNameEN"].ToString(), _dataRecorded["FirstNameEN"].ToString(), _dataRecorded["MiddleNameEN"].ToString(), _dataRecorded["LastNameEN"].ToString()).ToUpper();
            _facultyNameTH          = _dataRecorded["FacultyNameTH"].ToString();
            _facultyNameEN          = _dataRecorded["FacultyNameEN"].ToString();
            _programNameTH          = _dataRecorded["ProgramNameTH"].ToString();
            _programNameEN          = _dataRecorded["ProgramNameEN"].ToString();
            _statusTypeNameTH       = _dataRecorded["StatusTypeNameTH"].ToString();
            _statusTypeNameEN       = _dataRecorded["StatusTypeNameEN"].ToString();
            _scholarshipsNameTH     = _dataRecorded["ScholarshipsNameTH"].ToString();
            _scholarshipsNameEN     = (!String.IsNullOrEmpty(_dataRecorded["ScholarshipsNameEN"].ToString()) ? _dataRecorded["ScholarshipsNameEN"].ToString() : (!String.IsNullOrEmpty(_scholarshipsNameTH) ? _scholarshipsNameTH : ""));
            _scholarshipsTypeGroup  = _dataRecorded["ScholarshipsTypeGroup"].ToString();
            _responsibleAgency      = _dataRecorded["ResponsibleAgency"].ToString();
            _registerDate           = (!String.IsNullOrEmpty(_dataRecorded["RegisterDate"].ToString()) ? DateTime.Parse(_dataRecorded["RegisterDate"].ToString()).ToString("dd/MM/yyyy") : "");
            _scholarshipsYear       = _dataRecorded["ScholarshipsYear"].ToString();
            _semester               = _dataRecorded["Semester"].ToString();
            _regisCase              = _dataRecorded["RegisCase"].ToString().ToUpper();
            _regisCaseNameTH        = _dataRecorded["RegisCaseNameTH"].ToString();
            _regisCaseNameEN        = _dataRecorded["RegisCaseNameEN"].ToString();
            _groupReceiverNameTH    = _dataRecorded["GroupReceiverNameTH"].ToString();
            _groupReceiverNameEN    = _dataRecorded["GroupReceiverNameEN"].ToString();
            _tuition                = (!String.IsNullOrEmpty(_dataRecorded["Tuition"].ToString()) ? double.Parse(_dataRecorded["Tuition"].ToString()).ToString("#,##0.00") : "");
            _tuition                = (_tuition.Equals("0.00") ? "" : _tuition);
            _contractDate           = (!String.IsNullOrEmpty(_dataRecorded["ContractDate"].ToString()) ? DateTime.Parse(_dataRecorded["ContractDate"].ToString()).ToString("dd/MM/yyyy") : "");
            _approveDate            = (!String.IsNullOrEmpty(_dataRecorded["ApproveDate"].ToString()) ? DateTime.Parse(_dataRecorded["ApproveDate"].ToString()).ToString("dd/MM/yyyy") : "");
            _transferDate           = (!String.IsNullOrEmpty(_dataRecorded["TransferDate"].ToString()) ? DateTime.Parse(_dataRecorded["TransferDate"].ToString()).ToString("dd/MM/yyyy") : "");
            _cancelStatus           = _dataRecorded["CancelStatus"].ToString();
            _reason                 = _dataRecorded["Reason"].ToString().Replace("\n", "<br />");

            _str.AppendLine( GetValue(_valueDataRecorded).ToString());
            _str.AppendLine("<div class='ui form'>");
            _str.AppendLine("   <div class='ui right aligned header'>");
            _str.AppendLine("       <i class='close icon link font-th regular black btnclose'></i>");
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");
            _str.AppendLine("<div class='view paddingTop5'>");
            _str.AppendLine("   <div class='iform'>");
            _str.AppendLine("       <div class='iform-row'>");
            _str.AppendLine("           <div class='col1 iform-col'>");
            _str.AppendLine("               <div class='avatar profilepicture'>");
            _str.AppendLine("                   <div class='watermark'></div>");
            _str.AppendLine("                   <img />");
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("           <div class='col2 iform-col'>");
            _str.AppendLine("               <div class='iform'>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>รหัสนักศึกษา</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Student ID</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _studentCode);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _studentCode);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>ชื่อ - สกุล</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Full Name</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _fullNameTH);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _fullNameEN);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>คณะ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Faculty</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _facultyNameTH);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _facultyNameEN);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>หลักสูตร</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Program</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _programNameTH);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _programNameEN);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>สถานภาพ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Student Status</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _statusTypeNameTH);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _statusTypeNameEN);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>ทุน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Scholarship</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span><span class='lang lang-th f10 font-th regular blue opacity05'>{1}</span>", _scholarshipsNameTH, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span><span class='lang lang-en f10 font-en regular blue opacity05'>{1}</span>", _scholarshipsNameEN, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>สมัครรับทุนเมื่อ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Regerter When</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}, {1} / {2}</span>", _registerDate, _scholarshipsYear, _semester);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}, {1} / {2}</span>", _registerDate, _scholarshipsYear, _semester);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>วันทำสัญญา</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Contract Date</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _contractDate);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _contractDate);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>จำนวนเงิน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Amount</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}{1}</span>", _tuition, (!String.IsNullOrEmpty(_tuition) ? " บาท" : ""));
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}{1}</span>", _tuition, (!String.IsNullOrEmpty(_tuition) ? " bath" : ""));
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>ประเภท</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Type</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _regisCaseNameTH);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _regisCaseNameEN);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>อนุมัติรับทุนเมื่อ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Approve When</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _approveDate);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _approveDate);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>ผุู้รับเงิน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Recipient</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _groupReceiverNameTH);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _groupReceiverNameEN);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");

            if (String.IsNullOrEmpty(_cancelStatus))
            {
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>หมายเหตุ</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Remark</span>");
            }

            if (_cancelStatus.Equals("Y"))
            {
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>เหตุผลในการยกเลิกทุน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Reason for Cancel</span>");

            }
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendFormat("                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _reason);
            _str.AppendFormat("                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _reason);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");

            return _str;
        }
    }
}