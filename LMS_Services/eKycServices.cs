using System.Text.Json;
using LMS_DL;
//using LMS_DL.Model.Kyc.eKyc;
using LMS_DL.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS_Services
{
    public static class eKycServices
    {
       
        private static readonly HttpClient client = new HttpClient();
        
        //public static async Task<object>FetcheKycAsync(eKycRQModel eKycRQModel, FinbKyc finbKyc)
        //{

        //    string idtype = FrefillKYCInfo.GetEkycTypeCode(eKycRQModel.type);

        //    if (string.IsNullOrEmpty(idtype))
        //    {
        //        return new BankAccount_Verificarion.BankVerificationRS
        //        {
        //            message = "Bad Request",
        //            message_code = "fail",
        //            success = false,
        //            status_code = 100
        //        };
        //    }

        //    object prefillModelRS = ReturnObject(idtype);
        //    string url = $"https://kyc360.finb.app/api?api={finbKyc.APIkey}&type={idtype}&response_type=JSON&id={eKycRQModel.id}&id_2={eKycRQModel.id_2}";
        //    string response = string.Empty;


        //    try
        //    {
        //        //var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage result = await client.GetAsync(url);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            response = await result.Content.ReadAsStringAsync();
        //            response = response.Replace("Malformed request 400", string.Empty).Trim();
        //            prefillModelRS = ReturnDeserializeObject(idtype, response);// JsonSerializer.Deserialize<PrefillModelRS>(response);
        //            return prefillModelRS;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return new BankAccount_Verificarion.BankVerificationRS
        //        {
        //            message = ex.Message,
        //            message_code = "fail",
        //            success = false,
        //            status_code = 100
        //        };
        //    }
        //    return prefillModelRS;
        //}

        //private static object ReturnObject(string idtype)
        //{
        //    switch (idtype)
        //    {
        //        case "BID":
        //            return new BankAccount_Verificarion.BankVerificationRS();
        //        case "ADV":
        //            return new Aadhaar_Card_Validation.AadhaarCard();
        //        case "GADV2":
        //            return new Generate_Aadhaar_OTP.GenerateOTP();
        //        case "SADV2":
        //            return new Submit_Aadhaar_OTP.SubmitOTP();
        //        case "PID":
        //            return new PanCard_Lite.PanCardLite_RS();
        //        case "PCID":
        //            return new PanCard_Comprihensive.PanCardComprihensive_RS();
        //        default:
        //            return new object();
        //    }
        //}

        //private static object ReturnDeserializeObject(string idtype, string response)
        //{
        //    try
        //    {
        //        switch (idtype)
        //        {
        //            case "BID":
        //                return JsonSerializer.Deserialize<BankAccount_Verificarion.BankVerificationRS>(response);
        //            case "ADV":
        //                return JsonSerializer.Deserialize<Aadhaar_Card_Validation.AadhaarCard>(response);
        //            case "GADV2":
        //                return JsonSerializer.Deserialize<Generate_Aadhaar_OTP.GenerateOTP>(response);
        //            case "SADV2":
        //                return JsonSerializer.Deserialize<Submit_Aadhaar_OTP.SubmitOTP>(response);
        //            case "PID":
        //                return JsonSerializer.Deserialize<PanCard_Lite.PanCardLite_RS>(response);
        //            case "PCID":
        //                return JsonSerializer.Deserialize<PanCard_Comprihensive.PanCardComprihensive_RS>(response);
        //            default:
        //                return new object();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BankAccount_Verificarion.BankVerificationRS
        //        {
        //            message = ex.Message,
        //            message_code = "fail",
        //            success = false,
        //            status_code = 100
        //        };
        //    }

        //}
    }
}
