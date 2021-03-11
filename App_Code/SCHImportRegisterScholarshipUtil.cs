using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class SCHImportRegisterScholarshipUtil
{
    public static string[] _excelFirstRow = new string[]
    {
        "ลำดับ",
        "ปีการศึกษา",
        "ภาคการศึกษา",
        "รหัสนักศึกษา",
        "ชื่อทุนการศึกษา",
        "เงินทุนต่อเทอม",
        "หน่วยงานที่รับผิดชอบ",
        "หมายเหตุ"
    };
}