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
        public VendorServiceHistoryModel.VendorServiceHistoryRS VendorServiceHistory(VendorServiceHistoryModel.VendorServiceHistoryRQ request)
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.VendorServiceHistory(request, _appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
        public ChangePasswordModel.ChangePasswordRS ChangePassword(ChangePasswordModel.ChangePasswordRQ request)
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.ChangePassword(request, _appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
        public UploadVendorDocumentModel.UploadVendorDocumentRS UploadVendorDocument(UploadVendorDocumentModel.UploadVendorDocumentRQ request)
        {
            adminDbLayer = new(_logger);
            UploadVendorDocumentModel.UploadVendorDocumentRS vendorDocumentRS = new UploadVendorDocumentModel.UploadVendorDocumentRS();
            try
            {
                string folderPath = "Documents";
                if (request.file != null && request.file.Length > 0)
                {
                    string filename = request.file.FileName;
                    string extenssion = Path.GetExtension(filename);
                    string filenamewithoutextension = Path.GetFileNameWithoutExtension(filename);
                    string newfilename = filenamewithoutextension + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extenssion;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    else
                    {
                        string filePath = Path.Combine(folderPath, newfilename);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            request.file.CopyTo(stream);
                        }
                        vendorDocumentRS.status = true;
                        vendorDocumentRS.message = "File uploaded successfully.";
                        vendorDocumentRS = adminDbLayer.UploadVendorDocument(request, newfilename, _appsetting.Value.ConnectionStrings?.dbconnection ?? "");
                    }
                }
            }
            catch (Exception ex)
            {
                vendorDocumentRS.status = false;
                vendorDocumentRS.message = ex.Message;
            }

            return vendorDocumentRS;
        }
        public GetVendorDocumentModel.GetVendorDocumentRS GetVendorDocument(GetVendorDocumentModel.GetVendorDocumentRQ request)
        {
            adminDbLayer = new(_logger);
            return adminDbLayer.GetVendorDocument(request, _appsetting.Value.ConnectionStrings?.dbconnection ?? "");
        }
    }
}