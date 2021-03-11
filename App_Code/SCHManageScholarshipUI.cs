using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;

public class SCHManageScholarshipUI
{
    public class MainUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("<div class='ui horizontal divider header container'>");
            _str.AppendLine("   <i class='money icon font-th regular black'></i>&nbsp;");
            _str.AppendLine("   <span class='lang lang-th f7 font-th regular black'>จัดการทุน</span>");
            _str.AppendLine("   <span class='lang lang-en f7 font-en regular black'>Manage Scholarship</span>");
            _str.AppendLine("</div>");
            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
            _str.AppendFormat("     <div id='{0}'>{1}</div>", SearchUI._idContent, SearchUI.GetMain());
            _str.AppendFormat("     <div id='{0}'></div>", ListUI._idContent);
            _str.AppendFormat("     <div id='{0}'>{1}</div>", StudentCancelUI.MainUI._idContent, StudentCancelUI.MainUI.GetMain());
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");

            return _str;
        }
    }

    public class SearchUI
    {
        public static string _idContent = ("search-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendLine("   <div class='ui form blue inverted segment'>");
            _str.AppendLine("       <div class='ui left floated header'>");
            _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>ค้นหา</span>");
            _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Search</span>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui right floated header'>");
            _str.AppendFormat("         <i class='minus square icon link btnshrink font-th regular white' alt='{0}'></i>", _idContent);
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui header'></div>");
            _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
            _str.AppendLine("           <div class='ui inverted dividing header'></div>");
            _str.AppendLine("           <div class='panel-body'>");
            _str.AppendLine("               <div class='two fields'>");
            _str.AppendLine("                   <div class='five wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>คณะ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Faculty</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLFaculty(_idContent + "-faculty").ToString());
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='six wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>หลักสูตร</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Program</span>");
            _str.AppendLine("                       </label>");
            _str.AppendFormat("                     <div id='{0}-program-dropdown'>{1}</div>", _idContent, SCHUI.DDLProgram((_idContent + "-program"), "", ""));
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='five wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ปีที่เข้าศึกษา</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Entries Year</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLYearEntry(_idContent + "-yearentry").ToString());
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='two fields'>");
            _str.AppendLine("                   <div class='five wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ปี / ภาคเรียนที่สมัครรับทุน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Scholarship on Year / Semester</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLScholarshipsYearSemester((_idContent + "-scholarshipsyearsemester"), "").ToString());
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='eleven wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ทุน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Scholarship</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLScholarships(_idContent + "-scholarships").ToString());
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='field'>");
            _str.AppendFormat("                 <div class='ui fluid button inverted blue' id='{0}-btnsearch'>", _idContent);
            _str.AppendLine("                       <i class='search icon font-th regular white'></i>");
            _str.AppendLine("                       <span class='lang lang-th f9 font-th regular white'>ค้นหา</span>");
            _str.AppendLine("                       <span class='lang lang-en f9 font-en regular white'>Search</span>");
            _str.AppendLine("                   </div>");
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
        public static string _idContent = ("list-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIP.ToLower());

        public static StringBuilder GetMain(DataRow[] _dr)
        { 
            StringBuilder _str = new StringBuilder();
            string _row = String.Empty;
            string _personId = String.Empty;
            string _studentCode = String.Empty;
            string _fullNameTH = String.Empty;
            string _fullNameEN = String.Empty;
            string _facultyCode = String.Empty;
            string _statusGroup = String.Empty;
            string _scholarshipsId = String.Empty;
            string _scholarshipsNameTH = String.Empty;
            string _scholarshipsNameEN = String.Empty;
            string _scholarshipsTypeGroup = String.Empty;
            string _responsibleAgency = String.Empty;
            string _registerDate = String.Empty;
            string _scholarshipsYear = String.Empty;
            string _semester = String.Empty;
            string _tuition = String.Empty;
            string _regisCase = String.Empty;
            string _approveDate = String.Empty;
            int _recordCount = _dr.GetLength(0);

            _str.AppendFormat("<div class='paddingTop10 {0}'>", _idContent);
            _str.AppendLine("   <div class='ui horizontal segments table-title'>");        
            _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btnsave-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='save icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกอนุมัติ</span>");
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Approve</span>");
            _str.AppendLine("           </div>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btncancel-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='remove icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>ยกเลิกทุน</span>");
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Cancel</span>");
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
            _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
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
            _str.AppendLine("                   <input type ='checkbox' class='select-root checkbox ui' tabindex='0' />");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col3'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>รหัสนักศึกษา</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Student ID</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col4'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ชื่อ - สกุล</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Full Name</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col5'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ทุน</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Scholarship</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col6'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>สมัครรับทุน<br />เมื่อ</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Regerter<br />When</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col7'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงิน<br />( บาท )</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount<br />( bath )</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col8'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ประเภท</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Type</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col9'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>อนุมัติรับทุน<br />เมื่อ</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Approve<br />When</span>");
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
                    _facultyCode            = _dr1["facultyCode"].ToString();
                    _statusGroup            = _dr1["statusGroup"].ToString();
                    _scholarshipsId         = _dr1["schScholarshipsId"].ToString();
                    _scholarshipsNameTH     = _dr1["scholarshipsNameTH"].ToString();
                    _scholarshipsNameEN     = (!String.IsNullOrEmpty(_dr1["scholarshipsNameEN"].ToString()) ? _dr1["scholarshipsNameEN"].ToString() : (!String.IsNullOrEmpty(_scholarshipsNameTH) ? _scholarshipsNameTH : ""));
                    _scholarshipsTypeGroup  = _dr1["scholarshipsTypeGroup"].ToString();
                    _responsibleAgency      = _dr1["responsibleAgency"].ToString();
                    _registerDate           = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                    _scholarshipsYear       = _dr1["scholarshipsYear"].ToString();
                    _semester               = _dr1["semester"].ToString();                
                    _tuition                = (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()).ToString("#,##0.00") : "");
                    _tuition                = (_tuition.Equals("0.00") ? "" : _tuition);                
                    _regisCase              = _dr1["regisCase"].ToString().ToUpper();
                    _approveDate            = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");

                    _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId));
                    _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='col2 checkbox'>");
                    _str.AppendLine("           <input type='checkbox' name='select-child' class='select-child checkbox checker' data-value='{\"studentId\":\"" + _studentCode + "\",\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\",\"scholarshipsTypeGroup\":\"" + _scholarshipsTypeGroup + "\"}' value='" + _personId + ":" + _scholarshipsYear + ":" + _semester + ":" + _scholarshipsId + ":" + _scholarshipsTypeGroup + "' />");
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='รหัสนักศึกษา' data-contenten='Student ID'>");
                    _str.AppendLine("           <div class='ui green button btnstudentcv' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\"}'>");
                    _str.AppendFormat("             <span class='lang lang-th f10 font-th regular white'>{0}</span>", _studentCode);
                    _str.AppendFormat("             <span class='lang lang-en f10 font-en regular white'>{0}</span>", _studentCode);                
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col4 left aligned' data-content='' data-contentth='ชื่อ - สกุล' data-contenten='Full Name'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _fullNameTH);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _fullNameEN);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col5 left aligned' data-content='' data-contentth='ทุน' data-contenten='Scholarship'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span><span class='lang lang-th f10 font-th regular muted'>{1}</span>", _scholarshipsNameTH, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span><span class='lang lang-en f10 font-en regular muted'>{1}</span>", _scholarshipsNameEN, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='วันที่สมัครรับทุน, ปี / ภาคเรียนที่สมัครรับทุน' data-contenten='Register Date, Scholarship on Year / Semester'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col7' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");
                    _str.AppendFormat("         <div class='ui form'><input type='text' class='textbox-numeric {0}' id='{1}-amount-{2}' maxlength='12' value='{3}' {4} /></div>", (!_statusGroup.Equals("00") ? "textbox-disable" : ""), _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId), _tuition, (!_statusGroup.Equals("00") ? "disabled" : ""));
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col8 left aligned' data-content='' data-contentth='ประเภท' data-contenten='Type'>");
                    _str.AppendLine("           <div class='ui form'>");
                    _str.AppendLine("               <div class='field'>");
                    _str.AppendLine("                   <div class='ui radio'>");
                    _str.AppendLine("                       <div>");
                    _str.AppendFormat("                         <input type='radio' name='{0}-regiscase-{1}' class='checkbox' value='S' {2} {3} />", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId), (_regisCase.Equals("S") ? "checked='checked'" : ""), (!_statusGroup.Equals("00") ? "disabled" : ""));
                    _str.AppendLine("                           <label>");
                    _str.AppendFormat("                             <span class='lang lang-th f10 font-th regular black link-click link-{0}'>ปกติ</span>", SCHUtil.SUBJECT_MEANINGOFSCHOLARSHIPPAYTYPE.ToLower());
                    _str.AppendFormat("                             <span class='lang lang-en f10 font-en regular black link-click link-{0}'>Normal</span>", SCHUtil.SUBJECT_MEANINGOFSCHOLARSHIPPAYTYPE.ToLower());
                    _str.AppendLine("                           </label>");
                    _str.AppendLine("                       </div>");
                    _str.AppendLine("                       <div>");
                    _str.AppendFormat("                         <input type='radio' name='{0}-regiscase-{1}' class='checkbox' value='F' {2} {3} />", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId), (_regisCase.Equals("F") ? "checked='checked'" : ""), (!_statusGroup.Equals("00") ? "disabled" : ""));
                    _str.AppendLine("                           <label>");
                    _str.AppendFormat("                             <span class='lang lang-th f10 font-th regular black link-click link-{0}'>เต็มจำนวน</span>", SCHUtil.SUBJECT_MEANINGOFSCHOLARSHIPPAYTYPE.ToLower());
                    _str.AppendFormat("                             <span class='lang lang-en f10 font-en regular black link-click link-{0}'>Full</span>", SCHUtil.PAGE_MEANINGOFSCHOLARSHIPPAYTYPE_MAIN.ToLower());
                    _str.AppendLine("                           </label>");
                    _str.AppendLine("                       </div>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='วันที่อนุมัติรับทุน' data-contenten='Approve Date'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _approveDate);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _approveDate);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("   </tr>");
                    _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                    _str.AppendFormat("     <td class='preloading' colspan='9' id='{0}-id-{1}{2}{3}{4}'></td>", StudentCVUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                    _str.AppendLine("   </tr>");
                }
            }
        
            _str.AppendLine("       </tbody>");
            _str.AppendLine("   </table>");
            _str.AppendLine("   <div class='ui horizontal segments table-title'>");
            _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btnsave-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='save icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกอนุมัติ</span>");
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Approve</span>");
            _str.AppendLine("           </div>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btncancel-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='remove icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>ยกเลิกทุน</span>");
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Cancel</span>");
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
            _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("       </div>");
            _str.AppendLine("   </div>");
            _str.AppendLine("   <div class='table-navpage'></div>");
            _str.AppendLine("  </div>");

            return _str;
        }
    }

    public class StudentCVUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPSTUDENTCV.ToLower());

        public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
        {
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPSTUDENTCV] : null);

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

            _valueDataRecorded      = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN, "", _paramSearch);
            _dataRecorded           = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPSTUDENTCV] : null);
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

            if (_scholarshipsTypeGroup.Equals(SCHUtil.SUBJECT_ICL))
            {
                _str.AppendLine("               <div class='iform-row'>");
                _str.AppendLine("                   <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>วันทำสัญญา</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Contract Date</span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("                   <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                     <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _contractDate);
                _str.AppendFormat("                     <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _contractDate);
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
            }

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

            if (_scholarshipsTypeGroup.Equals(SCHUtil.SUBJECT_ICL))
            {
                _str.AppendLine("               <div class='iform-row'>");
                _str.AppendLine("                   <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ผุู้รับเงิน</span>");
                _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Recipient</span>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("                   <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                     <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _groupReceiverNameTH);
                _str.AppendFormat("                     <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _groupReceiverNameEN);
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
            }

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

    public class StudentCancelUI
    {
        public class MainUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCEL.ToLower());

            public static StringBuilder GetMain()
            {
                StringBuilder _str = new StringBuilder();

                _str.AppendLine("<div class='paddingTop10'>");
                _str.AppendLine("   <div class='ui form orange inverted segment'>");
                _str.AppendLine("       <div class='ui left floated header'>");
                _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>รายการนักศึกษาที่ยกเลิกทุน</span>");
                _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>List of Student Cancel Scholarship</span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui right floated header'>");
                _str.AppendLine("           <i class='refresh icon link btnrefresh font-th regular white'></i>");
                _str.AppendLine("           <i class='plus square icon link btnshrink font-th regular white'></i>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui header'></div>");
                _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
                _str.AppendLine("           <div class='ui inverted dividing header'></div>");
                _str.AppendFormat("         <div class='panel-body' id='{0}'></div>", ListUI._idContent);
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("</div>");

                return _str;
            }
        }

        public class ListUI
        {
            public static string _idContent = ("list-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCEL.ToLower());

            public static StringBuilder GetMain(DataRow[] _dr)
            {
                StringBuilder _str = new StringBuilder();
                string _row = String.Empty;
                string _personId = String.Empty;
                string _studentCode = String.Empty;
                string _fullNameTH = String.Empty;
                string _fullNameEN = String.Empty;
                string _facultyCode = String.Empty;
                string _scholarshipsId = String.Empty;
                string _scholarshipsNameTH = String.Empty;
                string _scholarshipsNameEN = String.Empty;
                string _responsibleAgency = String.Empty;
                string _registerDate = String.Empty;
                string _scholarshipsYear = String.Empty;
                string _semester = String.Empty;
                string _regisCase = String.Empty;
                string _regisCaseNameTH = String.Empty;
                string _regisCaseNameEN = String.Empty;
                string _tuition = String.Empty;
                string _approveDate = String.Empty;
                int _recordCount = _dr.GetLength(0);

                _str.AppendFormat("<div class='{0}'>", SCHManageScholarshipUI.ListUI._idContent);
                _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                _str.AppendLine("       <div class='ui segment right floated right aligned orange inverted recordcount'>");
                _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("   <table class='ui table unstackable'>");
                _str.AppendLine("       <thead>");
                _str.AppendLine("           <tr class='center aligned'>");
                _str.AppendLine("               <th class='col1'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ที่</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>No.</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col3'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>รหัสนักศึกษา</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Student ID</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col4'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ชื่อ - สกุล</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Full Name</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col5'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ทุน</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Scholarship</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col6'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>สมัครรับทุน<br />เมื่อ</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Regerter<br />When</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col7'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงิน<br />( บาท )</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount<br />( bath )</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col8'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ประเภท</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Type</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col9'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>อนุมัติรับทุน<br />เมื่อ</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Approve<br />When</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("           </tr>");
                _str.AppendLine("       </thead>");
                _str.AppendLine("       <tbody>");

                if (_recordCount > 0)
                {
                    foreach (DataRow _dr1 in _dr)
                    {
                        _row                = _dr1["rowNum"].ToString();
                        _personId           = _dr1["id"].ToString();
                        _studentCode        = _dr1["studentCode"].ToString();
                        _fullNameTH         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString());
                        _fullNameEN         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper();
                        _facultyCode        = _dr1["facultyCode"].ToString();
                        _scholarshipsId     = _dr1["schScholarshipsId"].ToString();
                        _scholarshipsNameTH = _dr1["scholarshipsNameTH"].ToString();
                        _scholarshipsNameEN = (!String.IsNullOrEmpty(_dr1["scholarshipsNameEN"].ToString()) ? _dr1["scholarshipsNameEN"].ToString() : (!String.IsNullOrEmpty(_scholarshipsNameTH) ? _scholarshipsNameTH : ""));
                        _responsibleAgency  = _dr1["responsibleAgency"].ToString();
                        _registerDate       = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                        _scholarshipsYear   = _dr1["scholarshipsYear"].ToString();
                        _semester           = _dr1["semester"].ToString();                    
                        _regisCase          = _dr1["regisCase"].ToString().ToUpper();
                        _regisCaseNameTH    = _dr1["regisCaseNameTH"].ToString();
                        _regisCaseNameEN    = _dr1["regisCaseNameEN"].ToString();
                        _tuition            = (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()).ToString("#,##0.00") : "");
                        _tuition            = (_tuition.Equals("0.00") ? "" : _tuition);                    
                        _approveDate        = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");

                        _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, _personId);
                        _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='รหัสนักศึกษา' data-contenten='Student ID'>");
                        _str.AppendLine("           <div class='ui green button btnstudentcv' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\"}'>");
                        _str.AppendFormat("             <span class='lang lang-th f10 font-th regular white'>{0}</span>", _studentCode);
                        _str.AppendFormat("             <span class='lang lang-en f10 font-en regular white'>{0}</span>", _studentCode);
                        _str.AppendLine("           </div>");
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col4 left aligned' data-content='' data-contentth='ชื่อ - สกุล' data-contenten='Full Name'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _fullNameTH);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _fullNameEN);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col5 left aligned' data-content='' data-contentth='ทุน' data-contenten='Scholarship'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span><span class='lang lang-th f10 font-th regular muted'>{1}</span>", _scholarshipsNameTH, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span><span class='lang lang-en f10 font-en regular muted'>{1}</span>", _scholarshipsNameEN, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='วันที่สมัครรับทุน, ปี / ภาคเรียนที่สมัครรับทุน' data-contenten='Register Date, Scholarship on Year / Semester'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col7 right aligned' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _tuition);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _tuition);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col8' data-content='' data-contentth='ประเภท' data-contenten='Type'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black link-click link-{0}'>{1}</span>", SCHUtil.SUBJECT_MEANINGOFSCHOLARSHIPPAYTYPE.ToLower(), _regisCaseNameTH);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black link-click link-{0}'>{1}</span>", SCHUtil.SUBJECT_MEANINGOFSCHOLARSHIPPAYTYPE.ToLower(), _regisCaseNameEN);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='วันที่อนุมัติรับทุน' data-contenten='Approve Date'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _approveDate);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _approveDate);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("   </tr>");
                        _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                        _str.AppendFormat("     <td class='preloading' colspan='9' id='{0}-id-{1}{2}{3}{4}'></td>", StudentCVUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                        _str.AppendLine("   </tr>");
                    }
                }

                _str.AppendLine("       </tbody>");
                _str.AppendLine("   </table>");
                _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                _str.AppendLine("       <div class='ui segment right floated right aligned orange inverted recordcount'>");
                _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("   <div class='table-navpage'></div>");
                _str.AppendLine("  </div>");

                return _str;
            }
        }
                       
        public class StudentCVUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCELSTUDENTCV.ToLower());
        }
    }

    public class ICLUI
    {
        public class ListUI
        {
            public static string _idContent = ("list-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPTYPEGROUPICL.ToLower());

            public static StringBuilder GetMain(DataRow[] _dr)
            {
                StringBuilder _str = new StringBuilder();
                string _row = String.Empty;
                string _personId = String.Empty;
                string _studentCode = String.Empty;
                string _fullNameTH = String.Empty;
                string _fullNameEN = String.Empty;
                string _facultyCode = String.Empty;
                string _statusGroup = String.Empty;
                string _scholarshipsId = String.Empty;
                string _scholarshipsNameTH = String.Empty;
                string _scholarshipsNameEN = String.Empty;
                string _scholarshipsTypeGroup = String.Empty;
                string _responsibleAgency = String.Empty;
                string _registerDate = String.Empty;
                string _scholarshipsYear = String.Empty;            
                string _semester = String.Empty;            
                string _contractDate = String.Empty;
                string _tuition = String.Empty;
                string _approveDate = String.Empty;
                int _recordCount = _dr.GetLength(0);

                _str.AppendFormat("<div class='paddingTop10 {0}'>", _idContent);
                _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                _str.AppendFormat("         <div class='mini ui grey inverted button btnsave-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                _str.AppendLine("               <i class='save icon font-th regular white'></i>");
                _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกวันทำสัญญา</span>");
                _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Contract Date</span>");
                _str.AppendLine("           </div>");
                _str.AppendFormat("         <div class='mini ui grey inverted button btncancel-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                _str.AppendLine("               <i class='remove icon font-th regular white'></i>");
                _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>ยกเลิกทุน</span>");
                _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Cancel</span>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
                _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
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
                _str.AppendLine("                   <input type ='checkbox' class='select-root checkbox ui' tabindex='0' />");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col3'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>รหัสนักศึกษา</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Student ID</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col4'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ชื่อ - สกุล</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Full Name</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col5'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ทุน</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Scholarship</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col6'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>สมัครรับทุน<br />เมื่อ</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Regerter<br />When</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col7'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>วันทำสัญญา</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Contract Date</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col8'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงิน<br />( บาท )</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount<br />( bath )</span>");
                _str.AppendLine("               </th>");
                _str.AppendLine("               <th class='col9'>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>อนุมัติรับทุน<br />เมื่อ</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Approve<br />When</span>");
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
                        _facultyCode            = _dr1["facultyCode"].ToString();
                        _statusGroup            = _dr1["statusGroup"].ToString();
                        _scholarshipsId         = _dr1["schScholarshipsId"].ToString();
                        _scholarshipsNameTH     = _dr1["scholarshipsNameTH"].ToString();
                        _scholarshipsNameEN     = (!String.IsNullOrEmpty(_dr1["scholarshipsNameEN"].ToString()) ? _dr1["scholarshipsNameEN"].ToString() : (!String.IsNullOrEmpty(_scholarshipsNameTH) ? _scholarshipsNameTH : ""));
                        _scholarshipsTypeGroup  = _dr1["scholarshipsTypeGroup"].ToString();
                        _responsibleAgency      = _dr1["responsibleAgency"].ToString();
                        _registerDate           = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                        _scholarshipsYear       = _dr1["scholarshipsYear"].ToString();
                        _semester               = _dr1["semester"].ToString();
                        _contractDate           = (!String.IsNullOrEmpty(_dr1["contractDate"].ToString()) ? DateTime.Parse(_dr1["contractDate"].ToString()).ToString("dd/MM/yyyy") : "");
                        _tuition                = (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()).ToString("#,##0.00") : "");
                        _tuition                = (_tuition.Equals("0.00") ? "" : _tuition);
                        _approveDate            = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");

                        _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId));
                        _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='col2 checkbox'>");
                        _str.AppendLine("           <input type='checkbox' name='select-child' class='select-child checkbox checker' data-value='{\"studentId\":\"" + _studentCode + "\",\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\",\"scholarshipsTypeGroup\":\"" + _scholarshipsTypeGroup + "\"}' value='" + _personId + ":" + _scholarshipsYear + ":" + _semester + ":" + _scholarshipsId + ":" + _scholarshipsTypeGroup + "' />");
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='รหัสนักศึกษา' data-contenten='Student ID'>");
                        _str.AppendLine("           <div class='ui green button btnstudentcv' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\",\"statusGroup\":\"" + _statusGroup + "\",\"contractDate\":\"" + _contractDate + "\",\"approveDate\":\"" + _approveDate + "\"}'>");
                        _str.AppendFormat("             <span class='lang lang-th f10 font-th regular white'>{0}</span>", _studentCode);
                        _str.AppendFormat("             <span class='lang lang-en f10 font-en regular white'>{0}</span>", _studentCode);                
                        _str.AppendLine("           </div>");
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col4 left aligned' data-content='' data-contentth='ชื่อ - สกุล' data-contenten='Full Name'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _fullNameTH);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _fullNameEN);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col5 left aligned' data-content='' data-contentth='ทุน' data-contenten='Scholarship'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span><span class='lang lang-th f10 font-th regular muted'>{1}</span>", _scholarshipsNameTH, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span><span class='lang lang-en f10 font-en regular muted'>{1}</span>", _scholarshipsNameEN, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='วันที่สมัครรับทุน, ปี / ภาคเรียนที่สมัครรับทุน' data-contenten='Register Date, Scholarship on Year / Semester'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                        _str.AppendLine("       </td>");
                        _str.AppendFormat("     <td class='tooltip col7' data-content='' data-contentth='วันทำสัญญา' data-contenten='Contract Date' data-value='{0}'>", _contractDate);
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _contractDate);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _contractDate);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col8 right aligned' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _tuition);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _tuition);
                        _str.AppendLine("       </td>");
                        _str.AppendFormat("     <td class='tooltip col9' data-content='' data-contentth='วันที่อนุมัติรับทุน' data-contenten='Approve Date' data-value='{0}'>", _approveDate);
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _approveDate);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _approveDate);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("   </tr>");
                        _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), SCHManageScholarshipUI.ListUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                        _str.AppendFormat("     <td class='preloading' colspan='9' id='{0}-id-{1}{2}{3}{4}'></td>", SCHManageScholarshipUI.StudentCVUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                        _str.AppendLine("   </tr>");
                    }
                }
            
                _str.AppendLine("       </tbody>");
                _str.AppendLine("   </table>");
                _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                _str.AppendFormat("         <div class='mini ui grey inverted button btnsave-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                _str.AppendLine("               <i class='save icon font-th regular white'></i>");
                _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกวันทำสัญญา</span>");
                _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Contract Date</span>");
                _str.AppendLine("           </div>");
                _str.AppendFormat("         <div class='mini ui grey inverted button btncancel-option {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                _str.AppendLine("               <i class='remove icon font-th regular white'></i>");
                _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>ยกเลิกทุน</span>");
                _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Cancel</span>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
                _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("   <div class='table-navpage'></div>");
                _str.AppendLine("  </div>");

                return _str;
            }
        }
                      
        public class StudentCancelUI
        {
            public class ListUI
            {
                public static StringBuilder GetMain(DataRow[] _dr)
                {
                    StringBuilder _str = new StringBuilder();
                    string _row = String.Empty;
                    string _personId = String.Empty;
                    string _studentCode = String.Empty;
                    string _fullNameTH = String.Empty;
                    string _fullNameEN = String.Empty;
                    string _facultyCode = String.Empty;
                    string _scholarshipsId = String.Empty;
                    string _scholarshipsNameTH = String.Empty;
                    string _scholarshipsNameEN = String.Empty;
                    string _responsibleAgency = String.Empty;
                    string _registerDate = String.Empty;
                    string _scholarshipsYear = String.Empty;
                    string _semester = String.Empty;
                    string _contractDate = String.Empty;
                    string _tuition = String.Empty;
                    string _approveDate = String.Empty;
                    int _recordCount = _dr.GetLength(0);

                    _str.AppendFormat("<div class='{0}'>", SCHManageScholarshipUI.ICLUI.ListUI._idContent);
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned orange inverted recordcount'>");
                    _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("   </div>");
                    _str.AppendLine("   <table class='ui table unstackable'>");
                    _str.AppendLine("       <thead>");
                    _str.AppendLine("           <tr class='center aligned'>");
                    _str.AppendLine("               <th class='col1'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ที่</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>No.</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col3'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>รหัสนักศึกษา</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Student ID</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col4'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ชื่อ - สกุล</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Full Name</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col5'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ทุน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Scholarship</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col6'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>สมัครรับทุน<br />เมื่อ</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Regerter<br />When</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col7'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>วันทำสัญญา</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Contract Date</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col8'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงิน<br />( บาท )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount<br />( bath )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col9'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>อนุมัติรับทุน<br />เมื่อ</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Approve<br />When</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("           </tr>");
                    _str.AppendLine("       </thead>");
                    _str.AppendLine("       <tbody>");

                    if (_recordCount > 0)
                    {
                        foreach (DataRow _dr1 in _dr)
                        {
                            _row                = _dr1["rowNum"].ToString();
                            _personId           = _dr1["id"].ToString();
                            _studentCode        = _dr1["studentCode"].ToString();
                            _fullNameTH         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString());
                            _fullNameEN         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper();
                            _facultyCode        = _dr1["facultyCode"].ToString();
                            _scholarshipsId     = _dr1["schScholarshipsId"].ToString();
                            _scholarshipsNameTH = _dr1["scholarshipsNameTH"].ToString();
                            _scholarshipsNameEN = (!String.IsNullOrEmpty(_dr1["scholarshipsNameEN"].ToString()) ? _dr1["scholarshipsNameEN"].ToString() : (!String.IsNullOrEmpty(_scholarshipsNameTH) ? _scholarshipsNameTH : ""));
                            _responsibleAgency  = _dr1["responsibleAgency"].ToString();
                            _registerDate       = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _scholarshipsYear   = _dr1["scholarshipsYear"].ToString();
                            _semester           = _dr1["semester"].ToString();
                            _contractDate       = (!String.IsNullOrEmpty(_dr1["contractDate"].ToString()) ? DateTime.Parse(_dr1["contractDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _tuition            = (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()).ToString("#,##0.00") : "");
                            _tuition            = (_tuition.Equals("0.00") ? "" : _tuition);
                            _approveDate        = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");

                            _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", SCHManageScholarshipUI.ListUI._idContent, _personId);
                            _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='รหัสนักศึกษา' data-contenten='Student ID'>");
                            _str.AppendLine("           <div class='ui green button btnstudentcv' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\"}'>");
                            _str.AppendFormat("             <span class='lang lang-th f10 font-th regular white'>{0}</span>", _studentCode);
                            _str.AppendFormat("             <span class='lang lang-en f10 font-en regular white'>{0}</span>", _studentCode);
                            _str.AppendLine("           </div>");
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col4 left aligned' data-content='' data-contentth='ชื่อ - สกุล' data-contenten='Full Name'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _fullNameTH);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _fullNameEN);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col5 left aligned' data-content='' data-contentth='ทุน' data-contenten='Scholarship'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0} </span><span class='lang lang-th f10 font-th regular muted'>- {1}</span>", _scholarshipsNameTH, _responsibleAgency);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0} </span><span class='lang lang-en f10 font-en regular muted'>- {1}</span>", _scholarshipsNameEN, _responsibleAgency);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='วันที่สมัครรับทุน, ปี / ภาคเรียนที่สมัครรับทุน' data-contenten='Register Date, Scholarship on Year / Semester'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}{1} / {2}</span>", (!String.IsNullOrEmpty(_registerDate) ? (_registerDate + "<br />") : ""), _scholarshipsYear, _semester);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col7' data-content='' data-contentth='วันทำสัญญา' data-contenten='Contract Date'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _contractDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _contractDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col7 right aligned' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _tuition);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _tuition);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='วันที่อนุมัติรับทุน' data-contenten='Approve Date'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _approveDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _approveDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("   </tr>");
                            _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), SCHManageScholarshipUI.StudentCancelUI.ListUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendFormat("     <td class='preloading' colspan='9' id='{0}-id-{1}{2}{3}{4}'></td>", SCHManageScholarshipUI.StudentCancelUI.StudentCVUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendLine("   </tr>");
                        }
                    }

                    _str.AppendLine("       </tbody>");
                    _str.AppendLine("   </table>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned orange inverted recordcount'>");
                    _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("   </div>");
                    _str.AppendLine("   <div class='table-navpage'></div>");
                    _str.AppendLine("  </div>");

                    return _str;
                }
            }
        }

        public class AddUpdateUI
        {
            public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPTYPEGROUPICL.ToLower());

            public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _str = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPTYPEGROUPICL] : null);
                string _personId            = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "PersonId", _dataRecorded["PersonId"], "") : "").ToString();
                string _scholarshipsYear    = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsYear", _dataRecorded["ScholarshipsYear"], "") : "").ToString();
                string _semester            = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Semester", _dataRecorded["Semester"], "") : "").ToString();
                string _scholarshipsId      = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsId", _dataRecorded["ScholarshipsId"], "") : "").ToString();

                _str.AppendFormat("<input class='studentpicture-hidden' type='hidden' value='{0}' />",      (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "StudentPicture", _dataRecorded["StudentPicture"], "") : ""));
                _str.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />",                 _idContent, (_personId + "|" + _scholarshipsYear + "|" + _semester + "|" + _scholarshipsId));
                _str.AppendFormat("<input type='hidden' id='{0}-personid-hidden' value='{1}' />",           _idContent, _personId);
                _str.AppendFormat("<input type='hidden' id='{0}-scholarshipsyear-hidden' value='{1}' />",   _idContent, _scholarshipsYear);
                _str.AppendFormat("<input type='hidden' id='{0}-semester-hidden' value='{1}' />",           _idContent, _semester);
                _str.AppendFormat("<input type='hidden' id='{0}-scholarshipsid-hidden' value='{1}' />",     _idContent, _scholarshipsId);
                _str.AppendFormat("<input type='hidden' id='{0}-amount-hidden' value='{1}' />",             _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Tuition", _dataRecorded["Tuition"], "") : ""));
                _str.AppendFormat("<input type='hidden' id='{0}-rateperyearremain-hidden' value='{1}' />",  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "RatePerYearRemain", _dataRecorded["RatePerYearRemain"], "") : ""));                
                 
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
                string _scholarshipsYear = String.Empty;
                string _semester = String.Empty;
                string _tuition = String.Empty;
                string _invoiceNo = String.Empty;
                string _invoiceAmount = String.Empty;
                string _stdPayAmount = String.Empty;
                string _totalCredit = String.Empty;
                string _ratePerYear = String.Empty;
                string _discountAmount = String.Empty;
                string _ratePerYearRemain = String.Empty;
                string _registerDate = String.Empty;
                string _approveDate = String.Empty;
                string[] _valueArray = _id.Split('|');

                _paramSearch.Clear();
                _paramSearch.Add("PersonId",            _valueArray[0]);
                _paramSearch.Add("ScholarshipsYear",    _valueArray[1]);
                _paramSearch.Add("Semester",            _valueArray[2]);
                _paramSearch.Add("ScholarshipsId",      _valueArray[3]);

                _valueDataRecorded  = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE, "", _paramSearch);
                _dataRecorded       = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_MANAGESCHOLARSHIPTYPEGROUPICL] : null);
                _studentCode        = _dataRecorded["StudentCode"].ToString();
                _fullNameTH         = SCHUtil.GetFullName(_dataRecorded["TitleInitialsTH"].ToString(), _dataRecorded["TitleFullNameTH"].ToString(), _dataRecorded["FirstName"].ToString(), _dataRecorded["MiddleName"].ToString(), _dataRecorded["LastName"].ToString());
                _fullNameEN         = SCHUtil.GetFullName(_dataRecorded["TitleInitialsEN"].ToString(), _dataRecorded["TitleFullNameEN"].ToString(), _dataRecorded["FirstNameEN"].ToString(), _dataRecorded["MiddleNameEN"].ToString(), _dataRecorded["LastNameEN"].ToString()).ToUpper();
                _facultyNameTH      = _dataRecorded["FacultyNameTH"].ToString();
                _facultyNameEN      = _dataRecorded["FacultyNameEN"].ToString();
                _programNameTH      = _dataRecorded["ProgramNameTH"].ToString();
                _programNameEN      = _dataRecorded["ProgramNameEN"].ToString();
                _statusTypeNameTH   = _dataRecorded["StatusTypeNameTH"].ToString();
                _statusTypeNameEN   = _dataRecorded["StatusTypeNameEN"].ToString();                
                _scholarshipsYear   = _dataRecorded["ScholarshipsYear"].ToString();
                _semester           = _dataRecorded["Semester"].ToString();
                _tuition            = (!String.IsNullOrEmpty(_dataRecorded["Tuition"].ToString()) ? double.Parse(_dataRecorded["Tuition"].ToString()).ToString("#,##0.00") : "");
                _invoiceNo          = _dataRecorded["InvoiceNo"].ToString();
                _invoiceAmount      = (!String.IsNullOrEmpty(_dataRecorded["InvoiceAmount"].ToString()) ? double.Parse(_dataRecorded["InvoiceAmount"].ToString()).ToString("#,##0.00") : "");
                _stdPayAmount       = (!String.IsNullOrEmpty(_dataRecorded["StdPayAmount"].ToString()) ? double.Parse(_dataRecorded["StdPayAmount"].ToString()).ToString("#,##0.00") : "");
                _totalCredit        = _dataRecorded["TotalCredit"].ToString();
                _ratePerYear        = (!String.IsNullOrEmpty(_dataRecorded["RatePerYear"].ToString()) ? double.Parse(_dataRecorded["RatePerYear"].ToString()).ToString("#,##0.00") : "");
                _discountAmount     = (!String.IsNullOrEmpty(_dataRecorded["DiscountAmount"].ToString()) ? double.Parse(_dataRecorded["DiscountAmount"].ToString()).ToString("#,##0.00") : "");
                _ratePerYearRemain  = (!String.IsNullOrEmpty(_dataRecorded["RatePerYearRemain"].ToString()) ? double.Parse(_dataRecorded["RatePerYearRemain"].ToString()).ToString("#,##0.00") : "");
                _registerDate       = _dataRecorded["RegisterDate"].ToString();
                _approveDate        = _dataRecorded["ApproveDate"].ToString();

                _str.AppendFormat("<div id='{0}'>", _idContent);
                _str.AppendLine(        GetValue(_valueDataRecorded).ToString());
                _str.AppendFormat("     <input type='hidden' id='{0}-saveresult' value=''>", _idContent);
                _str.AppendLine("       <div class='ui studentcv' >");
                _str.AppendLine("           <div class='view'>");
                _str.AppendLine("               <div class='iform' >");
                _str.AppendLine("                   <div class='iform-row'>");
                _str.AppendLine("                       <div class='col1 iform-col paddingBottom10'>");
                _str.AppendLine("                           <div class='avatar profilepicture'>");
                _str.AppendLine("                               <div class='watermark'></div>");
                _str.AppendLine("                               <img />");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                       </div>");
                _str.AppendLine("                       <div class='col2 iform-col'>");
                _str.AppendLine("                           <div class='iform'>");
                _str.AppendLine("                               <div class='iform-row'>");
                _str.AppendLine("                                   <div class='iform-col input-col left aligned'>");
                _str.AppendFormat("                                     <span class='lang lang-th f8 font-th bold black'>{0}</span><span class='lang lang-th f9 font-th regular black'> ( {1} )</span>", _fullNameTH, _studentCode);
                _str.AppendFormat("                                     <span class='lang lang-en f8 font-en bold black'>{0}</span><span class='lang lang-en f9 font-en regular black'> ( {1} )</span>", _fullNameEN, _studentCode);
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='iform-row'>");
                _str.AppendLine("                                   <div class='iform-col input-col left aligned'>");
                _str.AppendLine("                                       <div>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _facultyNameTH);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _facultyNameEN);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th light black'>{0}</span>", _programNameTH);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en light black'>{0}</span>", _programNameEN);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='iform-row'>");
                _str.AppendLine("                                   <div class='iform-col input-col left aligned'>");
                _str.AppendFormat("                                     <span class='lang lang-th f11 font-th light black'>{0}</span>", _statusTypeNameTH);
                _str.AppendFormat("                                     <span class='lang lang-en f11 font-en light black'>{0}</span>", _statusTypeNameEN);
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                       </div>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='view'>");
                _str.AppendLine("           <div class='ui dividing header'></div>");
                _str.AppendLine("           <div class='iform'>");
                _str.AppendLine("               <div class='iform-row'>");
                _str.AppendLine("                   <div class='col3 iform-col'>");
                _str.AppendLine("                       <div class='iform'>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>ประจำภาคเรียนที่</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Semester</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' id='{0}-scholarshipsyearsemester' value='{1} / {2}' /></div>", _idContent, _scholarshipsYear, _semester);
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col33 iform-col label-col'>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>หมายเลขใบแจ้งหนี้</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Invoice No.</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' id='{0}-invoiceno' value='{1}' /></div>", _idContent, _invoiceNo);
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col33 iform-col label-col'>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>หน่วยกิตที่ลงทะเบียน</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Total Credit</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' id='{0}-totalcredit' value='{1}' /></div>", _idContent, _totalCredit);
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col33 iform-col label-col'>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                       </div>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("                   <div class='col4 iform-col'>");
                _str.AppendLine("                       <div class='iform'>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col41 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>เงินกู้ที่สามารถกู้ได้ต่อปี</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Loan Rate Per Year</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col42 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' class='textalignright' id='{0}-rateperyear' maxlength='12' value='{1}' /></div>", _idContent, _ratePerYear);
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col43 iform-col label-col left aligned textalignright'>");
                _str.AppendLine("                                   <span class='lang lang-th font-th regular black'> บาท</span>");
                _str.AppendLine("                                   <span class='lang lang-en font-en regular black'> bath</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col41 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>เงินกู้คงเหลือที่สามารถกู้ได้ต่อปี</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Remain Loan Rate Per Year</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col42 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' class='textalignright' id='{0}-rateperyearremain' maxlength='12' value='{1}' /></div>", _idContent, _ratePerYearRemain);
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col43 iform-col label-col left aligned textalignright'>");
                _str.AppendLine("                                   <span class='lang lang-th font-th regular black'> บาท</span>");
                _str.AppendLine("                                   <span class='lang lang-en font-en regular black'> bath</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col41 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>ค่าลงทะเบียนไม่รวมค่าหอพัก</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Registration Fee Not Include Dormitory Fee</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col42 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' class='textbox-numeric' id='{0}-invoiceamount' maxlength='12' value='{1}' /></div>", _idContent, _invoiceAmount);
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col43 iform-col label-col left aligned textalignright'>");
                _str.AppendLine("                                   <span class='lang lang-th font-th regular black'> บาท</span>");
                _str.AppendLine("                                   <span class='lang lang-en font-en regular black'> bath</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col41 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>จำนวนเงินที่ขอกู้</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Amount of Loan</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col42 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' class='textbox-numeric' id='{0}-amount' maxlength='12' value='{1}' /></div>", _idContent, (!String.IsNullOrEmpty(_tuition) ? _tuition : _invoiceAmount));
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col43 iform-col label-col left aligned textalignright'>");
                _str.AppendLine("                                   <span class='lang lang-th font-th regular black'> บาท</span>");
                _str.AppendLine("                                   <span class='lang lang-en font-en regular black'> bath</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='iform-row input'>");
                _str.AppendLine("                               <div class='col41 iform-col label-col left aligned'>");
                _str.AppendLine("                                   <span class='lang lang-th f10 font-th regular black'>จำนวนเงินที่ต้องชำระเอง</span>");
                _str.AppendLine("                                   <span class='lang lang-en f10 font-en regular black'>Amount to Pay</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col42 iform-col input-col left aligned'>");
                _str.AppendFormat("                                 <div class='ui form'><input type='text' class='textalignright' id='{0}-stdpayamount' maxlength='12' value='{1}' /></div>", _idContent, _stdPayAmount);
                _str.AppendLine("                               </div>");
                _str.AppendLine("                               <div class='col43 iform-col label-col left aligned textalignright'>");
                _str.AppendLine("                                   <span class='lang lang-th font-th regular black'> บาท</span>");
                _str.AppendLine("                                   <span class='lang lang-en font-en regular black'> bath</span>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                       </div>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui form'>");
                _str.AppendLine("           <div class='field'>");
                _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsave' alt='{1}'>", _idContent, SCHUtil.PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE);
                _str.AppendLine("                   <i class='save icon font-th regular black'></i>");
                _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>บันทึก</span>");
                _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Save</span>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("  </div>");

                return _str;
            }
        }
    }

    public class AddUpdateUI
    {
        public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_MANAGESCHOLARSHIP.ToLower());

        public static StringBuilder GetMain(string _page)
        {
            StringBuilder _str = new StringBuilder();
            string _msgTH = String.Empty;
            string _msgEN = String.Empty;

            if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIP_ADDUPDATE))
            {
                _msgTH = "จัดการทุน";
            }
            if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_ADDUPDATE))
            {
                _msgTH = "ยกเลิกทุน";
            }

            _str.AppendFormat("<div id='{0}'>", _idContent);
            _str.AppendFormat("     <input type='hidden' id='{0}-saveresult' value=''>", _idContent);
            _str.AppendLine("       <div class='view' >");
            _str.AppendLine("           <div class='iform' >");
            _str.AppendLine("               <div class='iform-row'>");
            _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
            _str.AppendFormat("                     <span class='lang lang-th f10 font-th regular black'>บันทึก{0}จำนวน</span>", _msgTH);
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Total of</span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='total'></span> รายการ</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='total'></span> items</span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='iform-row'>");
            _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
            _str.AppendFormat("                     <span class='lang lang-th f10 font-th regular black'>บันทึก{0}สำเร็จจำนวน</span>", _msgTH);
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Complete Total of</span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalcomplete'></span> <span class='totalunit'>รายการ</span></span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalcomplete'></span> <span class='totalunit'>items</span></span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='iform-row'>");
            _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
            _str.AppendFormat("                     <span class='lang lang-th f10 font-th regular black'>บันทึก{0}ไม่สำเร็จจำนวน</span>", _msgTH);
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Incomplete Total of</span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalincomplete'></span> <span class='totalunit'>รายการ</span></span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalincomplete'></span> <span class='totalunit'>items</span></span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui form'>");

            if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIP_ADDUPDATE))
            {
                _str.AppendLine("       <div class='ui dividing header hide scholarshipstypegroupicl'></div>");
                _str.AppendLine("       <div class='fields hide scholarshipstypegroupicl'>");
                _str.AppendLine("           <div class='sixteen wide field'>");
                _str.AppendLine("               <label>");
                _str.AppendLine("                   <span class='lang lang-th f10 font-th regular black'>วันทำสัญญา</span>");
                _str.AppendLine("                   <span class='lang lang-en f10 font-en regular black'>Contract Date</span>");
                _str.AppendLine("               </label>");
                _str.AppendFormat("             <div class='ui calendar' id='{0}-contractdate'>", _idContent);
                _str.AppendLine("                   <div class='ui input right icon'>");
                _str.AppendLine("                       <i class='calendar icon'></i>");
                _str.AppendLine("                       <input class='inputcalendar' type='text' placeholder='' placeholderth='' placeholderen='' value='' />");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
            }

            if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_ADDUPDATE))
            {
                _str.AppendLine("       <div class='ui dividing header'></div>");
                _str.AppendLine("       <div class='fields'>");
                _str.AppendLine("           <div class='sixteen wide field'>");
                _str.AppendLine("               <label>");
                _str.AppendLine("                   <span class='lang lang-th f10 font-th regular black'>เหตุผลในการยกเลิกทุน</span>");
                _str.AppendLine("                   <span class='lang lang-en f10 font-en regular black'>Reason for Cancel</span>");
                _str.AppendLine("               </label>");
                _str.AppendFormat("             <textarea id='{0}-reason' placeholder='' placeholderth='' placeholderen=''></textarea>", _idContent);
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
            }

            _str.AppendLine("           <div class='field'>");
            _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsave' alt='{1}'>", _idContent, _page);
            _str.AppendLine("                   <i class='save icon font-th regular black'></i>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>บันทึก</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Save</span>");
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("  </div>");

            return _str;
        }
    }
}