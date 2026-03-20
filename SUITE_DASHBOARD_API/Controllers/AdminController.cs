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

        [HttpPost]
        public IActionResult AddUpdateSeriveType(ServiceTypeModel.ServiceTypeRQ request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addservicetype = _admin.AddUpdateSeriveType(request);
            return Ok(addservicetype);
        }

        [HttpGet]
        public IActionResult GetServiceType()
        {
            var _result = _admin.GetServiceType();
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult AddUpdateServiceName(ServiceNameModel.ServiceNameRQ request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var servicename = _admin.AddUpdateServiceName(request);
            return Ok(servicename);
        }

        [HttpPost]
        public IActionResult GetServiceName()
        {
            var _result = _admin.GetServiceName();
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult GetVendorList()
        {
            var _result = _admin.GetVendorList();
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult VendorServiceName(VendorServiceNameModel.VendorServiceNameRQ request)
        {
            var _result = _admin.VendorServiceName(request);
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult VendorDashboard(VendorDashboardModel.VendorDashboardRQ request, string companyid)
        {
            var _result = _admin.VendorDashboard(request, companyid);
            return Ok(_result);
        }
    }
}
