using System.ComponentModel.DataAnnotations;
using LMS_BL.Interface;
using LMS_DL;
using LMS_DL.Model.Admin;
using LoggerLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API_SERVICES.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOptions<AppSettingModel> _appsetting;
        private readonly ILoggerManager _logger;
        private readonly IAdmin _admin;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminController(IOptions<AppSettingModel> _app, ILoggerManager _log, IAdmin employee, IHttpContextAccessor httpContextAccessor)
        {
            _appsetting = _app ?? throw new ArgumentNullException(nameof(_app));
            _logger = _log ?? throw new ArgumentNullException(nameof(_log));
            this._admin = employee ?? throw new ArgumentNullException(nameof(employee));
            this.httpContextAccessor = httpContextAccessor;
        }

        //[HttpPost]
        //public IActionResult RegisterEmployee(AdminRegisterModel.RegisterModelRQ registerModelRQ)
        //{
        //    //var IP = httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        //    var register = _admin.RegisterEmployee(registerModelRQ);
        //    return Ok(register);
        //}

        [HttpPost]
        public IActionResult AddUpdateSeriveType(ServiceTypeModel.ServiceTypeRQ request, [FromHeader(Name = "token")] string requiredHeader = "anonyms", [FromHeader(Name = "companyid")] string requiredcompanyid = "anonyms")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addservicetype = _admin.AddUpdateSeriveType(request);
            return Ok(addservicetype);
        }

        [HttpGet]
        public IActionResult GetServiceType([FromHeader(Name = "token")] string requiredHeader = "anonyms", [FromHeader(Name = "companyid")] string requiredcompanyid = "anonyms")
        {
            var _result = _admin.GetServiceType();
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult AddUpdateServiceName(ServiceNameModel.ServiceNameRQ request, [FromHeader(Name = "token")] string requiredHeader = "anonyms", [FromHeader(Name = "companyid")] string requiredcompanyid = "anonyms")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var servicename = _admin.AddUpdateServiceName(request);
            return Ok(servicename);
        }

        [HttpPost]
        public IActionResult GetServiceName([FromHeader(Name = "token")] string requiredHeader = "anonyms", [FromHeader(Name = "companyid")] string requiredcompanyid = "anonyms")
        {
            var _result = _admin.GetServiceName();
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult GetVendorList([FromHeader(Name = "token")] string requiredHeader = "anonyms", [FromHeader(Name = "companyid")] string requiredcompanyid = "anonyms")
        {
            var _result = _admin.GetVendorList();
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult VendorServiceName(VendorServiceNameModel.VendorServiceNameRQ request, [FromHeader(Name = "token")] string requiredHeader = "anonyms", [FromHeader(Name = "companyid")] string requiredcompanyid = "anonyms")
        {
            var _result = _admin.VendorServiceName(request);
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult GetVendorAmount([FromHeader(Name = "token")][Required] string requiredHeader, [FromHeader(Name = "companyid")][Required] string requiredcompanyid)
        {
            var _result = _admin.GetVendorAmount(requiredcompanyid);
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult VendorDashboard(VendorDashboardModel.VendorDashboardRQ request, [FromHeader(Name = "token")][Required] string requiredHeader, [FromHeader(Name = "companyid")][Required] string requiredcompanyid)
        {
            var _result = _admin.VendorDashboard(request, requiredcompanyid);
            return Ok(_result);
        }


        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult SetPermission(SetPermissionModel.SetPermissionRQ setPermissionRS)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.SetPermission(setPermissionRS);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult GetPermission(GetPermissionModel.GetPermissionRQ getPermissionRQ)
        //{
        //    var getresponce = _admin.GetPermission(getPermissionRQ);
        //    return Ok(getresponce);
        //}



        ////public bool IsValidEmailRegex(string email)
        ////{
        ////    string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        ////    return Regex.IsMatch(email, pattern);
        ////}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult LoginEmployee(AdminLoginModel.AdminLoginRQ adminLoginRQ)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var responce = _admin.LoginEmployee(adminLoginRQ);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult LoanCollection(LoanCollectionModel.LoanCollectionRQ request)
        //{
        //    var responce = _admin.LoanCollection(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult LoanCollection_V1(LoanCollectionModel.LoanCollectionRQ_V1 request)
        //{
        //    var responce = _admin.LoanCollection_V1(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult GetEmployeeList(GetEmployeeModel.GetEmployeeRQ request)
        //{
        //    var responce = _admin.GetEmployeeList(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult GetEmployeeDetails(EmployeeDetailsRQ  request)
        //{
        //    var responce = _admin.GetEmployeeDetails(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult UpdateEmployee(UpdateEmployeeRQ request)
        //{
        //    var responce = _admin.UpdateEmployee(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult AddLeadHistory(AddLeadHistoryRQ request)
        //{
        //    var responce = _admin.AddLeadHistory(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult AddBranch(AddBranchRQ request)
        //{
        //    var responce = _admin.AddBranch(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult UpdateBranch(UpdateBranchRQ request)
        //{
        //    var responce = _admin.UpdateBranch(request);
        //    return Ok(responce);
        //}
        //[HttpPost]
        //public IActionResult GetBranchList(GetBranchRQ request)
        //{
        //    var responce = _admin.GetBranchList(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult GetStateCityBranch(GetStateCityBranchRQ request)
        //{
        //    var responce = _admin.GetStateCityBranch(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //public IActionResult Dashboard(DashboardRQ request)
        //{
        //    var responce = _admin.Dashboard(request);
        //    return Ok(responce);
        //}


        //[HttpPost]
        //public IActionResult Dashboard_V1(DashboardRQ request)
        //{
        //    var responce = _admin.Dashboard(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult ManualLoanCollection(UpdateLoanCollectionRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.ManualLoanCollection(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult AddOtherDocuments(OtherDocumentModelRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.AddOtherDocuments(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult CibilManualUpdate(CibilUpdateRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.CibilManualUpdate(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult ENachManualUpdate(E_NachUpdateRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.ENachManualUpdate(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult ManualCollectionUpdate(ManualCollectionRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.ManualCollectionUpdate(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult GetAllActiveloans(GetAllActiveLoansModel.ActiveLoansRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.GetAllActiveloans(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult GetAllActiveloans_V1(GetAllActiveLoansModel.ActiveLoansRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.GetAllActiveloans_V1(request);
        //    return Ok(responce);
        //}

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationActionFilter))]
        //public IActionResult ManualCollectionUpdate_V1(ManualCollectionRQ request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var responce = _admin.ManualCollectionUpdate_V1(request);
        //    return Ok(responce);
        //}
    }
}
