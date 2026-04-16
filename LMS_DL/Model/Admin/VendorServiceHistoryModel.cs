using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class VendorServiceHistoryModel
    {
        public class VendorServiceHistoryRQ
        {
            [JsonPropertyName("vendor_code")]
            public string? vendor_code { get; set; }

            [JsonPropertyName("from_date")]
            public string? from_date { get; set; }

            [JsonPropertyName("to_date")]
            public string? to_date { get; set; }
        }

        public class VendorServiceHistoryRS
        {
            [JsonPropertyName("status")]
            public bool? status { get; set; }
            [JsonPropertyName("message")]
            public string? message { get; set; }
            [JsonPropertyName("vendor_code")]
            public string? vendor_code { get; set; }
            public List<ServiceHistory>? serviceHistories { get; set; }
        }

        public class ServiceHistory
        {
            [JsonPropertyName("service_name")]
            public string? service_name { get; set; }

            [JsonPropertyName("description")]
            public string? description { get; set; }

            [JsonPropertyName("success_count")]
            public int? success_count { get; set; }

            [JsonPropertyName("failed_count")]
            public int? failed_count { get; set; }

            [JsonPropertyName("service_amount")]
            public double? service_amount { get; set; }

            [JsonPropertyName("service_assign_amt")]
            public double? service_assign_amt { get; set; }
        }
    }
}
