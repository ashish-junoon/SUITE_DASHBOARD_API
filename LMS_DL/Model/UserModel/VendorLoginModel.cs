using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class VendorLoginModel
    {
        public class VendorLoginRQ
        {
            [JsonPropertyName("UserName")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter username Code")]
            [StringLength(30, MinimumLength = 3)]
            public string? UserName { get; set; }

            [JsonPropertyName("Password")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
            [StringLength(30, MinimumLength = 8)]
            public string? Password { get; set; }

        }

        public class VendorLoginRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("vendorLogin")]
            public VendorLogin vendorLogin { get; set; }

            [JsonPropertyName("services")]
            public List<AssignServices> services { get; set; }  

        }
        public class VendorLogin
        {
            [JsonPropertyName("vendorname")]
            public string? vendorname { get; set; }

            [JsonPropertyName("vendorcode")]
            public string? vendorcode { get; set; }

            [JsonPropertyName("companyname")]
            public string? companyname { get; set; }

            [JsonPropertyName("token")]
            public string? token { get; set; }

            [JsonPropertyName("ipaddress")]
            public string? ipaddress { get; set; }

            [JsonPropertyName("isactive")]
            public bool? isactive { get; set; }

            [JsonPropertyName("vendorfirstname")]
            public string? vendorfirstname { get; set; }

            [JsonPropertyName("vendorlastname")]
            public string? vendorlastname { get; set; }

            [JsonPropertyName("vendoremail")]
            public string? vendoremail { get; set; }

            [JsonPropertyName("username")]
            public string? username { get; set; }

            [JsonPropertyName("gender")]
            public string? gender { get; set; }

            [JsonPropertyName("mobile")]
            public string? mobile { get; set; }

            [JsonPropertyName("officelandline")]
            public string? officelandline { get; set; }

            [JsonPropertyName("address")]
            public string? address { get; set; }

            [JsonPropertyName("city")]
            public string? city { get; set; }

            [JsonPropertyName("state")]
            public string? state { get; set; }

            [JsonPropertyName("zipcode")]
            public string? zipcode { get; set; }

            [JsonPropertyName("officeaddress")]
            public string? officeaddress { get; set; }

            [JsonPropertyName("officecity")]
            public string? officecity { get; set; }

            [JsonPropertyName("officestate")]
            public string? officestate { get; set; }

            [JsonPropertyName("officezipcode")]
            public string? officezipcode { get; set; }
        }

        public class AssignServices
        {
            [JsonPropertyName("servicename")]
            public string? servicename { get; set; }

            [JsonPropertyName("serviceamount")]
            public double? serviceamount { get; set; }
        }
    }
}
