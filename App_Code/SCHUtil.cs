using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using NFinServiceLogin;
using Excel;

public class SCHUtil
{
    public const string SUBJECT_MEANINGOFSCHOLARSHIPPAYTYPE                                     = "MeaningOfScholarshipPayType";
    public const string SUBJECT_ICL                                                             = "ICL";
    public const string SUBJECT_STUDENTCV                                                       = "StudentCV";    
    public const string SUBJECT_SCHOLARSHIP                                                     = "Scholarship";
    public const string SUBJECT_REGISTERSCHOLARSHIP                                             = "RegisterScholarship";
    public const string SUBJECT_REGISTERSCHOLARSHIPTEMPLATE                                     = (SUBJECT_REGISTERSCHOLARSHIP + "Template");
    public const string SUBJECT_REGISTERSCHOLARSHIPSTUDENTCV                                    = (SUBJECT_REGISTERSCHOLARSHIP + SUBJECT_STUDENTCV);
    public const string SUBJECT_MANAGESCHOLARSHIP                                               = "ManageScholarship";
    public const string SUBJECT_MANAGESCHOLARSHIPSTUDENTCV                                      = (SUBJECT_MANAGESCHOLARSHIP + SUBJECT_STUDENTCV);
    public const string SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCEL                                  = (SUBJECT_MANAGESCHOLARSHIP + "StudentCancel");
    public const string SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCELSTUDENTCV                         = (SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCEL + SUBJECT_STUDENTCV);
    public const string SUBJECT_MANAGESCHOLARSHIPTYPEGROUPICL                                   = (SUBJECT_MANAGESCHOLARSHIP + "TypeGroup" + SUBJECT_ICL);    
    public const string SUBJECT_IMPORTREGISTERSCHOLARSHIP                                       = "ImportRegisterScholarship";
    public const string SUBJECT_IMPORTREGISTERSCHOLARSHIPSTUDENTCV                              = (SUBJECT_IMPORTREGISTERSCHOLARSHIP + SUBJECT_STUDENTCV);    
    public const string SUBJECT_FINANCESCHOLARSHIP                                              = "FinanceScholarship";
    public const string SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL                                  = (SUBJECT_FINANCESCHOLARSHIP + "TypeGroup" + SUBJECT_ICL);
    public const string SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE            = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL + "ApprovalReceiveFinance");
    public const string SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED                = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL + "SavePeopleApproved");    
    public const string SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE    = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL + "ClassificationRecipientFinance");
    public const string SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE                         = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL + "PayCheque");
    public const string SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE               = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL + "SavePeoplePayCheque");    
    public const string SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV                         = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL + SUBJECT_STUDENTCV);
    public const string SUBJECT_REPORTSCHOLARSHIP                                               = "ReportScholarship";
    public const string SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL                        = "ReportListOfPeopleApprovedFinanceFromICL";
    public const string SUBJECT_REPORTSCHOLARSHIPSTUDENTCV                                      = (SUBJECT_REPORTSCHOLARSHIP + SUBJECT_STUDENTCV);

    public const string PAGE_MEANINGOFSCHOLARSHIPPAYTYPE_MAIN                                       = (SUBJECT_MEANINGOFSCHOLARSHIPPAYTYPE + "Main");
    public const string PAGE_MAIN                                                                   = "Main";
    public const string PAGE_SCHOLARSHIP_MAIN                                                       = (SUBJECT_SCHOLARSHIP + "Main");
    public const string PAGE_SCHOLARSHIP_ADD                                                        = (SUBJECT_SCHOLARSHIP + "Add");
    public const string PAGE_SCHOLARSHIP_UPDATE                                                     = (SUBJECT_SCHOLARSHIP + "Update");
    public const string PAGE_REGISTERSCHOLARSHIP_MAIN                                               = (SUBJECT_REGISTERSCHOLARSHIP + "Main");
    public const string PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN                                      = (SUBJECT_REGISTERSCHOLARSHIPSTUDENTCV + "Main");
    public const string PAGE_REGISTERSCHOLARSHIP_ADDUPDATE                                          = (SUBJECT_REGISTERSCHOLARSHIP + "AddUpdate");
    public const string PAGE_MANAGESCHOLARSHIP_MAIN                                                 = (SUBJECT_MANAGESCHOLARSHIP + "Main");
    public const string PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN                                        = (SUBJECT_MANAGESCHOLARSHIPSTUDENTCV + "Main");
    public const string PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_MAIN                                    = (SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCEL + "Main");
    public const string PAGE_MANAGESCHOLARSHIP_ADDUPDATE                                            = (SUBJECT_MANAGESCHOLARSHIP + "AddUpdate");
    public const string PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_ADDUPDATE                               = (SUBJECT_MANAGESCHOLARSHIPSTUDENTCANCEL + "AddUpdate");
    public const string PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE                                = (SUBJECT_MANAGESCHOLARSHIPTYPEGROUPICL + "AddUpdate");
    public const string PAGE_IMPORTREGISTERSCHOLARSHIP_MAIN                                         = (SUBJECT_IMPORTREGISTERSCHOLARSHIP + "Main");
    public const string PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN                                = (SUBJECT_IMPORTREGISTERSCHOLARSHIPSTUDENTCV + "Main");
    public const string PAGE_IMPORTREGISTERSCHOLARSHIP_ADDUPDATE                                    = (SUBJECT_IMPORTREGISTERSCHOLARSHIP + "AddUpdate");    
    public const string PAGE_FINANCESCHOLARSHIP_MAIN                                                = (SUBJECT_FINANCESCHOLARSHIP + "Main");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICL_MAIN                                    = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL + "Main");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_MAIN              = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE + "Main");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_ADD               = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE + "Add");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE            = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE + "Update");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN                  = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED + "Main");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE             = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED + "AddUpdate");    
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_MAIN      = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE + "Main");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_ADDUPDATE = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE + "AddUpdate");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_MAIN                           = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE + "Main");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_ADD                            = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE + "Add");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE                         = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE + "Update");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN                 = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE + "Main");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE            = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE + "AddUpdate");
    public const string PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN                           = (SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV + "Main");
    public const string PAGE_REPORTSCHOLARSHIP_MAIN                                                 = (SUBJECT_REPORTSCHOLARSHIP + "Main");
    public const string PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_MAIN                          = (SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL + "Main");
    public const string PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT                        = (SUBJECT_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL + "Export");
    public const string PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN                                        = (SUBJECT_REPORTSCHOLARSHIPSTUDENTCV + "Main");

    public static CultureInfo th                = System.Globalization.CultureInfo.GetCultureInfo("th-TH");
    public static CultureInfo en                = System.Globalization.CultureInfo.GetCultureInfo("en-US");
    public static string _dayTH                 = DateTime.Now.ToString("dd", th);
    public static string _monthTH               = DateTime.Now.ToString("MM", th);
    public static string _monthNameTH           = DateTime.Now.ToString("MMMM", th);
    public static string _yearTH                = DateTime.Now.ToString("yyyy", th);
    public static string _yearEN                = DateTime.Now.ToString("yyyy", en);
    public static string _version               = "2.0";
    public static string _myURLPictureStudent   = System.Configuration.ConfigurationManager.AppSettings["urlPictureStudent"].ToString();
    public static string _myHandlerPath         = System.Configuration.ConfigurationManager.AppSettings["handlerPath"].ToString();
    public static string _myFileDownloadPath    = System.Configuration.ConfigurationManager.AppSettings["fileDownloadPath"].ToString();
    public static string _myFileUploadPath      = System.Configuration.ConfigurationManager.AppSettings["fileUploadPath"].ToString();    
    public static string _myRowPerPageDefault   = System.Configuration.ConfigurationManager.AppSettings["rowPerPageDefault"].ToString();

    public static string[] _selectOption = new string[]
    {
        "All",
        "Selected"
    };

    public static string[,] _semester = new string[,]
    {
        {"1", "ภาคต้น", "First Semester"},
        {"2", "ภาคปลาย", "Final Semester"},
        {"3", "ภาคฤดูร้อน", "Summer"}
    };

    public static string[,] _approveStatus = new string[,]
    {
        {"Y", "อนุมัติแล้ว", "Approved"},
        {"N", "รออนุมัติ", "Pending Approved"}
    };

    public static string[,] _recipientStatus = new string[,]
    {
        {"Y", "จำแนกผู้รับเงินแล้ว", "Recipient"},
        {"N", "รอจำแนกผู้รับเงิน", "Pending Recipient"}
    };

    public static string[,] _payChequeStatus = new string[,]
    {
        {"Y", "บันทึกจ่ายเช็คแล้ว", "Pay Cheque"},
        {"N", "รอบันทึกจ่ายเช็ค", "Pending Pay Cheque"}
    };

    public static string CurrentDate(string _format)
    {
        return (DateTime.Today.ToString(_format));
    }

    public static string GetFullName(string _titleName, string _titleNameOther, string _firstName, string _middleName, string _lastName)
    {
        _titleName  = (!String.IsNullOrEmpty(_titleName) ? _titleName : _titleNameOther);
        _middleName = (!String.IsNullOrEmpty(_middleName) ? (_middleName + " ") : String.Empty);

        return (_titleName + _firstName + " " + _middleName + _lastName);
    }

    public static object GetValueDataDictionary(Dictionary<string, object> _dataDict, string _containsKey, object _valueTrue, object _valueFalse)
    {
        object _valueResult;

        try
        {
            _valueResult = (_dataDict.ContainsKey(_containsKey).Equals(true) ? (!String.IsNullOrEmpty(_dataDict[_containsKey].ToString()) ? _valueTrue : _valueFalse) : _valueFalse);
        }
        catch
        {
            _valueResult = _valueFalse;
        }

        return _valueResult;
    }

    public static int ChkCookie(string _cookieName)
    {
        int _cookieError = 0;

        HttpCookie _cookieObj = GetCookie(_cookieName);

        if (_cookieObj == null)
            _cookieError = 1;

        return _cookieError;
    }

    public static void SetAddCookie(string _cookieName, StringBuilder _cookieValue)
    {
        string[] _cookieValueArray = _cookieValue.ToString().Split(',');
        int _i = 0;

        HttpCookie _cookieObj = new HttpCookie(_cookieName);

        for (_i = 0; _i < _cookieValueArray.GetLength(0); _i++)
        {
            string[] _cookieValueSubArray = _cookieValueArray[_i].Split(':');

            _cookieObj.Values.Add(_cookieValueSubArray[0], _cookieValueSubArray[1]);
        }

        HttpContext.Current.Response.Cookies.Add(_cookieObj);
    }

    public static HttpCookie GetCookie(string _cookieName)
    {
        HttpCookie _cookieObj = new HttpCookie(_cookieName);
        _cookieObj = HttpContext.Current.Request.Cookies[_cookieName];

        return _cookieObj;
    }

    public static string GetIP()
    {
        string _ip = String.Empty;

        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            _ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        else
            if (!String.IsNullOrWhiteSpace(HttpContext.Current.Request.UserHostAddress))
                _ip = HttpContext.Current.Request.UserHostAddress;

        if (_ip == "::1")
            _ip = "127.0.0.1";

        return _ip;
    }

    public static bool FileSiteExist(string _file)
    {
        bool _result = true;

        try
        {
            HttpWebRequest _request = (HttpWebRequest)HttpWebRequest.Create(new Uri(_file));
            _result = (_request.GetResponse().ContentLength > 0) ? true : false;
        }
        catch
        {
            _result = false;
        }

        return _result;
    }

    public static MemoryStream ImageToStream(string _fileSite, string _fileFormat)
    {
        MemoryStream _ms = new MemoryStream();

        try
        {
            HttpWebRequest _request = (HttpWebRequest)HttpWebRequest.Create(_fileSite);
            HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
            Image _sourceImage = Image.FromStream(_response.GetResponseStream());

            Bitmap _bmp = new Bitmap(_sourceImage);
            _bmp.Save(_ms, GetImageFormat(_fileFormat));
        }
        catch
        {
        }

        return _ms;
    }

    public static ImageFormat GetImageFormat(string _fileFormat)
    {
        switch (_fileFormat.ToLower())
        {
            case "jpg"      :
            case "jpeg"     :
            case ".jpg"     :
            case ".jpeg"    : return ImageFormat.Jpeg;
            case "gif"      :
            case ".gif"     : return ImageFormat.Gif;
            case "bmp"      :
            case ".bmp"     : return ImageFormat.Bmp;
            case "png"      :
            case ".png"     : return ImageFormat.Png;
            default         : return null;
        }
    }

    public static string GetHeaderContentType(string _fileExtension)
    {
        switch (_fileExtension)
        {
            case "txt"  :   return "text/plain";
            case "doc"  :   return "application/ms-word";
            case "xls"  :   
            case "xlsx" :   return "application/vnd.ms-excel";
            case "gif"  :   return "image/gif";
            case "jpg"  :
            case "jpeg" :   return "image/jpeg";
            case "bmp"  :   return "image/bmp";
            case "wav"  :   return "audio/wav";
            case "ppt"  :   return "application/mspowerpoint";
            case "dwg"  :   return "image/vnd.dwg";
            case "zip"  :   return "application/zip";
            case "pdf"  :   return "application/pdf";
            default     :   return "application/octet-stream";
        }
    }

    public static string EncodeToBase64(string _str)
    {
        try
        {
            string _strEncode = String.Empty;
            byte[] _encDataByte = new byte[_str.Length];

            _encDataByte = Encoding.UTF8.GetBytes(_str);
            _strEncode = Convert.ToBase64String(_encDataByte);

            return _strEncode;
        }
        catch
        {
            return String.Empty;
        }
    }

    public static string DecodeFromBase64(string _strEncode)
    {
        UTF8Encoding _encoder = new UTF8Encoding();
        Decoder _utf8Decode = _encoder.GetDecoder();
        byte[] _todecodeByte = Convert.FromBase64String(_strEncode);
        int _charCount = _utf8Decode.GetCharCount(_todecodeByte, 0, _todecodeByte.Length);
        char[] _decodedChar = new char[_charCount];
        string _strDecode = String.Empty;

        _utf8Decode.GetChars(_todecodeByte, 0, _todecodeByte.Length, _decodedChar, 0);
        _strDecode = new String(_decodedChar);

        return _strDecode;
    }

    public static bool FileExist(string _fileName)
    {
        return File.Exists(HttpContext.Current.Server.MapPath("~") + "/" + _fileName);
    }

    public static int ViewFile(string _filePath, string _fileName)
    {
        int _error = 0;
        bool _fileExist = FileExist(_filePath + "/" + _fileName);

        if (_fileExist.Equals(true))
        {
            try
            {
                if (!String.IsNullOrEmpty(_fileName))
                {
                    _error = 0;

                    string[] _viewFileArray = _fileName.Split('.');
                    string _fileExtension = _viewFileArray[_viewFileArray.GetLength(0) - 1];

                    FileStream _sourceFile = new FileStream((HttpContext.Current.Server.MapPath("~") + "/" + _filePath + "/" + _fileName), FileMode.Open);
                    float _fileSize = _sourceFile.Length;
                    byte[] _getContent = new byte[(int)_fileSize];
                    _sourceFile.Read(_getContent, 0, (int)_fileSize);
                    _sourceFile.Close();

                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.ContentType = GetHeaderContentType(_fileExtension.ToLower());
                    HttpContext.Current.Response.AddHeader("Content-Length", _getContent.Length.ToString());
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + _fileName);
                    HttpContext.Current.Response.BinaryWrite(_getContent);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
                else
                    _error = 1;
            }
            catch
            {
                _error = 2;
            }
        }
        else
            _error = 1;

        return _error;
    }

    public static int RemoveMultipleFiles(string _sourcePath, string _keyword)
    {
        int _error = 0;
        string[] _fileList;

        try
        {
            _sourcePath = HttpContext.Current.Server.MapPath(_sourcePath);
            _fileList = Directory.GetFiles(_sourcePath, _keyword);

            foreach (string _f in _fileList)
            {
                File.Delete(_f);
            }
        }
        catch
        {
            _error = 1;
        }

        return _error;
    }

    public static int[] CalNavPage(int _recordCount, int _currentPage, int _rowPerPage)
    {
        int _totalPage;
        int _diffPage;
        int[] _calNavPageResult = new int[2];

        if (_recordCount > 0)
        {
            _totalPage = 1;

            if (_recordCount > _rowPerPage)
            {
                _totalPage = (_recordCount / _rowPerPage);
                _totalPage = ((_recordCount % _rowPerPage).Equals(0) ? _totalPage : (_totalPage + 1));
            }

            if ((String.IsNullOrEmpty(_currentPage.ToString())) || (_currentPage.Equals(0)))
                _currentPage = 1;
            else
            {
                if (_currentPage < 1) _currentPage = 1;
                if (_currentPage > _totalPage) _currentPage = _totalPage;

                _diffPage = _currentPage - _totalPage;

                if (_diffPage.Equals(1))
                    _currentPage = _totalPage;
            }
        }
        else
        {
            _currentPage = 0;
            _totalPage = 0;
        }

        _calNavPageResult[0] = _currentPage;
        _calNavPageResult[1] = _totalPage;

        return _calNavPageResult;
    }

    public static StringBuilder GetPanelNavPage(int _recordCount, int[] _calNavPage, string _section, int _rowPerPage)
    {
        StringBuilder _str = new StringBuilder();
        string _callFunc = String.Empty;
        int _distance = 10;
        int _pageCenter;
        int _startPage = 0;
        int _endPage = 0;
        int _i;

        _str.AppendLine("<div class='navpage'>");
        _str.AppendLine("  <div class='panel'>");
        _str.AppendLine("      <div class='panel-body center aligned'>");
        _str.AppendLine("          <ul>");
        
        _callFunc = "Util.gotoNavPage({" +
                    "page:'" + _section + "'," +
                    "currentPage:1," +
                    "startRow:1," +
                    "endRow:"+ _rowPerPage +
                    "})";

        _str.AppendFormat("            <li><a class='font-th regular f10' href='javascript:void(0)' onclick={0}>&lt;&lt;</a></li>", _callFunc);

        _callFunc = "Util.gotoNavPage({" +
                    "page:'" + _section + "'," +
                    "currentPage:" + (_calNavPage[0] - 1) + "," +
                    "startRow:" + ((_calNavPage[0] - 1).Equals(0) ? 1 : ((((_calNavPage[0] - 1) * _rowPerPage) + 1) - _rowPerPage)) + "," +
                    "endRow:" + ((_calNavPage[0] - 1).Equals(0) ? _rowPerPage : ((_calNavPage[0] - 1) * _rowPerPage)) +
                    "})";

        _str.AppendFormat("            <li><a class='font-th regular f10' href='javascript:void(0)' onclick={0}>&lt;</a></li>", _callFunc);

        _pageCenter = (_distance / 2);
        _pageCenter = ((_distance % 2).Equals(0) ? _pageCenter : (_pageCenter + 1));

        if (_calNavPage[1] <= _distance)
        {
            _startPage = 1;
            _endPage = _calNavPage[1];
        }
        else
        {
            if (_calNavPage[0].Equals(1)) { _startPage = 1; _endPage = _distance; }
            if (_calNavPage[0].Equals(_calNavPage[1])) { _startPage = (_calNavPage[1] - (_distance - 1)); _endPage = _calNavPage[1]; }
            if (!_calNavPage[0].Equals(1) && !_calNavPage[0].Equals(_calNavPage[1]))
            {
                _startPage = (_calNavPage[0] - _pageCenter);
                _endPage = ((_startPage + _distance) - 1);

                if (_endPage > _calNavPage[1])
                {
                    _startPage = ((_calNavPage[1] - _distance) + 1);
                    _endPage = _calNavPage[1];
                }

                if (!(_endPage - _startPage).Equals(_distance) && !_endPage.Equals(_calNavPage[1]))
                {
                    _startPage = _startPage + 1;
                    if (_startPage <= 0) _startPage = 1;

                    _endPage = (_startPage + _distance) - 1;
                    if (_endPage > _calNavPage[1]) _endPage = _calNavPage[1];
                }
            }
        }

        for (_i = _startPage; _i <= _endPage; _i++)
        {
            if (_i.Equals(_calNavPage[0]))
                _str.AppendFormat("    <li class='active'><div class='font-th regular f10'>{0}</div></li>", _i.ToString("#,##0"));
            else
                {
                    _callFunc = "Util.gotoNavPage({" +
                                "page:'" + _section + "'," +
                                "currentPage:" + _i + "," +
                                "startRow:" + (((_i * _rowPerPage) + 1) - _rowPerPage) + "," +
                                "endRow:" + (_i * _rowPerPage) +
                                "})";

                    _str.AppendFormat("<li class='page-number'><a class='font-th regular f10' href='javascript:void(0)' onclick={0}>{1}</a></li>", _callFunc, _i.ToString("#,##0"));
                }
        }

        _callFunc = "Util.gotoNavPage({" +
                    "page:'" + _section + "'," +
                    "currentPage:" + (_calNavPage[0] + 1) + "," +
                    "startRow:" + ((_calNavPage[0] + 1) > _calNavPage[1] ? (((_calNavPage[1] * _rowPerPage) + 1) - _rowPerPage) : ((((_calNavPage[0] + 1) * _rowPerPage) + 1) - _rowPerPage)) + "," +
                    "endRow:" + ((_calNavPage[0] + 1) > _calNavPage[1] ? (_calNavPage[1] * _rowPerPage) : ((_calNavPage[0] + 1) * _rowPerPage)) +
                    "})";

        _str.AppendFormat("            <li><a class='font-th regular f10' href='javascript:void(0)' onclick={0}>&gt;</a></li>", _callFunc);

        _callFunc = "Util.gotoNavPage({" +
                    "page:'" + _section + "'," +
                    "currentPage:" + _calNavPage[1] + "," +
                    "startRow:" + (((_calNavPage[1] * _rowPerPage) + 1) - _rowPerPage) + "," +
                    "endRow:" + (_calNavPage[1] * _rowPerPage) +
                    "})";

        _str.AppendFormat("            <li><a class='font-th regular f10' href='javascript:void(0)' onclick={0}>&gt;&gt;</a></li>", _callFunc);
        _str.AppendFormat("            <li><div class='font-th regular f10'>of {0}</div></li>", _calNavPage[1].ToString("#,##0"));
        _str.AppendLine("          </ul>");
        _str.AppendLine("          <div class='clear'></div>");
        _str.AppendLine("      </div>");
        _str.AppendLine("  </div>");
        _str.AppendLine("</div>");

        return _str;
    }

    public static StringBuilder GetNavPage(int _recordCount, int _currentPage, string _page, int _rowPerPage)
    {
        StringBuilder _str = new StringBuilder();
        int _curPage = (!String.IsNullOrEmpty(_currentPage.ToString()) ? _currentPage : 0);
        int _recCount = (!String.IsNullOrEmpty(_recordCount.ToString()) ? _recordCount : 0);
        int[] _calNavPage = new int[2];

        if (_recCount > 0)
        {
            _calNavPage = CalNavPage(_recCount, _curPage, _rowPerPage);

            _str.AppendLine(GetPanelNavPage(_recCount, _calNavPage, _page, _rowPerPage).ToString());
        }

        return _str;
    }

    public static int ChkSystemPermissionStaff(Dictionary<string, object> _finServiceLogin)
    {
        int _cookieError = int.Parse(_finServiceLogin["CookieError"].ToString());
        int _systemError = 0;

        if (_cookieError.Equals(0))
        {
        }
        else
            _systemError = 1;

        return _systemError;
    }

    public static Dictionary<string, object> GetInfoLogin(string _page, string _id)
    {
        Dictionary<string, object> _finServiceLoginResult = FinServiceLogin.GetFinServiceLogin(FinServiceLogin.USERTYPE_STAFF, "MUScholarship");
        Dictionary<string, object> _loginResult = new Dictionary<string, object>();
        int _systemError = ChkSystemPermissionStaff(_finServiceLoginResult);
        int _cookieError = 0;
        int _userError = 0;
        int _studentError = 0;
        string _username = _finServiceLoginResult["Username"].ToString();
        string _fullnameEN = _finServiceLoginResult["FullnameEN"].ToString();
        string _fullnameTH = _finServiceLoginResult["FullnameTH"].ToString();
        string _department = _finServiceLoginResult["DepID"].ToString();
        string _userlevel = _finServiceLoginResult["Userlevel"].ToString();
        string _systemGroup = _finServiceLoginResult["SystemGroup"].ToString();
        string _faculty = _finServiceLoginResult["FacultyId"].ToString();
        string _program = _finServiceLoginResult["ProgramId"].ToString();        

        if (_systemError.Equals(0)) _systemError = (ChkUserPermission(_finServiceLoginResult, _page).Equals(true) ? 0 : 2);
        if (_systemError.Equals(0))
        {
            if (_page.Equals(PAGE_SCHOLARSHIP_UPDATE))                  _systemError = (!String.IsNullOrEmpty(_id) ? (SCHDB.GetScholarships(_id, "").Tables[0].Rows.Count > 0 ? 0 : 4) : 4);
            if (_page.Equals(PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN))   _systemError = (!String.IsNullOrEmpty(_id) ? (SCHDB.GetStudent(_username, _userlevel, _systemGroup, _id).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);
            if (_page.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN) ||
                _page.Equals(PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN) ||
                _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN) ||
                _page.Equals(PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN))
            {
                string[] _valueArray = _id.Split('|');

                _systemError = (!String.IsNullOrEmpty(_valueArray[0]) ? (SCHDB.GetStudent(_username, _userlevel, _systemGroup, _valueArray[0]).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);
            }
            if (_page.Equals(PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE))
            {
                string[] _valueArray = _id.Split('|');

                _systemError = (_valueArray.GetLength(0).Equals(4) ? (SCHDB.GetTranStudent(_valueArray[0], _valueArray[1], _valueArray[2], _valueArray[3]).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);
            }
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE) ||
                _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN))
            {
                string[] _valueArray = _id.Split('|');

                _systemError = (_valueArray.GetLength(0).Equals(4) ? (SCHDB.GetApprovalReceiveFinance(_valueArray[0], _valueArray[1], _valueArray[2], _valueArray[3]).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);
            }
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE) ||
                _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN))
            {
                string[] _valueArray = _id.Split('|');

                _systemError = (_valueArray.GetLength(0).Equals(5) ? (SCHDB.GetCheque(_valueArray[0], _valueArray[1], _valueArray[2], _valueArray[3], _valueArray[4]).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);
            }
        }

        switch (_systemError)
        {
            case 1  : { _cookieError    = 1; break; }
            case 2  : { _userError      = 1; break; }
            case 3  : { _studentError   = 1; break; }
            case 4  : { _userError      = 2; break; }

        }

        _loginResult.Add("CookieError",     _cookieError.ToString());
        _loginResult.Add("UserError",       _userError.ToString());
        _loginResult.Add("StudentError",    _studentError.ToString());
        _loginResult.Add("Username",        _username);
        _loginResult.Add("FullNameEN",      _fullnameEN);
        _loginResult.Add("FullNameTH",      _fullnameTH);
        _loginResult.Add("Department",      _department);
        _loginResult.Add("Userlevel",       _userlevel);
        _loginResult.Add("SystemGroup",     _systemGroup);
        _loginResult.Add("Userfaculty",     _faculty);
        _loginResult.Add("Userprogram",     _program);

        return _loginResult;
    }
    
    public static bool ChkUserPermission(Dictionary<string, object> _finServiceLogin, string _page)
    {
        string _userlevel = _finServiceLogin["Userlevel"].ToString();
        string _userfaculty = (!String.IsNullOrEmpty(_finServiceLogin["FacultyId"].ToString()) ? _finServiceLogin["FacultyId"].ToString().Substring(0, 2) : "");        
        bool _access = false;

        switch (_page)
        {
            case PAGE_MEANINGOFSCHOLARSHIPPAYTYPE_MAIN                                          : { _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false); break; }
            case PAGE_MAIN                                                                      : { _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false); break; }
            case PAGE_SCHOLARSHIP_MAIN                                                          : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_SCHOLARSHIP_ADD                                                           : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_SCHOLARSHIP_UPDATE                                                        : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_REGISTERSCHOLARSHIP_MAIN                                                  : { _access = (((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU")) || (_userlevel.Equals(FinServiceLogin.USERLEVEL_USER) && !_userfaculty.Equals("MU"))  ? true : false); break; }
            case PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN                                         : { _access = (((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU")) || (_userlevel.Equals(FinServiceLogin.USERLEVEL_USER) && !_userfaculty.Equals("MU"))  ? true : false); break; }
            case PAGE_REGISTERSCHOLARSHIP_ADDUPDATE                                             : { _access = (((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU")) || (_userlevel.Equals(FinServiceLogin.USERLEVEL_USER) && !_userfaculty.Equals("MU"))  ? true : false); break; }
            case PAGE_MANAGESCHOLARSHIP_MAIN                                                    : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN                                           : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_MANAGESCHOLARSHIP_ADDUPDATE                                               : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_ADDUPDATE                                  : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE                                   : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_IMPORTREGISTERSCHOLARSHIP_MAIN                                            : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN                                   : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_IMPORTREGISTERSCHOLARSHIP_ADDUPDATE                                       : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICL_MAIN                                       : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_MAIN                 : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_ADD                  : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE               : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN                     : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE                : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN                              : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_MAIN         : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_ADDUPDATE    : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_MAIN                              : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_ADD                               : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE                            : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN                    : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE               : { _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU") ? true : false); break; }
            case PAGE_REPORTSCHOLARSHIP_MAIN                                                    : { _access = (((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU")) ? true : false); break; }
            case PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_MAIN                             : { _access = (((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU")) ? true : false); break; }
            case PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT                           : { _access = (((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU")) ? true : false); break; }
            case PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN                                           : { _access = (((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _userfaculty.Equals("MU")) ? true : false); break; }
        }

        return _access;
    } 

    public static Dictionary<string, object> GetPage(string _page, string _id)
    {        
        Dictionary<string, object> _loginResult = GetInfoLogin(_page, _id);
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();        
        int _pageError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        string _signinYN = String.Empty;
        string _userlevel = _loginResult["Userlevel"].ToString();
        string _userfaculty = _loginResult["Userfaculty"].ToString();
        string _menuActiveContent = String.Empty;
        StringBuilder _mainContent = new StringBuilder();

        _pageError = 1;
        _mainContent = null;

        if (_page.Equals(PAGE_MAIN))
        {
            _pageError          = 0;
            _signinYN           = "Y";
        }

        if (_page.Equals(PAGE_SCHOLARSHIP_MAIN))
        {
            _pageError          = 0;
            _signinYN           = "Y";
            _menuActiveContent  = SUBJECT_SCHOLARSHIP.ToLower();
            _mainContent        = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHScholarshipUI.MainUI.GetMain() : null);
        }

        if (_page.Equals(PAGE_REGISTERSCHOLARSHIP_MAIN))
        {
            _pageError          = 0;
            _signinYN           = "Y";
            _menuActiveContent  = SUBJECT_REGISTERSCHOLARSHIP.ToLower();
            _mainContent        = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHRegisterScholarshipUI.MainUI.GetMain() : null);
        }

        if (_page.Equals(PAGE_MANAGESCHOLARSHIP_MAIN))
        {
            _pageError          = 0;
            _signinYN           = "Y";
            _menuActiveContent  = SUBJECT_MANAGESCHOLARSHIP.ToLower();
            _mainContent        = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHManageScholarshipUI.MainUI.GetMain() : null);
        }

        if (_page.Equals(PAGE_IMPORTREGISTERSCHOLARSHIP_MAIN))
        {
            _pageError          = 0;
            _signinYN           = "Y";
            _menuActiveContent  = SUBJECT_IMPORTREGISTERSCHOLARSHIP.ToLower();
            _mainContent        = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHImportRegisterScholarshipUI.MainUI.GetMain() : null);
        }

        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICL_MAIN))
        {
            _pageError          = 0;
            _signinYN           = "Y";
            _menuActiveContent  = SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICL.ToLower();
            _mainContent        = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.MainUI.GetMain() : null);
        }

        if (_page.Equals(PAGE_REPORTSCHOLARSHIP_MAIN))
        {
            _pageError          = 0;
            _signinYN           = "Y";
            _menuActiveContent  = SUBJECT_REPORTSCHOLARSHIP.ToLower();
            _mainContent        = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHReportScholarshipUI.MainUI.GetMain() : null);
        }

        _pageResult.Add("Page",                 _page);
        _pageResult.Add("PageError",            _pageError.ToString());
        _pageResult.Add("SignInYN",             _signinYN);
        _pageResult.Add("CookieError",          _cookieError.ToString());
        _pageResult.Add("UserError",            _userError.ToString());
        _pageResult.Add("Userlevel",            _userlevel.ToString());
        _pageResult.Add("Userfaculty",          _userfaculty.ToString());
        _pageResult.Add("MenuActiveContent",    _menuActiveContent);
        _pageResult.Add("MainContent",          (_mainContent != null ? _mainContent.ToString() : String.Empty));
        
        return _pageResult;
    }

    public static Dictionary<string, object> GetForm(string _form, string _id)
    {
        Dictionary<string, object> _loginResult = GetInfoLogin(_form, _id);
        Dictionary<string, object> _formResult = new Dictionary<string, object>();
        int _formError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        int _width = 0;
        int _height = 0;
        string _signinYN = String.Empty;
        string _titleTHContent = String.Empty;
        string _titleENContent = String.Empty;
        StringBuilder _mainContent = new StringBuilder();

        _formError = 1;
        _mainContent = null;

        if (_form.Equals(PAGE_MEANINGOFSCHOLARSHIPPAYTYPE_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHUI.GetFrmNotice(_form) : null);
            _titleTHContent = "ความหมายของประเภทของการจ่ายเงินทุน";
            _titleENContent = "Meaning of Scholarship Pay Type";
        }        
        
        if (_form.Equals(PAGE_SCHOLARSHIP_ADD))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHScholarshipUI.AddUpdateUI.GetMain(_form, _id) : null);
        }

        if (_form.Equals(PAGE_SCHOLARSHIP_UPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHScholarshipUI.AddUpdateUI.GetMain(_form, _id) : null);
        }

        if (_form.Equals(PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHRegisterScholarshipUI.StudentCVUI.GetMain(_id) : null);
        }
        
        if (_form.Equals(PAGE_REGISTERSCHOLARSHIP_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกสมัครรับทุน";
            _titleENContent = "Save Register Scholarship Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHRegisterScholarshipUI.AddUpdateUI.GetMain() : null);
        }
        
        if (_form.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHManageScholarshipUI.StudentCVUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_MANAGESCHOLARSHIP_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกจัดการทุน";
            _titleENContent = "Save Manage Scholarship Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHManageScholarshipUI.AddUpdateUI.GetMain(_form) : null);
        }

        if (_form.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกยกเลิกทุน";
            _titleENContent = "Save Student Cancel Scholarship Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHManageScholarshipUI.AddUpdateUI.GetMain(_form) : null);
        }

        if (_form.Equals(PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกจัดการทุนกรอ.";
            _titleENContent = "Save Manage ICL Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHManageScholarshipUI.ICLUI.AddUpdateUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHImportRegisterScholarshipUI.StudentCVUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_IMPORTREGISTERSCHOLARSHIP_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกสมัครรับทุน";
            _titleENContent = "Save Register Scholarship Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHImportRegisterScholarshipUI.AddUpdateUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_ADD))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.ApprovalReceiveFinanceUI.AddUpdateUI.GetMain(_form, _id) : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.ApprovalReceiveFinanceUI.AddUpdateUI.GetMain(_form, _id) : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.SavePeopleApprovedUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกผู้ที่ได้รับอนุมัติ";
            _titleENContent = "Save People Approved Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.SavePeopleApprovedUI.AddUpdateUI.GetMain(_id) : null);
        }
        
        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.StudentCVUI.GetMain(_id) : null);
        }
        
        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.ClassificationRecipientFinanceUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกจำแนกผู้รับเงิน";
            _titleENContent = "Save Classification Recipient Finance Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.ClassificationRecipientFinanceUI.AddUpdateUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.PayChequeUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_ADD))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.PayChequeUI.AddUpdateUI.GetMain(_form, _id) : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.PayChequeUI.AddUpdateUI.GetMain(_form, _id) : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.SavePeoplePayChequeUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "บันทึกจ่ายเช็ค";
            _titleENContent = "Save People Pay Cheque Selection";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.SavePeoplePayChequeUI.AddUpdateUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHReportScholarshipUI.ListOfPeopleApprovedFinanceFromICLUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHFinanceScholarshipUI.ICLUI.StudentCVUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT))
        {
            _formError      = 0;
            _signinYN       = "Y";
            _titleTHContent = "ส่งออกรายชื่อผู้ที่ได้รับอนุมัติเงินจาก กรอ.";
            _titleENContent = "Export List of People Approved Finance From ICL";
            _mainContent    = (_cookieError.Equals(0) && _userError.Equals(0) ? SCHReportScholarshipUI.ListOfPeopleApprovedFinanceFromICLUI.ExportUI.GetMain() : null);
        }

        _formResult.Add("FormError",        _formError.ToString());
        _formResult.Add("SignInYN",         _signinYN);
        _formResult.Add("CookieError",      _cookieError.ToString());
        _formResult.Add("UserError",        _userError.ToString());
        _formResult.Add("Width",            _width.ToString());
        _formResult.Add("Height",           _height.ToString());
        _formResult.Add("TitleTHContent",   _titleTHContent);
        _formResult.Add("TitleENContent",   _titleENContent);
        _formResult.Add("MainContent",      (_mainContent != null ? _mainContent.ToString() : String.Empty));        

        return _formResult;
    }

    public static Dictionary<string, object> GetSearch(string _page, HttpContext _c)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        Dictionary<string, object> _searchResult = new Dictionary<string, object>();

        _paramSearch = SetParameterSearch(_page, _c);

        if (_page.Equals(PAGE_SCHOLARSHIP_MAIN))                                                    _searchResult = SCHScholarshipUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_REGISTERSCHOLARSHIP_MAIN))                                            _searchResult = SCHRegisterScholarshipUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_MANAGESCHOLARSHIP_MAIN))                                              _searchResult = SCHManageScholarshipUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCANCEL_MAIN))                                 _searchResult = SCHManageScholarshipUtil.StudentCancelUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_MAIN))           _searchResult = SCHFinanceScholarshipUtil.ICLUtil.ApprovalReceiveFinanceUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN))               _searchResult = SCHFinanceScholarshipUtil.ICLUtil.SavePeopleApprovedUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLCLASSIFICATIONRECIPIENTFINANCE_MAIN))   _searchResult = SCHFinanceScholarshipUtil.ICLUtil.ClassificationRecipientFinanceUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_MAIN))                        _searchResult = SCHFinanceScholarshipUtil.ICLUtil.PayChequeUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN))              _searchResult = SCHFinanceScholarshipUtil.ICLUtil.SavePeoplePayChequeUtil.GetSearch(_paramSearch);
        if (_page.Equals(PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_MAIN))                       _searchResult = SCHReportScholarshipUtil.ListOfPeopleApprovedFinanceFromICLUtil.GetSearch(_paramSearch);

        return _searchResult;
    }

    public static Dictionary<string, object> SetParameterSearch(string _page, HttpContext _c)
    {
        Dictionary<string, object> _paramResult = new Dictionary<string, object>();
        string _keyword = String.Empty;
        string _subKeyword = String.Empty;
        string _scholarshipsTypeId = String.Empty;
        string _facultyId = String.Empty;
        string _programId = String.Empty;
        string _yearEntry = String.Empty;
        string _scholarshipsYear = String.Empty;
        string _semester = String.Empty;
        string _scholarshipsId = String.Empty;
        string _scholarshipsTypeGroup = String.Empty;
        string _lotNo = String.Empty;
        string _groupReceiver = String.Empty;
        string _bankId = String.Empty;
        string _approveStatus = String.Empty;
        string _recipientStatus = String.Empty;
        string _payChequeYear = String.Empty;
        string _pvjvNo = String.Empty;
        string _chequeNo = String.Empty;
        string _payChequeStatus = String.Empty;
        string _cancelStatus = String.Empty;
        int _currentPage = 1;
        int _startRow = 1;
        int _endRow = 1;
        int _rowPerPage = int.Parse(_myRowPerPageDefault);

        if (_c != null)
        {            
            _keyword                = (!String.IsNullOrEmpty(_c.Request["keyword"]) ? _c.Request["keyword"] : _keyword);
            _subKeyword             = (!String.IsNullOrEmpty(_c.Request["subKeyword"]) ? _c.Request["subKeyword"] : _subKeyword);
            _scholarshipsTypeId     = (!String.IsNullOrEmpty(_c.Request["scholarshipsTypeId"]) ? _c.Request["scholarshipsTypeId"] : _scholarshipsTypeId);
            _facultyId              = (!String.IsNullOrEmpty(_c.Request["facultyId"]) ? _c.Request["facultyId"] : _facultyId);
            _programId              = (!String.IsNullOrEmpty(_c.Request["programId"]) ? _c.Request["programId"] : _programId);
            _yearEntry              = (!String.IsNullOrEmpty(_c.Request["yearEntry"]) ? _c.Request["yearEntry"] : _yearEntry);
            _scholarshipsYear       = (!String.IsNullOrEmpty(_c.Request["scholarshipsYear"]) ? _c.Request["scholarshipsYear"] : _scholarshipsYear);
            _semester               = (!String.IsNullOrEmpty(_c.Request["semester"]) ? _c.Request["semester"] : _semester);
            _scholarshipsId         = (!String.IsNullOrEmpty(_c.Request["scholarshipsId"]) ? _c.Request["scholarshipsId"] : _scholarshipsId);
            _scholarshipsTypeGroup  = (!String.IsNullOrEmpty(_c.Request["scholarshipsTypeGroup"]) ? _c.Request["scholarshipsTypeGroup"] : _scholarshipsTypeGroup);
            _lotNo                  = (!String.IsNullOrEmpty(_c.Request["lotNo"]) ? _c.Request["lotNo"] : _lotNo);
            _groupReceiver          = (!String.IsNullOrEmpty(_c.Request["groupReceiver"]) ? _c.Request["groupReceiver"] : _groupReceiver);
            _bankId                 = (!String.IsNullOrEmpty(_c.Request["bankId"]) ? _c.Request["bankId"] : _bankId);
            _approveStatus          = (!String.IsNullOrEmpty(_c.Request["approveStatus"]) ? _c.Request["approveStatus"] : _approveStatus);
            _recipientStatus        = (!String.IsNullOrEmpty(_c.Request["recipientStatus"]) ? _c.Request["recipientStatus"] : _recipientStatus);
            _payChequeYear          = (!String.IsNullOrEmpty(_c.Request["payChequeYear"]) ? _c.Request["payChequeYear"] : _payChequeYear);
            _pvjvNo                 = (!String.IsNullOrEmpty(_c.Request["pvjvNo"]) ? _c.Request["pvjvNo"] : _pvjvNo);
            _chequeNo               = (!String.IsNullOrEmpty(_c.Request["chequeNo"]) ? _c.Request["chequeNo"] : _chequeNo);
            _payChequeStatus        = (!String.IsNullOrEmpty(_c.Request["payChequeStatus"]) ? _c.Request["payChequeStatus"] : _payChequeStatus);
            _cancelStatus           = (!String.IsNullOrEmpty(_c.Request["cancelStatus"]) ? _c.Request["cancelStatus"] : _cancelStatus);
            _currentPage            = (!String.IsNullOrEmpty(_c.Request["currentPage"]) ? int.Parse(_c.Request["currentPage"]) : _currentPage);
            _startRow               = (!String.IsNullOrEmpty(_c.Request["startRow"]) ? int.Parse(_c.Request["startRow"]) : _startRow);
            _endRow                 = (!String.IsNullOrEmpty(_c.Request["endRow"]) ? int.Parse(_c.Request["endRow"]) : (!String.IsNullOrEmpty(_c.Request["rowPerPage"]) ? int.Parse(_c.Request["rowPerPage"]) : _rowPerPage));
            _rowPerPage             = (!String.IsNullOrEmpty(_c.Request["rowPerPage"]) ? int.Parse(_c.Request["rowPerPage"]) : _rowPerPage);            
        }

        _paramResult.Add("Keyword",                 _keyword);
        _paramResult.Add("SubKeyword",              _subKeyword);
        _paramResult.Add("ScholarshipsTypeId",      _scholarshipsTypeId);
        _paramResult.Add("FacultyId",               _facultyId);
        _paramResult.Add("ProgramId",               _programId);
        _paramResult.Add("YearEntry",               _yearEntry);
        _paramResult.Add("ScholarshipsYear",        _scholarshipsYear);
        _paramResult.Add("Semester",                _semester);
        _paramResult.Add("ScholarshipsId",          _scholarshipsId);
        _paramResult.Add("ScholarshipsTypeGroup",   _scholarshipsTypeGroup);
        _paramResult.Add("LotNo",                   _lotNo);
        _paramResult.Add("GroupReceiver",           _groupReceiver);
        _paramResult.Add("BankId",                  _bankId);
        _paramResult.Add("ApproveStatus",           _approveStatus);
        _paramResult.Add("RecipientStatus",         _recipientStatus);
        _paramResult.Add("PayChequeYear",           _payChequeYear);
        _paramResult.Add("PVJVNo",                  _pvjvNo);
        _paramResult.Add("ChequeNo",                _chequeNo);
        _paramResult.Add("PayChequeStatus",         _payChequeStatus);
        _paramResult.Add("CancelStatus",            _cancelStatus);
        _paramResult.Add("CurrentPage",             _currentPage);
        _paramResult.Add("StartRow",                _startRow);
        _paramResult.Add("EndRow",                  _endRow);
        _paramResult.Add("RowPerPage",              _rowPerPage);

        return _paramResult;
    }

    public static Dictionary<string, object> SetValueDataRecorded(string _page, string _id, Dictionary<string, object> _paramSearch)
    {
        Dictionary<string, object> _valueDataRecordedResult = new Dictionary<string, object>();
        Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
        DataSet _ds1 = new DataSet();
        DataSet _ds2 = new DataSet();
        DataSet _ds3 = new DataSet();

        if (_page.Equals(PAGE_SCHOLARSHIP_UPDATE))                      _ds1 = SCHDB.GetScholarships(_id, "");
        if (_page.Equals(PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN))       _ds1 = SCHDB.GetStudent(_id);
        if (_page.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN) ||
            _page.Equals(PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE) ||
            _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN) ||
            _page.Equals(PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN))
        {
            _ds1 = SCHDB.GetStudent(_paramSearch["PersonId"].ToString());
            _ds2 = SCHDB.GetTranStudent(
                        _paramSearch["PersonId"].ToString(),
                        _paramSearch["ScholarshipsYear"].ToString(),
                        _paramSearch["Semester"].ToString(),
                        _paramSearch["ScholarshipsId"].ToString()
                   );
        }
        if (_page.Equals(PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN)) _ds1 = SCHDB.GetStudent(_paramSearch["PersonId"].ToString());
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE) ||
            _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN) ||
            _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE))
        {
            _ds1 = SCHDB.GetApprovalReceiveFinance(
                        _paramSearch["ScholarshipsTypeGroup"].ToString(),
                        _paramSearch["ScholarshipsYear"].ToString(),
                        _paramSearch["Semester"].ToString(),
                        _paramSearch["LotNo"].ToString()
                   );
        }
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE) ||
            _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN) ||
            _page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE))
        {
            _ds1 = SCHDB.GetCheque(
                        _paramSearch["PayChequeYear"].ToString(),
                        _paramSearch["Semester"].ToString(),
                        _paramSearch["LotNo"].ToString(),
                        _paramSearch["PVJVNo"].ToString(),
                        _paramSearch["ChequeNo"].ToString()
                   );
        }

        if (_ds1.Tables.Count > 0)
        {
            if (_page.Equals(PAGE_SCHOLARSHIP_UPDATE))                                          _dataRecorded = SCHScholarshipUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN))                           _dataRecorded = SCHStudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN))                             _dataRecorded = SCHStudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE))                     _dataRecorded = SCHStudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN))                     _dataRecorded = SCHStudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE)) _dataRecorded = SCHFinanceScholarshipUtil.ICLUtil.ApprovalReceiveFinanceUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN))       _dataRecorded = SCHFinanceScholarshipUtil.ICLUtil.ApprovalReceiveFinanceUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE))  _dataRecorded = SCHFinanceScholarshipUtil.ICLUtil.ApprovalReceiveFinanceUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN))                _dataRecorded = SCHStudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE))              _dataRecorded = SCHFinanceScholarshipUtil.ICLUtil.PayChequeUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN))      _dataRecorded = SCHFinanceScholarshipUtil.ICLUtil.PayChequeUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE)) _dataRecorded = SCHFinanceScholarshipUtil.ICLUtil.PayChequeUtil.SetValueDataRecorded(_dataRecorded, _ds1);
            if (_page.Equals(PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN))                             _dataRecorded = SCHStudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds1);
        }
        if (_ds2.Tables.Count > 0)
        {
            if (_page.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN))                 _dataRecorded = SCHManageScholarshipUtil.SetValueDataRecorded(_dataRecorded, _ds2);
            if (_page.Equals(PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE))         _dataRecorded = SCHManageScholarshipUtil.SetValueDataRecorded(_dataRecorded, _ds2);
            if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN))    _dataRecorded = SCHFinanceScholarshipUtil.ICLUtil.StudentCVUtil.SetValueDataRecorded(_dataRecorded, _ds2);
            if (_page.Equals(PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN))                 _dataRecorded = SCHReportScholarshipUtil.StudentCVUtil.SetValueDataRecorded(_dataRecorded, _ds2);
        }

        _ds3.Dispose();
        _ds2.Dispose();
        _ds1.Dispose();

        if (_page.Equals(PAGE_SCHOLARSHIP_ADD))                                             _valueDataRecordedResult = null;
        if (_page.Equals(PAGE_SCHOLARSHIP_UPDATE))                                          _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SCHOLARSHIP), _dataRecorded);
        if (_page.Equals(PAGE_REGISTERSCHOLARSHIPSTUDENTCV_MAIN))                           _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_REGISTERSCHOLARSHIPSTUDENTCV), _dataRecorded);
        if (_page.Equals(PAGE_MANAGESCHOLARSHIPSTUDENTCV_MAIN))                             _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_MANAGESCHOLARSHIPSTUDENTCV), _dataRecorded);
        if (_page.Equals(PAGE_MANAGESCHOLARSHIPTYPEGROUPICL_ADDUPDATE))                     _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_MANAGESCHOLARSHIPTYPEGROUPICL), _dataRecorded);
        if (_page.Equals(PAGE_IMPORTREGISTERSCHOLARSHIPSTUDENTCV_MAIN))                     _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_IMPORTREGISTERSCHOLARSHIPSTUDENTCV), _dataRecorded);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_ADD))    _valueDataRecordedResult = null;
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE_UPDATE)) _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLAPPROVALRECEIVEFINANCE), _dataRecorded);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_MAIN))       _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED), _dataRecorded);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED_ADDUPDATE))  _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEAPPROVED), _dataRecorded);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV_MAIN))                _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSTUDENTCV), _dataRecorded);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_ADD))                 _valueDataRecordedResult = null;
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE_UPDATE))              _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLPAYCHEQUE), _dataRecorded);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_MAIN))      _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE), _dataRecorded);
        if (_page.Equals(PAGE_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE_ADDUPDATE)) _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_FINANCESCHOLARSHIPTYPEGROUPICLSAVEPEOPLEPAYCHEQUE), _dataRecorded);
        if (_page.Equals(PAGE_REPORTSCHOLARSHIPSTUDENTCV_MAIN))                             _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_REPORTSCHOLARSHIPSTUDENTCV), _dataRecorded);

        return _valueDataRecordedResult;               
    }

    public static DataSet GetExcelToDataSet(string _filePath)
    {
        FileStream _stream = File.Open(_filePath, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader;

        if (Path.GetExtension(_filePath).ToUpper() == ".XLS")
            excelReader = ExcelReaderFactory.CreateBinaryReader(_stream);
        else
            excelReader = ExcelReaderFactory.CreateOpenXmlReader(_stream);

        DataSet _ds = excelReader.AsDataSet();

        excelReader.IsFirstRowAsColumnNames = false;

        excelReader.Close();        

        return _ds;
    }

    public static int ValidateDataExcel(DataSet _ds, string[] _excelFirstRow)
    {
        int _error = 0;
        int _i = 0;

        if (_ds.Tables[0].Rows.Count >= 2)
        {
            if (_ds.Tables[0].Columns.Count.Equals(_excelFirstRow.GetLength(0)))
            {
                DataRow _dr = _ds.Tables[0].Rows[0];

                while (_i < _excelFirstRow.GetLength(0) && _error.Equals(0))
                {
                    if (!_dr[_i].Equals(_excelFirstRow[_i]))
                        _error = 2;

                    _i++;
                }
            }
            else
                _error = 2;
        }
        else
            _error = 1;
        
        return _error;
    }

    public static int FindIndexArray2D(int _dimension, Array _array, string _value)
    {
        int _indexArray = 0;

        for (int _i = 0; _i < _array.GetLength(0); _i++)
        {
            if (_array.GetValue(_i, _dimension).Equals(_value))
            {
                _indexArray = _i + 1;
                break;
            }
        }

        return _indexArray;
    }

    public static int FindIndexArray3D(int _dimension, Array _array, string _value)
    {
        int _indexArray = 0;

        if (_array.GetLength(1) == 0)
        {
            for (int _i = 0; _i < _array.GetLength(0); _i++)
            {
                if (_array.GetValue(_i, 0, _dimension).Equals(_value))
                {
                    _indexArray = _i + 1;
                    break;
                }
            }
        }

        if (_array.GetLength(1) > 0)
        {
            for (int _i = 0; _i < _array.GetLength(0); _i++)
            {
                for (int _j = 0; _j < _array.GetLength(1); _j++)
                {
                    if (_array.GetValue(_i, _j, _dimension).Equals(_value))
                    {
                        _indexArray = _j + 1;
                        break;
                    }
                }
            }
        }

        return _indexArray;
    }

    public static Dictionary<string, object> GetTranStudent(string _personId, string _acaYear, string _semester, string _scholarshipsId)
    {
        Dictionary<string, object> _getResult = new Dictionary<string, object>();
        DataSet _ds = SCHDB.GetTranStudent(_personId, _acaYear, _semester, _scholarshipsId);
        DataRow _dr = null;
        string _scholarshipsYear = String.Empty;
        string _invoiceNo = String.Empty;
        string _totalCredit = String.Empty;
        string _ratePerYear = String.Empty;
        string _ratePerYearRemain = String.Empty;
        string _registerDate = String.Empty;
        string _contractDate = String.Empty;

        _personId       = "";
        _semester       = "";
        _scholarshipsId = "";

        if (_ds.Tables[0].Rows.Count > 0)
        {
            _dr = _ds.Tables[0].Rows[0];

            _personId           = _dr["id"].ToString();
            _scholarshipsYear   = _dr["scholarshipsYear"].ToString();
            _semester           = _dr["semester"].ToString();
            _scholarshipsId     = _dr["schScholarshipsId"].ToString();
            _invoiceNo          = _dr["invoiceNo"].ToString();
            _totalCredit        = _dr["totalCredit"].ToString();
            _ratePerYear        = _dr["ratePerYear"].ToString();
            _ratePerYearRemain  = _dr["ratePerYearRemain"].ToString();
            _registerDate       = _dr["registerDate"].ToString();
            _contractDate       = _dr["contractDate"].ToString();
        }

        _ds.Dispose();

        _getResult.Clear();
        _getResult.Add("PersonId",          _personId);
        _getResult.Add("ScholarshipsYear",  _scholarshipsYear);
        _getResult.Add("Semester",          _semester);
        _getResult.Add("ScholarshipsId",    _scholarshipsId);
        _getResult.Add("InvoiceNo",         _invoiceNo);
        _getResult.Add("TotalCredit",       _totalCredit);
        _getResult.Add("RatePerYear",       _ratePerYear);
        _getResult.Add("RatePerYearRemain", _ratePerYearRemain);
        _getResult.Add("RegisterDate",      _registerDate);
        _getResult.Add("ContractDate",      _contractDate);

        return _getResult;
    }

    public static Dictionary<string, object> GetMaxLotApprovalReceiveFinance(string _scholarshipsTypeGroup, string _scholarshipsYear, string _semester)
    {
        Dictionary<string, object> _getResult = new Dictionary<string, object>();
        Dictionary<string, object> _paramSearch = new Dictionary<string,object>();
        string _maxLotNo = String.Empty;

        _paramSearch.Clear();
        _paramSearch.Add("ScholarshipsTypeGroup",   _scholarshipsTypeGroup);
        _paramSearch.Add("ScholarshipsYear",        _scholarshipsYear);
        _paramSearch.Add("Semester",                _semester);

        DataSet _ds = SCHDB.GetListApprovalReceiveFinance(_paramSearch);
        DataRow _dr = _ds.Tables[1].Rows[0];

        _maxLotNo   = (!String.IsNullOrEmpty(_dr["maxLotNo"].ToString()) ? (int.Parse(_dr["maxLotNo"].ToString()) + 1).ToString() : "1");

        _ds.Dispose();

        _getResult.Clear();
        _getResult.Add("MaxLotNo", _maxLotNo);

        return _getResult;
    }

    public static DataTable SetColumnDataTable(string _page)
    {
        DataTable _dt = new DataTable();

        if (_page.Equals(PAGE_REPORTLISTOFPEOPLEAPPROVEDFINANCEFROMICL_EXPORT))
        {
            _dt.Columns.Add("No.");
            _dt.Columns.Add("StudentCode");
            _dt.Columns.Add("FullName");
            _dt.Columns.Add("Faculty");
            _dt.Columns.Add("Program");
            _dt.Columns.Add("Tuition");
            _dt.Columns.Add("GroupReceiver");
            _dt.Columns.Add("Bank");
            _dt.Columns.Add("AccountNo");
            _dt.Columns.Add("LotNo");
        }

        return _dt;
    }
}