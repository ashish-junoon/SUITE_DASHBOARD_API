using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class GetVendorDocumentModel
    {
        public class GetVendorDocumentRQ
        {
            public string? vendor_code { get; set; }
        }
        public class GetVendorDocumentRS
        {
            public bool? status { get; set; }
            public string? message { get; set; }
            public List<VendorDocument>? documents { get; set; }
        }
        public class VendorDocument
        {
            public int? Id { get; set; }
            public string? document_name { get; set; }
            public string? file_name { get; set; }
            public string? vendor_code { get; set; }
            public string? created_by { get; set; }
            public string? created_date { get; set; }
        }
    }
}
