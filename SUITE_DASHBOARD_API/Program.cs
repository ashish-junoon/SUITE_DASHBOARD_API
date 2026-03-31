using Junoon_LMS_API;
using LMS_BL.Interface;
using LMS_BL.Services;
using LMS_DL;
using LMS_DL.Model;
using LMS_Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.FileProviders;
using NLog;



IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json").AddJsonFile("IpValidation.json", optional: true, reloadOnChange: true)
                            .Build();


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("IpValidation.json", optional: false, reloadOnChange: true);
builder.Services.Configure<LogCleanerSettings>(builder.Configuration.GetSection("LogCleanerSettings"));

//logger
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
var MyAllowSpecificOrigine = "_MyAllowSpecificOrigine";

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    //options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
    options.MimeTypes = new[] { "text/plain", "text/css", "application/json", "application/javascript", "text/html" };
});

// Configure Brotli and Gzip compression levels
builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Optimal;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Optimal;
});
// Add services to the container.



builder.Services.Configure<ExternalPartner>(configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<AppSettingModel>(configuration);

builder.Services.ConfigureLoggerService();
builder.Services.AddHostedService<LogCleanerBackgroundService>();
//builder.Services.AddTransient<IServices, ExtraServiceServices>();
//builder.Services.AddTransient<IKycInterface, KycServices>();
//builder.Services.AddTransient<ICreditReport, CreditReportService>();
//builder.Services.AddTransient<IPayProvider, PayProviderService>();
builder.Services.AddTransient<IUser, UserService>();
//builder.Services.AddTransient<IEasebuzzKycInterface, EasebuzzKycServices>();
//builder.Services.AddTransient<IEasebuzzPayProvider, EasebuzzPayProvider>();
//builder.Services.AddTransient<IICICI_PayProvider, ICICI_PayProvider>();
builder.Services.AddTransient<IAdmin, AdminService>();
//builder.Services.AddTransient<ICommonInterface, CommonService>();
//builder.Services.AddScoped<HtmlToPdfService>();
//builder.Services.AddScoped<ValidationActionFilter>();
//builder.Services.AddTransient<IDigioService, DigioService>();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigine,
         policy =>
         {
             policy//.WithOrigins("http://localhost:5173/application", "http://localhost:5173/")
             .AllowAnyHeader()
             .AllowAnyMethod()
             .AllowAnyOrigin();
         });
});

// Enable reading headers like X-Forwarded-For
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor;
    options.KnownNetworks.Clear();  // Allow all networks
    options.KnownProxies.Clear();
});

var app = builder.Build();
app.UseResponseCompression();
app.UseStaticFiles();
//app.UseHttpsRedirection();

var loggerFactory = app.Services.GetService<ILoggerFactory>();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "Crif_Report")
//    ),
//    RequestPath = "/crif_report"   // ? public URL prefix
//});

// Configure the HTTP request pipeline.

app.UseCors(MyAllowSpecificOrigine);
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
//app.UseMiddleware<IPWhitelistMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();