using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class VendorDashboardModel
    {
        public class VendorDashboardRQ
        {
            [JsonPropertyName("from_date")]
            public string? from_date { get; set; }

            [JsonPropertyName("to_date")]
            public string? to_date { get; set; }
        }

        public class VendorDashboardRS
        {
            [JsonPropertyName("status")]
            public bool? status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("vendor_code")]
            public string? vendor_code { get; set; }
            public List<DashboardVendor>dashboardVendors { get; set; }
        }

        public class DashboardVendor
        {
            public List<VendorDashboard> aadharmasked { get; set; }
            public List<VendorDashboard> aadharverifications { get; set; }
            public List<VendorDashboard> panbasic { get; set; }
            public List<VendorDashboard> bankaccount { get; set; }
            public List<VendorDashboard> drivinglicense { get; set; }
            public List<VendorDashboard> gsts { get; set; }
            public List<VendorDashboard> ifsc { get; set; }
            public List<VendorDashboard> upi { get; set; }
            public List<VendorDashboard> user_prefill { get; set; }
            public List<VendorDashboard> transunion { get; set; }
            public List<VendorDashboard> experian { get; set; }
            public List<VendorDashboard> crif { get; set; }
            public List<VendorDashboard> register_e_mandate{ get; set; }
            public List<VendorDashboard> pull_payment { get; set; }
            public List<VendorDashboard> payment_getways { get; set; }
        }

        public class VendorDashboard
        {
            [JsonPropertyName("service_name")]
            public string? service_name { get; set; }
            [JsonPropertyName("success_count")]
            public int? success_count { get; set; }

            [JsonPropertyName("failed_count")]
            public int? failed_count { get; set; }

            [JsonPropertyName("service_amount")]
            public double? service_amount { get; set; }
        }

    }
}
