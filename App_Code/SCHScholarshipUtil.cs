using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

public class SCHScholarshipUtil
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

        _ds                 = SCHDB.GetListScholarships(_paramSearch);
        _dr                 = _ds.Tables[0].Select();
        _recordCount        = _ds.Tables[0].Rows.Count;
        _recordCountPrimary = _ds.Tables[0].Rows.Count;
        _list               = SCHScholarshipUI.ListUI.GetMain(_dr);

        _ds.Dispose();

        _searchResult.Add("RecordCount",        _recordCount);
        _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
        _searchResult.Add("Sum",                0);
        _searchResult.Add("List",               _list);
        _searchResult.Add("NavPage",            new StringBuilder());

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
             
        _dataRecorded.Add("Id",                     (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"] : String.Empty));
        _dataRecorded.Add("ScholarshipsNameTH",     (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsNameTH"].ToString()) ? _dr["scholarshipsNameTH"] : String.Empty));
        _dataRecorded.Add("ScholarshipsNameEN",     (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsNameEN"].ToString()) ? _dr["scholarshipsNameEN"] : String.Empty));
        _dataRecorded.Add("ScholarshipsTypeId",     (_dr != null && !String.IsNullOrEmpty(_dr["schScholarshipsTypeId"].ToString()) ? _dr["schScholarshipsTypeId"] : String.Empty));
        _dataRecorded.Add("ScholarshipsTypeGroup",  (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipsTypeGroup"].ToString()) ? _dr["scholarshipsTypeGroup"] : String.Empty));
        _dataRecorded.Add("Owner",                  (_dr != null && !String.IsNullOrEmpty(_dr["owner"].ToString()) ? _dr["owner"] : String.Empty));
        _dataRecorded.Add("ApprovalStatus",         (_dr != null && !String.IsNullOrEmpty(_dr["approvalStatus"].ToString()) ? _dr["approvalStatus"] : String.Empty));

        return _dataRecorded;
    }     
}