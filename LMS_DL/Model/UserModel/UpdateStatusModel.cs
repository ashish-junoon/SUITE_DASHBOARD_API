using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_DL.Model.UserModel
{
    public class UpdateStatusModel
    {
        public class UpdateStatusRQ
        {
            [JsonPropertyName("id")]
            [Required(ErrorMessage = "Id is required.")]
            public int id { get; set; }

            [JsonPropertyName("is_active")]
            public bool is_active { get; set; }

            [JsonPropertyName("type")]
            [Required(ErrorMessage = "Type is required.")]
            public string type { get; set; } = string.Empty;
        }

        public class UpdateStatusRS
        {
            [JsonPropertyName("status")]
            public bool status { get; set; }

            [JsonPropertyName("message")]
            public string? message { get; set; }

            [JsonPropertyName("id")]
            public int? id { get; set; }
        }
    }
}
