using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class LoginUserModel
    {
        public class LoginUserRQ
        {
            [JsonPropertyName("user_name")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter user name")]
            [StringLength(30, MinimumLength = 3)]
            public string? user_name { get; set; }

            [JsonPropertyName("password")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
            [StringLength(30, MinimumLength = 6)]
            public string? password { get; set; }
        }

        public class LoginUserRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }
            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("vendor_full_name")]
            public string? vendor_full_name { get; set; }

            [JsonPropertyName("vendor_code")]
            public string? vendor_code { get; set; }

            [JsonPropertyName("token")]
            public string? token { get; set; }

            [JsonPropertyName("vendor_company_name")]
            public string? vendor_company_name { get; set; }

            [JsonPropertyName("ip_address")]
            public string? ip_address { get; set; }

            [JsonPropertyName("is_active")]
            public bool? is_active { get; set; }
            
            [JsonPropertyName("role")]
            public string? role { get; set; }

        }
    }
}
