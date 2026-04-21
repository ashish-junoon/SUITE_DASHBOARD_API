using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL.Model.Admin
{
    public class ChangePasswordModel
    {
        public class ChangePasswordRQ
        {
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Old Password is required.")]
            public string? OldPassword { get; set; }

            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "New Password is required.")]
            [System.ComponentModel.DataAnnotations.MinLength(6, ErrorMessage = "New Password must be at least 6 characters long.")]
            public string? NewPassword { get; set; }

            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Confirm Password is required.")]
            [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Confirm Password must match New Password.")]
            public string? ConfirmPassword { get; set; }
        }

        public class ChangePasswordRS
        {
            public bool status { get; set; }
            public string message { get; set; } = string.Empty;
        }
    }
}
