using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

public class SCHRegisterScholarshipUtil
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
        StringBuilder _list = new StringBuilder();
        StringBuilder _navPage = new StringBuilder();

        _ds                 = SCHDB.GetListStudent(_username, _userlevel, _systemGroup, _paramSearch);
        _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
        _recordCount        = _ds.Tables[0].Rows.Count;
        _recordCountPrimary = _ds.Tables[0].Rows.Count;
        _list               = SCHRegisterScholarshipUI.ListUI.GetMain(_dr);
        _navPage            = SCHUtil.GetNavPage(_recordCount, (int)(_paramSearch["CurrentPage"]), SCHUtil.PAGE_REGISTERSCHOLARSHIP_MAIN, (int)(_paramSearch["RowPerPage"]));

        _ds.Dispose();

        _searchResult.Add("RecordCount",        _recordCount);
        _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
        _searchResult.Add("Sum",                0);
        _searchResult.Add("List",               _list);
        _searchResult.Add("NavPage",            _navPage);        

        return _searchResult;
    }
}