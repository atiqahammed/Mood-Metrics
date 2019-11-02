using SmOffice.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SmOffice.Models
{
    public class MdlEmpys
    {
        #region Properties
        public int EmpyId { get; set; }
        public string EmpyName { get; set; }
        public byte[] EmpyPwHash { get; set; }
        public byte[] EmpyPwSalt { get; set; }
        public int EmpyAge { get; set; }
        public string EmpyGender { get; set; }
        public DateTime EmpyDOB { get; set; }
        public int EmpyHmPhnNo { get; set; }
        public int EmpyMbPhnNo { get; set; }
        public string EmpyEmail { get; set; }
        public string EmpyMailAdd { get; set; }
        public int DpmtId { get; set; }
        public string DpmtName { get; set; }
        public string EmpyJobTitle { get; set; }
        public int EmpyDrctMgId { get; set; }
        public string EmpyDrctMgName { get; set; }
        #endregion

        #region Constructors
        public MdlEmpys()
        {
        }   // Empty constructor

        public MdlEmpys(int EmpyId, string EmpyName, byte[] EmpyPwHash, byte[] EmpyPwSalt, int EmpyAge, string EmpyGender, DateTime EmpyDOB, int EmpyHmPhnNo, int EmpyMbPhnNo, string EmpyEmail, string EmpyMailAdd, int DpmtId, string DpmtName, string EmpyJobTitle, int EmpyDrctMgId, string EmpyDrctMgName)
        {
            this.EmpyId = EmpyId;
            this.EmpyName = EmpyName;
            this.EmpyPwHash = EmpyPwHash;
            this.EmpyPwSalt = EmpyPwSalt;
            this.EmpyAge = EmpyAge;
            this.EmpyGender = EmpyGender;
            this.EmpyDOB = EmpyDOB;
            this.EmpyHmPhnNo = EmpyHmPhnNo;
            this.EmpyMbPhnNo = EmpyMbPhnNo;
            this.EmpyEmail = EmpyEmail;
            this.EmpyMailAdd = EmpyMailAdd;
            this.DpmtId = DpmtId;
            this.DpmtName = DpmtName;
            this.EmpyJobTitle = EmpyJobTitle;
            this.EmpyDrctMgId = EmpyDrctMgId;
            this.EmpyDrctMgName = EmpyDrctMgName;
        }   // Full constructor
        #endregion

        public bool IsValid(string username, string password)
        {
            DataTable tblUser = new DlEmpys().GetCredential(username);
            return (tblUser.Rows.Count > 0);
        }

        public bool RegisterUser()
        {
            return new DlEmpys().SetUser(this);
        }

        public bool RegisterUser(MdlEmpys mdlEmpys)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("EmpyId", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("EmpyName"));
            dt.Columns.Add(new DataColumn("EmpyPwHash", Type.GetType("System.Byte[]")));
            dt.Columns.Add(new DataColumn("EmpyPwSalt", Type.GetType("System.Byte[]")));
            dt.Columns.Add(new DataColumn("EmpyAge", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("EmpyGender"));
            dt.Columns.Add(new DataColumn("EmpyDOB", Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("EmpyHmPhnNo", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("EmpyMbPhnNo", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("EmpyEmail"));
            dt.Columns.Add(new DataColumn("EmpyMailAdd"));
            dt.Columns.Add(new DataColumn("DpmtId", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("DpmtName"));
            dt.Columns.Add(new DataColumn("EmpyJobTitle"));
            dt.Columns.Add(new DataColumn("EmpyDrctMgId", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("EmpyDrctMgName"));

            DataRow dr = dt.NewRow();
            dr["EmpyId"] = this.EmpyId;
            dr["EmpyName"] = this.EmpyName;
            dr["EmpyPwHash"] = this.EmpyPwHash;
            dr["EmpyPwSalth"] = this.EmpyPwSalt;
            dr["EmpyAge"] = this.EmpyAge;
            dr["EmpyGender"] = this.EmpyGender;
            dr["EmpyDOB"] = this.EmpyDOB;
            dr["EmpyHmPhnNo"] = this.EmpyHmPhnNo;
            dr["EmpyMbPhnNo"] = this.EmpyMbPhnNo;
            dr["EmpyEmail"] = this.EmpyEmail;
            dr["EmpyMailAdd"] = this.EmpyMailAdd;
            dr["DpmtId"] = this.DpmtId;
            dr["DpmtName"] = this.DpmtName;
            dr["EmpyJobTitle"] = this.EmpyJobTitle;
            dr["EmpyDrctMgId"] = this.EmpyDrctMgId;
            dr["EmpyDrctMgName"] = this.EmpyDrctMgName;
            dt.Rows.Add(dr);

            return dt;

        }
    }
}