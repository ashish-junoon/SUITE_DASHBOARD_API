using LMS_DL.Model.UserModel;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security;
using static LMS_DL.Model.UserModel.AssignServiceModel;
using static LMS_DL.Model.UserModel.GetVendorCodeModel;
using static LMS_DL.Model.UserModel.LoginUserModel;
using static LMS_DL.Model.UserModel.VendorLoginModel;
using static LMS_DL.Model.UserModel.VendorRegisterModel;
using static LMS_DL.Model.UserModel.VendorWalletRechargeHistoryModel;
using static LMS_DL.Model.UserModel.VendorWalletRechargeModel;

namespace LMS_DL.Repository
{
    public class UserRepository
    {
        DataSet Objds = null;
        DataTable Objtable = new DataTable();

        public LoginUserModel.LoginUserRS LoginUser(LoginUserModel.LoginUserRQ loginUserRQ, string dbconnection)
        {
            LoginUserModel.LoginUserRS loginUserRS = new();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                param[0] = new SqlParameter("user_name", SqlDbType.VarChar, 30);
                param[0].Value = loginUserRQ.user_name;

                param[1] = new SqlParameter("Password", SqlDbType.VarChar, 20);
                param[1].Value = loginUserRQ.password;


                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Objds = new DataSet();
                    try
                    {
                        Objds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_VendorLogin", param);
                    }
                    catch (Exception ex)
                    {
                        return new LoginUserModel.LoginUserRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Objds?.Tables?.Count > 0)
                {
                    Objtable = Objds.Tables[0];

                    if (Convert.ToBoolean(Objtable.Rows[0]?["status"]))
                    {
                        loginUserRS = new LoginUserModel.LoginUserRS()
                        {
                            message = string.IsNullOrEmpty(Convert.ToString(Objtable.Rows[0]["message"])) ? string.Empty : Convert.ToString(Objtable.Rows[0]["message"]),
                            status = Objtable.Rows[0]["status"] == DBNull.Value ? false : Convert.ToBoolean(Objtable.Rows[0]["status"]),
                            vendor_full_name = string.IsNullOrEmpty(Convert.ToString(Objtable.Rows[0]["vendor_full_name"])) ? string.Empty : Convert.ToString(Objtable.Rows[0]["vendor_full_name"]),
                            vendor_code = string.IsNullOrEmpty(Convert.ToString(Objtable.Rows[0]["vendor_code"])) ? string.Empty : Convert.ToString(Objtable.Rows[0]["vendor_code"]),
                            token = string.IsNullOrEmpty(Convert.ToString(Objtable.Rows[0]["token"])) ? string.Empty : Convert.ToString(Objtable.Rows[0]["token"]),
                            vendor_company_name = string.IsNullOrEmpty(Convert.ToString(Objtable.Rows[0]["vendor_company_name"])) ? string.Empty : Convert.ToString(Objtable.Rows[0]["vendor_company_name"]),
                            ip_address = string.IsNullOrEmpty(Convert.ToString(Objtable.Rows[0]["ip_address"])) ? string.Empty : Convert.ToString(Objtable.Rows[0]["ip_address"]),
                            is_active = Objtable.Rows[0]["is_active"] == DBNull.Value ? false : Convert.ToBoolean(Objtable.Rows[0]["is_active"]),
                        };
                    }
                    else
                    {
                        loginUserRS = new LoginUserModel.LoginUserRS()
                        {
                            message = string.IsNullOrEmpty(Convert.ToString(Objtable.Rows[0]["message"])) ? string.Empty : Convert.ToString(Objtable.Rows[0]["message"]),
                            status = Objtable.Rows[0]["status"] == DBNull.Value ? false : Convert.ToBoolean(Objtable.Rows[0]["status"]),
                        };
                    }
                }
                else
                {
                    loginUserRS = new LoginUserModel.LoginUserRS()
                    {
                        message = "Invalid Password and Vendor Code",
                        status = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginUserRS()
                {
                    message = ex.Message,
                    status = false,
                };
            }
            return loginUserRS;
        }

        public VendorRegisterModel.VendorRegisterRS VendorRegister(VendorRegisterModel.VendorRegisterRQ vendorRQ, string dbconnection)
        {
            VendorRegisterRS vendorRS = new();
            try
            {
                SqlParameter[] param = new SqlParameter[23];

                param[0] = new SqlParameter("vendor_full_name", SqlDbType.NVarChar, 100) { Value = vendorRQ.vendor_full_name ?? (object)DBNull.Value };
                param[1] = new SqlParameter("vendor_email", SqlDbType.NVarChar, 100) { Value = vendorRQ.vendor_email ?? (object)DBNull.Value };
                param[2] = new SqlParameter("vendor_company_name", SqlDbType.NVarChar, 100) { Value = vendorRQ.vendor_company_name ?? (object)DBNull.Value };
                param[4] = new SqlParameter("user_name", SqlDbType.NVarChar, 100) { Value = vendorRQ.vendor_email ?? (object)DBNull.Value };
                param[5] = new SqlParameter("pan_number", SqlDbType.NVarChar, 15) { Value = vendorRQ.pan_number ?? (object)DBNull.Value };
                param[6] = new SqlParameter("mobile", SqlDbType.NVarChar, 15) { Value = vendorRQ.mobile ?? (object)DBNull.Value };
                param[7] = new SqlParameter("office_land_line", SqlDbType.NVarChar, 15) { Value = vendorRQ.office_land_line ?? (object)DBNull.Value };
                param[8] = new SqlParameter("address_line", SqlDbType.NVarChar, 200) { Value = vendorRQ.address_line ?? (object)DBNull.Value };
                param[9] = new SqlParameter("city", SqlDbType.NVarChar, 50) { Value = vendorRQ.city ?? (object)DBNull.Value };
                param[10] = new SqlParameter("state", SqlDbType.NVarChar, 50) { Value = vendorRQ.state ?? (object)DBNull.Value };
                param[11] = new SqlParameter("zip_code", SqlDbType.NVarChar, 10) { Value = vendorRQ.zip_code ?? (object)DBNull.Value };
                param[12] = new SqlParameter("office_address_line", SqlDbType.NVarChar, 200) { Value = vendorRQ.office_address_line ?? (object)DBNull.Value };
                param[13] = new SqlParameter("office_city", SqlDbType.NVarChar, 50) { Value = vendorRQ.office_city ?? (object)DBNull.Value };
                param[14] = new SqlParameter("office_state", SqlDbType.NVarChar, 50) { Value = vendorRQ.office_state ?? (object)DBNull.Value };
                param[15] = new SqlParameter("office_zip_code", SqlDbType.NVarChar, 15) { Value = vendorRQ.office_zip_code ?? (object)DBNull.Value };
                param[16] = new SqlParameter("ip_address", SqlDbType.NVarChar, 50) { Value = vendorRQ.ip_address ?? (object)DBNull.Value };
                param[17] = new SqlParameter("created_by", SqlDbType.NVarChar, 100) { Value = vendorRQ.created_by ?? (object)DBNull.Value };
                param[18] = new SqlParameter("is_active", SqlDbType.Bit) { Value = vendorRQ.is_active };
                param[19] = new SqlParameter("id", SqlDbType.Int)
                {
                    Value = vendorRQ.id == 0 ? 0 : (object)vendorRQ.id
                };
                param[20] = new SqlParameter("vendor_type", SqlDbType.NVarChar, 50) { Value = vendorRQ.vendor_type ?? (object)DBNull.Value };
                param[21] = new SqlParameter("billing_type", SqlDbType.NVarChar, 50) { Value = vendorRQ.billing_type ?? (object)DBNull.Value };

                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    DataSet Objds = new();
                    try
                    {
                        Objds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_NewVendorRegistration", param);
                    }
                    catch (Exception ex)
                    {
                        return new VendorRegisterRS
                        {
                            message = ex.Message,
                            status = false
                        };
                    }
                    if (Objds?.Tables?.Count > 0 && Objds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = Objds.Tables[0].Rows[0];
                        vendorRS = new VendorRegisterRS
                        {
                            message = row["Message"] != DBNull.Value ? Convert.ToString(row["Message"]) : string.Empty,
                            status = row["Status"] != DBNull.Value && Convert.ToBoolean(row["Status"]),
                            id = Convert.ToInt32(row["Id"]),
                            vendor_code = row["vendor_code"] != DBNull.Value ? Convert.ToString(row["vendor_code"]) : string.Empty,
                        };
                    }
                    else
                    {
                        vendorRS = new VendorRegisterRS
                        {
                            message = "No response from database.",
                            status = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new VendorRegisterRS
                {
                    message = ex.Message,
                    status = false
                };
            }

            return vendorRS;
        }


        //public AssignServiceModel.AssignServiceRS AssignService(AssignServiceModel.AssignServiceRQ request, string dbconnection)
        //{
        //    AssignServiceModel.AssignServiceRS assignServiceRS = new();
        //    SqlParameter[] param = new SqlParameter[7];
        //    try
        //    {
        //        param[0] = new SqlParameter("vendor_code", SqlDbType.VarChar, 5);
        //        param[0].Value = request.vendor_code;

        //        param[1] = new SqlParameter("service_name_id", SqlDbType.Int);
        //        param[1].Value = request.service_name_id;

        //        param[2] = new SqlParameter("service_amount", SqlDbType.Decimal);
        //        param[2].Value = request.service_amount;

        //        param[3] = new SqlParameter("is_active", SqlDbType.Bit);
        //        param[3].Value = request.is_active;

        //        param[4] = new SqlParameter("created_by", SqlDbType.VarChar, 30);
        //        param[4].Value = request.created_by;

        //        param[5] = new SqlParameter("service_type_id", SqlDbType.Int);
        //        param[5].Value = request.service_type_id;

        //        param[6] = new SqlParameter("assigned_service_id", SqlDbType.Int);
        //        param[6].Value = request.assigned_service_id;

        //        using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
        //        {
        //            Objds = new DataSet();
        //            try
        //            {
        //                Objds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_AssignService", param);
        //            }
        //            catch (Exception ex)
        //            {
        //                return new AssignServiceModel.AssignServiceRS()
        //                {
        //                    message = ex.Message,
        //                    status = false,
        //                };
        //            }
        //        }
        //        if (Objds?.Tables?.Count > 0)
        //        {
        //            Objtable = Objds.Tables[0];

        //            if (Convert.ToBoolean(Objtable.Rows[0]?["status"]))
        //            {
        //                assignServiceRS = new AssignServiceModel.AssignServiceRS()
        //                {
        //                    message = Objtable.Rows[0]?["message"]?.ToString()?.Trim() ?? string.Empty,
        //                    status = Objtable.Rows[0]?["status"] != DBNull.Value && Convert.ToBoolean(Objtable.Rows[0]["status"]),
        //                    assigned_service_id = Convert.ToInt32(Objtable.Rows[0]?["assigned_service_id"])
        //                };
        //            }
        //            else
        //            {
        //                assignServiceRS = new AssignServiceModel.AssignServiceRS()
        //                {
        //                    message = Objtable.Rows[0]?["message"]?.ToString()?.Trim() ?? string.Empty,
        //                    status = Objtable.Rows[0]?["status"] != DBNull.Value && Convert.ToBoolean(Objtable.Rows[0]["status"]),
        //                };
        //            }
        //        }
        //        else
        //        {
        //            assignServiceRS = new AssignServiceModel.AssignServiceRS()
        //            {
        //                message = "Invalid Request",
        //                status = false,
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new AssignServiceRS()
        //        {
        //            message = ex.Message,
        //            status = false,
        //        };
        //    }
        //    return assignServiceRS;
        //}

        public AssignServiceModel_V1.AssignServiceRS AssignService(AssignServiceModel_V1.AssignServiceRQ request, string dbconnection)
        {
            DataSet Obj_ds = new DataSet();
            int total = 0;
            AssignServiceModel_V1.AssignServiceRS assignServiceRS = new();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("vendor_code", SqlDbType.VarChar, 50);
            param[0].Value = request.servicesArray?[0].vendor_code;

            param[1] = new SqlParameter("Action", SqlDbType.VarChar, 20);
            param[1].Value = "DELETE";

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("vendor_code", typeof(string));
                dt.Columns.Add("service_amount", typeof(decimal));
                dt.Columns.Add("is_active", typeof(bool));
                dt.Columns.Add("created_by", typeof(string));
                //dt.Columns.Add("created_date", typeof(DateTime));
                dt.Columns.Add("service_type_id", typeof(int));
                dt.Columns.Add("service_name_id", typeof(int));

                foreach (var item in request.servicesArray ?? [])
                {
                    dt.Rows.Add
                       (
                           item.vendor_code,
                           item.service_amount,
                           item.is_active,
                           item.created_by,
                           item.service_type_id,
                           item.service_name_id
                       );
                }
                using (SqlConnection con = new SqlConnection(dbconnection))
                {
                    if (dt != null)
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_AssignService_V1", param);
                    }
                    using (SqlCommand cmd = new SqlCommand("USP_AssignService_V1"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tbl_Type", dt);
                        con.Open();
                        total = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                if (total > 0)
                {
                    return new AssignServiceModel_V1.AssignServiceRS()
                    {
                        message = "Success",
                        status = true
                    };
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error in SetPermission" + ex.Message);
                return new AssignServiceModel_V1.AssignServiceRS()
                {
                    message = ex.Message,
                    status = false
                };
            }

            return assignServiceRS;
        }

        public GetVendorCodeRS GetVendorCode(string dbconnection)
        {
            GetVendorCodeRS getVendorCodeRS = new GetVendorCodeRS();
            SqlParameter[] param = new SqlParameter[0];
            using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
            {
                Objds = new DataSet();
                try
                {
                    Objds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetVendorCode", param);
                }
                catch (Exception ex)
                {
                    //_logger.LogError($"Exception in GetHouseType while executing storeprocedure - USP_GetHouseType: {ex.Message}");
                }
            }
            if (Objds?.Tables?.Count > 0 && Objds.Tables[0]?.Rows?.Count > 0)
            {
                List<GetVendorCode> data = new List<GetVendorCode>();
                Objtable = Objds.Tables[0];

                foreach (DataRow row in Objtable.Rows)
                {
                    GetVendorCode vendorCode = new GetVendorCode
                    {
                        user_name = row["user_name"] != DBNull.Value ? Convert.ToString(row["user_name"])?.Trim() : string.Empty,
                        vendor_code = row["vendor_code"] != DBNull.Value ? Convert.ToString(row["vendor_code"])?.Trim() : string.Empty,
                    };
                    data.Add(vendorCode);
                }

                getVendorCodeRS.status = true;
                getVendorCodeRS.getVendorCodes = data;
                getVendorCodeRS.message = "Success";
            }
            else
            {
                getVendorCodeRS.status = false;
                getVendorCodeRS.getVendorCodes = new List<GetVendorCode>();
                getVendorCodeRS.message = "No data found";
            }
            return getVendorCodeRS;
        }

        public UpdateStatusModel.UpdateStatusRS UpdateStatus(UpdateStatusModel.UpdateStatusRQ request, string dbconnection)
        {
            UpdateStatusModel.UpdateStatusRS updateStatusRS = new();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                param[0] = new SqlParameter("id", SqlDbType.Int);
                param[0].Value = request.id;

                param[1] = new SqlParameter("is_active", SqlDbType.Bit);
                param[1].Value = request.is_active;

                param[2] = new SqlParameter("type", SqlDbType.VarChar, 30);
                param[2].Value = request.type;

                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Objds = new DataSet();
                    try
                    {
                        Objds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_UpdateStatus", param);
                    }
                    catch (Exception ex)
                    {
                        return new UpdateStatusModel.UpdateStatusRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Objds?.Tables?.Count > 0)
                {
                    Objtable = Objds.Tables[0];
                    if (Objtable.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(Objtable.Rows[0]?["status"]))
                        {
                            updateStatusRS = new UpdateStatusModel.UpdateStatusRS()
                            {
                                message = Objtable.Rows[0]?["message"]?.ToString()?.Trim() ?? string.Empty,
                                status = Objtable.Rows[0]?["status"] != DBNull.Value && Convert.ToBoolean(Objtable.Rows[0]["Status"]),
                                id = Convert.ToInt32(Objtable.Rows[0]?["id"])
                            };
                        }
                        else
                        {
                            updateStatusRS = new UpdateStatusModel.UpdateStatusRS()
                            {
                                message = Objtable.Rows[0]?["message"]?.ToString()?.Trim() ?? string.Empty,
                                status = Objtable.Rows[0]?["status"] != DBNull.Value && Convert.ToBoolean(Objtable.Rows[0]["Status"]),
                            };
                        }
                    }
                    else
                    {
                        updateStatusRS = new UpdateStatusModel.UpdateStatusRS()
                        {
                            message = "No records found.",
                            status = false,
                        };
                    }
                }
                else
                {
                    updateStatusRS = new UpdateStatusModel.UpdateStatusRS()
                    {
                        message = "Invalid Request",
                        status = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new UpdateStatusModel.UpdateStatusRS()
                {
                    message = ex.Message,
                    status = false,
                };
            }
            return updateStatusRS;
        }

    }
}
