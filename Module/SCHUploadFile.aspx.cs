using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel;

public partial class SCHUploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = Request.QueryString["action"];
        string _page = String.Empty;
        string _fileName = String.Empty;
        string _saveFile = String.Empty;
        string _username = String.Empty;
        int _cookieError = 0;
        int _userError = 0;
        int _error = 0;
        Dictionary<string, object> _loginResult = new Dictionary<string,object>();        
        Dictionary<string, object> _uploadFileResult = new Dictionary<string, object>();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        StringBuilder _mainContent = new StringBuilder();

        if (_action.Equals(SCHUtil.SUBJECT_IMPORTREGISTERSCHOLARSHIP))
        {
            _page               = SCHUtil.PAGE_IMPORTREGISTERSCHOLARSHIP_MAIN;
            _fileName           = (DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US"));
        }
            
        _loginResult    = SCHUtil.GetInfoLogin(_page, "");        
        _cookieError    = int.Parse(_loginResult["CookieError"].ToString());
        _userError      = int.Parse(_loginResult["UserError"].ToString());
        _username       = _loginResult["Username"].ToString();

        //try
        //{
            FileInfo _f = new FileInfo(Request.Files[0].FileName);

            _fileName = (_f.Name.Replace(_f.Extension, "") + _username.ToUpper() + _fileName);
            _saveFile = (Server.MapPath("~") + "/" + SCHUtil._myFileUploadPath + "/" + _fileName + _f.Extension.ToLower());

            Request.Files[0].SaveAs(_saveFile);

            if (_page.Equals(SCHUtil.PAGE_IMPORTREGISTERSCHOLARSHIP_MAIN))
            {
                DataSet _ds  = SCHUtil.GetExcelToDataSet(_saveFile);

                _error       = SCHUtil.ValidateDataExcel(_ds, SCHImportRegisterScholarshipUtil._excelFirstRow);
                _error       = (_error.Equals(1) ? 3 : _error);
                _error       = (_error.Equals(2) ? 4 : _error);                
                _mainContent = (_error.Equals(0) ? SCHImportRegisterScholarshipUI.ListUI.GetMain(_loginResult, _ds.Tables[0].Select()) : null);

                _ds.Dispose();
            }
        /*
        }
        catch
        {
            _error = 2;
        }
        */
        _uploadFileResult.Add("SignInYN",           "Y");
        _uploadFileResult.Add("CookieError",        _cookieError.ToString());
        _uploadFileResult.Add("UserError",          _userError.ToString());
        _uploadFileResult.Add("Username",           _username);
        _uploadFileResult.Add("UploadFileError",    _error.ToString());
        _uploadFileResult.Add("MainContent",        (_mainContent != null ? _mainContent.ToString() : String.Empty));        

        Response.Write(_json.Serialize(_uploadFileResult));           
    }
}