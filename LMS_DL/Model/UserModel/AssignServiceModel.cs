using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class AssignServiceModel
    {
        public class AssignServiceRQ
        {
            [JsonPropertyName("assigned_service_id")]
            public int? assigned_service_id { get; set; }

            [JsonPropertyName("vendor_code")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Vendor Code is required.")]
            [StringLength(5, MinimumLength = 3, ErrorMessage = "Vendor Code must be between 3 and 5 characters.")]
            public string? vendor_code { get; set; }

            [JsonPropertyName("service_type_id")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Service Name is required.")]
            public int? service_type_id { get; set; }

            [JsonPropertyName("service_name_id")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Service Name is required.")]
            public int? service_name_id { get; set; }

            [JsonPropertyName("service_amount")]
            [Required(ErrorMessage = "Service Amount is required.")]
            [Range(0, double.MaxValue, ErrorMessage = "Service Amount must be a positive value.")]
            public double? service_amount { get; set; }

            [JsonPropertyName("is_active")]
            [Required(ErrorMessage = "Please specify whether the service is active.")]
            public bool? is_active { get; set; }

            [JsonPropertyName("created_by")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Created By is required.")]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "Created By must be between 3 and 30 characters.")]
            public string? created_by { get; set; }

        }

        public class AssignServiceRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("assigned_service_id")]
            public int? assigned_service_id { get; set; }
        }
    }
}
