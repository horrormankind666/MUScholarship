using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public class SCHDB
{
    public static string _myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

    public static SqlConnection ConnectDB(string _connString)
    {
        SqlConnection _conn = new SqlConnection(_connString);

        return _conn;
    }

    public static DataSet ExecuteCommandStoredProcedure(string _procName, params SqlParameter[] _values)
    {
        SqlConnection _conn = ConnectDB(_myConnectionString);
        SqlCommand _cmd = new SqlCommand(_procName, _conn);
        DataSet _ds = new DataSet();

        _cmd.CommandType = CommandType.StoredProcedure;
        _cmd.CommandTimeout = 1000;

        if (_values != null && _values.Length > 0)
            _cmd.Parameters.AddRange(_values);

        try
        {
            _conn.Open();

            SqlDataAdapter _da = new SqlDataAdapter(_cmd);

            _ds = new DataSet();
            _da.Fill(_ds);
        }
        finally
        {
            _cmd.Dispose();

            _conn.Close();
            _conn.Dispose();
        }

        return _ds;
    }

    public static DataSet GetUserStaff(string _username, string _userlevel, string _systemGroup)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_autUserAccessProgram",
            new SqlParameter("@username", _username),
            new SqlParameter("@userlevel", _userlevel),
            new SqlParameter("@systemGroup", _systemGroup));

        return _ds;
    }

    public static DataSet GetListFaculty(string _username, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_autGetListFacultyAccess",
            new SqlParameter("@username",       _username),
            new SqlParameter("@systemGroup",    _systemGroup),
            new SqlParameter("@faculty",        (_paramSearch.ContainsKey("FacultyId").Equals(true) ? _paramSearch["FacultyId"] : String.Empty)),
            new SqlParameter("@distinction",    (_paramSearch.ContainsKey("Distinction").Equals(true) ? _paramSearch["Distinction"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListProgram(string _username, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_autGetListProgramAccess",
            new SqlParameter("@username",       _username),
            new SqlParameter("@systemGroup",    _systemGroup),
            new SqlParameter("@degreeLevel",    (_paramSearch.ContainsKey("DegreeLevelId").Equals(true) ? _paramSearch["DegreeLevelId"] : String.Empty)),
            new SqlParameter("@faculty",        (_paramSearch.ContainsKey("FacultyId").Equals(true) ? _paramSearch["FacultyId"] : String.Empty)),
            new SqlParameter("@program",        (_paramSearch.ContainsKey("ProgramId").Equals(true) ? _paramSearch["ProgramId"] : String.Empty)),
            new SqlParameter("@distinction",    (_paramSearch.ContainsKey("Distinction").Equals(true) ? _paramSearch["Distinction"] : String.Empty)));
                
        return _ds;
    }

    public static DataSet GetListYearEntry()
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_perGetListYearEntryPersonStudent", null);

        return _ds;
    }

    public static DataSet GetListScholarships(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListScholarships",
            new SqlParameter("@keyword",            (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@scholarshipsTypeId", (_paramSearch.ContainsKey("ScholarshipsTypeId").Equals(true) ? _paramSearch["ScholarshipsTypeId"] : String.Empty)),
            new SqlParameter("@status",             (_paramSearch.ContainsKey("Status").Equals(true) ? _paramSearch["Status"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetScholarships(string _id, string _name)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetScholarships",
            new SqlParameter("@id",     _id),
            new SqlParameter("@name",   _name));

        return _ds;
    }

    public static DataSet GetListScholarshipsType()
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListScholarshipsType", null);

        return _ds;
    }

    public static DataSet GetListStudent(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListStudentWithAuthenStaff",
            new SqlParameter("@username",       _username),
            new SqlParameter("@userlevel",      _userlevel),
            new SqlParameter("@systemGroup",    _systemGroup),
            new SqlParameter("@keyword",        (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@facultyId",      (_paramSearch.ContainsKey("FacultyId").Equals(true) ? _paramSearch["FacultyId"] : String.Empty)),
            new SqlParameter("@programId",      (_paramSearch.ContainsKey("ProgramId").Equals(true) ? _paramSearch["ProgramId"] : String.Empty)),
            new SqlParameter("@yearEntry",      (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetSCHStudent(string _username, string _userlevel, string _systemGroup, string _studentCode)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetStudentWithAuthenStaff",
            new SqlParameter("@username",       _username),
            new SqlParameter("@userlevel",      _userlevel),
            new SqlParameter("@systemGroup",    _systemGroup),
            new SqlParameter("@studentCode",    _studentCode));

        return _ds;
    }

    public static DataSet GetStudent(string _username, string _userlevel, string _systemGroup, string _personId)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_perGetPersonStudentWithAuthenStaff",
            new SqlParameter("@username",       _username),
            new SqlParameter("@userlevel",      _userlevel),
            new SqlParameter("@systemGroup",    _systemGroup),
            new SqlParameter("@personId",       _personId));

        return _ds;
    }

    public static DataSet GetStudent(string _personId)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_perGetPersonStudent",
            new SqlParameter("@personId", _personId));

        return _ds;
    }

    public static DataSet GetStudentGPA(string _studentcode)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_grdGetListGPAStatusOnline",
            new SqlParameter("@studentId", _studentcode));

        return _ds;
    }

    public static DataSet GetTranStudent(string _personId, string _acaYear, string _semester, string _scholarshipsId)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetTranStudent",
            new SqlParameter("@personId",       _personId),
            new SqlParameter("@acaYear",        _acaYear),
            new SqlParameter("@semester",       _semester),
            new SqlParameter("@scholarshipsId", _scholarshipsId));

        return _ds;
    }

    public static DataSet GetListScholarshipsYearSemester(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListScholarshipsYearSemester",
            new SqlParameter("@scholarshipsTypeGroup", (_paramSearch.ContainsKey("ScholarshipsTypeGroup").Equals(true) ? _paramSearch["ScholarshipsTypeGroup"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListPayChequeYearSemester(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListPayChequeYearSemester",
            new SqlParameter("@scholarshipsTypeGroup", (_paramSearch.ContainsKey("ScholarshipsTypeGroup").Equals(true) ? _paramSearch["ScholarshipsTypeGroup"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListTranStudent(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListTranStudentWithAuthenStaff",
            new SqlParameter("@username",               _username),
            new SqlParameter("@userlevel",              _userlevel),
            new SqlParameter("@systemGroup",            _systemGroup),
            new SqlParameter("@keyword",                (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@subKeyword",             (_paramSearch.ContainsKey("SubKeyword").Equals(true) ? _paramSearch["SubKeyword"] : String.Empty)),
            new SqlParameter("@facultyId",              (_paramSearch.ContainsKey("FacultyId").Equals(true) ? _paramSearch["FacultyId"] : String.Empty)),
            new SqlParameter("@programId",              (_paramSearch.ContainsKey("ProgramId").Equals(true) ? _paramSearch["ProgramId"] : String.Empty)),
            new SqlParameter("@yearEntry",              (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),
            new SqlParameter("@scholarshipsTypeGroup",  (_paramSearch.ContainsKey("ScholarshipsTypeGroup").Equals(true) ? _paramSearch["ScholarshipsTypeGroup"] : String.Empty)),
            new SqlParameter("@scholarshipsYear",       (_paramSearch.ContainsKey("ScholarshipsYear").Equals(true) ? _paramSearch["ScholarshipsYear"] : String.Empty)),
            new SqlParameter("@payChequeYear",          (_paramSearch.ContainsKey("PayChequeYear").Equals(true) ? _paramSearch["PayChequeYear"] : String.Empty)),
            new SqlParameter("@semester",               (_paramSearch.ContainsKey("Semester").Equals(true) ? _paramSearch["Semester"] : String.Empty)),
            new SqlParameter("@lotNo",                  (_paramSearch.ContainsKey("LotNo").Equals(true) ? _paramSearch["LotNo"] : String.Empty)),
            new SqlParameter("@pvjvNo",                 (_paramSearch.ContainsKey("PVJVNo").Equals(true) ? _paramSearch["PVJVNo"] : String.Empty)),
            new SqlParameter("@chequeNo",               (_paramSearch.ContainsKey("ChequeNo").Equals(true) ? _paramSearch["ChequeNo"] : String.Empty)),
            new SqlParameter("@groupReceiver",          (_paramSearch.ContainsKey("GroupReceiver").Equals(true) ? _paramSearch["GroupReceiver"] : String.Empty)),
            new SqlParameter("@bankId",                 (_paramSearch.ContainsKey("BankId").Equals(true) ? _paramSearch["BankId"] : String.Empty)),
            new SqlParameter("@scholarshipsId",         (_paramSearch.ContainsKey("ScholarshipsId").Equals(true) ? _paramSearch["ScholarshipsId"] : String.Empty)),
            new SqlParameter("@approveStatus",          (_paramSearch.ContainsKey("ApproveStatus").Equals(true) ? _paramSearch["ApproveStatus"] : String.Empty)),
            new SqlParameter("@recipientStatus",        (_paramSearch.ContainsKey("RecipientStatus").Equals(true) ? _paramSearch["RecipientStatus"] : String.Empty)),
            new SqlParameter("@payChequeStatus",        (_paramSearch.ContainsKey("PayChequeStatus").Equals(true) ? _paramSearch["PayChequeStatus"] : String.Empty)),
            new SqlParameter("@cancelStatus",           (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListTranStudentManageScholarship(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListTranStudentManageScholarshipWithAuthenStaff",
            new SqlParameter("@username",               _username),
            new SqlParameter("@userlevel",              _userlevel),
            new SqlParameter("@systemGroup",            _systemGroup),
            new SqlParameter("@keyword",                (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@facultyId",              (_paramSearch.ContainsKey("FacultyId").Equals(true) ? _paramSearch["FacultyId"] : String.Empty)),
            new SqlParameter("@programId",              (_paramSearch.ContainsKey("ProgramId").Equals(true) ? _paramSearch["ProgramId"] : String.Empty)),
            new SqlParameter("@yearEntry",              (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),
            new SqlParameter("@scholarshipsYear",       (_paramSearch.ContainsKey("ScholarshipsYear").Equals(true) ? _paramSearch["ScholarshipsYear"] : String.Empty)),
            new SqlParameter("@semester",               (_paramSearch.ContainsKey("Semester").Equals(true) ? _paramSearch["Semester"] : String.Empty)),
            new SqlParameter("@scholarshipsId",         (_paramSearch.ContainsKey("ScholarshipsId").Equals(true) ? _paramSearch["ScholarshipsId"] : String.Empty)),
            new SqlParameter("@cancelStatus",           (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListTranStudentFinanceScholarshipSavePeopleApproved(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListTranStudentFinanceScholarshipSavePeopleApprovedWithAuthenStaff",
            new SqlParameter("@username",               _username),
            new SqlParameter("@userlevel",              _userlevel),
            new SqlParameter("@systemGroup",            _systemGroup),
            new SqlParameter("@keyword",                (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@scholarshipsTypeGroup",  (_paramSearch.ContainsKey("ScholarshipsTypeGroup").Equals(true) ? _paramSearch["ScholarshipsTypeGroup"] : String.Empty)),
            new SqlParameter("@scholarshipsYear",       (_paramSearch.ContainsKey("ScholarshipsYear").Equals(true) ? _paramSearch["ScholarshipsYear"] : String.Empty)),
            new SqlParameter("@semester",               (_paramSearch.ContainsKey("Semester").Equals(true) ? _paramSearch["Semester"] : String.Empty)),
            new SqlParameter("@lotNo",                  (_paramSearch.ContainsKey("LotNo").Equals(true) ? _paramSearch["LotNo"] : String.Empty)),
            new SqlParameter("@approveStatus",          (_paramSearch.ContainsKey("ApproveStatus").Equals(true) ? _paramSearch["ApproveStatus"] : String.Empty)),
            new SqlParameter("@cancelStatus",           (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListTranStudentFinanceScholarshipClassificationRecipient(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListTranStudentFinanceScholarshipClassificationRecipientWithAuthenStaff",
            new SqlParameter("@username",               _username),
            new SqlParameter("@userlevel",              _userlevel),
            new SqlParameter("@systemGroup",            _systemGroup),
            new SqlParameter("@keyword",                (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@facultyId",              (_paramSearch.ContainsKey("FacultyId").Equals(true) ? _paramSearch["FacultyId"] : String.Empty)),
            new SqlParameter("@programId",              (_paramSearch.ContainsKey("ProgramId").Equals(true) ? _paramSearch["ProgramId"] : String.Empty)),
            new SqlParameter("@yearEntry",              (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),
            new SqlParameter("@scholarshipsTypeGroup",  (_paramSearch.ContainsKey("ScholarshipsTypeGroup").Equals(true) ? _paramSearch["ScholarshipsTypeGroup"] : String.Empty)),
            new SqlParameter("@scholarshipsYear",       (_paramSearch.ContainsKey("ScholarshipsYear").Equals(true) ? _paramSearch["ScholarshipsYear"] : String.Empty)),
            new SqlParameter("@semester",               (_paramSearch.ContainsKey("Semester").Equals(true) ? _paramSearch["Semester"] : String.Empty)),
            new SqlParameter("@lotNo",                  (_paramSearch.ContainsKey("LotNo").Equals(true) ? _paramSearch["LotNo"] : String.Empty)),
            new SqlParameter("@groupReceiver",          (_paramSearch.ContainsKey("GroupReceiver").Equals(true) ? _paramSearch["GroupReceiver"] : String.Empty)),
            new SqlParameter("@recipientStatus",        (_paramSearch.ContainsKey("RecipientStatus").Equals(true) ? _paramSearch["RecipientStatus"] : String.Empty)),
            new SqlParameter("@cancelStatus",           (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListTranStudentFinanceScholarshipSavePeoplePayCheque(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListTranStudentFinanceScholarshipSavePeoplePayChequeWithAuthenStaff",
            new SqlParameter("@username",               _username),
            new SqlParameter("@userlevel",              _userlevel),
            new SqlParameter("@systemGroup",            _systemGroup),
            new SqlParameter("@keyword",                (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@payChequeYear",          (_paramSearch.ContainsKey("PayChequeYear").Equals(true) ? _paramSearch["PayChequeYear"] : String.Empty)),
            new SqlParameter("@semester",               (_paramSearch.ContainsKey("Semester").Equals(true) ? _paramSearch["Semester"] : String.Empty)),
            new SqlParameter("@lotNo",                  (_paramSearch.ContainsKey("LotNo").Equals(true) ? _paramSearch["LotNo"] : String.Empty)),
            new SqlParameter("@pvjvNo",                 (_paramSearch.ContainsKey("PVJVNo").Equals(true) ? _paramSearch["PVJVNo"] : String.Empty)),
            new SqlParameter("@chequeNo",               (_paramSearch.ContainsKey("ChequeNo").Equals(true) ? _paramSearch["ChequeNo"] : String.Empty)),
            new SqlParameter("@groupReceiver",          (_paramSearch.ContainsKey("GroupReceiver").Equals(true) ? _paramSearch["GroupReceiver"] : String.Empty)),
            new SqlParameter("@bankId",                 (_paramSearch.ContainsKey("BankId").Equals(true) ? _paramSearch["BankId"] : String.Empty)),
            new SqlParameter("@payChequeStatus",        (_paramSearch.ContainsKey("PayChequeStatus").Equals(true) ? _paramSearch["PayChequeStatus"] : String.Empty)),
            new SqlParameter("@cancelStatus",           (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListApprovalReceiveFinance(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListApprovalReceiveFinance",
            new SqlParameter("@scholarshipsTypeGroup",  (_paramSearch.ContainsKey("ScholarshipsTypeGroup").Equals(true) ? _paramSearch["ScholarshipsTypeGroup"] : String.Empty)),
            new SqlParameter("@scholarshipsYear",       (_paramSearch.ContainsKey("ScholarshipsYear").Equals(true) ? _paramSearch["ScholarshipsYear"] : String.Empty)),
            new SqlParameter("@semester",               (_paramSearch.ContainsKey("Semester").Equals(true) ? _paramSearch["Semester"] : String.Empty)),
            new SqlParameter("@cancelStatus",           (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetApprovalReceiveFinance(string _scholarshipsTypeGroup, string _scholarshipsYear, string _semester, string _lotNo)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetApprovalReceiveFinance",
            new SqlParameter("@scholarshipsTypeGroup",  _scholarshipsTypeGroup),
            new SqlParameter("@scholarshipsYear",       _scholarshipsYear),
            new SqlParameter("@semester",               _semester),
            new SqlParameter("@lotNo",                  _lotNo));

        return _ds;
    }

    public static DataSet GetListGroupReceiver(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListGroupReceiver",
            new SqlParameter("@classify",       (_paramSearch.ContainsKey("Classify").Equals(true) ? _paramSearch["Classify"] : String.Empty)),
            new SqlParameter("@cancelStatus",   (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetListCheque(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetListCheque",
            new SqlParameter("@payChequeYear",  (_paramSearch.ContainsKey("PayChequeYear").Equals(true) ? _paramSearch["PayChequeYear"] : String.Empty)),
            new SqlParameter("@semester",       (_paramSearch.ContainsKey("Semester").Equals(true) ? _paramSearch["Semester"] : String.Empty)),
            new SqlParameter("@cancelStatus",   (_paramSearch.ContainsKey("CancelStatus").Equals(true) ? _paramSearch["CancelStatus"] : String.Empty)));

        return _ds;
    }

    public static DataSet GetCheque(string _payChequeYear, string _semester, string _lotNo, string _pvjvNo, string _chequeNo)
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_schGetCheque",
            new SqlParameter("@payChequeYear",  _payChequeYear),
            new SqlParameter("@semester",       _semester),
            new SqlParameter("@lotNo",          _lotNo),
            new SqlParameter("@pvjvNo",         _pvjvNo),
            new SqlParameter("@chequeNo",       _chequeNo));

        return _ds;
    }

    public static DataSet GetListBank()
    {
        DataSet _ds = ExecuteCommandStoredProcedure("sp_plcGetListBank", null);

        return _ds;
    }

    public static List<string> GetListText(string _lang, string _fileName)
    {
        List<string> _ls = File.ReadAllLines(HttpContext.Current.Server.MapPath("~") + ("/Content/Notice/" + _lang + "/" + _fileName)).ToList();

        return _ls;
    }    

    public static Dictionary<string, object> ActionSave(HttpContext _c, Dictionary<string, object> _infoLogin)
    {
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();
        Dictionary<string, object> _paramResult = new Dictionary<string, object>();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        DataSet _ds = new DataSet();
        DataRow _dr;
        string _username = _infoLogin["Username"].ToString();
        string _userlevel = _infoLogin["Userlevel"].ToString();
        string _systemGroup = _infoLogin["SystemGroup"].ToString();
        string _page = _c.Request["page"];
        string _action = String.Empty;
        string _id = String.Empty;
        string _option = String.Empty;
        string _selected = String.Empty;
        string _paramSearch = String.Empty;
        string _keyword = String.Empty;
        string _subKeyword = String.Empty;
        string _facultyId = String.Empty;
        string _programId = String.Empty;
        string _yearEntry = String.Empty;
        string _scholarshipsTypeGroup = String.Empty;
        string _scholarshipsYear = String.Empty;
        string _semester = String.Empty;
        string _scholarshipsId = String.Empty;
        string _lotNo = String.Empty;
        string _groupReceiver = String.Empty;
        string _approveStatus = String.Empty;
        string _recipientStatus = String.Empty;
        string _contractDate = String.Empty;
        string _approveDate = String.Empty;
        string _transferDate = String.Empty;
        string _chequeDate = String.Empty;
        string[] _valueArray1;
        string[] _valueArray2;
        string[] _valueSearch;
        bool _actionSave = true;
        int _saveError = 0;
        int _complete = 0;
        int _incomplete = 0;
        int _i;

        try
        {
            if (_page.Equals(SCHUtil.PAGE_SCHOLARSHIP_ADD) ||
                _page.Equals(SCHUtil.PAGE_SCHOLARSHIP_UPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    if (_page.Equals(SCHUtil.PAGE_SCHOLARSHIP_ADD))      _action = "INSERT";
                    if (_page.Equals(SCHUtil.PAGE_SCHOLARSHIP_UPDATE))   _action = "UPDATE";

                    _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetScholarships",
                                    new SqlParameter("@action",             _action),
                                    new SqlParameter("@id",                 _c.Request["id"]),
                                    new SqlParameter("@scholarshipsNameTH", _c.Request["scholarshipsNameTH"]),
                                    new SqlParameter("@scholarshipsNameEN", _c.Request["scholarshipsNameEN"]),
                                    new SqlParameter("@scholarshipsTypeId", _c.Request["scholarshipsTypeId"]),
                                    new SqlParameter("@owner",              _c.Request["owner"]),
                                    new SqlParameter("@approvalStatus",     _c.Request["approvalStatus"]),
                                    new SqlParameter("@by",                 _username),
                                    new SqlParameter("@ip",                 SCHUtil.GetIP()));
                    _dr         = _ds.Tables[0].Rows[0];
                    _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                    _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                    _id         = _dr[1].ToString();
                    _ds.Dispose();
                }
            }

            if (_page.Equals(SCHUtil.PAGE_REGISTERSCHOLARSHIP_ADDUPDATE))
            {
                _option         = _c.Request["option"];
                _selected       = _c.Request["selected"];
                _paramSearch    = _c.Request["paramSearch"];
                
                if (_option.Equals("selected") || _option.Equals("all"))
                {
                    if (_option.Equals("selected") && !String.IsNullOrEmpty(_selected))
                        _keyword = _selected;

                    if (_option.Equals("all") && !String.IsNullOrEmpty(_paramSearch))
                    {
                        _valueArray1 = _paramSearch.Split(',');
                        _valueSearch = new string[_valueArray1.GetLength(0)];

                        for (_i = 0; _i < _valueArray1.GetLength(0); _i++)
                        {
                            _valueArray2        = _valueArray1[_i].Split(':');
                            _valueSearch[_i]    = _valueArray2[1];
                        }

                        _keyword    = _valueSearch[0];
                        _facultyId  = _valueSearch[1];
                        _programId  = _valueSearch[2];
                        _yearEntry  = _valueSearch[3];
                    }

                    _paramResult.Add("Keyword",     _keyword);
                    _paramResult.Add("FacultyId",   _facultyId);
                    _paramResult.Add("ProgramId",   _programId);
                    _paramResult.Add("YearEntry",   _yearEntry);

                    DataTable _dt1  = new DataTable();
                    DataSet _ds1    = new DataSet();

                    if (_option.Equals("selected"))
                    {
                        string[] _valueSelected = _paramResult["Keyword"].ToString().Split('|');
                        _dt1.Columns.Add("id");

                        for (_i = 0; _i < _valueSelected.GetLength(0); _i++)
                        {
                            _dt1.Rows.Add(_valueSelected[_i]);
                        }

                        _ds1.Tables.Add(_dt1);
                    }

                    if (_option.Equals("all"))
                    {
                        _ds1 = GetListStudent(_username, _userlevel, _systemGroup, _paramResult);
                    }

                    foreach (DataRow _dr1 in _ds1.Tables[0].Rows)
                    {                
                        try
                        {
                            _saveError = 0;

                            DataSet _ds2 = GetTranStudent(_dr1["id"].ToString(), _c.Request["scholarshipsYear"], _c.Request["semester"], _c.Request["scholarshipsId"]);

                            if (_ds2.Tables[0].Rows.Count > 0)
                            {
                                _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                                new SqlParameter("@action",             "UPDATE"),
                                                new SqlParameter("@personId",           _dr1["id"].ToString()),
                                                new SqlParameter("@acaYear",            _c.Request["scholarshipsYear"]),
                                                new SqlParameter("@semester",           _c.Request["semester"]),
                                                new SqlParameter("@scholarshipsId",     _c.Request["scholarshipsId"]),
                                                new SqlParameter("@lotNo",              ""),
                                                new SqlParameter("@responsibleAgency",  _c.Request["responsibleAgency"]),
                                                new SqlParameter("@regisCase",          "S"),
                                                new SqlParameter("@schGroupReceiverId", ""),
                                                new SqlParameter("@registerDate",       _c.Request["registerDate"]),
                                                new SqlParameter("@contractDate",       ""),
                                                new SqlParameter("@approveDate",        ""),
                                                new SqlParameter("@transferDate",       ""),
                                                new SqlParameter("@chequeId",           ""),
                                                new SqlParameter("@chequeDate",         ""),
                                                new SqlParameter("@cancelStatus",       ""),
                                                new SqlParameter("@remark",             ""),
                                                new SqlParameter("@by",                 _username),
                                                new SqlParameter("@ip",                 SCHUtil.GetIP()));
                                _dr         = _ds.Tables[0].Rows[0];
                                _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                                _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                                _ds.Dispose();
                            }
                            else
                                {
                                    _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                                    new SqlParameter("@action",             "INSERT"),
                                                    new SqlParameter("@personId",           _dr1["id"].ToString()),
                                                    new SqlParameter("@acaYear",            _c.Request["scholarshipsYear"]),
                                                    new SqlParameter("@semester",           _c.Request["semester"]),
                                                    new SqlParameter("@scholarshipsId",     _c.Request["scholarshipsId"]),
                                                    new SqlParameter("@responsibleAgency",  _c.Request["responsibleAgency"]),
                                                    new SqlParameter("@regisCase",          "S"),
                                                    new SqlParameter("@registerDate",       _c.Request["registerDate"]),                                                                                                        
                                                    new SqlParameter("@by",                 _username),
                                                    new SqlParameter("@ip",                 SCHUtil.GetIP()));
                                    _dr         = _ds.Tables[0].Rows[0];
                                    _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                                    _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                                    _ds.Dispose();
                                }

                            _ds2.Dispose();
                        }
                        catch (Exception _ex)
                        {
                            _incomplete++;
                        }
                    }

                    _ds1.Dispose();
                }             
            }

            if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIP_ADDUPDATE) ||
                _page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_ADDUPDATE))
            {
                _option         = _c.Request["option"];
                _selected       = _c.Request["selected"];
                _paramSearch    = _c.Request["paramSearch"];
                _contractDate   = _c.Request["contractDate"];
                _approveDate    = SCHUtil.CurrentDate("dd/MM/yyyy");

                if (_option.Equals("selected") || _option.Equals("all"))
                {
                    if (_option.Equals("selected") && !String.IsNullOrEmpty(_selected))
                        _keyword = _selected;

                    _paramResult.Add("Keyword", _keyword);

                    DataTable _dt1  = new DataTable();
                    DataSet _ds1    = new DataSet();

                    if (_option.Equals("selected"))
                    {
                        string[] _valueSelected = _paramResult["Keyword"].ToString().Split('|');
                        _dt1.Columns.Add("id");
                        _dt1.Columns.Add("scholarshipsYear");
                        _dt1.Columns.Add("semester");
                        _dt1.Columns.Add("scholarshipsId");
                        _dt1.Columns.Add("scholarshipsTypeGroup");
                        _dt1.Columns.Add("amount");
                        _dt1.Columns.Add("regisCase");

                        for (_i = 0; _i < _valueSelected.GetLength(0); _i++)
                        {
                            _valueArray1 = _valueSelected[_i].Split(':');

                            DataRow _dr1 = _dt1.NewRow();

                            _dr1["id"]                      = _valueArray1[0];
                            _dr1["scholarshipsYear"]        = _valueArray1[1];
                            _dr1["semester"]                = _valueArray1[2];
                            _dr1["scholarshipsId"]          = _valueArray1[3];
                            _dr1["scholarshipsTypeGroup"]   = _valueArray1[4];
                            _dr1["amount"]                  = _valueArray1[5];
                            _dr1["regisCase"]               = _valueArray1[6];

                            _dt1.Rows.Add(_dr1);    
                        }

                        _ds1.Tables.Add(_dt1);
                    }

                    foreach (DataRow _dr2 in _ds1.Tables[0].Rows)
                    {                
                        try
                        {
                            _saveError = 0;

                            DataSet _ds2 = GetTranStudent(_dr2["id"].ToString(), _dr2["scholarshipsYear"].ToString(), _dr2["semester"].ToString(), _dr2["scholarshipsId"].ToString());

                            if (_ds2.Tables[0].Rows.Count > 0)
                            {                                
                                if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIP_ADDUPDATE))
                                {
                                    if (_dr2["scholarshipsTypeGroup"].ToString().Equals(""))                    _contractDate = "";
                                    if (_dr2["scholarshipsTypeGroup"].ToString().Equals(SCHUtil.SUBJECT_ICL))   _approveDate = "";
                                    
                                    _ds     = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                                new SqlParameter("@action",         "UPDATE"),
                                                new SqlParameter("@personId",       _dr2["id"].ToString()),
                                                new SqlParameter("@acaYear",        _dr2["scholarshipsYear"].ToString()),
                                                new SqlParameter("@semester",       _dr2["semester"].ToString()),                                                
                                                new SqlParameter("@scholarshipsId", _dr2["scholarshipsId"].ToString()),
                                                new SqlParameter("@amount",         _dr2["amount"].ToString()),
                                                new SqlParameter("@regisCase",      (!String.IsNullOrEmpty(_dr2["regisCase"].ToString()) ? _dr2["regisCase"].ToString() : null)),
                                                new SqlParameter("@contractDate",   _contractDate),
                                                new SqlParameter("@approveDate",    _approveDate),                                                
                                                new SqlParameter("@by",             _username),
                                                new SqlParameter("@ip",             SCHUtil.GetIP()));
                                }

                                if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_ADDUPDATE))
                                {                                
                                    _ds     = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                                new SqlParameter("@action",         "UPDATE"),
                                                new SqlParameter("@personId",       _dr2["id"].ToString()),
                                                new SqlParameter("@acaYear",        _dr2["scholarshipsYear"].ToString()),
                                                new SqlParameter("@semester",       _dr2["semester"].ToString()),                                                
                                                new SqlParameter("@scholarshipsId", _dr2["scholarshipsId"].ToString()),
                                                new SqlParameter("@cancelStatus",   _c.Request["cancelStatus"]),
                                                new SqlParameter("@remark",         _c.Request["reason"]),                                                
                                                new SqlParameter("@by",             _username),
                                                new SqlParameter("@ip",             SCHUtil.GetIP()));
                                }                                
                                _dr         = _ds.Tables[0].Rows[0];
                                _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                                _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                                _ds.Dispose();
                            }
                            else
                                {
                                    _incomplete++;
                                }

                            _ds2.Dispose();
                        }
                        catch (Exception _ex)
                        {
                            _incomplete++;
                        }
                    }

                    _ds1.Dispose();
                }
            }
            
            if (_page.Equals(SCHUtil.PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                    new SqlParameter("@action",             "UPDATE"),
                                    new SqlParameter("@personId",           _c.Request["personId"]),
                                    new SqlParameter("@acaYear",            _c.Request["scholarshipsYear"]),
                                    new SqlParameter("@semester",           _c.Request["semester"]),
                                    new SqlParameter("@scholarshipsId",     _c.Request["scholarshipsId"]),
                                    new SqlParameter("@amount",             _c.Request["tuition"]),
                                    new SqlParameter("@invoiceNo",          _c.Request["invoiceNo"]),
                                    new SqlParameter("@regisCredit",        _c.Request["regisCredit"]),
                                    new SqlParameter("@invoiceAmount",      _c.Request["invoiceAmount"]),
                                    new SqlParameter("@stdPayAmount",       _c.Request["stdPayAmount"]),
                                    new SqlParameter("@ratePerYear",        _c.Request["ratePerYear"]),
                                    new SqlParameter("@ratePerYearRemain",  _c.Request["ratePerYearRemain"]),                                                                       
                                    new SqlParameter("@by",                 _username),
                                    new SqlParameter("@ip",                 SCHUtil.GetIP()));
                    _dr         = _ds.Tables[0].Rows[0];
                    _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                    _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                    _ds.Dispose();
                }
            }
            
            if (_page.Equals(SCHUtil.PAGE_IMPORTREGISTERSCHOLARSHIP_ADDUPDATE))
            {
                _option         = _c.Request["option"];
                _selected       = _c.Request["selected"];
                _paramSearch    = _c.Request["paramSearch"];

                if (_option.Equals("selected") || _option.Equals("all"))
                {
                    _keyword        = _selected;
                    _valueArray1    = _keyword.Split('|');

                    DataTable _dt1  = new DataTable();
                    DataSet _ds1    = new DataSet();

                    _dt1.Columns.Add("id");
                    _dt1.Columns.Add("scholarshipsYear");
                    _dt1.Columns.Add("semester");
                    _dt1.Columns.Add("scholarshipsId");
                    _dt1.Columns.Add("responsibleAgency");
                    _dt1.Columns.Add("amount");
                    _dt1.Columns.Add("remark");

                    for (_i = 0; _i < _valueArray1.GetLength(0); _i++)
                    {
                        string[] _valueSelected = _valueArray1[_i].Split(':');

                        DataRow _dr1 = _dt1.NewRow();

                        _dr1["id"]                  = _valueSelected[0];
                        _dr1["scholarshipsYear"]    = _valueSelected[1];
                        _dr1["semester"]            = _valueSelected[2];
                        _dr1["scholarshipsId"]      = _valueSelected[3];                            
                        _dr1["responsibleAgency"]   = _valueSelected[4];
                        _dr1["amount"]              = _valueSelected[5];
                        _dr1["remark"]              = _valueSelected[6];                        

                        _dt1.Rows.Add(_dr1);    
                    }

                    _ds1.Tables.Add(_dt1);

                    foreach (DataRow _dr2 in _ds1.Tables[0].Rows)
                    {
                        try
                        {
                            _saveError = 0;

                            DataSet _ds2 = GetTranStudent(_dr2["id"].ToString(), _dr2["scholarshipsYear"].ToString(), _dr2["semester"].ToString(), _dr2["scholarshipsId"].ToString());

                            if (_ds2.Tables[0].Rows.Count > 0)
                            {
                                if (_ds2.Tables[0].Rows[0]["cancelStatus"].Equals("Y"))    
                                {
                                    _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                                    new SqlParameter("@action",             "UPDATE"),
                                                    new SqlParameter("@personId",           _dr2["id"].ToString()),
                                                    new SqlParameter("@acaYear",            _dr2["scholarshipsYear"].ToString()),
                                                    new SqlParameter("@semester",           _dr2["semester"].ToString()),
                                                    new SqlParameter("@scholarshipsId",     _dr2["scholarshipsId"].ToString()),
                                                    new SqlParameter("@responsibleAgency",  _dr2["responsibleAgency"].ToString()),
                                                    new SqlParameter("@amount",             _dr2["amount"].ToString()),
                                                    new SqlParameter("@regisCase",          "S"),
                                                    new SqlParameter("@registerDate",       _c.Request["registerDate"]),                                                    
                                                    new SqlParameter("@contractDate",       ""),
                                                    new SqlParameter("@approveDate",        ""),
                                                    new SqlParameter("@cancelStatus",       ""),
                                                    new SqlParameter("@remark",             _dr2["remark"].ToString()),
                                                    new SqlParameter("@by",                 _username),
                                                    new SqlParameter("@ip",                 SCHUtil.GetIP()));
                                    _dr         = _ds.Tables[0].Rows[0];
                                    _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                                    _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                                    _ds.Dispose();
                                }
                                else
                                    _complete++;
                            }
                            else
                                {
                                    _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                                    new SqlParameter("@action",             "INSERT"),
                                                    new SqlParameter("@personId",           _dr2["id"].ToString()),
                                                    new SqlParameter("@acaYear",            _dr2["scholarshipsYear"].ToString()),
                                                    new SqlParameter("@semester",           _dr2["semester"].ToString()),
                                                    new SqlParameter("@scholarshipsId",     _dr2["scholarshipsId"].ToString()),
                                                    new SqlParameter("@responsibleAgency",  _dr2["responsibleAgency"].ToString()),
                                                    new SqlParameter("@amount",             _dr2["amount"].ToString()),
                                                    new SqlParameter("@regisCase",          "S"),
                                                    new SqlParameter("@registerDate",       _c.Request["registerDate"]),
                                                    new SqlParameter("@remark",             _dr2["remark"].ToString()),
                                                    new SqlParameter("@by",                 _username),
                                                    new SqlParameter("@ip",                 SCHUtil.GetIP()));
                                    _dr         = _ds.Tables[0].Rows[0];
                                    _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                                    _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                                    _ds.Dispose();
                                }

                            _ds2.Dispose();
                        }
                        catch (Exception _ex)
                        {
                            _incomplete++;
                        }
                    }

                    _ds1.Dispose();
                }
            }

            if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_ADD) ||
                _page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_ADD))    _action = "INSERT";
                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE)) _action = "UPDATE";

                    _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetApprovalReceiveFinance",
                                    new SqlParameter("@action",                 _action),
                                    new SqlParameter("@scholarshipsTypeGroup",  _c.Request["scholarshipsTypeGroup"]),
                                    new SqlParameter("@scholarshipsYear",       _c.Request["scholarshipsYear"]),
                                    new SqlParameter("@semester",               _c.Request["semester"]),
                                    new SqlParameter("@lotNo",                  _c.Request["lotno"]),
                                    new SqlParameter("@deliverNo",              _c.Request["deliverNo"]),
                                    new SqlParameter("@deliverDate",            _c.Request["deliverDate"]),
                                    new SqlParameter("@amount",                 _c.Request["amount"]),
                                    new SqlParameter("@approveNumber",          _c.Request["approveNumber"]),
                                    new SqlParameter("@approveDate",            _c.Request["approveDate"]),
                                    new SqlParameter("@cancelStatus",           ""),
                                    new SqlParameter("@by",                     _username),
                                    new SqlParameter("@ip",                     SCHUtil.GetIP()));
                    _dr         = _ds.Tables[0].Rows[0];
                    _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                    _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                    _ds.Dispose();
                }
            }

            if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE))
            {
                _selected       = _c.Request["selected"];
                _approveDate    = SCHUtil.CurrentDate("dd/MM/yyyy");
                _keyword        = _selected;
                
                _paramResult.Add("Keyword", _keyword);

                DataTable _dt1  = new DataTable();
                DataSet _ds1    = new DataSet();

                string[] _valueSelected = _paramResult["Keyword"].ToString().Split('|');
                _dt1.Columns.Add("id");
                _dt1.Columns.Add("scholarshipsYear");
                _dt1.Columns.Add("semester");
                _dt1.Columns.Add("scholarshipsId");
                _dt1.Columns.Add("lotNo");

                for (_i = 0; _i < _valueSelected.GetLength(0); _i++)
                {
                    _valueArray1 = _valueSelected[_i].Split(':');

                    DataRow _dr1 = _dt1.NewRow();

                    _dr1["id"]                  = _valueArray1[0];
                    _dr1["scholarshipsYear"]    = _valueArray1[1];
                    _dr1["semester"]            = _valueArray1[2];
                    _dr1["scholarshipsId"]      = _valueArray1[3];
                    _dr1["lotNo"]               = _valueArray1[4];

                    _dt1.Rows.Add(_dr1);
                }

                _ds1.Tables.Add(_dt1);

                foreach (DataRow _dr2 in _ds1.Tables[0].Rows)
                {                
                    try
                    {
                        _saveError = 0;

                        DataSet _ds2 = GetTranStudent(_dr2["id"].ToString(), _dr2["scholarshipsYear"].ToString(), _dr2["semester"].ToString(), _dr2["scholarshipsId"].ToString());

                        if (_ds2.Tables[0].Rows.Count > 0)
                        {                                                                    
                            _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                            new SqlParameter("@action",         "UPDATE"),
                                            new SqlParameter("@personId",       _dr2["id"].ToString()),
                                            new SqlParameter("@acaYear",        _dr2["scholarshipsYear"].ToString()),
                                            new SqlParameter("@semester",       _dr2["semester"].ToString()),                                                
                                            new SqlParameter("@scholarshipsId", _dr2["scholarshipsId"].ToString()),
                                            new SqlParameter("@lotNo",          _dr2["lotNo"].ToString()),
                                            new SqlParameter("@approveDate",    _approveDate),
                                            new SqlParameter("@by",             _username),
                                            new SqlParameter("@ip",             SCHUtil.GetIP()));

                            _dr         = _ds.Tables[0].Rows[0];
                            _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                            _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                            _ds.Dispose();
                        }
                        else
                            {
                                _incomplete++;
                            }

                        _ds2.Dispose();
                    }
                    catch (Exception _ex)
                    {
                        _incomplete++;
                    }
                }

                _ds1.Dispose();
            }

            if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_ADDUPDATE))
            {
                _option         = _c.Request["option"];
                _selected       = _c.Request["selected"];
                _paramSearch    = _c.Request["paramSearch"];
                _transferDate   = SCHUtil.CurrentDate("dd/MM/yyyy");

                if (_option.Equals("selected") || _option.Equals("all"))
                {
                    if (_option.Equals("selected") && !String.IsNullOrEmpty(_selected))
                        _keyword = _selected;

                    if (_option.Equals("all") && !String.IsNullOrEmpty(_paramSearch))
                    {
                        _valueArray1 = _paramSearch.Split(',');
                        _valueSearch = new string[_valueArray1.GetLength(0)];

                        for (_i = 0; _i < _valueArray1.GetLength(0); _i++)
                        {
                            _valueArray2        = _valueArray1[_i].Split(':');
                            _valueSearch[_i]    = _valueArray2[1];
                        }
                    
                        _subKeyword             = _valueSearch[0];
                        _facultyId              = _valueSearch[1];
                        _programId              = _valueSearch[2];
                        _yearEntry              = _valueSearch[3];
                        _scholarshipsTypeGroup  = _valueSearch[4];
                        _scholarshipsYear       = _valueSearch[5];
                        _semester               = _valueSearch[6];
                        _lotNo                  = _valueSearch[7];
                        _groupReceiver          = _valueSearch[8];
                        _recipientStatus        = _valueSearch[9];
                    }

                    _paramResult.Add("SubKeyword",              _subKeyword);
                    _paramResult.Add("FacultyId",               _facultyId);
                    _paramResult.Add("ProgramId",               _programId);
                    _paramResult.Add("YearEntry",               _yearEntry);
                    _paramResult.Add("ScholarshipsTypeGroup",   _scholarshipsTypeGroup);
                    _paramResult.Add("ScholarshipsYear",        _scholarshipsYear);
                    _paramResult.Add("Semester",                _semester);                        
                    _paramResult.Add("LotNo",                   _lotNo);
                    _paramResult.Add("GroupReceiver",           _groupReceiver);
                    _paramResult.Add("RecipientStatus",         _recipientStatus);
                        
                    DataTable _dt1  = new DataTable();
                    DataSet _ds1    = new DataSet();

                    if (_option.Equals("selected"))
                    {
                        _valueArray1 = _keyword.Split('|');

                        _dt1.Columns.Add("id");
                        _dt1.Columns.Add("scholarshipsYear");
                        _dt1.Columns.Add("semester");
                        _dt1.Columns.Add("schScholarshipsId");
                        _dt1.Columns.Add("schGroupReceiverId");

                        for (_i = 0; _i < _valueArray1.GetLength(0); _i++)
                        {
                            string[] _valueSelected = _valueArray1[_i].Split(':');

                            DataRow _dr1 = _dt1.NewRow();

                            _dr1["id"]                  = _valueSelected[0];
                            _dr1["scholarshipsYear"]    = _valueSelected[1];
                            _dr1["semester"]            = _valueSelected[2];
                            _dr1["schScholarshipsId"]   = _valueSelected[3];
                            _dr1["schGroupReceiverId"]  = _valueSelected[4];

                            _dt1.Rows.Add(_dr1);
                        }

                        _ds1.Tables.Add(_dt1);                                             
                    }

                    if (_option.Equals("all"))
                    {
                        _ds1 = GetListTranStudentFinanceScholarshipClassificationRecipient(_username, _userlevel, _systemGroup, _paramResult);
                    }

                    foreach (DataRow _dr2 in _ds1.Tables[0].Rows)
                    {                
                        try
                        {
                            _saveError = 0;

                            DataSet _ds2 = GetTranStudent(_dr2["id"].ToString(), _dr2["scholarshipsYear"].ToString(), _dr2["semester"].ToString(), _dr2["schScholarshipsId"].ToString());

                            if (_ds2.Tables[0].Rows.Count > 0)
                            {
                                _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                                new SqlParameter("@action",             "UPDATE"),
                                                new SqlParameter("@personId",           _dr2["id"].ToString()),
                                                new SqlParameter("@acaYear",            _dr2["scholarshipsYear"].ToString()),
                                                new SqlParameter("@semester",           _dr2["semester"].ToString()),
                                                new SqlParameter("@scholarshipsId",     _dr2["schScholarshipsId"].ToString()),
                                                new SqlParameter("@schGroupReceiverId", _dr2["schGroupReceiverId"].ToString()),
                                                new SqlParameter("@transferDate",       _transferDate),
                                                new SqlParameter("@by",                 _username),
                                                new SqlParameter("@ip",                 SCHUtil.GetIP()));
                                _dr         = _ds.Tables[0].Rows[0];
                                _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                                _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                                _ds.Dispose();
                            }
                            else
                                _incomplete++;

                            _ds2.Dispose();
                        }
                        catch (Exception _ex)
                        {
                            _incomplete++;
                        }
                    }

                    _ds1.Dispose();
                }             
            }

            if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_ADD) ||
                _page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_ADD))     _action = "INSERT";
                    if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE))  _action = "UPDATE";

                    _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetCheque",
                                    new SqlParameter("@action",         _action),
                                    new SqlParameter("@payChequeYear",  _c.Request["payChequeYear"]),
                                    new SqlParameter("@semester",       _c.Request["semester"]),
                                    new SqlParameter("@lotNo",          _c.Request["lotno"]),
                                    new SqlParameter("@pvjvNo",         _c.Request["pvjvNo"]),
                                    new SqlParameter("@chequeNo",       _c.Request["chequeNo"]),
                                    new SqlParameter("@groupReceiver",  _c.Request["groupReceiver"]),
                                    new SqlParameter("@amount",         _c.Request["amount"]),
                                    new SqlParameter("@receiverNumber", _c.Request["receiverNumber"]),
                                    new SqlParameter("@bankCode",       _c.Request["bankCode"]),
                                    new SqlParameter("@paidDate",       _c.Request["paidDate"]),
                                    new SqlParameter("@prepareDate",    _c.Request["prepareDate"]),
                                    new SqlParameter("@cancelStatus",   ""),
                                    new SqlParameter("@by",             _username),
                                    new SqlParameter("@ip",             SCHUtil.GetIP()));
                    _dr         = _ds.Tables[0].Rows[0];
                    _action     = _dr[1].ToString();
                    _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                    _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                    _ds.Dispose();
                }
            }

            if (_page.Equals(SCHUtil.PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE))
            {
                _selected   = _c.Request["selected"];
                _chequeDate = SCHUtil.CurrentDate("dd/MM/yyyy");
                _keyword    = _selected;
                
                _paramResult.Add("Keyword", _keyword);

                DataTable _dt1  = new DataTable();
                DataSet _ds1    = new DataSet();

                string[] _valueSelected = _paramResult["Keyword"].ToString().Split('|');
                _dt1.Columns.Add("id");
                _dt1.Columns.Add("scholarshipsYear");
                _dt1.Columns.Add("semester");
                _dt1.Columns.Add("scholarshipsId");
                _dt1.Columns.Add("payChequeYear");
                _dt1.Columns.Add("payChequeSemester");
                _dt1.Columns.Add("lotNo");
                _dt1.Columns.Add("pvjvNo");
                _dt1.Columns.Add("chequeNo");

                for (_i = 0; _i < _valueSelected.GetLength(0); _i++)
                {
                    _valueArray1 = _valueSelected[_i].Split(':');

                    DataRow _dr1 = _dt1.NewRow();

                    _dr1["id"]                  = _valueArray1[0];
                    _dr1["scholarshipsYear"]    = _valueArray1[1];
                    _dr1["semester"]            = _valueArray1[2];
                    _dr1["scholarshipsId"]      = _valueArray1[3];
                    _dr1["payChequeYear"]       = _valueArray1[4];
                    _dr1["payChequeSemester"]   = _valueArray1[5];
                    _dr1["lotNo"]               = _valueArray1[6];
                    _dr1["pvjvNo"]              = _valueArray1[7];
                    _dr1["chequeNo"]            = _valueArray1[8];

                    _dt1.Rows.Add(_dr1);
                }

                _ds1.Tables.Add(_dt1);

                foreach (DataRow _dr2 in _ds1.Tables[0].Rows)
                {                
                    try
                    {
                        _saveError = 0;

                        DataSet _ds2 = GetTranStudent(_dr2["id"].ToString(), _dr2["scholarshipsYear"].ToString(), _dr2["semester"].ToString(), _dr2["scholarshipsId"].ToString());

                        if (_ds2.Tables[0].Rows.Count > 0)
                        {                                                                    
                            _ds         = SCHDB.ExecuteCommandStoredProcedure("sp_schSetTranStudent",
                                            new SqlParameter("@action",         "UPDATE"),
                                            new SqlParameter("@personId",       _dr2["id"].ToString()),
                                            new SqlParameter("@acaYear",        _dr2["scholarshipsYear"].ToString()),
                                            new SqlParameter("@semester",       _dr2["semester"].ToString()),                                                
                                            new SqlParameter("@scholarshipsId", _dr2["scholarshipsId"].ToString()),
                                            new SqlParameter("@chequeId",       (_dr2["payChequeYear"].ToString() + _dr2["payChequeSemester"].ToString() + _dr2["lotNo"].ToString() + _dr2["pvjvNo"].ToString() + _dr2["chequeNo"].ToString())),
                                            new SqlParameter("@chequeDate",     _chequeDate),
                                            new SqlParameter("@by",             _username),
                                            new SqlParameter("@ip",             SCHUtil.GetIP()));

                            _dr         = _ds.Tables[0].Rows[0];
                            _complete   = (_complete + (int.Parse(_dr[0].ToString()) > 0 ? int.Parse(_dr[0].ToString()) : 0));
                            _incomplete = (_incomplete + (int.Parse(_dr[0].ToString()).Equals(0) ? 1 : 0));
                            _ds.Dispose();
                        }
                        else
                            {
                                _incomplete++;
                            }

                        _ds2.Dispose();
                    }
                    catch (Exception _ex)
                    {
                        _incomplete++;
                    }
                }

                _ds1.Dispose();
            }

            if (_actionSave.Equals(true))
            {
                _saveError  = (_complete > 0 ? 0 : 1);
            }
        }
        catch
        {
            _ds.Dispose();
            _saveError = 1;
        }

        _saveResult.Add("Action",       _action);
        _saveResult.Add("SaveError",    _saveError);
        _saveResult.Add("Complete",     _complete.ToString("#,##0"));
        _saveResult.Add("Incomplete",   _incomplete.ToString("#,##0"));
        _saveResult.Add("Id",           _id);

        return _saveResult;
    }

    public static Dictionary<string, object> ActionExport(HttpContext _c, Dictionary<string, object> _infoLogin)
    {
        Dictionary<string, object> _exportResult = new Dictionary<string, object>();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        string _username = _infoLogin["Username"].ToString();
        string _userlevel = _infoLogin["Userlevel"].ToString();
        string _systemGroup = _infoLogin["SystemGroup"].ToString();
        string _fileName = ((DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US")));
        string _filePath = (HttpContext.Current.Server.MapPath("~") + "/" + SCHUtil._myFileDownloadPath);
        string _page = _c.Request["page"];
        string _option = _c.Request["option"];
        string _selected = _c.Request["selected"];
        string _keyword = String.Empty;
        string _facultyId = String.Empty;
        string _programId = String.Empty;
        string _yearEntry = String.Empty;
        string _scholarshipsTypeGroup = String.Empty;
        string _scholarshipsYear = String.Empty;
        string _semester = String.Empty;
        string _lotNo = String.Empty;
        string _groupReceiver = String.Empty;
        string _recipientStatus = String.Empty;
        bool _exportError = false;
        int _tbIndex = 0;
        int _complete = 0;
        int _incomplete = 0;
        int _i = 0;
        object _sum = 0;        

        if (_option.Equals("selected") || _option.Equals("all"))
        {
            if (_option.Equals("selected") && !String.IsNullOrEmpty(_selected))
                _keyword = _selected;

            if (_option.Equals("all"))
            {
                _keyword                = _c.Request["keyword"];
                _facultyId              = _c.Request["facultyId"];
                _programId              = _c.Request["programId"];
                _yearEntry              = _c.Request["yearEntry"];
                _scholarshipsTypeGroup  = _c.Request["scholarshipsTypeGroup"];
                _scholarshipsYear       = _c.Request["scholarshipsYear"];
                _semester               = _c.Request["semester"];
                _lotNo                  = _c.Request["lotNo"];
                _groupReceiver          = _c.Request["groupReceiver"];
                _recipientStatus        = _c.Request["recipientStatus"];
            }

            _paramSearch.Add("Keyword",                 _keyword);
            _paramSearch.Add("FacultyId",               _facultyId);
            _paramSearch.Add("ProgramId",               _programId);
            _paramSearch.Add("YearEntry",               _yearEntry);
            _paramSearch.Add("ScholarshipsTypeGroup",   _scholarshipsTypeGroup);
            _paramSearch.Add("ScholarshipsYear",        _scholarshipsYear);
            _paramSearch.Add("Semester",                _semester);
            _paramSearch.Add("LotNo",                   _lotNo);
            _paramSearch.Add("GroupReceiver",           _groupReceiver);
            _paramSearch.Add("RecipientStatus",         _recipientStatus);
            
            DataTable _dt1 = new DataTable();
            DataTable _dt2 = new DataTable();
            DataSet _ds1 = new DataSet();

            if (_option.Equals("selected"))
            {               
                string[] _id = _paramSearch["Keyword"].ToString().Split('|');
                _dt1.Columns.Add("id");

                for (_i = 0; _i < _id.GetLength(0); _i++)
                {
                    _dt1.Rows.Add(_id[_i]);
                }

                _ds1.Tables.Add(_dt1);
            }

            if (_option.Equals("all"))                    
            {
                if (_page.Equals(SCHUtil.PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT))
                    _ds1 = GetListTranStudentFinanceScholarshipClassificationRecipient(_username, _userlevel, _systemGroup, _paramSearch);
            }

            if (_ds1.Tables[_tbIndex].Rows.Count > 0)
            {
                if (_page.Equals(SCHUtil.PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT))
                {
                    _dt2    = SCHUtil.SetColumnDataTable(_page);
                    _i      = 0;
                    _sum    = _ds1.Tables[_tbIndex].Compute("SUM(tuition)", "");        

                    foreach (DataRow _dr1 in _ds1.Tables[_tbIndex].Rows)
                    {                
                        try
                        {
                            _exportError = false;

                            if (_page.Equals(SCHUtil.PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT))
                            {                                                                        
                                DataRow _dr2 = _dt2.NewRow();

                                _dr2["No."]             = _dr1["rowNum"].ToString(); 
                                _dr2["StudentCode"]     = _dr1["studentCode"].ToString();
                                _dr2["FullName"]        = SCHUtil.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString());
                                _dr2["Faculty"]         = _dr1["facultyCode"].ToString(); 
                                _dr2["Program"]         = _dr1["programNameTH"].ToString();
                                _dr2["Tuition"]         = _dr1["tuition"].ToString();
                                _dr2["GroupReceiver"]   = _dr1["groupReceiverNameTH"].ToString();
                                _dr2["Bank"]            = _dr1["plcBankCode"].ToString();
                                _dr2["AccountNo"]       = _dr1["accNo"].ToString();
                                _dr2["LotNo"]           = _dr1["lotNo"].ToString();

                                _dt2.Rows.Add(_dr2);
                                _i++;
                            }

                            if (_exportError.Equals(false))
                                _complete++;
                            else
                                _incomplete++;
                        }
                        catch (Exception _ex)
                        {
                            _incomplete++;
                        }
                    }
                }
            }

            _ds1.Dispose();

            if (_complete > 0)
            {
                if (_page.Equals(SCHUtil.PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT))
                {
                    _fileName = (SCHUtil.SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL + _fileName + ".xlsx");
                   
                    MemoryStream _ms    = new MemoryStream();
                    FileStream _fs      = new FileStream(_filePath + "/" + _fileName, FileMode.Create, FileAccess.Write);
                    ExcelPackage _pk    = new ExcelPackage();
                    ExcelWorksheet _ws  = _pk.Workbook.Worksheets.Add("Sheet1");
                    var _cellRange      = _ws.Cells[1, 1, (_complete + 3), _dt2.Columns.Count];
                    var _cellTitle      = _ws.Cells["A1:J1"];
                    var _cellHeader     = _ws.Cells["A2:J2"];
                    var _cellFooter     = _ws.Cells["A" + (_complete + 3) + ":J" + (_complete + 3)];
                    var _cellFooter1    = _ws.Cells["A" + (_complete + 3) + ":D" + (_complete + 3)];
                    var _cellFooter2    = _ws.Cells["E" + (_complete + 3) + ":F" + (_complete + 3)];                    

                    _ws.Cells.Style.Font.Name   = "Cordia New";
                    _ws.Cells.Style.Font.Size   = 14;                    

                    _cellRange.Style.Border.Top.Style       = ExcelBorderStyle.Thin;
                    _cellRange.Style.Border.Right.Style     = ExcelBorderStyle.Thin;
                    _cellRange.Style.Border.Bottom.Style    = ExcelBorderStyle.Thin;
                    _cellRange.Style.Border.Left.Style      = ExcelBorderStyle.Thin;

                    _cellTitle.Merge = true;
                    _cellTitle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _cellTitle.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _cellTitle.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 204, 255));
                    _cellTitle.Value = string.Format("รายชื่อนักศึกษาที่ได้รับอนุมัติเงินจาก กรอ. ภาคการศึกษา {0} / {1}", _paramSearch["Semester"], _paramSearch["ScholarshipsYear"]);

                    _cellHeader.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _cellHeader.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _cellHeader.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(204, 204, 255));
                    _ws.Cells["A2"].Value = "ลำดับ";
                    _ws.Cells["B2"].Value = "รหัสนักศึกษา";
                    _ws.Cells["C2"].Value = "ชื่อ - สกุล";
                    _ws.Cells["D2"].Value = "คณะ";
                    _ws.Cells["E2"].Value = "หลักสูตร";
                    _ws.Cells["F2"].Value = "จำนวนเงินที่ขอกู้ ( บาท )";
                    _ws.Cells["G2"].Value = "ผู้รับเงิน";
                    _ws.Cells["H2"].Value = "ธนาคาร";
                    _ws.Cells["I2"].Value = "เลขที่บัญชี";
                    _ws.Cells["J2"].Value = "งวดที่จ่ายเงิน";

                    _i = 3;                    
                    _ws.Cells["A" + _i + ":A" + (_complete + _i)].Style.Numberformat.Format = "#,##0";
                    _ws.Cells["A" + _i + ":A" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _ws.Cells["B" + _i + ":B" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _ws.Cells["D" + _i + ":D" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;                    
                    _ws.Cells["F" + _i + ":F" + (_complete + _i)].Style.Numberformat.Format = "#,##0.00";
                    _ws.Cells["F" + _i + ":F" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    _ws.Cells["G" + _i + ":G" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;                    
                    _ws.Cells["H" + _i + ":H" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _ws.Cells["I" + _i + ":I" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _ws.Cells["J" + _i + ":J" + (_complete + _i)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    foreach (DataRow _dr3 in _dt2.Rows)
                    {
                        _ws.Cells["A" + _i].Value = int.Parse(_dr3["No."].ToString());
                        _ws.Cells["B" + _i].Value = _dr3["StudentCode"];
                        _ws.Cells["C" + _i].Value = _dr3["FullName"];
                        _ws.Cells["D" + _i].Value = _dr3["Faculty"];
                        _ws.Cells["E" + _i].Value = _dr3["Program"];
                        _ws.Cells["F" + _i].Value = double.Parse(_dr3["Tuition"].ToString());
                        _ws.Cells["G" + _i].Value = _dr3["GroupReceiver"];
                        _ws.Cells["H" + _i].Value = _dr3["Bank"];
                        _ws.Cells["I" + _i].Value = _dr3["AccountNo"];
                        _ws.Cells["J" + _i].Value = _dr3["LotNo"];

                        _i++;
                    }

                    _cellFooter.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _cellFooter.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(204, 204, 255));

                    _cellFooter1.Merge = true;
                    _cellFooter1.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    _cellFooter1.Value = string.Format("นักศึกษาทั้งหมด {0} คน", _complete);

                    _cellFooter2.Merge = true;
                    _cellFooter2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    _cellFooter2.Value = string.Format("จำนวนเงินทั้งหมด {0}", double.Parse(_sum.ToString()).ToString("#,##0.00"));

                    _ws.Cells.AutoFitColumns();

                    _pk.SaveAs(_ms);
                    _ms.WriteTo(_fs);

                    _ms.Close();
                    _ms.Dispose();
                    _fs.Close();
                    _fs.Dispose();
                }
            }
        }

        _exportResult.Add("Complete",       _complete.ToString("#,##0"));
        _exportResult.Add("Incomplete",     _incomplete.ToString("#,##0"));
        _exportResult.Add("DownloadFolder", SCHUtil._myFileDownloadPath);
        _exportResult.Add("DownloadFile",   _fileName);
        
        return _exportResult;
    }
}