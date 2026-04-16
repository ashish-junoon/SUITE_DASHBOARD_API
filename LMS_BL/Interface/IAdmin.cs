
using LMS_DL.Model.Admin;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BL.Interface
{
    public interface IAdmin
    {
        ServiceTypeModel.ServiceTypeRS AddUpdateSeriveType(ServiceTypeModel.ServiceTypeRQ request);
        ServiceTypeModel.GetServiceTypeRS GetServiceType();
        ServiceNameModel.ServiceNameRS AddUpdateServiceName(ServiceNameModel.ServiceNameRQ request);
        ServiceNameModel.GetServiceNameRS GetServiceName();
        GetVendorListModel.GetVendorListRS GetVendorList();
        VendorServiceNameModel.VendorServiceNameRS VendorServiceName(VendorServiceNameModel.VendorServiceNameRQ request);
        VendorDashboardModel.VendorDashboardRS VendorDashboard(VendorDashboardModel.VendorDashboardRQ request, string requiredcompanyid);
        VendorServiceHistoryModel.VendorServiceHistoryRS VendorServiceHistory(VendorServiceHistoryModel.VendorServiceHistoryRQ request);
    }
}
