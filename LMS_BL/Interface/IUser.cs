using LMS_DL.Model.UserModel;

namespace LMS_BL.Interface
{
    public interface IUser
    {
        //// -----------------  Write Code Namrata---------------------------------
        LoginUserModel.LoginUserRS LoginUser(LoginUserModel.LoginUserRQ _request);
        VendorRegisterModel.VendorRegisterRS VendorRegister(VendorRegisterModel.VendorRegisterRQ request);
        //AssignServiceModel.AssignServiceRS AssignService(AssignServiceModel.AssignServiceRQ request);
        AssignServiceModel_V1.AssignServiceRS AssignService(AssignServiceModel_V1.AssignServiceRQ request);
        GetVendorCodeModel.GetVendorCodeRS GetVendorCode();
        UpdateStatusModel.UpdateStatusRS UpdateStatus(UpdateStatusModel.UpdateStatusRQ request);
    }
}
