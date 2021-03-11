using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;

public class SCHImportRegisterScholarshipUI
{
    public class MainUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("<div class='ui horizontal divider header container'>");
            _str.AppendLine("   <i class='upload icon font-th regular black'></i>&nbsp;");
            _str.AppendLine("   <span class='lang lang-th f7 font-th regular black'>นำเข้าผู้สมัครรับทุน</span>");
            _str.AppendLine("   <span class='lang lang-en f7 font-en regular black'>Import Register Scholarship</span>");
            _str.AppendLine("</div>");
            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
            _str.AppendFormat("     <div class='mini ui button' id='{0}-btndownload'>", _idContent);
            _str.AppendLine("           <i class='file excel outline icon font-th regular black'></i>");
            _str.AppendLine("           <span class='lang lang-th f9 font-th regular black'>ดาวน์โหลดแบบบันทึกการรับทุน</span>");
            _str.AppendLine("           <span class='lang lang-en f9 font-en regular black'>Download Scholarship Register Template</span>");
            _str.AppendLine("       </div>");        
            _str.AppendFormat("     <div id='{0}'>{1}</div>", ImportUI._idContent, ImportUI.GetMain());
            _str.AppendFormat("     <div id='{0}'></div>", ListUI._idContent);
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");

            return _str;
        } 
    }

    public class ImportUI
    {
        public static string _idContent = ("import-" + SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendLine("   <div class='ui form blue inverted segment'>");
            _str.AppendLine("       <div class='ui left floated header'>");
            _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>นำเข้าไฟล์</span>");
            _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Import File</span>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui right floated header'>");
            _str.AppendFormat("         <i class='minus square icon link btnshrink font-th regular white' alt='{0}'></i>", _idContent);
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui header'></div>");
            _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
            _str.AppendLine("           <div class='ui inverted dividing header'></div>");
            _str.AppendLine("           <div class='panel-body'>");
            _str.AppendLine("               <div class='two fields'>");
            _str.AppendLine("                   <div class='sixteen wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ไฟล์ที่ต้องการนำเข้า</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Select File to Import</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine("                       <div class='ui fluid action input browsefile'>");
            _str.AppendFormat("                         <input type='text' id='{0}-relativefile' value='' />", _idContent);
            _str.AppendFormat("                         <label for='{0}-absolutefile' class='ui button'>", _idContent);
            _str.AppendLine("                               <i class='folder icon font-th regular black'></i>");
            _str.AppendLine("                               <span class='lang lang-th f9 font-th regular black'>เลือกไฟล์</span>");
            _str.AppendLine("                               <span class='lang lang-en f9 font-en regular black'>Browse</span>");
            _str.AppendLine("                           </label>");
            _str.AppendFormat("                         <input class='hidden' type='file' id='{0}-absolutefile' name='{0}-absolutefile' />", _idContent);
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <label class='paddingTop3'>");
            _str.AppendLine("                           <span class='lang lang-th f105 font-th regular black opacity05'>สนับสนุนไฟล์นามสกุล .xls</span>");
            _str.AppendLine("                           <span class='lang lang-en f105 font-en regular black opacity05'>Support for .xls extension files.</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='field'>");
            _str.AppendFormat("                 <div class='ui fluid button inverted blue' id='{0}-btnimport'>", _idContent);
            _str.AppendLine("                       <i class='upload icon font-th regular white'></i>");
            _str.AppendLine("                       <span class='lang lang-th f9 font-th regular white'>นำเข้า</span>");
            _str.AppendLine("                       <span class='lang lang-en f9 font-en regular white'>Import</span>");
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
        public static string _idContent = ("list-" + SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIP.ToLower());

        public static StringBuilder GetMain(Dictionary<string, object> _infoLogin, DataRow[] _dr)
        { 
            StringBuilder _str = new StringBuilder();            
            string _username = _infoLogin["Username"].ToString();
            string _userlevel = _infoLogin["Userlevel"].ToString();
            string _systemGroup = _infoLogin["SystemGroup"].ToString();
            string _personId = String.Empty;
            string _studentCode = String.Empty;
            string _fullNameTH = String.Empty;
            string _fullNameEN = String.Empty;
            string _scholarshipsId = String.Empty;
            string _scholarshipsNameTH = String.Empty;
            string _scholarshipsNameEN = String.Empty;
            string _responsibleAgency = String.Empty;
            string _scholarshipsYear = String.Empty;
            string _semester = String.Empty;
            string _tuition = String.Empty;
            string _remark = String.Empty;
            string _fontColor = String.Empty;
            string[] _msgTH = new string[5];
            string[] _msgEN = new string[5];
            int _error = 0;
            int _row = 0;
            int _i = 0;
            int _j = 0;
            int _indexArray = 0;
            int _recordCount = (_dr.GetLength(0) - 1);

            _str.AppendFormat("<div class='paddingTop10'>");
            _str.AppendLine("   <div class='ui horizontal segments table-title'>");        
            _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='save icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึก</span>");
            _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save</span>");
            _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'>{0}</span></span>", _recordCount);
            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'>{0}</span></span>", _recordCount);
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
            _str.AppendLine("           </tr>");
            _str.AppendLine("       </thead>");
            _str.AppendLine("       <tbody>");
        
            if (_recordCount > 0)
            {
                foreach(DataRow _dr1 in _dr)
                {
                    if (_row > 0)
                    {
                        _personId           = String.Empty;
                        _studentCode        = _dr1[3].ToString();
                        _fullNameTH         = String.Empty;
                        _fullNameEN         = String.Empty;
                        _scholarshipsNameTH = _dr1[4].ToString();
                        _scholarshipsNameEN = _scholarshipsNameTH;
                        _responsibleAgency  = _dr1[6].ToString();
                        _scholarshipsYear   = _dr1[1].ToString();
                        _semester           = _dr1[2].ToString();
                        _tuition            = _dr1[5].ToString();
                        _remark             = _dr1[7].ToString();
                                                       
                        _i = 0;
                        
                        DataSet _ds2 = SCHDB.GetSCHStudent(_username, _userlevel, _systemGroup, _studentCode);
                        _error       = (_ds2.Tables[0].Rows.Count > 0 ? 0 : 1);
                        
                        if (_error.Equals(0))
                        {                            
                            DataRow _dr2 = _ds2.Tables[0].Rows[0];

                            _personId    = _dr2["id"].ToString();
                            _studentCode = _dr2["studentCode"].ToString();
                            _fullNameTH  = SCHUtil.GetFullName(_dr2["titlePrefixInitialsTH"].ToString(), _dr2["titlePrefixFullNameTH"].ToString(), _dr2["firstName"].ToString(), _dr2["middleName"].ToString(), _dr2["lastName"].ToString());
                            _fullNameEN  = SCHUtil.GetFullName(_dr2["titlePrefixInitialsEN"].ToString(), _dr2["titlePrefixFullNameEN"].ToString(), _dr2["firstNameEN"].ToString(), _dr2["middleNameEN"].ToString(), _dr2["lastNameEN"].ToString()).ToUpper();
                        }
                        else
                            {                                
                                _msgTH[_i] = "ไม่พบนักศึกษา";
                                _msgEN[_i] = "Student not found.";
                                _i++;
                            }
                        
                        _ds2.Dispose();

                        DataSet _ds3 = SCHDB.GetScholarships("", _scholarshipsNameTH);
                        _error       = (_ds3.Tables[0].Rows.Count > 0 ? 0 : 1);

                        if (_error.Equals(0))
                        {
                            DataRow _dr3 = _ds3.Tables[0].Rows[0];

                            _scholarshipsId     = _dr3["id"].ToString();
                            _scholarshipsNameTH = _dr3["scholarshipsNameTH"].ToString();
                            _scholarshipsNameEN = (!String.IsNullOrEmpty(_dr3["scholarshipsNameEN"].ToString()) ? _dr3["scholarshipsNameEN"].ToString() : (!String.IsNullOrEmpty(_scholarshipsNameTH) ? _scholarshipsNameTH : ""));

                            if (String.IsNullOrEmpty(_responsibleAgency))
                            {
                                _msgTH[_i] = "ไม่พบหน่วยงานที่รับผิดชอบ";
                                _msgEN[_i] = "Responsible Agency not found.";
                                _i++;
                            }
                        }
                        else
                            {
                                _msgTH[_i] = "ไม่พบทุน";
                                _msgEN[_i] = "Scholarship not found.";
                                _i++;
                            }

                        _ds3.Dispose();

                        _indexArray = SCHUtil.FindIndexArray2D(1, SCHUtil._semester, _semester);
                        _error      = (_indexArray > 0 ? 0 : 1);

                        if (_error.Equals(0))
                            _semester = SCHUtil._semester[_indexArray - 1, 0];
                        else
                            {
                                _msgTH[_i] = "ไม่พบภาคเรียน";
                                _msgEN[_i] = "Semester not found.";
                                _i++;
                            }

                        try
                        {
                            _error = (!_tuition.Equals("0") ? 0 : 1);

                            if (_error.Equals(0))
                                _tuition = double.Parse(_tuition).ToString("#,##0.00");
                            else
                                {
                                    _msgTH[_i] = "จำนวนเงินต้องมากกว่า 0";
                                    _msgEN[_i] = "Amount must be greater than 0.";
                                    _i++;
                                }
                        }
                        catch
                        {
                            _msgTH[_i] = "รูปแบบจำนวนเงินไม่ถูกต้อง";
                            _msgEN[_i] = "Invalid number format.";
                            _i++;
                        }

                        _fontColor = (_i.Equals(0) ? "black" : "red");

                        _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId));
                        _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular {0}'>{1}</span>", _fontColor, _row.ToString("#,##0"));
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular {0}'>{1}</span>", _fontColor, _row.ToString("#,##0"));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='col2 checkbox'>");

                        if (_i.Equals(0))
                            _str.AppendLine("       <input type='checkbox' name='select-child' class='select-child checkbox checker' data-options='{\"studentId\":\"" + _studentCode + "\",\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\",\"responsibleAgency\":\"" + _responsibleAgency + "\",\"tuition\":\"" + _tuition.Replace(",", "") + "\",\"remark\":\"" + _remark + "\"}' value='" + _personId + ":" + _scholarshipsYear + ":" + _semester + ":" + _scholarshipsId + ":" + _responsibleAgency + ":" + _tuition.Replace(",", "") + ":" + _remark + "' />");

                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='รหัสนักศึกษา' data-contenten='Student ID'>");

                        if (_i.Equals(0))
                        {
                            _str.AppendLine("       <div class='ui green button btnstudentcv' data-options='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\"}'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular white'>{0}</span>", _studentCode);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular white'>{0}</span>", _studentCode);
                            _str.AppendLine("       </div>");
                        }
                        else
                            {
                                _str.AppendFormat(" <span class='lang lang-th f10 font-th regular red'>{0}</span>", _studentCode);
                                _str.AppendFormat(" <span class='lang lang-en f10 font-en regular red'>{0}</span>", _studentCode);
                            }

                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col4 left aligned' data-content='' data-contentth='ชื่อ - สกุล' data-contenten='Full Name'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular {0}'>{1}</span>", _fontColor, _fullNameTH);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular {0}'>{1}</span>", _fontColor, _fullNameEN);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col5 left aligned' data-content='' data-contentth='ทุน' data-contenten='Scholarship'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular {0} black'>{1}</span><span class='lang lang-th f10 font-th regular {2}'>{3}</span>", _fontColor, _scholarshipsNameTH, (_i.Equals(0) ? "muted" : "red"), (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular {0} black'>{1}</span><span class='lang lang-en f10 font-en regular {2}'>{3}</span>", _fontColor, _scholarshipsNameEN, (_i.Equals(0) ? "muted" : "red"), (!String.IsNullOrEmpty(_responsibleAgency) ? (" - " + _responsibleAgency) : ""));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='ปี / ภาคเรียนที่สมัครรับทุน' data-contenten='Scholarship on Year / Semester'>");
                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular {0}'>{1} / {2}</span>", _fontColor, _scholarshipsYear, _semester);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular {0}'>{1} / {2}</span>", _fontColor, _scholarshipsYear, _semester);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col7 right aligned' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");                        _str.AppendFormat("         <span class='lang lang-th f10 font-th regular {0}'>{1}</span>", _fontColor, _tuition);
                        _str.AppendFormat("         <span class='lang lang-en f10 font-en regular {0}'>{1}</span>", _fontColor, _tuition);
                        _str.AppendLine("       </td>");
                        _str.AppendLine("       <td class='tooltip col8 hide'>");
                        _str.AppendFormat("         <span>{0}</span>", _remark.Replace("\n", "<br />"));
                        _str.AppendLine("       </td>");
                        _str.AppendLine("   </tr>");

                        if (_i > 0)
                        {
                            _str.AppendLine("<tr>");
                            _str.AppendLine("   <td class='info-list' colspan='7'>");
                            _str.AppendLine("       <ul>");

                            for (_j = 0; _j < _i; _j++)
                            {
                                _str.AppendFormat("     <li class='lang lang-th f10 font-th regular white'>{0}</li>", _msgTH[_j]);
                                _str.AppendFormat("     <li class='lang lang-en f10 font-en regular white'>{0}</li>", _msgEN[_j]);
                            }

                            _str.AppendLine("       </ul>");
                            _str.AppendLine("   </td>");
                            _str.AppendLine("</tr>");
                        }
                        else
                            {
                                _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                                _str.AppendFormat("     <td class='preloading' colspan='8' id='{0}-id-{1}{2}{3}{4}'></td>", StudentCVUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                                _str.AppendLine("   </tr>");
                            }
                    }

                    _row++;
                }
            }
            _str.AppendLine("       </tbody>");
            _str.AppendLine("   </table>");
            _str.AppendLine("   <div class='ui horizontal segments table-title'>");
            _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
            _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
            _str.AppendLine("               <i class='save icon font-th regular white'></i>");
            _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึก</span>");
            _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
            _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save</span>");
            _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnregister-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnregister-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'>{0}</span></span>", _recordCount);
            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'>{0}</span></span>", _recordCount);
            _str.AppendLine("       </div>");
            _str.AppendLine("   </div>");
            _str.AppendLine("  </div>");
            return _str;
        }
    }

    public class StudentCVUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIP.ToLower());
        
        public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
        {
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIPSTUDENTCV] : null);

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
            string[] _valueArray = _id.Split('|');

            _paramSearch.Clear();
            _paramSearch.Add("PersonId",            _valueArray[0]);
            _paramSearch.Add("ScholarshipsYear",    _valueArray[1]);
            _paramSearch.Add("Semester",            _valueArray[2]);
            _paramSearch.Add("ScholarshipsId",      _valueArray[3]);

            _valueDataRecorded  = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN, "", _paramSearch);
            _dataRecorded       = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIPSTUDENTCV] : null);

            _studentCode        = _dataRecorded["StudentCode"].ToString();
            _fullNameTH         = SCHUtil.GetFullName(_dataRecorded["TitleInitialsTH"].ToString(), _dataRecorded["TitleFullNameTH"].ToString(), _dataRecorded["FirstName"].ToString(), _dataRecorded["MiddleName"].ToString(), _dataRecorded["LastName"].ToString());
            _fullNameEN         = SCHUtil.GetFullName(_dataRecorded["TitleInitialsEN"].ToString(), _dataRecorded["TitleFullNameEN"].ToString(), _dataRecorded["FirstNameEN"].ToString(), _dataRecorded["MiddleNameEN"].ToString(), _dataRecorded["LastNameEN"].ToString()).ToUpper();
            _facultyNameTH      = _dataRecorded["FacultyNameTH"].ToString();
            _facultyNameEN      = _dataRecorded["FacultyNameEN"].ToString();
            _programNameTH      = _dataRecorded["ProgramNameTH"].ToString();
            _programNameEN      = _dataRecorded["ProgramNameEN"].ToString();
            _statusTypeNameTH   = _dataRecorded["StatusTypeNameTH"].ToString();
            _statusTypeNameEN   = _dataRecorded["StatusTypeNameEN"].ToString();

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
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular blue'></span><span class='lang lang-th f10 font-th regular blue opacity05'></span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular blue'></span><span class='lang lang-en f10 font-en regular blue opacity05'></span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>สมัครรับทุนเมื่อ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Regerter When</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular blue'></span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular blue'></span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='iform-row'>");
            _str.AppendLine("                       <div class='col21 iform-col label-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular black'>หมายเหตุ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular black'>Remark</span>");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                       <div class='col22 iform-col input-col left aligned'>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular blue'></span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular blue'></span>");
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
        public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIP.ToLower());

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
            _str.AppendLine("           <div class='fields'>");
            _str.AppendLine("               <div class='sixteen wide field'>");
            _str.AppendLine("                   <label>");
            _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>วันที่สมัครรับทุน</span>");
            _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Register Date</span>");
            _str.AppendLine("                   </label>");
            _str.AppendFormat("                 <div class='ui calendar' id='{0}-registerdate'>", _idContent);
            _str.AppendLine("                       <div class='ui input right icon'>");
            _str.AppendLine("                           <i class='calendar icon'></i>");
            _str.AppendLine("                           <input class='inputcalendar' type='text' placeholder='' placeholderth='ระบุวันที่สมัครรับทุน' placeholderen='Enter Register Date' value='' />");
            _str.AppendLine("                       </div>");
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("           </div>");
            _str.AppendLine("           <div class='field'>");
            _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsave' alt='{1}'>", _idContent, SCHUtil.PAGE_IMPORTREGISTERSCHOLARSHIP_ADDUPDATE);
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