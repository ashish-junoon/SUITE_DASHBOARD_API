//using iText.Html2pdf;
//using iText.Kernel.Geom;
//using iText.Kernel.Pdf;
using LoggerLibrary;
//using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Services
{
    public static class HtmlToPdfService
    {
        /// <summary>
        /// Converts HTML string to PDF using iText7.
        /// </summary>
        /// <returns>Byte array of PDF file</returns>
        //public static string ConvertHtmlToPdfAndGetUrl(string html, string webRootPath, ILoggerManager _logger)
        //{
        //    string pdfUrl = string.Empty;
        //    try
        //    {
        //        // 1️⃣ File name
        //        var fileName = $"report_{Guid.NewGuid()}.pdf";

        //        // 2️⃣ Folder path
        //        var folderPath = System.IO.Path.Combine(webRootPath, "pdfs");
        //        if (!Directory.Exists(folderPath))
        //            Directory.CreateDirectory(folderPath);

        //        // 3️⃣ File path
        //        var filePath = System.IO.Path.Combine(folderPath, fileName);

        //        // 4️⃣ Convert HTML to PDF safely
        //        var props = new ConverterProperties();
        //        using (var pdfStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        //        {
        //            HtmlConverter.ConvertToPdf(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)), pdfStream, props);
        //        }

        //        // 5️⃣ Return public URL
        //        pdfUrl = $"{webRootPath}/pdfs/{fileName}";
        //        _logger.LogInfo($"MethodName: {MethodBase.GetCurrentMethod().Name}, Result : {pdfUrl}");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"MethodName: {MethodBase.GetCurrentMethod().Name}, Error Message : {ex.Message}");
        //    }

        //    return pdfUrl;
        //}



        //public static async Task<string> GeneratePdfAndGetUrlAsync(string html, string webRootPath, ILoggerManager _logger)
        //{
        //    string pdfUrl = string.Empty;
        //    try
        //    {
        //        using var playwright = await Playwright.CreateAsync();
        //        await using var browser = await playwright.Chromium.LaunchAsync(
        //            new BrowserTypeLaunchOptions { Headless = true });

        //        var page = await browser.NewPageAsync();
        //        await page.SetContentAsync(html, new() { WaitUntil = WaitUntilState.NetworkIdle });

        //        var pdfBytes = await page.PdfAsync(new PagePdfOptions
        //        {
        //            Format = "A4",
        //            PrintBackground = true
        //        });

        //        // 1️⃣ file name
        //        var fileName = $"report_{Guid.NewGuid()}.pdf";

        //        // 2️⃣ physical path
        //        var folderPath = System.IO.Path.Combine(webRootPath, "pdfs");
        //        if (!Directory.Exists(folderPath))
        //            Directory.CreateDirectory(folderPath);

        //        var filePath = System.IO.Path.Combine(folderPath, fileName);

        //        // 3️⃣ save pdf
        //        await File.WriteAllBytesAsync(filePath, pdfBytes);

        //        // 4️⃣ public url
        //        pdfUrl = $"{webRootPath}/pdfs/{fileName}";
        //        _logger.LogInfo($"MethodName: {MethodBase.GetCurrentMethod().Name}, Result : {pdfUrl}");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"MethodName: {MethodBase.GetCurrentMethod().Name}, Error Message : {ex.Message}");
        //    }
        //    return pdfUrl;
        //}


    }
}
