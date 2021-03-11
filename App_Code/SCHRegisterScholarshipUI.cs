using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;

public class SCHRegisterScholarshipUI
{
    public class MainUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_REGISTERSCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("   <div class='ui horizontal divider header container'>");
            _str.AppendLine("       <i class='pointing up icon font-th regular black'></i>&nbsp;");
            _str.AppendLine("       <span class='lang lang-th f7 font-th regular black'>สมัครรับทุน</span>");
            _str.AppendLine("       <span class='lang lang-en f7 font-en regular black'>Register Scholarship</span>");
            _str.AppendLine("   </div>");
            _str.AppendLine("   <div class='paddingTop10'>");
            _str.AppendFormat("     <div class='ui container' id='{0}'>", _idContent);
            _str.AppendFormat("         <div id='{0}'>{1}</div>", SearchUI._idContent, SearchUI.GetMain());
            _str.AppendFormat("         <div id='{0}'></div>", ListUI._idContent);
            _str.AppendLine("       </div>");
            _str.AppendLine("   </div>");

            return _str;
        }
    }

    public class SearchUI
    {
        public static string _idContent = ("search-" + SCHUtil.SUBJECT_REGISTERSCHOLARSHIP.ToLower());

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
            _str.AppendLine("                   <div class='eight wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>คณะ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Faculty</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLFaculty(_idContent + "-faculty").ToString());
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='eight wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>หลักสูตร</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Program</span>");
            _str.AppendLine("                       </label>");
            _str.AppendFormat("                     <div id='{0}-program-dropdown'>{1}</div>", _idContent, SCHUI.DDLProgram((_idContent + "-program"), "", ""));
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='two fields'>");
            _str.AppendLine("                   <div class='eight wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ปีที่เข้าศึกษา</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Entries Year</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLYearEntry(_idContent + "-yearentry").ToString());
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='eight wide field hide'>");
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
        public static string _idContent = ("list-" + SCHUtil.SUBJECT_REGISTERSCHOLARSHIP.ToLower());
        
        public static StringBuilder GetMain(DataRow[] _dr)
        { 
            StringBuilder _str = new StringBuilder();
            string _personId = String.Empty;
            string _studentCode = String.Empty;
            string _fullNameTH = String.Empty;
            string _fullNameEN = String.Empty;
            string _facultyCode = String.Empty;
            string _programNameTH = String.Empty;
            string _programNameEN = String.Empty;            
            string _numberScholar = String.Empty;
            string _statusTypeNameTH = String.Empty;
            string _statusTypeNameEN = String.Empty;
            string _statusGroup = String.Empty;
            int _recordCount = _dr.GetLength(0);

            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendLine("   <div class='ui horizontal segments table-title'>");        
            _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>สมัครรับทุน</span>");
            _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Register</span>");
            _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
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
            _str.AppendLine("               <th class='col2 checkbox'>");
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
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>คณะ</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Faculty</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col6'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>หลักสูตร</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Program</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col7'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนทุน</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Store</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("               <th class='col8'>");
            _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>สถานภาพ</span>");
            _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Student Status</span>");
            _str.AppendLine("               </th>");
            _str.AppendLine("           </tr>");
            _str.AppendLine("       </thead>");
            _str.AppendLine("       <tbody>");

            if (_recordCount > 0)
            {
                foreach(DataRow _dr1 in _dr)
                {
                    _personId           = _dr1["id"].ToString();
                    _studentCode        = (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX");
                    _fullNameTH         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString());
                    _fullNameEN         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper();
                    _facultyCode        = _dr1["facultyCode"].ToString();
                    _programNameTH      = _dr1["programNameTH"].ToString();
                    _programNameEN      = _dr1["programNameEN"].ToString();
                    _numberScholar      = int.Parse(_dr1["numberScholar"].ToString()).ToString("#,##0");
                    _statusTypeNameTH   = _dr1["statusTypeNameTH"].ToString();
                    _statusTypeNameEN   = _dr1["statusTypeNameEN"].ToString();
                    _statusGroup        = _dr1["statusGroup"].ToString();

                    _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, _personId);
                    _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_dr1["rowNum"].ToString()).ToString("#,##0"));
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_dr1["rowNum"].ToString()).ToString("#,##0"));
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='col2 checkbox'>");

                    if (_statusGroup.Equals("00"))
                        _str.AppendFormat("     <input type='checkbox' name='select-child' class='select-child checkbox checker studentcode' value='{0}' />", _personId);

                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='รหัสนักศึกษา' data-contenten='Student ID'>");
                    _str.AppendFormat("         <div class='ui green button btnstudentcv' data-options='{0}'>", _personId);
                    _str.AppendFormat("             <span class='lang lang-th f10 font-th regular white'>{0}</span>", _studentCode);
                    _str.AppendFormat("             <span class='lang lang-en f10 font-en regular white'>{0}</span>", _studentCode);                
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col4 left aligned' data-content='' data-contentth='ชื่อ - สกุล' data-contenten='Full Name'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _fullNameTH);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _fullNameEN);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col5' data-content='' data-contentth='คณะ' data-contenten='Faculty'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _facultyCode);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _facultyCode);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col6 left aligned' data-content='' data-contentth='หลักสูตร' data-contenten='Program'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _programNameTH);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _programNameEN);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col7' data-content='' data-contentth='จำนวนทุน' data-contenten='Store'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _numberScholar);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _numberScholar);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("       <td class='tooltip col8' data-content='' data-contentth='สถานภาพ' data-contenten='Student Status'>");
                    _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _statusTypeNameTH);
                    _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _statusTypeNameEN);
                    _str.AppendLine("       </td>");
                    _str.AppendLine("   </tr>");
                    _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId);
                    _str.AppendFormat("     <td class='preloading' colspan='8' id='{0}-id-{1}'></td>", StudentCVUI._idContent, _personId);
                    _str.AppendLine("   </tr>");
                }
            }

            _str.AppendLine("       </tbody>");
            _str.AppendLine("   </table>");
            _str.AppendLine("   <div class='ui horizontal segments table-title'>");
            _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>สมัครรับทุน</span>");
            _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Register</span>");
            _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
            _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("       </div>");
            _str.AppendLine("   </div>");
            _str.AppendLine("   <div class='table-navpage'></div>");
            _str.AppendLine("</div>");
        
            return _str;
        }
    }

    public class StudentCVUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_REGISTERSCHOLARSHIPSTUDENTCV.ToLower());

        public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
        {
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_REGISTERSCHOLARSHIPSTUDENTCV] : null);

            _str.AppendFormat("<input type='hidden' id='{0}-studentpicture-hidden' value='{1}' />", _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "StudentPicture", _dataRecorded["StudentPicture"], "") : ""));

            return _str;
        }        
        
        public static StringBuilder GetMain(string _id)
        {
            Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin("", "");                     
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _paramSearch = new Dictionary<string,object>();
            Dictionary<string, object> _valueDataRecorded = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN, _id, null);
            Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_REGISTERSCHOLARSHIPSTUDENTCV] : null);
            string _username = _loginResult["Username"].ToString();
            string _userlevel = _loginResult["Userlevel"].ToString();
            string _systemGroup = _loginResult["SystemGroup"].ToString();
            string _studentCode = _dataRecorded["StudentCode"].ToString();
            string _fullNameTH = SCHUtil.GetFullName(_dataRecorded["TitleInitialsTH"].ToString(), _dataRecorded["TitleFullNameTH"].ToString(), _dataRecorded["FirstName"].ToString(), _dataRecorded["MiddleName"].ToString(), _dataRecorded["LastName"].ToString());
            string _fullNameEN = SCHUtil.GetFullName(_dataRecorded["TitleInitialsEN"].ToString(), _dataRecorded["TitleFullNameEN"].ToString(), _dataRecorded["FirstNameEN"].ToString(), _dataRecorded["MiddleNameEN"].ToString(), _dataRecorded["LastNameEN"].ToString()).ToUpper();
            string _facultyNameTH = _dataRecorded["FacultyNameTH"].ToString();
            string _facultyNameEN = _dataRecorded["FacultyNameEN"].ToString();
            string _programNameTH = _dataRecorded["ProgramNameTH"].ToString();
            string _programNameEN = _dataRecorded["ProgramNameEN"].ToString();
            string _statusTypeNameTH = _dataRecorded["StatusTypeNameTH"].ToString();
            string _statusTypeNameEN = _dataRecorded["StatusTypeNameEN"].ToString();
            string _row = String.Empty;
            string _scholarshipsNameTH = String.Empty;
            string _scholarshipsNameEN = String.Empty;
            string _responsibleAgency = String.Empty;
            string _registerDate = String.Empty;
            string _scholarshipsYear = String.Empty;
            string _semester = String.Empty;

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
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>ทุน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Scholarship</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendLine("                           <div class='info-list'>");
            _str.AppendLine("                               <ul>");
            
            _paramSearch.Clear();
            _paramSearch.Add("Keyword", _studentCode);

            DataSet _ds1 = SCHDB.GetListTranStudentManageScholarship(_username, _userlevel, _systemGroup, _paramSearch);

            foreach(DataRow _dr1 in _ds1.Tables[0].Rows)
            {
                _row                = _dr1["rowNum"].ToString();
                _scholarshipsNameTH = _dr1["scholarshipsNameTH"].ToString();
                _scholarshipsNameEN = (!String.IsNullOrEmpty(_dr1["scholarshipsNameEN"].ToString()) ? _dr1["scholarshipsNameEN"].ToString() : (!String.IsNullOrEmpty(_scholarshipsNameTH) ? _scholarshipsNameTH : ""));
                _responsibleAgency  = _dr1["responsibleAgency"].ToString();
                _registerDate       = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                _scholarshipsYear   = _dr1["scholarshipsYear"].ToString();
                _semester           = _dr1["semester"].ToString();                
                
                _str.AppendLine("                               <li class='blue'>");
                _str.AppendFormat("                                 <span class='lang lang-th f10 font-th regular blue'>{0}</span><span class='lang lang-th f10 font-th regular blue opacity05'>{1}</span><span class='lang lang-th f10 font-th regular blue'> ( {2} - {3} / {4} )</span>", _scholarshipsNameTH, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""), _registerDate, _scholarshipsYear, _semester);
                _str.AppendFormat("                                 <span class='lang lang-en f10 font-en regular blue'>{0}</span><span class='lang lang-en f10 font-en regular blue opacity05'>{1}</span><span class='lang lang-en f10 font-en regular blue'> ( {2} - {3} / {4} )</span>", _scholarshipsNameEN, (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""), _registerDate, _scholarshipsYear, _semester);
                _str.AppendLine("                               </li>");
            }

            _ds1.Dispose();
            
            _str.AppendLine("                               </ul>");
            _str.AppendLine("                           </div>");
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
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='iform'>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='iform-col'>");
            _str.AppendLine("                           <div class='ui segment list-grade'>");
            _str.AppendLine("                               <div class='ui middle aligned divided list'>");
            _str.AppendLine("                                   <div class='item'>");
            _str.AppendLine("                                       <div class='content'>");
            _str.AppendLine("                                           <div class='col1 list-col left floated left aligned header'>");
            _str.AppendLine("                                               <span class='lang lang-th f9 font-th regular black'>ภาคการศึกษา</span>");
            _str.AppendLine("                                               <span class='lang lang-en f9 font-en regular black'>Semester</span>");
            _str.AppendLine("                                           </div>");
            _str.AppendLine("                                           <div class='col2 list-col left aligned header'>");
            _str.AppendLine("                                               <span class='lang lang-th f9 font-th regular black'>เกรดเฉลี่ย</span>");
            _str.AppendLine("                                               <span class='lang lang-en f9 font-en regular black'>GPA</span>");
            _str.AppendLine("                                           </div>");
            _str.AppendLine("                                       </div>");
            _str.AppendLine("                                   </div>");

            DataSet _ds2 = SCHDB.GetStudentGPA(_dataRecorded["StudentCode"].ToString());

            foreach (DataRow _dr2 in _ds2.Tables[0].Rows)
            {
                _str.AppendLine("                               <div class='item'>");
                _str.AppendLine("                                   <div class='col1 list-col left floated left aligned content'>");
                _str.AppendFormat("                                     <span class='lang lang-th f10 font-th regular black'>{0}</span>", _dr2["sem"].ToString());
                _str.AppendFormat("                                     <span class='lang lang-en f10 font-en regular black'>{0}</span>", _dr2["sem"].ToString());
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='col2 list-col left aligned content'>");
                _str.AppendFormat("                                     <span class='lang lang-th f10 font-th regular black'>{0}</span>", _dr2["cGPA"].ToString());
                _str.AppendFormat("                                     <span class='lang lang-en f10 font-en regular black'>{0}</span>", _dr2["cGPA"].ToString());
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
            }

            _ds2.Dispose();

            _str.AppendLine("                               </div>");
            _str.AppendLine("                           </div>");
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

    public class AddUpdateUI
    {
        public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_REGISTERSCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendFormat("<div id='{0}'>", _idContent);
            _str.AppendFormat("     <input type='hidden' id='{0}-saveresult' value=''>", _idContent);
            _str.AppendLine("       <div class='view' >");
            _str.AppendLine("           <div class='iform' >");
            _str.AppendLine("               <div class='iform-row'>");
            _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกสมัครรับทุนจำนวน</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Total of</span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='total'></span> รายการ</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='total'></span> items</span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='iform-row'>");
            _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกสมัครรับทุนสำเร็จจำนวน</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Complete Total of</span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalcomplete'></span> <span class='totalunit'>รายการ</span></span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalcomplete'></span> <span class='totalunit'>items</span></span>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='iform-row'>");
            _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกสมัครรับทุนไม่สำเร็จจำนวน</span>");
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
            _str.AppendLine("           <div class='ui dividing header'></div>");
            _str.AppendLine("           <div class='three fields'>");
            _str.AppendLine("               <div class='five wide field'>");
            _str.AppendLine("                   <label>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ปีที่สมัครรับทุน</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Scholarship Year</span>");
            _str.AppendLine("                   </label>");
            _str.AppendLine(                    SCHUI.DDLYearEntry(_idContent + "-scholarshipsyear").ToString());
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='five wide field'>");
            _str.AppendLine("                   <label>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ภาคเรียนที่</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Semester</span>");
            _str.AppendLine("                   </label>");
            _str.AppendLine(                    SCHUI.DDLSemester(_idContent + "-semester").ToString());
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='six wide field'>");
            _str.AppendLine("                   <label>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>วันที่สมัครรับทุน</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Register Date</span>");
            _str.AppendLine("                   </label>");
            _str.AppendFormat("                 <div class='ui calendar' id='{0}-registerdate'>", _idContent);
            _str.AppendLine("                       <div class='ui input right icon'>");
            _str.AppendLine("                           <i class='calendar icon'></i>");
            _str.AppendLine("                           <input class='inputcalendar' type='text' placeholder='' placeholderth='' placeholderen='' value='' />");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("           <div class='fields'>");
            _str.AppendLine("               <div class='sixteen wide field'>");
            _str.AppendLine("                   <label>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>สมัครรับทุน</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Scholarship</span>");
            _str.AppendLine("                   </label>");
            _str.AppendLine(                    SCHUI.DDLScholarships(_idContent + "-scholarships").ToString());
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("           <div class='fields'>");
            _str.AppendLine("               <div class='sixteen wide field'>");
            _str.AppendLine("                   <label>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>หน่วยงานที่รับผิดขอบ</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Responsible Agency</span>");
            _str.AppendLine("                   </label>");
            _str.AppendFormat("                 <input id='{0}-responsibleagency' type='text' maxlength='255' placeholder=''  placeholderth='' placeholderen='' value='' />", _idContent);
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("           <div class='field'>");
            _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsave' alt='{1}'>", _idContent, SCHUtil.PAGE_REGISTERSCHOLARSHIP_ADDUPDATE);
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