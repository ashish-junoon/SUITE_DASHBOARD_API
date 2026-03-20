using LMS_BL.Interface;
using LMS_DL;
using LMS_DL.Model.UserModel;
using LMS_DL.Repository;
using LoggerLibrary;
using Microsoft.Extensions.Options;

namespace LMS_BL.Services
{
    public class UserService : IUser
    {
        private readonly IOptions<AppSettingModel> _appsetting;
        private readonly ILoggerManager _logger;
        UserRepository registerUserDbLayer;
        private readonly AppSettingModel _mailSettings;

        public UserService(IOptions<AppSettingModel> _app, ILoggerManager _log, IOptions<AppSettingModel> mailSettings)
        {
            _appsetting = _app ?? throw new ArgumentNullException(nameof(_app));
            _logger = _log ?? throw new ArgumentNullException(nameof(_log));
            _mailSettings = mailSettings.Value ?? throw new ArgumentNullException(nameof(mailSettings));

        }
        public VendorRegisterModel.VendorRegisterRS VendorRegister(VendorRegisterModel.VendorRegisterRQ loginUserRQ)
        {
            registerUserDbLayer = new();
            return registerUserDbLayer.VendorRegister(loginUserRQ, _appsetting.Value.ConnectionStrings.dbconnection);

        }

        //public AssignServiceModel.AssignServiceRS AssignService(AssignServiceModel.AssignServiceRQ request)
        //{
        //    registerUserDbLayer = new();
        //    return registerUserDbLayer.AssignService(request, _appsetting.Value.ConnectionStrings.dbconnection);
        //}
        public AssignServiceModel_V1.AssignServiceRS AssignService(AssignServiceModel_V1.AssignServiceRQ request)
        {
            registerUserDbLayer = new();
            return registerUserDbLayer.AssignService(request, _appsetting.Value.ConnectionStrings.dbconnection);
        }

        public GetVendorCodeModel.GetVendorCodeRS GetVendorCode()
        {
            registerUserDbLayer = new();
            return registerUserDbLayer.GetVendorCode(_appsetting.Value.ConnectionStrings.dbconnection);
        }

        public LoginUserModel.LoginUserRS LoginUser(LoginUserModel.LoginUserRQ loginUserRQ)
        {
            registerUserDbLayer = new();
            return registerUserDbLayer.LoginUser(loginUserRQ, _appsetting.Value.ConnectionStrings.dbconnection);
        }
        public UpdateStatusModel.UpdateStatusRS UpdateStatus(UpdateStatusModel.UpdateStatusRQ request)
        {
            registerUserDbLayer = new();
            return registerUserDbLayer.UpdateStatus(request, _appsetting.Value.ConnectionStrings.dbconnection);
        }
    }
}