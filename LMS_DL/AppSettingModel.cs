using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL
{
    public class AppSettingModel
    {
        public Logging? Logging { get; set; }
        public string? LogFilePath { get; set; }
        public string? AllowedHosts { get; set; }
        public Connectionstrings? ConnectionStrings { get; set; }
        public List<SMTP>? SMTP { get; set; }
        public SMS? SMS { get; set; }
        public FinbKyc? finbKyc { get; set; }
        public RazorPay? razorPay { get; set; }
        public Serilog? Serilog { get; set; }
        public Easebuzz? easebuzz { get; set; }
        public EasebuzzPay? easebuzzPay { get; set; }
        public EasebuzzService? easebuzzService { get; set; }
        public EasebuzzEmandate? easebuzzEmandate { get; set; }
        public ICICIEmandate? iCICIEmandate { get; set; }
        public DigioAuth? DigioAuth { get; set; }
    }

    public class DigioAuth
    {
        public bool? Test_BaseUrl { get; set; }
        public bool? clientId { get; set; }
        public bool? secretId { get; set; }

    }
    public class EasebuzzService
    {
        public bool? verifyService { get; set; }
        public bool? gatewayService { get; set; }
        public bool? emandateService { get; set; }
        public bool? wireApiService { get; set; }
    }
    public class Easebuzz
    {
        public string? baseurl { get; set; }
        public string? key { get; set; }
        public string? salt { get; set; }
    }
    public class EasebuzzPay
    {
        public string? baseurl { get; set; }
        public string? key { get; set; }
        public string? salt { get; set; }
    }

    public class EasebuzzEmandate
    {
        public string? baseurl { get; set; }
        public string? key { get; set; }
        public string? salt { get; set; }
    }
    public class ICICIEmandate
    {
        public string? baseurl { get; set; }
        public string? merchantid { get; set; }
        public string? salt { get; set; }
    }
    public class Logging
    {
        public Loglevel? LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string? Default { get; set; }
        public string? MicrosoftAspNetCore { get; set; }
    }

    public class Connectionstrings
    {
        public string? dbconnection { get; set; }
        public string? dbconnectiontest { get; set; }
        public string? dbconnectionlive { get; set; }
    }

    public class SMTP
    {
        public string? Product { get; set; }
        public string? Email { get; set; }
        public string EmailName { get; set; }
        public string? Password { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string? Host { get; set; }
        public string? EmailCC { get; set; }
        public string? EmailCCName { get; set; }
        public string? EmailSubject { get; set; }

    }

    public class SMS
    {
        public string? EndPointOTP { get; set; }
        public string? EndPointSMS { get; set; }
        public string? RegisterUserConsentTemplate { get; set; }
        public string? LoanProductConsentTemplate { get; set; }
        public string? DocumentSigningConsentTemplate { get; set; }
        public string? CreditApprovedNotification { get; set; }
        public string? UpdateDisbursementNotification { get; set; }
        public string? EMIReminderNotification { get; set; }
        public int? OtpExpiryMinute { get; set; } = 10;
        public string? Authkey { get; set; }
        public bool Enable { get; set; }
    }
    public class FinbKyc
    {
        public string? EndPoint { get; set; }
        public string? EndPointTotalKyc { get; set; }
        public string? APIkey { get; set; }
        public string? APIkeyTest { get; set; }
        public bool Enable { get; set; }
    }
    public class RazorPay: FinbKyc
    {
        public string? APISecret { get; set; }
    }

    public class Serilog
    {
        public string[]? Using { get; set; }
        public Minimumlevel? MinimumLevel { get; set; }
        public Writeto[]? WriteTo { get; set; }
    }

    public class Minimumlevel
    {
        public string? Default { get; set; }
    }

    public class Writeto
    {
        public string? Name { get; set; }
        public Args? Args { get; set; }
    }

    public class Args
    {
        public string? path { get; set; }
        public string? rollingInterval { get; set; }
        public string? outputTemplate { get; set; }
    }
}
