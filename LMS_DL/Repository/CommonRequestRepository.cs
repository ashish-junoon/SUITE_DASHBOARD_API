using LoggerLibrary;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace LMS_DL.Repository
{
    public class CommonRequestRepository
    {
        public static void SaveVendorServiceRequest(string vendor_code , string service_name , string body , string dbconnection, ILoggerManager _logger)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@vendor_code", SqlDbType.NVarChar, 5)
                {
                    Value = vendor_code ?? (object)DBNull.Value
                };

                param[1] = new SqlParameter("@services_name", SqlDbType.NVarChar, 50)
                {
                    Value = service_name ?? (object)DBNull.Value
                };

                param[2] = new SqlParameter("@services_status", SqlDbType.NVarChar, 30)
                {
                    Value = "" ?? (object)DBNull.Value
                };

                param[3] = new SqlParameter("@requested_amount", SqlDbType.Decimal)
                {
                    Value = 0.00
                };

                //param[4] = new SqlParameter("@json_request", SqlDbType.NVarChar)
                //{
                //    Value = model?.json_request ?? (object)DBNull.Value
                //};

                //param[5] = new SqlParameter("@unique_id", SqlDbType.NVarChar, 50)
                //{
                //    Value = model?.unique_id ?? (object)DBNull.Value
                //};

                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Usp_vendor_service_requests", param);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error in SaveVendorServiceRequest method: {ex.Message}");
            }
        }

        public static ExternalPartner? GetPartnersDetails(string token,string vendor,string action_name,string dbconnection,ILoggerManager _logger)
        {
            ExternalPartner? partner = new ExternalPartner();
            DataSet? ds = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Token", SqlDbType.VarChar) { Value = token },
                    new SqlParameter("@VendorCode", SqlDbType.VarChar) { Value = vendor },
                    new SqlParameter("@ServiceName", SqlDbType.VarChar) { Value = action_name }
                };
                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Usp_GetPartnersDetails_V1", param);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        DataRow row = dt.Rows[0];
                        partner.message = row["Message"] != DBNull.Value ? Convert.ToString(row["Message"]) : string.Empty;
                        partner.status = row["Status"] != DBNull.Value && Convert.ToBoolean(row["Status"]);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error in GetPartnersDetails method: {ex.Message}");
            }
            return partner;
        }
    }
}
