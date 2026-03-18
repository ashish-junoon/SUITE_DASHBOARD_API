using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class GetVendorCodeModel
    {
        public class GetVendorCodeRS
        {
            [JsonPropertyName("status")]
            public bool? status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("getVendorCodes")]
            public List<GetVendorCode> getVendorCodes { get; set; }
        }
        public class GetVendorCode
        {
            [JsonPropertyName("user_name")]
            public string? user_name { get; set; }

            [JsonPropertyName("vendor_code")]
            public string? vendor_code { get; set; }
        }

    }
}
