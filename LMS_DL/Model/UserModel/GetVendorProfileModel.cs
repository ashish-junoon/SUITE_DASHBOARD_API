using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class GetVendorProfileModel
    {
        public class GetVendorProfileRQ
        {
            [JsonPropertyName("VendorCode")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Vendor Code is required.")]
            [StringLength(5, MinimumLength = 3, ErrorMessage = "Vendor Code must be between 3 and 5 characters.")]
            public string? VendorCode { get; set; }
        }
        public class GetVendorProfileRS
        {
            [JsonPropertyName("Status")]
            public bool Status { get; set; }
            [JsonPropertyName("Message")]
            public string? Message { get; set; }

            [JsonPropertyName("getVendorProfileRS")]
            public GetVendorProfile getVendorProfileRS { get; set; }

            [JsonPropertyName("assignServices")]
            public List<AssignServices> assignServices { get; set; }
        }

        public class GetVendorProfile
        {

            [JsonPropertyName("FirstName")]
            public string? FirstName { get; set; }

            [JsonPropertyName("LastName")]
            public string? LastName { get; set; }

            [JsonPropertyName("Email")]
            public string? Email { get; set; }

            [JsonPropertyName("Username")]
            public string? Username { get; set; }

            [JsonPropertyName("Gender")]
            public string? Gender { get; set; }

            [JsonPropertyName("Mobile")]
            public string? Mobile { get; set; }

            [JsonPropertyName("OfficeLandline")]
            public string? OfficeLandline { get; set; }

            [JsonPropertyName("Address")]
            public string? Address { get; set; }

            [JsonPropertyName("City")]
            public string? City { get; set; }

            [JsonPropertyName("State")]
            public string? State { get; set; }

            [JsonPropertyName("ZipCode")]
            public string? ZipCode { get; set; }

            [JsonPropertyName("OfficeAddress")]
            public string? OfficeAddress { get; set; }

            [JsonPropertyName("OfficeCity")]
            public string? OfficeCity { get; set; }

            [JsonPropertyName("OfficeState")]
            public string? OfficeState { get; set; }

            [JsonPropertyName("OfficeZipCode")]
            public string? OfficeZipCode { get; set; }

        }

        public class AssignServices
        {
            [JsonPropertyName("ServiceName")]
            public string? ServiceName { get; set; }

            [JsonPropertyName("ServiceAmount")]
            public string? ServiceAmount { get; set; }
        }
    }
}
