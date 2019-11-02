using SmOffice.DL.DataSetTableAdapters;
using SmOffice.Models;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SmOffice.DL
{
    public class DlEmpys
    {
        public DataTable GetCredential(string EmpyName)
        {
            return new wca_sel_GetCredentialsTableAdapter().GetData(EmpyName);
        }

        public bool SetUser(MdlEmpys mdlEmpys)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;

                    //The name of the above mentioned stored procedure.  
                    //cmd.CommandText = "dbo.ins_upd_User";
                    //DataTable dataTable = mdlEmpys.GetDataTable();
                    //SqlParameter param = cmd.Parameters.AddWithValue("@UserType", dataTable);

                    //Set up a return value paramter to get back the returned code from the stored procedure
                    //SqlParameter retval = cmd.Parameters.Add("@ReturnValue", SqlDbType.VarChar);
                    //retval.Direction = ParameterDirection.ReturnValue;

                    //conn.Open();
                   // cmd.ExecuteNonQuery();
                    //int returnValue = (int)cmd.Parameters["@ReturnValue"].Value;
                    return true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}