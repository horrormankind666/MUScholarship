using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NFinServiceLogin;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        followingmenu.InnerHtml = SCHUI.GetFollowingMenu().ToString();        
        header.InnerHtml        = SCHUI.GetHeader().ToString();
        sidebarmenu.InnerHtml   = SCHUI.GetSideBarMenu().ToString();
        userprofile.InnerHtml   = SCHUI.GetUserProfile().ToString();
        footer.InnerHtml        = SCHUI.GetFooter().ToString();

        /*
        DataSet _ds = SCHDB.ExecuteCommandStoredProcedure("sp_schGetListStudentWithAuthenStaff",
            new SqlParameter("@username",       "saowaluk.sor"),
            new SqlParameter("@userlevel",      "Admin"),
            new SqlParameter("@systemGroup",    "MUScholarship"),
            new SqlParameter("@keyword",        "5601033"),
            new SqlParameter("@facultyId",      ""),
            new SqlParameter("@programId",      ""),
            new SqlParameter("@yearEntry",      ""));

        DataRow _dr = _ds.Tables[0].Rows[0];

        Response.Write(_dr["numberScholar"]);

        _ds.Dispose();
        */
        /*
        Dictionary<string, object> _searchResult = new Dictionary<string, object>();        
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        _paramSearch.Add("Keyword",     "5601033");
        _paramSearch.Add("FacultyId",   "");
        _paramSearch.Add("ProgramId",   "");
        _paramSearch.Add("YearEntry",   "");
        _paramSearch.Add("CurrentPage", 1);
        _paramSearch.Add("StartRow",    1);
        _paramSearch.Add("EndRow",      50);
        _paramSearch.Add("RowPerPage",  50);

        _searchResult = SCHRegisterScholarshipUtil.GetSearch(_paramSearch);
        Response.Write(_searchResult["RecordCountPrimary"]);
        */
        /*
        StringBuilder _cookieValue = new StringBuilder();
        
        _cookieValue.AppendFormat("result:{0}", "60@#@117@#@115@#@101@#@114@#@62@#@60@#@117@#@105@#@100@#@62@#@50@#@53@#@51@#@49@#@51@#@55@#@51@#@55@#@52@#@51@#@51@#@52@#@55@#@53@#@48@#@60@#@47@#@117@#@105@#@100@#@62@#@60@#@117@#@115@#@101@#@114@#@116@#@121@#@112@#@101@#@62@#@115@#@116@#@97@#@102@#@102@#@60@#@47@#@117@#@115@#@101@#@114@#@116@#@121@#@112@#@101@#@62@#@60@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@101@#@110@#@62@#@83@#@97@#@111@#@119@#@97@#@108@#@117@#@107@#@32@#@83@#@111@#@114@#@110@#@99@#@104@#@97@#@105@#@60@#@47@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@101@#@110@#@62@#@60@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@116@#@104@#@62@#@224@#@202@#@210@#@199@#@197@#@209@#@161@#@201@#@179@#@236@#@32@#@200@#@195@#@228@#@170@#@194@#@60@#@47@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@116@#@104@#@62@#@60@#@100@#@101@#@112@#@99@#@111@#@100@#@101@#@62@#@79@#@80@#@73@#@84@#@68@#@65@#@60@#@47@#@100@#@101@#@112@#@99@#@111@#@100@#@101@#@62@#@60@#@109@#@97@#@105@#@108@#@97@#@100@#@100@#@114@#@101@#@115@#@115@#@62@#@111@#@112@#@115@#@115@#@104@#@64@#@109@#@97@#@104@#@105@#@100@#@111@#@108@#@46@#@97@#@99@#@46@#@116@#@104@#@115@#@97@#@111@#@119@#@97@#@108@#@117@#@107@#@46@#@115@#@111@#@114@#@64@#@109@#@97@#@104@#@105@#@100@#@111@#@108@#@46@#@97@#@99@#@46@#@116@#@104@#@60@#@47@#@109@#@97@#@105@#@108@#@97@#@100@#@100@#@114@#@101@#@115@#@115@#@62@#@60@#@97@#@117@#@116@#@104@#@101@#@110@#@62@#@116@#@114@#@117@#@101@#@60@#@47@#@97@#@117@#@116@#@104@#@101@#@110@#@62@#@60@#@109@#@115@#@103@#@62@#@65@#@117@#@116@#@104@#@101@#@110@#@116@#@105@#@99@#@97@#@116@#@105@#@111@#@110@#@32@#@83@#@117@#@99@#@99@#@101@#@115@#@115@#@60@#@47@#@109@#@115@#@103@#@62@#@60@#@117@#@115@#@101@#@114@#@110@#@97@#@109@#@101@#@62@#@115@#@97@#@111@#@119@#@97@#@108@#@117@#@107@#@46@#@115@#@111@#@114@#@60@#@47@#@117@#@115@#@101@#@114@#@110@#@97@#@109@#@101@#@62@#@60@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@105@#@100@#@62@#@60@#@47@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@105@#@100@#@62@#@60@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@99@#@111@#@100@#@101@#@62@#@115@#@97@#@111@#@119@#@97@#@108@#@117@#@107@#@46@#@115@#@111@#@114@#@60@#@47@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@99@#@111@#@100@#@101@#@62@#@60@#@109@#@105@#@115@#@115@#@112@#@97@#@115@#@115@#@119@#@111@#@114@#@100@#@62@#@60@#@47@#@109@#@105@#@115@#@115@#@112@#@97@#@115@#@115@#@119@#@111@#@114@#@100@#@62@#@60@#@47@#@117@#@115@#@101@#@114@#@62@#@");
        SCHUtil.SetAddCookie("STAFF", _cookieValue);
        */
        //5801001
        /*_cookieValue.AppendFormat("result:{0}", "60@#@117@#@115@#@101@#@114@#@62@#@60@#@117@#@105@#@100@#@62@#@50@#@53@#@53@#@56@#@48@#@48@#@48@#@51@#@57@#@49@#@60@#@47@#@117@#@105@#@100@#@62@#@60@#@117@#@115@#@101@#@114@#@116@#@121@#@112@#@101@#@62@#@83@#@84@#@85@#@68@#@69@#@78@#@84@#@60@#@47@#@117@#@115@#@101@#@114@#@116@#@121@#@112@#@101@#@62@#@60@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@101@#@110@#@62@#@75@#@82@#@73@#@84@#@84@#@65@#@80@#@65@#@83@#@32@#@66@#@85@#@65@#@74@#@69@#@69@#@80@#@60@#@47@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@101@#@110@#@62@#@60@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@116@#@104@#@62@#@161@#@196@#@181@#@192@#@210@#@202@#@32@#@186@#@209@#@199@#@168@#@213@#@186@#@60@#@47@#@102@#@117@#@108@#@108@#@110@#@97@#@109@#@101@#@116@#@104@#@62@#@60@#@100@#@101@#@112@#@99@#@111@#@100@#@101@#@62@#@83@#@73@#@45@#@48@#@49@#@60@#@47@#@100@#@101@#@112@#@99@#@111@#@100@#@101@#@62@#@60@#@109@#@97@#@105@#@108@#@97@#@100@#@100@#@114@#@101@#@115@#@115@#@62@#@60@#@47@#@109@#@97@#@105@#@108@#@97@#@100@#@100@#@114@#@101@#@115@#@115@#@62@#@60@#@97@#@117@#@116@#@104@#@101@#@110@#@62@#@116@#@114@#@117@#@101@#@60@#@47@#@97@#@117@#@116@#@104@#@101@#@110@#@62@#@60@#@109@#@115@#@103@#@62@#@65@#@117@#@116@#@104@#@101@#@110@#@32@#@83@#@117@#@99@#@99@#@101@#@115@#@115@#@60@#@47@#@109@#@115@#@103@#@62@#@60@#@117@#@115@#@101@#@114@#@110@#@97@#@109@#@101@#@62@#@49@#@49@#@48@#@48@#@56@#@48@#@49@#@49@#@55@#@53@#@52@#@51@#@52@#@60@#@47@#@117@#@115@#@101@#@114@#@110@#@97@#@109@#@101@#@62@#@60@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@105@#@100@#@62@#@83@#@84@#@68@#@50@#@53@#@53@#@56@#@48@#@48@#@49@#@56@#@52@#@60@#@47@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@105@#@100@#@62@#@60@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@99@#@111@#@100@#@101@#@62@#@53@#@56@#@48@#@49@#@48@#@48@#@49@#@60@#@47@#@115@#@116@#@117@#@100@#@101@#@110@#@116@#@99@#@111@#@100@#@101@#@62@#@60@#@109@#@105@#@115@#@115@#@112@#@97@#@115@#@115@#@119@#@111@#@114@#@100@#@62@#@60@#@47@#@109@#@105@#@115@#@115@#@112@#@97@#@115@#@115@#@119@#@111@#@114@#@100@#@62@#@60@#@47@#@117@#@115@#@101@#@114@#@62@#@");
        NUtil.Util.SetAddCookie("STUDENT", _cookieValue);*/

        /*
        MemoryStream _ms = new MemoryStream();
        FileStream _fs = new FileStream((Server.MapPath("~") + "/Test.xlsx"), FileMode.Create, FileAccess.Write);
        ExcelPackage _pk = new ExcelPackage();
        ExcelWorksheet _ws = _pk.Workbook.Worksheets.Add("Test");

        for (int _i = 1; _i <= 1000; _i++)
        {
            _ws.Cells["A" + _i].Value = string.Format("Test{0}", _i);
        }
            
        _pk.SaveAs(_ms);
        _ms.WriteTo(_fs);

        _ms.Close();
        _ms.Dispose();
        _fs.Close();
        _fs.Dispose();
        */
    }
}