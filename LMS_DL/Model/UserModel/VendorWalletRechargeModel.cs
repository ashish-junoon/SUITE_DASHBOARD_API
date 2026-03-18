using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class VendorWalletRechargeModel
    {
        public class VendorWalletRechargeRQ
        {
            [JsonProperty("vendor_code")]
            [Required(ErrorMessage = "Vendor code is required.")]
            [StringLength(5, MinimumLength = 3, ErrorMessage = "Vendor code must be between 3 and 5 characters.")]
            public string? vendor_code { get; set; }

            [JsonProperty("recharge_amount")]
            [Required(ErrorMessage = "Recharge amount is required.")]
            [Range(0.01, double.MaxValue, ErrorMessage = "Recharge amount must be greater than zero.")]
            public double? recharge_amount { get; set; }

            [JsonProperty("recharge_mode")]
            [Required(ErrorMessage = "Recharge mode is required.")]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "Recharge mode must be between 3 and 30 characters.")]
            public string? recharge_mode { get; set; }

            [JsonProperty("transaction_id")]
            [StringLength(100, MinimumLength = 5, ErrorMessage = "Transaction ID must be between 5 and 100 characters.")]
            public string? transaction_id { get; set; }

            [JsonProperty("recharge_status")]
            [Required(ErrorMessage = "Recharge status is required.")]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "Recharge status must be between 3 and 30 characters.")]
            public string? recharge_status { get; set; }

            [JsonProperty("created_by")]
            [Required(ErrorMessage = "Created by is required.")]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "Created by must be between 3 and 50 characters.")]
            public string? created_by { get; set; }

        }

        public class VendorWalletRechargeRS
        {
            [JsonProperty("status")]
            public bool? status { get; set; }

            [JsonProperty("message")]
            public string? message { get; set; }
        }
    }
}
