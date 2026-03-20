using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class AssignServiceModel_V1
    {
        public class AssignServiceRQ
        {
            public List<ServicesArray>? servicesArray { get; set; }
        }
        public class ServicesArray
        {
            public string? vendor_code { get; set; }
            public int service_type_id { get; set; }
            public int service_name_id { get; set; }
            public string? api_end_point { get; set; }
            public int service_amount { get; set; }
            public bool is_active { get; set; }
            public string? created_by { get; set; }
        }
        public class AssignServiceRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }
        }
    }
}
