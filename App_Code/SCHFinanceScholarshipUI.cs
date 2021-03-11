using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;

public class SCHFinanceScholarshipUI
{
	public class ICLUI
	{
        public class MainUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL.ToLower());

            public static StringBuilder GetMain()
            {
                StringBuilder _str = new StringBuilder();

                _str.AppendLine("<div class='ui horizontal divider header container'>");
                _str.AppendLine("   <i class='pencil icon font-th regular black'></i>&nbsp;");
                _str.AppendLine("   <span class='lang lang-th f7 font-th regular black'>การเงิน ( กรอ. )</span>");
                _str.AppendLine("   <span class='lang lang-en f7 font-en regular black'>Finance ( ICL )</span>");
                _str.AppendLine("</div>");
                _str.AppendLine("<div class='paddingTop10'>");
                _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
                _str.AppendLine("       <div class='three horizontal item tabular ui menu top'>");        
                _str.AppendLine("           <a class='active item' data-tab='tab1'>");
                _str.AppendLine("               <span class='lang lang-th f9 font-th regular black'>บันทึกอนุมัติรับเงิน</span>");
                _str.AppendLine("               <span class='lang lang-en f9 font-en regular black'>Approval Receive Finance</span>");
                _str.AppendLine("           </a>");
                _str.AppendLine("           <a class='item' data-tab='tab2'>");
                _str.AppendLine("               <span class='lang lang-th f9 font-th regular black'>บันทึกจำแนกผู้รับเงิน</span>");
                _str.AppendLine("               <span class='lang lang-en f9 font-en regular black'>Classification Recipient Finance</span>");
                _str.AppendLine("           </a>");
                _str.AppendLine("           <a class='item' data-tab='tab3'>");
                _str.AppendLine("               <span class='lang lang-th f9 font-th regular black'>บันทึกจ่ายเช็ค</span>");
                _str.AppendLine("               <span class='lang lang-en f9 font-en regular black'>Pay Cheque</span>");
                _str.AppendLine("           </a>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='fluid vertical item tabular ui menu'>");        
                _str.AppendLine("           <a class='active item' data-tab='tab1'>");
                _str.AppendLine("               <span class='lang lang-th f9 font-th regular black'>บันทึกอนุมัติรับเงิน</span>");
                _str.AppendLine("               <span class='lang lang-en f9 font-en regular black'>Approval Receive Finance</span>");
                _str.AppendLine("           </a>");
                _str.AppendLine("           <a class='item' data-tab='tab2'>");
                _str.AppendLine("               <span class='lang lang-th f9 font-th regular black'>บันทึกจำแนกผู้รับเงิน</span>");
                _str.AppendLine("               <span class='lang lang-en f9 font-en regular black'>Classification Recipient Finance</span>");
                _str.AppendLine("           </a>");
                _str.AppendLine("           <a class='item' data-tab='tab3'>");
                _str.AppendLine("               <span class='lang lang-th f9 font-th regular black'>บันทึกจ่ายเช็ค</span>");
                _str.AppendLine("               <span class='lang lang-en f9 font-en regular black'>Pay Cheque</span>");
                _str.AppendLine("           </a>");
                _str.AppendLine("       </div>");
                _str.AppendFormat("     <div class='active ui tab' id='tab-{0}' data-tab='tab1'>{1}</div>", SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE.ToLower(), ApprovalReceiveFinanceUI.GetMain());
                _str.AppendFormat("     <div class='ui tab' id='tab-{0}' data-tab='tab2'></div>", SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE.ToLower());
                _str.AppendFormat("     <div class='ui tab' id='tab-{0}' data-tab='tab3'></div>", SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE.ToLower());
                _str.AppendLine("   </div>");
                _str.AppendLine("</div>");                
                
                return _str;
            }
        }

        public class ApprovalReceiveFinanceUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE.ToLower());

            public static StringBuilder GetMain()
            {
                StringBuilder _str = new StringBuilder();

                _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
                _str.AppendFormat("     <div class='mini ui button {0}' id='{0}-btnadd'>", _idContent);
                _str.AppendLine("           <i class='icon plus font-th regular black'></i>");
                _str.AppendLine("           <span class='lang lang-th f9 font-th regular black'>เพิ่มรายการเงินทุนที่ได้รับอนุมัติ</span>");
                _str.AppendLine("           <span class='lang lang-en f9 font-en regular black'>Add Approval Receive Finance</span>");
                _str.AppendLine("       </div>");
                _str.AppendFormat("     <div class='{0}' id='{1}'>{2}</div>", _idContent, SearchUI._idContent, SearchUI.GetMain());
                _str.AppendFormat("     <div class='{0}' id='{1}'></div>", _idContent, AddUpdateUI._idContent);
                _str.AppendFormat("     <div class='{0}' id='{1}'></div>", _idContent, ListUI._idContent);
                _str.AppendFormat("     <div id='{0}'></div>", SavePeopleApprovedUI._idContent);
                _str.AppendLine("   </div>");

                return _str;
            }

            public class SearchUI
            {
                public static string _idContent = ("search-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE.ToLower());

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
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ปี / ภาคเรียนที่อนุมัติรับเงิน</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Approval Receive Finance on Year / Semester</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendLine(                        SCHUI.DDLScholarshipsYearSemester((_idContent + "-scholarshipsyearsemester"), SCHUtil.SUBJECT_ICL).ToString());
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
                public static string _idContent = ("list-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE.ToLower());

                public static StringBuilder GetMain(DataRow[] _dr)
                {
                    StringBuilder _str = new StringBuilder();
                    string _row = String.Empty;
                    string _scholarshipsTypeGroup = String.Empty;
                    string _scholarshipsYear = String.Empty;
                    string _semester = String.Empty;
                    string _lotNo = String.Empty;
                    string _deliverNo = String.Empty;
                    string _deliverDate = String.Empty;
                    string _amount = String.Empty;
                    string _approveNumber = String.Empty;
                    string _totalApprove = String.Empty;
                    string _approveDate = String.Empty;
                    int _recordCount = _dr.GetLength(0);

                    _str.AppendLine("<div class='paddingTop10'>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
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
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col3'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ปี / ภาคเรียน<br />ที่อนุมัติรับเงิน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Approval Receive Finance<br />on Year / Semester</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col4'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>งวดที่</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Period</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col5'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>เลขที่ใบนำส่ง</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Delivery No.</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col6'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>วันที่นำส่ง</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Delivery Date</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col7'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงิน<br />( บาท )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount<br />( bath )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col8'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนผู้ที่ได้รับอนุมัติ<br />( คน )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Number of Approval<br />( people )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col9'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>วันที่รับเงิน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Date of<br />Receive Money</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("           </tr>");
                    _str.AppendLine("       </thead>");
                    _str.AppendLine("       <tbody>");

                    if (_recordCount > 0)
                    {
                        foreach (DataRow _dr1 in _dr)
                        {
                            _row                    = _dr1["rowNum"].ToString();
                            _scholarshipsTypeGroup  = _dr1["schScholarshipsTypeGroup"].ToString();
                            _scholarshipsYear       = _dr1["scholarshipsYear"].ToString();
                            _semester               = _dr1["semester"].ToString();
                            _lotNo                  = _dr1["lotNo"].ToString();
                            _deliverNo              = _dr1["deliverNo"].ToString();
                            _deliverDate            = (!String.IsNullOrEmpty(_dr1["deliverDate"].ToString()) ? DateTime.Parse(_dr1["deliverDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _amount                 = (!String.IsNullOrEmpty(_dr1["amount"].ToString()) ? double.Parse(_dr1["amount"].ToString()).ToString("#,##0.00") : "");
                            _amount                 = (_amount.Equals("0.00") ? "" : _amount);
                            _approveNumber          = (!String.IsNullOrEmpty(_dr1["approveNumber"].ToString()) ? double.Parse(_dr1["approveNumber"].ToString()).ToString("#,##0") : "");
                            _approveNumber          = (_approveNumber.Equals("0") ? "" : _approveNumber);
                            _totalApprove           = (!String.IsNullOrEmpty(_dr1["totalApprove"].ToString()) ? double.Parse(_dr1["totalApprove"].ToString()).ToString("#,##0") : "");
                            _approveDate            = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");

                            _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_scholarshipsTypeGroup + _scholarshipsYear + _semester + _lotNo));
                            _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col2 left aligned' data-content='' data-contentth='แก้ไข' data-contenten='Edit'>");

                            if (_totalApprove.Equals("0"))
                            {
                                _str.AppendFormat("     <div class='ui green button btnupdate' data-value='{0}|{1}|{2}|{3}'>", _scholarshipsTypeGroup, _scholarshipsYear, _semester, _lotNo);
                                _str.AppendLine("           <i class='icon pencil font-th regular white'></i>");
                                _str.AppendFormat("         <span class='lang lang-th f10 font-th regular white'>แก้ไข</span>");
                                _str.AppendFormat("         <span class='lang lang-en f10 font-en regular white'>Edit</span>");
                                _str.AppendLine("       </div>");
                            }

                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='ปี / ภาคเรียนที่อนุมัติรับเงิน' data-contenten='Approval Receive Finance on Year / Semester'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0} / {1}</span>", _scholarshipsYear, _semester);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0} / {1}</span>", _scholarshipsYear, _semester);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col4' data-content='' data-contentth='งวดที่' data-contenten='Period'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _lotNo);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _lotNo);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col5' data-content='' data-contentth='เลขที่ใบนำส่ง' data-contenten='Delivery No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _deliverNo);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _deliverNo);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='วันที่นำส่ง' data-contenten='Delivery Date'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _deliverDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _deliverDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col7 right aligned' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _amount);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _amount);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col8' data-content='' data-contentth='จำนวนผู้ที่ได้รับอนุมัติ' data-contenten='Number of Approval'>");
                            _str.AppendLine("           <div class='link-click link-savepeopleapproved' data-value='{\"scholarshipsTypeGroup\":\"" + _scholarshipsTypeGroup + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"lotNo\":\"" + _lotNo + "\"}'>");
                            _str.AppendFormat("             <span class='lang lang-th f10 font-th regular black link-click'>{0} ( {1} )</span>", _approveNumber, _totalApprove);
                            _str.AppendFormat("             <span class='lang lang-en f10 font-en regular black link-click'>{0} ( {1} )</span>", _approveNumber, _totalApprove);
                            _str.AppendLine("           </div>");
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='วันที่รับเงิน' data-contenten='Date of Receive Money'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _approveDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _approveDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("   </tr>");
                        }
                    }

                    _str.AppendLine("       </tbody>");
                    _str.AppendLine("   </table>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
                    _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'>{0}</span></span>");
                    _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'>{0}</span></span>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("   </div>");
                    _str.AppendLine("   <div class='table-navpage'></div>");
                    _str.AppendLine("</div>");

                    return _str;
                }
            }

            public class AddUpdateUI
            {
                public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE.ToLower());

                public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
                {
                    StringBuilder _str = new StringBuilder();
                    Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE] : null);
                    string _scholarshipsTypeGroup   = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsTypeGroup", _dataRecorded["ScholarshipsTypeGroup"], "") : "").ToString();
                    string _scholarshipsYear        = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsYear", _dataRecorded["ScholarshipsYear"], "") : "").ToString();
                    string _semester                = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Semester", _dataRecorded["Semester"], "") : "").ToString();
                    string _lotNo                   = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "LotNo", _dataRecorded["LotNo"], "") : "").ToString();

                    _str.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />",                     _idContent, (_scholarshipsTypeGroup + "|" + _scholarshipsYear + "|" + _semester + "|" + _lotNo));
                    _str.AppendFormat("<input type='hidden' id='{0}-scholarshipstypegroup-hidden' value='{1}' />",  _idContent, _scholarshipsTypeGroup);
                    _str.AppendFormat("<input type='hidden' id='{0}-scholarshipsyear-hidden' value='{1}' />",       _idContent, _scholarshipsYear);
                    _str.AppendFormat("<input type='hidden' id='{0}-semester-hidden' value='{1}' />",               _idContent, _semester);
                    _str.AppendFormat("<input type='hidden' id='{0}-lotno-hidden' value='{1}' />",                  _idContent, _lotNo);
                    _str.AppendFormat("<input type='hidden' id='{0}-deliverno-hidden' value='{1}' />",              _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "DeliverNo", _dataRecorded["DeliverNo"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-deliverdate-hidden' value='{1}' />",            _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "DeliverDate", _dataRecorded["DeliverDate"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-approvedate-hidden' value='{1}' />",            _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ApproveDate", _dataRecorded["ApproveDate"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-amount-hidden' value='{1}' />",                 _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Amount", _dataRecorded["Amount"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-approvenumber-hidden' value='{1}' />",          _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ApproveNumber", _dataRecorded["ApproveNumber"], "") : "").ToString());

                    return _str;
                }

                public static StringBuilder GetMain(string _page, string _id)
                {
                    StringBuilder _str = new StringBuilder();
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    Dictionary<string, object> _valueDataRecorded = new Dictionary<string, object>();
                    Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
                    string _titleTH = String.Empty;
                    string _titleEN = String.Empty;
                    string _background = String.Empty;
                    string[] _valueArray;

                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_ADD))
                    {
                        _titleTH    = "เพิ่ม";
                        _titleEN    = "Add";
                        _background = "green";
                    }

                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE))
                    {
                        _titleTH    = "แก้ไข";
                        _titleEN    = "Edit";
                        _background = "orange";
                        _valueArray = _id.Split('|');

                        _paramSearch.Clear();
                        _paramSearch.Add("ScholarshipsTypeGroup",   _valueArray[0]);
                        _paramSearch.Add("ScholarshipsYear",        _valueArray[1]);
                        _paramSearch.Add("Semester",                _valueArray[2]);
                        _paramSearch.Add("LotNo",                   _valueArray[3]);
                    }

                    _valueDataRecorded = SCHUtil.SetValueDataRecorded(_page, "", _paramSearch);

                    _str.AppendLine("<div class='paddingTop10'>");
                    _str.AppendLine(    GetValue(_valueDataRecorded).ToString());
                    _str.AppendFormat(" <div class='ui form {0} inverted segment'>", _background);
                    _str.AppendLine("       <div class='ui left floated header'>");
                    _str.AppendFormat("         <span class='lang lang-th f9 font-th regular white'>{0}รายการเงินที่ได้รับอนุมัติ</span>", _titleTH);
                    _str.AppendFormat("         <span class='lang lang-en f9 font-en regular white'>{0} Approved Finance List</span>", _titleEN);
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui right floated header'>");
                    _str.AppendLine("           <i class='close icon link font-th regular white btnclose'></i>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui header'></div>");
                    _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
                    _str.AppendLine("           <div class='ui inverted dividing header'></div>");
                    _str.AppendLine("           <div class='panel-body'>");
                    _str.AppendLine("               <div class='two fields'>");
                    _str.AppendLine("                   <div class='eight wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ปี / ภาคเรียนที่อนุมัติรับเงิน</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Approval Receive Finance on Year / Semester</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendLine(                        SCHUI.DDLScholarshipsYearSemester((_idContent + "-scholarshipsyearsemester"), SCHUtil.SUBJECT_ICL).ToString());
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='eight wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>งวดที่</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Period</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input id='{0}-lotno' type='text' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='three fields'>");
                    _str.AppendLine("                   <div class='eight wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>เลขที่ใบนำส่ง</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Delivery No.</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input id='{0}-deliverno' type='text' maxlength='15' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>วันที่นำส่ง</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Delivery Date</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <div class='ui calendar' id='{0}-deliverdate'>", _idContent);
                    _str.AppendLine("                           <div class='ui input right icon'>");
                    _str.AppendLine("                               <i class='calendar icon'></i>");
                    _str.AppendLine("                               <input class='inputcalendar' type='text' placeholder='' placeholderth='' placeholderen='' value='' />");
                    _str.AppendLine("                           </div>");
                    _str.AppendLine("                       </div>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>วันที่รับเงิน</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Date of Receive Money</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <div class='ui calendar' id='{0}-approvedate'>", _idContent);
                    _str.AppendLine("                           <div class='ui input right icon'>");
                    _str.AppendLine("                               <i class='calendar icon'></i>");
                    _str.AppendLine("                               <input class='inputcalendar' type='text' placeholder='' placeholderth='' placeholderen='' value='' />");
                    _str.AppendLine("                           </div>");
                    _str.AppendLine("                       </div>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='two fields'>");
                    _str.AppendLine("                   <div class='eight wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>จำนวนเงิน ( บาท )</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Amount ( bath )</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input class='textbox-numeric' id='{0}-amount' type='text' maxlength='13' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='eight wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>จำนวนผู้ที่ได้รับอนุมัติ ( คน )</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Number of Approval ( people )</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input class='textbox-numeric' id='{0}-approvenumber' type='text' maxlength='5' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='field'>");
                    _str.AppendFormat("                 <div class='ui button fluid inverted {0}' id='{1}-btnsave' data-value='{2}' alt='{3}'>", _background, _idContent, _id, _page);
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

        public class SavePeopleApprovedUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED.ToLower());

            public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _str = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED] : null);

                _str.AppendFormat("<input type='hidden' id='{0}-scholarshipstypegroup-hidden' value='{1}' />",  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsTypeGroup", _dataRecorded["ScholarshipsTypeGroup"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-scholarshipsyear-hidden' value='{1}' />",       _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ScholarshipsYear", _dataRecorded["ScholarshipsYear"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-semester-hidden' value='{1}' />",               _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Semester", _dataRecorded["Semester"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-lotno-hidden' value='{1}' />",                  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "LotNo", _dataRecorded["LotNo"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-amount-hidden' value='{1}' />",                 _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Amount", _dataRecorded["Amount"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-approvenumber-hidden' value='{1}' />",          _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ApproveNumber", _dataRecorded["ApproveNumber"], "") : "").ToString());

                return _str;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _str = new StringBuilder();
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                Dictionary<string, object> _valueDataRecorded = new Dictionary<string, object>();
                Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
                string _scholarshipsTypeGroup = String.Empty;
                string _scholarshipsYear = String.Empty;
                string _semester = String.Empty;
                string _semesterNameTH = String.Empty;
                string _semesterNameEN = String.Empty;
                string _lotNo = String.Empty;
                string _deliverNo = String.Empty;
                string _deliverDate = String.Empty;
                string _approveDate = String.Empty;
                string _amount = String.Empty;
                string _approveNumber = String.Empty;
                string[] _valueArray = _id.Split('|');

                _paramSearch.Clear();
                _paramSearch.Add("ScholarshipsTypeGroup",   _valueArray[0]);
                _paramSearch.Add("ScholarshipsYear",        _valueArray[1]);
                _paramSearch.Add("Semester",                _valueArray[2]);
                _paramSearch.Add("LotNo",                   _valueArray[3]);

                _valueDataRecorded      = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN, "", _paramSearch);
                _dataRecorded           = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED] : null);
                _scholarshipsTypeGroup  = _dataRecorded["ScholarshipsTypeGroup"].ToString();
                _scholarshipsYear       = _dataRecorded["ScholarshipsYear"].ToString();
                _semester               = _dataRecorded["Semester"].ToString();
                _semesterNameTH         = _dataRecorded["SemesterNameTH"].ToString();
                _semesterNameEN         = _dataRecorded["SemesterNameEN"].ToString();
                _lotNo                  = _dataRecorded["LotNo"].ToString();
                _deliverNo              = _dataRecorded["DeliverNo"].ToString();
                _deliverDate            = _dataRecorded["DeliverDate"].ToString();
                _approveDate            = _dataRecorded["ApproveDate"].ToString();
                _amount                 = _dataRecorded["Amount"].ToString();
                _approveNumber          = _dataRecorded["ApproveNumber"].ToString();

                _str.AppendLine( GetValue(_valueDataRecorded).ToString());
                _str.AppendLine("<div>");
                _str.AppendLine("   <div class='ui form orange inverted segment'>");
                _str.AppendLine("       <div class='ui left floated header'>");
                _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>บันทึกผู้ที่ได้รับอนุมัติ</span>");
                _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Save People Approved</span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui right floated header'>");
                _str.AppendLine("           <i class='close icon link font-th regular white btnclose'></i>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui header'></div>");
                _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
                _str.AppendLine("           <div class='ui dividing header'></div>");
                _str.AppendLine("           <div class='paddingTop14 panel-body'>");
                _str.AppendLine("               <div class='view'>");
                _str.AppendLine("                   <div class='iform'>");
                _str.AppendLine("                       <div class='iform-row'>");
                _str.AppendLine("                           <div class='col1 iform-col'>");
                _str.AppendLine("                               <div class='iform'>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col11 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>สมัครรับทุนเมื่อ</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Scholarship on</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col12 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0} / {1}</span>", _scholarshipsYear, _semesterNameTH);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0} / {1}</span>", _scholarshipsYear, _semesterNameEN);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col11 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>งวดที่</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Period</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col12 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _lotNo);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _lotNo);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='col2 iform-col'>");
                _str.AppendLine("                               <div class='iform'>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>จำนวนเงิน</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Amount</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span><span class='lang lang-th f10 font-th regular black'> บาท</span>", _amount);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span><span class='lang lang-en f10 font-en regular black'> bath</span>", _amount);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>จำนวนผู้ที่ได้รับอนุมัติ</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Number of Approval</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span><span class='lang lang-th f10 font-th regular black'> คน</span>", _approveNumber);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span><span class='lang lang-en f10 font-en regular black'> people</span>", _approveNumber);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='col3 iform-col'>");
                _str.AppendLine("                               <div class='iform'>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>เลขที่ใบนำส่ง</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Delivery No.</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _deliverNo);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _deliverNo);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>วันที่นำส่ง</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Delivery Date</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _deliverDate);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _deliverDate);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>วันที่รับเงิน</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Date of Receive Money</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _approveDate);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _approveDate);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                       </div>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("</div>");
                _str.AppendFormat("<div id='{0}'>{1}</div>", SearchUI._idContent, SearchUI.GetMain());
                _str.AppendFormat("<div id='{0}'></div>", ListUI._idContent);

                return _str;
            }

            public class SearchUI
            {
                public static string _idContent = ("search-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED.ToLower());

                public static StringBuilder GetMain()
                {
                    StringBuilder _str = new StringBuilder();

                    _str.AppendLine("<div class='ui form paddingBottom10'>");
                    _str.AppendLine("   <div class='panel-bodys'>");
                    _str.AppendLine("       <div class='ui dividing header'></div>");
                    _str.AppendLine("       <div class='panel-body'>");
                    _str.AppendLine("           <div class='two fields'>");
                    _str.AppendLine("               <div class='fourteen wide field'>");
                    _str.AppendLine(                    SCHUI.DDLApproveStatus((_idContent + "-approvestatus"), "เลือกสถานะการอนุมัติ", "Select Approve Status").ToString());
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='two wide field'>");
                    _str.AppendFormat("                 <div class='ui fluid button inverted grey' id='{0}-btnsearch'>", _idContent);
                    _str.AppendLine("                       <i class='search icon font-th regular black'></i>");
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
                public static string _idContent = ("list-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED.ToLower());

                public static StringBuilder GetMain(DataRow[] _dr)
                {
                    StringBuilder _str = new StringBuilder();
                    string _row = String.Empty;
                    string _personId = String.Empty;
                    string _studentCode = String.Empty;
                    string _fullNameTH = String.Empty;
                    string _fullNameEN = String.Empty;
                    string _statusGroup = String.Empty;
                    string _scholarshipsId = String.Empty;
                    string _scholarshipsTypeGroup = String.Empty;
                    string _registerDate = String.Empty;
                    string _scholarshipsYear = String.Empty;
                    string _semester = String.Empty;
                    string _lotNo = String.Empty;
                    string _contractDate = String.Empty;
                    string _tuition = String.Empty;                    
                    string _approveDate = String.Empty;
                    double _totalTuition = 0;
                    int _recordCount = _dr.GetLength(0);

                    _str.AppendLine("<div>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                    _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                    _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
                    _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกอนุมัติ</span>");
                    _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnapprove-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnapprove-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Approve</span>");
                    _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnapprove-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnapprove-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
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
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>สมัครรับทุน<br />เมื่อ</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Scholarship<br />on</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col6'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>งวดที่</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Period</span>");
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
                            _statusGroup            = _dr1["statusGroup"].ToString();
                            _scholarshipsId         = _dr1["schScholarshipsId"].ToString();
                            _scholarshipsTypeGroup  = _dr1["scholarshipsTypeGroup"].ToString();
                            _registerDate           = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _scholarshipsYear       = _dr1["scholarshipsYear"].ToString();
                            _semester               = _dr1["semester"].ToString();
                            _contractDate           = (!String.IsNullOrEmpty(_dr1["contractDate"].ToString()) ? DateTime.Parse(_dr1["contractDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _lotNo                  = _dr1["lotNo"].ToString();
                            _tuition                = (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()).ToString("#,##0.00") : "");
                            _tuition                = (_tuition.Equals("0.00") ? "" : _tuition);
                            _totalTuition           = (_totalTuition + (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()) : 0));
                            _approveDate            = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");

                            _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId));
                            _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='col2 checkbox'>");

                            if (!String.IsNullOrEmpty(_registerDate) && !String.IsNullOrEmpty(_contractDate) && String.IsNullOrEmpty(_approveDate) && _statusGroup.Equals("00"))
                                _str.AppendLine("       <input type='checkbox' name='select-child' class='select-child checkbox checker' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\",\"amount\":\"" + (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? _dr1["tuition"].ToString() : "0") + "\"}' />");

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
                            _str.AppendLine("       <td class='tooltip col5' data-content='' data-contentth='สมัครรับทุนเมื่อ' data-contenten='Scholarship on'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _registerDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _registerDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='งวดที่' data-contenten='Period'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _lotNo);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _lotNo);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col7' data-content='' data-contentth='วันทำสัญญา' data-contenten='Contract Date' data-value='{}'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _contractDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _contractDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col8 right aligned' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _tuition);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _tuition);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='วันที่อนุมัติรับทุน' data-contenten='Approve Date' data-value='{}'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _approveDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _approveDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("   </tr>");
                            _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendFormat("     <td class='preloading' colspan='9' id='{0}-id-{1}{2}{3}{4}'></td>", SCHFinanceScholarshipUI.ICLUI.SavePeopleApprovedUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendLine("   </tr>");

                        }
                    }

                    _str.AppendLine("       </tbody>");
                    _str.AppendLine("   </table>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                    _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                    _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
                    _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกอนุมัติ</span>");
                    _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnapprove-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnapprove-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Approve</span>");
                    _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnapprove-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnapprove-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
                    _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("           <br />");
                    _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>จำนวนเงิน <span class='sum-search'></span></span>");
                    _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Amount <span class='sum-search'></span></span>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("   </div>");
                    _str.AppendLine("</div>");

                    return _str;
                }
            }

            public class AddUpdateUI
            {
                public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED.ToLower());

                public static StringBuilder GetMain(string _id)
                {
                    StringBuilder _str = new StringBuilder();
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    Dictionary<string, object> _valueDataRecorded = new Dictionary<string, object>();
                    Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
                    string _totalApprove = String.Empty;
                    string _totalTuition = String.Empty;
                    string[] _valueArray = _id.Split('|');

                    _paramSearch.Clear();
                    _paramSearch.Add("ScholarshipsTypeGroup",   _valueArray[0]);
                    _paramSearch.Add("ScholarshipsYear",        _valueArray[1]);
                    _paramSearch.Add("Semester",                _valueArray[2]);
                    _paramSearch.Add("LotNo",                   _valueArray[3]);

                    _valueDataRecorded  = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE, "", _paramSearch);
                    _dataRecorded       = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED] : null);
                    _totalApprove       = _dataRecorded["TotalApprove"].ToString();
                    _totalTuition       = _dataRecorded["TotalTuition"].ToString();

                    _str.AppendFormat("<div id='{0}'>", _idContent);
                    _str.AppendFormat("     <input type='hidden' id='{0}-saveresult' value=''>", _idContent);
                    _str.AppendLine("       <div class='view' >");
                    _str.AppendLine("           <div class='iform' >");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกผู้ที่ได้รับอนุมัติจำนวน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Total of</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='total'></span> รายการ</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='total'></span> items</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกผู้ที่ได้รับอนุมัติสำเร็จจำนวน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Complete Total of</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalcomplete'></span> <span class='totalunit'>รายการ</span></span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalcomplete'></span> <span class='totalunit'>items</span></span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกผู้ที่ได้รับอนุมัติไม่สำเร็จจำนวน</span>");
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
                    _str.AppendLine("               <div class='seven wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ผู้ที่ได้รับอนุมัติที่บันทึกแล้วจำนวน ( คน )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Has Been Saved Approval Total of ( people )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-approvenumbersave' type='text' value='{1}' />", _idContent, _totalApprove);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='five wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกผู้ที่ได้รับอนุมัติจำนวน ( คน )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Approval Total of ( people )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-approvenumber' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='four wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>รวมจำนวนผู้ที่ได้รับอนุมัติ ( คน )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Approval Total of ( people )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-totalapprove' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("           <div class='three fields'>");
                    _str.AppendLine("               <div class='seven wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>จำนวนเงินที่บันทึกแล้ว ( บาท )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Has Been Saved Amount Total of ( bath )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-amountsave' type='text' value='{1}' />", _idContent, _totalTuition);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='five wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจำนวนเงิน ( บาท )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Amount Total of ( bath )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-amount' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='four wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>รวมจำนวนเงิน ( บาท )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Amount Total of ( bath )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-totalamount' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("           <div class='field'>");
                    _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsave' alt='{1}'>", _idContent, SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE);
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

        public class ClassificationRecipientFinanceUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE.ToLower());

            public static StringBuilder GetMain()
            {
                StringBuilder _str = new StringBuilder();

                _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
                _str.AppendFormat("     <div class='{0}' id='{1}'>{2}</div>", _idContent, SearchUI._idContent, SearchUI.GetMain());
                _str.AppendFormat("     <div class='{0}' id='{1}'></div>", _idContent, ListUI._idContent);
                _str.AppendLine("   </div>");

                return _str;
            }

            public class SearchUI
            {
                public static string _idContent = ("search-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE.ToLower());

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
                    _str.AppendLine("           <div class='two fields'>");
                    _str.AppendLine("               <div class='eight wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>ปี / ภาคเรียนที่อนุมัติรับเงิน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Approval Receive Finance on Year / Semester</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendLine(                    SCHUI.DDLScholarshipsYearSemester((_idContent + "-scholarshipsyearsemester"), SCHUtil.SUBJECT_ICL).ToString());
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='eight wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>งวดที่อนุมัติรับเงิน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Approval Receive Finance on Period</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <div id='{0}-lotno-dropdown'>{1}</div>", _idContent, SCHUI.DDLLotNoApprovalReceiveFinance((_idContent + "-lotno"), "", "", ""));
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("           <div class='two fields'>");
                    _str.AppendLine("               <div class='eight wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>ผู้รับเงิน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Group Receiver</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendLine(                    SCHUI.DDLGroupReceiver((_idContent + "-groupreceiver"), "Y").ToString());
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='eight wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular white'>สถานะการจำแนกผู้รับเงิน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular white'>Classification Recipient Finance Status</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendLine(                    SCHUI.DDLRecipientStatus(_idContent + "-recipientstatus").ToString());
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
                public static string _idContent = ("list-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE.ToLower());

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
                    string _invoiceAmount = String.Empty;
                    string _groupReceiverId = String.Empty;
                    string _groupReceiverNameTH = String.Empty;
                    string _groupReceiverNameEN = String.Empty;
                    string _registerDate = String.Empty;
                    string _contractDate = String.Empty;
                    string _approveDate = String.Empty;
                    string _transferDate = String.Empty;
                    int _recordCount = _dr.GetLength(0);

                    _str.AppendLine("<div class='paddingTop10'>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                    _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                    _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
                    _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกผู้รับเงิน</span>");
                    _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Recipient</span>");
                    _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
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
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงินที่ขอกู้<br />( บาท )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount of Loan<br />( bath )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col7'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงินในใบแจ้งหนี้<br />( บาท )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount in Invoice<br />( bath )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col8'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ผู้รับเงิน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Recipient</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col9'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>บันทึกผู้รับเงิน<br />เมื่อ</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Recipient<br />When</span>");
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
                            _invoiceAmount          = (!String.IsNullOrEmpty(_dr1["invoiceAmount"].ToString()) ? double.Parse(_dr1["invoiceAmount"].ToString()).ToString("#,##0.00") : "");
                            _invoiceAmount          = (_tuition.Equals("0.00") ? "" : _invoiceAmount);
                            _groupReceiverId        = _dr1["schGroupReceiverId"].ToString();
                            _groupReceiverNameTH    = _dr1["groupReceiverNameTH"].ToString();
                            _groupReceiverNameEN    = _dr1["groupReceiverNameEN"].ToString();
                            _registerDate           = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _contractDate           = (!String.IsNullOrEmpty(_dr1["contractDate"].ToString()) ? DateTime.Parse(_dr1["contractDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _approveDate            = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _transferDate           = (!String.IsNullOrEmpty(_dr1["transferDate"].ToString()) ? DateTime.Parse(_dr1["transferDate"].ToString()).ToString("dd/MM/yyyy") : "");

                            _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId));
                            _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='col2 checkbox'>");

                            if (!String.IsNullOrEmpty(_registerDate) && !String.IsNullOrEmpty(_contractDate) && !String.IsNullOrEmpty(_lotNo) && !String.IsNullOrEmpty(_approveDate))
                                _str.AppendLine("       <input type='checkbox' name='select-child' class='select-child checkbox checker' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\",\"groupReceiverId\":\"" + _groupReceiverId + "\",\"amount\":\"" + (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? _dr1["tuition"].ToString() : "0") + "\"}' />");

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
                            _str.AppendLine("       <td class='tooltip col5' data-content='' data-contentth='คณะ' data-contenten='Faculty'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _facultyCode);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _facultyCode);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col6 right aligned' data-content='' data-contentth='จำนวนเงินที่ขอกู้' data-contenten='Amount of Loan'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _tuition);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _tuition);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col7 right aligned' data-content='' data-contentth='จำนวนเงินในใบแจ้งหนี้' data-contenten='Amount in Invoice'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _invoiceAmount);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _invoiceAmount);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col8' data-content='' data-contentth='ผู้รับเงิน' data-contenten='Recipient'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _groupReceiverNameTH);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _groupReceiverNameEN);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='วันที่บันทึกผู้รับเงิน' data-contenten='Recipient Date' data-value='{}'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _transferDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _transferDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("   </tr>");
                            _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendFormat("     <td class='preloading' colspan='9' id='{0}-id-{1}{2}{3}{4}'></td>", SCHFinanceScholarshipUI.ICLUI.ClassificationRecipientFinanceUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendLine("   </tr>");
                        }
                    }
                    
                    _str.AppendLine("       </tbody>");
                    _str.AppendLine("   </table>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                    _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                    _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
                    _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกผู้รับเงิน</span>");
                    _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Recipient</span>");
                    _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
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

            public class AddUpdateUI
            {
                public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE.ToLower());

                public static StringBuilder GetMain()
                {
                    StringBuilder _str = new StringBuilder();

                    _str.AppendFormat("<div id='{0}'>", _idContent);
                    _str.AppendFormat("     <input type='hidden' id='{0}-saveresult' value=''>", _idContent);
                    _str.AppendLine("       <div class='view' >");
                    _str.AppendLine("           <div class='iform' >");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจำแนกผู้รับเงินจำนวน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Total of</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='total'></span> รายการ</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='total'></span> items</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจำแนกผู้รับเงินสำเร็จจำนวน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Complete Total of</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalcomplete'></span> <span class='totalunit'>รายการ</span></span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalcomplete'></span> <span class='totalunit'>items</span></span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจำแนกผู้รับเงินไม่สำเร็จจำนวน</span>");
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
                    _str.AppendLine("           <div class='two fields'>");
                    _str.AppendLine("               <div class='eight wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจำแนกผู้รับเงินจำนวน ( คน )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Classification Recipient Finance Total of ( people )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-recipientnumber' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='eight wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจำนวนเงิน ( บาท )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Amount Total of ( bath )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-amount' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("           <div class='field'>");
                    _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsave' alt='{1}'>", _idContent, SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_ADDUPDATE);
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

        public class PayChequeUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE.ToLower());

            public static StringBuilder GetMain()
            {
                StringBuilder _str = new StringBuilder();

                _str.AppendFormat(" <div class='ui container' id='{0}'>", _idContent);
                _str.AppendFormat("     <div class='mini ui button {0}' id='{0}-btnadd'>", _idContent);
                _str.AppendLine("           <i class='icon plus font-th regular black'></i>");
                _str.AppendLine("           <span class='lang lang-th f9 font-th regular black'>เพิ่มรายการจ่ายเช็ค</span>");
                _str.AppendLine("           <span class='lang lang-en f9 font-en regular black'>Add Pay Cheque</span>");
                _str.AppendLine("       </div>");
                _str.AppendFormat("     <div class='{0}' id='{1}'>{2}</div>", _idContent, SearchUI._idContent, SearchUI.GetMain());
                _str.AppendFormat("     <div class='{0}' id='{1}'></div>", _idContent, AddUpdateUI._idContent);
                _str.AppendFormat("     <div class='{0}' id='{1}'></div>", _idContent, ListUI._idContent);
                _str.AppendFormat("     <div id='{0}'></div>", SavePeoplePayChequeUI._idContent);
                _str.AppendLine("   </div>");

                return _str;
            }

            public class SearchUI
            {
                public static string _idContent = ("search-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE.ToLower());

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
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ปี / ภาคเรียนที่จ่ายเช็ค</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Pay Cheque on Year / Semester</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendLine(                        SCHUI.DDLScholarshipsYearSemester((_idContent + "-paychequeyearsemester"), SCHUtil.SUBJECT_ICL).ToString());
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
                public static string _idContent = ("list-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE.ToLower());

                public static StringBuilder GetMain(DataRow[] _dr)
                {
                    StringBuilder _str = new StringBuilder();
                    string _row = String.Empty;
                    string _payChequeYear = String.Empty;
                    string _semester = String.Empty;
                    string _lotNo = String.Empty;
                    string _PVJVNo = String.Empty;
                    string _chequeNo = String.Empty;
                    string _groupReceiverNameTH = String.Empty;
                    string _groupReceiverNameEN = String.Empty;
                    string _bankCode = String.Empty;
                    string _amount = String.Empty;
                    string _receiverNumber = String.Empty;
                    string _totalRecipient = String.Empty;                    
                    string _paidDate = String.Empty;
                    int _recordCount = _dr.GetLength(0);
                    
                    _str.AppendLine("<div class='paddingTop10'>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
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
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col3'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ปี / ภาคเรียน<br />ที่จ่ายเช็ค</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Pay Cheque<br />on Year / Semester</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col4'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>งวดที่<br/ >จ่าย / โอน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Pay<br />Period</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col5'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>เลขที่ PV / JV</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>PV / JV<br />No.</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col6'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>เลขที่เช็ค</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Cheque<br />No.</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col7'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ผู้รับเงิน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Recipient</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col8'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนผู้รับเงิน<br />( คน )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Number of Recipient<br />( people )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col9'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงิน<br />( บาท )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount<br />( bath )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col10'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>วันที่จ่ายเช็ค</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Date of Pay Cheque</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("           </tr>");
                    _str.AppendLine("       </thead>");
                    _str.AppendLine("       <tbody>");

                    if (_recordCount > 0)
                    {
                        foreach (DataRow _dr1 in _dr)
                        {
                            _row                    = _dr1["rowNum"].ToString();
                            _payChequeYear          = _dr1["payChequeYear"].ToString();
                            _semester               = _dr1["semester"].ToString();
                            _lotNo                  = _dr1["lotNo"].ToString();
                            _PVJVNo                 = _dr1["PVJVNo"].ToString();
                            _chequeNo               = _dr1["chequeNo"].ToString();
                            _groupReceiverNameTH    = _dr1["groupReceiverNameTH"].ToString();
                            _groupReceiverNameEN    = _dr1["groupReceiverNameEN"].ToString();
                            _bankCode               = _dr1["bankCode"].ToString();
                            _receiverNumber         = (!String.IsNullOrEmpty(_dr1["receiverNumber"].ToString()) ? double.Parse(_dr1["receiverNumber"].ToString()).ToString("#,##0") : "");
                            _receiverNumber         = (_receiverNumber.Equals("0") ? "" : _receiverNumber);
                            _totalRecipient         = (!String.IsNullOrEmpty(_dr1["totalRecipient"].ToString()) ? double.Parse(_dr1["totalRecipient"].ToString()).ToString("#,##0") : "");
                            _amount                 = (!String.IsNullOrEmpty(_dr1["amount"].ToString()) ? double.Parse(_dr1["amount"].ToString()).ToString("#,##0.00") : "");
                            _amount                 = (_amount.Equals("0.00") ? "" : _amount);
                            _paidDate               = (!String.IsNullOrEmpty(_dr1["paidDate"].ToString()) ? DateTime.Parse(_dr1["paidDate"].ToString()).ToString("dd/MM/yyyy") : "");

                            _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_payChequeYear + _semester + _lotNo + _PVJVNo + _chequeNo));
                            _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col2' data-content='' data-contentth='แก้ไข' data-contenten='Edit'>"); 
                            _str.AppendFormat("         <div class='ui green button btnupdate' data-value='{0}|{1}|{2}|{3}|{4}'>", _payChequeYear, _semester, _lotNo, _PVJVNo, _chequeNo);
                            _str.AppendLine("               <i class='icon pencil font-th regular white'></i>");
                            _str.AppendFormat("             <span class='lang lang-th f10 font-th regular white'>แก้ไข</span>");
                            _str.AppendFormat("             <span class='lang lang-en f10 font-en regular white'>Edit</span>");
                            _str.AppendLine("           </div>");
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col3' data-content='' data-contentth='ปี / ภาคเรียนที่จ่ายเช็ค' data-contenten='Pay Cheque on Year / Semester'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0} / {1}</span>", _payChequeYear, _semester);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0} / {1}</span>", _payChequeYear, _semester);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col4' data-content='' data-contentth='งวดที่จ่าย / โอน' data-contenten='Pay Period'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _lotNo);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _lotNo);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col5' data-content='' data-contentth='เลขที่ PV / JV' data-contenten='PV / JVNo No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _PVJVNo);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _PVJVNo);
                            _str.AppendLine("       </td>");                    
                            _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='เลขที่เช็ค' data-contenten='Cheque No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _chequeNo);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _chequeNo);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col7' data-content='' data-contentth='ผู้รับเงิน' data-contenten='Recipient'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}{1}</span>", _groupReceiverNameTH, (!String.IsNullOrEmpty(_bankCode) ? ("<br />( " + _bankCode + " )") : ""));
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}{1}</span>", _groupReceiverNameEN, (!String.IsNullOrEmpty(_bankCode) ? ("<br />( " + _bankCode + " )") : ""));
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col8' data-content='' data-contentth='จำนวนผู้รับเงิน' data-contenten='Number of Recipient'>");
                            _str.AppendLine("           <div class='link-click link-savepeoplepaycheque' data-value='{\"payChequeYear\":\"" + _payChequeYear + "\",\"semester\":\"" + _semester + "\",\"lotNo\":\"" + _lotNo + "\",\"PVJVNo\":\"" + _PVJVNo + "\",\"chequeNo\":\"" + _chequeNo + "\"}'>");
                            _str.AppendFormat("             <span class='lang lang-th f10 font-th regular black link-click'>{0} ( {1} )</span>", _receiverNumber, _totalRecipient);
                            _str.AppendFormat("             <span class='lang lang-en f10 font-en regular black link-click'>{0} ( {1} )</span>", _receiverNumber, _totalRecipient);
                            _str.AppendLine("           </div>");
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col9 right aligned' data-content='' data-contentth='จำนวนเงิน' data-contenten='Amount'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _amount);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _amount);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col10' data-content='' data-contentth='วันที่จ่ายเช็ค' data-contenten='Date of Pay Cheque'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _paidDate);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _paidDate);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("   </tr>");
                        }
                    }
                    
                    _str.AppendLine("       </tbody>");
                    _str.AppendLine("   </table>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
                    _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'>{0}</span></span>");
                    _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'>{0}</span></span>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("   </div>");
                    _str.AppendLine("   <div class='table-navpage'></div>");
                    _str.AppendLine("</div>");

                    return _str;
                }
            }

            public class AddUpdateUI
            {
                public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE.ToLower());
                
                public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
                {
                    StringBuilder _str = new StringBuilder();
                    Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE] : null);
                    string _payChequeYear   = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "PayChequeYear", _dataRecorded["PayChequeYear"], "") : "").ToString();
                    string _semester        = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Semester", _dataRecorded["Semester"], "") : "").ToString();
                    string _lotNo           = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "LotNo", _dataRecorded["LotNo"], "") : "").ToString();
                    string _PVJVNo          = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "PVJVNo", _dataRecorded["PVJVNo"], "") : "").ToString();
                    string _chequeNo        = (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ChequeNo", _dataRecorded["ChequeNo"], "") : "").ToString();

                    _str.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />",             _idContent, (_payChequeYear + "|" + _semester + "|" + _lotNo + "|" + _PVJVNo + "|" + _chequeNo));
                    _str.AppendFormat("<input type='hidden' id='{0}-paychequeyear-hidden' value='{1}' />",  _idContent, _payChequeYear);
                    _str.AppendFormat("<input type='hidden' id='{0}-semester-hidden' value='{1}' />",       _idContent, _semester);
                    _str.AppendFormat("<input type='hidden' id='{0}-lotno-hidden' value='{1}' />",          _idContent, _lotNo);
                    _str.AppendFormat("<input type='hidden' id='{0}-pvjvno-hidden' value='{1}' />",         _idContent, _PVJVNo);
                    _str.AppendFormat("<input type='hidden' id='{0}-chequeno-hidden' value='{1}' />",       _idContent, _chequeNo);
                    _str.AppendFormat("<input type='hidden' id='{0}-groupreceiver-hidden' value='{1}' />",  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "GroupReceiverId", _dataRecorded["GroupReceiverId"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-bankcode-hidden' value='{1}' />",       _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "BankId", _dataRecorded["BankId"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-amount-hidden' value='{1}' />",         _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Amount", _dataRecorded["Amount"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-receivernumber-hidden' value='{1}' />", _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ReceiverNumber", _dataRecorded["ReceiverNumber"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-preparedate-hidden' value='{1}' />",    _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "PrepareDate", _dataRecorded["PrepareDate"], "") : "").ToString());
                    _str.AppendFormat("<input type='hidden' id='{0}-paiddate-hidden' value='{1}' />",       _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "PaidDate", _dataRecorded["PaidDate"], "") : "").ToString());

                    return _str;
                }
                
                public static StringBuilder GetMain(string _page, string _id)
                {
                    StringBuilder _str = new StringBuilder();
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    Dictionary<string, object> _valueDataRecorded = new Dictionary<string, object>();
                    Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
                    string _titleTH = String.Empty;
                    string _titleEN = String.Empty;
                    string _background = String.Empty;
                    string[] _valueArray;

                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_ADD))
                    {
                        _titleTH    = "เพิ่ม";
                        _titleEN    = "Add";
                        _background = "green";
                    }

                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE))
                    {
                        _titleTH    = "แก้ไข";
                        _titleEN    = "Edit";
                        _background = "orange";
                        _valueArray = _id.Split('|');

                        _paramSearch.Clear();
                        _paramSearch.Add("PayChequeYear",   _valueArray[0]);
                        _paramSearch.Add("Semester",        _valueArray[1]);
                        _paramSearch.Add("LotNo",           _valueArray[2]);
                        _paramSearch.Add("PVJVNo",          _valueArray[3]);
                        _paramSearch.Add("ChequeNo",        _valueArray[4]);
                    }

                    _valueDataRecorded = SCHUtil.SetValueDataRecorded(_page, "", _paramSearch);

                    _str.AppendLine("<div class='paddingTop10'>");
                    _str.AppendLine(    GetValue(_valueDataRecorded).ToString());
                    _str.AppendFormat(" <div class='ui form {0} inverted segment'>", _background);
                    _str.AppendLine("       <div class='ui left floated header'>");
                    _str.AppendFormat("         <span class='lang lang-th f9 font-th regular white'>{0}รายการจ่ายเช็ค</span>", _titleTH);
                    _str.AppendFormat("         <span class='lang lang-en f9 font-en regular white'>{0} Pay Cheque</span>", _titleEN);
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui right floated header'>");
                    _str.AppendLine("           <i class='close icon link font-th regular white btnclose'></i>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui header'></div>");
                    _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
                    _str.AppendLine("           <div class='ui inverted dividing header'></div>");
                    _str.AppendLine("           <div class='panel-body'>");                    
                    _str.AppendLine("               <div class='four fields'>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ปี / ภาคเรียนที่จ่ายเช็ค</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Pay Cheque on Year / Semester</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendLine(                        SCHUI.DDLScholarshipsYearSemester((_idContent + "-paychequeyearsemester"), SCHUtil.SUBJECT_ICL).ToString());
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>งวดที่จ่าย / โอน</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Pay Period</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input class='textbox-numeric textalignleft' id='{0}-lotno' type='text' maxlength='2' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>เลขที่ PV / JV</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>PV / JV No.</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input class='textbox-numeric textalignleft' id='{0}-pvjvno' type='text' maxlength='10' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>เลขที่เช็ค</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Cheque No.</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input class='textbox-numeric textalignleft' id='{0}-chequeno' type='text' maxlength='7' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='four fields'>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>ผู้รับเงิน</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Group Receiver</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendLine(                        SCHUI.DDLGroupReceiver((_idContent + "-groupreceiver"), "").ToString());
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>บัญชีธนาคาร</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Bank</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendLine(                        SCHUI.DDLBank(_idContent + "-bankcode").ToString());
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>จำนวนเงิน ( บาท )</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Amount ( bath )</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input class='textbox-numeric' id='{0}-amount' type='text' maxlength='13' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>จำนวนผู้รับเงิน ( คน )</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Number of Recipient ( people )</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <input class='textbox-numeric' id='{0}-receivernumber' type='text' maxlength='5' placeholder='' placeholderth='' placeholderen='' value='' />", _idContent);
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='four fields'>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>วันที่เตรียมข้อมูล</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Date of Prepare</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <div class='ui calendar' id='{0}-preparedate'>", _idContent);
                    _str.AppendLine("                           <div class='ui input right icon'>");
                    _str.AppendLine("                               <i class='calendar icon'></i>");
                    _str.AppendLine("                               <input class='inputcalendar' type='text' placeholder='' placeholderth='' placeholderen='' value='' />");
                    _str.AppendLine("                           </div>");
                    _str.AppendLine("                       </div>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'>");
                    _str.AppendLine("                       <label>");
                    _str.AppendLine("                           <span class='lang lang-th f10 font-th regular white'>วันที่จ่ายเช็ค</span>");
                    _str.AppendLine("                           <span class='lang lang-en f10 font-en regular white'>Date of Pay Cheque</span>");
                    _str.AppendLine("                       </label>");
                    _str.AppendFormat("                     <div class='ui calendar' id='{0}-paiddate'>", _idContent);
                    _str.AppendLine("                           <div class='ui input right icon'>");
                    _str.AppendLine("                               <i class='calendar icon'></i>");
                    _str.AppendLine("                               <input class='inputcalendar' type='text' placeholder='' placeholderth='' placeholderen='' value='' />");
                    _str.AppendLine("                           </div>");
                    _str.AppendLine("                       </div>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='four wide field'></div>");
                    _str.AppendLine("                   <div class='four wide field'></div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='field'>");
                    _str.AppendFormat("                 <div class='ui button fluid inverted {0}' id='{1}-btnsave' data-value='{2}' alt='{3}'>", _background, _idContent, _id, _page);
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

        public class SavePeoplePayChequeUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE.ToLower());

            public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _str = new StringBuilder();                
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE] : null);

                _str.AppendFormat("<input type='hidden' id='{0}-paychequeyear-hidden' value='{1}' />",  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "PayChequeYear", _dataRecorded["PayChequeYear"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-semester-hidden' value='{1}' />",       _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Semester", _dataRecorded["Semester"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-lotno-hidden' value='{1}' />",          _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "LotNo", _dataRecorded["LotNo"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-pvjvno-hidden' value='{1}' />",         _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "PVJVNo", _dataRecorded["PVJVNo"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-chequeno-hidden' value='{1}' />",       _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ChequeNo", _dataRecorded["ChequeNo"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-groupreceiver-hidden' value='{1}' />",  _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "GroupReceiverId", _dataRecorded["GroupReceiverId"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-bankid-hidden' value='{1}' />",         _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "BankId", _dataRecorded["BankId"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-amount-hidden' value='{1}' />",         _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "Amount", _dataRecorded["Amount"], "") : "").ToString());
                _str.AppendFormat("<input type='hidden' id='{0}-receivernumber-hidden' value='{1}' />", _idContent, (_dataRecorded != null ? SCHUtil.GetValueDataDictionary(_dataRecorded, "ReceiverNumber", _dataRecorded["ReceiverNumber"], "") : "").ToString());

                return _str;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _str = new StringBuilder();
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                Dictionary<string, object> _valueDataRecorded = new Dictionary<string, object>();
                Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
                string _payChequeYear = String.Empty;
                string _semester = String.Empty;
                string _semesterNameTH = String.Empty;
                string _semesterNameEN = String.Empty;
                string _lotNo = String.Empty;
                string _PVJVNo = String.Empty;
                string _chequeNo = String.Empty;
                string _groupReceiver = String.Empty;
                string _groupReceiverNameTH = String.Empty;
                string _groupReceiverNameEN = String.Empty;
                string _bankCode = String.Empty;
                string _amount = String.Empty;
                string _receiverNumber = String.Empty;
                string _paidDate = String.Empty;
                string _prepareDate = String.Empty;
                string[] _valueArray = _id.Split('|');

                _paramSearch.Clear();
                _paramSearch.Add("PayChequeYear",   _valueArray[0]);
                _paramSearch.Add("Semester",        _valueArray[1]);
                _paramSearch.Add("LotNo",           _valueArray[2]);
                _paramSearch.Add("PVJVNo",          _valueArray[3]);
                _paramSearch.Add("ChequeNo",        _valueArray[4]);

                _valueDataRecorded      = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN, "", _paramSearch);
                _dataRecorded           = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE] : null);
                _payChequeYear          = _dataRecorded["PayChequeYear"].ToString();
                _semester               = _dataRecorded["Semester"].ToString();
                _semesterNameTH         = _dataRecorded["SemesterNameTH"].ToString();
                _semesterNameEN         = _dataRecorded["SemesterNameEN"].ToString();
                _lotNo                  = _dataRecorded["LotNo"].ToString();
                _PVJVNo                 = _dataRecorded["PVJVNo"].ToString();
                _chequeNo               = _dataRecorded["ChequeNo"].ToString();
                _groupReceiver          = _dataRecorded["GroupReceiverId"].ToString();
                _groupReceiverNameTH    = _dataRecorded["GroupReceiverNameTH"].ToString();
                _groupReceiverNameEN    = _dataRecorded["GroupReceiverNameEN"].ToString();
                _bankCode               = _dataRecorded["BankCode"].ToString(); 
                _amount                 = _dataRecorded["Amount"].ToString();
                _receiverNumber         = _dataRecorded["ReceiverNumber"].ToString();
                _paidDate               = _dataRecorded["PaidDate"].ToString();
                _prepareDate            = _dataRecorded["PrepareDate"].ToString();

                _str.AppendLine( GetValue(_valueDataRecorded).ToString());
                _str.AppendLine("<div>");
                _str.AppendLine("   <div class='ui form orange inverted segment'>");
                _str.AppendLine("       <div class='ui left floated header'>");
                _str.AppendLine("           <span class='lang lang-th f9 font-th regular white'>บันทึกจ่ายเช็ค</span>");
                _str.AppendLine("           <span class='lang lang-en f9 font-en regular white'>Save People Pay Cheque</span>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui right floated header'>");
                _str.AppendLine("           <i class='close icon link font-th regular white btnclose'></i>");
                _str.AppendLine("       </div>");
                _str.AppendLine("       <div class='ui header'></div>");
                _str.AppendLine("       <div class='paddingTop5 panel-bodys'>");
                _str.AppendLine("           <div class='ui dividing header'></div>");
                _str.AppendLine("           <div class='paddingTop14 panel-body'>");
                _str.AppendLine("               <div class='view'>");
                _str.AppendLine("                   <div class='iform'>");
                _str.AppendLine("                       <div class='iform-row'>");
                _str.AppendLine("                           <div class='col1 iform-col'>");
                _str.AppendLine("                               <div class='iform'>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col11 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>จ่ายเช็คเมื่อ</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Pay Cheque on</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col12 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0} / {1}</span>", _payChequeYear, _semesterNameTH);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0} / {1}</span>", _payChequeYear, _semesterNameEN);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col11 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>งวดที่จ่าย / โอน</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Pay Period</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col12 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _lotNo);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _lotNo);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col11 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>เลขที่ PV / JV</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>PV / JV No.</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col12 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _PVJVNo);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _PVJVNo);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col11 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>เลขที่เช็ค</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Cheque No.</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col12 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _chequeNo);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _chequeNo);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='col2 iform-col'>");
                _str.AppendLine("                               <div class='iform'>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>ผู้รับเงิน</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Group Receiver</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _groupReceiverNameTH);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _groupReceiverNameEN);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>บัญชีธนาคาร</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Bank</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _bankCode);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _bankCode);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>จำนวนเงิน</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Amount</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span><span class='lang lang-th f10 font-th regular black'> บาท</span>", _amount);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span><span class='lang lang-en f10 font-en regular black'> bath</span>", _amount);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col21 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>จำนวนผู้รับเงิน</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Number of Recipient</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col22 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span><span class='lang lang-th f10 font-th regular black'> คน</span>", _receiverNumber);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span><span class='lang lang-en f10 font-en regular black'> people</span>", _receiverNumber);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                           <div class='col3 iform-col'>");
                _str.AppendLine("                               <div class='iform'>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>วันที่เตรียมข้อมูล</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Date of Prepare</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _prepareDate);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _prepareDate);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                                   <div class='iform-row'>");
                _str.AppendLine("                                       <div class='col31 iform-col label-col left aligned'>");
                _str.AppendLine("                                           <span class='lang lang-th f10 font-th regular black'>วันที่จ่ายเช็ค</span>");
                _str.AppendLine("                                           <span class='lang lang-en f10 font-en regular black'>Date of Pay Cheque</span>");
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                       <div class='col32 iform-col input-col left aligned'>");
                _str.AppendFormat("                                         <span class='lang lang-th f10 font-th regular blue'>{0}</span>", _paidDate);
                _str.AppendFormat("                                         <span class='lang lang-en f10 font-en regular blue'>{0}</span>", _paidDate);
                _str.AppendLine("                                       </div>");
                _str.AppendLine("                                   </div>");
                _str.AppendLine("                               </div>");
                _str.AppendLine("                           </div>");
                _str.AppendLine("                       </div>");
                _str.AppendLine("                   </div>");
                _str.AppendLine("               </div>");
                _str.AppendLine("           </div>");
                _str.AppendLine("       </div>");
                _str.AppendLine("   </div>");
                _str.AppendLine("</div>");
                _str.AppendFormat("<div id='{0}'>{1}</div>", SearchUI._idContent, SearchUI.GetMain());
                _str.AppendFormat("<div id='{0}'></div>", ListUI._idContent);

                return _str;
            }

            public class SearchUI
            {
                public static string _idContent = ("search-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE.ToLower());

                public static StringBuilder GetMain()
                {
                    StringBuilder _str = new StringBuilder();

                    _str.AppendLine("<div class='ui form paddingBottom10'>");
                    _str.AppendLine("   <div class='panel-bodys'>");
                    _str.AppendLine("       <div class='ui dividing header'></div>");
                    _str.AppendLine("       <div class='panel-body'>");
                    _str.AppendLine("           <div class='two fields'>");
                    _str.AppendLine("               <div class='fourteen wide field'>");
                    _str.AppendLine(                    SCHUI.DDLPayChequeStatus((_idContent + "-paychequestatus"), "เลือกสถานะการบันทึกจ่ายเช็ค", "Select Pay Cheque Status").ToString());
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='two wide field'>");
                    _str.AppendFormat("                 <div class='ui fluid button inverted grey' id='{0}-btnsearch'>", _idContent);
                    _str.AppendLine("                       <i class='search icon font-th regular black'></i>");
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
                public static string _idContent = ("list-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE.ToLower());

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
                    string _scholarshipsYear = String.Empty;
                    string _semester = String.Empty;
                    string _tuition = String.Empty;
                    string _bankCode = String.Empty;
                    string _lotNo = String.Empty;
                    string _groupReceiver = String.Empty;
                    string _chequeId = String.Empty;
                    string _registerDate = String.Empty;
                    string _contractDate = String.Empty;
                    string _approveDate = String.Empty;
                    string _transferDate = String.Empty;
                    int _recordCount = _dr.GetLength(0);
                    
                    _str.AppendLine("<div>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                    _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                    _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
                    _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกจ่ายเช็ค</span>");
                    _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Pay Cheque</span>");
                    _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
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
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>ปี / ภาคเรียน<br />ที่อนุมัติรับเงิน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Approval Receive Finance<br />on Year / Semester</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col7'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>จำนวนเงินที่ได้รับ<br />( บาท )</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Amount<br />( bath )</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col8'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>บัญชีธนาคาร</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Bank</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("               <th class='col9'>");
                    _str.AppendLine("                   <span class='lang lang-th f9 font-th regular black'>งวดที่<br />จ่าย / โอน</span>");
                    _str.AppendLine("                   <span class='lang lang-en f9 font-en regular black'>Pay Period</span>");
                    _str.AppendLine("               </th>");
                    _str.AppendLine("           </tr>");
                    _str.AppendLine("       </thead>");
                    _str.AppendLine("       <tbody>");
                    
                    if (_recordCount > 0)
                    {
                        foreach(DataRow _dr1 in _dr)
                        {
                            _row                = _dr1["rowNum"].ToString();
                            _personId           = _dr1["id"].ToString();
                            _studentCode        = _dr1["studentCode"].ToString();
                            _fullNameTH         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString());
                            _fullNameEN         = SCHUtil.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper();
                            _facultyCode        = _dr1["facultyCode"].ToString();
                            _statusGroup        = _dr1["statusGroup"].ToString();
                            _scholarshipsId     = _dr1["schScholarshipsId"].ToString();
                            _scholarshipsYear   = _dr1["scholarshipsYear"].ToString();
                            _semester           = _dr1["semester"].ToString();                            
                            _tuition            = (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? double.Parse(_dr1["tuition"].ToString()).ToString("#,##0.00") : "");
                            _tuition            = (_tuition.Equals("0.00") ? "" : _tuition);
                            _bankCode           = _dr1["bankCode"].ToString();
                            _lotNo              = _dr1["schChequeLotNo"].ToString();
                            _groupReceiver      = _dr1["schGroupReceiverId"].ToString();
                            _chequeId           = _dr1["chequeId"].ToString();
                            _registerDate       = (!String.IsNullOrEmpty(_dr1["registerDate"].ToString()) ? DateTime.Parse(_dr1["registerDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _contractDate       = (!String.IsNullOrEmpty(_dr1["contractDate"].ToString()) ? DateTime.Parse(_dr1["contractDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _approveDate        = (!String.IsNullOrEmpty(_dr1["approveDate"].ToString()) ? DateTime.Parse(_dr1["approveDate"].ToString()).ToString("dd/MM/yyyy") : "");
                            _transferDate       = (!String.IsNullOrEmpty(_dr1["transferDate"].ToString()) ? DateTime.Parse(_dr1["transferDate"].ToString()).ToString("dd/MM/yyyy") : "");

                            _str.AppendFormat(" <tr class='center aligned' id='{0}-id-{1}'>", _idContent, (_personId + _scholarshipsYear + _semester + _scholarshipsId));
                            _str.AppendLine("       <td class='tooltip col1' data-content='' data-contentth='ที่' data-contenten='No.'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", int.Parse(_row).ToString("#,##0"));
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='col2 checkbox'>");

                            if (!String.IsNullOrEmpty(_registerDate) && !String.IsNullOrEmpty(_contractDate) && !String.IsNullOrEmpty(_approveDate) && !String.IsNullOrEmpty(_groupReceiver) && !String.IsNullOrEmpty(_transferDate) && String.IsNullOrEmpty(_chequeId) && _statusGroup.Equals("00"))
                                _str.AppendLine("       <input type='checkbox' name='select-child' class='select-child checkbox checker' data-value='{\"personId\":\"" + _personId + "\",\"scholarshipsYear\":\"" + _scholarshipsYear + "\",\"semester\":\"" + _semester + "\",\"scholarshipsId\":\"" + _scholarshipsId + "\",\"amount\":\"" + (!String.IsNullOrEmpty(_dr1["tuition"].ToString()) ? _dr1["tuition"].ToString() : "0") + "\"}' />");

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
                            _str.AppendLine("       <td class='tooltip col5' data-content='' data-contentth='คณะ' data-contenten='Faculty'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _facultyCode);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _facultyCode);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col6' data-content='' data-contentth='ปี / ภาคเรียนที่อนุมัติรับเงิน' data-contenten='Approval Receive Finance on Year / Semester'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0} / {1}</span>", _scholarshipsYear, _semester);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0} / {1}</span>", _scholarshipsYear, _semester);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col7 right aligned' data-content='' data-contentth='จำนวนเงินที่ได้รับ' data-contenten='Amount'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _tuition);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _tuition);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col8' data-content='' data-contentth='บัญชีธนาคาร' data-contenten='Bank'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _bankCode);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _bankCode);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("       <td class='tooltip col9' data-content='' data-contentth='งวดที่จ่าย / โอน' data-contenten='Pay Period'>");
                            _str.AppendFormat("         <span class='lang lang-th f10 font-th regular black'>{0}</span>", _lotNo);
                            _str.AppendFormat("         <span class='lang lang-en f10 font-en regular black'>{0}</span>", _lotNo);
                            _str.AppendLine("       </td>");
                            _str.AppendLine("   </tr>");
                            _str.AppendFormat(" <tr class='center aligned hide ui {0}' id='{1}-studentcv-{2}{3}{4}{5}'>", SCHUtil.SUBJECT_STUDENTCV.ToLower(), _idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendFormat("     <td class='preloading' colspan='9' id='{0}-id-{1}{2}{3}{4}'></td>", SCHFinanceScholarshipUI.ICLUI.SavePeoplePayChequeUI._idContent, _personId, _scholarshipsYear, _semester, _scholarshipsId);
                            _str.AppendLine("   </tr>");
                        }
                    }

                    _str.AppendLine("       </tbody>");
                    _str.AppendLine("   </table>");
                    _str.AppendLine("   <div class='ui horizontal segments table-title'>");
                    _str.AppendLine("       <div class='ui segment left floated grey inverted'>");
                    _str.AppendFormat("         <div class='mini ui grey inverted button btnoption {0} button-overflow'>", (_recordCount.Equals(0) ? "disabled" : ""));
                    _str.AppendLine("               <i class='pointing up icon font-th regular white'></i>");
                    _str.AppendLine("               <span class='lang lang-th f10 font-th regular white'>บันทึกจ่ายเช็ค</span>");
                    _str.AppendFormat("             <div class='lang lang-th f11 font-th regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>ทั้งหมด</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>เฉพาะที่เลือก</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("               <span class='lang lang-en f10 font-en regular white'>Save Pay Cheque</span>");
                    _str.AppendFormat("             <div class='lang lang-en f11 font-en regular white'><a class='btnsave-option' href='javascript:void(0)' alt='{0}'>All</a> | <a class='btnsave-option' href='javascript:void(0)' alt='{1}'>Selected</a></div>", SCHUtil._selectOption[0].ToLower(), SCHUtil._selectOption[1].ToLower());
                    _str.AppendLine("           </div>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("       <div class='ui segment right floated right aligned grey inverted recordcount'>");
                    _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>พบ <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Found <span class='recordcountprimary-search'></span></span>");
                    _str.AppendLine("           <br />");
                    _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>จำนวนเงิน <span class='sum-search'></span></span>");
                    _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Amount <span class='sum-search'></span></span>");
                    _str.AppendLine("       </div>");
                    _str.AppendLine("   </div>");
                    _str.AppendLine("</div>");

                    return _str;
                }
            }

            public class AddUpdateUI
            {
                public static string _idContent = ("addupdate-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE.ToLower());

                public static StringBuilder GetMain(string _id)
                {
                    StringBuilder _str = new StringBuilder();
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    Dictionary<string, object> _valueDataRecorded = new Dictionary<string, object>();
                    Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
                    string _totalRecipient = String.Empty;
                    string _totalTuition = String.Empty;
                    string[] _valueArray = _id.Split('|');

                    _paramSearch.Clear();
                    _paramSearch.Add("PayChequeYear",   _valueArray[0]);
                    _paramSearch.Add("Semester",        _valueArray[1]);
                    _paramSearch.Add("LotNo",           _valueArray[2]);
                    _paramSearch.Add("PVJVNo",          _valueArray[3]);
                    _paramSearch.Add("ChequeNo",        _valueArray[4]);

                    _valueDataRecorded  = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE, "", _paramSearch);
                    _dataRecorded       = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE] : null);
                    _totalRecipient     = _dataRecorded["TotalRecipient"].ToString();
                    _totalTuition       = _dataRecorded["TotalTuition"].ToString();

                    _str.AppendFormat("<div id='{0}'>", _idContent);
                    _str.AppendFormat("     <input type='hidden' id='{0}-saveresult' value=''>", _idContent);
                    _str.AppendLine("       <div class='view' >");
                    _str.AppendLine("           <div class='iform' >");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจ่ายเช็คจำนวน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Total of</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='total'></span> รายการ</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='total'></span> items</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจ่ายเช็คสำเร็จจำนวน</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Complete Total of</span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("                   <div class='col2 iform-col input-col left aligned paddingLeft10'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular blue'><span class='totalcomplete'></span> <span class='totalunit'>รายการ</span></span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular blue'><span class='totalcomplete'></span> <span class='totalunit'>items</span></span>");
                    _str.AppendLine("                   </div>");
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='iform-row'>");
                    _str.AppendLine("                   <div class='col1 iform-col label-col left aligned'>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจ่ายเช็คไม่สำเร็จจำนวน</span>");
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
                    _str.AppendLine("               <div class='seven wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ผู้รับเงินที่บันทึกจ่ายเข็คแล้วจำนวน ( คน )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Has Been Saved Pay Cheque Total of ( people )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-receivernumbersave' type='text' value='{1}' />", _idContent, _totalRecipient);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='five wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>ผู้รับเงินที่บันทึกจ่ายเช็คจำนวน ( คน )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Pay Cheque Total of ( people )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-receivernumber' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='four wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>รวมจำนวนผู้รับเงินที่บันทึกจ่ายเช็ค ( คน )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Approval Total of ( people )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-totalrecipient' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("           <div class='three fields'>");
                    _str.AppendLine("               <div class='seven wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>จำนวนเงินที่บันทึกแล้ว ( บาท )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Has Been Saved Amount Total of ( bath )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-amountsave' type='text' value='{1}' />", _idContent, _totalTuition);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='five wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>บันทึกจำนวนเงิน ( บาท )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Save Amount Total of ( bath )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-amount' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("               <div class='four wide field'>");
                    _str.AppendLine("                   <label>");
                    _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>รวมจำนวนเงิน ( บาท )</span>");
                    _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Amount Total of ( bath )</span>");
                    _str.AppendLine("                   </label>");
                    _str.AppendFormat("                 <input id='{0}-totalamount' type='text' value='' />", _idContent);
                    _str.AppendLine("               </div>");
                    _str.AppendLine("           </div>");
                    _str.AppendLine("           <div class='field'>");
                    _str.AppendFormat("             <div class='ui fluid button inverted blue' id='{0}-btnsave' alt='{1}'>", _idContent, SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE);
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

        public class StudentCVUI
        {
            public static string _idContent = ("main-" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV.ToLower());

            public static StringBuilder GetValue(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _str = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV] : null);

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

                _valueDataRecorded      = SCHUtil.SetValueDataRecorded(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN, "", _paramSearch);
                _dataRecorded           = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + SCHUtil.SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV] : null);
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
}