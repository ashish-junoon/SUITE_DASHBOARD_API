using System.ComponentModel.DataAnnotations;
using LMS_BL.Interface;
using LMS_DL;
using LMS_DL.Model.UserModel;
using LoggerLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static LMS_DL.Model.UserModel.VendorRegisterModel;


namespace API_SERVICES.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOptions<AppSettingModel> _appsetting;
        private readonly ILoggerManager _logger;
        private readonly IUser _user;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserController(IOptions<AppSettingModel> _app, ILoggerManager _log, IUser user, IHttpContextAccessor httpContextAccessor)
        {
            _appsetting = _app ?? throw new ArgumentNullException(nameof(_app));
            _logger = _log ?? throw new ArgumentNullException(nameof(_log));
            this._user = user ?? throw new ArgumentNullException(nameof(user));
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpPost]
        public IActionResult LoginUser(LoginUserModel.LoginUserRQ request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _result = _user.LoginUser(request);
            return Ok(_result);
        }

        [HttpPost]
        public async Task<ActionResult> VendorRegister(VendorRegisterModel.VendorRegisterRQ request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _result = _user.VendorRegister(request);
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult AssignService(AssignServiceModel.AssignServiceRQ request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _result = _user.AssignService(request);
            return Ok(_result);
        }

        [HttpGet]
        public IActionResult GetVendorCode()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _result = _user.GetVendorCode();
            return Ok(_result);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateStatus(UpdateStatusModel.UpdateStatusRQ request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _result = _user.UpdateStatus(request);
            return Ok(_result);
        }

    }
}
