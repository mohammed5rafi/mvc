using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL1
{
    public class CommonDA : SQLConnection
    {



        public string dataConnection = GetConnectionString("ESSPCON");

        public String ErrorMsg = "";
        public bool GetGeneralSettings(string Prefix)
        {
            using (IDbConnection connection = OpenConnection(dataConnection))
            {
                var param = new DynamicParameters();
                param.Add("@Prefix", Prefix, dbType: DbType.String);
                var Value = connection.Query<int?>("dbo.usp_GetSettings", param, commandType: CommandType.StoredProcedure);
                return (Value.ElementAtOrDefault<int?>(0) > 0) ? true : false;
            }
        }

        public String ReplaceCharFromXML(String xmlString)
        {
            if (xmlString != null)
            {
                xmlString = xmlString.Replace("&", "&amp;");
                xmlString = xmlString.Replace("<", "&lt;");
                xmlString = xmlString.Replace(">", "&gt;");
                xmlString = xmlString.Replace("\"", "&quot;");
                xmlString = xmlString.Replace("'", "&apos;");
                //xmlString = xmlString.Replace("", "&quot;");
            }
            return xmlString;
        }

        //public SalaryPeriod GetCurrentPeriod()
        //{
        //    using (IDbConnection connection = OpenConnection(dataConnection))
        //    {
        //        return connection.Query<SalaryPeriod>("select mpCode Code,mpName Month,mpDateFrom FromDate,mpDateTo ToDate "
        //         + " from mstMonthSalPeriod WHERE CAST (GETDATE() AS DATE) BETWEEN  CAST(mpDateFrom AS DATE) AND CAST(mpDateTo AS DATE)").FirstOrDefault();
        //    }
        //}


        //public MailConfiguraion GetMailConfiguration()
        //{
        //    using (IDbConnection connection = OpenConnection(dataConnection))
        //    {
        //        return connection.Query<MailConfiguraion>("select mMailSMTPSrvr SmtpServer,mMailPort MailPort,mMailSMTPServerMailId MailID,mMailSMTPServerPwd Password ,"
        //         + " isnull(mMailsslEnable,0) EnableSSL from [mstMailConfiguration]").FirstOrDefault();
        //    }
        //}

        //public EmployeeMasters GetEmployee(int EMPID)
        //{
        //    try
        //    {
        //        using (IDbConnection connection = OpenConnection(dataConnection))
        //        {
        //            var param = new DynamicParameters();
        //            param.Add("@EMPID", EMPID, dbType: DbType.Int32);
        //            return connection.Query<EmployeeMasters>("HRM_ESSP_GET_EMPLOYEE", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorMsg = ex.Message.ToString();
        //        throw new Exception(ErrorMsg, ex);
        //    }
        //}

        //public SalaryPeriod getMonth(string date)
        //{
        //    using (IDbConnection connection = OpenConnection(dataConnection))
        //    {
        //        return connection.Query<SalaryPeriod>("select mpCode Code,mpName Month,mpDateFrom FromDate,mpDateTo ToDate "
        //         + " from mstMonthSalPeriod WHERE  '" + date + "'  BETWEEN  CAST(mpDateFrom AS DATE) AND CAST(mpDateTo AS DATE)").FirstOrDefault();
        //    }
        //}

        //public GeneralSettings getRecruitmentGeneralSettings()
        //{
        //    try
        //    {
        //        using (IDbConnection connection = OpenConnection(dataConnection))
        //        {
        //            return connection.Query<GeneralSettings>("HRM_ESSP_REC_GET_RECRUITMENT_GENERALSETTINGS", commandType: CommandType.StoredProcedure).FirstOrDefault();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorMsg = ex.Message.ToString();
        //        throw new Exception(ErrorMsg, ex);
        //    }
        //}
        public string SaveErrorLog(string msg)
        {
            try
            {
                using (IDbConnection connection = OpenConnection(dataConnection))
                {
                    var param = new DynamicParameters();
                    param.Add("@Error", msg, dbType: DbType.String);
                    param.Add("@Result", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                    connection.Query<int?>("USP_ESSP_SAVE_ERROR", param, commandType: CommandType.StoredProcedure);
                    return param.Get<String>("@Result");
                }
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

    }
}
