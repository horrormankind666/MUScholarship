using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCHDownloadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = Request.QueryString["action"];
        string _filePath = Request.QueryString["p"];
        string _fileName = Request.QueryString["f"];

        if (_action.Equals(SCHUtil.SUBJECT_REGISTERSCHOLARSHIPTEMPLATE))
        {
            _filePath   = SCHUtil._myFileDownloadPath;
            _fileName   = "RegisterScholarshipTemplate.xls";
        }

        SCHUtil.ViewFile(_filePath, _fileName);
    }
}