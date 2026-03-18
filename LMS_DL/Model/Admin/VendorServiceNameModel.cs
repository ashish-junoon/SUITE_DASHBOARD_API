using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static LMS_DL.Model.Admin.GetVendorListModel;

namespace LMS_DL.Model.Admin
{
    public class VendorServiceNameModel
    {
        public class VendorServiceNameRQ
        {
            [JsonPropertyName("VendorCode")]
            public string? VendorCode { get; set; }
        }
        public class VendorServiceNameRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("getVendorLists")]
            public List<VendorServiceList> vendorServiceLists { get; set; }
        }

        public class VendorServiceList
        {
            [JsonPropertyName("ServiceID")]
            public int? ServiceID { get; set; }

            [JsonPropertyName("vendor_code")]
            public string? vendor_code { get; set; }

            [JsonPropertyName("service_type")]
            public string? service_type { get; set; }

            [JsonPropertyName("service_name")]
            public string? service_name { get; set; }

            [JsonPropertyName("price")]
            public double? price { get; set; }

            [JsonPropertyName("IsActive")]
            public bool? IsActive { get; set; }

            [JsonPropertyName("service_name_id")]
            public int? service_name_id { get; set; }

            [JsonPropertyName("service_type_id")]
            public int? service_type_id { get; set; }
        }
    }
}
