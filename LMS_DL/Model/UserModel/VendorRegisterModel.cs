using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class VendorRegisterModel
    {
        public class VendorRegisterRQ
        {
            [JsonPropertyName("vendor_full_name")]
            public string vendor_full_name { get; set; } = string.Empty;

            [JsonPropertyName("vendor_email")]
            public string vendor_email { get; set; } = string.Empty;

            [JsonPropertyName("vendor_company_name")]
            public string vendor_company_name { get; set; } = string.Empty;

            [JsonPropertyName("pan_number")]
            public string pan_number { get; set; } = string.Empty;

            [JsonPropertyName("mobile")]
            public string mobile { get; set; } = string.Empty;

            [JsonPropertyName("office_land_line")]
            public string office_land_line { get; set; } = string.Empty;

            [JsonPropertyName("address_line")]
            public string address_line { get; set; } = string.Empty;

            [JsonPropertyName("city")]
            public string city { get; set; } = string.Empty;

            [JsonPropertyName("state")]
            public string state { get; set; } = string.Empty;

            [JsonPropertyName("zip_code")]
            public string zip_code { get; set; } = string.Empty;

            [JsonPropertyName("office_address_line")]
            public string office_address_line { get; set; } = string.Empty;

            [JsonPropertyName("office_city")]
            public string office_city { get; set; } = string.Empty;

            [JsonPropertyName("office_state")]
            public string office_state { get; set; } = string.Empty;

            [JsonPropertyName("office_zip_code")]
            public string office_zip_code { get; set; } = string.Empty;

            [JsonPropertyName("ip_address")]
            public string ip_address { get; set; } = string.Empty;

            [JsonPropertyName("created_by")]
            public string created_by { get; set; } = string.Empty;

            [JsonPropertyName("is_active")]
            public bool is_active { get; set; } = false;

            [JsonPropertyName("id")]
            public int id { get; set; } = 0;

            [JsonPropertyName("vendor_type")]
            public string vendor_type { get; set; } = string.Empty;

            [JsonPropertyName("billing_type")]
            public string billing_type { get; set; } = string.Empty;

        }

        public class VendorRegisterRS
        {
            [JsonProperty("status")]
            public bool? status { get; set; }

            [JsonProperty("message")]
            public string? message { get; set; }

            [JsonProperty("id")]
            public int? id { get; set; }
            
            [JsonProperty("vendor_code")]
            public string? vendor_code { get; set; }
        }
    }
}
