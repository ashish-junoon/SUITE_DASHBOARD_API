using LMS_DL;
using LMS_DL.Repository;
using LoggerLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Junoon_LMS_API
{
    public class IPWhitelistMiddleware
    {
        private readonly ILoggerManager _logger;
        private readonly RequestDelegate _next;
        //private readonly List<string> _allowedIPs;
        private readonly IOptions<ExternalPartner> _appexter;
        private readonly IOptions<AppSettingModel> _options;
        public IPWhitelistMiddleware(RequestDelegate next, IConfiguration config, ILoggerManager _log, IOptions<ExternalPartner> _app, IOptions<AppSettingModel> options)
        {
            _next = next;
            _logger = _log ?? throw new ArgumentNullException();
            _appexter = _app ?? throw new ArgumentNullException();
            _options = options;
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    await _next(context);

        //    var endpoint = context.GetEndpoint();
        //    if (endpoint is RouteEndpoint routeEndpoint)
        //    {
        //        var controllerName = routeEndpoint.RoutePattern.RequiredValues["controller"]?.ToString();
        //        var actionName = routeEndpoint.RoutePattern.RequiredValues["action"]?.ToString();

        //        if (!string.IsNullOrEmpty(controllerName))
        //            context.Response.Headers.Add("X-Controller-Name", controllerName);

        //        if (!string.IsNullOrEmpty(actionName))
        //            context.Response.Headers.Add("X-Action-Name", actionName);
        //    }
        //}
        //public static string? GetActionName(Endpoint endpoint)
        //{
        //    if (endpoint is RouteEndpoint routeEndpoint)
        //    {
        //        var methodInfo = routeEndpoint.Metadata.GetMetadata<MethodInfo>();
        //        if (methodInfo != null)
        //        {
        //            return methodInfo.Name;
        //        }
        //    }
        //    return null;
        //}

        public async Task InvokeAsync(HttpContext context)
        {
            var methodName = string.Empty;
            var endpoint = context.GetEndpoint();
            var allowAnyIP = endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>();
            if (endpoint != null)
            {
                var routeData = context.GetRouteData();
                var controllerName = routeData.Values["controller"]?.ToString();
                methodName = routeData.Values["action"]?.ToString();
                if (!string.IsNullOrEmpty(controllerName) && !string.IsNullOrEmpty(methodName))
                {
                    _logger.LogInfo($"Controller: {controllerName}, Action: {methodName}");
                }
                else
                {
                    _logger.LogError($"Controller and action name not found: {controllerName}, Action: {methodName}");
                }
            }


            //var request = context.Request;
            //var body = await new StreamReader(request.Body).ReadToEndAsync();
            //var actionDescriptor = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();
            //if (actionDescriptor != null)
            //{
            //    var controllerName = actionDescriptor.ControllerName;
            //    methodName = actionDescriptor.MethodInfo.Name;
            //    _logger.LogInfo($"Controller: {controllerName},  Method: {methodName}");
            //}

            if (allowAnyIP != null)
            {
                await _next(context);
                return;
            }
            var path = context.Request.Path.Value?.ToLower();
            if (path.StartsWith("/webhook") || path.Contains("webhook"))
            {
                await _next(context);
                return;
            }
            string? vendor = null;
            string? token = null;
            if (context!.Request!.Headers != null)
            {
                token = context.Request.Headers["token"];
                vendor = context.Request.Headers["companyid"];
            }
            if (context.Request.Headers != null)
            {
                ExternalPartner? partners = CommonRequestRepository.GetPartnersDetails(token, vendor, methodName, _options.Value.ConnectionStrings?.dbconnection ?? string.Empty, _logger);
                //CommonRequestRepository.SaveVendorServiceRequest(vendor, methodName, body , _options.Value.ConnectionStrings?.dbconnection ?? string.Empty, _logger);
                if (partners?.message == "401 Unauthorized: IP not allowed." && partners.status == false)
                {
                    _logger.LogInfo($"Invalid token: {token} and vendor not allowed : {vendor}");
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("401 Unauthorized: IP not allowed.");
                    return;
                }
                else if (partners?.status == false || (!string.IsNullOrEmpty(partners?.message)))
                {
                    _logger.LogInfo($"Partner validation failed for token: {token}, vendor: {vendor}, message: {partners?.message}");
                    var responseObj = new
                    {
                        status = partners?.status,
                        message = partners?.message
                    };
                    string jsonResponse = JsonConvert.SerializeObject(responseObj);
                    await context.Response.WriteAsync(jsonResponse);
                    return;
                }
            }
            await _next(context);
        }

        //public async Task<string> RequestExternalApi(VendorRequest body)
        //{
        //    using var client = new HttpClient();
        //    var json = JsonConvert.SerializeObject(body);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    return await result.Content.ReadAsStringAsync();
        //}

        //public async Task ResponceApiResponse(string response)
        //{
        //    var parsed = JsonConvert.DeserializeObject<dynamic>(response);
        //    Console.WriteLine($"API Response Status: {parsed.status}");
        //    // DB save / logging etc.
        //}

    }


}
