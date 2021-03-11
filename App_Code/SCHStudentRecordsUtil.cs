using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

public class SCHStudentRecordsUtil
{    
    public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
    {
        string _studentPicture = String.Empty;
        DataRow _dr = null;

        if (_ds != null)
        {
            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];
        }

        _studentPicture = (_dr != null && !String.IsNullOrEmpty(_dr["profilePictureName"].ToString()) ? (SCHUtil._myURLPictureStudent + "/" + _dr["profilePictureName"].ToString()) : String.Empty);
        _studentPicture = (!String.IsNullOrEmpty(_studentPicture) && SCHUtil.FileSiteExist(_studentPicture) ? (SCHUtil._myHandlerPath + "?action=image2stream&f=" + SCHUtil.EncodeToBase64(_studentPicture)) : String.Empty);

        _dataRecorded.Add("PersonId",           (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"] : String.Empty));
        _dataRecorded.Add("StudentId",          (_dr != null && !String.IsNullOrEmpty(_dr["studentId"].ToString()) ? _dr["studentId"] : String.Empty));
        _dataRecorded.Add("StudentCode",        (_dr != null && !String.IsNullOrEmpty(_dr["studentCode"].ToString()) ? _dr["studentCode"] : "XXXXXXX"));
        _dataRecorded.Add("StudentPicture",     (!String.IsNullOrEmpty(_studentPicture) ? _studentPicture : String.Empty));
        _dataRecorded.Add("TitleInitialsTH",    (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsTH"].ToString()) ? _dr["titlePrefixInitialsTH"].ToString() : String.Empty));
        _dataRecorded.Add("TitleInitialsEN",    (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsEN"].ToString()) ? _dr["titlePrefixInitialsEN"].ToString() : String.Empty));
        _dataRecorded.Add("TitleFullNameTH",    (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameTH"].ToString()) ? _dr["titlePrefixFullNameTH"].ToString() : String.Empty));
        _dataRecorded.Add("TitleFullNameEN",    (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameEN"].ToString()) ? _dr["titlePrefixFullNameEN"].ToString() : String.Empty));
        _dataRecorded.Add("FirstName",          (_dr != null && !String.IsNullOrEmpty(_dr["firstName"].ToString()) ? _dr["firstName"].ToString() : String.Empty));
        _dataRecorded.Add("MiddleName",         (_dr != null && !String.IsNullOrEmpty(_dr["middleName"].ToString()) ? _dr["middleName"].ToString() : String.Empty));
        _dataRecorded.Add("LastName",           (_dr != null && !String.IsNullOrEmpty(_dr["lastName"].ToString()) ? _dr["lastName"].ToString() : String.Empty));
        _dataRecorded.Add("FirstNameEN",        (_dr != null && !String.IsNullOrEmpty(_dr["firstNameEN"].ToString()) ? _dr["firstNameEN"].ToString() : String.Empty));
        _dataRecorded.Add("MiddleNameEN",       (_dr != null && !String.IsNullOrEmpty(_dr["middleNameEN"].ToString()) ? _dr["middleNameEN"].ToString() : String.Empty));
        _dataRecorded.Add("LastNameEN",         (_dr != null && !String.IsNullOrEmpty(_dr["lastNameEN"].ToString()) ? _dr["lastNameEN"].ToString() : String.Empty));
        _dataRecorded.Add("FacultyNameTH",      (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameTH"].ToString()) ? _dr["facultyNameTH"].ToString() : String.Empty));
        _dataRecorded.Add("FacultyNameEN",      (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameEN"].ToString()) ? _dr["facultyNameEN"].ToString() : String.Empty));
        _dataRecorded.Add("ProgramNameTH",      (_dr != null && !String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? _dr["programNameTH"].ToString() : String.Empty));
        _dataRecorded.Add("ProgramNameEN",      (_dr != null && !String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? _dr["programNameEN"].ToString() : String.Empty));
        _dataRecorded.Add("StatusTypeNameTH",   (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameTH"].ToString()) ? _dr["statusTypeNameTH"].ToString() : String.Empty));
        _dataRecorded.Add("StatusTypeNameEN",   (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameEN"].ToString()) ? _dr["statusTypeNameEN"].ToString() : String.Empty));

        return _dataRecorded;
    }
}