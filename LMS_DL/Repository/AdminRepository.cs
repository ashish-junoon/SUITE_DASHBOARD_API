using LMS_DL.Model.Admin;
using LoggerLibrary;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using static LMS_DL.Model.Admin.GetVendorAmountModel;
using static LMS_DL.Model.Admin.GetVendorListModel;
using static LMS_DL.Model.Admin.ServiceNameModel;
using static LMS_DL.Model.Admin.ServiceTypeModel;
using static LMS_DL.Model.Admin.VendorDashboardModel;
using static LMS_DL.Model.Admin.VendorServiceNameModel;
namespace LMS_DL.Repository
{
    public class AdminRepository
    {
        private readonly ILoggerManager _logger;
        public AdminRepository(ILoggerManager logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        DataSet? Obj_ds = null;
        DataTable Obj_table = new DataTable();
        public ServiceTypeModel.ServiceTypeRS AddUpdateSeriveType(ServiceTypeModel.ServiceTypeRQ request, string dbconnection)
        {
            ServiceTypeRS serviceTypeRS = new ServiceTypeRS();
            SqlParameter[] param = new SqlParameter[5];
            try
            {

                param[0] = new SqlParameter("service_type", SqlDbType.VarChar, 50);
                param[0].Value = request.service_type;

                param[1] = new SqlParameter("description", SqlDbType.VarChar, 100);
                param[1].Value = request.description;

                param[2] = new SqlParameter("is_active", SqlDbType.Bit);
                param[2].Value = request.is_active;

                param[3] = new SqlParameter("created_by", SqlDbType.VarChar, 30);
                param[3].Value = request.created_by;

                param[4] = new SqlParameter("service_type_id", SqlDbType.Int);
                param[4].Value = request.service_type_id;

                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_AddUpdateSeriveType", param);
                    }
                    catch (Exception ex)
                    {
                        return new ServiceTypeRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    Obj_table = Obj_ds.Tables[0];
                    if (Obj_table.Rows.Count > 0)
                    {
                        serviceTypeRS = new ServiceTypeRS()
                        {
                            message = Obj_table.Rows[0]["message"] != DBNull.Value ? Convert.ToString(Obj_table.Rows[0]["message"]) : string.Empty,
                            status = Obj_table.Rows[0]["status"] != DBNull.Value && !string.IsNullOrEmpty(Convert.ToString(Obj_table.Rows[0]["status"])) ? Convert.ToBoolean(Obj_table.Rows[0]["status"]) : false,
                            service_type_id = Obj_table.Rows[0].Field<int?>("service_type_id") ?? 0,
                        };
                    }
                    else
                    {
                        serviceTypeRS = new ServiceTypeRS()
                        {
                            message = "Something went wrong !",
                            status = false,
                            service_type_id = 0
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceTypeRS()
                {
                    //message = ex.Message,
                    message = ex.Message,
                    status = false
                };
            }

            return serviceTypeRS;
        }
        public GetServiceTypeRS GetServiceType(string dbconnection)
        {
            GetServiceTypeRS getServiceTypeRS = new GetServiceTypeRS();
            SqlParameter[] param = new SqlParameter[0];

            try
            {
                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetServiceType", param);
                    }
                    catch (Exception ex)
                    {
                        return new GetServiceTypeRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    Obj_table = Obj_ds.Tables[0];

                    if (Obj_table.Rows.Count > 0)
                    {
                        List<ServiceType> data = new List<ServiceType>();
                        foreach (DataRow row in Obj_table.Rows)
                        {
                            ServiceType service = new ServiceType
                            {
                                service_type_id = row["service_type_id"] != DBNull.Value ? Convert.ToInt32(row["service_type_id"]) : (int?)null,
                                service_type = row["service_type"] != DBNull.Value ? Convert.ToString(row["service_type"]) : string.Empty,
                                is_active = row["is_active"] != DBNull.Value ? Convert.ToBoolean(row["is_active"]) : (bool?)null,
                                description = row["description"] != DBNull.Value ? Convert.ToString(row["description"]) : string.Empty
                            };
                            data.Add(service);
                        }
                        getServiceTypeRS.status = true;
                        getServiceTypeRS.serviceTypes = data;
                        getServiceTypeRS.message = "Success";
                    }
                    else
                    {
                        getServiceTypeRS.status = false;
                        getServiceTypeRS.message = "No data found";
                    }
                }
                else
                {
                    getServiceTypeRS.status = false;
                    getServiceTypeRS.message = "No data found";
                }
            }
            catch (Exception ex)
            {
                return new GetServiceTypeRS()
                {
                    message = ex.Message,
                    status = false
                };
            }
            return getServiceTypeRS;
        }
        public ServiceNameModel.ServiceNameRS AddUpdateServiceName(ServiceNameModel.ServiceNameRQ request, string dbconnection)
        {
            ServiceNameRS serviceName = new ServiceNameRS();
            SqlParameter[] param = new SqlParameter[9];
            try
            {

                param[0] = new SqlParameter("service_name", SqlDbType.VarChar, 50);
                param[0].Value = string.IsNullOrEmpty(request.service_name) ? (object)DBNull.Value : request.service_name;

                param[1] = new SqlParameter("description", SqlDbType.VarChar, 100);
                param[1].Value = string.IsNullOrEmpty(request.description) ? (object)DBNull.Value : request.description;

                param[2] = new SqlParameter("is_active", SqlDbType.Bit);
                param[2].Value = request.is_active.HasValue ? request.is_active.Value : (object)DBNull.Value;

                param[3] = new SqlParameter("created_by", SqlDbType.VarChar, 30);
                param[3].Value = request.created_by;

                param[4] = new SqlParameter("service_type_id", SqlDbType.Int);
                param[4].Value = request.service_type_id;

                param[5] = new SqlParameter("price", SqlDbType.Decimal);
                param[5].Value = request.price;

                param[6] = new SqlParameter("service_name_id", SqlDbType.Int);
                param[6].Value = request.service_name_id;

                param[7] = new SqlParameter("api_end_point", SqlDbType.VarChar, 30);
                param[7].Value = request.api_end_point;

                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_AddUpdateServiceName", param);
                    }
                    catch (Exception ex)
                    {
                        return new ServiceNameRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    Obj_table = Obj_ds.Tables[0];
                    if (Obj_table.Rows.Count > 0)
                    {
                        serviceName = new ServiceNameRS()
                        {
                            message = Obj_table.Rows[0]["message"] != DBNull.Value ? Convert.ToString(Obj_table.Rows[0]["message"]) : string.Empty,
                            status = Obj_table.Rows[0]["status"] != DBNull.Value && !string.IsNullOrEmpty(Convert.ToString(Obj_table.Rows[0]["status"])) ? Convert.ToBoolean(Obj_table.Rows[0]["status"]) : false,
                            Id = Convert.ToInt32(Obj_table.Rows[0]["Id"])
                        };
                    }
                    else
                    {
                        serviceName = new ServiceNameRS()
                        {
                            message = "Something went wrong !",
                            status = false,
                        };
                    }
                }
                else
                {
                    serviceName = new ServiceNameRS()
                    {
                        message = "Something went wrong !",
                        status = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceNameRS()
                {
                    //message = ex.Message,
                    message = ex.Message,
                    status = false
                };
            }

            return serviceName;
        }
        public GetServiceNameRS GetServiceName(string dbconnection)
        {
            GetServiceNameRS getServiceNameRS = new GetServiceNameRS();
            SqlParameter[] param = new SqlParameter[0];

            try
            {
                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetServiceNames", param);
                    }
                    catch (Exception ex)
                    {
                        return new GetServiceNameRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    Obj_table = Obj_ds.Tables[0];

                    if (Obj_table.Rows.Count > 0)
                    {
                        List<ServiceName> data = new List<ServiceName>();
                        foreach (DataRow row in Obj_table.Rows)
                        {
                            ServiceName service = new ServiceName
                            {
                                service_type_id = row["service_type_id"] as int?,
                                service_name_id = row["service_name_id"] as int?,
                                service_type = row["service_type"] as string ?? string.Empty,
                                service_name = row["service_name"] as string ?? string.Empty,
                                description = row["description"] as string ?? string.Empty,
                                price = row["price"] != DBNull.Value ? Convert.ToDouble(row["price"]) : (double?)null,
                                is_active = row["is_active"] != DBNull.Value ? Convert.ToBoolean(row["is_active"]) : (bool?)null,
                                api_end_point = row["api_end_point"] as string ?? string.Empty,
                            };
                            data.Add(service);
                        }
                        getServiceNameRS.status = true;
                        getServiceNameRS.serviceNames = data;
                        getServiceNameRS.message = "Success";
                    }
                    else
                    {
                        getServiceNameRS.status = false;
                        getServiceNameRS.message = "No data found";
                    }
                }
                else
                {
                    getServiceNameRS.status = false;
                    getServiceNameRS.message = "No data found";
                }
            }
            catch (Exception ex)
            {
                return new GetServiceNameRS()
                {
                    message = ex.Message,
                    status = false
                };
            }
            return getServiceNameRS;
        }
        public GetVendorListRS GetVendorList(string dbconnection)
        {
            GetVendorListRS getVendorListRS = new GetVendorListRS();
            SqlParameter[] param = new SqlParameter[0];

            try
            {
                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetVendors", param);
                    }
                    catch (Exception ex)
                    {
                        return new GetVendorListRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    Obj_table = Obj_ds.Tables[0];

                    if (Obj_table.Rows.Count > 0)
                    {
                        List<GetVendorList> data = new List<GetVendorList>();
                        foreach (DataRow row in Obj_table.Rows)
                        {
                            GetVendorList getVendorList = new GetVendorList
                            {
                                id = Convert.ToInt32(row["id"]),
                                vendor_type = row["vendor_type"] as string ?? string.Empty,
                                billing_type = row["billing_type"] as string ?? string.Empty,
                                vendor_full_name = row["vendor_full_name"] as string ?? string.Empty,
                                vendor_email = row["vendor_email"] as string ?? string.Empty,
                                vendor_company_name = row["vendor_company_name"] as string ?? string.Empty,
                                vendor_code = row["vendor_code"] as string ?? string.Empty,
                                password = row["password"] as string ?? string.Empty,
                                user_name = row["user_name"] as string ?? string.Empty,
                                token = row["token"] as string ?? string.Empty,
                                pan_number = row["pan_number"] as string ?? string.Empty,
                                mobile = row["mobile"] as string ?? string.Empty,
                                office_land_line = row["office_land_line"] as string ?? string.Empty,
                                address_line = row["address_line"] as string ?? string.Empty,
                                city = row["city"] as string ?? string.Empty,
                                state = row["state"] as string ?? string.Empty,
                                zip_code = row["zip_code"] as string ?? string.Empty,
                                office_address_line = row["office_address_line"] as string ?? string.Empty,
                                office_city = row["office_city"] as string ?? string.Empty,
                                office_state = row["office_state"] as string ?? string.Empty,
                                office_zip_code = row["office_zip_code"] as string ?? string.Empty,
                                ip_address = row["ip_address"] as string ?? string.Empty,
                                created_date = row["created_date"] != DBNull.Value ? Convert.ToDateTime(row["created_date"]) : (DateTime?)null,
                                created_by = row["created_by"] as string ?? string.Empty,
                                updated_date = row["updated_date"] != DBNull.Value ? Convert.ToDateTime(row["updated_date"]) : (DateTime?)null,
                                updated_by = row["updated_by"] as string ?? string.Empty,
                                is_active = row["is_active"] != DBNull.Value ? Convert.ToBoolean(row["is_active"]) : (bool?)null

                            };
                            data.Add(getVendorList);
                        }
                        getVendorListRS.status = true;
                        getVendorListRS.getVendorLists = data;
                        getVendorListRS.message = "Success";
                    }
                    else
                    {
                        getVendorListRS.status = false;
                        getVendorListRS.message = "No data found";
                    }
                }
                else
                {
                    getVendorListRS.status = false;
                    getVendorListRS.message = "No data found";
                }
            }
            catch (Exception ex)
            {
                return new GetVendorListRS()
                {
                    message = ex.Message,
                    status = false
                };
            }
            return getVendorListRS;
        }
        public VendorServiceNameModel.VendorServiceNameRS VendorServiceName(VendorServiceNameModel.VendorServiceNameRQ request, string dbconnection)
        {
            VendorServiceNameRS vendorServiceNameRS = new VendorServiceNameRS();
            SqlParameter[] param = new SqlParameter[1];

            try
            {
                param[0] = new SqlParameter("vendor_code", SqlDbType.VarChar, 7) { Value = request.VendorCode };
                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_VendorServiceName", param);
                    }
                    catch (Exception ex)
                    {
                        return new VendorServiceNameRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    Obj_table = Obj_ds.Tables[0];

                    if (Obj_table.Rows.Count > 0)
                    {
                        List<VendorServiceList> data = new List<VendorServiceList>();
                        foreach (DataRow row in Obj_table.Rows)
                        {
                            VendorServiceList vendorService = new VendorServiceList
                            {
                                vendor_code = row["vendor_code"] as string ?? string.Empty,
                                service_type = row["service_type"] as string ?? string.Empty,
                                service_name = row["service_name"] as string ?? string.Empty,
                                price = row["price"] != DBNull.Value ? Convert.ToDouble(row["price"]) : (double?)null,
                                IsActive = Convert.ToBoolean(row["IsActive"]),
                                ServiceID = Convert.ToInt32(row["ServiceID"]),
                                service_name_id = Convert.ToInt32(row["service_name_id"]),
                                service_type_id = Convert.ToInt32(row["service_type_id"]),
                            };
                            data.Add(vendorService);
                        }
                        vendorServiceNameRS.status = true;
                        vendorServiceNameRS.vendorServiceLists = data;
                        vendorServiceNameRS.message = "Success";
                    }
                    else
                    {
                        vendorServiceNameRS.status = false;
                        vendorServiceNameRS.message = "No data found";
                    }
                }
                else
                {
                    vendorServiceNameRS.status = false;
                    vendorServiceNameRS.message = "No data found";
                }
            }
            catch (Exception ex)
            {
                return new VendorServiceNameRS()
                {
                    message = ex.Message,
                    status = false
                };
            }
            return vendorServiceNameRS;
        }
        public GetVendorAmountModel.GetVendorAmountRS GetVendorAmount(string requiredcompanyid, string dbconnection)
        {
            GetVendorAmountRS getServiceNameRS = new GetVendorAmountRS();
            SqlParameter[] param = new SqlParameter[1];
            try
            {
                param[0] = new SqlParameter("vendor_code", SqlDbType.VarChar, 50);
                param[0].Value = requiredcompanyid;
                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetVendorAmount", param);
                    }
                    catch (Exception ex)
                    {
                        return new GetVendorAmountRS()
                        {
                            message = ex.Message,
                            status = false,
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    Obj_table = Obj_ds.Tables[0];

                    if (Obj_table.Rows.Count > 0)
                    {
                        List<GetVendorAmount> data = new List<GetVendorAmount>();
                        foreach (DataRow row in Obj_table.Rows)
                        {
                            GetVendorAmount service = new GetVendorAmount
                            {
                                vendor_code = row["vendor_code"] as string ?? string.Empty,
                                wallet_amount = row["recharge_amount"] != DBNull.Value ? Convert.ToDouble(row["recharge_amount"]) : (double?)null,
                                wallet_modified_amount = row["recharge_modified_amount"] != DBNull.Value ? Convert.ToDouble(row["recharge_modified_amount"]) : (double?)null,
                            };
                            data.Add(service);
                        }
                        getServiceNameRS.status = true;
                        getServiceNameRS.getVendorAmount = data;
                        getServiceNameRS.message = "Success";
                    }
                    else
                    {
                        getServiceNameRS.status = false;
                        getServiceNameRS.message = "No data found";
                    }
                }
                else
                {
                    getServiceNameRS.status = false;
                    getServiceNameRS.message = "No data found";
                }
            }
            catch (Exception ex)
            {
                return new GetVendorAmountRS()
                {
                    message = ex.Message,
                    status = false
                };
            }
            return getServiceNameRS;
        }
        public VendorDashboardModel.VendorDashboardRS VendorDashboard(VendorDashboardModel.VendorDashboardRQ request, string requiredcompanyid, string dbconnection)
        {
            VendorDashboardRS vendorDashboardRS = new VendorDashboardRS();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                param[0] = new SqlParameter("from_date", SqlDbType.VarChar, 20) { Value = request.from_date };
                param[1] = new SqlParameter("to_date", SqlDbType.VarChar, 20) { Value = request.to_date };
                param[2] = new SqlParameter("vendor_code", SqlDbType.VarChar, 10) { Value = requiredcompanyid };

                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_VendorDashboard", param);
                    }
                    catch (Exception ex)
                    {
                        return new VendorDashboardRS
                        {
                            message = ex.Message,
                            status = false
                        };
                    }
                }
                if (Obj_ds?.Tables?.Count > 0)
                {
                    DashboardVendor dashboardVendor = new DashboardVendor
                    {
                        aadharmasked = SafeMapTable(Obj_ds, 0),
                        aadharverifications = SafeMapTable(Obj_ds, 1),
                        panbasic = SafeMapTable(Obj_ds, 2),
                        bankaccount = SafeMapTable(Obj_ds, 3),
                        drivinglicense = SafeMapTable(Obj_ds, 4),
                        gsts = SafeMapTable(Obj_ds, 5),
                        ifsc = SafeMapTable(Obj_ds, 6),
                        upi = SafeMapTable(Obj_ds, 7),
                        user_prefill = SafeMapTable(Obj_ds, 8),
                        transunion = SafeMapTable(Obj_ds, 9),
                        experian = SafeMapTable(Obj_ds, 10),
                        crif = SafeMapTable(Obj_ds, 11),
                        register_e_mandate = SafeMapTable(Obj_ds, 12),
                        pull_payment = SafeMapTable(Obj_ds, 13),
                        payment_getways = SafeMapTable(Obj_ds, 14),
                    };

                    vendorDashboardRS.status = true;
                    vendorDashboardRS.message = "Success";
                    vendorDashboardRS.vendor_code = requiredcompanyid;
                    vendorDashboardRS.dashboardVendors = new List<DashboardVendor> { dashboardVendor };
                }
                else
                {
                    vendorDashboardRS.status = false;
                    vendorDashboardRS.message = "No data found";
                }
            }
            catch (Exception ex)
            {
                return new VendorDashboardRS
                {
                    message = ex.Message,
                    status = false
                };
            }

            return vendorDashboardRS;
        }
        private List<VendorDashboard> SafeMapTable(DataSet ds, int index)
        {
            if (ds == null || ds.Tables == null || ds.Tables.Count <= index || ds.Tables[index] == null)
                return new List<VendorDashboard>();
            return MapTableToDashboard(ds.Tables[index]);
        }
        private List<VendorDashboard> MapTableToDashboard(DataTable table)
        {
            List<VendorDashboard> dashboardList = new List<VendorDashboard>();

            foreach (DataRow row in table.Rows)
            {
                dashboardList.Add(new VendorDashboard
                {
                    service_name = row["service_name"] as string ?? string.Empty,
                    success_count = row["success_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["success_count"]),
                    failed_count = row["failed_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["failed_count"]),
                    service_amount = row["ServiceAmount"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["ServiceAmount"]),
                });
            }

            return dashboardList;
        }
        public VendorServiceHistoryModel.VendorServiceHistoryRS VendorServiceHistory(VendorServiceHistoryModel.VendorServiceHistoryRQ request, string dbconnection)
        {
            VendorServiceHistoryModel.VendorServiceHistoryRS serviceHistoryRS = new VendorServiceHistoryModel.VendorServiceHistoryRS();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                param[0] = new SqlParameter("from_date", SqlDbType.VarChar, 20) { Value = request.from_date };
                param[1] = new SqlParameter("to_date", SqlDbType.VarChar, 20) { Value = request.to_date };
                param[2] = new SqlParameter("vendor_code", SqlDbType.VarChar, 20) { Value = request.vendor_code };

                using (SqlConnection con = GetDBConnection.getConnection(dbconnection))
                {
                    Obj_ds = new DataSet();
                    try
                    {
                        Obj_ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_Vendor_Service_History", param);
                        if (Obj_ds.Tables.Count > 0 && Obj_ds.Tables[0].Rows.Count > 0)
                        {
                            serviceHistoryRS.serviceHistories = new List<VendorServiceHistoryModel.ServiceHistory>();
                            serviceHistoryRS.status = true;
                            serviceHistoryRS.message = "Success";
                            serviceHistoryRS.vendor_code = request.vendor_code;
                            foreach (DataRow row in Obj_ds.Tables[0].Rows)
                            {
                                serviceHistoryRS.serviceHistories.Add(new VendorServiceHistoryModel.ServiceHistory
                                {
                                    service_name = row["service_name"] as string ?? string.Empty,
                                    description = row["description"] as string ?? string.Empty,
                                    success_count = row["success_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["success_count"]),
                                    failed_count = row["failed_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["failed_count"]),
                                    service_amount = row["service_amount"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["service_amount"]),
                                    service_assign_amt = row["service_assign_amt"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["service_assign_amt"]),
                                });
                            }
                        }
                        else
                        {
                            serviceHistoryRS.status = false;
                            serviceHistoryRS.message = "No record found.";
                        }
                    }
                    catch (Exception ex)
                    {
                        return new VendorServiceHistoryModel.VendorServiceHistoryRS
                        {
                            message = ex.Message,
                            status = false
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                return new VendorServiceHistoryModel.VendorServiceHistoryRS
                {
                    message = ex.Message,
                    status = false
                };
            }

            return serviceHistoryRS;
        }
    }
}
