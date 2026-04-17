using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class GetVendorListModel
    {

        public class GetVendorListRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("getVendorLists")]
            public List<GetVendorList> getVendorLists { get; set; }
        }
        public class GetVendorList
        {
            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("vendor_type")]
            public string vendor_type { get; set; } = string.Empty;

            [JsonProperty("billing_type")]
            public string billing_type { get; set; } = string.Empty;

            [JsonProperty("vendor_full_name")]
            public string vendor_full_name { get; set; } = string.Empty;

            [JsonProperty("vendor_email")]
            public string vendor_email { get; set; } = string.Empty;

            [JsonProperty("vendor_company_name")]
            public string vendor_company_name { get; set; } = string.Empty;

            [JsonProperty("vendor_code")]
            public string vendor_code { get; set; } = string.Empty;

            [JsonProperty("password")]
            public string password { get; set; } = string.Empty;

            [JsonProperty("user_name")]
            public string user_name { get; set; } = string.Empty;

            [JsonProperty("token")]
            public string token { get; set; } = string.Empty;

            [JsonProperty("pan_number")]
            public string pan_number { get; set; } = string.Empty;

            [JsonProperty("mobile")]
            public string mobile { get; set; } = string.Empty;

            [JsonProperty("office_land_line")]
            public string office_land_line { get; set; } = string.Empty;

            [JsonProperty("address_line")]
            public string address_line { get; set; } = string.Empty;

            [JsonProperty("city")]
            public string city { get; set; } = string.Empty;

            [JsonProperty("state")]
            public string state { get; set; } = string.Empty;

            [JsonProperty("zip_code")]
            public string zip_code { get; set; } = string.Empty;

            [JsonProperty("office_address_line")]
            public string office_address_line { get; set; } = string.Empty;

            [JsonProperty("office_city")]
            public string office_city { get; set; } = string.Empty;

            [JsonProperty("office_state")]
            public string office_state { get; set; } = string.Empty;

            [JsonProperty("office_zip_code")]
            public string office_zip_code { get; set; } = string.Empty;

            [JsonProperty("ip_address")]
            public string ip_address { get; set; } = string.Empty;

            [JsonProperty("created_date")]
            public DateTime? created_date { get; set; }

            [JsonProperty("created_by")]
            public string created_by { get; set; } = string.Empty;

            [JsonProperty("updated_date")]
            public DateTime? updated_date { get; set; }

            [JsonProperty("updated_by")]
            public string updated_by { get; set; } = string.Empty;

            [JsonProperty("is_active")]
            public bool? is_active { get; set; }

            [JsonPropertyName("role")]
            public string? role { get; set; }
        }
    }
}
