using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

public class SCHUI
{
    public static StringBuilder GetHeader()
    {
        StringBuilder _str = new StringBuilder();

        _str.AppendLine("<div class='ui container'>");
        _str.AppendLine(    GetMenu().ToString());
        _str.AppendLine("   <div id='main-logosystemname'>");
        _str.AppendLine("       <div class='ui stackable two column grid'>");
        _str.AppendLine("           <div class='wide column'>");
        _str.AppendLine("               <div class='lang lang-th'><img class='ui image floated' src='../Content/Image/LogowTH.png' /></div>");
        _str.AppendLine("               <div class='lang lang-en'><img class='ui image floated' src='../Content/Image/LogowEN.png' /></div>");
        _str.AppendLine("           </div>");
        _str.AppendLine("           <div class='wide column'>");
        _str.AppendLine("               <div class='lang lang-th paddingTop5'><img class='th ui image right floated' src='../Content/Image/HeadingStringTH.png' /></div>");
        _str.AppendLine("               <div class='lang lang-en paddingTop5'><img class='en ui image right floated' src='../Content/Image/HeadingStringEN.png' /></div>");
        _str.AppendLine("           </div>");
        _str.AppendLine("       </div>");
        _str.AppendLine("   </div>");
        _str.AppendLine("</div>");

        return _str;
    }

    public static StringBuilder GetMenu()
    {
        StringBuilder _str = new StringBuilder();

        _str.AppendLine("<div class='ui large secondary inverted pointing menu'>");
        _str.AppendLine("   <a class='toc item on-left'>");
        _str.AppendLine("       <span class='f9 font-th regular white'><i class='sidebar icon'></i></span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <div class='mulogo on-left'><img src='../Content/Image/Logo_icon.png' /></div>");
        _str.AppendLine("   <a class='item systemname'>");
        _str.AppendLine("       <span class='lang lang-th f10 font-th regular white'>ระบบทุนการศึกษา</span>");
        _str.AppendLine("       <span class='lang lang-en f10 font-en regular white'>Mahidol Scholarship</span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <a class='item btnscholarship button-bar hide'>");
        _str.AppendLine("       <span class='f9 font-th regular white'><i class='student icon'></i></span>");
        _str.AppendLine("       <span class='lang lang-th f10 font-th regular white'>ทุน</span>");
        _str.AppendLine("       <span class='lang lang-en f10 font-en regular white'>Scholarship</span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <a class='item btnregisterscholarship button-bar hide'>");
        _str.AppendLine("       <span class='f9 font-th regular white'><i class='pointing up icon'></i></span>");
        _str.AppendLine("       <span class='lang lang-th f10 font-th regular white'>สมัครรับทุน</span>");
        _str.AppendLine("       <span class='lang lang-en f10 font-en regular white'>Register</span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <a class='item btnmanagescholarship button-bar hide'>");
        _str.AppendLine("       <span class='f9 font-th regular white'><i class='money icon'></i></span>");
        _str.AppendLine("       <span class='lang lang-th f10 font-th regular white'>จัดการทุน</span>");
        _str.AppendLine("       <span class='lang lang-en f10 font-en regular white'>Approve</span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <a class='item btnimportregisterscholarship button-bar hide'>");
        _str.AppendLine("       <span class='f9 font-th regular white'><i class='upload icon'></i></span>");
        _str.AppendLine("       <span class='lang lang-th f10 font-th regular white'>นำเข้า</span>");
        _str.AppendLine("       <span class='lang lang-en f10 font-en regular white'>Import</span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <a class='item btnfinancescholarshiptypegroupicl button-bar hide'>");
        _str.AppendLine("       <span class='f9 font-th regular white'><i class='pencil icon'></i></span>");
        _str.AppendLine("       <span class='lang lang-th f10 font-th regular white'>การเงิน ( กรอ. )</span>");
        _str.AppendLine("       <span class='lang lang-en f10 font-en regular white'>Finance ( ICL )</span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <a class='item btnreportscholarship button-bar hide'>");
        _str.AppendLine("       <span class='f9 font-th regular white'><i class='area dashboard icon'></i></span>");
        _str.AppendLine("       <span class='lang lang-th f10 font-th regular white'>รายงาน</span>");
        _str.AppendLine("       <span class='lang lang-en f10 font-en regular white'>Report</span>");
        _str.AppendLine("   </a>");
        _str.AppendLine("   <div class='right item'>");
        _str.AppendLine("       <div class='ui icon floating dropdown basic on-left-more combobox' data-element='dropdown' data-type='module'>");
        _str.AppendLine("           <div class='f9 font-th regular'><i class='setting icon fg-amber'></i></div>");        
        _str.AppendLine("           <div class='menu transition hidden'>");
        _str.AppendLine("               <div class='item'>");
        _str.AppendLine("                   <span class='f9 font-th regular black'><i class='help icon'></i></span>");
        _str.AppendLine("                   <span class='lang lang-th f10 font-th regular black'>คู่มือ</span>");
        _str.AppendLine("                   <span class='lang lang-en f10 font-en regular black'>Manual</span>");
        _str.AppendLine("               </div>");
        _str.AppendLine("           </div>");
        _str.AppendLine("       </div>");
        _str.AppendLine("       <div class='lang-active'>");
        _str.AppendLine("           <a href='javascript:void(0)' alt='TH'><span class='f9 font-th regular'><i class='th flag thai'></i></span></a>");
        _str.AppendLine("           <a href='javascript:void(0)' alt='EN'><span class='f9 font-th regular'><i class='us flag'></i></span></a>");
        _str.AppendLine("       </div>");
        _str.AppendLine("   </div>");
        _str.AppendLine("</div>");

        return _str;
    }

    public static StringBuilder GetFollowingMenu()
    {
        StringBuilder _str = new StringBuilder();

        _str.AppendLine("<div class='ui container'>");
        _str.AppendLine("   <div class='ui large secondary inverted pointing menu'>");
        _str.AppendLine("       <a class='toc item on-left'>");
        _str.AppendLine("           <span class='f9 font-th regular white'><i class='sidebar icon'></i></span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <div class='mulogo on-left'><img src='../Content/Image/Logo_icon.png' /></div>");
        _str.AppendLine("       <a class='item systemname'>");
        _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>ระบบทุนการศึกษา</span>");
        _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Mahidol Scholarship</span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <a class='item btnscholarship button-bar hide'>");
        _str.AppendLine("           <span class='f9 font-th regular white'><i class='student icon'></i>&nbsp;</span>");
        _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>ทุน</span>");
        _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Scholarship</span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <a class='item btnregisterscholarship button-bar hide'>");
        _str.AppendLine("           <span class='f9 font-th regular white'><i class='pointing up icon'></i>&nbsp;</span>");
        _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>สมัครรับทุน</span>");
        _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Register</span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <a class='item btnmanagescholarship button-bar hide'>");
        _str.AppendLine("           <span class='f9 font-th regular white'><i class='money icon'></i>&nbsp;</span>");
        _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>จัดการทุน</span>");
        _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Approve</span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <a class='item btnimportregisterscholarship button-bar hide'>");
        _str.AppendLine("           <span class='f9 font-th regular white'><i class='upload icon'></i>&nbsp;</span>");
        _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>นำเข้า</span>");
        _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Import</span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <a class='item btnfinancescholarshiptypegroupicl button-bar hide'>");
        _str.AppendLine("           <span class='f9 font-th regular white'><i class='pencil icon'></i>&nbsp;</span>");
        _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>การเงิน ( กรอ. )</span>");
        _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Finance ( ICL )</span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <a class='item btnreportscholarship button-bar hide'>");
        _str.AppendLine("           <span class='f9 font-th regular white'><i class='area dashboard icon'></i>&nbsp;</span>");
        _str.AppendLine("           <span class='lang lang-th f10 font-th regular white'>รายงาน</span>");
        _str.AppendLine("           <span class='lang lang-en f10 font-en regular white'>Report</span>");
        _str.AppendLine("       </a>");
        _str.AppendLine("       <div class='right item'>");
        _str.AppendLine("           <div class='ui icon floating dropdown basic on-left-more combobox' data-element='dropdown' data-type='module'>");
        _str.AppendLine("               <div class='f9 font-th regular'><i class='setting icon fg-amber'></i></div>");
        _str.AppendLine("               <div class='menu transition hidden'>");
        _str.AppendLine("                   <div class='item'>");
        _str.AppendLine("                       <span class='f9 font-th regular black'><i class='help icon'></i></span>");
        _str.AppendLine("                       <span class='lang lang-th f10 font-th regular black'>คู่มือ</span>");
        _str.AppendLine("                       <span class='lang lang-en f10 font-en regular black'>Manual</span>");
        _str.AppendLine("                   </div>");
        _str.AppendLine("               </div>");
        _str.AppendLine("           </div>");
        _str.AppendLine("           <div class='lang-active'>");
        _str.AppendLine("               <a href='javascript:void(0)' alt='TH'><span class='f9 font-th regular'><i class='th flag thai'></i></span></a>");
        _str.AppendLine("               <a href='javascript:void(0)' alt='EN'><span class='f9 font-th regular'><i class='us flag'></i></span></a>");
        _str.AppendLine("           </div>");
        _str.AppendLine("       </div>");
        _str.AppendLine("   </div>");
        _str.AppendLine("</div>");
        
        return _str;
    }

    public static StringBuilder GetSideBarMenu()
    {
        StringBuilder _str = new StringBuilder();

        _str.AppendLine("<a class='item btnscholarship button-bar hide'>");
        _str.AppendLine("   <i class='student icon font-th regular black'></i>");
        _str.AppendLine("   <span class='lang lang-th f10 font-th regular black'>ทุน</span>");
        _str.AppendLine("   <span class='lang lang-en f10 font-en regular black'>Scholarship</span>");
        _str.AppendLine("</a>");
        _str.AppendLine("<a class='item btnregisterscholarship button-bar hide'>");
        _str.AppendLine("   <i class='pointing up icon font-th regular black'></i>");
        _str.AppendLine("   <span class='lang lang-th f10 font-th regular black'>สมัครรับทุน</span>");
        _str.AppendLine("   <span class='lang lang-en f10 font-en regular black'>Register</span>");
        _str.AppendLine("</a>");
        _str.AppendLine("<a class='item btnmanagescholarship button-bar hide'>");
        _str.AppendLine("   <i class='money icon font-th regular black'></i>");
        _str.AppendLine("   <span class='lang lang-th f10 font-th regular black'>จัดการทุน</span>");
        _str.AppendLine("   <span class='lang lang-en f10 font-en regular black'>Approve</span>");
        _str.AppendLine("</a>");
        _str.AppendLine("<a class='item btnimportregisterscholarship button-bar hide'>");
        _str.AppendLine("   <i class='upload icon font-th regular black'></i>");
        _str.AppendLine("   <span class='lang lang-th f10 font-th regular black'>นำเข้า</span>");
        _str.AppendLine("   <span class='lang lang-en f10 font-en regular black'>Import</span>");
        _str.AppendLine("</a>");
        _str.AppendLine("<a class='item btnfinancescholarshiptypegroupicl button-bar hide'>");
        _str.AppendLine("   <i class='pencil icon font-th regular black'></i>");
        _str.AppendLine("   <span class='lang lang-th f10 font-th regular black'>การเงิน ( กรอ. )</span>");
        _str.AppendLine("   <span class='lang lang-en f10 font-en regular black'>Finance ( ICL )</span>");
        _str.AppendLine("</a>");
        _str.AppendLine("<a class='item btnreportscholarship button-bar hide'>");
        _str.AppendLine("   <i class='area dashboard icon font-th regular black'></i>");
        _str.AppendLine("   <span class='lang lang-th f10 font-th regular black'>รายงาน</span>");
        _str.AppendLine("   <span class='lang lang-en f10 font-en regular black'>Report</span>");
        _str.AppendLine("</a>");
        _str.AppendLine("<a class='item'>");
        _str.AppendLine("   <i class='help icon font-th regular black'></i>");
        _str.AppendLine("   <span class='lang lang-th f10 font-th regular black'>คู่มือ</span>");
        _str.AppendLine("   <span class='lang lang-en f10 font-en regular black'>Manual</span>");
        _str.AppendLine("</a>");

        return _str;
    }   

    public static StringBuilder GetFooter()
    {
        StringBuilder _str = new StringBuilder();

        _str.AppendLine("<div class='ui container'>");
        _str.AppendLine("   <div class='ui stackable grid'>");
        _str.AppendLine("       <div class='eight wide column'>");
        _str.AppendLine("           <div class='ui inverted header'>");
        _str.AppendLine("               <span class='lang lang-th f9 font-th regular white'>กองกิจการนักศึกษา</span>");
        _str.AppendLine("               <span class='lang lang-en f9 font-en regular white'>Academic Affairs</span>");
        _str.AppendLine("           </div>");
        _str.AppendLine("           <div class='lang lang-th f10 font-th regular muted'>สำนักงานอธิการบดี มหาวิทยาลัยมหิดล</div>");
        _str.AppendLine("           <div class='lang lang-en f10 font-en regular muted'>Office of President, Mahidol University</div>");
        _str.AppendLine("           <div class='lang-th f10 font-th regular muted'>0-2849-6115-24, 0-2849-6251-59</div>");
        _str.AppendLine("       </div>");
        _str.AppendLine("       <div class='eight wide column'>");
        _str.AppendLine("           <div class='ui inverted header'>");
        _str.AppendLine("               <span class='lang lang-th f9 font-th regular white'>กองเทคโนโลยีสารสนเทศ, หน่วยพัฒนาระบบนักศึกษา</span>");
        _str.AppendLine("               <span class='lang lang-en f9 font-en regular white'>Infomation Techonology, Student Unit</span>");
        _str.AppendLine("           </div>");
        _str.AppendLine("           <div class='lang-th f10 font-th regular muted'>0-2849-6413</div> ");
        _str.AppendLine("           <div class='lang-th f10 font-th regular muted'>nopparat.jap@mahidol.ac.th</div>");
        _str.AppendLine("       </div>");
        _str.AppendLine("       <div class='sixteen wide column'>");
        _str.AppendFormat("         <span class='lang lang-th f9 font-th regular muted'>&copy; สงวนลิขสิทธิ์ พ.ศ.2559 - {0} มหาวิทยาลัยมหิดล, พัฒนาโดย กองเทคโนโลยีสารสนเทศ</span>", SCHUtil._yearTH);
        _str.AppendFormat("         <span class='lang lang-en f9 font-en regular muted'>Copyright &copy; 2016-{0} Mahidol University. All rights reserved.</span>", SCHUtil._yearEN);
        _str.AppendLine("       </div>");
        _str.AppendLine("   </div>");
        _str.AppendLine("</div>");

        return _str;
    }

    public static StringBuilder GetUserProfile()
    {
        StringBuilder _str = new StringBuilder();
        Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin(SCHUtil.PAGE_MAIN, "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        string _userlevel = _loginResult["Userlevel"].ToString();
        string _userfaculty = _loginResult["Userfaculty"].ToString();
        string[] _fullNameTH = _loginResult["FullNameTH"].ToString().Split(' ');
        string _fullNameEN = _loginResult["FullNameEN"].ToString();
        string _facultyColor = "#FFC726";

        if (_cookieError.Equals(0) && _userError.Equals(0))
        {
            _str.AppendLine("<div class='ui stackable secondary menu'>");
            _str.AppendLine("   <div class='item'>");
            _str.AppendFormat("     <input type='hidden' id='main-userfaculty-hidden' value='{0}'/>", _userfaculty);
            _str.AppendFormat("     <input type='hidden' id='main-currentyear-hidden' value='{0}'/>", SCHUtil._yearTH);
            _str.AppendLine("       <span class='f9 font-th regular black'><i class='user icon'></i></span>");
            _str.AppendFormat("     <span class='lang lang-th f9 font-th regular black'>{0}</span>", (_fullNameTH[0] + " " + _fullNameTH[1]));
            _str.AppendFormat("     <span class='lang lang-en f9 font-en regular black'>{0}</span>", _fullNameEN);
            _str.AppendFormat("     <span class='lang-th f9 font-th regular' style='color:{1}'>&nbsp;( {2} )</span>", _userfaculty.Substring(0, 2), _facultyColor, _userfaculty.Substring(0, 2));
            _str.AppendLine("   </div>");
            _str.AppendLine("   <div class='right menu'>");
            _str.AppendLine("       <div class='ui search'>");
            _str.AppendLine("           <div class='ui icon input large hide' id='main-quicksearch'>");
            _str.AppendLine("               <input id='main-keyword' type='text' placeholder='' placeholderth='คำค้น' placeholderen='keyword' />");
            _str.AppendLine("               <i class='search link icon' id='main-btnquicksearch' ></i>");
            _str.AppendLine("           </div>");
            _str.AppendLine("       </div>");
            _str.AppendLine("   </div>");
            _str.AppendLine("</div>");
        }

        return _str;
    }

    public static StringBuilder GetFrmNotice(string _page)
    {
        StringBuilder _str = new StringBuilder();
        List<string> _lsTH = new List<string>();
        List<string> _lsEN = new List<string>();

        _str.AppendLine("<div class='view' >");
        _str.AppendLine("   <div class='iform' >");
        _str.AppendLine("       <div class='iform-row'>");
        _str.AppendLine("           <div class='iform-col input-col left aligned'>");

        _lsTH = SCHDB.GetListText("TH", "MeaningOfScholarshipPayType.txt");
        _lsEN = SCHDB.GetListText("EN", "MeaningOfScholarshipPayType.txt");

        if (_page.Equals(SCHUtil.PAGE_MEANINGOFSCHOLARSHIPPAYTYPE_MAIN))
        {
            _str.AppendLine("           <div>");
            _str.AppendLine("               <ul class='notstyle'>");
            _str.AppendLine("                   <li>");
            _str.AppendFormat("                     <span class='lang lang-th f10 font-th regular black'>{0}</span>", _lsTH[0]);
            _str.AppendFormat("                     <span class='lang lang-en f10 font-en regular black'>{0}</span>", _lsEN[0]);
            _str.AppendLine("                   </li>");
            _str.AppendLine("                   <li>");
            _str.AppendFormat("                     <span class='lang lang-th f10 font-th regular black'>{0}</span>", _lsTH[1]);
            _str.AppendFormat("                     <span class='lang lang-en f10 font-en regular black'>{0}</span>", _lsEN[1]);
            _str.AppendLine("                   </li>");
            _str.AppendLine("               </ul>");
            _str.AppendLine("          </div>");
        }

        _str.AppendLine("           </div>");
        _str.AppendLine("       </div>");
        _str.AppendLine("   </div>");
        _str.AppendLine("</div>");
         
        return _str;
    }
    
    public static StringBuilder GetSelect(string _idSelect, string _defaultTextTH, string _defaultTextEN, string[] _value, string[] _textTH, string[] _textEN)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;

        _str.AppendFormat("<div class='ui fluid search selection dropdown combobox' id='{0}'>", _idSelect);
        _str.AppendLine("       <input value='0' type='hidden'>");
        _str.AppendLine("       <i class='dropdown icon font-th regular black'></i>");
        _str.AppendLine("       <div class='default text'>");
        _str.AppendFormat("         <span class='lang lang-th font-th'>{0}</span>", _defaultTextTH);
        _str.AppendFormat("         <span class='lang lang-en font-en'>{0}</span>", _defaultTextEN);
        _str.AppendLine("       </div>");
        _str.AppendLine("       <div class='menu'>");
        _str.AppendLine("           <div class='item' data-value='0'>");
        _str.AppendFormat("             <span class='lang lang-th font-th'>{0}</span>", _defaultTextTH);
        _str.AppendFormat("             <span class='lang lang-en font-en'>{0}</span>", _defaultTextEN);
        _str.AppendLine("           </div>");

        for (_i = 0; _i < _value.GetLength(0); _i++)
        {
            _str.AppendFormat("     <div class='item' data-value='{0}'>", _value[_i]);
            _str.AppendFormat("         <span class='lang lang-th font-th'>{0}</span>", _textTH[_i]);
            _str.AppendFormat("         <span class='lang lang-en font-en'>{0}</span>", _textEN[_i]);
            _str.AppendLine("       </div>");
        }

        _str.AppendLine("       </div>");
        _str.AppendLine("</div>");

        return _str;
    }

    public static StringBuilder DDLScholarshipsType(string _idSelect)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;
        DataSet _ds = SCHDB.GetListScholarshipsType();

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = _dr["id"].ToString();
            _optionTextTH[_i]   = _dr["scholarshipsTypeNameTH"].ToString();
            _optionTextEN[_i]   = _dr["scholarshipsTypeNameEN"].ToString();

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLFaculty(string _idSelect)
    {
        Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _str = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        string _userfaculty = _loginResult["Userfaculty"].ToString();
        int _i = 0;

        _paramSearch.Add("FacultyId", _userfaculty);

        DataSet _ds     = SCHDB.GetListFaculty(_username, _systemGroup, _paramSearch);
        DataRow[] _dr   = _ds.Tables[0].Select("facultyId <> 'MU-01'");

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr1 in _dr)
        {            
            _optionValue[_i]    = _dr1["facultyId"].ToString();
            _optionTextTH[_i]   = (_dr1["facultyCode"].ToString() + " : " + _dr1["facultyNameTH"].ToString());
            _optionTextEN[_i]   = (_dr1["facultyCode"].ToString() + " : " + _dr1["facultyNameEN"].ToString());

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }    

    public static StringBuilder DDLProgram(string _idSelect, string _degreeLevelId, string _facultyId)
    {
        Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _str = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        string _userprogram = _loginResult["Userprogram"].ToString();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("DegreeLevelId",   _degreeLevelId);
        _paramSearch.Add("FacultyId",       _facultyId);
        _paramSearch.Add("ProgramId",       _userprogram);

        DataSet _ds = SCHDB.GetListProgram(_username, _systemGroup, _paramSearch);

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = _dr["programId"].ToString();
            _optionTextTH[_i]   = ((_dr["programCode"].ToString() + " " + _dr["majorCode"].ToString() + " " + _dr["groupNum"].ToString()) + " : " + _dr["programNameTH"].ToString());
            _optionTextEN[_i]   = ((_dr["programCode"].ToString() + " " + _dr["majorCode"].ToString() + " " + _dr["groupNum"].ToString()) + " : " + _dr["programNameEN"].ToString());

            _i++;
        }
        
        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLYearEntry(string _idSelect)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;
        int _j = 0;
        int _yearStart = 0;
        DataSet _ds = SCHDB.GetListYearEntry();

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count + 20];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count + 20];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count + 20];

        _yearStart = (int.Parse(_ds.Tables[0].Rows[0]["yearEntry"].ToString()) + 20);

        for (_i = 0; _i < 20; _i++)
        {
            _optionValue[_i]   = (_yearStart - _i).ToString();
            _optionTextTH[_i]  = (_yearStart - _i).ToString();
            _optionTextEN[_i]  = (_yearStart - _i).ToString();
        }            

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = _dr["yearEntry"].ToString();
            _optionTextTH[_i]   = _dr["yearEntry"].ToString();
            _optionTextEN[_i]   = _dr["yearEntry"].ToString();

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLScholarships(string _idSelect)
    {
        StringBuilder _str = new StringBuilder();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Status", "Y");

        DataSet _ds = SCHDB.GetListScholarships(_paramSearch);

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = (_dr["id"].ToString() + ":" + _dr["scholarshipsTypeGroup"].ToString());
            _optionTextTH[_i]   = _dr["scholarshipsNameTH"].ToString();
            _optionTextEN[_i]   = (!String.IsNullOrEmpty(_dr["scholarshipsNameEN"].ToString()) ? _dr["scholarshipsNameEN"].ToString() : _optionTextTH[_i]);

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLSemester(string _idSelect)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;

        string[] _optionValue   = new string[SCHUtil._semester.GetLength(0)];
        string[] _optionTextTH  = new string[SCHUtil._semester.GetLength(0)];
        string[] _optionTextEN  = new string[SCHUtil._semester.GetLength(0)];

        for (_i = 0; _i < SCHUtil._semester.GetLength(0); _i++)
        {            
            _optionValue[_i]    = SCHUtil._semester[_i, 0];
            _optionTextTH[_i]   = SCHUtil._semester[_i, 1];
            _optionTextEN[_i]   = SCHUtil._semester[_i, 2];
        }

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLScholarshipsYearSemester(string _idSelect, string _scholarshipsTypeGroup)
    {
        StringBuilder _str = new StringBuilder();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("ScholarshipsTypeGroup", _scholarshipsTypeGroup);

        DataSet _ds = SCHDB.GetListScholarshipsYearSemester(_paramSearch);

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = (_dr["acaYear"].ToString() + ":" + _dr["semester"].ToString());
            _optionTextTH[_i]   = (_dr["acaYear"].ToString() + " / " + _dr["semesterNameTH"].ToString());
            _optionTextEN[_i]   = (_dr["acaYear"].ToString() + " / " + _dr["semesterNameEN"].ToString());

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLPayChequeYearSemester(string _idSelect, string _scholarshipsTypeGroup)
    {
        StringBuilder _str = new StringBuilder();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("ScholarshipsTypeGroup", _scholarshipsTypeGroup);

        DataSet _ds = SCHDB.GetListPayChequeYearSemester(_paramSearch);

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = (_dr["acaYear"].ToString() + ":" + _dr["semester"].ToString());
            _optionTextTH[_i]   = (_dr["acaYear"].ToString() + " / " + _dr["semesterNameTH"].ToString());
            _optionTextEN[_i]   = (_dr["acaYear"].ToString() + " / " + _dr["semesterNameEN"].ToString());

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLApproveStatus(string _idSelect, string _defaultTextTH, string _defaultTextEN)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;

        string[] _optionValue   = new string[SCHUtil._approveStatus.GetLength(0)];
        string[] _optionTextTH  = new string[SCHUtil._approveStatus.GetLength(0)];
        string[] _optionTextEN  = new string[SCHUtil._approveStatus.GetLength(0)];

        for (_i = 0; _i < SCHUtil._approveStatus.GetLength(0); _i++)
        {            
            _optionValue[_i]    = SCHUtil._approveStatus[_i, 0];
            _optionTextTH[_i]   = SCHUtil._approveStatus[_i, 1];
            _optionTextEN[_i]   = SCHUtil._approveStatus[_i, 2];
        }

        return GetSelect(_idSelect, _defaultTextTH, _defaultTextEN, _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLLotNoApprovalReceiveFinance(string _idSelect, string _scholarshipsTypeGroup, string _scholarshipsYear, string _semester)
    {
        StringBuilder _str = new StringBuilder();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("ScholarshipsTypeGroup",   _scholarshipsTypeGroup);
        _paramSearch.Add("ScholarshipsYear",        _scholarshipsYear);
        _paramSearch.Add("Semester",                _semester);

        DataSet _ds = SCHDB.GetListApprovalReceiveFinance(_paramSearch);

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = _dr["lotNo"].ToString();
            _optionTextTH[_i]   = _dr["lotNo"].ToString();
            _optionTextEN[_i]   = _dr["lotNo"].ToString();

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLGroupReceiver(string _idSelect, string _classify)
    {    
        StringBuilder _str = new StringBuilder();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Classify", _classify);
        
        DataSet _ds = SCHDB.GetListGroupReceiver(_paramSearch);

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {            
            _optionValue[_i]    = _dr["id"].ToString();
            _optionTextTH[_i]   = _dr["groupReceiverNameTH"].ToString();
            _optionTextEN[_i]   = _dr["groupReceiverNameEN"].ToString();

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLRecipientStatus(string _idSelect)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;

        string[] _optionValue   = new string[SCHUtil._recipientStatus.GetLength(0)];
        string[] _optionTextTH  = new string[SCHUtil._recipientStatus.GetLength(0)];
        string[] _optionTextEN  = new string[SCHUtil._recipientStatus.GetLength(0)];

        for (_i = 0; _i < SCHUtil._recipientStatus.GetLength(0); _i++)
        {            
            _optionValue[_i]    = SCHUtil._recipientStatus[_i, 0];
            _optionTextTH[_i]   = SCHUtil._recipientStatus[_i, 1];
            _optionTextEN[_i]   = SCHUtil._recipientStatus[_i, 2];
        }

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLBank(string _idSelect)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;

        DataSet _ds = SCHDB.GetListBank();

        string[] _optionValue   = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextTH  = new string[_ds.Tables[0].Rows.Count];
        string[] _optionTextEN  = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["id"].ToString();
            _optionTextTH[_i]   = _dr["code"].ToString();
            _optionTextEN[_i]   = _dr["code"].ToString();

            _i++;
        }

        _ds.Dispose();

        return GetSelect(_idSelect, "เลือก", "Select", _optionValue, _optionTextTH, _optionTextEN);
    }

    public static StringBuilder DDLPayChequeStatus(string _idSelect, string _defaultTextTH, string _defaultTextEN)
    {
        StringBuilder _str = new StringBuilder();
        int _i = 0;

        string[] _optionValue   = new string[SCHUtil._payChequeStatus.GetLength(0)];
        string[] _optionTextTH  = new string[SCHUtil._payChequeStatus.GetLength(0)];
        string[] _optionTextEN  = new string[SCHUtil._payChequeStatus.GetLength(0)];

        for (_i = 0; _i < SCHUtil._payChequeStatus.GetLength(0); _i++)
        {            
            _optionValue[_i]    = SCHUtil._payChequeStatus[_i, 0];
            _optionTextTH[_i]   = SCHUtil._payChequeStatus[_i, 1];
            _optionTextEN[_i]   = SCHUtil._payChequeStatus[_i, 2];
        }

        return GetSelect(_idSelect, _defaultTextTH, _defaultTextEN, _optionValue, _optionTextTH, _optionTextEN);
    }
}