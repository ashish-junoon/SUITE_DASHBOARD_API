using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class ServiceNameModel
    {
        public class ServiceNameRQ
        {
            [JsonPropertyName("service_type_id")]
            [Required(ErrorMessage = "Service Type Id is required")]
            public int? service_type_id { get; set; }

            [JsonPropertyName("service_name")]
            [Required(ErrorMessage = "Service Name is required")]
            [StringLength(50, ErrorMessage = "Service Name cannot exceed 50 characters")]
            public string? service_name { get; set; }

            [JsonPropertyName("description")]
            [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
            public string? description { get; set; }

            [JsonPropertyName("price")]
            [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
            public double? price { get; set; }

            [JsonPropertyName("is_active")]
            [Required(ErrorMessage = "IsActive flag is required")]
            public bool? is_active { get; set; }

            [JsonPropertyName("created_by")]
            //[Range(1, int.MaxValue, ErrorMessage = "CreatedBy must be a valid employee name or id")]
            public string? created_by { get; set; }

            [JsonPropertyName("service_name_id")]
            public int service_name_id { get; set; }

            [JsonPropertyName("api_end_point")]
            [Required(ErrorMessage = "api end point is required")]
            public string? api_end_point { get; set; }
        }

        public class ServiceNameRS
        {
            [JsonPropertyName("status")]
            public bool? status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("id")]
            public int? Id { get; set; }
        }

        public class GetServiceNameRS
        {
            [JsonPropertyName("status")]
            public bool? status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            public List<ServiceName>  serviceNames { get; set; }
        }

        public class ServiceName
        {
            [JsonPropertyName("service_type_id")]
            public int? service_type_id { get; set; }

            [JsonPropertyName("service_name_id")]
            public int? service_name_id { get; set; }

            [JsonPropertyName("service_type")]
            public string? service_type { get; set; }

            [JsonPropertyName("service_name")]
            public string? service_name { get; set; }

            [JsonPropertyName("description")]
            public string? description { get; set; }

            [JsonPropertyName("price")]
            public double? price { get; set; }

            [JsonPropertyName("is_active")]
            public bool? is_active { get; set; }

            [JsonPropertyName("api_end_point")]
            public string? api_end_point { get; set; }
        }
    }
}
