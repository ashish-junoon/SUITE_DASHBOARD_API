
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

        GetVendorAmountModel.GetVendorAmountRS GetVendorAmount(string requiredcompanyid);

        VendorDashboardModel.VendorDashboardRS VendorDashboard(VendorDashboardModel.VendorDashboardRQ request , string requiredcompanyid);

        //SetPermissionModel.SetPermissionRS SetPermission(SetPermissionModel.SetPermissionRQ setPermissionRQ);
        //GetPermissionModel.GetPermissionRS GetPermission(GetPermissionModel.GetPermissionRQ getPermissionRQ);
        //AdminLoginModel.AdminLoginRS LoginEmployee(AdminLoginModel.AdminLoginRQ adminLoginRQ);
        //LoanCollectionModel.LoanCollectionRS LoanCollection(LoanCollectionModel.LoanCollectionRQ request);
        //LoanCollectionModel.LoanCollectionRS LoanCollection_V1(LoanCollectionModel.LoanCollectionRQ_V1 request);
        //GetEmployeeModel.GetEmployeeRS GetEmployeeList(GetEmployeeModel.GetEmployeeRQ request);
        //GetEmployeeDetailsModel.EmployeeDetailsRS GetEmployeeDetails(GetEmployeeDetailsModel.EmployeeDetailsRQ request);
        //UpdateEmployeeModel.UpdateEmployeeRS UpdateEmployee(UpdateEmployeeModel.UpdateEmployeeRQ request);
        //AddLeadHistoryModel.AddLeadHistoryRS AddLeadHistory(AddLeadHistoryModel.AddLeadHistoryRQ request);
        //AddBranchModel.AddBranchRS AddBranch(AddBranchModel.AddBranchRQ request);
        //UpdateBranchModel.UpdateBranchRS UpdateBranch(UpdateBranchModel.UpdateBranchRQ request);
        //GetBranchModel.GetBranchRS GetBranchList(GetBranchModel.GetBranchRQ request);
        //GetStateCityBranchListModel.GetStateCityBranchRS GetStateCityBranch(GetStateCityBranchListModel.GetStateCityBranchRQ request);
        //DashboardModel.DashboardRS Dashboard(DashboardModel.DashboardRQ request);
        //DashboardModel.DashboardRS Dashboard_V1(DashboardModel.DashboardRQ request);

        //UpdateLoanCollectionModel.UpdateLoanCollectionRS ManualLoanCollection(UpdateLoanCollectionModel.UpdateLoanCollectionRQ request);
        //OtherDocumentModel.OtherDocumentModelRS AddOtherDocuments(OtherDocumentModel.OtherDocumentModelRQ request);
        //CibilUpdateModel.CibilUpdateRS CibilManualUpdate(CibilUpdateModel.CibilUpdateRQ request);
        //E_NachUpdateModel.E_NachUpdateRS ENachManualUpdate(E_NachUpdateModel.E_NachUpdateRQ request);
        //ManualCollectionUpdate.ManualCollectionRS ManualCollectionUpdate(ManualCollectionUpdate.ManualCollectionRQ request);
        //GetAllActiveLoansModel.ActiveloansRS GetAllActiveloans(GetAllActiveLoansModel.ActiveLoansRQ request);

        //GetAllActiveLoansModel.ActiveloansRS GetAllActiveloans_V1(GetAllActiveLoansModel.ActiveLoansRQ request);
        //ManualCollectionUpdate.ManualCollectionRS ManualCollectionUpdate_V1(ManualCollectionUpdate.ManualCollectionRQ request);
    }
}
