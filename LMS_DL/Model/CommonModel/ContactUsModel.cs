using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.CommonModel
{
    public class ContactUsModel
    {
        public class ContactUsRQ
        {
            [JsonPropertyName("CaseNumber"), Required]
            public string? CaseNumber { get; set; }

            [JsonPropertyName("Email"), Required]
            public string? Email { get; set; }

            [JsonPropertyName("MobileNumber"), Required]
            public string? MobileNumber { get; set; }

            [JsonPropertyName("Remarks"), Required]
            public string? Remarks { get; set; }

            [JsonPropertyName("Product_Code"), Required]
            public string? Product_Code { get; set; }

            [JsonPropertyName("Company_Id"), Required]
            public string? Company_Id { get; set; }
        }

        public class ContactUsRS
        {
            [JsonPropertyName("Status")]
            public bool? Status { get; set; }
            [JsonPropertyName("Message")]
            public string? Message { get; set; }
        }
    }
}
