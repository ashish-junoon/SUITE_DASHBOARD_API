using LMS_BL.Interface;
using LMS_DL;
using LMS_DL.Model.Admin;
using LMS_DL.Repository;
using LoggerLibrary;
using Microsoft.Extensions.Options;
namespace LMS_BL.Services
{
    public class AdminService(IOptions<AppSettingModel> _app, ILoggerManager _log) : IAdmin
    {
        private readonly IOptions<AppSettingModel> _appsetting = _app ?? throw new ArgumentNullException(nameof(_app));
        private readonly ILoggerManager _logger = _log ?? throw new ArgumentNullException(nameof(_log));
        AdminRepository? adminDbLayer;
        public ServiceTypeModel.ServiceTypeRS AddUpdateSeriveType(ServiceTypeModel.ServiceTypeRQ request)
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.AddUpdateSeriveType(request, _appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
        public ServiceTypeModel.GetServiceTypeRS GetServiceType()
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.GetServiceType(_appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
        public ServiceNameModel.ServiceNameRS AddUpdateServiceName(ServiceNameModel.ServiceNameRQ request)
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.AddUpdateServiceName(request, _appsetting.Value.ConnectionStrings?.dbconnection ?? "" ?? "");
        }

        public ServiceNameModel.GetServiceNameRS GetServiceName()
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.GetServiceName(_appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }

        public GetVendorListModel.GetVendorListRS GetVendorList()
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.GetVendorList(_appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
        public VendorServiceNameModel.VendorServiceNameRS VendorServiceName(VendorServiceNameModel.VendorServiceNameRQ request)
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.VendorServiceName(request, _appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
        public VendorDashboardModel.VendorDashboardRS VendorDashboard(VendorDashboardModel.VendorDashboardRQ request, string requiredcompanyid)
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.VendorDashboard(request, requiredcompanyid, _appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
    }
}