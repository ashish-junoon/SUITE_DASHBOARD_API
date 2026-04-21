using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class UploadVendorDocumentModel
    {
        public class UploadVendorDocumentRQ
        {
            [Required(ErrorMessage = "Vendor code is required.")]
            public string? vendor_code { get; set; }

            [Required(ErrorMessage = "Document name is required.")]
            public string? document_name { get; set; }

            [Required(ErrorMessage = "Created by is required.")]
            public string? created_by { get; set; }

            [Required(ErrorMessage = "Please select file.")]
            public IFormFile? file { get; set; }
        }

        public class UploadVendorDocumentRS
        {
            public bool status { get; set; }
            public string? message { get; set; }
            public string? file_name { get; set; }
        }
    }
}
