using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class GetVendorAmountModel
    {
        public class GetVendorAmountRS
        {
            public bool status { get; set; }
            public string? message { get; set; }
            public List<GetVendorAmount> getVendorAmount { get; set; }
        }

        public class GetVendorAmount
        {
            public string? vendor_code { get; set; }
            public double? wallet_amount { get; set; }
            public double? wallet_modified_amount { get; set; }
        }
    }
}
