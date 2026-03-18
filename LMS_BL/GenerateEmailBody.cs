using LMS_DL.Model.CommonModel;
//using LMS_DL.Model.EasebuzzKyc;
using System.Text;
using static LMS_DL.Model.CommonModel.ContactUsModel;

namespace LMS_BL
{
    public class GenerateEmailBody
    {
        public static string VerifyEmailTemplate(string EmailToName, string email_otp)
        {
            return (
                "<!DOCTYPE html>" +
                "<html lang='en'>" +
                "<head>" +
                    "<meta charset='UTF-8' />" +
                    "<meta name='viewport' content='width=device-width, initial-scale=1.0' />" +
                    "<meta http-equiv='X-UA-Compatible' content='ie=edge' /> " +
                    "<title>Static Template</title>" +
                    "<link href='https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600&display=swap' rel='stylesheet' />" +
                "</head>" +
                "<body style='margin: 0; font-family: \"Poppins\", sans-serif; background: #ffffff; font-size: 14px;'>" +
                    "<div style='max-width: 680px; margin: 0 auto; padding: 0px 29px 60px; background: #f4f7ff; background-color: #6495ED; background-repeat: no-repeat; background-size: 800px 665px; background-position: top center; font-size: 14px; color: #434343;'> " +
                        "<header>" +
                            "<table style='width: 100%;'>" +
                                "<tbody>" +
                                    "<tr style='height: 0;'>" +
                                        "<td></td>" +
                                    "</tr>" +
                                "</tbody>" +
                            "</table>" +
                        "</header>" +
                        "<main>" +
                            "<div style='margin: 0; margin-top: 45px; padding: -1px 30px 115px; background: #ffffff; border-radius: 30px; text-align: center;'>" +
                                "<div style='width: 100%; max-width: 489px; margin: 0 auto;'>" +
                                    "<h1 style='margin: 0; font-size: 24px; font-weight: 500; color: #6495ED;'>" +
                                        "<b>Your One Time Password</b>" +
                                    "</h1> " +
                                    "<p style='margin: 0; margin-top: 20px; font-size: 16px; font-weight: 500; color: #1f1f1f;'><b>" + EmailToName + "</b></p> " +
                                    "<p style='margin: 0; margin-top: 18px; font-weight: 500; letter-spacing: 0.56px; color: #1f1f1f;'>" +
                                        "Thank you for choosing Paisa Udhaar. Use the following OTP to complete the procedure to verify your email address. OTP is valid for" +
                                        "<br/><span style='font-weight: 800; color: #1f1f1f;'><b>5 minutes</b></span>" +
                                        ". Do not share this code with others, including Paisa Udhaar employees." +
                                    "</p>" +
                                    "<p style='margin: 0; margin-top: 36px; font-size: 40px; font-weight: 600; letter-spacing: 25px; color: #6495ED;'>" +
                                        "<b>" + email_otp + "</b>" +
                                    "</p>" +
                                "</div> " +
                            "</div>  " +
                        "</main>" +
                    "</div>" +
                "</body>" +
                "</html>"
            );
        }
        public static string ContactUsCustomerTemplate(ContactUsRQ contact, string CompanyName)
        {
            StringBuilder sBody = new StringBuilder();

            sBody.Append("<!DOCTYPE html>");
            sBody.Append("<html><body style='font-family: Arial, sans-serif; font-size:14px; color:#1f1f1f;'>");

            sBody.Append("<p>Dear Customer,</p>");
            sBody.Append("<p>Thank you for contacting us.</p>");
            sBody.Append("<p>We have successfully received your request. Our support team will review it shortly. Below are your reference details:</p>");

            sBody.Append("<p>");
            sBody.Append("<b>Case Number:</b> " + contact.CaseNumber + "<br>");
            //sBody.Append("<b>Product Code:</b> " + contact.Product_Code + "<br>");
            sBody.Append("<b>Mobile Number:</b> " + contact.MobileNumber + "<br>");
            sBody.Append("<b>Email:</b> " + contact.Email + "<br>");
            sBody.Append("<b>Remarks:</b> " + contact.Remarks);
            sBody.Append("</p>");

            sBody.Append("<p>If you have any further questions, please reply to this email and mention your <b>Case Number</b> for faster assistance.</p>");
            sBody.Append("<p>Thank you for your patience and cooperation.</p>");
            sBody.Append("<p>Warm regards,<br>");
            sBody.Append("Customer Support Team<br>");
            sBody.Append(CompanyName + "</p>");

            sBody.Append("</body></html>");

            return sBody.ToString();
        }
        public static string ContactUsAdminTemplate(ContactUsRQ contact, string ApplicationName)
        {
            StringBuilder sBody = new StringBuilder();

            sBody.Append("<!DOCTYPE html>");
            sBody.Append("<html>");
            sBody.Append("<body style='font-family: Arial, sans-serif; font-size:14px; color:#1f1f1f;'>");

            sBody.Append("<p>Hello Team,</p>");

            sBody.Append("<p>A new <b>Contact Us</b> request has been received. Please find the details below:</p>");

            sBody.Append("<p>");
            sBody.Append("<b>Case Number:</b> " + contact.CaseNumber + "<br>");
            sBody.Append("<b>Email:</b> " + contact.Email + "<br>");
            sBody.Append("<b>Mobile Number:</b> " + contact.MobileNumber + "<br>");
            sBody.Append("<b>Product Code:</b> " + contact.Product_Code + "<br>");
            sBody.Append("<b>Company ID:</b> " + contact.Company_Id);
            sBody.Append("</p>");

            sBody.Append("<p><b>Remarks:</b><br>");
            sBody.Append(contact.Remarks + "</p>");

            sBody.Append("<p>Please review the request and take the necessary action.</p>");

            sBody.Append("<p>Regards,<br>");
            sBody.Append("System Notification<br>");
            sBody.Append(ApplicationName + "</p>");

            sBody.Append("</body>");
            sBody.Append("</html>");

            return sBody.ToString();
        }
        //public static string AadhaarVerificationCustomerTemplate(SendAadhaarVerifyLinkRQ sendAadhaar, VerifyAadhaarViaDigilockerRS verifyAadhaarViaDigilockerRS, string CompanyName)
        //{
        //    StringBuilder sBody = new StringBuilder();

        //    sBody.Append("<!DOCTYPE html>");
        //    sBody.Append("<html><body style='font-family: Arial, sans-serif; font-size:14px; color:#1f1f1f;'>");

        //    sBody.Append($"<p>Dear {sendAadhaar.full_name},</p>");

        //    sBody.Append("<p>Thank you for choosing our services.</p>");

        //    sBody.Append("<p>To proceed further, we request you to complete your <b>Aadhaar verification via digilocker</b>. "
        //               + "Please click on the link below to securely verify your Aadhaar details:</p>");

        //    sBody.Append("<p style='margin:16px 0;'>");
        //    sBody.Append("<a href='" + verifyAadhaarViaDigilockerRS.data?.url + "' " + "text-decoration:none;border-radius:4px;' target='_blank'>");
        //    sBody.Append("Verify Aadhaar");
        //    sBody.Append("</a>");
        //    sBody.Append("</p>");

        //    //sBody.Append("<p><b>Reference Details:</b></p>");
        //    //sBody.Append("<p>");
        //    //sBody.Append("<b>Case Number:</b> " + contact.CaseNumber + "<br>");
        //    //sBody.Append("<b>Aadhaar Number:</b> " + sendAadhaar.aadhaar_number + "<br>");
        //    //sBody.Append("<b>Email:</b> " + sendAadhaar.email_id);
        //    //sBody.Append("</p>");

        //    //sBody.Append("<p><b>Important:</b> This link is confidential and valid for a limited time only. "+ "Please do not share it with anyone.</p>");

        //    //sBody.Append("<p>If you face any issues during verification, please reply to this email "+ "and mention your <b>Aadhaar Number</b> for faster assistance.</p>");

        //    sBody.Append("<p>Warm regards,<br>");
        //    sBody.Append("Customer Support Team<br>");
        //    sBody.Append(CompanyName + "</p>");

        //    sBody.Append("</body></html>");

        //    return sBody.ToString();
        //}

    }
}
