using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class VendorWalletRechargeHistoryModel
    {
        public class VendorWalletRechargeHistoryRS
        {
            [JsonProperty("status")]
            public bool? status { get; set; }

            [JsonProperty("message")]
            public string? message { get; set; }

            public List<Recharge_Data>? data { get; set; }
        }
        public class Recharge_Data
        {
            public int id { get; set; }
            public string? vendor_code { get; set; }
            public double recharge_amount { get; set; }
            public string? recharge_mode { get; set; }
            public string? transaction_id { get; set; }
            public string? recharge_status { get; set; }
            public string? recharge_date { get; set; }
        }
    }
}
