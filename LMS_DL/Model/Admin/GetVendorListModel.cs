using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class GetVendorListModel
    {

        public class GetVendorListRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("getVendorLists")]
            public List<GetVendorList> getVendorLists { get; set; }
        }
        public class GetVendorList
        {
            [JsonPropertyName("id")]
            public int? id { get; set; }

            [JsonPropertyName("vendorname")]
            public string? vendorname { get; set; }

            [JsonPropertyName("vendorcode")]
            public string? vendorcode { get; set; }

            [JsonPropertyName("companyname")]
            public string? companyname { get; set; }

            [JsonPropertyName("isactive")]
            public bool? isactive { get; set; }

            [JsonPropertyName("vendorfirstname")]
            public string? vendorfirstname { get; set; }

            [JsonPropertyName("vendorlastname")]
            public string? vendorlastname { get; set; }

            [JsonPropertyName("vendoremail")]
            public string? vendoremail { get; set; }

            [JsonPropertyName("username")]
            public string? username { get; set; }

            [JsonPropertyName("gender")]
            public string? gender { get; set; }

            [JsonPropertyName("mobile")]
            public string? mobile { get; set; }

            [JsonPropertyName("officelandline")]
            public string? officelandline { get; set; }

            [JsonPropertyName("address")]
            public string? address { get; set; }

            [JsonPropertyName("city")]
            public string? city { get; set; }

            [JsonPropertyName("state")]
            public string? state { get; set; }

            [JsonPropertyName("zipcode")]
            public string? zipcode { get; set; }

            [JsonPropertyName("officeaddress")]
            public string? officeaddress { get; set; }

            [JsonPropertyName("officecity")]
            public string? officecity { get; set; }

            [JsonPropertyName("officestate")]
            public string? officestate { get; set; }

            [JsonPropertyName("officezipcode")]
            public string? officezipcode { get; set; }

            [JsonPropertyName("pannumber")]
            public string? pannumber { get; set; }

            [JsonPropertyName("vendortype")]
            public string? vendortype { get; set; }
        }
    }
}
