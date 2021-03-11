<%@ WebHandler Language="C#" Class="SCHHandler" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

public class SCHHandler : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext _context)
    {
        _context.Response.ContentType = "application/json";
        bool _error = false;

        if (_error.Equals(false))
        {
            string _action = _context.Request["action"];

            GetContentAction(_action, _context);
        }
    }

    private void GetContentAction(string _action, HttpContext _c)
    {
        switch (_action)
        {
            case "page"         : { ShowPage(_c); break; }
            case "form"         : { ShowForm(_c); break; }
            case "search"       : { ShowSearch(_c); break; }
            case "save"         : { ShowSave(_c); break; }
            case "export"       : { ShowExport(_c); break; }
            case "dropdown"     : { ShowDropdown(_c); break; }
            case "get"          : { ShowGet(_c); break; }
            case "image2stream" : { ShowImage2Stream(_c); break; }
        }
    }

    private void ShowPage(HttpContext _c)
    {
        string _page = _c.Request["page"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();

        _pageResult = SCHUtil.GetPage(_page, _id);

        _c.Response.Write(_json.Serialize(_pageResult));
    }

    private void ShowForm(HttpContext _c)
    {
        string _form = _c.Request["form"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();

        _formResult = SCHUtil.GetForm(_form, _id);

        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_formResult));
    }

    private void ShowDropdown(HttpContext _c)
    {
        string _cmd = _c.Request["cmd"];
        StringBuilder _content = new StringBuilder();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _listResult = new Dictionary<string, object>();

        switch (_cmd)
        {
            case "getprogram"   : { _content = SCHUI.DDLProgram(_c.Request["id"], "", _c.Request["facultyId"]); break; }
            case "getlotno"     : { _content = SCHUI.DDLLotNoApprovalReceiveFinance(_c.Request["id"], _c.Request["scholarshipsTypeGroup"], _c.Request["scholarshipsYear"], _c.Request["semester"]); break; }
        }

        _listResult.Add("Content", _content.ToString());

        _json.MaxJsonLength = Int32.MaxValue;
        
        _c.Response.Write(_json.Serialize(_listResult));
    }

    private void ShowSearch(HttpContext _c)
    {
        string _page = _c.Request["page"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _content = new Dictionary<string, object>();
        Dictionary<string, object> _searchResult = new Dictionary<string, object>();

        _content = SCHUtil.GetSearch(_page, _c);

        _searchResult.Clear();
        _searchResult.Add("RecordCount",        SCHUtil.GetValueDataDictionary(_content, "RecordCount", double.Parse(_content["RecordCount"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountPrimary", SCHUtil.GetValueDataDictionary(_content, "RecordCountPrimary", double.Parse(_content["RecordCountPrimary"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("Sum",                SCHUtil.GetValueDataDictionary(_content, "Sum", double.Parse(_content["Sum"].ToString()).ToString("#,##0.00"), String.Empty));
        _searchResult.Add("List",               SCHUtil.GetValueDataDictionary(_content, "List", _content["List"].ToString(), String.Empty));
        _searchResult.Add("NavPage",            SCHUtil.GetValueDataDictionary(_content, "NavPage", _content["NavPage"].ToString(), String.Empty));
               
        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_searchResult));
    }

    private void ShowGet(HttpContext _c)
    {
        string _cmd = _c.Request["cmd"];
        StringBuilder _content = new StringBuilder();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _getResult = new Dictionary<string, object>();

        switch (_cmd)
        {
            case "gettranstudent"                   : { _getResult = SCHUtil.GetTranStudent(_c.Request["personId"], _c.Request["scholarshipsYear"], _c.Request["semester"], _c.Request["scholarshipsId"]); break; }
            case "getmaxlotapprovalreceivefinance"  : { _getResult = SCHUtil.GetMaxLotApprovalReceiveFinance(_c.Request["scholarshipsTypeGroup"], _c.Request["scholarshipsYear"], _c.Request["semester"]); break; }
        }

        _json.MaxJsonLength = Int32.MaxValue;
        
        _c.Response.Write(_json.Serialize(_getResult));
    }    
    
    private void ShowImage2Stream(HttpContext _c)
    {
        MemoryStream _ms = SCHUtil.ImageToStream(SCHUtil.DecodeFromBase64(_c.Request["f"]), "png");

        _ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }    
    
    private void ShowSave(HttpContext _c)
    {
        string _signinYN = _c.Request["signinYN"];
        string _page = _c.Request["page"];
        string _id = _c.Request["id"];
        string _complete = String.Empty;
        string _incomplete = String.Empty;
        string _contractDate = String.Empty;
        string _approveDate = String.Empty;
        
        Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin(_page, _id);
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        int _saveError = 0;
        bool _save = false;
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();
        string _action = String.Empty;

        if (_save.Equals(false) && _signinYN.Equals("Y") && _cookieError.Equals(0) && _userError.Equals(0))
            _save = true;

        if (_save.Equals(true))
        {
            _saveResult = SCHDB.ActionSave(_c, _loginResult);
            _action     = _saveResult["Action"].ToString();
            _saveError  = int.Parse(_saveResult["SaveError"].ToString());            
            _complete   = _saveResult["Complete"].ToString();
            _incomplete = _saveResult["Incomplete"].ToString();
            _id         = _saveResult["Id"].ToString();
        }

        _saveResult.Clear();
        _saveResult.Add("CookieError",  _cookieError.ToString());
        _saveResult.Add("UserError",    _userError.ToString());
        _saveResult.Add("Action",       _action.ToString());
        _saveResult.Add("SaveError",    _saveError.ToString());
        _saveResult.Add("Complete",     _complete);
        _saveResult.Add("Incomplete",   _incomplete);
        _saveResult.Add("Id",           _id);
               
        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_saveResult));
    }
    
    private void ShowExport(HttpContext _c)
    {
        string _signinYN = _c.Request["signinYN"];
        string _page = _c.Request["page"];
        string _complete = String.Empty;
        string _incomplete = String.Empty;
        string _downloadFolder = String.Empty;
        string _downloadFile = String.Empty;        
        
        Dictionary<string, object> _loginResult = SCHUtil.GetInfoLogin(_page, "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        bool _export = false;     
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _exportResult = new Dictionary<string, object>();

        if (_export.Equals(false) && _signinYN.Equals("Y") && _cookieError.Equals(0) && _userError.Equals(0))
            _export = true;

        if (_export.Equals(true))
        {
            _exportResult   = SCHDB.ActionExport(_c, _loginResult);
            _complete       = _exportResult["Complete"].ToString();
            _incomplete     = _exportResult["Incomplete"].ToString();
            _downloadFolder = _exportResult["DownloadFolder"].ToString();
            _downloadFile   = _exportResult["DownloadFile"].ToString();

        }
        
        _exportResult.Clear();
        _exportResult.Add("CookieError",    _cookieError.ToString());
        _exportResult.Add("UserError",      _userError.ToString());
        _exportResult.Add("Complete",       _complete);
        _exportResult.Add("Incomplete",     _incomplete);
        _exportResult.Add("DownloadFolder", _downloadFolder);
        _exportResult.Add("DownloadFile",   _downloadFile);

        _json.MaxJsonLength = Int32.MaxValue;
        
        _c.Response.Write(_json.Serialize(_exportResult));
    }    
        
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}