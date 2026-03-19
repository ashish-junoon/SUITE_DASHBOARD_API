using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public  class ServiceTypeModel
    {
        public class ServiceTypeRQ
        {
            [JsonPropertyName("service_type_id")]
            public int? service_type_id { get; set; }

            [JsonPropertyName("service_type")]
            public string? service_type { get; set; }

            [JsonPropertyName("description")]
            public string? description { get; set; }

            [JsonPropertyName("is_active")]
            public bool? is_active { get; set; }

            [JsonPropertyName("created_by")]
            public string? created_by { get; set; }

        }

        public class ServiceTypeRS
        {
            [JsonPropertyName("status")]
            public bool? status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("service_type_id")]
            public int? service_type_id { get; set; }
        }

        public class GetServiceTypeRS
        {
            [JsonPropertyName("status")]
            public bool? status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("serviceTypes")]
            public List<ServiceType> serviceTypes { get; set;}
        }

        public class ServiceType
        {
            [JsonPropertyName("service_type_id")]
            public int? service_type_id { get; set; }

            [JsonPropertyName("service_type")]
            public string? service_type { get; set; }

            [JsonPropertyName("is_active")]
            public bool? is_active { get; set; }

            [JsonPropertyName("description")]
            public string? description { get; set; }

        }
    }
}
