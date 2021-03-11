using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;

public class SCHScholarshipUI
{
    public class MainUI
    {
        public static string _idContent = ("main-" + SCHUtil.SUBJECT_SCHOLARSHIP.ToLower());

        public static StringBuilder GetMain()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("<div class='ui horizontal divider header container'>");
            _str.AppendLine("   <i class='student icon font-th regular black'></i>&nbsp;");
            _str.AppendLine("   <span class='lang lang-th f7 font-th regular black'>ทุน</span>");
            _str.AppendLine("   <span class='lang lang-en f7 font-en regular black'>Scholarship</span>");
            _str.AppendLine("</div>");
            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
            _str.AppendFormat("     <div class='mini ui button' id='{0}-btnadd'>", _idContent);
            _str.AppendLine("           <i class='icon plus font-th regular black'></i>");
            _str.AppendLine("           <span class='lang lang-th f9 font-th regular black'>เพิ่มทุนใหม่</span>");
            _str.AppendLine("           <span class='lang lang-en f9 font-en regular black'>Add Scholarship</span>");
            _str.AppendLine("       </div>");
            _str.AppendFormat("     <div id='{0}'>{1}</div>", SearchUI._idContent, SearchUI.GetMain());
            _str.AppendFormat("     <div id='{0}'></div>", AddUpdateUI._idContent);
            _str.AppendFormat("     <div id='{0}'></div>", ListUI._idContent);
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");

            return _str;
        }
    }
    
    public class SearchUI
    {
        public static string _idContent = ("search-" + SCHUtil.SUBJECT_SCHOLARSHIP.ToLower());

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
            _str.AppendLine("               <div class='fields'>");
            _str.AppendLine("                   <div class='sixteen wide field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ประเภททุน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Type Scholarship</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLScholarshipsType(_idContent + "-scholarshipstype").ToString());
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
        public static string _idContent = ("list-" + SCHUtil.SUBJECT_SCHOLARSHIP.ToLower());

        public static StringBuilder GetMain(DataRow[] _dr)
        {
            StringBuilder _str = new StringBuilder();
            string _id = String.Empty;
            string _scholarshipsNameTH = String.Empty;
            string _scholarshipsNameEN = String.Empty;
            string _scholarshipsTypeId = String.Empty;
            string _scholarshipsTypeNameTH = String.Empty;
            string _scholarshipsTypeNameEN = String.Empty;
            string _approvalStatus = String.Empty;

            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendLine("   <div class='ui segments'>");
            _str.AppendLine("       <div class='ui segment grey inverted right aligned'>");
            _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span> </span>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui segment'>");
            _str.AppendLine("           <div class='ui items divided'>");

            if (_dr.GetLength(0) > 0)
            {
                foreach (DataRow _dr1 in _dr)
                {
                    _id                     = _dr1["id"].ToString();
                    _scholarshipsNameTH     = _dr1["scholarshipsNameTH"].ToString();
                    _scholarshipsNameEN     = (!String.IsNullOrEmpty(_dr1["scholarshipsNameEN"].ToString()) ? _dr1["scholarshipsNameEN"].ToString() : _scholarshipsNameTH);
                    _scholarshipsTypeId     = _dr1["schScholarshipsTypeId"].ToString();
                    _scholarshipsTypeNameTH = _dr1["scholarshipsTypeNameTH"].ToString();
                    _scholarshipsTypeNameEN = _dr1["scholarshipsTypeNameEN"].ToString();
                    _approvalStatus         = _dr1["approvalStatus"].ToString();

                    _str.AppendFormat("     <div class='item' id='{0}-id-{1}'>", _idContent, _id);
                    _str.AppendLine("           <div class='middle aligned content'>");
                    _str.AppendLine("               <div>");
                    _str.AppendFormat("                 <span class='lang lang-th f9 font-th regular black'>{0} <span class='lang lang-th f10 font-th regular muted'>- {1}</span></span>", _scholarshipsNameTH, _scholarshipsTypeNameTH);
                    _str.AppendFormat("                 <span class='lang lang-en f9 font-en regular black'>{0} <span class='lang lang-en f10 font-en regular muted'>- {1}</span></span>", _scholarshipsNameEN, _scholarshipsTypeNameEN);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='description'>");
                    _str.AppendLine("                   <div class='ui secondary menu'>");
                    _str.AppendLine("                       <div class='right menu'>");
                    _str.AppendFormat("                         <a class='item btnupdate' data-options='{0}'>", _id);
                    _str.AppendLine("                               <i class='icon pencil font-th regular muted'></i>");
                    _str.AppendLine("                               <span class='lang lang-th f10 font-th regular muted'>แก้ไข</span>");
                    _str.AppendLine("                               <span class='lang lang-en f10 font-en regular muted'>Edit</span>");
                    _str.AppendLine("                           </a>");
                    _str.AppendLine("                           <div class='ui pointing dropdown link item fg-grayLight combobox'>");
                    _str.AppendLine("                               <span class='text'>");

                    if (_approvalStatus.Equals("Y"))
                    {
                        _str.AppendLine("                               <span class='lang lang-th f10 font-th regular muted'>อนุมัติแล้ว</span>");
                        _str.AppendLine("                               <span class='lang lang-en f10 font-en regular muted'>Approved</span>");
                    }
                    else
                        {
                            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular muted'>ยกเลิก</span>");
                            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular muted'>Cancel</span>");
                        }                            
                    
                    _str.AppendLine("                               </span>");
                    _str.AppendLine("                               <i class='dropdown icon'></i>");
                    _str.AppendLine("                               <div class='menu'>");
                    _str.AppendFormat("                                 <div class='item btnsetactive' data-id='{0}' data-status='Y'>", _id);
                    _str.AppendLine("                                       <span class='lang lang-th f10 font-th regular muted'>อนุมัติแล้ว</span>");
                    _str.AppendLine("                                       <span class='lang lang-en f10 font-en regular muted'>Approved</span>");
                    _str.AppendLine("                                   </div>");
                    _str.AppendFormat("                                 <div class='item btnsetactive' data-id='{0}' data-status='N'>", _id);
                    _str.AppendLine("                                       <span class='lang lang-th f10 font-th regular muted'>ยกเลิก</span>");
                    _str.AppendLine("                                       <span class='lang lang-en f10 font-en regular muted'>Cancel</span>");
                    _str.AppendLine("                                   </div>");
                    _str.AppendLine("                               </div>");
                    _str.AppendLine("                           </div>");
                    _str.AppendLine("                       </div>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </div>");                
                }
            }

            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui segment grey inverted right aligned'>");
            _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
            _str.AppendLine("       </div>");
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");

            return _str;
        }
    }

    public class AddUpdateUI
    {
        public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_SCHOLARSHIP.ToLower());

        public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
        {
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_SCHOLARSHIP] : null);

            _str.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />",                     _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Id", _dataRecorded["Id"], "") : ""));
            _str.AppendFormat("<input type='hidden' id='{0}-scholarshipsnameth-hidden' value='{1}' />",     _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsNameTH", _dataRecorded["ScholarshipsNameTH"], "") : ""));
            _str.AppendFormat("<input type='hidden' id='{0}-scholarshipsnameen-hidden' value='{1}' />",     _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsNameEN", _dataRecorded["ScholarshipsNameEN"], "") : ""));
            _str.AppendFormat("<input type='hidden' id='{0}-scholarshipstype-hidden' value='{1}' />",       _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsTypeId", _dataRecorded["ScholarshipsTypeId"], "") : ""));
            _str.AppendFormat("<input type='hidden' id='{0}-scholarshipstypegroup-hidden' value='{1}' />",  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsTypeGroup", _dataRecorded["ScholarshipsTypeGroup"], "") : ""));
            _str.AppendFormat("<input type='hidden' id='{0}-owner-hidden' value='{1}' />",                  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Owner", _dataRecorded["Owner"], "") : ""));
            _str.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />",         _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ApprovalStatus", _dataRecorded["ApprovalStatus"], "Y") : "Y"));

            return _str;
        }

        public static StringBuilder GetMain(string _page, string _id)
        {
            StringBuilder _str = new StringBuilder();
            Dictionary<string, object> _valueDataRecorded = SCHUtil.SetValueDataRecorded(_page, _id, null);
            string _titleTH = String.Empty;
            string _titleEN = String.Empty;
            string _background = String.Empty;
        
            if (_page.Equals(SCHUtil.PAGE_SCHOLARSHIP_ADD))
            {
                _titleTH    = "เพิ่ม";
                _titleEN    = "Add";
                _background = "green";
            }

            if (_page.Equals(SCHUtil.PAGE_SCHOLARSHIP_UPDATE))
            {
                _titleTH    = "แก้ไข";
                _titleEN    = "Edit";
                _background = "orange";
            }

            _str.AppendLine("<div class='paddingTop10'>");
            _str.AppendLine(    GetValue(_valueDataRecorded).ToString());
            _str.AppendFormat(" <div class='ui form {0} inverted segment'>", _background);
            _str.AppendLine("       <div class='ui left floated header'>");
            _str.AppendFormat("         <span class='lang lang-th f9 font-th regular white'>{0}ทุน</span>", _titleTH);
            _str.AppendFormat("         <span class='lang lang-en f9 font-en regular white'>{0} Scholarship</span>", _titleEN);
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui right floated header'>");
            _str.AppendLine("           <i class='close icon link font-th regular white btnclose'></i>");
            _str.AppendLine("       </div>");
            _str.AppendLine("       <div class='ui header'></div>");
            _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
            _str.AppendLine("           <div class='ui inverted dividing header'></div>");
            _str.AppendLine("           <div class='panel-body'>");
            _str.AppendLine("               <div class='two fields'>");
            _str.AppendLine("                   <div class='field'>");        
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ชื่อทุนภาษาไทย</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Scholarship Thai Name</span>");
            _str.AppendLine("                       </label>");
            _str.AppendFormat("                     <input id='{0}-scholarshipsnameth' type='text' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ชื่อทุนภาษาอังกฤษ</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Scholarship English Name</span>");
            _str.AppendLine("                       </label>");
            _str.AppendFormat("                     <input id='{0}-scholarshipsnameen' type='text' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='two fields'>");
            _str.AppendLine("                   <div class='field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ประเภททุน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Type Scholarship</span>");
            _str.AppendLine("                       </label>");
            _str.AppendLine(                        SCHUI.DDLScholarshipsType(_idContent + "-scholarshipstype").ToString());
            _str.AppendLine("                   </div>");
            _str.AppendLine("                   <div class='field'>");
            _str.AppendLine("                       <label>");
            _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>เจ้าของทุน</span>");
            _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Scholarship Owner</span>");
            _str.AppendLine("                       </label>");
            _str.AppendFormat("                     <input id='{0}-owner' type='text' maxlength='255' placeholder=''  placeholderth='' placeholderen='' value='' />", _idContent);
            _str.AppendLine("                   </div>");
            _str.AppendLine("               </div>");
            _str.AppendLine("               <div class='field'>");
            _str.AppendFormat("                 <div class='ui button fluid inverted {0}' id='{1}-btnsave' data-options='{2}' alt='{3}'>", _background, _idContent, _id, _page);
            _str.AppendFormat("                     <i class='icon save font-th regular white'></i>");
            _str.AppendLine("                       <span class='lang lang-th f9 font-th regular white'>บันทึก</span>");
            _str.AppendLine("                       <span class='lang lang-en f9 font-en regular white'>Save</span>");
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